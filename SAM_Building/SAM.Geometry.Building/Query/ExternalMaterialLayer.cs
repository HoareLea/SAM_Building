namespace SAM.Geometry.Building
{
    public static partial class Query
    {
        public static Architectural.MaterialLayer ExternalMaterialLayer(this IHostPartition hostPartition)
        {
            return Core.Building.Query.ExternalMaterialLayer(hostPartition?.Type());
        }
    }
}