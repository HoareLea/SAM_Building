using System.ComponentModel;

namespace SAM.Core.Building
{
    [Description("Building Profile Group.")]
    public enum ProfileGroup
    {
        [Description("Undefined")] Undefined,
        [Description("Gain")] Gain,
        [Description("Thermostat")] Thermostat,
        [Description("Humidistat")] Humidistat,
        [Description("Ventilation")] Ventilation,
    }
}