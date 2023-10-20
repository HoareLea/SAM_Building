﻿namespace SAM.Core.Building
{
    public static partial class Query
    {

        /// <summary>
        /// Nusselt Number (Nu) according to EN 673:1997 [-]
        /// </summary>
        /// <param name="fluidMaterial">SAM Fluid Material</param>
        /// <param name="temperatureDifference">Temperature difference between glass surfaces bounding the fluid space</param>
        /// <param name="width">Width of the space , default 0.0012m</param>
        /// <param name="meanTemperature">Mean Temperature</param>
        /// <param name="angle">Angle of heat flow direction in radians (measured in 2D from Upward direction (0, 1) Vector2D.SignedAngle(Vector2D)), angle less than 0 considered as downward direction</param>
        /// <param name="tolerance">Tolerance for angle comparison, default is Tolerance.Angle</param>
        /// <returns>Nusselt Number (Nu) [-]</returns>
        public static double NusseltNumber(this FluidMaterial fluidMaterial, double temperatureDifference, double width, double meanTemperature, double angle, double tolerance = Tolerance.Angle)
        {
            if (fluidMaterial == null || double.IsNaN(temperatureDifference) || double.IsNaN(width) || double.IsNaN(meanTemperature))
                return double.NaN;

            if (angle < 0)
                return 1;

            double a = double.NaN;
            double n = double.NaN;

            //roof deg = 0, rad = 0
            if (angle < tolerance)
            {
                a = 0.16;
                n = 0.28;
            }

            //tilted roof,wall deg = 45, rad = 0.7854
            else if (System.Math.Abs(angle - System.Math.PI / 4) < tolerance)
            {
                a = 0.10;
                n = 0.31;
            }

            //wall deg = 90, rad = 1.5708
            else if (System.Math.Abs(angle - System.Math.PI / 2) < tolerance)
            {
                a = 0.035;
                n = 0.38;
            }

            //tilted 0<roof,wall <deg = 45, rad = 0.7854
            else if (angle - tolerance > 0 && angle + tolerance < System.Math.PI / 4)
            {
                double linearEquation_a;
                double linearEquation_b;

                linearEquation_a = (0.035 - 0.1) / (0 - System.Math.PI / 4);
                linearEquation_b = 0.035 - linearEquation_a * 0;
                a = linearEquation_a * angle + linearEquation_b;

                linearEquation_a = (0.38 - 0.31) / (0 - System.Math.PI / 4);
                linearEquation_b = 0.38 - linearEquation_a * 0;
                n = linearEquation_a * angle + linearEquation_b;
            }

            //tilted 45 < roof,wall < 90 deg, rad = 1.5708
            else if (angle + tolerance > System.Math.PI / 4 && angle - tolerance < System.Math.PI / 2)
            {
                double linearEquation_a;
                double linearEquation_b;

                linearEquation_a = (0.1 - 0.16) / (System.Math.PI / 4 - System.Math.PI / 2);
                linearEquation_b = 0.1 - linearEquation_a * System.Math.PI / 4;
                a = linearEquation_a * angle + linearEquation_b;

                linearEquation_a = (0.31 - 0.28) / (System.Math.PI / 4 - System.Math.PI / 2);
                linearEquation_b = 0.31 - linearEquation_a * System.Math.PI / 4;
                n = linearEquation_a * angle + linearEquation_b;
            }

            if (double.IsNaN(a) || double.IsNaN(n))
                return double.NaN;

            return NusseltNumber_ConstantAndExponent(fluidMaterial, temperatureDifference, width, meanTemperature, a, n);
        }

        /// <summary>
        /// Nusselt Number (Nu) according to EN 673:1997 [-]
        /// </summary>
        /// <param name="fluidMaterial">SAM Fluid Material</param>
        /// <param name="temperatureDifference">Temperature difference between glass surfaces bounding the fluid space</param>
        /// <param name="width">Width of the space</param>
        /// <param name="meanTemperature">Mean Temperature</param>
        /// <param name="constant">Constant (A) value for equation Nu = A(Gr * Pr)^n</param>
        /// <param name="exponent">Exponent (n) value for equation Nu = A(Gr * Pr)^n</param>
        /// <returns>Nusselt Number (Nu) [-]</returns>
        public static double NusseltNumber_ConstantAndExponent(this FluidMaterial fluidMaterial, double temperatureDifference, double width, double meanTemperature, double constant, double exponent)
        {
            if (fluidMaterial == null || double.IsNaN(temperatureDifference) || double.IsNaN(width) || double.IsNaN(meanTemperature))
                return double.NaN;

            double grashofNumber = GrashofNumber(fluidMaterial, temperatureDifference, width, meanTemperature);
            if (double.IsNaN(grashofNumber))
                return double.NaN;

            double prandtlNumber = PrandtlNumber(fluidMaterial);
            if (double.IsNaN(prandtlNumber))
                return double.NaN;

            return constant * System.Math.Pow(grashofNumber * prandtlNumber, exponent);
        }
    }
}