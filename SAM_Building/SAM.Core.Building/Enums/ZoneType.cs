﻿using System.ComponentModel;

namespace SAM.Core.Building
{
    [Description("Zone Type.")]
    public enum ZoneType
    {
        [Description("Undefined")] Undefined,
        [Description("Heating")] Heating,
        [Description("Cooling")] Cooling,
        [Description("Ventilation")] Ventilation,
        [Description("Other")] Other
    }
}