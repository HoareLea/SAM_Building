﻿using Newtonsoft.Json.Linq;
using SAM.Architectural;

namespace SAM.Core.Building
{
    public class ConstructionLayer : MaterialLayer, IBuildingObject
    {
        public ConstructionLayer(string name, double thickness)
            : base(name, thickness)
        {
        }

        public ConstructionLayer(ConstructionLayer constructionLayer)
            : base(constructionLayer)
        {

        }

        public ConstructionLayer(JObject jObject)
            : base(jObject)
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