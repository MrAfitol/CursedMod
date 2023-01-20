﻿using InventorySystem.Items;
using InventorySystem.Items.Radio;

namespace CursedMod.Features.Wrappers.Inventory.Items.Radio;

public class CursedRadio : CursedItem
{
    public RadioItem RadioBase { get; }
    
    internal CursedRadio(RadioItem itemBase) : base(itemBase)
    {
        RadioBase = itemBase;
    }

    public bool IsUsable => RadioBase.IsUsable;

    public byte BatteryPercent
    {
        get => RadioBase.BatteryPercent;
        set => RadioBase.BatteryPercent = value;
    }

    public void ProcessCommand(RadioMessages.RadioCommand command) => RadioBase.ServerProcessCmd(command);
    
    public RadioMessages.RadioRangeLevel RangeLevel
    {
        get => RadioBase.RangeLevel;
        set => RadioBase._rangeId = (byte)value;
    }
}