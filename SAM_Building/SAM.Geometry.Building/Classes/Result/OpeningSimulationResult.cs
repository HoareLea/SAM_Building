using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Building;
using System;

namespace SAM.Geometry.Building
{
    public class OpeningSimulationResult : Result, IBuildingObject
    {
        public OpeningSimulationResult(string name, string source, string reference)
            : base(name, source, reference)
        {

        }

        public OpeningSimulationResult(Guid guid, string name, string source, string reference)
            : base(guid, name, source, reference)
        {

        }

        public OpeningSimulationResult(OpeningSimulationResult openingSimulationResult)
            : base(openingSimulationResult)
        {

        }

        public OpeningSimulationResult(JObject jObject)
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