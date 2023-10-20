﻿using SAM.Core;
using SAM.Core.Building;
using System.Collections.Generic;

namespace SAM.Core.Building
{
    public static partial class Query
    {
        public static GasMaterial DefaultGasMaterial(this DefaultGasType defaultGasType)
        {
            if (defaultGasType == Building.DefaultGasType.Undefined)
                return null;

            MaterialLibrary materialLibrary = ActiveSetting.Setting.GetValue<MaterialLibrary>(BuildingSettingParameter.DefaultGasMaterialLibrary);
            if (materialLibrary == null)
                return null;

            string name = defaultGasType.ToString();

            List<GasMaterial> gasMaterials = materialLibrary.GetObjects<GasMaterial>(name, TextComparisonType.Contains, false);
            if (gasMaterials != null && gasMaterials.Count > 0)
            {
                if (gasMaterials.Count > 1)
                    gasMaterials.Sort((x, y) => (x.Name.Length - name.Length).CompareTo(y.Name.Length - name.Length));

                return gasMaterials[0];
            }

            gasMaterials = materialLibrary.GetObjects<GasMaterial>();
            if (gasMaterials == null || gasMaterials.Count == 0)
                return null;

            name = name.ToLower();

            foreach (GasMaterial gasMaterial in gasMaterials)
            {
                string name_Material = gasMaterial?.Name;
                if (string.IsNullOrWhiteSpace(name_Material))
                    continue;

                name_Material = name_Material.ToLower().Replace(" ", string.Empty);
                if (name_Material.Contains(name))
                    return gasMaterial;
            }

            return null;
        }

        public static GasMaterial DefaultGasMaterial(this GasMaterial gasMaterial)
        {
            if (gasMaterial == null)
                return null;

            DefaultGasType defaultGasType = DefaultGasType(gasMaterial);
            if (defaultGasType == Building.DefaultGasType.Undefined)
                return null;

            return DefaultGasMaterial(defaultGasType);
        }
    }
}