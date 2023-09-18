using Newtonsoft.Json.Linq;

namespace SAM.Core.Building
{
    public abstract class BuildingElementType : SAMType, IBuildingObject
    {
        public BuildingElementType(BuildingElementType buildingElementType)
            : base(buildingElementType)
        {

        }

        public BuildingElementType(BuildingElementType buildingElementType, string name)
            : base(buildingElementType, name)
        {

        }

        public BuildingElementType(JObject jObject)
            : base(jObject)
        {

        }

        public BuildingElementType(string name)
            : base(name)
        {

        }

        public BuildingElementType(System.Guid guid, string name)
            : base(guid, name)
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
                return jObject;

            return jObject;
        }

    }
}
