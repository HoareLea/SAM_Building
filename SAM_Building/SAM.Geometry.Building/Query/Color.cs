using SAM.Core.Building;

namespace SAM.Geometry.Building
{
    public static partial class Query
    {
        public static System.Drawing.Color Color(this IPartition partition)
        {
            System.Drawing.Color result = System.Drawing.Color.Empty;
            if (partition == null)
            {
                return result;
            }

            if (partition is Wall)
            {
                return System.Drawing.ColorTranslator.FromHtml("#FFB400");
            }

            if (partition is Floor)
            {
                return System.Drawing.ColorTranslator.FromHtml("#804000");
            }

            if (partition is Roof)
            {
                return System.Drawing.ColorTranslator.FromHtml("#800000");
            }

            if (partition is AirPartition)
            {
                return System.Drawing.ColorTranslator.FromHtml("#FFFF00");
            }

            return result;
        }

        public static System.Drawing.Color Color(this IPartition partition, bool internalEdges)
        {
            System.Drawing.Color result = System.Drawing.Color.Empty;
            if (partition == null)
            {
                return result;
            }

            if (internalEdges)
            {
                return System.Drawing.Color.Gray;
            }

            return Color(partition);
        }

        public static System.Drawing.Color Color(this IOpening opening)
        {
            return Core.Building.Query.Color(OpeningAnalyticalType(opening));
        }

        public static System.Drawing.Color Color(this IOpening opening, OpeningPart openingPart)
        {
            return Core.Building.Query.Color(OpeningAnalyticalType(opening), openingPart);
        }

        public static System.Drawing.Color Color(this IOpening opening, bool internalEdges)
        {
            System.Drawing.Color result = System.Drawing.Color.Empty;
            if (opening == null)
            {
                return result;
            }

            if (internalEdges)
            {
                return System.Drawing.Color.Violet;
            }

            return Core.Building.Query.Color(OpeningAnalyticalType(opening));
        }
    }
}