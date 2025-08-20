using System;
using System.Linq;

using Dalamud.Game.ClientState.JobGauge.Types;
using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.UI;

namespace XIVComboExpandedPlugin.Combos;

internal static class DNC
{
    public const byte JobID = 38;

    public const uint
        // Single Target
        Cascade = 15989,
        Fountain = 15990,
        ReverseCascade = 15991,
        Fountainfall = 15992,
        // AoE
        Windmill = 15993,
        Bladeshower = 15994,
        RisingWindmill = 15995,
        Bloodshower = 15996,
        // Dancing
        StandardStep = 15997,
        StandardFinish = 16003,
        TechnicalStep = 15998,
        TechnicalFinish = 16004,
        Tillana = 25790,
        LastDance = 36983,
        FinishingMove = 36984,
        // Fans
        FanDance1 = 16007,
        FanDance2 = 16008,
        FanDance3 = 16009,
        FanDance4 = 25791,
        // Steps
        Emboite = 15999,
        Entrechat = 16000,
        Jete = 16001,
        Pirouette = 16002,

        // Other
        SaberDance = 16005,
        ClosedPosition = 16006,
        EnAvant = 16010,
        Devilment = 16011,
        Flourish = 16013,
        Improvisation = 16014,
        StarfallDance = 25792,
        DanceOfTheDawn = 36985;

    public static class Buffs
    {
        public const ushort
            ClosedPosition = 1823,
            FlourishingSymmetry = 3017,
            FlourishingFlow = 3018,
            FlourishingFinish = 2698,
            FlourishingStarfall = 2700,
            SilkenSymmetry = 2693,
            SilkenFlow = 2694,
            StandardStep = 1818,
            StandardFinish = 1821,
            TechnicalStep = 1819,
            TechnicalFinish = 1822,
            ThreefoldFanDance = 1820,
            FourfoldFanDance = 2699,
            LastDanceReady = 3867,
            FinishingMoveReady = 3868,
            DanceOfTheDawnReady = 3869;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            Cascade = 1,
            Fountain = 2,
            Windmill = 15,
            StandardStep = 15,
            ReverseCascade = 20,
            Bladeshower = 25,
            RisingWindmill = 35,
            Fountainfall = 40,
            Bloodshower = 45,
            ClosedPosition = 60,
            FanDance3 = 66,
            TechnicalStep = 70,
            Flourish = 72,
            SaberDance = 76,
            Tillana = 82,
            FanDance4 = 86,
            StarfallDance = 90,
            LastDance = 92,
            FinishingMove = 96,
            DanceOfTheDawn = 100;
    }
}

internal class DancerDanceComboCompatibility : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DancerDanceComboCompatibility;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        var actionIDs = Service.Configuration.DancerDanceCompatActionIDs;

        if (actionIDs.Contains(actionID))
        {
            var gauge = GetJobGauge<DNCGauge>();

            if (level >= DNC.Levels.StandardStep && gauge.IsDancing)
            {
                if (actionID == actionIDs[0] || (actionIDs[0] == 0 && actionID == DNC.Cascade))
                    return OriginalHook(DNC.Cascade);

                if (actionID == actionIDs[1] || (actionIDs[1] == 0 && actionID == DNC.Flourish))
                    return OriginalHook(DNC.Fountain);

                if (actionID == actionIDs[2] || (actionIDs[2] == 0 && actionID == DNC.FanDance1))
                    return OriginalHook(DNC.ReverseCascade);

                if (actionID == actionIDs[3] || (actionIDs[3] == 0 && actionID == DNC.FanDance2))
                    return OriginalHook(DNC.Fountainfall);
            }
        }

        return actionID;
    }
}

internal class DancerFanDance12 : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DncAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DNC.FanDance1 || actionID == DNC.FanDance2)
        {
            if (level < DNC.Levels.FanDance3)
                return actionID;

            if (IsEnabled(CustomComboPreset.DancerFanDance3Feature) && HasEffect(DNC.Buffs.ThreefoldFanDance))
                    return DNC.FanDance3;

            var gauge = GetJobGauge<DNCGauge>();

            if (level >= DNC.Levels.FanDance4 && IsEnabled(CustomComboPreset.DancerFanDance4Feature) &&
                HasEffect(DNC.Buffs.FourfoldFanDance) && (gauge.Feathers < 4 ||
                !IsEnabled(CustomComboPreset.DancerFanDance4MaxFeathers)))
                    return DNC.FanDance4;
        }

        return actionID;
    }
}

