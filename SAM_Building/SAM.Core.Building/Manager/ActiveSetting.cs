using SAM.Core;
using SAM.Core.Building;
using System.Reflection;

namespace SAM.Analytical
{
    public static partial class ActiveSetting
    {
        private static Setting setting = Load();

        private static Setting Load()
        {
            Setting setting = ActiveManager.GetSetting(Assembly.GetExecutingAssembly());
            if (setting == null)
                setting = GetDefault();

            return setting;
        }

        public static Setting Setting
        {
            get
            {
                return setting;
            }
        }

        public static Setting GetDefault()
        {
            Setting result = new Setting(Assembly.GetExecutingAssembly());

            //File Names
            result.SetValue(BuildingSettingParameter.DefaultMaterialLibraryFileName, "SAM_MaterialLibrary.JSON");
            result.SetValue(BuildingSettingParameter.DefaultGasMaterialLibraryFileName, "SAM_GasMaterialLibrary.JSON");
            result.SetValue(BuildingSettingParameter.DefaultInternalConditionLibraryFileName, "SAM_InternalConditionLibrary.JSON");
            result.SetValue(BuildingSettingParameter.DefaultProfileLibraryFileName, "SAM_ProfileLibrary.JSON");
            result.SetValue(BuildingSettingParameter.InternaConditionTextMaplFileName, "SAM_InternalConditionTextMap.JSON");
            result.SetValue(BuildingSettingParameter.DefaultSystemTypeLibraryFileName, "SAM_SystemTypeLibrary.JSON");
                        
            result.SetValue(BuildingSettingParameter.DefaultHostPartitionTypeLibraryFileName, "SAM_HostPartitionTypeLibrary.JSON");
            result.SetValue(BuildingSettingParameter.DefaultOpeningTypeLibraryFileName, "SAM_OpeningTypeLibrary.JSON");

            string path = null;

            path = Core.Building.Query.DefaultPath(result, BuildingSettingParameter.DefaultMaterialLibraryFileName);
            if (System.IO.File.Exists(path))
                result.SetValue(BuildingSettingParameter.DefaultMaterialLibrary, Core.Create.IJSAMObject<MaterialLibrary>(System.IO.File.ReadAllText(path)));

            path = Core.Building.Query.DefaultPath(result, BuildingSettingParameter.DefaultGasMaterialLibraryFileName);
            if (System.IO.File.Exists(path))
                result.SetValue(BuildingSettingParameter.DefaultGasMaterialLibrary, Core.Create.IJSAMObject<MaterialLibrary>(System.IO.File.ReadAllText(path)));

            path = Core.Building.Query.DefaultPath(result, BuildingSettingParameter.DefaultInternalConditionLibraryFileName);
            if (System.IO.File.Exists(path))
                result.SetValue(BuildingSettingParameter.DefaultInternalConditionLibrary, Core.Create.IJSAMObject<InternalConditionLibrary>(System.IO.File.ReadAllText(path)));

            path = Core.Building.Query.DefaultPath(result, BuildingSettingParameter.DefaultProfileLibraryFileName);
            if (System.IO.File.Exists(path))
                result.SetValue(BuildingSettingParameter.DefaultProfileLibrary, Core.Create.IJSAMObject<ProfileLibrary>(System.IO.File.ReadAllText(path)));

            path = Core.Building.Query.DefaultPath(result, BuildingSettingParameter.InternaConditionTextMaplFileName);
            if (System.IO.File.Exists(path))
                result.SetValue(BuildingSettingParameter.InternalConditionTextMap, Core.Create.IJSAMObject<TextMap>(System.IO.File.ReadAllText(path)));

            path = Core.Building.Query.DefaultPath(result, BuildingSettingParameter.DefaultSystemTypeLibraryFileName);
            if (System.IO.File.Exists(path))
                result.SetValue(BuildingSettingParameter.DefaultSystemTypeLibrary, Core.Create.IJSAMObject<SystemTypeLibrary>(System.IO.File.ReadAllText(path)));

            path = Core.Building.Query.DefaultPath(result, BuildingSettingParameter.DefaultHostPartitionTypeLibraryFileName);
            if (System.IO.File.Exists(path))
                result.SetValue(BuildingSettingParameter.DefaultHostPartitionTypeLibrary, Core.Create.IJSAMObject<HostPartitionTypeLibrary>(System.IO.File.ReadAllText(path)));

            path = Core.Building.Query.DefaultPath(result, BuildingSettingParameter.DefaultOpeningTypeLibraryFileName);
            if (System.IO.File.Exists(path))
                result.SetValue(BuildingSettingParameter.DefaultOpeningTypeLibrary, Core.Create.IJSAMObject<OpeningTypeLibrary>(System.IO.File.ReadAllText(path)));

            return result;
        }
    }
}