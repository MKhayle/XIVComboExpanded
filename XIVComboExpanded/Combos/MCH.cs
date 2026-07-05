using System;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

internal static class MCH
{
    public const byte JobID = 31;

    public const uint
        // Single target
        CleanShot = 2873,
        HeatedCleanShot = 7413,
        SplitShot = 2866,
        HeatedSplitShot = 7411,
        SlugShot = 2868,
        HeatedSlugshot = 7412,
        // Charges
        GaussRound = 2874,
        Ricochet = 2890,
        DoubleCheck = 36979,
        Checkmate = 36980,
        // AoE
        SpreadShot = 2870,
        AutoCrossbow = 16497,
        Scattergun = 25786,
        // Rook
        RookAutoturret = 2864,
        RookOverdrive = 7415,
        AutomatonQueen = 16501,
        QueenOverdrive = 16502,
        // Other
        Wildfire = 2878,
        Detonator = 16766,
        Hypercharge = 17209,
        BarrelStabilizer = 7414,
        HeatBlast = 7410,
        BlazingShot = 36978,
        HotShot = 2872,
        Drill = 16498,
        Bioblaster = 16499,
        AirAnchor = 16500,
        Chainsaw = 25788,
        Excavator = 36981,
        FullMetal = 36982;

    public static class Buffs
    {
        public const ushort
            Overheat = 2688,
            HyperchargeReady = 3864,
            ExcavatorReady = 3865,
            FullMetalPrepared = 3866;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            SlugShot = 2,
            GaussRound = 15,
            CleanShot = 26,
            Hypercharge = 30,
            HeatBlast = 35,
            RookOverdrive = 40,
            Wildfire = 45,
            Ricochet = 50,
            AutoCrossbow = 52,
            HeatedSplitShot = 54,
            Drill = 58,
            HeatedSlugshot = 60,
            HeatedCleanShot = 64,
            BarrelStabilizer = 66,
            BlazingShot = 68,
            ChargedActionMastery = 74,
            AirAnchor = 76,
            QueenOverdrive = 80,
            Chainsaw = 90,
            DoubleCheck = 92,
            CheckMate = 92,
            Excavator = 96,
            FullMetal = 100;
    }
}

internal class MachinistCleanShot : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistMainCombo;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == MCH.CleanShot || actionID == MCH.HeatedCleanShot)
        {
            var gauge = GetJobGauge<MCHGauge>();

            if (IsEnabled(CustomComboPreset.MachinistHypercomboFeature))
            {
                if (gauge.IsOverheated && level >= MCH.Levels.HeatBlast)
                {
                    if (gauge.IsOverheated && level < MCH.Levels.BlazingShot)
                    {
                        return MCH.HeatBlast;
                    }
                    else
                    {
                        return MCH.BlazingShot;
                    }
                }
            }

            if (comboTime > 0)
            {
                if (lastComboMove == MCH.SlugShot && level >= MCH.Levels.CleanShot)
                    // Heated
                    return OriginalHook(MCH.CleanShot);

                if (lastComboMove == MCH.SplitShot && level >= MCH.Levels.SlugShot)
                    // Heated
                    return OriginalHook(MCH.SlugShot);
            }

            // Heated
            return OriginalHook(MCH.SplitShot);
        }

        return actionID;
    }
}

internal class MachinistGaussRoundRicochet : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistGaussRoundRicochetFeature;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID is MCH.GaussRound or MCH.Ricochet or MCH.Checkmate or MCH.DoubleCheck)
        {
            var gauge = GetJobGauge<MCHGauge>();

            if (IsEnabled(CustomComboPreset.MachinistGaussRoundRicochetFeatureOption))
            {
                if (!gauge.IsOverheated)
                    return actionID;
            }

            if (level >= MCH.Levels.Ricochet)
                return OriginalHook(CalcBestAction(actionID, MCH.GaussRound, MCH.Ricochet));

            return OriginalHook(MCH.Ricochet);
        }

        return actionID;
    }
}

