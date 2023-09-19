namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static IMaterial ExternalMaterial(this HostPartitionType hostPartitionType, MaterialLibrary materialLibrary)
        {
            if (hostPartitionType == null || materialLibrary == null)
                return null;

            Architectural.MaterialLayer materialLayer = ExternalMaterialLayer(hostPartitionType);
            if (materialLayer == null)
                return null;

            return Architectural.Query.Material(materialLayer, materialLibrary);
        }
    }
}