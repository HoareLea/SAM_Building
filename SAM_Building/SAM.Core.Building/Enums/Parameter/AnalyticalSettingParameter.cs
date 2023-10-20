using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Core.Building
{
    [AssociatedTypes(typeof(Setting)), Description("Building Setting Parameter")]
    public enum BuildingSettingParameter
    {
        [ParameterProperties("Default MaterialLibrary", "Default MaterialLibrary"), SAMObjectParameterValue(typeof(MaterialLibrary))] DefaultMaterialLibrary,
        [ParameterProperties("Default Gas MaterialLibrary", "Default Gas MaterialLibrary"), SAMObjectParameterValue(typeof(MaterialLibrary))] DefaultGasMaterialLibrary,
        [ParameterProperties("Default InternalConditionLibrary", "Default InternalConditionLibrary"), SAMObjectParameterValue(typeof(InternalConditionLibrary))] DefaultInternalConditionLibrary,
        [ParameterProperties("Default ProfileLibrary", "Default ProfileLibrary"), SAMObjectParameterValue(typeof(ProfileLibrary))] DefaultProfileLibrary,
        [ParameterProperties("Default SystemTypeLibrary", "Default SystemTypeLibrary"), SAMObjectParameterValue(typeof(SystemTypeLibrary))] DefaultSystemTypeLibrary,
        [ParameterProperties("InternalCondition TextMap", "InternalCondition TextMap"), SAMObjectParameterValue(typeof(TextMap))] InternalConditionTextMap,

        [ParameterProperties("Default MaterialLibrary File Name", "Default MaterialLibrary File Name"), ParameterValue(ParameterType.String)] DefaultMaterialLibraryFileName,
        [ParameterProperties("Default Gas MaterialLibrary File Name", "Default Gas MaterialLibrary File Name"), ParameterValue(ParameterType.String)] DefaultGasMaterialLibraryFileName,
        [ParameterProperties("Default InternalConditionLibrary File Name", "Default InternalConditionLibrary File Name"), ParameterValue(ParameterType.String)] DefaultInternalConditionLibraryFileName,
        [ParameterProperties("Default ProfileLibrary File Name", "Default ProfileLibrary File Name"), ParameterValue(ParameterType.String)] DefaultProfileLibraryFileName,
        [ParameterProperties("InternaCondition TextMap File Name", "InternaCondition TextMap File Name"), ParameterValue(ParameterType.String)] InternaConditionTextMaplFileName,
        [ParameterProperties("Default SystemTypeLibrary File Name", "Default SystemTypeLibrary File Name"), ParameterValue(ParameterType.String)] DefaultSystemTypeLibraryFileName,

        [ParameterProperties("Default HostPartitionTypeLibrary File Name", "Default HostPartitionTypeLibrary File Name"), ParameterValue(ParameterType.String)] DefaultHostPartitionTypeLibraryFileName,
        [ParameterProperties("Default HostPartitionTypeLibrary", "Default HostPartitionTypeLibrary"), SAMObjectParameterValue(typeof(HostPartitionTypeLibrary))] DefaultHostPartitionTypeLibrary,
        [ParameterProperties("Default OpeningTypeLibrary File Name", "Default OpeningTypeLibrary File Name"), ParameterValue(ParameterType.String)] DefaultOpeningTypeLibraryFileName,
        [ParameterProperties("Default OpeningTypeLibrary", "Default OpeningTypeLibrary"), SAMObjectParameterValue(typeof(OpeningTypeLibrary))] DefaultOpeningTypeLibrary,
    }
}