internal class MachinistWildfire : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistHyperfireFeature;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == MCH.Hypercharge)
        {
            if (level >= MCH.Levels.Wildfire && IsCooldownUsable(MCH.Wildfire) && TargetIsEnemy())
                return MCH.Wildfire;

            if (level >= MCH.Levels.Wildfire && !IsCooldownUsable(MCH.Hypercharge) && !IsOriginal(MCH.Wildfire))
                return MCH.Detonator;
        }

        return actionID;
    }
}

internal class MachinistHeatBlastAutoCrossbow : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistOverheatFeature;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == MCH.HeatBlast || actionID == MCH.BlazingShot || actionID == MCH.AutoCrossbow)
        {
            var gauge = GetJobGauge<MCHGauge>();

            if (IsEnabled(CustomComboPreset.MachinistHyperfireFeature))
            {
                if (level >= MCH.Levels.Wildfire && IsCooldownUsable(MCH.Wildfire) && TargetIsEnemy())
                    return MCH.Wildfire;
            }

            if (level >= MCH.Levels.Hypercharge && !gauge.IsOverheated)
                return MCH.Hypercharge;

            if (level < MCH.Levels.AutoCrossbow)
                return MCH.HeatBlast;
        }

        return actionID;
    }
}

internal class MachinistSpreadShot : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistSpreadShotFeature;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == MCH.SpreadShot || actionID == MCH.Scattergun)
        {
            var gauge = GetJobGauge<MCHGauge>();

            if (level >= MCH.Levels.AutoCrossbow && gauge.IsOverheated)
                return MCH.AutoCrossbow;
        }

        return actionID;
    }
}

internal class MachinistRookAutoturret : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistOverdriveFeature;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == MCH.RookAutoturret || actionID == MCH.AutomatonQueen)
        {
            var gauge = GetJobGauge<MCHGauge>();

            if (level >= MCH.Levels.RookOverdrive && gauge.IsRobotActive)
                // Queen Overdrive
                return OriginalHook(MCH.RookOverdrive);
        }

        return actionID;
    }
}

internal class MachinistDrillAirAnchorChainsaw : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistHotShotDrillChainsawFeature;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == MCH.HotShot || actionID == MCH.AirAnchor || actionID == MCH.Drill || actionID == MCH.Chainsaw || actionID == MCH.Excavator)
        {
            if (level >= MCH.Levels.Excavator && HasEffect(MCH.Buffs.ExcavatorReady))
                return MCH.Excavator;

            if (level >= MCH.Levels.Chainsaw)
                return CalcBestAction(actionID, MCH.Chainsaw, MCH.AirAnchor, MCH.Drill);

            if (level >= MCH.Levels.AirAnchor)
                return CalcBestAction(actionID, MCH.AirAnchor, MCH.Drill);

            if (level >= MCH.Levels.Drill)
                return CalcBestAction(actionID, MCH.Drill, MCH.HotShot);

            return MCH.HotShot;
        }

        return actionID;
    }
}

internal class MachinistAirAnchorChainsaw : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistHotShotChainsawFeature;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == MCH.HotShot || actionID == MCH.AirAnchor || actionID == MCH.Chainsaw || actionID == MCH.Excavator)
        {
            if (level >= MCH.Levels.Excavator && HasEffect(MCH.Buffs.ExcavatorReady))
                return MCH.Excavator;

            if (level >= MCH.Levels.Chainsaw)
                return CalcBestAction(actionID, MCH.Chainsaw, MCH.AirAnchor);

            if (level >= MCH.Levels.AirAnchor)
                return MCH.AirAnchor;

            return MCH.HotShot;
        }

        return actionID;
    }
}

internal class MachinistBioblaster : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistBioblasterChainsawFeature;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == MCH.Bioblaster)
        {
            if (level >= MCH.Levels.Chainsaw)
                return CalcBestAction(actionID, MCH.Chainsaw, MCH.Bioblaster);
        }

        return actionID;
    }
}
