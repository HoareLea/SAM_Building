using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static Architectural.MaterialLayer ExternalMaterialLayer(this HostPartitionType hostPartitionType)
        {
            List<Architectural.MaterialLayer> materialLayers = hostPartitionType?.MaterialLayers;
            if (materialLayers == null || materialLayers.Count == 0)
                return null;

            return materialLayers.Last();
        }
    }
}