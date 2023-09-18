﻿using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Building;
using SAM.Geometry.Spatial;
using System;

namespace SAM.Geometry.Building
{
    public class Space : SAMObject, ISAMGeometry3DObject, IBuildingObject
    {
        private Point3D location;
        private InternalCondition internalCondition;

        public Space(Space space)
            : base(space)
        {
            location = space.Location;
            internalCondition = space.InternalCondition;
        }

        public Space(Guid guid, Space space)
        : base(guid, space)
        {
            location = space.Location;
            internalCondition = space.InternalCondition;
        }

        public Space(Guid guid, string name, Point3D location)
            : base(guid, name)
        {
            if (location != null)
            {
                this.location = new Point3D(location);
            }
        }

        public Space(Guid guid, Space space, string name, Point3D location)
            : base(name, guid, space)
        {
            if (location != null)
            {
                this.location = new Point3D(location);
            }
        }

        public Space(string name)
            : base(name)
        {
        }

        public Space(string name, Point3D location)
            : base(name)
        {
            if (location != null)
            {
                this.location = new Point3D(location);
            }
        }

        public Space(Space space, string name, Point3D location)
            : base(name, space)
        {
            internalCondition = space.InternalCondition;

            if (location != null)
            {
                this.location = new Point3D(location);
            }
        }

        public Space(JObject jObject)
            : base(jObject)
        {
        }

        public Point3D Location
        {
            get
            {
                if (location == null)
                    return null;

                return new Point3D(location);
            }
        }

        public bool IsPlaced()
        {
            return location != null && location.IsValid();
        }

        public InternalCondition InternalCondition
        {
            get
            {
                if (internalCondition == null)
                    return null;

                return new InternalCondition(internalCondition);
            }

            set
            {
                if (value == null)
                    internalCondition = null;
                else
                    internalCondition = new InternalCondition(Guid.NewGuid(), value);
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            if (!base.FromJObject(jObject))
                return false;

            if (jObject.ContainsKey("Location"))
                location = new Point3D(jObject.Value<JObject>("Location"));

            if (jObject.ContainsKey("InternalCondition"))
                internalCondition = new InternalCondition(jObject.Value<JObject>("InternalCondition"));

            return true;
        }

        public override JObject ToJObject()
        {
            JObject jObject = base.ToJObject();
            if (jObject == null)
                return jObject;

            if (location != null)
                jObject.Add("Location", location.ToJObject());

            if (internalCondition != null)
                jObject.Add("InternalCondition", internalCondition.ToJObject());

            return jObject;
        }

        public void Transform(Transform3D transform3D)
        {
            if (location != null)
                location = Location.Transform(transform3D);
        }

        public void Move(Vector3D vector3D)
        {
            location = location?.GetMoved(vector3D) as Point3D;
        }
    }
}