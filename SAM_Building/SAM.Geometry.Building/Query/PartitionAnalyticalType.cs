using SAM.Core.Building;
using System.Collections.Generic;

namespace SAM.Geometry.Building
{
    public static partial class Query
    {
        public static PartitionAnalyticalType PartitionAnalyticalType(this BuildingModel buildingModel, IPartition partition, double tolerance_Angle = Core.Tolerance.Angle, double tolerance_Distance = Core.Tolerance.Distance)
        {
            if (buildingModel == null || partition == null)
            {
                return Core.Building.PartitionAnalyticalType.Undefined;
            }

            if (partition is AirPartition)
            {
                return Core.Building.PartitionAnalyticalType.Air;
            }

            List<Space> spaces = buildingModel.GetSpaces(partition);
            if (spaces == null || spaces.Count == 0)
            {
                return Core.Building.PartitionAnalyticalType.Shade;
            }

            if (partition is Roof)
            {
                return Core.Building.PartitionAnalyticalType.Roof;
            }

            Architectural.Terrain terrain = buildingModel.Terrain;

            if (partition is Wall)
            {
                Wall wall = partition as Wall;

                if (buildingModel.GetMaterialType(wall.Type) == Core.MaterialType.Transparent)
                {
                    return Core.Building.PartitionAnalyticalType.CurtainWall;
                }

                if (spaces.Count > 1)
                {
                    return Core.Building.PartitionAnalyticalType.InternalWall;
                }

                if (terrain == null)
                {
                    return Core.Building.PartitionAnalyticalType.Undefined;
                }

                if (terrain.Below(wall, tolerance_Distance))
                {
                    return Core.Building.PartitionAnalyticalType.UndergroundWall;
                }

                return Core.Building.PartitionAnalyticalType.ExternalWall;
            }

            if (partition is Floor)
            {
                Floor floor = partition as Floor;

                if (spaces.Count > 1)
                {
                    return Core.Building.PartitionAnalyticalType.InternalFloor;
                }

                if (terrain == null)
                {
                    return Core.Building.PartitionAnalyticalType.Undefined;
                }

                if (terrain.On(floor, tolerance_Distance))
                {
                    HostPartitionCategory hostPartitionCategory = Query.HostPartitionCategory(floor, tolerance_Angle);
                    if (hostPartitionCategory == Core.Building.HostPartitionCategory.Roof)
                    {
                        return Core.Building.PartitionAnalyticalType.UndergroundCeiling;
                    }
                    else
                    {
                        return Core.Building.PartitionAnalyticalType.OnGradeFloor;
                    }
                }

                if (terrain.Below(floor, tolerance_Distance))
                {
                    return Core.Building.PartitionAnalyticalType.UndergroundFloor;
                }
            }

            return Core.Building.PartitionAnalyticalType.Undefined;
        }
    }
}