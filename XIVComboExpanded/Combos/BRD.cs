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
        MagesBallad = 114,
        ArmysPaeon = 116,
        RainOfDeath = 117,
        BattleVoice = 118,
        EmpyrealArrow = 3558,
        WanderersMinuet = 3559,
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
        RadiantFinale = 25785,
        WideVolley = 36974,
        HeartbreakShot = 36975,
        ResonantArrow = 36976,
        RadiantEncore = 36977;

    public static class Buffs
    {
        public const ushort
            StraightShotReady = 122,
            Barrage = 128,
            WanderersMinuet = 2009,
            BlastShotReady = 2692,
            ShadowbiteReady = 3002,
            HawksEye = 3861,
            ResonantArrowReady = 3862,
            RadiantEncoreReady = 3863;
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
            WideVolley = 25,
            MagesBallad = 30,
            Windbite = 30,
            Barrage = 38,
            ArmysPaeon = 40,
            RainOfDeath = 45,
            BattleVoice = 50,
            WanderersMinuet = 52,
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
            RadiantFinale = 90,
            HeartbreakShot = 92,
            ResonantArrow = 96,
            RadiantEncore = 100;
    }
}

internal class BardHeavyShot : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.HeavyShot || actionID == BRD.BurstShot)
        {
            if (IsEnabled(CustomComboPreset.BardShotIronJawsFeature))
            {
                if (level >= BRD.Levels.IronJaws)
                {
                    // Using 5 seconds instead of 2.8s like the other DoT auto-refresh features, because Bard loses a
                    // lot more from letting their DoTs drop, since they have to use two GCDs instead of one to
                    // re-apply them.
                    var dotTimer = 5.0;

                    if (IsEnabled(CustomComboPreset.BardShotIronJawsOption)) // option to use 2.8
                        dotTimer = 2.8;

                    // have to explicitly check all variants of the dot for some reason else spaghetti code ensues
                    var venomous = FindTargetEffect(BRD.Debuffs.VenomousBite);
                    var windbite = FindTargetEffect(BRD.Debuffs.Windbite);
                    var stormbite = FindTargetEffect(BRD.Debuffs.Stormbite);
                    var caustic = FindTargetEffect(BRD.Debuffs.CausticBite);

                    if (venomous?.RemainingTime < dotTimer || windbite?.RemainingTime < dotTimer ||
                    stormbite?.RemainingTime < dotTimer || caustic?.RemainingTime < dotTimer)
                        return BRD.IronJaws;
                }
            }

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
                if (level >= BRD.Levels.StraightShot && (HasEffect(BRD.Buffs.HawksEye) || HasEffect(BRD.Buffs.Barrage)))
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
				if (level < BRD.Levels.Windbite)
					return BRD.VenomousBite;

				if (level < BRD.Levels.BiteUpgrade)
                {
                    var venomous = TargetHasEffect(BRD.Debuffs.VenomousBite);
                    var windbite = TargetHasEffect(BRD.Debuffs.Windbite);

                    if (venomous && windbite && level >= BRD.Levels.IronJaws)
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

            if (IsEnabled(CustomComboPreset.BardShadowbiteFeature) && level >= BRD.Levels.WideVolley)
            {
                if (IsEnabled(CustomComboPreset.BardShadowbiteBarrageFeature))
                {
                    if (level >= BRD.Levels.Barrage && IsCooldownUsable(BRD.Barrage))
                        return BRD.Barrage;
                }

                if (HasEffect(BRD.Buffs.HawksEye) || HasEffect(BRD.Buffs.Barrage))
                    return OriginalHook(BRD.WideVolley);
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
        if (actionID is BRD.Bloodletter or BRD.HeartbreakShot)
        {
            var gauge = GetJobGauge<BRDGauge>();

            if (IsEnabled(CustomComboPreset.BardExpiringPerfectBloodletterFeature))
            {
                if (level >= BRD.Levels.PitchPerfect && gauge.Song == Song.Wanderer && gauge.Repertoire >= 1)
                {
                    if (gauge.SongTimer <= 2500)
                        return BRD.PitchPerfect;
                }
            }

            if (IsEnabled(CustomComboPreset.BardPerfectBloodletterFeature))
            {
                if (level >= BRD.Levels.PitchPerfect && gauge.Song == Song.Wanderer && gauge.Repertoire == 3)
                    return BRD.PitchPerfect;
            }

            if (IsEnabled(CustomComboPreset.BardBloodletterFeature))
            {
                if (level >= BRD.Levels.Sidewinder)
                    return CalcBestAction(actionID, OriginalHook(BRD.Bloodletter), BRD.EmpyrealArrow, BRD.Sidewinder);

                if (level >= BRD.Levels.EmpyrealArrow)
                    return CalcBestAction(actionID, OriginalHook(BRD.Bloodletter), BRD.EmpyrealArrow);

                if (level >= BRD.Levels.Bloodletter)
                    return OriginalHook(BRD.Bloodletter);
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
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.RainOfDeath)
        {
            var gauge = GetJobGauge<BRDGauge>();

            if (IsEnabled(CustomComboPreset.BardExpiringPerfectRainOfDeathFeature))
            {
                if (level >= BRD.Levels.PitchPerfect && gauge.Song == Song.Wanderer && gauge.Repertoire >= 1)
                {
                    if (gauge.SongTimer <= 2500)
                        return BRD.PitchPerfect;
                }
            }

            if (IsEnabled(CustomComboPreset.BardPerfectRainOfDeathFeature))
            {
                if (level >= BRD.Levels.PitchPerfect && gauge.Song == Song.Wanderer && gauge.Repertoire == 3)
                    return BRD.PitchPerfect;
            }

            if (IsEnabled(CustomComboPreset.BardRainOfDeathFeature))
            {
                if (level >= BRD.Levels.Sidewinder)
                    return CalcBestAction(actionID, BRD.RainOfDeath, BRD.EmpyrealArrow, BRD.Sidewinder);

                if (level >= BRD.Levels.EmpyrealArrow)
                    return CalcBestAction(actionID, BRD.RainOfDeath, BRD.EmpyrealArrow);

                if (level >= BRD.Levels.RainOfDeath)
                    return BRD.RainOfDeath;
            }
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

internal class BardApexArrow : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BardAutoIronJawsApexFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.ApexArrow || actionID == BRD.BlastArrow)
        {
            if (level >= BRD.Levels.IronJaws)
            {
                // Using 5 seconds instead of 2.8s like the other DoT auto-refresh features, because Bard loses a
                // lot more from letting their DoTs drop, since they have to use two GCDs instead of one to
                // re-apply them.
                var dotTimer = 5.0;

                if (IsEnabled(CustomComboPreset.BardShotIronJawsOption)) // option to use 2.8
                    dotTimer = 2.8;

                // have to explicitly check all variants of the dot for some reason else spaghetti code ensues
                var venomous = FindTargetEffect(BRD.Debuffs.VenomousBite);
                var windbite = FindTargetEffect(BRD.Debuffs.Windbite);
                var stormbite = FindTargetEffect(BRD.Debuffs.Stormbite);
                var caustic = FindTargetEffect(BRD.Debuffs.CausticBite);

                if (venomous?.RemainingTime < dotTimer || windbite?.RemainingTime < dotTimer ||
                stormbite?.RemainingTime < dotTimer || caustic?.RemainingTime < dotTimer)
                    return BRD.IronJaws;
            }
        }

        return actionID;
    }
}

internal class BardEmpyrealArrow : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BardEmpyrealArrowFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.EmpyrealArrow)
        {
            if (level >= BRD.Levels.Sidewinder)
                return CalcBestAction(actionID, BRD.EmpyrealArrow, BRD.Sidewinder);
        }

        return actionID;
    }
}

