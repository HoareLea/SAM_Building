
namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static System.Drawing.Color Color(this OpeningType openingType, bool internalEdges)
        {
            System.Drawing.Color result = System.Drawing.Color.Empty;
            if (openingType == null)
            {
                return result;
            }

            if (internalEdges)
            {
                return System.Drawing.Color.Violet;
            }

            return Color(OpeningAnalyticalType(openingType));
        }

        public static System.Drawing.Color Color(this PartitionAnalyticalType partitionAnalyticalType)
        {
            switch (partitionAnalyticalType)
            {
                case Building.PartitionAnalyticalType.CurtainWall:
                    return System.Drawing.Color.BlueViolet;

                case Building.PartitionAnalyticalType.ExternalFloor:
                    return System.Drawing.ColorTranslator.FromHtml("#40B4FF");

                case Building.PartitionAnalyticalType.InternalFloor:
                    return System.Drawing.ColorTranslator.FromHtml("#80FFFF");

                case Building.PartitionAnalyticalType.Roof:
                    return System.Drawing.ColorTranslator.FromHtml("#800000");

                case Building.PartitionAnalyticalType.Shade:
                    return System.Drawing.ColorTranslator.FromHtml("#FFCE9D");

                case Building.PartitionAnalyticalType.OnGradeFloor:
                    return System.Drawing.ColorTranslator.FromHtml("#804000");

                case Building.PartitionAnalyticalType.Undefined:
                    return System.Drawing.ColorTranslator.FromHtml("#FFB400");

                case Building.PartitionAnalyticalType.UndergroundCeiling:
                    return System.Drawing.ColorTranslator.FromHtml("#408080");

                case Building.PartitionAnalyticalType.UndergroundFloor:
                    return System.Drawing.ColorTranslator.FromHtml("#804000");

                case Building.PartitionAnalyticalType.UndergroundWall:
                    return System.Drawing.ColorTranslator.FromHtml("#A55200");

                case Building.PartitionAnalyticalType.ExternalWall:
                    return System.Drawing.ColorTranslator.FromHtml("#FFB400");

                case Building.PartitionAnalyticalType.InternalWall:
                    return System.Drawing.ColorTranslator.FromHtml("#008000");

                case Building.PartitionAnalyticalType.Air:
                    return System.Drawing.ColorTranslator.FromHtml("#FFFF00");
            }

            return System.Drawing.Color.Empty;
        }

        public static System.Drawing.Color Color(this OpeningAnalyticalType openingAnalyticalType)
        {
            switch (openingAnalyticalType)
            {
                case Building.OpeningAnalyticalType.Door:
                    return Color(openingAnalyticalType, OpeningPart.Frame);

                case Building.OpeningAnalyticalType.Window:
                    return Color(openingAnalyticalType, OpeningPart.Pane);

                case Building.OpeningAnalyticalType.Undefined:
                    return System.Drawing.Color.Empty;
            }

            return System.Drawing.Color.Empty;
        }

        public static System.Drawing.Color Color(this OpeningAnalyticalType openingAnalyticalType, OpeningPart openingPart)
        {
            switch (openingAnalyticalType)
            {
                case Building.OpeningAnalyticalType.Door:
                    switch (openingPart)
                    {
                        case OpeningPart.Frame:
                            return System.Drawing.Color.Brown;

                        case OpeningPart.Pane:
                            return System.Drawing.Color.Blue;
                    }
                    break;


                case Building.OpeningAnalyticalType.Window:
                    switch (openingPart)
                    {
                        case OpeningPart.Frame:
                            return System.Drawing.Color.Brown;

                        case OpeningPart.Pane:
                            return System.Drawing.Color.Blue;
                    }
                    break;

                case Building.OpeningAnalyticalType.Undefined:
                    return System.Drawing.Color.Empty;
            }

            return System.Drawing.Color.Empty;
        }

        public static System.Drawing.Color Color(this BoundaryType boundaryType)
        {
            switch (boundaryType)
            {
                case Building.BoundaryType.Adiabatic:
                    return System.Drawing.Color.FromArgb(192, 128, 255);

                case Building.BoundaryType.Exposed:
                    return System.Drawing.Color.FromArgb(128, 255, 128);

                case Building.BoundaryType.Ground:
                    return System.Drawing.Color.FromArgb(128, 255, 255);

                case Building.BoundaryType.Linked:
                    return System.Drawing.Color.FromArgb(255, 128, 128);

                case Building.BoundaryType.Shade:
                    return System.Drawing.Color.FromArgb(255, 180, 128);

            }

            return System.Drawing.Color.Empty;
        }
    }
}