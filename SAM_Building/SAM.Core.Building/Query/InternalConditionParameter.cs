namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static InternalConditionParameter? InternalConditionParameter(this ProfileType profileType)
        {
            if (profileType == ProfileType.Undefined || profileType == ProfileType.Other)
                return null;

            switch (profileType)
            {
                case ProfileType.Cooling:
                    return Building.InternalConditionParameter.CoolingProfileName;

                case ProfileType.Dehumidification:
                    return Building.InternalConditionParameter.DehumidificationProfileName;

                case ProfileType.EquipmentLatent:
                    return Building.InternalConditionParameter.EquipmentLatentProfileName;

                case ProfileType.EquipmentSensible:
                    return Building.InternalConditionParameter.EquipmentSensibleProfileName;

                case ProfileType.Heating:
                    return Building.InternalConditionParameter.HeatingProfileName;

                case ProfileType.Humidification:
                    return Building.InternalConditionParameter.HumidificationProfileName;

                case ProfileType.Infiltration:
                    return Building.InternalConditionParameter.InfiltrationProfileName;

                case ProfileType.Lighting:
                    return Building.InternalConditionParameter.LightingProfileName;

                case ProfileType.Occupancy:
                    return Building.InternalConditionParameter.OccupancyProfileName;

                case ProfileType.Pollutant:
                    return Building.InternalConditionParameter.PollutantProfileName;

                case ProfileType.Ventilation:
                    return Building.InternalConditionParameter.VentilationProfileName;
            }

            return null;
        }
    }
}