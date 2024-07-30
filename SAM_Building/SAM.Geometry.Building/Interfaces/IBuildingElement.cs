using SAM.Core;
using SAM.Core.Building;
using SAM.Geometry.Object.Spatial;
using SAM.Geometry.Spatial;

namespace SAM.Geometry.Building
{
    public interface IBuildingElement : IBuildingObject, IParameterizedSAMObject, IFace3DObject, ISAMObject
    {
        void Transform(Transform3D transform3D);

        void Move(Vector3D vector3D);

        BoundingBox3D GetBoundingBox(double offset = 0);

    }
}