internal class BardRagingStrikes : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BardRagingBarrageFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.RagingStrikes)
        {
            if (level >= BRD.Levels.Barrage && IsCooldownUsable(BRD.Barrage) && !IsCooldownUsable(BRD.RagingStrikes))
                return OriginalHook(BRD.Barrage);
        }

        return actionID;
    }
}

internal class BardBattleVoice : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BardBattleFinaleFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.BattleVoice)
        {
            var finale = IsCooldownUsable(BRD.RadiantFinale);
            var voice = GetCooldown(BRD.BattleVoice);

            if (level >= BRD.Levels.RadiantFinale && ((GetCooldown(BRD.BattleVoice).CooldownRemaining > 30 &&
                IsCooldownUsable(BRD.RadiantFinale)) || HasEffect(BRD.Buffs.RadiantEncoreReady)))
                return OriginalHook(BRD.RadiantFinale);
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
                if (level >= BRD.Levels.RagingStrikes && IsCooldownUsable(BRD.RagingStrikes))
                    return BRD.RagingStrikes;
            }

            if (IsEnabled(CustomComboPreset.BardRadiantVoiceFeature))
            {
                if (level >= BRD.Levels.BattleVoice && IsCooldownUsable(BRD.BattleVoice))
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

internal class BardMagesBallad : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BardCyclingSongFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.MagesBallad)
        {
            const ushort remaining = 40000;
            var gauge = GetJobGauge<BRDGauge>();

            if (level >= BRD.Levels.WanderersMinuet)
            {
                if (gauge.Song == Song.Wanderer && gauge.SongTimer >= remaining)
                    return BRD.WanderersMinuet;

                if (IsCooldownUsable(BRD.WanderersMinuet))
                    return BRD.WanderersMinuet;
            }

            if (level >= BRD.Levels.MagesBallad)
            {
                if (gauge.Song == Song.Mage && gauge.SongTimer >= remaining)
                    return BRD.MagesBallad;

                if (IsCooldownUsable(BRD.MagesBallad))
                    return BRD.MagesBallad;
            }

            if (level >= BRD.Levels.ArmysPaeon)
            {
                if (gauge.Song == Song.Army && gauge.SongTimer >= remaining)
                    return BRD.ArmysPaeon;

                if (IsCooldownUsable(BRD.ArmysPaeon))
                    return BRD.ArmysPaeon;
            }

            // Show the next expected song while on cooldown
            if (level >= BRD.Levels.WanderersMinuet)
                return CalcBestAction(BRD.WanderersMinuet, BRD.WanderersMinuet, BRD.MagesBallad, BRD.ArmysPaeon);

            if (level >= BRD.Levels.ArmysPaeon)
                return CalcBestAction(BRD.MagesBallad, BRD.MagesBallad, BRD.ArmysPaeon);
        }

        return actionID;
    }
}
