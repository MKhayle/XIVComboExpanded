using System;

using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos
{
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
            Hypercharge = 17209,
            HeatBlast = 7410,
            HotShot = 2872,
            Drill = 16498,
            AirAnchor = 16500,
            Chainsaw = 25788;

        public static class Buffs
        {
            public const ushort
                Placeholder = 0;
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
                Ricochet = 50,
                AutoCrossbow = 52,
                HeatedSplitShot = 54,
                Drill = 58,
                HeatedSlugshot = 60,
                HeatedCleanShot = 64,
                ChargedActionMastery = 74,
                AirAnchor = 76,
                QueenOverdrive = 80,
                Chainsaw = 90;
        }
    }

    internal class MachinistMainCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistMainCombo;

        protected internal override uint[] ActionIDs { get; } = new[] { MCH.CleanShot, MCH.HeatedCleanShot };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.CleanShot || actionID == MCH.HeatedCleanShot)
            {
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

    internal class MachinistGaussRoundRicochetFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistGaussRoundRicochetFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { MCH.GaussRound, MCH.Ricochet };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.GaussRound || actionID == MCH.Ricochet)
            {
                if (level >= MCH.Levels.Ricochet)
                    return CalcBestAction(actionID, MCH.GaussRound, MCH.Ricochet);

                return MCH.GaussRound;
            }

            return actionID;
        }
    }

    internal class MachinistOverheatFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistOverheatFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { MCH.HeatBlast, MCH.AutoCrossbow };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.HeatBlast || actionID == MCH.AutoCrossbow)
            {
                var gauge = GetJobGauge<MCHGauge>();

                if (level >= MCH.Levels.Hypercharge && !gauge.IsOverheated)
                    return MCH.Hypercharge;

                if (level < MCH.Levels.AutoCrossbow)
                    return MCH.HeatBlast;
            }

            return actionID;
        }
    }

    internal class MachinistSpreadShotFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistSpreadShotFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { MCH.SpreadShot, MCH.Scattergun };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
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

    internal class MachinistOverdriveFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistOverdriveFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { MCH.RookAutoturret };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.RookAutoturret)
            {
                var gauge = GetJobGauge<MCHGauge>();

                if (level >= MCH.Levels.RookOverdrive && gauge.IsRobotActive)
                    // Queen Overdrive
                    return OriginalHook(MCH.RookOverdrive);
            }

            return actionID;
        }
    }

    internal class MachinistDrillAirAnchorFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistHotShotDrillChainsawFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { MCH.HotShot, MCH.AirAnchor, MCH.Drill, MCH.Chainsaw };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.HotShot || actionID == MCH.AirAnchor || actionID == MCH.Drill || actionID == MCH.Chainsaw)
            {
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
}
