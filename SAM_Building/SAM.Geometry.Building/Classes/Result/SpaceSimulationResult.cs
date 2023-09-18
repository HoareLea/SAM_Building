using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Building;
using System;

namespace SAM.Geometry.Building
{
    public class SpaceSimulationResult : Result, IBuildingObject
    {
        public SpaceSimulationResult(string name, string source, string reference)
            : base(name, source, reference)
        {

        }

        public SpaceSimulationResult(Guid guid, string name, string source, string reference)
            : base(guid, name, source, reference)
        {

        }

        public SpaceSimulationResult(SpaceSimulationResult spaceSimulationResult)
            : base(spaceSimulationResult)
        {

        }

        public SpaceSimulationResult(Guid guid, SpaceSimulationResult spaceSimulationResult)
            : base(guid, spaceSimulationResult)
        {

        }

        public SpaceSimulationResult(JObject jObject)
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