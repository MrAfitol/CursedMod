﻿// -----------------------------------------------------------------------
// <copyright file="EntryPoint.cs" company="CursedMod">
// Copyright (c) CursedMod. All rights reserved.
// Licensed under the GPLv3 license.
// See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using CursedMod.Events;
using CursedMod.Features.Logger;
using CursedMod.Loader;
using CursedMod.Loader.Configurations;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;

namespace CursedMod;

internal class EntryPoint
{
    [PluginConfig] 
    public static CursedModConfiguration ModConfiguration;

    [PluginEntryPoint("CursedMod", CursedModInformation.Version, "A rich low level modding framework.", "Jesus-QC")]
    private void Init()
    {
        if (!ModConfiguration.LoadCursedMod)
            return;

        CursedLogger.InternalPrint($"Welcome to CursedMod {CursedModInformation.Version}");

        EventManager.PatchEvents();
        
        CursedPaths.LoadPaths(PluginHandler.Get(this).PluginDirectoryPath);
        CursedLoader.LoadAll();
    }
}