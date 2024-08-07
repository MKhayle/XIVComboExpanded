using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

internal static class SGE
{
    public const byte JobID = 40;

    public const uint
        Dosis = 24283,
        Dosis2 = 24306,
        Dosis3 = 24312,
        Diagnosis = 24284,
        Kardia = 24285,
        Prognosis = 24286,
        Egeiro = 24287,
        Physis = 24288,
        Phlegma = 24289,
        Eukrasia = 24290,
        Soteria = 24294,
        Druochole = 24296,
        Dyskrasia = 24297,
        Kerachole = 24298,
        Ixochole = 24299,
        Zoe = 24300,
        Pepsis = 24301,
        Physis2 = 24302,
        Taurochole = 24303,
        Toxikon = 24304,
        Haima = 24305,
        Phlegma2 = 24307,
        Rhizomata = 24309,
        Holos = 24310,
        Panhaima = 24311,
        Phlegma3 = 24313,
        Krasis = 24317,
        Pneuma = 24318,
        Psyche = 37033;

    public static class Buffs
    {
        public const ushort
            Kardion = 2604,
            Eukrasia = 2606;
    }

    public static class Debuffs
    {
        public const ushort
            EukrasianDosis = 2614,
            EukrasianDosis2 = 2615,
            EukrasianDosis3 = 2616;

    }

    public static class Levels
    {
        public const ushort
            Dosis = 1,
            Prognosis = 10,
            Egeiro = 12,
            Phlegma = 26,
            Soteria = 35,
            Druochole = 45,
            Dyskrasia = 46,
            Kerachole = 50,
            Ixochole = 52,
            Physis2 = 60,
            Taurochole = 62,
            Toxicon = 66,
            Haima = 70,
            Phlegma2 = 72,
            Dosis2 = 72,
            Rhizomata = 74,
            Holos = 76,
            Panhaima = 80,
            Phlegma3 = 82,
            Dosis3 = 82,
            Krasis = 86,
            Pneuma = 90,
            Psyche = 92;
    }
}

internal class SageDosis : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Dosis || actionID == SGE.Dosis2 || actionID == SGE.Dosis3)
        {
            if (IsEnabled(CustomComboPreset.SageDosisPsyche))
            {
                if (level >= SGE.Levels.Psyche && IsCooldownUsable(SGE.Psyche) && InCombat() && TargetIsEnemy())
                    return OriginalHook(SGE.Psyche);
            }
            if (IsEnabled(CustomComboPreset.SageDoTFeature) && InCombat() && TargetIsEnemy())
            {
                var eurkasiandosis = FindTargetEffect(SGE.Debuffs.EukrasianDosis);
                var eurkasiandosis2 = FindTargetEffect(SGE.Debuffs.EukrasianDosis2);
                var eurkasiandosis3 = FindTargetEffect(SGE.Debuffs.EukrasianDosis3);

                if (HasEffect(SGE.Buffs.Eukrasia))
                    return OriginalHook(SGE.Dosis);

                // have to explicitly check all variants of the dot for some reason else spaghetti code ensues
                if (!(eurkasiandosis?.RemainingTime > 2.8 || eurkasiandosis2?.RemainingTime > 2.8 || eurkasiandosis3?.RemainingTime > 2.8))
                    return SGE.Eukrasia;
            }

            if (IsEnabled(CustomComboPreset.SageDosisKardiaFeature))
            {
                if (!HasEffect(SGE.Buffs.Kardion))
                    return SGE.Kardia;
            }
        }

        return actionID;
    }
}

internal class SageToxikon : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Toxikon)
        {

            if (IsEnabled(CustomComboPreset.SagePsycheToxikonFeature))
            {
                if (level >= SGE.Levels.Psyche && IsCooldownUsable(SGE.Psyche))
                    return OriginalHook(SGE.Psyche);

            }

            if (IsEnabled(CustomComboPreset.SageToxikonPhlegma))
            {
                var phlegma =
                    level >= SGE.Levels.Phlegma3 ? SGE.Phlegma3 :
                    level >= SGE.Levels.Phlegma2 ? SGE.Phlegma2 :
                    level >= SGE.Levels.Phlegma ? SGE.Phlegma : 0;

                if (phlegma != 0 && IsCooldownUsable(phlegma))
                    return OriginalHook(SGE.Phlegma);
            }

        }

        return actionID;
    }
}

