using Rhino.DocObjects;
using Rhino.Geometry;
using Rhino;
using SAM.Geometry.Building;
using System;
using System.Collections.Generic;

namespace SAM.Geometry.Grasshopper.Building
{
    public static partial class Modify
    {
        public static bool BakeGeometry(this BuildingModel buildingModel, RhinoDoc rhinoDoc, ObjectAttributes objectAttributes, out Guid obj_guid)
        {
            obj_guid = Guid.Empty;

            if (buildingModel == null || rhinoDoc == null || objectAttributes == null)
                return false;

            List<IPartition> partitions = buildingModel.GetObjects<IPartition>();
            if (partitions == null || partitions.Count == 0)
                return false;

            List<Brep> breps = new List<Brep>();
            foreach (IPartition partition in partitions)
            {
                Brep brep = Geometry.Building.Rhino.Convert.ToRhino(partition);
                if (brep == null)
                    continue;

                breps.Add(brep);
            }

            if (breps == null || breps.Count == 0)
                return false;

            Brep result = Brep.MergeBreps(breps, Core.Tolerance.MacroDistance); //Tolerance has been changed from Core.Tolerance.Distance
            if (result == null)
                return false;

            obj_guid = rhinoDoc.Objects.AddBrep(result);
            return true;
        }

    }
}
