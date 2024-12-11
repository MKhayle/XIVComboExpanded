using Dalamud.Game.ClientState.JobGauge.Types;
using Lumina.Data.Parsing.Layer;

namespace XIVComboExpandedPlugin.Combos;

internal static class DRG
{
    public const byte ClassID = 4;
    public const byte JobID = 22;

    public const uint
        // Single Target
        TrueThrust = 75,
        VorpalThrust = 78,
        Disembowel = 87,
        FullThrust = 84,
        ChaosThrust = 88,
        WheelingThrust = 3556,
        FangAndClaw = 3554,
        HeavensThrust = 25771,
        ChaoticSpring = 25772,
        RaidenThrust = 16479,
        LanceBarrage = 36954,
        SpiralBlow = 36955,
        Drakesbane = 36952,
        // AoE
        DoomSpike = 86,
        SonicThrust = 7397,
        CoerthanTorment = 16477,
        DraconianFury = 25770,
        // Combined
        Geirskogul = 3555,
        Nastrond = 7400,
        // Jumps
        Jump = 92,
        SpineshatterDive = 95,
        DragonfireDive = 96,
        HighJump = 16478,
        MirageDive = 7399,
        // Dragon
        Stardiver = 16480,
        WyrmwindThrust = 25773,
        RiseOfTheDragon = 36953,
        Starcross = 36956,
        // Buff abilities
        LanceCharge = 85,
        DragonSight = 7398,
        BattleLitany = 3557;

    public static class Buffs
    {
        public const ushort
            SharperFangAndClaw = 802,
            EnhancedWheelingThrust = 803,
            DiveReady = 1243,
            DraconianFire = 1863,
            PowerSurge = 2720,
            NastrondReady = 3844,
            Dragonsflight = 3845,
            StarcrossReady = 3846;
    }

    public static class Debuffs
    {
        public const ushort
            ChaosThrust = 118,
            ChaoticSpring = 2719;
    }

    public static class Levels
    {
        public const byte
            VorpalThrust = 4,
            Disembowel = 18,
            FullThrust = 26,
            SpineshatterDive = 45,
            DragonfireDive = 50,
            ChaosThrust = 50,
            BattleLitany = 52,
            HeavensThrust = 86,
            ChaoticSpring = 86,
            FangAndClaw = 56,
            WheelingThrust = 58,
            Geirskogul = 60,
            SonicThrust = 62,
            Drakesbane = 64,
            DragonSight = 66,
            MirageDive = 68,
            LifeOfTheDragon = 70,
            CoerthanTorment = 72,
            HighJump = 74,
            RaidenThrust = 76,
            Stardiver = 80,
            WyrmwindThrust = 90,
            RiseOfTheDragon = 92,
            Starcross = 100;
    }
}

internal class DragoonCoerthanTorment : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrgAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRG.CoerthanTorment)
        {
            var gauge = GetJobGauge<DRGGauge>();

            if (IsEnabled(CustomComboPreset.DragoonCoerthanWyrmwindFeature))
            {
                if (gauge.FirstmindsFocusCount == 2)
                    return DRG.WyrmwindThrust;
            }

            if (IsEnabled(CustomComboPreset.DragoonCoerthanTormentCombo))
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == DRG.SonicThrust && level >= DRG.Levels.CoerthanTorment)
                        return DRG.CoerthanTorment;

                    if ((lastComboMove == DRG.DoomSpike || lastComboMove == DRG.DraconianFury) && level >= DRG.Levels.SonicThrust)
                        return DRG.SonicThrust;
                }

                // Draconian Fury
                return OriginalHook(DRG.DoomSpike);
            }
        }

        return actionID;
    }
}

