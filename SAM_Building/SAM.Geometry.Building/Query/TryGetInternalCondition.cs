﻿using SAM.Core;
using SAM.Core.Building;
using System.Collections.Generic;

namespace SAM.Geometry.Building
{
    public static partial class Query
    {
        public static bool TryGetInternalCondition(this Space space, InternalConditionLibrary internalConditionLibrary, TextMap textMap, out InternalCondition internalCondition)
        {
            internalCondition = null;

            if (!TryGetInternalConditions(space, internalConditionLibrary, textMap, out List<InternalCondition> internalConditions) || internalConditions == null || internalConditions.Count == 0)
            {
                return false;
            }

            internalCondition = internalConditions.Find(x => x != null);
            return internalCondition != null;
        }
    }
}