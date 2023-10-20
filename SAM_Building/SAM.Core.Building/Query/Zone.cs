using SAM.Core.Building;

namespace SAM.Core.Building
{
    public static partial class Create
    {
        public static Zone Zone(System.Guid guid, string name, ZoneType zoneType)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            return Zone(guid, name, zoneType.Description());
        }

        public static Zone Zone(System.Guid guid, string name, string zoneCategory)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            Zone result = new Zone(guid, name);
            if (zoneCategory != null)
                result.SetValue(ZoneParameter.ZoneCategory, zoneCategory);

            return result;
        }
    }
}