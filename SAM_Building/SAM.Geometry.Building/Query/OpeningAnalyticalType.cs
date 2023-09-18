using SAM.Core.Building;

namespace SAM.Geometry.Building
{
    public static partial class Query
    {
        public static OpeningAnalyticalType OpeningAnalyticalType(this IOpening opening)
        {
            if (opening == null)
            {
                return Core.Building.OpeningAnalyticalType.Undefined;
            }

            if (opening is Door)
            {
                return Core.Building.OpeningAnalyticalType.Door;
            }

            if (opening is Window)
            {
                return Core.Building.OpeningAnalyticalType.Window;
            }

            return Core.Building.OpeningAnalyticalType.Undefined;
        }
    }
}