using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos
{
    internal static class DRG
    {
        public const byte ClassID = 4;
        public const byte JobID = 22;

        public const uint
            // Single Target
            TrueThrust = 75,
            VorpalThrust = 78,
            Disembowel = 87,
            FullThrust = 84,
            ChaosThrust = 88,
            HeavensThrust = 25771,
            ChaoticSpring = 25772,
            WheelingThrust = 3556,
            FangAndClaw = 3554,
            RaidenThrust = 16479,
            // AoE
            DoomSpike = 86,
            SonicThrust = 7397,
            CoerthanTorment = 16477,
            DraconianFury = 25770,
            // Combined
            // Jumps
            Jump = 92,
            SpineshatterDive = 95,
            DragonfireDive = 96,
            HighJump = 16478,
            MirageDive = 7399,
            // Dragon
            Stardiver = 16480,
            WyrmwindThrust = 25773;

        public static class Buffs
        {
            public const ushort
                SharperFangAndClaw = 802,
                EnhancedWheelingThrust = 803,
                DiveReady = 1243;
        }

        public static class Debuffs
        {
            public const ushort
                Placeholder = 0;
        }

        public static class Levels
        {
            public const byte
                VorpalThrust = 4,
                Disembowel = 18,
                FullThrust = 26,
                SpineshatterDive = 45,
                DragonfireDive = 50,
                ChaosThrust = 50,
                HeavensThrust = 86,
                ChaoticSpring = 86,
                FangAndClaw = 56,
                WheelingThrust = 58,
                SonicThrust = 62,
                MirageDive = 68,
                CoerthanTorment = 72,
                HighJump = 74,
                RaidenThrust = 76,
                Stardiver = 80;
        }
    }

    internal class DragoonJumpFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DragoonJumpFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { DRG.Jump, DRG.HighJump };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == DRG.Jump || actionID == DRG.HighJump)
            {
                if (level >= DRG.Levels.MirageDive && HasEffect(DRG.Buffs.DiveReady))
                    return DRG.MirageDive;

                // High Jump
                return OriginalHook(DRG.Jump);
            }

            return actionID;
        }
    }

    internal class DragoonCoerthanTormentCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DragoonCoerthanTormentCombo;

        protected internal override uint[] ActionIDs { get; } = new[] { DRG.CoerthanTorment };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == DRG.CoerthanTorment)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == DRG.SonicThrust && level >= DRG.Levels.CoerthanTorment)
                        return DRG.CoerthanTorment;

                    if ((lastComboMove == DRG.DoomSpike || lastComboMove == DRG.DraconianFury) && level >= DRG.Levels.SonicThrust)
                        return DRG.SonicThrust;
                }

                // Draconian Fury
                return OriginalHook(DRG.DoomSpike);
            }

            return actionID;
        }
    }

    internal class DragoonChaosThrustCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrgAny;

        protected internal override uint[] ActionIDs { get; } = new[] { DRG.ChaosThrust, DRG.ChaoticSpring };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == DRG.ChaosThrust || actionID == DRG.ChaoticSpring)
            {
                if (IsEnabled(CustomComboPreset.DragoonFangThrustFeature))
                {
                    if (level >= DRG.Levels.FangAndClaw && (HasEffect(DRG.Buffs.SharperFangAndClaw) || HasEffect(DRG.Buffs.EnhancedWheelingThrust)))
                        return DRG.WheelingThrust;
                }

                if (IsEnabled(CustomComboPreset.DragoonChaosThrustCombo))
                {
                    if (level >= DRG.Levels.FangAndClaw && HasEffect(DRG.Buffs.SharperFangAndClaw))
                        return DRG.FangAndClaw;

                    if (level >= DRG.Levels.WheelingThrust && HasEffect(DRG.Buffs.EnhancedWheelingThrust))
                        return DRG.WheelingThrust;

                    if (comboTime > 0)
                    {
                        if (lastComboMove == DRG.Disembowel && level >= DRG.Levels.ChaosThrust)
                            // ChaoticSpring
                            return OriginalHook(DRG.ChaosThrust);

                        if ((lastComboMove == DRG.TrueThrust || lastComboMove == DRG.RaidenThrust) && level >= DRG.Levels.Disembowel)
                            return DRG.Disembowel;
                    }

                    // Vorpal Thrust
                    return OriginalHook(DRG.TrueThrust);
                }
            }

            return actionID;
        }
    }

    internal class DragoonFullThrustCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrgAny;

        protected internal override uint[] ActionIDs { get; } = new[] { DRG.FullThrust, DRG.HeavensThrust };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == DRG.FullThrust || actionID == DRG.HeavensThrust)
            {
                if (IsEnabled(CustomComboPreset.DragoonFangThrustFeature))
                {
                    if (level >= DRG.Levels.FangAndClaw && (HasEffect(DRG.Buffs.SharperFangAndClaw) || HasEffect(DRG.Buffs.EnhancedWheelingThrust)))
                        return DRG.FangAndClaw;
                }

                if (IsEnabled(CustomComboPreset.DragoonFullThrustCombo))
                {
                    if (level >= DRG.Levels.WheelingThrust && HasEffect(DRG.Buffs.EnhancedWheelingThrust))
                        return DRG.WheelingThrust;

                    if (level >= DRG.Levels.FangAndClaw && HasEffect(DRG.Buffs.SharperFangAndClaw))
                        return DRG.FangAndClaw;

                    if (comboTime > 0)
                    {
                        if (lastComboMove == DRG.VorpalThrust && level >= DRG.Levels.FullThrust)
                            // Heavens' Thrust
                            return OriginalHook(DRG.FullThrust);

                        if ((lastComboMove == DRG.TrueThrust || lastComboMove == DRG.RaidenThrust) && level >= DRG.Levels.VorpalThrust)
                            return DRG.VorpalThrust;
                    }

                    // Vorpal Thrust
                    return OriginalHook(DRG.TrueThrust);
                }
            }

            return actionID;
        }
    }

    internal class DragoonDiveFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.Disabled; // DragoonDiveFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { DRG.SpineshatterDive, DRG.DragonfireDive, DRG.Stardiver };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == DRG.SpineshatterDive || actionID == DRG.DragonfireDive || actionID == DRG.Stardiver)
            {
                if (level >= DRG.Levels.Stardiver)
                {
                    var gauge = GetJobGauge<DRGGauge>();

                    if (gauge.IsLOTDActive)
                        return CalcBestAction(actionID, DRG.SpineshatterDive, DRG.DragonfireDive, DRG.Stardiver);

                    return CalcBestAction(actionID, DRG.SpineshatterDive, DRG.DragonfireDive);
                }

                if (level >= DRG.Levels.DragonfireDive)
                    return CalcBestAction(actionID, DRG.SpineshatterDive, DRG.DragonfireDive);

                if (level >= DRG.Levels.SpineshatterDive)
                    return DRG.SpineshatterDive;
            }

            return actionID;
        }
    }
}
