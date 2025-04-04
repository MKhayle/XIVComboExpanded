using System.Data.Common;
using Dalamud.Game.ClientState.JobGauge.Types;
using System;

namespace XIVComboExpandedPlugin.Combos;

internal static class GNB
{
    public const byte JobID = 37;

    public const uint
        KeenEdge = 16137,
        NoMercy = 16138,
        BrutalShell = 16139,
        DemonSlice = 16141,
        RoyalGuard = 16142,
        LightningShot = 16143,
        DangerZone = 16144,
        SolidBarrel = 16145,
        GnashingFang = 16146,
        SavageClaw = 16147,
        DemonSlaughter = 16149,
        WickedTalon = 16150,
        SonicBreak = 16153,
        Trajectory = 36934,
        Continuation = 16155,
        JugularRip = 16156,
        AbdomenTear = 16157,
        EyeGouge = 16158,
        BowShock = 16159,
        BurstStrike = 16162,
        FatedCircle = 16163,
        Bloodfest = 16164,
        Hypervelocity = 25759,
        DoubleDown = 25760,
        RoyalGuardRemoval = 32068,
        FatedBrand = 36936,
        ReignOfBeasts = 36937,
        NobleBlood = 36938,
        LionHeart = 36939;

    public static class Buffs
    {
        public const ushort
            NoMercy = 1831,
            RoyalGuard = 1833,
            ReadyToRip = 1842,
            ReadyToTear = 1843,
            ReadyToGouge = 1844,
            ReadyToBlast = 2686,
            ReadyToFated = 3839,
            ReadyToReign = 3840,
            ReadyToBreak = 3886;
    }

    public static class Debuffs
    {
        public const ushort
            BowShock = 1838;
    }

    public static class Levels
    {
        public const byte
            NoMercy = 2,
            BrutalShell = 4,
            RoyalGuard = 10,
            DangerZone = 18,
            SolidBarrel = 26,
            BurstStrike = 30,
            DemonSlaughter = 40,
            SonicBreak = 54,
            Trajectory = 56,
            GnashingFang = 60,
            BowShock = 62,
            Continuation = 70,
            FatedCircle = 72,
            Bloodfest = 76,
            EnhancedContinuation = 86,
            CartridgeCharge2 = 88,
            DoubleDown = 90,
            ReignOfBeasts = 100;
    }
}

internal class GunbreakerSolidBarrel : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerSolidBarrelCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == GNB.SolidBarrel)
        {
            if (comboTime > 0)
            {
                if (lastComboMove == GNB.BrutalShell && level >= GNB.Levels.SolidBarrel)
                {
                    if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeFeature))
                    {
                        var gauge = GetJobGauge<GNBGauge>();
                        var maxAmmo = level >= GNB.Levels.CartridgeCharge2 ? 3 : 2;

                        if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeCont))
                        {
                            if (level >= GNB.Levels.EnhancedContinuation && HasEffect(GNB.Buffs.ReadyToBlast))
                                return GNB.Hypervelocity;
                        }

                        if (IsEnabled(CustomComboPreset.GunbreakerDoubleDownFeatureST))
                        {
                            if (level >= GNB.Levels.DoubleDown && gauge.Ammo == maxAmmo && IsCooldownUsable(GNB.DoubleDown))
                                return GNB.DoubleDown;
                        }

                        if (level >= GNB.Levels.BurstStrike && gauge.Ammo == maxAmmo)
                            return GNB.BurstStrike;
                    }

                    return GNB.SolidBarrel;
                }

                if (lastComboMove == GNB.KeenEdge && level >= GNB.Levels.BrutalShell)
                    return GNB.BrutalShell;
            }

            return GNB.KeenEdge;
        }

        return actionID;
    }
}

internal class GunbreakerBrutalShell : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerBrutalShellCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == GNB.BrutalShell && lastComboMove != GNB.KeenEdge)
        {
            return GNB.KeenEdge;
        }

        return actionID;
    }
}

