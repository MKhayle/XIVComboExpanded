using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

internal static class SCH
{
    public const byte ClassID = 15;
    public const byte JobID = 28;

    public const uint
        Aetherflow = 166,
        EnergyDrain = 167,
        Resurrection = 173,
        Ruin = 17869,
        Broil = 3584,
        Broil2 = 7435,
        Broil3 = 16541,
        Broil4 = 25865,
        Bio = 17864,
        Adloquium = 185,
        SacredSoil = 188,
        Lustrate = 189,
        Physick = 190,
        Indomitability = 3583,
        DeploymentTactics = 3585,
        EmergencyTactics = 3586,
        Dissipation = 3587,
        Excogitation = 7434,
        ChainStratagem = 7436,
        Aetherpact = 7437,
        WhisperingDawn = 16537,
        FeyIllumination = 16538,
        Recitation = 16542,
        FeyBless = 16543,
        SummonSeraph = 16545,
        Consolation = 16546,
        SummonEos = 17215,
        SummonSelene = 17216,
        Ruin2 = 17870,
        Seraphism = 37014;

    public static class Buffs
    {
        public const ushort
            Dissipation = 791,
            Recitation = 1896,
            Seraphism = 3884,
            SeraphismAura = 3885;
    }

    public static class Debuffs
    {
        public const ushort
            Bio = 179,
            Bio2 = 189,
            Biolysis = 1895;
    }

    public static class Levels
    {
        public const byte
            Resurrection = 12,
            Adloquium = 30,
            Aetherflow = 45,
            Lustrate = 45,
            Excogitation = 62,
            ChainStratagem = 66,
            Recitation = 74,
            Consolation = 80,
            SummonSeraph = 80;
    }
}

internal class ScholarFeyBless : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ScholarSeraphConsolationFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SCH.FeyBless)
        {
            var gauge = GetJobGauge<SCHGauge>();

            if (level >= SCH.Levels.Consolation && gauge.SeraphTimer > 0)
                return SCH.Consolation;
        }

        return actionID;
    }
}

internal class ScholarExcogitation : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SchAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SCH.Excogitation)
        {
            if (IsEnabled(CustomComboPreset.ScholarExcogitationRecitationFeature))
            {
                if (level >= SCH.Levels.Recitation && IsCooldownUsable(SCH.Recitation))
                    return SCH.Recitation;
            }

            if (IsEnabled(CustomComboPreset.ScholarExcogitationLustrateFeature))
            {
                if (level < SCH.Levels.Excogitation || !IsCooldownUsable(SCH.Excogitation))
                    return SCH.Lustrate;
            }
        }

        return actionID;
    }
}

internal class ScholarEnergyDrain : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ScholarEnergyDrainAetherflowFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SCH.EnergyDrain)
        {
            var gauge = GetJobGauge<SCHGauge>();

            if (level >= SCH.Levels.Aetherflow && gauge.Aetherflow == 0)
                return SCH.Aetherflow;
        }

        return actionID;
    }
}

internal class ScholarLustrate : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SchAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SCH.Lustrate)
        {
            var gauge = GetJobGauge<SCHGauge>();

            if (IsEnabled(CustomComboPreset.ScholarLustrateRecitationFeature))
            {
                if (level >= SCH.Levels.Recitation && IsCooldownUsable(SCH.Recitation))
                    return SCH.Recitation;
            }

            if (IsEnabled(CustomComboPreset.ScholarLustrateExcogitationFeature))
            {
                if (level >= SCH.Levels.Excogitation && IsCooldownUsable(SCH.Excogitation))
                    return SCH.Excogitation;
            }

            if (IsEnabled(CustomComboPreset.ScholarLustrateAetherflowFeature))
            {
                if (level >= SCH.Levels.Aetherflow && gauge.Aetherflow == 0)
                    return SCH.Aetherflow;
            }
        }

        return actionID;
    }
}

internal class ScholarIndomitability : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ScholarIndomAetherflowFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SCH.Indomitability)
        {
            var gauge = GetJobGauge<SCHGauge>();

            if (level >= SCH.Levels.Aetherflow && gauge.Aetherflow == 0 && !HasEffect(SCH.Buffs.Recitation))
                return SCH.Aetherflow;
        }

        return actionID;
    }
}

internal class ScholarSacredSoil : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ScholarSacredSoilAetherflowFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SCH.SacredSoil)
        {
            var gauge = GetJobGauge<SCHGauge>();

            if (level >= SCH.Levels.Aetherflow && gauge.Aetherflow == 0)
                return SCH.Aetherflow;
        }

        return actionID;
    }
}

internal class ScholarSummon : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ScholarSeraphFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SCH.SummonEos || actionID == SCH.SummonSelene)
        {
            var gauge = GetJobGauge<SCHGauge>();

            if (gauge.SeraphTimer != 0 || HasPetPresent())
                // Consolation
                return OriginalHook(SCH.SummonSeraph);
        }

        return actionID;
    }
}

internal class ScholarSeraphism : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ScholarSeraphismFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SCH.Seraphism)
        {
            if (HasEffect(SCH.Buffs.Seraphism))
                return OriginalHook(SCH.EmergencyTactics);
        }

        return actionID;
    }
}

internal class ScholarAdloquium : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ScholarAdloquiumSyncFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SCH.Adloquium)
        {
            if (level < SCH.Levels.Adloquium)
                return SCH.Physick;
        }

        return actionID;
    }
}

internal class ScholarRuin : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SchAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SCH.Ruin || actionID == SCH.Broil || actionID == SCH.Broil2 || actionID == SCH.Broil3 || actionID == SCH.Broil4)
        {
            if (IsEnabled(CustomComboPreset.ScholarDoTFeature) && InCombat() && TargetIsEnemy())
            {
                var bio = FindTargetEffect(SCH.Debuffs.Bio);
                var bio2 = FindTargetEffect(SCH.Debuffs.Bio2);
                var biolysis = FindTargetEffect(SCH.Debuffs.Biolysis);

                // have to explicitly check all variants of the dot for some reason else spaghetti code ensues
                if (!(bio?.RemainingTime > 2.8 || bio2?.RemainingTime > 2.8 || biolysis?.RemainingTime > 2.8))
                    return OriginalHook(SCH.Bio);
            }
        }

        return actionID;
    }
}