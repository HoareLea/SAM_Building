using SAM.Core.Building;
using System.Collections.Generic;

namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static PartitionAnalyticalType? PartitionAnalyticalType(this HostPartitionType hostPartitionType)
        {
            if (hostPartitionType == null)
            {
                return null;
            }

            if (!hostPartitionType.TryGetValue(HostPartitionTypeParameter.PartitionAnalyticalType, out string value, true))
            {
                return null;
            }

            return Core.Query.Enum<PartitionAnalyticalType>(value);
        }

        public static PartitionAnalyticalType? PartitionAnalyticalType(this OpeningType openingType)
        {
            if (openingType == null)
            {
                return null;
            }

            if (!openingType.TryGetValue(OpeningTypeParameter.PartitionAnalyticalType, out string value, true))
            {
                return null;
            }

            return Core.Query.Enum<PartitionAnalyticalType>(value);
        }
    }
}