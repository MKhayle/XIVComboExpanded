using System;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

internal static class WAR
{
    public const byte ClassID = 3;
    public const byte JobID = 21;

    public const uint
        HeavySwing = 31,
        Maim = 37,
        Berserk = 38,
        ThrillOfBattle = 40,
        Overpower = 41,
        StormsPath = 42,
        StormsEye = 45,
        Defiance = 48,
        InnerBeast = 49,
        SteelCyclone = 51,
        Infuriate = 52,
        FellCleave = 3549,
        Decimate = 3550,
        RawIntuition = 3551,
        Equilibrium = 3552,
        InnerRelease = 7389,
        MythrilTempest = 16462,
        ChaoticCyclone = 16463,
        NascentFlash = 16464,
        InnerChaos = 16465,
        Bloodwhetting = 25751,
        PrimalRend = 25753,
        DefianceRemoval = 32066,
        PrimalWrath = 36924,
        PrimalRuination = 36925;

    public static class Buffs
    {
        public const ushort
            Berserk = 86,
            Defiance = 91,
            InnerRelease = 1177,
            NascentChaos = 1897,
            PrimalRendReady = 2624,
            SurgingTempest = 2677,
            Wrathful = 3901,
            PrimalRuinationReady = 3834;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            Maim = 4,
            Berserk = 6,
            Defiance = 10,
            StormsPath = 26,
            ThrillOfBattle = 30,
            InnerBeast = 35,
            MythrilTempest = 40,
            StormsEye = 50,
            Infuriate = 50,
            FellCleave = 54,
            RawIntuition = 56,
            Equilibrium = 58,
            Decimate = 60,
            InnerRelease = 70,
            MythrilTempestTrait = 74,
            NascentFlash = 76,
            InnerChaos = 80,
            Bloodwhetting = 82,
            PrimalRend = 90,
            PrimalWrath = 96,
            PrimalRuination = 100;
    }
}

internal class WarriorStormsPathCombo : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WarAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == WAR.StormsPath)
        {
            var gauge = GetJobGauge<WARGauge>();

            if (IsEnabled(CustomComboPreset.WarriorStormsPathInnerReleaseFeature))
            {
                if (level >= WAR.Levels.InnerRelease && HasEffect(WAR.Buffs.InnerRelease))
                    return OriginalHook(WAR.FellCleave);
            }

            if (lastComboMove == WAR.Maim && level >= WAR.Levels.StormsPath)
            {
                if (IsEnabled(CustomComboPreset.WarriorSTGaugeOvercapProtection))
                {
                    if (level >= WAR.Levels.InnerBeast && gauge.BeastGauge > 80)
                        // Fell Cleave
                        return OriginalHook(WAR.InnerBeast);
                }

                if (level >= WAR.Levels.StormsEye && IsEnabled(CustomComboPreset.WarriorAutoSurgingTempestFeature))
                {
                    var surgingTempest = FindEffect(WAR.Buffs.SurgingTempest);
                    if (surgingTempest is null)
                        return WAR.StormsEye;

                    if (!IsEnabled(CustomComboPreset.WarriorOptimizeSurgingTempestFeature) &&
                        surgingTempest.RemainingTime < 15)
                        return WAR.StormsEye;

                    // Medicated + Opener
                    if (HasEffect(ADV.Buffs.Medicated) && surgingTempest.RemainingTime > 10)
                        return WAR.StormsPath;

                    var innerReleaseCD = GetCooldown(WAR.InnerRelease).CooldownRemaining;
                    var surgingTempestFromIR = Math.Max(0, 10 - innerReleaseCD);
                    if (surgingTempest.RemainingTime + 30 + surgingTempestFromIR < 60)
                        return WAR.StormsEye;
                }

                return WAR.StormsPath;
            }

            if (IsEnabled(CustomComboPreset.WarriorStormsPathCombo))
            {
                if (lastComboMove == WAR.HeavySwing && level >= WAR.Levels.Maim)
                {
                    if (IsEnabled(CustomComboPreset.WarriorSTGaugeOvercapProtection))
                    {
                        if (level >= WAR.Levels.InnerBeast && gauge.BeastGauge > 90)
                            // Fell Cleave
                            return OriginalHook(WAR.InnerBeast);
                    }

                    return WAR.Maim;
                }

                return WAR.HeavySwing;
            }
        }

        return actionID;
    }
}