internal class DancerStandardStepTechnicalStep : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DncAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DNC.StandardStep)
        {
            var gauge = GetJobGauge<DNCGauge>();

            if (IsEnabled(CustomComboPreset.DancerDanceStepCombo) && level >= DNC.Levels.StandardStep && gauge.IsDancing)
            {
                if (gauge.CompletedSteps < 2 && HasEffect(DNC.Buffs.StandardStep))
                    return gauge.NextStep;

                if (gauge.CompletedSteps < 4 && HasEffect(DNC.Buffs.TechnicalStep) &&
                    IsEnabled(CustomComboPreset.DancerCombinedStandardStepTechnicalStep))
                    return gauge.NextStep;

                return OriginalHook(DNC.StandardStep);
            }

            if (IsEnabled(CustomComboPreset.DancerPartnerFeature) && level >= DNC.Levels.ClosedPosition && (!HasEffect(DNC.Buffs.ClosedPosition)))
            {
                if (IsEnabled(CustomComboPreset.DancerChocoboPartnerFeature) && HasCompanionPresent())
                {
                    return DNC.ClosedPosition;
                }

                if (IsInParty() && IsInInstance())
                    return DNC.ClosedPosition;
            }

            if (IsEnabled(CustomComboPreset.DancerLastDanceFeature) &&
                level >= DNC.Levels.LastDance && HasEffect(DNC.Buffs.LastDanceReady))
            {
                if (IsEnabled(CustomComboPreset.DancerFinishingMovePriorityFeature) &&
                    HasEffect(DNC.Buffs.FinishingMoveReady) && level >= DNC.Levels.FinishingMove)
                {
                        return DNC.FinishingMove;
                }

                return DNC.LastDance;
            }
        }

        if (actionID == DNC.TechnicalStep)
        {
            var gauge = GetJobGauge<DNCGauge>();

            if (IsEnabled(CustomComboPreset.DancerDanceStepCombo) && level >= DNC.Levels.StandardStep && gauge.IsDancing)
            {
                if (gauge.CompletedSteps < 4 && HasEffect(DNC.Buffs.TechnicalStep))
                    return gauge.NextStep;

                if (gauge.CompletedSteps < 2 && HasEffect(DNC.Buffs.StandardStep) &&
                    IsEnabled(CustomComboPreset.DancerCombinedStandardStepTechnicalStep))
                    return gauge.NextStep;

                return OriginalHook(DNC.TechnicalStep);
            }

            if (IsEnabled(CustomComboPreset.DancerPartnerFeature) && level >= DNC.Levels.ClosedPosition && (!HasEffect(DNC.Buffs.ClosedPosition)))
            {
                if (IsEnabled(CustomComboPreset.DancerChocoboPartnerFeature) && HasCompanionPresent())
                {
                    return DNC.ClosedPosition;
                }

                if (IsInParty() && IsInInstance())
                    return DNC.ClosedPosition;
            }
        }

        return actionID;
    }
}

internal class DancerFlourish : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DncAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DNC.Flourish)
        {
            if (IsEnabled(CustomComboPreset.DancerFlourishFan3Feature))
            {
                if (level >= DNC.Levels.FanDance3 && HasEffect(DNC.Buffs.ThreefoldFanDance))
                    return DNC.FanDance3;
            }

            if (IsEnabled(CustomComboPreset.DancerFlourishFan4Feature))
            {
                if (level >= DNC.Levels.FanDance4 && HasEffect(DNC.Buffs.FourfoldFanDance))
                    return DNC.FanDance4;
            }
        }

        return actionID;
    }
}

internal class DancerCascadeFountain : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DncAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DNC.Cascade || actionID == DNC.Fountain ||
            actionID == DNC.ReverseCascade || actionID == DNC.Fountainfall)
        {
            var gauge = GetJobGauge<DNCGauge>();

            if (level >= DNC.Levels.SaberDance && !HasEffect(DNC.Buffs.StandardStep) &&
                !HasEffect(DNC.Buffs.TechnicalStep) && IsEnabled(CustomComboPreset.DancerAutoSaberDance))
            {
                if (IsEnabled(CustomComboPreset.DancerAutoSaberDanceSTDawn) && gauge.Esprit >= 50 &&
                    HasEffect(DNC.Buffs.DanceOfTheDawnReady))
                    return OriginalHook(DNC.SaberDance);

                if (IsEnabled(CustomComboPreset.DancerAutoSaberDanceSTTech) && gauge.Esprit >= 50 &&
                    HasEffect(DNC.Buffs.TechnicalFinish))
                    return OriginalHook(DNC.SaberDance);

                if (gauge.Esprit >= 50 && (gauge.Esprit >= 85 ||
                    !IsEnabled(CustomComboPreset.DancerAutoSaberDanceST85Esprit)))
                    return OriginalHook(DNC.SaberDance);
            }

            if (IsEnabled(CustomComboPreset.DancerFan3FeatherOvercap) && HasEffect(DNC.Buffs.ThreefoldFanDance))
                return DNC.FanDance3;
            if (gauge.Feathers > 3 && IsEnabled(CustomComboPreset.DancerFanFeatherOvercap))
                return DNC.FanDance1;

            if (actionID == DNC.Cascade && IsEnabled(CustomComboPreset.DancerSingleTargetMultibutton))
            {
                if (level >= DNC.Levels.Fountainfall &&
                    (HasEffect(DNC.Buffs.FlourishingFlow) || HasEffect(DNC.Buffs.SilkenFlow)))
                    return DNC.Fountainfall;

                if (level >= DNC.Levels.ReverseCascade &&
                    (HasEffect(DNC.Buffs.FlourishingSymmetry) || HasEffect(DNC.Buffs.SilkenSymmetry)))
                    return DNC.ReverseCascade;

                if (lastComboMove == DNC.Cascade && level >= DNC.Levels.Fountain)
                    return DNC.Fountain;
            }

            if (IsEnabled(CustomComboPreset.DancerSingleTargetProcs))
            {
                if (actionID == DNC.Cascade && level >= DNC.Levels.ReverseCascade &&
                    (HasEffect(DNC.Buffs.FlourishingSymmetry) || HasEffect(DNC.Buffs.SilkenSymmetry)))
                    return DNC.ReverseCascade;

                if (actionID == DNC.Fountain && level >= DNC.Levels.Fountainfall &&
                    (HasEffect(DNC.Buffs.FlourishingFlow) || HasEffect(DNC.Buffs.SilkenFlow)))
                    return DNC.Fountainfall;
            }
        }

        return actionID;
    }
}

