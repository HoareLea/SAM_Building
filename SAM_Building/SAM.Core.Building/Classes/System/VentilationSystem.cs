﻿using Newtonsoft.Json.Linq;

namespace SAM.Core.Building
{
    public class VentilationSystem : MechanicalSystem
    {
        public VentilationSystem(string id, VentilationSystemType ventilationSystemType)
            : base(id, ventilationSystemType)
        {

        }

        public VentilationSystem(System.Guid guid, string id, VentilationSystem VentilationSystem)
            : base(guid, id, VentilationSystem)
        {

        }

        public VentilationSystem(VentilationSystem ventilationSystem)
            : base(ventilationSystem)
        {

        }

        public VentilationSystem(JObject jObject)
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