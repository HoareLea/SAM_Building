using SAM.Core.Building;
using SAM.Geometry.Spatial;
using System.Linq;

namespace SAM.Geometry.Building
{
    public static partial class Query
    {
        public static HostPartitionType DefaultHostPartitionType(Vector3D normal, double tolerance = Core.Tolerance.Angle)
        {
            if (normal == null)
            {
                return null;
            }

            HostPartitionTypeLibrary hostPartitionTypeLibrary = Core.Building.Query.DefaultHostPartitionTypeLibrary();
            if (hostPartitionTypeLibrary == null)
            {
                return null;
            }

            HostPartitionCategory hostPartitionCategory = HostPartitionCategory(normal, tolerance);
            switch (hostPartitionCategory)
            {
                case Core.Building.HostPartitionCategory.Floor:
                    return hostPartitionTypeLibrary.GetHostPartitionTypes(Core.Building.PartitionAnalyticalType.InternalFloor)?.FirstOrDefault();

                case Core.Building.HostPartitionCategory.Roof:
                    return hostPartitionTypeLibrary.GetHostPartitionTypes(Core.Building.PartitionAnalyticalType.Roof)?.FirstOrDefault();

                case Core.Building.HostPartitionCategory.Wall:
                    return hostPartitionTypeLibrary.GetHostPartitionTypes(Core.Building.PartitionAnalyticalType.ExternalWall)?.FirstOrDefault();

                default:
                    return null;
            }
        }

        public static HostPartitionType DefaultHostPartitionType(Face3D face3D, double tolerance = Core.Tolerance.Angle)
        {
            return DefaultHostPartitionType(face3D?.GetPlane()?.Normal, tolerance);
        }

        public static T DefaultHostPartitionType<T>(this PartitionAnalyticalType partitionAnalyticalType) where T : HostPartitionType
        {
            HostPartitionTypeLibrary hostPartitionTypeLibrary = Core.Building.Query.DefaultHostPartitionTypeLibrary();
            if (hostPartitionTypeLibrary == null)
            {
                return null;
            }

            return hostPartitionTypeLibrary.GetHostPartitionTypes(partitionAnalyticalType)?.Find(x => x is T) as T;
        }

        public static HostPartitionType DefaultHostPartitionType(this PartitionAnalyticalType partitionAnalyticalType)
        {
            return DefaultHostPartitionType<HostPartitionType>(partitionAnalyticalType);
        }
    }
}