internal class DragoonSingleTargetThrust : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrgAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRG.ChaosThrust || actionID == DRG.ChaoticSpring ||
            actionID == DRG.FullThrust || actionID == DRG.HeavensThrust)
        {
            if (IsEnabled(CustomComboPreset.DragoonFullChaosWyrmwindFeature))
            {
                var gauge = GetJobGauge<DRGGauge>();
                if (gauge.FirstmindsFocusCount == 2)
                    return DRG.WyrmwindThrust;
            }

            if ((IsEnabled(CustomComboPreset.DragoonChaosThrustCombo) ||
                IsEnabled(CustomComboPreset.DragoonFullThrustCombo) ||
                IsEnabled(CustomComboPreset.DragoonAllInOneCombo)) &&
                level >= DRG.Levels.Drakesbane &&
                (lastComboMove == DRG.WheelingThrust || lastComboMove == DRG.FangAndClaw))
                return DRG.Drakesbane;

            if ((IsEnabled(CustomComboPreset.DragoonFullThrustCombo) &&
                (actionID == DRG.FullThrust || actionID == DRG.HeavensThrust)) ||
                IsEnabled(CustomComboPreset.DragoonDoubleChaosThrustComboOption) ||
                IsEnabled(CustomComboPreset.DragoonAllInOneCombo))
            {
                if ((lastComboMove == DRG.FullThrust || lastComboMove == DRG.HeavensThrust) &&
                    level >= DRG.Levels.FangAndClaw)
                    // Claw
                    return OriginalHook(DRG.FangAndClaw);

                if ((lastComboMove == DRG.VorpalThrust || lastComboMove == DRG.LanceBarrage) &&
                    level >= DRG.Levels.FullThrust)
                    // Heavens' Thrust
                    return OriginalHook(DRG.FullThrust);
            }

            if ((IsEnabled(CustomComboPreset.DragoonChaosThrustCombo) &&
                (actionID == DRG.ChaosThrust || actionID == DRG.ChaoticSpring)) ||
                IsEnabled(CustomComboPreset.DragoonDoubleFullThrustComboOption) ||
                IsEnabled(CustomComboPreset.DragoonAllInOneCombo))
            {
                if ((lastComboMove == DRG.ChaosThrust || lastComboMove == DRG.ChaoticSpring) &&
                    level >= DRG.Levels.WheelingThrust)
                    // Wheeling
                    return OriginalHook(DRG.WheelingThrust);

                if ((lastComboMove == DRG.Disembowel || lastComboMove == DRG.SpiralBlow) &&
                    level >= DRG.Levels.ChaosThrust)
                    // ChaoticSpring
                    return OriginalHook(DRG.ChaosThrust);
            }

            if ((lastComboMove == DRG.TrueThrust || lastComboMove == DRG.RaidenThrust) &&
                level >= DRG.Levels.Disembowel)
            {
                if (IsEnabled(CustomComboPreset.DragoonChaosThrustCombo) &&
                    (actionID == DRG.ChaosThrust || actionID == DRG.ChaoticSpring))
                    return OriginalHook(DRG.Disembowel);

                if (IsEnabled(CustomComboPreset.DragoonAllInOneCombo))
                {
                    var powersurge = FindEffect(DRG.Buffs.PowerSurge);
                    var chaosthrust = FindTargetEffect(DRG.Debuffs.ChaosThrust);
                    var chaoticspring = FindTargetEffect(DRG.Debuffs.ChaoticSpring);
                    var buffThreshold = 15.0; // 12.5s until next Disembowel opportunity
                    var dotThreshold = 9.0; // DoT naturally lasts 6 seconds less than Disembowel
                    if (level < DRG.Levels.Drakesbane)
                    {
                        buffThreshold -= 2.5;
                        dotThreshold -= 2.5;
                    }

                    if (level < DRG.Levels.FangAndClaw)
                    {
                        buffThreshold -= 2.5;
                        dotThreshold -= 2.5;
                    }

                    if (!((chaosthrust?.RemainingTime > dotThreshold ||
                        chaoticspring?.RemainingTime > dotThreshold) &&
                        powersurge?.RemainingTime > buffThreshold))
                        return OriginalHook(DRG.Disembowel);

                    return OriginalHook(DRG.VorpalThrust);
                }
            }

            if ((lastComboMove == DRG.TrueThrust || lastComboMove == DRG.RaidenThrust) &&
                level >= DRG.Levels.VorpalThrust)
            {
                if ((IsEnabled(CustomComboPreset.DragoonFullThrustCombo) &&
                    (actionID == DRG.FullThrust || actionID == DRG.HeavensThrust)) ||
                    IsEnabled(CustomComboPreset.DragoonAllInOneCombo))
                    return OriginalHook(DRG.VorpalThrust);
            }

            if (IsEnabled(CustomComboPreset.DragoonFullThrustCombo) &&
                !IsEnabled(CustomComboPreset.DragoonFullThrustComboOption) &&
                (actionID == DRG.FullThrust || actionID == DRG.HeavensThrust))
                return OriginalHook(DRG.TrueThrust);

            if (IsEnabled(CustomComboPreset.DragoonChaosThrustCombo) &&
                !IsEnabled(CustomComboPreset.DragoonChaosThrustComboOption) &&
                (actionID == DRG.ChaosThrust || actionID == DRG.ChaoticSpring))
                return OriginalHook(DRG.TrueThrust);

            if (IsEnabled(CustomComboPreset.DragoonAllInOneCombo))
                return OriginalHook(DRG.TrueThrust);
        }

        return actionID;
    }
}

