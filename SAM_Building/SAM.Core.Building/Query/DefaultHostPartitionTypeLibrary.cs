namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static HostPartitionTypeLibrary DefaultHostPartitionTypeLibrary()
        {
            return ActiveSetting.Setting.GetValue<HostPartitionTypeLibrary>(BuildingSettingParameter.DefaultHostPartitionTypeLibrary);
        }
    }
}