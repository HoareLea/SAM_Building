
namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static bool Type(this MechanicalSystem mechanicalSystem, MechanicalSystemType mechanicalSystemType)
        {
            if (mechanicalSystem == null || mechanicalSystemType == null)
            {
                return false;
            }

            if (mechanicalSystem is CoolingSystem && mechanicalSystemType is CoolingSystemType)
            {
                ((CoolingSystem)mechanicalSystem).Type = (CoolingSystemType)mechanicalSystemType;
            }
            else if (mechanicalSystem is HeatingSystem && mechanicalSystemType is HeatingSystemType)
            {
                ((HeatingSystem)mechanicalSystem).Type = (HeatingSystemType)mechanicalSystemType;
            }
            else if (mechanicalSystem is VentilationSystem && mechanicalSystemType is VentilationSystemType)
            {
                ((VentilationSystem)mechanicalSystem).Type = (VentilationSystemType)mechanicalSystemType;
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}