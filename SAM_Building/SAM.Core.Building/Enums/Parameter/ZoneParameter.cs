using System.ComponentModel;
using System.Security.Policy;
using SAM.Core.Attributes;

namespace SAM.Core.Building
{
    [AssociatedTypes(typeof(Zone)), Description("Building Zone Parameter")]
    public enum ZoneParameter
    {
        [ParameterProperties("Color", "Color"), ParameterValue(Core.ParameterType.Color)] Color,

        [ParameterProperties("Zone Category", "Zone Category"), ParameterValue(Core.ParameterType.String)] ZoneCategory,
    }
}