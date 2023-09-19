using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Geometry.Building
{
    [AssociatedTypes(typeof(IHostPartition)), Description("HostPartition Parameter")]
    public enum HostPartitionParameter
    {
        [ParameterProperties("Adiabatic", "Adiabatic"), ParameterValue(Core.ParameterType.Boolean)] Adiabatic,
    }
}