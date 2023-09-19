using SAM.Core.Building;

namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static ProfileLibrary DefaultProfileLibrary()
        {
            return ActiveSetting.Setting.GetValue<ProfileLibrary>(BuildingSettingParameter.DefaultProfileLibrary);
        }
    }
}