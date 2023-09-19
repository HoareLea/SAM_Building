namespace SAM.Geometry.Building
{
    public static partial class Query
    {
        public static bool Adiabatic(this IHostPartition hostPartition)
        {
            if (hostPartition == null)
            {
                return false;
            }

            if (Core.Building.Query.Adiabatic(hostPartition.Type()))
            {
                return true;
            }

            if (!hostPartition.TryGetValue(HostPartitionParameter.Adiabatic, out bool result))
            {
                return false;
            }

            return result;
        }
    }
}