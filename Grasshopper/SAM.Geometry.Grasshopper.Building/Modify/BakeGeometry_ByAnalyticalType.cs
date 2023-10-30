using Rhino;
using SAM.Geometry.Building;
using SAM.Geometry.Grasshopper.Building;
using System;

namespace SAM.Geometry.Grasshopper.Building
{
    public static partial class Modify
    {
        public static void BakeGeometry_ByAnalyticalType(this RhinoDoc rhinoDoc, global::Grasshopper.Kernel.Data.IGH_Structure gH_Structure, bool cutOpenings, double tolerance = Core.Tolerance.Distance)
        {
            if (rhinoDoc == null)
                return;

            foreach (var variable in gH_Structure.AllData(true))
            {
                if (variable is GooBuildingModel)
                {
                    BuildingModel buildingModel = ((GooBuildingModel)variable).Value;
                    if (buildingModel != null)
                    {
                        Geometry.Building.Rhino.Modify.BakeGeometry_ByAnalyticalType(rhinoDoc, buildingModel, cutOpenings, tolerance);
                    }
                }
            }
        }
    }
}