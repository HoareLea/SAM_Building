namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static bool Transparent(this HostPartitionType hostPartitionType, MaterialLibrary materialLibrary = null)
        {
            MaterialType materialType = Architectural.Query.MaterialType(hostPartitionType?.MaterialLayers, materialLibrary);
            return materialType == MaterialType.Transparent;
        }
    }
}