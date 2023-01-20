﻿using Footprinting;
using InventorySystem.Items.Firearms;
using InventorySystem.Items.Firearms.Attachments.Components;
using InventorySystem.Items.Firearms.BasicMessages;
using InventorySystem.Items.Firearms.Modules;

namespace CursedMod.Features.Wrappers.Inventory.Items.Firearms;

public class CursedFirearm : CursedItem
{
    public Firearm FirearmBase { get; }
    
    internal CursedFirearm(Firearm itemBase) : base(itemBase)
    {
        FirearmBase = itemBase;
    }

    public static CursedFirearm Get(Firearm firearm)
    {
        if (firearm is AutomaticFirearm automaticFirearm)
            return new CursedAutomaticFirearm(automaticFirearm);

        return new CursedFirearm(firearm);
    }

    public FirearmBaseStats BaseStats => FirearmBase.BaseStats;

    public float ArmorPenetration => FirearmBase.ArmorPenetration;

    public IAmmoManagerModule AmmoManagerModule
    {
        get => FirearmBase.AmmoManagerModule;
        set => FirearmBase.AmmoManagerModule = value;
    }

    public byte Ammo
    {
        get => Status.Ammo;
        set => Status = new FirearmStatus(value, Status.Flags, Status.Attachments);
    }
    
    public byte MaxAmmo => AmmoManagerModule.MaxAmmo;

    public IEquipperModule EquipperModule
    {
        get => FirearmBase.EquipperModule;
        set => FirearmBase.EquipperModule = value;
    }

    public IActionModule ActionModule
    {
        get => FirearmBase.ActionModule;
        set => FirearmBase.ActionModule = value;
    }

    public IInspectorModule InspectorModule
    {
        get => FirearmBase.InspectorModule;
        set => FirearmBase.InspectorModule = value;
    }

    public IHitregModule HitregModule
    {
        get => FirearmBase.HitregModule;
        set => FirearmBase.HitregModule = value;
    }

    public IAdsModule AdsModule
    {
        get => FirearmBase.AdsModule;
        set => FirearmBase.AdsModule = value;
    }

    public FirearmStatus Status
    {
        get => FirearmBase.Status;
        set => FirearmBase.Status = value;
    }

    public Footprint Footprint => FirearmBase.Footprint;

    public bool AllowDisarming => FirearmBase.AllowDisarming;
    
    public float StaminaUsageMultiplier => FirearmBase.StaminaUsageMultiplier;
    
    public float MovementSpeedMultiplier => FirearmBase.MovementSpeedMultiplier;
    
    public float StaminaRegenMultiplier => FirearmBase.StaminaRegenMultiplier;
    
    public float MovementSpeedLimit => FirearmBase.MovementSpeedLimit;
    
    public bool SprintingDisabled => FirearmBase.SprintingDisabled;

    public float Lenght => FirearmBase.Length;

    public bool IsEmittingLight => FirearmBase.IsEmittingLight;

    public bool MovementModifierActive => FirearmBase.MovementModifierActive;

    public bool StaminaModifierActive => FirearmBase.StaminaModifierActive;

    public bool IsAiming => AdsModule.ServerAds;

    //
    public bool FlashlightEnabled
    {
        get => Status.Flags.HasFlagFast(FirearmStatusFlags.FlashlightEnabled);
        set
        {
            FirearmStatusFlags flags = Status.Flags;
            if (value)
                flags = flags | FirearmStatusFlags.FlashlightEnabled;
            else
                flags = flags & ~FirearmStatusFlags.FlashlightEnabled;

            Status = new FirearmStatus(Status.Ammo, flags, Status.Attachments);
        }
    }

    public float BaseWeight
    {
        get => FirearmBase.BaseWeight;
        set => FirearmBase.BaseWeight = value;
    }

    public float BaseLenght
    {
        get => FirearmBase.BaseLength;
        set => FirearmBase.BaseLength = value;
    }

    public Attachment[] Attachments
    {
        get => FirearmBase.Attachments;
        set => FirearmBase.Attachments = value;
    }

    public uint AttachmentsCode
    {
        get => Status.Attachments;
        set => Status = new FirearmStatus(Status.Ammo, Status.Flags, value);
    }
}