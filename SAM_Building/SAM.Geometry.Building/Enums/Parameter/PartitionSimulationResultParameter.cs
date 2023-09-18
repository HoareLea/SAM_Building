using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Geometry.Building
{
    [AssociatedTypes(typeof(PartitionSimulationResult)), Description("PartitionSimulationResult Parameter")]
    public enum PartitionSimulationResultParameter
    {
        [ParameterProperties("Area", "Area [m2]"), DoubleParameterValue()] Area,
    }
}