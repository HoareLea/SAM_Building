﻿using Newtonsoft.Json.Linq;
using SAM.Core.Building;
using SAM.Geometry.Spatial;

namespace SAM.Geometry.Building
{
    public class Roof : HostPartition<RoofType>
    {
        public Roof(Roof roof)
            : base(roof)
        {

        }

        public Roof(JObject jObject)
            : base(jObject)
        {

        }
        public Roof(RoofType roofType, Face3D face3D)
            : base(roofType, face3D)
        {

        }
        public Roof(System.Guid guid, RoofType roofType, Face3D face3D)
            : base(guid, roofType, face3D)
        {

        }

        public Roof(System.Guid guid, Roof roof, Face3D face3D, double tolerance = Core.Tolerance.Distance)
            : base(guid, roof, face3D, tolerance)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            if (!base.FromJObject(jObject))
            {
                return false;
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

            return jObject;
        }

    }
}
