namespace SAM.Geometry.Building
{
    public static partial class Query
    {
        public static double MinElevation(this BuildingModel buildingModel, Space space)
        {
            if (buildingModel == null || space == null)
            {
                return double.NaN;
            }

            Spatial.BoundingBox3D boundingBox3D = buildingModel.GetShell(space)?.GetBoundingBox();
            if (boundingBox3D == null)
            {
                return double.NaN;
            }

            return boundingBox3D.Min.Z;
        }
    }
}