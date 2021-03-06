﻿using HarmonyLib;

using MCM.Abstractions.Attributes;

using System.Collections;

using TaleWorlds.MountAndBlade;

namespace MCM.Implementation.ModLib.Functionality
{
    [Version("e1.0.0",  1)]
    [Version("e1.0.1",  1)]
    [Version("e1.0.2",  1)]
    [Version("e1.0.3",  1)]
    [Version("e1.0.4",  1)]
    [Version("e1.0.5",  1)]
    [Version("e1.0.6",  1)]
    [Version("e1.0.7",  1)]
    [Version("e1.0.8",  1)]
    [Version("e1.0.9",  1)]
    [Version("e1.0.10", 1)]
    [Version("e1.0.11", 1)]
    [Version("e1.1.0",  1)]
    [Version("e1.2.0",  1)]
    [Version("e1.2.1",  1)]
    [Version("e1.3.0",  1)]
    [Version("e1.3.1",  1)]
    [Version("e1.4.0",  1)]
    [Version("e1.4.1",  1)]
    internal sealed class DefaultModLibScreenOverrider : BaseModLibScreenOverrider
    {
        private static readonly AccessTools.FieldRef<Module, IList> _initialStateOptions =
            AccessTools.FieldRefAccess<Module, IList>("_initialStateOptions");

        public override void OverrideModLibScreen()
        {
            var oldOptionScreen = Module.CurrentModule.GetInitialStateOptionWithId("ModOptionsMenu");
            if (oldOptionScreen != null)
            {
                _initialStateOptions(Module.CurrentModule).Remove(oldOptionScreen);
            }
        }
    }
}