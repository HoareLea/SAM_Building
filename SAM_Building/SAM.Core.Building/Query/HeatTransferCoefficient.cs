﻿using SAM.Core;

namespace SAM.Core.Building
{
    public static partial class Query
    {

        /// <summary>
        /// Calculates Heat Transfer Coefficient (Thermal Conductance) [W/m2K] <see href="https://www.edsl.net/htmlhelp/Building_Simulator/ParametersforGasLayers.htm">source</see>
        /// </summary>
        /// <param name="fluidMaterial">SAM Fluid Material</param>
        /// <param name="temperatureDifference">Temperature difference between glass surfaces bounding the fluid space</param>
        /// <param name="width">Width of the space , default 0.0012m</param>
        /// <param name="meanTemperature">Mean Temperature</param>
        /// <param name="angle">Angle of heat flow direction in radians (measured in 2D from Upward direction (0, 1) Vector2D.SignedAngle(Vector2D)), angle less than 0 considered as downward direction</param>
        /// <returns>Heat Transfer Coefficient [W/m2K]</returns>
        public static double HeatTransferCoefficient(this FluidMaterial fluidMaterial, double temperatureDifference, double width, double meanTemperature, double angle)
        {
            double thermalConductivity = fluidMaterial.ThermalConductivity;
            if (double.IsNaN(thermalConductivity))
                return double.NaN;

            double nusseltNumber = NusseltNumber(fluidMaterial, temperatureDifference, width, meanTemperature, angle);
            if (double.IsNaN(nusseltNumber))
                return double.NaN;

            if (nusseltNumber < 1)
                nusseltNumber = 1;

            return nusseltNumber * (thermalConductivity / width);
        }

        /// <summary>
        /// Calculates Heat Transfer Coefficient (Thermal Conductance) [W/m2K] for temperature difference 15K (Temperature difference between glass surfaces bounding the fluid space) and mean temperature 283<see href="https://www.edsl.net/htmlhelp/Building_Simulator/ParametersforGasLayers.htm">source</see>
        /// </summary>
        /// <param name="fluidMaterial">SAM Fluid Material</param>
        /// <param name="width">Width of the space , default 0.0012m</param>
        /// <param name="angle">Angle of heat flow direction in radians (measured in 2D from Upward direction (0, 1) Vector2D.SignedAngle(Vector2D)), angle less than 0 considered as downward direction</param>
        /// <returns>Heat Transfer Coefficient [W/m2K]</returns>
        public static double HeatTransferCoefficient(this FluidMaterial fluidMaterial, double width, double angle)
        {
            return HeatTransferCoefficient(fluidMaterial, 15, width, 283, angle);
        }
    }
}