internal class WarriorStormsEyeCombo : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WarAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == WAR.StormsEye)
        {
            var gauge = GetJobGauge<WARGauge>();

            if (lastComboMove == WAR.Maim && level >= WAR.Levels.StormsEye)
            {
                if (IsEnabled(CustomComboPreset.WarriorSTGaugeOvercapProtection))
                {
                    if (level >= WAR.Levels.InnerBeast && gauge.BeastGauge > 90)
                        // Fell Cleave
                        return OriginalHook(WAR.InnerBeast);
                }

                return WAR.StormsEye;
            }

            if (IsEnabled(CustomComboPreset.WarriorStormsEyeCombo))
            {
                if (lastComboMove == WAR.HeavySwing && level >= WAR.Levels.Maim)
                {
                    if (IsEnabled(CustomComboPreset.WarriorSTGaugeOvercapProtection))
                    {
                        if (level >= WAR.Levels.InnerBeast && gauge.BeastGauge > 90)
                            // Fell Cleave
                            return OriginalHook(WAR.InnerBeast);
                    }

                    return WAR.Maim;
                }

                return WAR.HeavySwing;
            }
        }

        return actionID;
    }
}

internal class WarriorMythrilTempestCombo : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WarAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == WAR.MythrilTempest)
        {
            var gauge = GetJobGauge<WARGauge>();

            if (IsEnabled(CustomComboPreset.WarriorMythrilTempestInnerReleaseFeature))
            {
                if (level >= WAR.Levels.InnerRelease && HasEffect(WAR.Buffs.InnerRelease))
                    return OriginalHook(WAR.Decimate);
            }

            if (lastComboMove == WAR.Overpower && level >= WAR.Levels.MythrilTempest)
            {
                if (IsEnabled(CustomComboPreset.WarriorAoEGaugeOvercapProtection))
                {
                    if (level >= WAR.Levels.MythrilTempestTrait && gauge.BeastGauge > 80)
                        return OriginalHook(WAR.Decimate);
                }

                return WAR.MythrilTempest;
            }

            if (IsEnabled(CustomComboPreset.WarriorMythrilTempestCombo))
                return WAR.Overpower;
        }

        return actionID;
    }
}

internal class WarriorFellCleaveDecimate : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WarAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == WAR.InnerBeast || actionID == WAR.FellCleave ||
            actionID == WAR.SteelCyclone || actionID == WAR.Decimate)
        {
            if (IsEnabled(CustomComboPreset.WarriorPrimalBeastFeature))
            {
                if (level >= WAR.Levels.PrimalRuination && HasEffect(WAR.Buffs.PrimalRuinationReady))
                    return WAR.PrimalRuination;

                if (level >= WAR.Levels.PrimalRend && HasEffect(WAR.Buffs.PrimalRendReady))
                    return WAR.PrimalRend;
            }

            if (IsEnabled(CustomComboPreset.WarriorInfuriateBeastFeature))
            {
                var gauge = GetJobGauge<WARGauge>();

                if (level >= WAR.Levels.Infuriate && gauge.BeastGauge < 50 && !HasEffect(WAR.Buffs.InnerRelease))
                    return WAR.Infuriate;
            }
        }

        return actionID;
    }
}

internal class WarriorBerserkInnerRelease : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WarriorPrimalReleaseFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == WAR.Berserk || actionID == WAR.InnerRelease)
        {
            if (level >= WAR.Levels.PrimalWrath && HasEffect(WAR.Buffs.Wrathful))
                return WAR.PrimalWrath;

            if (level >= WAR.Levels.PrimalRuination && HasEffect(WAR.Buffs.PrimalRuinationReady))
                return WAR.PrimalRuination;

            if (level >= WAR.Levels.PrimalRend && HasEffect(WAR.Buffs.PrimalRendReady))
                return WAR.PrimalRend;
        }

        return actionID;
    }
}

internal class WarriorNascentFlashFeature : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WarriorNascentFlashSyncFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == WAR.NascentFlash)
        {
            if (level < WAR.Levels.NascentFlash && level >= WAR.Levels.RawIntuition)
                return WAR.RawIntuition;
        }

        return actionID;
    }
}

internal class WarriorBloodwhetting : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WarAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == WAR.Bloodwhetting || actionID == WAR.RawIntuition)
        {
            if (IsEnabled(CustomComboPreset.WarriorHealthyBalancedDietFeature))
            {
                if (level >= WAR.Levels.Bloodwhetting)
                {
                    if (IsCooldownUsable(WAR.Bloodwhetting))
                        return WAR.Bloodwhetting;
                }
                else if (level >= WAR.Levels.RawIntuition)
                {
                    if (IsCooldownUsable(WAR.RawIntuition))
                        return WAR.RawIntuition;
                }

                if (level >= WAR.Levels.ThrillOfBattle && IsCooldownUsable(WAR.ThrillOfBattle))
                    return WAR.ThrillOfBattle;

                if (level >= WAR.Levels.Equilibrium && IsCooldownUsable(WAR.Equilibrium))
                    return WAR.Equilibrium;
            }
        }

        return actionID;
    }
}
