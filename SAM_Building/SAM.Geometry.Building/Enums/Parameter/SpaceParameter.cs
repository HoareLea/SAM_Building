using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Geometry.Building
{
    [AssociatedTypes(typeof(Space)), Description("Space Parameter")]
    public enum SpaceParameter
    {
        [ParameterProperties("Color", "Color"), ParameterValue(Core.ParameterType.Color)] Color,

        [ParameterProperties("Design Heating Load", "Design Heating Load [W]"), DoubleParameterValue(0)] DesignHeatingLoad,
        [ParameterProperties("Design Cooling Load", "Design Cooling Load [W]"), DoubleParameterValue(0)] DesignCoolingLoad,
        [ParameterProperties("Volume", "Volume [m3]"), DoubleParameterValue(0)] Volume,
        [ParameterProperties("Area", "Area [m2]"), DoubleParameterValue(0)] Area,
        [ParameterProperties("Occupancy", "Occupancy [p]"), DoubleParameterValue(0)] Occupancy,
        [ParameterProperties("Facing External", "Facing External"), ParameterValue(Core.ParameterType.Boolean)] FacingExternal,
        [ParameterProperties("Facing External Glazing", "Facing External Glazing"), ParameterValue(Core.ParameterType.Boolean)] FacingExternalGlazing,
        [ParameterProperties("Level Name", "Level Name"), ParameterValue(Core.ParameterType.String)] LevelName,
        [ParameterProperties("Cooling Sizing Factor", "Cooling Sizing Factor"), DoubleParameterValue(0)] CoolingSizingFactor,
        [ParameterProperties("Heating Sizing Factor", "Heating Sizing Factor"), DoubleParameterValue(0)] HeatingSizingFactor,
        [ParameterProperties("Ventilation Riser Name", "Ventilation Riser Name"), ParameterValue(Core.ParameterType.String)] VentilationRiserName,
        [ParameterProperties("Heating Riser Name", "Heating Riser Name"), ParameterValue(Core.ParameterType.String)] HeatingRiserName,
        [ParameterProperties("Cooling Riser Name", "Cooling Riser Name"), ParameterValue(Core.ParameterType.String)] CoolingRiserName,

        [ParameterProperties("Outside Supply Air Flow", "Outside Supply Air Flow [m3/s]"), DoubleParameterValue(0)] OutsideSupplyAirFlow,
        [ParameterProperties("Supply Air Flow", "Supply Air Flow [m3/s]"), DoubleParameterValue(0)] SupplyAirFlow,
        [ParameterProperties("Exhaust Air Flow", "Exhaust Air Flow [m3/s]"), DoubleParameterValue(0)] ExhaustAirFlow,

        [ParameterProperties("Daylight Factor", "Daylight Factor [-]"), DoubleParameterValue(0)] DaylightFactor,
    }
}