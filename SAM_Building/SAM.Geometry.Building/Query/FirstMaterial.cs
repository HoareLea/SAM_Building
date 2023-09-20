using SAM.Core;
using SAM.Geometry.Building;
using SAM.Geometry.Spatial;

namespace SAM.Geometry.Building
{
    public static partial class Query
    {
        public static IMaterial FirstMaterial(this IHostPartition hostPartition, Vector3D direction, MaterialLibrary materialLibrary)
        {
            if (hostPartition == null || direction == null || materialLibrary == null)
                return null;

            Architectural.MaterialLayer materialLayer = FirstMaterialLayer(hostPartition, direction);
            if (materialLayer == null)
                return null;

            return Architectural.Query.Material(materialLayer, materialLibrary);
        }
    }
}