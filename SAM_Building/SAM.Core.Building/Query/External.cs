namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static bool External(this PartitionAnalyticalType panelType)
        {
            switch (panelType)
            {
                case Building.PartitionAnalyticalType.CurtainWall:
                case Building.PartitionAnalyticalType.ExternalFloor:
                case Building.PartitionAnalyticalType.Roof:
                case Building.PartitionAnalyticalType.Shade:
                case Building.PartitionAnalyticalType.OnGradeFloor:
                case Building.PartitionAnalyticalType.UndergroundWall:
                case Building.PartitionAnalyticalType.UndergroundCeiling:
                case Building.PartitionAnalyticalType.ExternalWall:
                    return true;
                default:
                    return false;
            }
        }
    }
}