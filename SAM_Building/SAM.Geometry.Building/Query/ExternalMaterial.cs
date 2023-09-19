using SAM.Core;

namespace SAM.Geometry.Building
{
    public static partial class Query
    {
        public static IMaterial ExternalMaterial(this IHostPartition hostPartition, MaterialLibrary materialLibrary)
        {
            return Core.Building.Query.ExternalMaterial(hostPartition?.Type(), materialLibrary);

        }
    }
}