using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

internal static class BLM
{
    public const byte ClassID = 7;
    public const byte JobID = 25;

    public const uint
        Fire = 141,
        Blizzard = 142,
        Thunder = 144,
        Fire2 = 147,
        Transpose = 149,
        Fire3 = 152,
        Thunder3 = 153,
        Blizzard3 = 154,
        Scathe = 156,
        Freeze = 159,
        Flare = 162,
        LeyLines = 3573,
        Sharpcast = 3574,
        Triplecast = 7421,
        Blizzard4 = 3576,
        Fire4 = 3577,
        BetweenTheLines = 7419,
        Thunder4 = 7420,
        Despair = 16505,
        UmbralSoul = 16506,
        Xenoglossy = 16507,
        Blizzard2 = 25793,
        HighFire2 = 25794,
        HighBlizzard2 = 25795,
        Paradox = 25797,
        Retrace = 36988,
        FlareStar = 36989;

    public static class Buffs
    {
        public const ushort
            Thundercloud = 164,
            Firestarter = 165,
            Swiftcast = 167,
            LeyLines = 737,
            Sharpcast = 867,
            Triplecast = 1211,
            EnhancedFlare = 2960;
    }

    public static class Debuffs
    {
        public const ushort
            Thunder = 161,
            Thunder3 = 163;
    }

    public static class Levels
    {
        public const byte
            Fire3 = 35,
            Blizzard3 = 35,
            Freeze = 40,
            Thunder3 = 45,
            Flare = 50,
            Sharpcast = 54,
            Blizzard4 = 58,
            Fire4 = 60,
            BetweenTheLines = 62,
            Despair = 72,
            UmbralSoul = 35,
            Xenoglossy = 80,
            HighFire2 = 82,
            HighBlizzard2 = 82,
            EnhancedSharpcast2 = 88,
            Paradox = 90,
            Retrace = 96,
            FlareStar = 100;
    }

    public static class MpCosts
    {
        public const ushort
            Fire2 = 3000,
            Flare = 800;
    }
}

internal class BlackFireBlizzard4 : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BLM.Blizzard4)
        {
            var gauge = GetJobGauge<BLMGauge>();

            if (IsEnabled(CustomComboPreset.BlackSpellsUmbralSoulFeature))
            {
                if (level >= BLM.Levels.UmbralSoul && gauge.InUmbralIce && !TargetIsEnemy())
                    return BLM.UmbralSoul;
            }
        }

        if (actionID == BLM.Fire4 || actionID == BLM.Blizzard4)
        {
            var gauge = GetJobGauge<BLMGauge>();
            var fire4 = GetCooldown(BLM.Fire4);

            if (IsEnabled(CustomComboPreset.BlackEnochianFeature))
            {
                if (IsEnabled(CustomComboPreset.BlackFlareStarFeature))
                {
                    if (level >= BLM.Levels.FlareStar)
                    {
                        if (gauge.AstralSoulStacks >= 6)
                            return BLM.FlareStar;
                    }
                }

                if (gauge.InAstralFire)
                {
                ///// temporary 7.2 graveyard
                //    if (IsEnabled(CustomComboPreset.BlackEnochianTimerFeature)) // 10% safety net to account for server tick shenanigans and despair cast time
                //        {
                //            if (((HasEffect(BLM.Buffs.Swiftcast) || HasEffect(BLM.Buffs.Triplecast))
                //            && gauge.ElementTimeRemaining / 1000.0 < fire4.BaseCooldown * 1.10) || gauge.ElementTimeRemaining / 1000.0 < fire4.CastTime * 1.10)
                //            {
                //                if (level >= BLM.Levels.Despair && LocalPlayer?.CurrentMp >= 800 && LocalPlayer?.CurrentMp < 2400) // optimal despair usage
                //                    return BLM.Despair;
                //                if (HasEffect(BLM.Buffs.Firestarter)) // rare case usually caused by rotation error or clipping
                //                    return BLM.Fire3;
                //                if (level >= BLM.Levels.Paradox && gauge.IsParadoxActive) // typical use case
                //                    return BLM.Paradox;
                //                if (level >= BLM.Levels.Despair && LocalPlayer?.CurrentMp >= 800) // suboptimal despair usage, but still better than Blizzard3
                //                    return BLM.Despair;
                //                if (level >= BLM.Levels.Blizzard3) // ultra-rare corner case when user royally screws up
                //                    return BLM.Blizzard3;
                //            }
                //        }

                    if (IsEnabled(CustomComboPreset.BlackEnochianDespairFeature))
                    {
                        if (IsEnabled(CustomComboPreset.BlackEnochianDespairFlareStarFeature))
                        {
                            // 2nd and 3rd checks for opener and post-manafont usage
                            if (level >= BLM.Levels.FlareStar && gauge.AstralSoulStacks >= 6 &&
                                (LocalPlayer?.CurrentMp <= 0 || LocalPlayer?.CurrentMp == 8400 ||
                                LocalPlayer?.CurrentMp == 10000))
                                return BLM.FlareStar;
                        }

                        if (level >= BLM.Levels.Despair && LocalPlayer?.CurrentMp < 2400)
                            return BLM.Despair;
                    }

                    if (IsEnabled(CustomComboPreset.BlackEnochianNoSyncFeature) || level >= BLM.Levels.Fire4)
                        return BLM.Fire4;

                    return BLM.Fire;
                }

                if (gauge.InUmbralIce)
                {
                    if (IsEnabled(CustomComboPreset.BlackEnochianUmbralIceFeature) && gauge.UmbralIceStacks < 3)
                    {
                        if (level >= BLM.Levels.Blizzard3 && (HasEffect(BLM.Buffs.Swiftcast) || HasEffect(BLM.Buffs.Triplecast)))
                            return BLM.Blizzard3;
                        return OriginalHook(BLM.Blizzard);
                    }

                    if (IsEnabled(CustomComboPreset.BlackEnochianNoSyncFeature) || level >= BLM.Levels.Blizzard4)
                        return BLM.Blizzard4;
                    return BLM.Blizzard;
                }
            }
        }

        return actionID;
    }
}

