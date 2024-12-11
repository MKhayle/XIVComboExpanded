using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

internal static class SMN
{
    public const byte ClassID = 26;
    public const byte JobID = 27;

    public const uint

        Ruin = 163,
        Ruin2 = 172,
        Ruin3 = 3579,
        Ruin4 = 7426,
        Fester = 181,
        Painflare = 3578,
        DreadwyrmTrance = 3581,
        Deathflare = 3582,
        SummonBahamut = 7427,
        EnkindleBahamut = 7429,
        Physick = 16230,
        EnergySyphon = 16510,
        Outburst = 16511,
        EnkindlePhoenix = 16516,
        EnergyDrain = 16508,
        SummonCarbuncle = 25798,
        RadiantAegis = 25799,
        Aethercharge = 25800,
        SearingLight = 25801,
        SummonRuby = 25802,
        SummonTopaz = 25803,
        SummonEmerald = 25804,
        SummonIfrit = 25805,
        SummonTitan = 25806,
        SummonGaruda = 25807,
        AstralFlow = 25822,
        TriDisaster = 25826,
        Rekindle = 25830,
        SummonPhoenix = 25831,
        CrimsonCyclone = 25835,
        MountainBuster = 25836,
        Slipstream = 25837,
        SummonIfrit2 = 25838,
        SummonTitan2 = 25839,
        SummonGaruda2 = 25840,
        CrimsonStrike = 25885,
        Gemshine = 25883,
        PreciousBrilliance = 25884,
        Necrosis = 36990,
        SearingFlash = 36991,
        SummonSolarBahamut = 36992,
        Sunflare = 36996,
        LuxSolaris = 36997,
        EnkindleSolarBahamut = 36998;

    public static class Buffs
    {
        public const ushort
            Aetherflow = 304,
            FurtherRuin = 2701,
            SearingLight = 2703,
            IfritsFavor = 2724,
            GarudasFavor = 2725,
            TitansFavor = 2853,
            RubysGlimmer = 3873,
            LuxSolarisReady = 3874,
            CrimsonStrikeReady = 4403;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            SummonCarbuncle = 2,
            RadiantAegis = 2,
            Gemshine = 6,
            EnergyDrain = 10,
            Fester = 10,
            PreciousBrilliance = 26,
            Painflare = 40,
            EnergySyphon = 52,
            Ruin3 = 54,
            Ruin4 = 62,
            SearingLight = 66,
            EnkindleBahamut = 70,
            Rekindle = 80,
            ElementalMastery = 86,
            SummonPhoenix = 80,
            Necrosis = 92,
            SummonSolarBahamut = 100,
            LuxSolaris = 100;
    }
}

internal class SummonerFester : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SummonerEDFesterFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SMN.Fester || actionID == SMN.Necrosis)
        {
            var gauge = GetJobGauge<SMNGauge>();

            if (level >= SMN.Levels.EnergyDrain && !gauge.HasAetherflowStacks)
                return SMN.EnergyDrain;
        }

        return actionID;
    }
}

internal class SummonerPainflare : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SummonerESPainflareFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SMN.Painflare)
        {
            var gauge = GetJobGauge<SMNGauge>();

            if (level >= SMN.Levels.EnergySyphon && !gauge.HasAetherflowStacks)
                return SMN.EnergySyphon;

            if (level >= SMN.Levels.EnergyDrain && !gauge.HasAetherflowStacks)
                return SMN.EnergyDrain;

            if (level < SMN.Levels.Painflare)
                return SMN.Fester;
        }

        return actionID;
    }
}

internal class SummonerRuin : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SmnAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SMN.Ruin || actionID == SMN.Ruin2 || actionID == SMN.Ruin3)
        {
            var gauge = GetJobGauge<SMNGauge>();

            if (IsEnabled(CustomComboPreset.SummonerRuinTitansFavorFeature))
            {
                if (level >= SMN.Levels.ElementalMastery && HasEffect(SMN.Buffs.TitansFavor))
                    return SMN.MountainBuster;
            }

            if (IsEnabled(CustomComboPreset.SummonerRuinFeature))
            {
                if (level >= SMN.Levels.Gemshine)
                {
                    if (gauge.Attunement > 0)
                        return OriginalHook(SMN.Gemshine);
                }
            }

            if (IsEnabled(CustomComboPreset.SummonerFurtherRuinFeature))
            {
                if (level >= SMN.Levels.Ruin4 && gauge.SummonTimerRemaining == 0 && gauge.AttunmentTimerRemaining == 0 && HasEffect(SMN.Buffs.FurtherRuin))
                    return SMN.Ruin4;
            }
        }

        return actionID;
    }
}

internal class SummonerOutburstTriDisaster : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SmnAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SMN.Outburst || actionID == SMN.TriDisaster)
        {
            var gauge = GetJobGauge<SMNGauge>();

            if (IsEnabled(CustomComboPreset.SummonerOutburstTitansFavorFeature))
            {
                if (level >= SMN.Levels.ElementalMastery && HasEffect(SMN.Buffs.TitansFavor))
                    return SMN.MountainBuster;
            }

            if (IsEnabled(CustomComboPreset.SummonerOutburstFeature))
            {
                if (level >= SMN.Levels.PreciousBrilliance)
                {
                    if (gauge.Attunement > 0)
                        return OriginalHook(SMN.PreciousBrilliance);
                }
            }

            if (IsEnabled(CustomComboPreset.SummonerFurtherOutburstFeature))
            {
                if (level >= SMN.Levels.Ruin4 && gauge.SummonTimerRemaining == 0 && gauge.AttunmentTimerRemaining == 0 && HasEffect(SMN.Buffs.FurtherRuin))
                    return SMN.Ruin4;
            }
        }

        return actionID;
    }
}

