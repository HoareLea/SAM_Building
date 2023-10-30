﻿using Grasshopper.Kernel;
using Rhino.Geometry;
using SAM.Geometry.Building;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAM.Geometry.Grasshopper.Building
{
    public static partial class Modify
    {
        public static void DrawViewportMeshes(this BuildingModel buildingModel, GH_PreviewMeshArgs previewMeshArgs, global::Rhino.Display.DisplayMaterial displayMaterial = null)
        {
            List<IHostPartition> hostPartitions = buildingModel?.GetObjects<IHostPartition>();
            if (hostPartitions == null)
                return;

            Geometry.Spatial.BoundingBox3D boundingBox3D = null;
            if (previewMeshArgs.Viewport.IsValidFrustum)
            {
                BoundingBox boundingBox = previewMeshArgs.Viewport.GetFrustumBoundingBox();
                boundingBox3D = new Geometry.Spatial.BoundingBox3D(new Geometry.Spatial.Point3D[] { Geometry.Rhino.Convert.ToSAM(boundingBox.Min), Geometry.Rhino.Convert.ToSAM(boundingBox.Max) });
            }

            List<Geometry.Spatial.Face3D> face3Ds = new List<Geometry.Spatial.Face3D>();
            for (int i = 0; i < hostPartitions.Count; i++)
                face3Ds.Add(null);

            Parallel.For(0, hostPartitions.Count, (int i) =>
            {
                IHostPartition hostPartition = hostPartitions[i];

                Geometry.Spatial.Face3D face3D = hostPartition?.Face3D;
                if (face3D == null)
                {
                    return;
                }

                List<Space> spaces = buildingModel.GetSpaces(hostPartition);
                if (spaces != null && spaces.Count > 1)
                    return;

                if (boundingBox3D != null)
                {
                    Geometry.Spatial.BoundingBox3D boundingBox3D_Temp = face3D.GetBoundingBox();
                    if (boundingBox3D_Temp != null)
                    {
                        if (!boundingBox3D.Inside(boundingBox3D_Temp) && !boundingBox3D.Intersect(boundingBox3D_Temp))
                            return;
                    }
                }

                face3Ds[i] = face3D;
            });

            foreach (Geometry.Spatial.Face3D face3D in face3Ds)
            {
                if (face3D == null)
                    continue;

                Brep brep = Geometry.Rhino.Convert.ToRhino_Brep(face3D);
                if (brep == null)
                    continue;

                previewMeshArgs.Pipeline.DrawBrepShaded(brep, displayMaterial == null ? previewMeshArgs.Material : displayMaterial);
            }
        }
    }
}