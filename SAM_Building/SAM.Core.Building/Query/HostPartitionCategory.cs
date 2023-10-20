namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static HostPartitionCategory HostPartitionCategory(this HostPartitionType hostPartitionType)
        {
            if (hostPartitionType == null)
            {
                return Core.Building.HostPartitionCategory.Undefined;
            }

            if (hostPartitionType is WallType)
            {
                return Core.Building.HostPartitionCategory.Wall;
            }

            if (hostPartitionType is FloorType)
            {
                return Core.Building.HostPartitionCategory.Floor;
            }

            if (hostPartitionType is RoofType)
            {
                return Core.Building.HostPartitionCategory.Roof;
            }

            return Core.Building.HostPartitionCategory.Undefined;
        }

        public static HostPartitionCategory HostPartitionCategory(this PartitionAnalyticalType partitionAnalyticalType)
        {
            switch (partitionAnalyticalType)
            {
                case Core.Building.PartitionAnalyticalType.Air:
                    return Core.Building.HostPartitionCategory.Undefined;
                case Core.Building.PartitionAnalyticalType.Undefined:
                    return Core.Building.HostPartitionCategory.Undefined;
                case Core.Building.PartitionAnalyticalType.CurtainWall:
                    return Core.Building.HostPartitionCategory.Wall;
                case Core.Building.PartitionAnalyticalType.ExternalFloor:
                    return Core.Building.HostPartitionCategory.Floor;
                case Core.Building.PartitionAnalyticalType.ExternalWall:
                    return Core.Building.HostPartitionCategory.Wall;
                case Core.Building.PartitionAnalyticalType.InternalFloor:
                    return Core.Building.HostPartitionCategory.Floor;
                case Core.Building.PartitionAnalyticalType.InternalWall:
                    return Core.Building.HostPartitionCategory.Wall;
                case Core.Building.PartitionAnalyticalType.OnGradeFloor:
                    return Core.Building.HostPartitionCategory.Floor;
                case Core.Building.PartitionAnalyticalType.Roof:
                    return Core.Building.HostPartitionCategory.Roof;
                case Core.Building.PartitionAnalyticalType.Shade:
                    return Core.Building.HostPartitionCategory.Undefined;
                case Core.Building.PartitionAnalyticalType.UndergroundCeiling:
                    return Core.Building.HostPartitionCategory.Floor;
                case Core.Building.PartitionAnalyticalType.UndergroundFloor:
                    return Core.Building.HostPartitionCategory.Floor;
                case Core.Building.PartitionAnalyticalType.UndergroundWall:
                    return Core.Building.HostPartitionCategory.Wall;
            }

            return Core.Building.HostPartitionCategory.Undefined;
        }
    }
}