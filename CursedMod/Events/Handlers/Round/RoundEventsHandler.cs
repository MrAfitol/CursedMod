﻿// -----------------------------------------------------------------------
// <copyright file="RoundEventsHandler.cs" company="CursedMod">
// Copyright (c) CursedMod. All rights reserved.
// Licensed under the GPLv3 license.
// See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace CursedMod.Events.Handlers.Round;

public static class RoundEventsHandler
{
    public static event EventManager.CursedEventHandler RoundStarted;
    
    public static event EventManager.CursedEventHandler WaitingForPlayers;
    
    public static event EventManager.CursedEventHandler RestartingRound;
    
    public static event EventManager.CursedEventHandler RoundEnded;

    internal static void OnRoundStarted()
    {
        RoundStarted.InvokeEvent();
    }

    internal static void OnWaitingForPlayers()
    {
        WaitingForPlayers.InvokeEvent();
    }

    internal static void OnRestartingRound()
    {
        RestartingRound.InvokeEvent();
    }

    internal static void OnRoundEnded()
    {
        RoundEnded.InvokeEvent();
    }
}