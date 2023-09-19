using SAM.Core;
using SAM.Core.Building;

namespace SAM.Analytical
{
    public static partial class Query
    {
        public static MaterialLibrary DefaultMaterialLibrary()
        {
            return ActiveSetting.Setting.GetValue<MaterialLibrary>(BuildingSettingParameter.DefaultMaterialLibrary);
        }
    }
}