internal class BlackTranspose : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlackTransposeUmbralSoulFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BLM.Transpose)
        {
            var gauge = GetJobGauge<BLMGauge>();
            if (level >= BLM.Levels.UmbralSoul && gauge.InUmbralIce)
                return BLM.UmbralSoul;
        }

        return actionID;
    }
}

internal class BlackUmbralSoul : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlackUmbralSoulTransposeFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BLM.UmbralSoul)
        {
            var gauge = GetJobGauge<BLMGauge>();

            if (level < BLM.Levels.UmbralSoul || !gauge.InUmbralIce)
                return BLM.Transpose;
        }

        return actionID;
    }
}

internal class BlackLeyLines : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlackLeyLinesFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BLM.LeyLines)
        {
            if (level >= BLM.Levels.BetweenTheLines && HasEffect(BLM.Buffs.LeyLines) &&
                (level < BLM.Levels.Retrace || !IsCooldownUsable(BLM.Retrace) ||
                !IsEnabled(CustomComboPreset.BlackLeyLinesRetraceFeature)))
                return BLM.BetweenTheLines;
        }

        return actionID;
    }
}

internal class BlackFire : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlackFireFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BLM.Fire)
        {
            var gauge = GetJobGauge<BLMGauge>();

            if (level >= BLM.Levels.Paradox && gauge.IsParadoxActive && gauge.InUmbralIce)
                return BLM.Paradox;

            if (level >= BLM.Levels.Fire3)
            {
                if (IsEnabled(CustomComboPreset.BlackFireOption))
                {
                    if (gauge.AstralFireStacks < 3)
                        return BLM.Fire3;
                }

                if (!IsEnabled(CustomComboPreset.BlackFireOption2))
                {
                    if (!gauge.InAstralFire)
                        return BLM.Fire3;
                }

                if (HasEffect(BLM.Buffs.Firestarter))
                    return BLM.Fire3;
            }
        }

        return actionID;
    }
}

