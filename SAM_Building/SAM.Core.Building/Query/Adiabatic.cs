﻿using System.Collections.Generic;

namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static bool Adiabatic(this HostPartitionType hostPartitionType)
        {
            List<Architectural.MaterialLayer> materialLayers = hostPartitionType?.MaterialLayers;
            if (materialLayers == null)
            {
                return false;
            }

            if (materialLayers.Count == 0)
            {
                return true;
            }

            return materialLayers.Find(x => double.IsNaN(x.Thickness)) != null;
        }
    }
}