internal class SummonerGemshinePreciousBrilliance : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SmnAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SMN.Gemshine || actionID == SMN.PreciousBrilliance)
        {
            var gauge = GetJobGauge<SMNGauge>();

            if (IsEnabled(CustomComboPreset.SummonerShinyTitansFavorFeature))
            {
                if (level >= SMN.Levels.ElementalMastery && HasEffect(SMN.Buffs.TitansFavor))
                    return SMN.MountainBuster;
            }

            if (IsEnabled(CustomComboPreset.SummonerShinyEnkindleFeature))
            {
                if (level >= SMN.Levels.EnkindleBahamut && gauge.SummonTimerRemaining > 0 && gauge.AttunmentTimerRemaining == 0)
                    // Rekindle
                    return OriginalHook(SMN.EnkindleBahamut);
            }

            if (IsEnabled(CustomComboPreset.SummonerFurtherShinyFeature))
            {
                if (level >= SMN.Levels.Ruin4 && gauge.SummonTimerRemaining == 0 && gauge.AttunmentTimerRemaining == 0 && HasEffect(SMN.Buffs.FurtherRuin))
                    return SMN.Ruin4;
            }
        }

        return actionID;
    }
}

internal class SummonerDemiFeature : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SmnAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SMN.Aethercharge || actionID == SMN.DreadwyrmTrance || actionID == SMN.SummonBahamut)
        {
            if (IsEnabled(CustomComboPreset.SummonerDemiCarbuncleFeature) && !HasPetPresent())
                return SMN.SummonCarbuncle;

            var gauge = GetJobGauge<SMNGauge>();

            if (IsEnabled(CustomComboPreset.SummonerSearingDemiFlashFeature))
            {
                if (level >= SMN.Levels.SearingLight && !CanUseAction(SMN.SummonBahamut) && !CanUseAction(SMN.SummonPhoenix) && !CanUseAction(SMN.SummonSolarBahamut) && InCombat())
                    if (IsCooldownUsable(SMN.SearingLight))
                        return SMN.SearingLight;
                    else if (HasEffect(SMN.Buffs.RubysGlimmer))
                        return SMN.SearingFlash;
            }

            if (IsEnabled(CustomComboPreset.SummonerDemiSearingLightFeature))
            {
                if (level >= SMN.Levels.SearingLight && CanUseAction(SMN.SummonBahamut) && CanUseAction(SMN.SummonPhoenix) && CanUseAction(SMN.SummonSolarBahamut) && InCombat() && IsCooldownUsable(SMN.SearingLight))
                    return SMN.SearingLight;
            }

            if (IsEnabled(CustomComboPreset.SummonerDemiEnkindleFeature))
            {
                if (level >= SMN.Levels.EnkindleBahamut && gauge.Attunement == 0 && gauge.SummonTimerRemaining > 0)
                    // Rekindle
                    return OriginalHook(SMN.EnkindleBahamut);
            }
        }

        return actionID;
    }
}

internal class SummonerRadiantCarbuncleFeature : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SmnAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SMN.RadiantAegis)
        {
            if (IsEnabled(CustomComboPreset.SummonerRadiantLuxSolarisFeature))
            {
                if (HasEffect(SMN.Buffs.LuxSolarisReady))
                    return SMN.LuxSolaris;
            }

            var gauge = GetJobGauge<SMNGauge>();

            if (level >= SMN.Levels.SummonCarbuncle && !HasPetPresent() && IsEnabled(CustomComboPreset.SummonerRadiantCarbuncleFeature))
                return SMN.SummonCarbuncle;
        }

        return actionID;
    }
}

internal class SummonerLuxSolarisFeature : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SummonerSummonLuxSolarisFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SMN.SummonBahamut)
        {
            if (HasEffect(SMN.Buffs.LuxSolarisReady))
                return SMN.LuxSolaris;
        }

        return actionID;
    }
}

internal class SummonerPrimalSummons : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SummonerPrimalFavorFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SMN.SummonRuby || actionID == SMN.SummonIfrit || actionID == SMN.SummonIfrit2)
        {
            if (HasEffect(SMN.Buffs.IfritsFavor) || HasEffect(SMN.Buffs.CrimsonStrikeReady))
                return OriginalHook(SMN.AstralFlow);
        }

        if (actionID == SMN.SummonEmerald || actionID == SMN.SummonGaruda || actionID == SMN.SummonGaruda2)
        {
            if (HasEffect(SMN.Buffs.GarudasFavor))
                return OriginalHook(SMN.AstralFlow);
        }

        if (actionID == SMN.SummonTopaz || actionID == SMN.SummonTitan || actionID == SMN.SummonTitan2)
        {
            if (HasEffect(SMN.Buffs.TitansFavor))
                return OriginalHook(SMN.AstralFlow);
        }

        return actionID;
    }
}
