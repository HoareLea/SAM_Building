using SAM.Architectural;

namespace SAM.Geometry.Building
{
    public static partial class Query
    {
        public static Core.Building.BoundaryType? BoundaryType(this BuildingModel buildingModel, IPartition partition)
        {
            if (partition == null)
            {
                return null;
            }

            if (partition is IHostPartition)
            {
                if (Adiabatic((IHostPartition)partition))
                {
                    return Core.Building.BoundaryType.Adiabatic;
                }
            }

            if (buildingModel.Shade(partition))
            {
                return Core.Building.BoundaryType.Shade;
            }

            ITerrain terrain = buildingModel.Terrain;
            if (terrain != null)
            {
                if (terrain.Below(partition.Face3D) || terrain.On(partition.Face3D))
                {
                    return Core.Building.BoundaryType.Ground;
                }
            }

            if (buildingModel.External(partition))
            {
                return Core.Building.BoundaryType.Exposed;
            }

            if (buildingModel.Internal(partition))
            {
                return Core.Building.BoundaryType.Linked;
            }

            return null;
        }
    }
}