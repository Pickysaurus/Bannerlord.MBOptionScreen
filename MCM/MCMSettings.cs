﻿using MCM.Abstractions.Settings.Base.Global;

namespace MCM
{
    internal sealed class MCMSettings : AttributeGlobalSettings<MCMSettings>
    {
        public override string Id => "MCM_v3";
        public override string DisplayName => $"Mod Configuration Menu {typeof(MCMSettings).Assembly.GetName().Version.ToString(3)}";
        public override string FolderName => "MCM";
        public override string Format => "memory";
    }
}