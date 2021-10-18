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
            // Rook
            RookAutoturret = 2864,
            RookOverdrive = 7415,
            AutomatonQueen = 16501,
            QueenOverdrive = 16502,
            // Other
            Hypercharge = 17209,
            HeatBlast = 7410,
            Drill = 16498,
            AirAnchor = 16500;

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
                HeatedSlugshot = 60,
                HeatedCleanShot = 64,
                ChargedActionMastery = 74,
                QueenOverdrive = 80;
        }
    }

    internal class MachinistHeatBlastFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MachinistHeatBlastFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.CleanShot || actionID == MCH.HeatedCleanShot)
            {
                var gauge = GetJobGauge<MCHGauge>();
                if (gauge.IsOverheated && level >= MCH.Levels.Hypercharge)
                    return MCH.HeatBlast;
            }

            return actionID;
        }
    }

    internal class MachinistMainCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MachinistMainCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.CleanShot || actionID == MCH.HeatedCleanShot)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == MCH.SplitShot && level >= MCH.Levels.SlugShot)
                        return OriginalHook(MCH.SlugShot);

                    if (lastComboMove == MCH.SlugShot && level >= MCH.Levels.CleanShot)
                        return OriginalHook(MCH.CleanShot);
                }

                return OriginalHook(MCH.SplitShot);
            }

            return actionID;
        }
    }

    internal class MachinistGaussRoundRicochetFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MachinistGaussRoundRicochetFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.GaussRound || actionID == MCH.Ricochet)
            {
                var gaussCd = GetCooldown(MCH.GaussRound);
                var ricochetCd = GetCooldown(MCH.Ricochet);

                // Prioritize the original if both are off cooldown
                if (!gaussCd.IsCooldown && !ricochetCd.IsCooldown)
                    return actionID;

                return gaussCd.CooldownRemaining < ricochetCd.CooldownRemaining
                    ? MCH.GaussRound
                    : MCH.Ricochet;
            }

            return actionID;
        }
    }

    internal class MachinistOverheatFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MachinistOverheatFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.HeatBlast || actionID == MCH.AutoCrossbow)
            {
                var gauge = GetJobGauge<MCHGauge>();
                if (!gauge.IsOverheated && level >= MCH.Levels.Hypercharge)
                    return MCH.Hypercharge;

                if (level < MCH.Levels.AutoCrossbow)
                    return MCH.HeatBlast;
            }

            return actionID;
        }
    }

    internal class MachinistSpreadShotFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MachinistSpreadShotFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.SpreadShot)
            {
                var gauge = GetJobGauge<MCHGauge>();
                if (gauge.IsOverheated && level >= MCH.Levels.AutoCrossbow)
                    return MCH.AutoCrossbow;
            }

            return actionID;
        }
    }

    internal class MachinistOverdriveFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MachinistOverdriveFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.RookAutoturret || actionID == MCH.AutomatonQueen)
            {
                var gauge = GetJobGauge<MCHGauge>();
                if (gauge.IsRobotActive)
                    return OriginalHook(MCH.QueenOverdrive);
            }

            return actionID;
        }
    }

    internal class MachinistDrillAirAnchorFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.MachinistDrillAirAnchortFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MCH.Drill || actionID == MCH.AirAnchor)
            {
                var drillCd = GetCooldown(MCH.Drill);
                var anchorCd = GetCooldown(MCH.AirAnchor);

                // Prioritize the original if both are off cooldown
                if (!drillCd.IsCooldown && !anchorCd.IsCooldown)
                    return actionID;

                return drillCd.CooldownRemaining < anchorCd.CooldownRemaining
                    ? MCH.Drill
                    : MCH.AirAnchor;
            }

            return actionID;
        }
    }
}
