﻿using GH_IO.Serialization;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.Geometry;
using SAM.Core.Grasshopper;
using SAM.Geometry.Building;
using SAM.Geometry.Grasshopper.Building.Properties;
using SAM.Geometry.Object.Spatial;
using SAM.Geometry.Spatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Geometry.Grasshopper.Building
{
    [Obsolete("Obsolete since 2021.11.24")]
    public class GooPartition : GooJSAMObject<IPartition>, IGH_PreviewData, IGH_BakeAwareData
    {
        public bool ShowAll = true;

        public GooPartition()
            : base()
        {
        }

        public GooPartition(IPartition partition)
            : base(partition)
        {
        }

        public BoundingBox ClippingBox
        {
            get
            {
                if (Value == null)
                    return BoundingBox.Empty;

                return Geometry.Rhino.Convert.ToRhino(Value?.Face3D?.GetBoundingBox());
            }
        }

        public override IGH_Goo Duplicate()
        {
            return new GooPartition(Value);
        }

        public void DrawViewportWires(GH_PreviewWireArgs args)
        {
            Face3D face3D = Value?.Face3D;
            if (face3D == null)
            {
                return;
            }

            System.Drawing.Color color_ExternalEdge = Geometry.Building.Query.Color(Value, false);
            System.Drawing.Color color_InternalEdges = Geometry.Building.Query.Color(Value, true);

            if (color_ExternalEdge == System.Drawing.Color.Empty)
                color_ExternalEdge = args.Color;

            if (color_InternalEdges == System.Drawing.Color.Empty)
                color_InternalEdges = args.Color;

            Geometry.Grasshopper.Modify.DrawViewportWires(face3D, args, color_ExternalEdge, color_InternalEdges);

            if (Value is IHostPartition)
            {
                List<IOpening> openings = ((IHostPartition)Value).GetOpenings();
                if (openings != null)
                {
                    foreach (IOpening opening in openings)
                    {
                        Face3D face3D_Opening = opening?.Face3D;
                        if (face3D_Opening == null)
                        {
                            continue;
                        }

                        color_ExternalEdge = Geometry.Building.Query.Color(opening, false);
                        color_InternalEdges = Geometry.Building.Query.Color(opening, true);

                        Geometry.Grasshopper.Modify.DrawViewportWires(face3D_Opening, args, color_ExternalEdge, color_InternalEdges);
                    }
                }
            }
        }

        public void DrawViewportMeshes(GH_PreviewMeshArgs args)
        {
            if (Value == null)
                return;

            Face3D face3D = Value.Face3D;
            if (face3D == null)
                return;

            if (!ShowAll)
            {
                Point3D point3D_CameraLocation = Geometry.Rhino.Convert.ToSAM(RhinoDoc.ActiveDoc.Views.ActiveView.ActiveViewport.CameraLocation);
                if (point3D_CameraLocation == null)
                    return;

                double distance = face3D.Distance(point3D_CameraLocation);
                if (distance < 8 || distance > 15)
                    return;
            }

            global::Rhino.Display.DisplayMaterial displayMaterial = Geometry.Building.Rhino.Query.DisplayMaterial(Value);
            if (displayMaterial == null)
                displayMaterial = args.Material;

            Brep brep = Rhino.Convert.ToRhino_Brep(face3D);
            if (brep == null)
                return;

            args.Pipeline.DrawBrepShaded(brep, displayMaterial);

            if (Value is IHostPartition)
            {
                List<IOpening> openings = ((IHostPartition)Value).GetOpenings();
                if (openings != null)
                {
                    foreach (IOpening opening in openings)
                    {
                        List<IClosedPlanar3D> edge3Ds = opening?.Face3D?.GetEdge3Ds();
                        if (edge3Ds != null && edge3Ds.Count != 0)
                        {
                            foreach (IClosedPlanar3D closedPlanar3D in edge3Ds)
                            {
                                global::Rhino.Display.DisplayMaterial displayMaterial_Opening = SAM.Geometry.Building.Rhino.Query.DisplayMaterial(opening);
                                if (displayMaterial_Opening == null)
                                    displayMaterial_Opening = args.Material;

                                Geometry.Grasshopper.Modify.DrawViewportMeshes(closedPlanar3D, args, displayMaterial_Opening);
                            }
                        }
                    }
                }
            }
        }

        public bool BakeGeometry(RhinoDoc doc, ObjectAttributes att, out Guid obj_guid)
        {
            return Geometry.Building.Rhino.Modify.BakeGeometry(Value, doc, att, out obj_guid);
        }

        public override bool CastFrom(object source)
        {
            if (source is IPartition)
            {
                Value = (IPartition)source;
                return true;
            }

            if (typeof(IGH_Goo).IsAssignableFrom(source.GetType()))
            {
                object object_Temp = null;

                try
                {
                    object_Temp = (source as dynamic).Value;
                }
                catch
                {
                }

                if (object_Temp is IPartition)
                {
                    Value = (IPartition)object_Temp;
                    return true;
                }
            }

            return base.CastFrom(source);
        }

        public override bool CastTo<Y>(ref Y target)
        {
            if (Value == null)
                return false;

            if (typeof(Y).IsAssignableFrom(typeof(GH_Mesh)))
            {
                target = (Y)(object)Value.ToGrasshopper_Mesh();
                return true;
            }
            else if (typeof(Y).IsAssignableFrom(typeof(GH_Brep)))
            {
                target = (Y)(object)Value.Face3D?.ToGrasshopper_Brep();
                return true;
            }

            return base.CastTo(ref target);
        }
    }

    [Obsolete("Obsolete since 2021.11.24")]
    public class GooPartitionParam : GH_PersistentParam<GooPartition>, IGH_PreviewObject, IGH_BakeAwareObject
    {
        private bool showAll = true;

        public override Guid ComponentGuid => new Guid("0091B0F4-8009-4388-8914-A3FE680EF12D");

        protected override System.Drawing.Bitmap Icon => Resources.SAM_Small;

        public override GH_Exposure Exposure => GH_Exposure.hidden;

        bool IGH_PreviewObject.Hidden { get; set; }

        bool IGH_PreviewObject.IsPreviewCapable => !VolatileData.IsEmpty;

        BoundingBox IGH_PreviewObject.ClippingBox => Preview_ComputeClippingBox();

        public bool IsBakeCapable => true;

        void IGH_PreviewObject.DrawViewportMeshes(IGH_PreviewArgs args)
        {
            foreach (var variable in VolatileData.AllData(true))
            {
                GooPartition goohostPartition = variable as GooPartition;
                if (goohostPartition == null)
                    continue;

                goohostPartition.ShowAll = showAll;
            }

            Preview_DrawMeshes(args);
        }

        void IGH_PreviewObject.DrawViewportWires(IGH_PreviewArgs args)
        {
            foreach (var variable in VolatileData.AllData(true))
            {
                GooPartition goohostPartition = variable as GooPartition;
                if (goohostPartition == null)
                    continue;

                goohostPartition.ShowAll = showAll;
            }

            Preview_DrawWires(args);
        }

        public GooPartitionParam()
            : base(typeof(IPartition).Name, typeof(IPartition).Name, typeof(IPartition).FullName.Replace(".", " "), "Params", "SAM")
        {
        }

        protected override GH_GetterResult Prompt_Plural(ref List<GooPartition> values)
        {
            global::Rhino.Input.Custom.GetObject getObject = new global::Rhino.Input.Custom.GetObject();
            getObject.SetCommandPrompt("Pick Surfaces to create Partitions");
            getObject.GeometryFilter = ObjectType.Brep;
            getObject.SubObjectSelect = true;
            getObject.DeselectAllBeforePostSelect = false;
            getObject.OneByOnePostSelect = false;
            getObject.GetMultiple(1, 0);

            if (getObject.CommandResult() != Result.Success)
                return GH_GetterResult.cancel;

            if (getObject.ObjectCount == 0)
                return GH_GetterResult.cancel;

            values = new List<GooPartition>();

            for (int i = 0; i < getObject.ObjectCount; i++)
            {
                ObjRef objRef = getObject.Object(i);

                RhinoObject rhinoObject = objRef.Object();
                if (rhinoObject == null)
                    return GH_GetterResult.cancel;

                GeometryBase geometryBase = rhinoObject.Geometry;

                List<ISAMGeometry3D> sAMGeometry3Ds = Geometry.Rhino.Convert.ToSAM(geometryBase as Brep);
                if (sAMGeometry3Ds == null)
                {
                    continue;
                }

                List<Face3D> face3Ds = Geometry.Spatial.Query.Face3Ds(sAMGeometry3Ds);
                if (face3Ds == null)
                {
                    continue;
                }

                List<IPartition> partitions = null;
                if (geometryBase.HasUserData)
                {
                    string @string = geometryBase.GetUserString("SAM");
                    if (!string.IsNullOrWhiteSpace(@string))
                    {
                        partitions = Core.Convert.ToSAM<IPartition>(@string);
                        if (partitions != null)
                        {
                            partitions.RemoveAll(x => x == null);
                        }

                        if (partitions != null && partitions.Count != 0)
                        {
                            for (int j = 0; j < face3Ds.Count; j++)
                            {
                                IPartition partition_Old = Object.Spatial.Query.Closest(partitions, face3Ds[j].GetInternalPoint3D());
                                if (partition_Old != null)
                                {
                                    partitions[j] = Geometry.Building.Create.Partition(partition_Old, partition_Old.Guid, face3Ds[j]);
                                }

                            }
                        }
                    }
                }

                if (partitions == null || partitions.Count == 0)
                {
                    partitions = Geometry.Building.Create.HostPartitions(sAMGeometry3Ds)?.Cast<IPartition>().ToList();
                }

                if (partitions == null || partitions.Count == 0)
                    continue;

                partitions.RemoveAll(x => x == null || x.Face3D == null);
                values.AddRange(partitions.ConvertAll(x => new GooPartition(x)));
            }

            return GH_GetterResult.success;
        }

        protected override GH_GetterResult Prompt_Singular(ref GooPartition value)
        {
            global::Rhino.Input.Custom.GetObject getObject = new global::Rhino.Input.Custom.GetObject();
            getObject.SetCommandPrompt("Pick Surface to create Partition");
            getObject.GeometryFilter = ObjectType.Brep;
            getObject.SubObjectSelect = true;
            getObject.DeselectAllBeforePostSelect = false;
            getObject.OneByOnePostSelect = true;
            getObject.Get();

            if (getObject.CommandResult() != Result.Success)
                return GH_GetterResult.cancel;

            if (getObject.ObjectCount == 0)
                return GH_GetterResult.cancel;

            for (int i = 0; i < getObject.ObjectCount; i++)
            {
                ObjRef objRef = getObject.Object(i);

                RhinoObject rhinoObject = objRef.Object();
                if (rhinoObject == null)
                    return GH_GetterResult.cancel;

                GeometryBase geometryBase = rhinoObject.Geometry;

                List<ISAMGeometry3D> sAMGeometry3Ds = Geometry.Rhino.Convert.ToSAM(geometryBase as Brep);
                if (sAMGeometry3Ds == null)
                {
                    continue;
                }

                List<Face3D> face3Ds = Geometry.Spatial.Query.Face3Ds(sAMGeometry3Ds);
                if (face3Ds == null)
                {
                    continue;
                }

                List<IPartition> partitions = null;
                if (geometryBase.HasUserData)
                {
                    string @string = geometryBase.GetUserString("SAM");
                    if (!string.IsNullOrWhiteSpace(@string))
                    {
                        partitions = Core.Convert.ToSAM<IPartition>(@string);
                        if (partitions != null)
                        {
                            partitions.RemoveAll(x => x == null);
                        }

                        if (partitions != null && partitions.Count != 0)
                        {
                            for (int j = 0; j < face3Ds.Count; j++)
                            {
                                IPartition partition_Old = Object.Spatial.Query.Closest(partitions, face3Ds[j].GetInternalPoint3D());
                                if (partition_Old != null)
                                {
                                    partitions[j] = Geometry.Building.Create.Partition(partition_Old, partition_Old.Guid, face3Ds[j]);
                                }

                            }
                        }
                    }
                }

                if (partitions == null || partitions.Count == 0)
                {
                    partitions = SAM.Geometry.Building.Create.HostPartitions(sAMGeometry3Ds)?.Cast<IPartition>().ToList();
                }

                if (partitions == null || partitions.Count == 0)
                    continue;

                partitions.RemoveAll(x => x == null || x.Face3D == null);
                if (partitions.Count != 0)
                {
                    value = new GooPartition(partitions[0]);
                    return GH_GetterResult.success;
                }
            }

            return GH_GetterResult.cancel;
        }

        public void BakeGeometry(RhinoDoc doc, List<Guid> obj_ids)
        {
            BakeGeometry(doc, doc.CreateDefaultAttributes(), obj_ids);
        }

        public void BakeGeometry(RhinoDoc doc, ObjectAttributes att, List<Guid> obj_ids)
        {
            foreach (var value in VolatileData.AllData(true))
            {
                Guid uuid = default;
                (value as IGH_BakeAwareData)?.BakeGeometry(doc, att, out uuid);
                obj_ids.Add(uuid);
            }
        }

        public void BakeGeometry_ByType(RhinoDoc doc)
        {
            Modify.BakeGeometry_ByType(doc, VolatileData, false, Core.Tolerance.Distance);
        }

        public void BakeGeometry_ByCategory(RhinoDoc doc)
        {
            Modify.BakeGeometry_ByCategory(doc, VolatileData, false, Core.Tolerance.Distance);
        }

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {

            Menu_AppendItem(menu, "Show All", Menu_ShowAll, VolatileData.AllData(true).Any(), showAll).Tag = showAll;

            Menu_AppendItem(menu, "Bake By Type", Menu_BakeByPanelType, VolatileData.AllData(true).Any());
            Menu_AppendItem(menu, "Bake By Category", Menu_BakeByCategory, VolatileData.AllData(true).Any());

            //Menu_AppendSeparator(menu);

            base.AppendAdditionalMenuItems(menu);
        }

        private void Menu_BakeByPanelType(object sender, EventArgs e)
        {
            BakeGeometry_ByType(RhinoDoc.ActiveDoc);
        }

        private void Menu_ShowAll(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.Tag is bool)
            {
                showAll = !(bool)item.Tag;
                ExpirePreview(true);
            }
        }

        private void Menu_BakeByCategory(object sender, EventArgs e)
        {
            BakeGeometry_ByCategory(RhinoDoc.ActiveDoc);
        }

        public override bool Write(GH_IWriter writer)
        {
            writer.SetBoolean(GetType().FullName, showAll);

            return base.Write(writer);
        }

        public override bool Read(GH_IReader reader)
        {
            if (reader != null)
                reader.TryGetBoolean(GetType().FullName, ref showAll);

            return base.Read(reader);
        }
    }
}