internal class DancerWindmillBladeshower : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DncAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DNC.Windmill || actionID == DNC.Bladeshower ||
            actionID == DNC.RisingWindmill || actionID == DNC.Bloodshower)
        {
            var gauge = GetJobGauge<DNCGauge>();

            if (level >= DNC.Levels.SaberDance && !HasEffect(DNC.Buffs.StandardStep) &&
                !HasEffect(DNC.Buffs.TechnicalStep) && IsEnabled(CustomComboPreset.DancerAutoSaberDance))
            {
                if (IsEnabled(CustomComboPreset.DancerAutoSaberDanceAoEDawn) && gauge.Esprit >= 50 &&
                    HasEffect(DNC.Buffs.DanceOfTheDawnReady))
                    return OriginalHook(DNC.SaberDance);

                if (IsEnabled(CustomComboPreset.DancerAutoSaberDanceAoETech) && gauge.Esprit >= 50 &&
                    HasEffect(DNC.Buffs.TechnicalFinish))
                    return OriginalHook(DNC.SaberDance);

                if (gauge.Esprit >= 50 && (gauge.Esprit >= 85 ||
                    !IsEnabled(CustomComboPreset.DancerAutoSaberDanceAoE85Esprit)))
                    return OriginalHook(DNC.SaberDance);
            }

            if (IsEnabled(CustomComboPreset.DancerFan3FeatherAoEOvercap) && HasEffect(DNC.Buffs.ThreefoldFanDance))
                return DNC.FanDance3;
            if (gauge.Feathers > 3 && IsEnabled(CustomComboPreset.DancerFanFeatherAoEOvercap))
                return DNC.FanDance2;

            if (actionID == DNC.Windmill && IsEnabled(CustomComboPreset.DancerAoeMultibutton))
            {
                if (level >= DNC.Levels.Bloodshower &&
                    (HasEffect(DNC.Buffs.FlourishingFlow) || HasEffect(DNC.Buffs.SilkenFlow)))
                    return DNC.Bloodshower;

                if (level >= DNC.Levels.RisingWindmill &&
                    (HasEffect(DNC.Buffs.FlourishingSymmetry) || HasEffect(DNC.Buffs.SilkenSymmetry)))
                    return DNC.RisingWindmill;

                if (lastComboMove == DNC.Windmill && level >= DNC.Levels.Bladeshower)
                    return DNC.Bladeshower;
            }

            if (IsEnabled(CustomComboPreset.DancerAoeProcs))
            {
                if (actionID == DNC.Windmill && level >= DNC.Levels.RisingWindmill &&
                    (HasEffect(DNC.Buffs.FlourishingSymmetry) || HasEffect(DNC.Buffs.SilkenSymmetry)))
                    return DNC.RisingWindmill;

                if (actionID == DNC.Bladeshower && level >= DNC.Levels.Bloodshower &&
                    (HasEffect(DNC.Buffs.FlourishingFlow) || HasEffect(DNC.Buffs.SilkenFlow)))
                    return DNC.Bloodshower;
            }
        }

        return actionID;
    }
}

internal class DancerDevilment : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DancerPartnerFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DNC.Devilment)
        {
            if (level >= DNC.Levels.ClosedPosition && (!HasEffect(DNC.Buffs.ClosedPosition)))
            {
                if (IsEnabled(CustomComboPreset.DancerChocoboPartnerFeature) && HasCompanionPresent())
                {
                    return DNC.ClosedPosition;
                }

                if (IsInParty() && IsInInstance())
                    return DNC.ClosedPosition;
            }
        }

        return actionID;
    }
}

internal class DancerTillanaOvercap : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DancerTillanaOvercap;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DNC.TechnicalStep || actionID == DNC.TechnicalFinish || actionID == DNC.Tillana)
        {
            var gauge = GetJobGauge<DNCGauge>();

            if (gauge.Esprit >= 50 && CanUseAction(DNC.Tillana))
                return OriginalHook(DNC.SaberDance);
        }

        return actionID;
    }
}