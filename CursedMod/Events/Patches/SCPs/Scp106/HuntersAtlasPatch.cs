﻿// -----------------------------------------------------------------------
// <copyright file="HuntersAtlasPatch.cs" company="CursedMod">
// Copyright (c) CursedMod. All rights reserved.
// Licensed under the GPLv3 license.
// See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Reflection.Emit;
using CursedMod.Events.Arguments.SCPs.Scp106;
using CursedMod.Events.Handlers;
using HarmonyLib;
using NorthwoodLib.Pools;
using PlayerRoles.PlayableScps.Scp106;

namespace CursedMod.Events.Patches.SCPs.Scp106;

[DynamicEventPatch(typeof(CursedScp106EventsHandler), nameof(CursedScp106EventsHandler.Submerging))]
[DynamicEventPatch(typeof(CursedScp106EventsHandler), nameof(CursedScp106EventsHandler.ExitingSubmergence))]
[HarmonyPatch(typeof(Scp106HuntersAtlasAbility), nameof(Scp106HuntersAtlasAbility.SetSubmerged), typeof(bool))]
public class HuntersAtlasPatch
{
    // TODO: REVIEW
    private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        List<CodeInstruction> newInstructions = EventManager.CheckEvent<HuntersAtlasPatch>(25, instructions);
        
        Label returnLabel = generator.DefineLabel();

        const int offset = -2;
        int index = newInstructions.FindIndex(i => i.opcode == OpCodes.Stfld) + offset;

        newInstructions.InsertRange(index, new CodeInstruction[]
        {
            new CodeInstruction(OpCodes.Ldarg_0).MoveLabelsFrom(newInstructions[index]),
            new (OpCodes.Ldarg_1),
            new (OpCodes.Call, AccessTools.Method(typeof(HuntersAtlasPatch), nameof(ProcessSubmergingEvents))),
            new (OpCodes.Brfalse_S, returnLabel),
        });

        newInstructions[newInstructions.Count - 1].labels.Add(returnLabel);

        foreach (CodeInstruction instruction in newInstructions)
            yield return instruction;

        ListPool<CodeInstruction>.Shared.Return(newInstructions);
    }

    private static bool ProcessSubmergingEvents(Scp106HuntersAtlasAbility atlasAbility, bool val)
    {
        if (val)
        {
            Scp106SubmergingEventArgs eventArgs = new (atlasAbility);
            CursedScp106EventsHandler.OnSubmerging(eventArgs);
            return eventArgs.IsAllowed;
        }
        else
        {
            Scp106ExitingSubmergenceEventArgs eventArgs = new (atlasAbility);
            CursedScp106EventsHandler.OnExitingSubmergence(eventArgs);
            return eventArgs.IsAllowed;
        }
    }
}