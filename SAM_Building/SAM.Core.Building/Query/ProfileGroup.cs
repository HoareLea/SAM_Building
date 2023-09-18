namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static ProfileGroup ProfileGroup(this ProfileType profileType)
        {
            if (profileType == ProfileType.Undefined || profileType == ProfileType.Other)
                return Building.ProfileGroup.Undefined;

            switch (profileType)
            {
                case ProfileType.Dehumidification:
                case ProfileType.Humidification:
                    return Building.ProfileGroup.Humidistat;

                case ProfileType.EquipmentLatent:
                case ProfileType.EquipmentSensible:
                case ProfileType.Infiltration:
                case ProfileType.Lighting:
                case ProfileType.Occupancy:
                case ProfileType.Pollutant:
                    return Building.ProfileGroup.Gain;

                case ProfileType.Heating:
                case ProfileType.Cooling:
                    return Building.ProfileGroup.Thermostat;

                case ProfileType.Ventilation:
                    return Building.ProfileGroup.Ventilation;

            }

            return Building.ProfileGroup.Undefined;
        }
    }
}