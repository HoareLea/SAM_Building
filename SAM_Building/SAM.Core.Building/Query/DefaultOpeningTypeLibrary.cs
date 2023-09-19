namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static OpeningTypeLibrary DefaultOpeningTypeLibrary()
        {
            return ActiveSetting.Setting.GetValue<OpeningTypeLibrary>(BuildingSettingParameter.DefaultOpeningTypeLibrary);
        }
    }
}