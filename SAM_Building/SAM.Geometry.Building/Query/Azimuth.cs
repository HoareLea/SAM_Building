using SAM.Geometry.Spatial;

namespace SAM.Geometry.Building
{
    public static partial class Query
    {
        public static double Azimuth(this IPartition partition)
        {
            return Spatial.Query.Azimuth(partition, Vector3D.WorldY);
        }
    }
}