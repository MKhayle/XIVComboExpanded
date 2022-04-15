using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

internal static class BRD
{
    public const byte ClassID = 5;
    public const byte JobID = 23;

    public const uint
        HeavyShot = 97,
        StraightShot = 98,
        VenomousBite = 100,
        RagingStrikes = 101,
        QuickNock = 106,
        Barrage = 107,
        Bloodletter = 110,
        Windbite = 113,
        RainOfDeath = 117,
        BattleVoice = 118,
        EmpyrealArrow = 3558,
        WanderersMinuet = 3559,
        LegGraze = 7554,
        IronJaws = 3560,
        Sidewinder = 3562,
        PitchPerfect = 7404,
        CausticBite = 7406,
        Stormbite = 7407,
        RefulgentArrow = 7409,
        BurstShot = 16495,
        ApexArrow = 16496,
        Shadowbite = 16494,
        Ladonsbite = 25783,
        BlastArrow = 25784,
        RadiantFinale = 25785;

    public static class Buffs
    {
        public const ushort
            StraightShotReady = 122,
            BlastShotReady = 2692,
            ShadowbiteReady = 3002;
    }

    public static class Debuffs
    {
        public const ushort
            VenomousBite = 124,
            Windbite = 129,
            CausticBite = 1200,
            Stormbite = 1201;
    }

    public static class Levels
    {
        public const byte
            StraightShot = 2,
            RagingStrikes = 4,
            VenomousBite = 6,
            Bloodletter = 12,
            Windbite = 30,
            RainOfDeath = 45,
            BattleVoice = 50,
            PitchPerfect = 52,
            EmpyrealArrow = 54,
            IronJaws = 56,
            Sidewinder = 60,
            BiteUpgrade = 64,
            RefulgentArrow = 70,
            Shadowbite = 72,
            BurstShot = 76,
            ApexArrow = 80,
            Ladonsbite = 82,
            BlastShot = 86,
            RadiantFinale = 90;
    }
}

internal class BardWanderersMinuet : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BardWanderersPitchPerfectFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.LegGraze)
        {
            var gauge = GetJobGauge<BRDGauge>();

            if (level >= BRD.Levels.PitchPerfect && gauge.Song == Song.WANDERER)
                return BRD.PitchPerfect;
            return BRD.WanderersMinuet;
        }

        return actionID;
    }
}

internal class BardHeavyShot : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.HeavyShot || actionID == BRD.BurstShot)
        {
            if (IsEnabled(CustomComboPreset.BardApexFeature))
            {
                var gauge = GetJobGauge<BRDGauge>();

                if (level >= BRD.Levels.BlastShot && HasEffect(BRD.Buffs.BlastShotReady))
                    return BRD.BlastArrow;

                if (level >= BRD.Levels.ApexArrow && gauge.SoulVoice == 100)
                    return BRD.ApexArrow;
            }

            if (IsEnabled(CustomComboPreset.BardStraightShotUpgradeFeature))
            {
                if (level >= BRD.Levels.StraightShot && HasEffect(BRD.Buffs.StraightShotReady))
                    // Refulgent Arrow
                    return OriginalHook(BRD.StraightShot);
            }
        }

        return actionID;
    }
}

internal class BardIronJaws : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.IronJaws)
        {
            if (IsEnabled(CustomComboPreset.BardPreIronJawsFeature))
            {
                if (level < BRD.Levels.Windbite)
                    return BRD.VenomousBite;

                if (level < BRD.Levels.IronJaws)
                {
                    var venomous = FindTargetEffect(BRD.Debuffs.VenomousBite);
                    var windbite = FindTargetEffect(BRD.Debuffs.Windbite);

                    if (venomous is null)
                        return BRD.VenomousBite;

                    if (windbite is null)
                        return BRD.Windbite;

                    if (venomous?.RemainingTime < windbite?.RemainingTime)
                        return BRD.VenomousBite;

                    return BRD.Windbite;
                }
            }

            if (IsEnabled(CustomComboPreset.BardIronJawsFeature))
            {
                if (level < BRD.Levels.BiteUpgrade)
                {
                    var venomous = TargetHasEffect(BRD.Debuffs.VenomousBite);
                    var windbite = TargetHasEffect(BRD.Debuffs.Windbite);

                    if (venomous && windbite)
                        return BRD.IronJaws;

                    if (windbite)
                        return BRD.VenomousBite;

                    return BRD.Windbite;
                }

                var caustic = TargetHasEffect(BRD.Debuffs.CausticBite);
                var stormbite = TargetHasEffect(BRD.Debuffs.Stormbite);

                if (caustic && stormbite)
                    return BRD.IronJaws;

                if (stormbite)
                    return BRD.CausticBite;

                return BRD.Stormbite;
            }
        }

        return actionID;
    }
}

