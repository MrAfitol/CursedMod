﻿// -----------------------------------------------------------------------
// <copyright file="PlayerEventsHandler.cs" company="CursedMod">
// Copyright (c) CursedMod. All rights reserved.
// Licensed under the GPLv3 license.
// See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using CursedMod.Events.Arguments.Player;
using CursedMod.Features.Logger;
using CursedMod.Features.Wrappers.Player;

namespace CursedMod.Events.Handlers.Player;

public static class PlayerEventsHandler
{
    public static event EventManager.CursedEventHandler<PlayerJoinedEventArgs> Joined;
    
    public static event EventManager.CursedEventHandler<PlayerDisconnectedEventArgs> Disconnected;
    
    public static event EventManager.CursedEventHandler<PlayerChangingRoleEventArgs> ChangingRole;
    
    public static event EventManager.CursedEventHandler<PlayerReceivingDamageEventArgs> ReceivingDamage;
    
    public static event EventManager.CursedEventHandler<PlayerDyingEventArgs> Dying;
    
    public static event EventManager.CursedEventHandler<PlayerEscapingEventArgs> Escaping;
    
    public static event EventManager.CursedEventHandler<RagdollSpawnedEventArgs> RagdollSpawned;

    internal static void OnPlayerJoined(PlayerJoinedEventArgs args)
    {
        if (!CheckPlayer(args.Player))
            return;
        
        Joined.InvokeEvent(args);
    }

    internal static void OnPlayerDisconnected(PlayerDisconnectedEventArgs args)
    {
        if (!CheckPlayer(args.Player))
            return;
        
        Disconnected.InvokeEvent(args); 
        CursedLogger.InternalDebug("Removing player");
        CursedPlayer.Dictionary.Remove(args.Player.ReferenceHub);
    }

    internal static void OnPlayerChangingRole(PlayerChangingRoleEventArgs args)
    {
        if (!CheckPlayer(args.Player))
            return;
        
        ChangingRole.InvokeEvent(args);
    }

    internal static void OnPlayerReceivingDamage(PlayerReceivingDamageEventArgs args)
    {
        if (!CheckPlayer(args.Player))
            return;
        
        ReceivingDamage.InvokeEvent(args);
    }
    
    internal static void OnPlayerDying(PlayerDyingEventArgs args)
    {
        if (!CheckPlayer(args.Player))
            return;
        
        Dying.InvokeEvent(args);
    }
    
    internal static void OnPlayerEscaping(PlayerEscapingEventArgs args)
    {
        if (!CheckPlayer(args.Player))
            return;
        
        Escaping.InvokeEvent(args);
    }

    internal static void OnRagdollSpawned(BasicRagdoll ragdoll)
    {
        RagdollSpawned.InvokeEvent(new RagdollSpawnedEventArgs(ragdoll));
    }

    private static bool CheckPlayer(CursedPlayer player) => player is not null && !player.IsDummy;
}