internal class GunbreakerGnashingFang : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerGnashingFangCont;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == GNB.GnashingFang)
        {
            if (level >= GNB.Levels.Continuation)
            {
                if (HasEffect(GNB.Buffs.ReadyToGouge))
                    return GNB.EyeGouge;

                if (HasEffect(GNB.Buffs.ReadyToTear))
                    return GNB.AbdomenTear;

                if (HasEffect(GNB.Buffs.ReadyToRip))
                    return GNB.JugularRip;
            }

            // Gnashing Fang > Savage Claw > Wicked Talon
            return OriginalHook(GNB.GnashingFang);
        }

        return actionID;
    }
}

internal class GunbreakerBurstStrikeFatedCircle : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GnbAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == GNB.BurstStrike)
        {
            if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeCont))
            {
                if (level >= GNB.Levels.EnhancedContinuation && HasEffect(GNB.Buffs.ReadyToBlast) && CanUseAction(OriginalHook(GNB.Hypervelocity)))
                    return GNB.Hypervelocity;
            }

            if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeDangerZone))
            {
                if (level >= GNB.Levels.DangerZone && IsCooldownUsable(GNB.DangerZone) && CanUseAction(OriginalHook(GNB.DangerZone)))
                    return OriginalHook(GNB.DangerZone);
            }

            if (IsEnabled(CustomComboPreset.GunbreakerBloodReignFeature) &&
                (HasEffect(GNB.Buffs.ReadyToReign) ||
                 !IsOriginal(GNB.Bloodfest)))
                return OriginalHook(GNB.Bloodfest);

            if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeGnashingFang))
            {
                if (level >= GNB.Levels.GnashingFang)
                {
                    var gauge = GetJobGauge<GNBGauge>();
                    if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangCont) &&
                        (HasEffect(GNB.Buffs.ReadyToRip) ||
                         HasEffect(GNB.Buffs.ReadyToTear) ||
                         HasEffect(GNB.Buffs.ReadyToGouge)))
                        return OriginalHook(GNB.Continuation);
                    if ((IsCooldownUsable(GNB.GnashingFang) && gauge.Ammo > 0) || !IsOriginal(GNB.GnashingFang))
                        return OriginalHook(GNB.GnashingFang);
                }
            }
        }

        if (actionID == GNB.FatedCircle)
        {
            if (IsEnabled(CustomComboPreset.GunbreakerFatedCircleCont))
            {
                if (level >= GNB.Levels.EnhancedContinuation && HasEffect(GNB.Buffs.ReadyToFated))
                    return GNB.FatedBrand;
            }

            if (IsEnabled(CustomComboPreset.GunbreakerBloodReignFeature) &&
                (HasEffect(GNB.Buffs.ReadyToReign) ||
                 !IsOriginal(GNB.Bloodfest)))
                return OriginalHook(GNB.Bloodfest);
        }

        if (actionID == GNB.BurstStrike || actionID == GNB.FatedCircle)
        {
            var gauge = GetJobGauge<GNBGauge>();

            if (IsEnabled(CustomComboPreset.GunbreakerEmptyBloodfestFeature))
            {
                if (level >= GNB.Levels.Bloodfest && gauge.Ammo == 0)
                    return OriginalHook(GNB.Bloodfest);
            }
        }

        return actionID;
    }
}

internal class GunbreakerBowShockSonicBreak : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerBowShockSonicBreakFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == GNB.BowShock || actionID == GNB.SonicBreak)
        {
            if (level >= GNB.Levels.BowShock && IsCooldownUsable(GNB.BowShock))
            {
                // Sonic Break has no real cooldown, but this also conveniently checks the GCD, so if Bow Shock is
                // off cooldown and the Ready to Break buff from No Mercy is active, this effectively returns
                // Sonic Break if the GCD is not active, and Bow Shock if the GCD *is* active, which is exactly
                // what we want.
                if (HasEffect(GNB.Buffs.ReadyToBreak))
                    return CalcBestAction(GNB.SonicBreak, GNB.SonicBreak, GNB.BowShock);

                return GNB.BowShock;
            }

            // Level check just to reduce useless buff checks when synced.
            if (level >= GNB.Levels.SonicBreak && HasEffect(GNB.Buffs.ReadyToBreak))
                return GNB.SonicBreak;
        }

        return actionID;
    }
}