internal class BardQuickNock : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.QuickNock || actionID == BRD.Ladonsbite)
        {
            if (IsEnabled(CustomComboPreset.BardApexFeature))
            {
                var gauge = GetJobGauge<BRDGauge>();

                if (level >= BRD.Levels.ApexArrow && gauge.SoulVoice == 100)
                    return BRD.ApexArrow;

                if (level >= BRD.Levels.BlastShot && HasEffect(BRD.Buffs.BlastShotReady))
                    return BRD.BlastArrow;
            }

            if (IsEnabled(CustomComboPreset.BardShadowbiteFeature))
            {
                if (level >= BRD.Levels.Shadowbite && HasEffect(BRD.Buffs.ShadowbiteReady))
                    return BRD.Shadowbite;
            }
        }

        return actionID;
    }
}

internal class BardBloodletter : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.Bloodletter)
        {
            if (IsEnabled(CustomComboPreset.BardBloodletterFeature))
            {
                if (level >= BRD.Levels.Sidewinder)
                    return CalcBestAction(actionID, BRD.Bloodletter, BRD.EmpyrealArrow, BRD.Sidewinder);

                if (level >= BRD.Levels.EmpyrealArrow)
                    return CalcBestAction(actionID, BRD.Bloodletter, BRD.EmpyrealArrow);

                if (level >= BRD.Levels.Bloodletter)
                    return BRD.Bloodletter;
            }

            if (IsEnabled(CustomComboPreset.BardBloodRainFeature))
            {
                if (level >= BRD.Levels.RainOfDeath
                    && !TargetHasEffect(BRD.Debuffs.CausticBite)
                    && !TargetHasEffect(BRD.Debuffs.Stormbite)
                    && !TargetHasEffect(BRD.Debuffs.Windbite)
                    && !TargetHasEffect(BRD.Debuffs.VenomousBite))
                {
                    return BRD.RainOfDeath;
                }
            }
        }

        return actionID;
    }
}

internal class BardRainOfDeath : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BardRainOfDeathFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.RainOfDeath)
        {
            if (level >= BRD.Levels.Sidewinder)
                return CalcBestAction(actionID, BRD.RainOfDeath, BRD.EmpyrealArrow, BRD.Sidewinder);

            if (level >= BRD.Levels.EmpyrealArrow)
                return CalcBestAction(actionID, BRD.RainOfDeath, BRD.EmpyrealArrow);

            if (level >= BRD.Levels.RainOfDeath)
                return BRD.RainOfDeath;
        }

        return actionID;
    }
}

internal class BardSidewinder : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BardSidewinderFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.Sidewinder)
        {
            if (level >= BRD.Levels.Sidewinder)
                return CalcBestAction(actionID, BRD.EmpyrealArrow, BRD.Sidewinder);
        }

        return actionID;
    }
}

internal class BardBarrage : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BardBarrageFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.Barrage)
        {
            if (level >= BRD.Levels.StraightShot && HasEffect(BRD.Buffs.StraightShotReady) && !HasEffect(BRD.Buffs.ShadowbiteReady))
                // Refulgent Arrow
                return OriginalHook(BRD.StraightShot);
        }

        return actionID;
    }
}

internal class BardRadiantFinale : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.RadiantFinale)
        {
            if (IsEnabled(CustomComboPreset.BardRadiantStrikesFeature))
            {
                if (level >= BRD.Levels.RagingStrikes && IsOffCooldown(BRD.RagingStrikes))
                    return BRD.RagingStrikes;
            }

            if (IsEnabled(CustomComboPreset.BardRadiantVoiceFeature))
            {
                if (level >= BRD.Levels.BattleVoice && IsOffCooldown(BRD.BattleVoice))
                    return BRD.BattleVoice;
            }

            if (IsEnabled(CustomComboPreset.BardRadiantStrikesFeature))
            {
                if (level < BRD.Levels.RadiantFinale)
                    return BRD.RagingStrikes;
            }

            if (IsEnabled(CustomComboPreset.BardRadiantVoiceFeature))
            {
                if (level < BRD.Levels.RadiantFinale)
                    return BRD.BattleVoice;
            }
        }

        return actionID;
    }
}
