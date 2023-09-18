﻿using Newtonsoft.Json.Linq;

using SAM.Core;
using SAM.Core.Building;
using SAM.Geometry.Spatial;

namespace SAM.Geometry.Building
{
    public abstract class BuildingElement<T> : SAMInstance<T>, IBuildingObject, IFace3DObject where T : BuildingElementType
    {
        private Face3D face3D;

        public BuildingElement(BuildingElement<T> buildingElement)
            : base(buildingElement)
        {
            face3D = buildingElement?.Face3D?.Clone() as Face3D;
        }

        public BuildingElement(JObject jObject)
            : base(jObject)
        {

        }

        public BuildingElement(T buildingElementType, Face3D face3D)
            : base(buildingElementType)
        {
            this.face3D = face3D;
        }

        public BuildingElement(System.Guid guid, T buildingElementType, Face3D face3D)
            : base(guid, buildingElementType)
        {
            this.face3D = face3D;
        }

        public BuildingElement(System.Guid guid, BuildingElement<T> buildingElement, Face3D face3D)
            : base(guid, buildingElement)
        {
            if (face3D != null)
            {
                this.face3D = new Face3D(face3D);
            }
        }

        public Face3D Face3D
        {
            get
            {
                if (face3D == null)
                    return null;

                return new Face3D(face3D);
            }
        }

        public virtual double GetArea()
        {
            if (face3D == null)
            {
                return double.NaN;
            }

            return face3D.GetArea();
        }

        public virtual void Transform(Transform3D transform3D)
        {
            face3D = Geometry.Spatial.Query.Transform(face3D, transform3D);
        }

        public virtual void Move(Vector3D vector3D)
        {
            face3D = face3D?.GetMoved(vector3D) as Face3D;
        }

        public override bool FromJObject(JObject jObject)
        {
            if (!base.FromJObject(jObject))
            {
                return false;
            }

            if (jObject.ContainsKey("Face3D"))
            {
                face3D = Geometry.Create.ISAMGeometry<Face3D>(jObject.Value<JObject>("Face3D"));
            }

            return true;
        }

        public override JObject ToJObject()
        {
            JObject jObject = base.ToJObject();

            if (jObject == null)
            {
                return jObject;
            }

            if (face3D != null)
            {
                jObject.Add("Face3D", face3D.ToJObject());
            }

            return jObject;
        }

        public BoundingBox3D GetBoundingBox(double offset = 0)
        {
            return face3D?.GetBoundingBox(offset);
        }

        public Vector3D Normal
        {
            get
            {
                return face3D?.GetPlane()?.Normal;
            }
        }

    }
}
