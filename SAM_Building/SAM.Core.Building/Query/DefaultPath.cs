using SAM.Core;
using System.Reflection;

namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static string DefaultPath(this Setting setting, BuildingSettingParameter buildingSettingParameter)
        {
            if (setting == null)
                return null;

            string fileName;
            if (!setting.TryGetValue(buildingSettingParameter, out fileName) || string.IsNullOrWhiteSpace(fileName))
                return null;

            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            string resourcesDirectory = Core.Query.ResourcesDirectory(Assembly.GetExecutingAssembly());
            if (string.IsNullOrWhiteSpace(resourcesDirectory))
                return null;

            return System.IO.Path.Combine(resourcesDirectory, fileName);
        }
    }
}