internal class GunbreakerDemonSlaughter : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerDemonSlaughterCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == GNB.DemonSlaughter)
        {

            if (comboTime > 0 && lastComboMove == GNB.DemonSlice && level >= GNB.Levels.DemonSlaughter)
            {
                var gauge = GetJobGauge<GNBGauge>();
                var maxAmmo = level >= GNB.Levels.CartridgeCharge2 ? 3 : 2;

                if (IsEnabled(CustomComboPreset.GunbreakerDoubleDownFeatureAoE))
                {
                    if (level >= GNB.Levels.DoubleDown && gauge.Ammo == maxAmmo && IsCooldownUsable(GNB.DoubleDown))
                        return GNB.DoubleDown;
                }

                if (IsEnabled(CustomComboPreset.GunbreakerFatedCircleFeature))
                {
                    if (HasEffect(GNB.Buffs.ReadyToFated) && IsEnabled(CustomComboPreset.GunbreakerFatedCircleCont))
                    {
                        return GNB.FatedBrand;
                    }

                    if (level >= GNB.Levels.FatedCircle && gauge.Ammo == maxAmmo)
                        return GNB.FatedCircle;
                }

                return GNB.DemonSlaughter;
            }

            return GNB.DemonSlice;
        }

        return actionID;
    }
}

internal class GunbreakerNoMercy : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GnbAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == GNB.NoMercy)
        {
            var gauge = GetJobGauge<GNBGauge>();

            if (IsEnabled(CustomComboPreset.GunbreakerNoMercyDoubleDownFeature))
            {
                if (level >= GNB.Levels.NoMercy && HasEffect(GNB.Buffs.NoMercy))
                {
                    if (level >= GNB.Levels.DoubleDown && gauge.Ammo >= 1 && IsCooldownUsable(GNB.DoubleDown))
                        return GNB.DoubleDown;
                }
            }

            if (IsEnabled(CustomComboPreset.GunbreakerNoMercyAlwaysDoubleDownFeature))
            {
                if (level >= GNB.Levels.NoMercy && HasEffect(GNB.Buffs.NoMercy))
                {
                    if (level >= GNB.Levels.DoubleDown)
                        return GNB.DoubleDown;
                }
            }

            if (IsEnabled(CustomComboPreset.GunbreakerNoMercyFeature) &&
                level >= GNB.Levels.NoMercy && HasEffect(GNB.Buffs.NoMercy))
            {
                if (level >= GNB.Levels.BowShock && IsCooldownUsable(GNB.BowShock))
                {
                    // Sonic Break has no real cooldown, but this also conveniently checks the GCD, so if Bow Shock is
                    // off cooldown and the Ready to Break buff from No Mercy is active, this effectively returns
                    // Sonic Break if the GCD is not active, and Bow Shock if the GCD *is* active, which is exactly
                    // what we want.
                    if (HasEffect(GNB.Buffs.ReadyToBreak))
                        return CalcBestAction(GNB.SonicBreak, GNB.SonicBreak, GNB.BowShock);

                    return GNB.BowShock;
                }
            }
        }

        return actionID;
    }
}