internal class DragoonStardiver : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrgAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRG.Stardiver)
        {
            var gauge = GetJobGauge<DRGGauge>();

            // Always prefer Geirskogul over everything else, if it's enabled, since the Geirskogul cooldown is the
            // primary rotational timing cooldown for DRG, and anything else we'd want to use, we'd rather use inside
            // Life of the Dragon anyway, if it's available.
            if (IsEnabled(CustomComboPreset.DragoonStardiverNastrondFeature))
            {
                if (level >= DRG.Levels.Geirskogul && IsCooldownUsable(DRG.Geirskogul))
                    return DRG.Geirskogul;
            }

            var canUseStardiver = (CanUseAction(DRG.Stardiver) && IsCooldownUsable(DRG.Stardiver)) ||
                OriginalHook(DRG.Stardiver) != DRG.Stardiver;

            // Dragonfire is prioritized over Nastrond, because it actually has a cooldown where drift can cause issues.
            if (IsEnabled(CustomComboPreset.DragoonStardiverDragonfireDiveFeature) &&
                level >= DRG.Levels.DragonfireDive)
            {
                var canUseDragonfire = IsCooldownUsable(DRG.DragonfireDive) ||
                     OriginalHook(DRG.DragonfireDive) != DRG.DragonfireDive;

                if (canUseDragonfire && (level < DRG.Levels.Stardiver || !gauge.IsLOTDActive || !canUseStardiver ||
                    (gauge.LOTDTimer > 7.5 && !IsEnabled(CustomComboPreset.DragoonStardiverBeforeDragonfire))))
                    return OriginalHook(DRG.DragonfireDive);
            }

            if (IsEnabled(CustomComboPreset.DragoonStardiverNastrondFeature) && level >= DRG.Levels.LifeOfTheDragon)
            {
                var canUseNastrond = HasEffect(DRG.Buffs.NastrondReady);

                if (canUseNastrond && (!canUseStardiver ||
                    !IsEnabled(CustomComboPreset.DragoonStardiverBeforeNastrond)))
                    return DRG.Nastrond;
            }
        }

        return actionID;
    }
}

internal class DragoonGierskogul : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DragoonGeirskogulWyrmwindFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRG.Geirskogul)
        {
            if (level >= DRG.Levels.WyrmwindThrust)
            {
                var gauge = GetJobGauge<DRGGauge>();
                if (gauge.FirstmindsFocusCount == 2 && !IsCooldownUsable(DRG.Geirskogul))
                    return DRG.WyrmwindThrust;
            }
        }

        return actionID;
    }
}

internal class DragoonLanceCharge : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DragoonLanceChargeFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRG.LanceCharge)
        {
            if (IsCooldownUsable(DRG.LanceCharge))
                return DRG.LanceCharge;

            if (level >= DRG.Levels.BattleLitany && IsCooldownUsable(DRG.BattleLitany))
                return DRG.BattleLitany;
        }

        return actionID;
    }
}
