﻿using System;
using CursedMod.Features.Wrappers.Inventory.Items;
using CursedMod.Features.Wrappers.Player;
using InventorySystem.Items;

namespace CursedMod.Events.Arguments.Inventory;

public class PlayerDroppingItemEventArgs : EventArgs, ICursedCancellableEvent, ICursedPlayerEvent, ICursedItemEvent 
{
    public bool IsAllowed { get; set; }
    public CursedPlayer Player { get; }
    public CursedItem Item { get; }
    public bool IsThrow { get; set; }

    public PlayerDroppingItemEventArgs(InventorySystem.Inventory inventory, ItemBase itemBase, bool isThrow)
    {
        IsAllowed = true;
        Player = CursedPlayer.Get(inventory._hub);
        Item = CursedItem.Get(itemBase);
        IsThrow = isThrow;
    }
}