internal class GunbreakerExpandedContinuation : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerExpandedContinuation;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == GNB.Continuation)
        {
            var gauge = GetJobGauge<GNBGauge>();

            // Default continuation behavior
            if (HasEffect(GNB.Buffs.ReadyToRip) || HasEffect(GNB.Buffs.ReadyToTear) || HasEffect(GNB.Buffs.ReadyToGouge) || HasEffect(GNB.Buffs.ReadyToBlast) || HasEffect(GNB.Buffs.ReadyToFated))
                return OriginalHook(GNB.Continuation);

            // Combo Danger/Blasting zone off Keen Edge
            if (level >= GNB.Levels.DangerZone && (lastComboMove == GNB.KeenEdge || lastComboMove == GNB.BrutalShell) && IsCooldownUsable(GNB.DangerZone) && !IsEnabled(CustomComboPreset.GunbreakerExpandedContinuationDisableDangerZone))
                return OriginalHook(GNB.DangerZone);

            // Bow Shock off cd, which functionally combos with Trajectory for your intro combo. Similar to PLD entry > Circle of Scorn
            if (level >= GNB.Levels.BowShock && IsCooldownUsable(GNB.BowShock) && !IsEnabled(CustomComboPreset.GunbreakerExpandedContinuationDisableBowShock))
                return GNB.BowShock;

            // Combo with No Mercy > Sonic Break
            if ((HasEffect(GNB.Buffs.ReadyToBreak) && level >= GNB.Levels.SonicBreak && IsCooldownUsable(GNB.SonicBreak)) && !IsEnabled(CustomComboPreset.GunbreakerExpandedContinuationDisableSonicBreak))
                return GNB.SonicBreak;

            // Combo Double Down off either Solid Barrel or Demon Slaughter
            if (((lastComboMove == GNB.SolidBarrel && !IsEnabled(CustomComboPreset.GunbreakerExpandedContinuationDisableSolidBarrel)) || (lastComboMove == GNB.DemonSlaughter && !IsEnabled(CustomComboPreset.GunbreakerExpandedContinuationDisableDemonSlaughter))) && level >= GNB.Levels.DoubleDown && gauge.Ammo >= 2 && IsCooldownUsable(GNB.DoubleDown))
                return OriginalHook(GNB.DoubleDown);

            // Combo to prefer Gnashing Fang combo over Burst Strike after Solid Barrel
            if (((lastComboMove == GNB.SolidBarrel && level >= GNB.Levels.GnashingFang && gauge.Ammo >= 1 && IsCooldownUsable(GNB.GnashingFang)) || !IsOriginal(GNB.GnashingFang) ) && !IsEnabled(CustomComboPreset.GunbreakerExpandedContinuationDisableSolidBarrel))
                return OriginalHook(GNB.GnashingFang);

            // Combo for Burst Strike after Solid Barrel
            if (lastComboMove == GNB.SolidBarrel && level >= GNB.Levels.BurstStrike && gauge.Ammo >= 1 && !IsEnabled(CustomComboPreset.GunbreakerExpandedContinuationDisableSolidBarrel))
                return GNB.BurstStrike;

            // Combo for Demon Slaughter > Fated Circle
            if (lastComboMove == GNB.DemonSlaughter && level >= GNB.Levels.FatedCircle && gauge.Ammo >= 1 && !IsEnabled(CustomComboPreset.GunbreakerExpandedContinuationDisableDemonSlaughter))
                return GNB.FatedCircle;

            // Reign combo, combos off of Bloodfest
            if (HasEffect(GNB.Buffs.ReadyToReign) || !IsOriginal(GNB.ReignOfBeasts) && !IsEnabled(CustomComboPreset.GunbreakerExpandedContinuationDisableBloodfest))
                return OriginalHook(GNB.ReignOfBeasts);

            return OriginalHook(GNB.Continuation);
        }

        return actionID;
    }
}

internal class GunbreakerTrajectoryDowngradeFeature : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerTrajectoryDowngradeFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == GNB.Trajectory)
        {
            if (level <= GNB.Levels.Trajectory || !CanUseAction(GNB.Trajectory))
                return GNB.LightningShot;
        }

        return actionID;
    }
}