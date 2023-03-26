﻿// -----------------------------------------------------------------------
// <copyright file="ICursedModule.cs" company="CursedMod">
// Copyright (c) CursedMod. All rights reserved.
// Licensed under the GPLv3 license.
// See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;
using System.Reflection;
using CursedMod.Loader.Modules.Configuration;

namespace CursedMod.Loader.Modules;

public interface ICursedModule
{
    public Assembly ModuleAssembly { get; set; }
    
    public string ModuleName { get; set; }
    
    public string ModuleAuthor { get; set; }
    
    public string ModuleVersion { get; set; }
    
    public string CursedModVersion { get; set; }
    
    public byte LoadPriority { get; set; }
    
    public DirectoryInfo ModuleDirectory { get; set; }
    
    public CursedModuleProperties ModuleProperties { get; set; }

    void OnLoaded();
    
    void OnUnloaded();

    T GetConfig<T>(string name);
    
    void SaveConfig<T>(T instance, string name);
}