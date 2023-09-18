namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static OpeningAnalyticalType OpeningAnalyticalType(this OpeningType openingType)
        {
            if (openingType == null)
            {
                return Building.OpeningAnalyticalType.Undefined;
            }

            if (openingType is DoorType)
            {
                return Building.OpeningAnalyticalType.Door;
            }

            if (openingType is WindowType)
            {
                return Building.OpeningAnalyticalType.Window;
            }

            return Building.OpeningAnalyticalType.Undefined;
        }
    }
}