internal class SageSoteria : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SageSoteriaKardionFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Soteria)
        {
            if (IsEnabled(CustomComboPreset.SageSoteriaKardionFeature))
            {
                if (!HasEffect(SGE.Buffs.Kardion) && IsCooldownUsable(SGE.Soteria))
                    return SGE.Kardia;
            }
        }

        return actionID;
    }
}

internal class SageTaurochole : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Taurochole)
        {
            var gauge = GetJobGauge<SGEGauge>();

            if (IsEnabled(CustomComboPreset.SageTaurocholeRhizomataFeature))
            {
                if (level >= SGE.Levels.Rhizomata && gauge.Addersgall == 0)
                    return SGE.Rhizomata;
            }

            if (IsEnabled(CustomComboPreset.SageTaurocholeDruocholeFeature))
            {
                if (level >= SGE.Levels.Taurochole && IsCooldownUsable(SGE.Taurochole))
                    return SGE.Taurochole;

                return SGE.Druochole;
            }
        }

        return actionID;
    }
}

internal class SageDruochole : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Druochole)
        {
            var gauge = GetJobGauge<SGEGauge>();

            if (IsEnabled(CustomComboPreset.SageDruocholeRhizomataFeature))
            {
                if (level >= SGE.Levels.Rhizomata && gauge.Addersgall == 0)
                    return SGE.Rhizomata;
            }

            if (IsEnabled(CustomComboPreset.SageDruocholeTaurocholeFeature))
            {
                if (level >= SGE.Levels.Taurochole && IsCooldownUsable(SGE.Taurochole))
                    return SGE.Taurochole;
            }
        }

        return actionID;
    }
}

internal class SageIxochole : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SageIxocholeRhizomataFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Ixochole)
        {
            var gauge = GetJobGauge<SGEGauge>();

            if (IsEnabled(CustomComboPreset.SageIxocholeRhizomataFeature))
            {
                if (level >= SGE.Levels.Rhizomata && gauge.Addersgall == 0)
                    return SGE.Rhizomata;
            }
        }

        return actionID;
    }
}

internal class SageKerachole : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SageKeracholaRhizomataFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Kerachole)
        {
            var gauge = GetJobGauge<SGEGauge>();

            if (IsEnabled(CustomComboPreset.SageKeracholaRhizomataFeature))
            {
                if (level >= SGE.Levels.Rhizomata && gauge.Addersgall == 0)
                    return SGE.Rhizomata;
            }
        }

        return actionID;
    }
}

internal class SagePhlegma : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Phlegma || actionID == SGE.Phlegma2 || actionID == SGE.Phlegma3)
        {
            var gauge = GetJobGauge<SGEGauge>();

            if (IsEnabled(CustomComboPreset.SagePhlegmaDyskrasia))
            {
                if (level >= SGE.Levels.Dyskrasia && HasNoTarget())
                    return OriginalHook(SGE.Dyskrasia);
            }

            if (IsEnabled(CustomComboPreset.SagePhlegmaToxicon))
            {
                var phlegma =
                    level >= SGE.Levels.Phlegma3 ? SGE.Phlegma3 :
                    level >= SGE.Levels.Phlegma2 ? SGE.Phlegma2 :
                    level >= SGE.Levels.Phlegma ? SGE.Phlegma : 0;

                if (level >= SGE.Levels.Toxicon && phlegma != 0 && !IsCooldownUsable(phlegma) && gauge.Addersting > 0)
                    return OriginalHook(SGE.Toxikon);
            }

            if (IsEnabled(CustomComboPreset.SagePhlegmaDyskrasia))
            {
                var phlegma =
                    level >= SGE.Levels.Phlegma3 ? SGE.Phlegma3 :
                    level >= SGE.Levels.Phlegma2 ? SGE.Phlegma2 :
                    level >= SGE.Levels.Phlegma ? SGE.Phlegma : 0;

                if (level >= SGE.Levels.Dyskrasia && phlegma != 0 && !IsCooldownUsable(phlegma))
                    return OriginalHook(SGE.Dyskrasia);
            }
        }

        return actionID;
    }
}
