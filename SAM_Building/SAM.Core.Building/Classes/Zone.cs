﻿using Newtonsoft.Json.Linq;
using System;

namespace SAM.Core.Building
{
    public class Zone : Group, IBuildingObject
    {
        public Zone(string name)
            : base(name)
        {

        }

        public Zone(Guid guid, string name)
            : base(guid, name)
        {

        }

        public Zone(Zone zone, string name)
            : base(zone, name)
        {

        }

        public Zone(Zone zone)
            : base(zone)
        {

        }

        public Zone(JObject jObject)
            : base(jObject)
        {
        }

        public override bool FromJObject(JObject jObject)
        {
            if (!base.FromJObject(jObject))
                return false;

            return true;
        }

        public override JObject ToJObject()
        {
            JObject jObject = base.ToJObject();
            if (jObject == null)
                return null;

            return jObject;
        }
    }
}