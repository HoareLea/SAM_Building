using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static Architectural.MaterialLayer InternalMaterialLayer(this HostPartitionType hostPartitionType)
        {
            List<Architectural.MaterialLayer> materialLayer = hostPartitionType?.MaterialLayers;
            if (materialLayer == null || materialLayer.Count == 0)
                return null;

            return materialLayer.First();
        }
    }
}