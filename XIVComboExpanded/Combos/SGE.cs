using Dalamud.Game.ClientState.JobGauge.Types;
using System;

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
        EukrasianDiagnosis = 24291,
        EukrasianPrognosis = 24292,
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
        EukrasianDosis = 24314,
        Dyskrasia2 = 24315,
        Krasis = 24317,
        Pneuma = 24318,
        EukrasianDyskrasia = 37032,
        EukrasianPrognosis2 = 37034,
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

    public static class RaidBuffs
    {
        public static readonly ushort[] Player =
        [
            1878, // Divination
            141,  // Battle Voice
            2722, // Radiant Finale
            1822, // Technical Finish
            786,  // Battle Litany
            1185, // Brotherhood
            3685, // Starry Muse
            1239, // Embolden (self)
            1297, // Embolden (party members)
            2599, // Arcane Circle
            2703, // Searing Light
        ];

        public static readonly ushort[] Target =
        [
            3183, // Mug
            3849, // Dokumori
            1221, // Chain Stratagem
        ];
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
            Dyskrasia2 = 82,
            Toxikon2 = 82,
            Krasis = 86,
            Pneuma = 90,
            Psyche = 92,
            Philosophia = 100;
    }
}

internal class SageDosis : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Dosis || actionID == SGE.Dosis2 || actionID == SGE.Dosis3)
        {
            if (IsEnabled(CustomComboPreset.SageDosisPsyche))
            {
                if (level >= SGE.Levels.Psyche && IsCooldownUsable(SGE.Psyche) && TargetIsEnemy() && InCombat())
                    return OriginalHook(SGE.Psyche);
            }

            if (IsEnabled(CustomComboPreset.SageDosisPhlegmaBurst) && TargetIsEnemy() && InCombat())
            {
                var phlegma =
                    level >= SGE.Levels.Phlegma3 ? SGE.Phlegma3 :
                    level >= SGE.Levels.Phlegma2 ? SGE.Phlegma2 :
                    level >= SGE.Levels.Phlegma ? SGE.Phlegma : 0;

                var raidBuffActive = Array.Exists(SGE.RaidBuffs.Player, HasEffectAny) ||
                    Array.Exists(SGE.RaidBuffs.Target, TargetHasEffectAny);
                if (raidBuffActive)
                    Service.ComboCache.RaidBuffDetectedThisCombat = true;

                var combatElapsed = Service.ComboCache.CombatElapsed.TotalSeconds;
                var firstBurstFallback = !Service.ComboCache.RaidBuffDetectedThisCombat &&
                    combatElapsed >= 10 && combatElapsed <= 20;
                var burstPhaseActive = raidBuffActive || firstBurstFallback;
                Service.ComboCache.UpdateRaidBurst(burstPhaseActive);

                var nextBurstIn = Service.ComboCache.NextRaidBurstIn;
                var spendToAvoidOvercap = !burstPhaseActive &&
                    GetRemainingCharges(phlegma) >= 2 &&
                    (!nextBurstIn.HasValue || nextBurstIn.Value.TotalSeconds > 20);
                var inPhlegmaRange = CurrentTarget!.CurrentDistance <= 6;

                if (phlegma != 0 && IsCooldownUsable(phlegma) &&
                    inPhlegmaRange && (burstPhaseActive || spendToAvoidOvercap))
                    return OriginalHook(SGE.Phlegma);
            }

            if (IsEnabled(CustomComboPreset.SageDoTFeature) && TargetIsEnemy() && InCombat())
            {
                var eurkasiandosis = FindTargetEffect(SGE.Debuffs.EukrasianDosis);
                var eurkasiandosis2 = FindTargetEffect(SGE.Debuffs.EukrasianDosis2);
                var eurkasiandosis3 = FindTargetEffect(SGE.Debuffs.EukrasianDosis3);

                if (HasEffect(SGE.Buffs.Eukrasia))
                    return OriginalHook(SGE.Dosis);

                // have to explicitly check all variants of the dot for some reason else spaghetti code ensues
                if (!(eurkasiandosis?.RemainingTime > 2.8 || eurkasiandosis2?.RemainingTime > 2.8 ||
                    eurkasiandosis3?.RemainingTime > 2.8))
                    return SGE.Eukrasia;
            }

            if (IsEnabled(CustomComboPreset.SageDosisKardiaFeature))
            {
                if (!HasEffect(SGE.Buffs.Kardion))
                    return SGE.Kardia;
            }
        }

        if ((actionID == SGE.Dyskrasia || actionID == SGE.Dyskrasia2) &&
            IsEnabled(CustomComboPreset.SagePsycheDyskrasiaFeature))
        {
            if (level >= SGE.Levels.Psyche && IsCooldownUsable(SGE.Psyche) && TargetIsEnemy() && InCombat())
                return OriginalHook(SGE.Psyche);
        }

        return actionID;
    }
}

internal class SageToxikon : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
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

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
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

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
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

internal class SageEukrasia : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Eukrasia)
        {
            if(HasEffect(SGE.Buffs.Eukrasia))
            {
                if (IsEnabled(CustomComboPreset.SageEukrasianDosisFeature))
                {
                    return OriginalHook(SGE.Dosis);
                }

                if (IsEnabled(CustomComboPreset.SageEukrasianDiagnosisFeature))
                {
                    return OriginalHook(SGE.Diagnosis);
                }
                if (IsEnabled(CustomComboPreset.SageEukrasianPrognosisFeature))
                {
                    return OriginalHook(SGE.Prognosis);
                }

                if (IsEnabled(CustomComboPreset.SageEukrasianDyskrasiaFeature))
                {
                    if (level >= SGE.Levels.Dyskrasia)
                        return OriginalHook(SGE.Dyskrasia);
                }
            }

            
        }

        return actionID;
    }
}

internal class SageDruochole : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
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

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
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

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
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

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SGE.Phlegma || actionID == SGE.Phlegma2 || actionID == SGE.Phlegma3)
        {
            if (IsEnabled(CustomComboPreset.SagePhlegmaPsyche))
            {
                if (level >= SGE.Levels.Psyche && IsCooldownUsable(SGE.Psyche) && TargetIsEnemy() && InCombat())
                    return OriginalHook(SGE.Psyche);
            }

            if (IsEnabled(CustomComboPreset.SagePhlegmaDyskrasia))
            {
                if (level >= SGE.Levels.Dyskrasia && !TargetIsEnemy())
                    return OriginalHook(SGE.Dyskrasia);
            }

            if (IsEnabled(CustomComboPreset.SagePhlegmaToxikon))
            {
                var gauge = GetJobGauge<SGEGauge>();
                var phlegma =
                    level >= SGE.Levels.Phlegma3 ? SGE.Phlegma3 :
                    level >= SGE.Levels.Phlegma2 ? SGE.Phlegma2 :
                    level >= SGE.Levels.Phlegma ? SGE.Phlegma : 0;

                if (level >= SGE.Levels.Toxicon && phlegma != 0 && !IsCooldownUsable(phlegma) &&
                    gauge.Addersting > 0)
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