internal class BlackBlizzard : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BLM.Blizzard || actionID == BLM.Blizzard3)
        {
            var gauge = GetJobGauge<BLMGauge>();

            if (IsEnabled(CustomComboPreset.BlackSpellsUmbralSoulFeature))
            {
                if (level >= BLM.Levels.UmbralSoul && gauge.InUmbralIce && !TargetIsEnemy())
                    return BLM.UmbralSoul;
            }

            if (IsEnabled(CustomComboPreset.BlackBlizzardFeature))
            {
                if (level >= BLM.Levels.Paradox && gauge.IsParadoxActive)
                {
                    if (gauge.InUmbralIce || LocalPlayer?.CurrentMp >= 1600)
                    return BLM.Paradox;
                }

                if (level >= BLM.Levels.Blizzard3)
                    return BLM.Blizzard3;

                return BLM.Blizzard;
            }
        }

        return actionID;
    }
}

internal class BlackFreezeFlare : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BLM.Freeze)
        {
            var gauge = GetJobGauge<BLMGauge>();

            if (IsEnabled(CustomComboPreset.BlackSpellsUmbralSoulFeature))
            {
                if (level >= BLM.Levels.UmbralSoul && gauge.InUmbralIce && !TargetIsEnemy())
                    return BLM.UmbralSoul;
            }
        }

        if (actionID == BLM.Freeze || actionID == BLM.Flare)
        {
            var gauge = GetJobGauge<BLMGauge>();

            if (IsEnabled(CustomComboPreset.BlackFreezeFlareFeature))
            {
                if (level >= BLM.Levels.Freeze && gauge.InUmbralIce)
                    return BLM.Freeze;

                if (level >= BLM.Levels.Flare && gauge.InAstralFire)
                    return BLM.Flare;
            }
        }

        return actionID;
    }
}

internal class BlackFire2 : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlackFire2Feature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BLM.Fire2 || actionID == BLM.HighFire2)
        {
            var gauge = GetJobGauge<BLMGauge>();

            if (IsEnabled(CustomComboPreset.BlackFireBlizzard2Option))
            {
                if (gauge.AstralFireStacks < 3)
                    return actionID;
            }

            if (level >= BLM.Levels.Flare && gauge.InAstralFire)
            {
                // Level 100 uses a simplified rotation that just uses Flare twice and then Flare Star.
                if (level >= BLM.Levels.FlareStar)
                {
                    if (gauge.AstralSoulStacks >= 6)
                        return BLM.FlareStar;

                    return BLM.Flare;
                }

                // At level 50, Fire II is used until under 3800 mana (the combined cost of Fire II and Flare),
                // and then Flare is cast once.
                // At level 58, Fire II is used until 1 Umbral Heart is remaining, and then Flare is cast twice.
                if (LocalPlayer?.CurrentMp < BLM.MpCosts.Fire2 + BLM.MpCosts.Flare || gauge.UmbralHearts == 1)
                    return BLM.Flare;
            }
        }

        return actionID;
    }
}

internal class BlackBlizzard2 : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BLM.Blizzard2 || actionID == BLM.HighBlizzard2)
        {
            var gauge = GetJobGauge<BLMGauge>();

            if (IsEnabled(CustomComboPreset.BlackSpellsUmbralSoulFeature))
            {
                if (level >= BLM.Levels.UmbralSoul && gauge.InUmbralIce && !TargetIsEnemy())
                    return BLM.UmbralSoul;
            }

            if (IsEnabled(CustomComboPreset.BlackBlizzard2Feature))
            {
                if (IsEnabled(CustomComboPreset.BlackFireBlizzard2Option))
                {
                    if (gauge.UmbralIceStacks < 3)
                        return actionID;
                }

                if (level >= BLM.Levels.Freeze && gauge.InUmbralIce)
                    return BLM.Freeze;
            }
        }

        return actionID;
    }
}

internal class BlackScathe : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BlackScatheFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BLM.Scathe)
        {
            var gauge = GetJobGauge<BLMGauge>();

            if (level >= BLM.Levels.Xenoglossy && gauge.PolyglotStacks > 0)
                return BLM.Xenoglossy;
        }

        return actionID;
    }
}
