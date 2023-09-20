
namespace SAM.Geometry.Building
{
    public static partial class Query
    {
        public static Architectural.MaterialLayer InternalConstructionLayer(this IHostPartition hostPartition)
        {
            return Core.Building.Query.InternalMaterialLayer(hostPartition?.Type());
        }
    }
}