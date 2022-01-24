using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos
{
    internal static class RPR
    {
        public const byte JobID = 39;

        public const uint
            // Single Target
            Slice = 24373,
            WaxingSlice = 24374,
            InfernalSlice = 24375,
            // AoE
            SpinningScythe = 24376,
            NightmareScythe = 24377,
            // Soul Reaver
            Gibbet = 24382,
            Gallows = 24383,
            Guillotine = 24384,
            BloodStalk = 24389,
            UnveiledGibbet = 24390,
            UnveiledGallows = 24391,
            GrimSwathe = 24392,
            Gluttony = 24393,
            VoidReaping = 24395,
            CrossReaping = 24396,
            // Generators
            SoulSlice = 24380,
            SoulScythe = 24381,
            // Sacrifice
            ArcaneCircle = 24405,
            PlentifulHarvest = 24385,
            // Shroud
            Enshroud = 24394,
            Communio = 24398,
            LemuresSlice = 24399,
            LemuresScythe = 24400,
            // Misc
            ShadowOfDeath = 24378,
            Soulsow = 24387,
            HarvestMoon = 24388,
            HellsIngress = 24401,
            HellsEgress = 24402,
            Regress = 24403;

        public static class Buffs
        {
            public const ushort
                SoulReaver = 2587,
                EnhancedGibbet = 2588,
                EnhancedGallows = 2589,
                EnhancedVoidReaping = 2590,
                EnhancedCrossReaping = 2591,
                ImmortalSacrifice = 2592,
                Enshrouded = 2593,
                Soulsow = 2594,
                Threshold = 2595;
        }

        public static class Debuffs
        {
            public const ushort
                Placeholder = 0;
        }

        public static class Levels
        {
            public const byte
                WaxingSlice = 5,
                HellsIngress = 20,
                HellsEgress = 20,
                SpinningScythe = 25,
                InfernalSlice = 30,
                NightmareScythe = 45,
                SoulReaver = 70,
                Regress = 74,
                Gluttony = 76,
                Enshroud = 80,
                Soulsow = 82,
                EnhancedShroud = 86,
                LemuresScythe = 86,
                PlentifulHarvest = 88,
                Communio = 90;
        }
    }

    internal class ReaperSlice : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.InfernalSlice)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (IsEnabled(CustomComboPreset.ReaperSliceSoulsowFeature))
                {
                    if (level >= RPR.Levels.Soulsow && !HasCondition(ConditionFlag.InCombat) && !HasEffect(RPR.Buffs.Soulsow))
                        return RPR.Soulsow;
                }

                if (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0)
                {
                    if (IsEnabled(CustomComboPreset.ReaperSliceCommunioFeature))
                    {
                        if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1 && gauge.VoidShroud == 0)
                            return RPR.Communio;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperSliceLemuresFeature))
                    {
                        if (level >= RPR.Levels.EnhancedShroud && gauge.VoidShroud >= 2)
                            return RPR.LemuresSlice;
                    }
                }

                if ((level >= RPR.Levels.SoulReaver && HasEffect(RPR.Buffs.SoulReaver)) ||
                    (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0))
                {
                    if (IsEnabled(CustomComboPreset.ReaperSliceEnhancedEnshroudedFeature))
                    {
                        if (HasEffect(RPR.Buffs.EnhancedVoidReaping))
                            return RPR.VoidReaping;

                        if (HasEffect(RPR.Buffs.EnhancedCrossReaping))
                            return RPR.CrossReaping;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperSliceEnhancedSoulReaverFeature))
                    {
                        if (HasEffect(RPR.Buffs.EnhancedGibbet))
                            // Void Reaping
                            return OriginalHook(RPR.Gibbet);

                        if (HasEffect(RPR.Buffs.EnhancedGallows))
                            // Cross Reaping
                            return OriginalHook(RPR.Gallows);
                    }

                    if (IsEnabled(CustomComboPreset.ReaperSliceGibbetFeature))
                        // Void Reaping
                        return OriginalHook(RPR.Gibbet);

                    if (IsEnabled(CustomComboPreset.ReaperSliceGallowsFeature))
                        // Cross Reaping
                        return OriginalHook(RPR.Gallows);
                }

                if (IsEnabled(CustomComboPreset.ReaperSliceCombo))
                {
                    if (comboTime > 0)
                    {
                        if (lastComboMove == RPR.WaxingSlice && level >= RPR.Levels.InfernalSlice)
                            return RPR.InfernalSlice;

                        if (lastComboMove == RPR.Slice && level >= RPR.Levels.WaxingSlice)
                            return RPR.WaxingSlice;
                    }

                    return RPR.Slice;
                }
            }

            return actionID;
        }
    }

    internal class ReaperScythe : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.NightmareScythe)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (IsEnabled(CustomComboPreset.ReaperScytheHarvestMoonFeature))
                {
                    if (level >= RPR.Levels.Soulsow && HasEffect(RPR.Buffs.Soulsow) && HasTarget())
                        return RPR.HarvestMoon;
                }

                if (IsEnabled(CustomComboPreset.ReaperScytheSoulsowFeature))
                {
                    if (level >= RPR.Levels.Soulsow && !HasCondition(ConditionFlag.InCombat) && !HasEffect(RPR.Buffs.Soulsow))
                        return RPR.Soulsow;
                }

                if (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0)
                {
                    if (IsEnabled(CustomComboPreset.ReaperScytheCommunioFeature))
                    {
                        if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1 && gauge.VoidShroud == 0)
                            return RPR.Communio;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperScytheLemuresFeature))
                    {
                        if (level >= RPR.Levels.LemuresScythe && gauge.VoidShroud >= 2)
                            return RPR.LemuresScythe;
                    }
                }

                if (IsEnabled(CustomComboPreset.ReaperScytheGuillotineFeature))
                {
                    if ((level >= RPR.Levels.SoulReaver && HasEffect(RPR.Buffs.SoulReaver)) ||
                        (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0))
                        // Grim Reaping
                        return OriginalHook(RPR.Guillotine);
                }

                if (IsEnabled(CustomComboPreset.ReaperScytheCombo))
                {
                    if (comboTime > 0)
                    {
                        if (lastComboMove == RPR.SpinningScythe && level >= RPR.Levels.NightmareScythe)
                            return RPR.NightmareScythe;
                    }

                    return RPR.SpinningScythe;
                }
            }

            return actionID;
        }
    }

    internal class ReaperShadowOfDeath : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.ShadowOfDeath)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (IsEnabled(CustomComboPreset.ReaperShadowSoulsowFeature))
                {
                    if (level >= RPR.Levels.Soulsow && !HasCondition(ConditionFlag.InCombat) && !HasTarget() && !HasEffect(RPR.Buffs.Soulsow))
                        return RPR.Soulsow;
                }

                if (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0)
                {
                    if (IsEnabled(CustomComboPreset.ReaperShadowCommunioFeature))
                    {
                        if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1 && gauge.VoidShroud == 0)
                            return RPR.Communio;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperShadowLemuresFeature))
                    {
                        if (level >= RPR.Levels.EnhancedShroud && gauge.VoidShroud >= 2)
                            return RPR.LemuresSlice;
                    }
                }

                if ((level >= RPR.Levels.SoulReaver && HasEffect(RPR.Buffs.SoulReaver)) ||
                    (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0))
                {
                    if (IsEnabled(CustomComboPreset.ReaperShadowGallowsFeature))
                        // Cross Reaping
                        return OriginalHook(RPR.Gallows);

                    if (IsEnabled(CustomComboPreset.ReaperShadowGibbetFeature))
                        // Void Reaping
                        return OriginalHook(RPR.Gibbet);
                }
            }

            return actionID;
        }
    }

    internal class ReaperSoulSlice : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.SoulSlice)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0)
                {
                    if (IsEnabled(CustomComboPreset.ReaperSoulCommunioFeature))
                    {
                        if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1 && gauge.VoidShroud == 0)
                            return RPR.Communio;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperSoulLemuresFeature))
                    {
                        if (level >= RPR.Levels.EnhancedShroud && gauge.VoidShroud >= 2)
                            return RPR.LemuresSlice;
                    }
                }

                if ((level >= RPR.Levels.SoulReaver && HasEffect(RPR.Buffs.SoulReaver)) ||
                    (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0))
                {
                    if (IsEnabled(CustomComboPreset.ReaperSoulGallowsFeature))
                        // Cross Reaping
                        return OriginalHook(RPR.Gallows);

                    if (IsEnabled(CustomComboPreset.ReaperSoulGibbetFeature))
                        // Void Reaping
                        return OriginalHook(RPR.Gibbet);
                }
            }

            return actionID;
        }
    }

    internal class ReaperBloodStalk : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.BloodStalk)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (IsEnabled(CustomComboPreset.ReaperBloodStalkGluttonyFeature))
                {
                    if (level >= RPR.Levels.Gluttony && gauge.Soul >= 50 && IsOffCooldown(RPR.Gluttony))
                        return RPR.Gluttony;
                }
            }

            return actionID;
        }
    }

    internal class ReaperBloodStalkGrimSwathe : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.GrimSwathe || actionID == RPR.BloodStalk)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (IsEnabled(CustomComboPreset.ReaperGrimSwatheGluttonyFeature))
                {
                    if (level >= RPR.Levels.Gluttony && gauge.Soul >= 50 && IsOffCooldown(RPR.Gluttony))
                        return RPR.Gluttony;
                }
            }

            return actionID;
        }
    }

    internal class ReaperGibbetGallowsGuillotine : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.Gibbet || actionID == RPR.Gallows)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if ((level >= RPR.Levels.SoulReaver && HasEffect(RPR.Buffs.SoulReaver)) ||
                    (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0))
                {
                    if (IsEnabled(CustomComboPreset.ReaperCommunioSoulReaverFeature))
                    {
                        if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1 && gauge.VoidShroud == 0)
                            return RPR.Communio;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperLemuresSoulReaverFeature))
                    {
                        if (level >= RPR.Levels.EnhancedShroud && gauge.VoidShroud >= 2)
                            return RPR.LemuresSlice;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperEnhancedEnshroudedFeature))
                    {
                        if (HasEffect(RPR.Buffs.EnhancedVoidReaping))
                            return RPR.VoidReaping;

                        if (HasEffect(RPR.Buffs.EnhancedCrossReaping))
                            return RPR.CrossReaping;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperEnhancedSoulReaverFeature))
                    {
                        if (HasEffect(RPR.Buffs.EnhancedGibbet))
                            // Void Reaping
                            return OriginalHook(RPR.Gibbet);

                        if (HasEffect(RPR.Buffs.EnhancedGallows))
                            // Cross Reaping
                            return OriginalHook(RPR.Gallows);
                    }
                }
            }

            if (actionID == RPR.Guillotine)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0)
                {
                    if (IsEnabled(CustomComboPreset.ReaperCommunioSoulReaverFeature))
                    {
                        if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1 && gauge.VoidShroud == 0)
                            return RPR.Communio;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperLemuresSoulReaverFeature))
                    {
                        if (level >= RPR.Levels.LemuresScythe && gauge.VoidShroud >= 2)
                            return RPR.LemuresScythe;
                    }
                }
            }

            return actionID;
        }
    }

    internal class ReaperEnshroud : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.Enshroud)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (IsEnabled(CustomComboPreset.ReaperEnshroudCommunioFeature))
                {
                    if (level >= RPR.Levels.Communio && gauge.EnshroudedTimeRemaining > 0)
                        return RPR.Communio;
                }
            }

            return actionID;
        }
    }

    internal class ReaperArcaneCircle : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.ArcaneCircle)
            {
                if (IsEnabled(CustomComboPreset.ReaperHarvestFeature))
                {
                    if (level >= RPR.Levels.PlentifulHarvest && HasEffect(RPR.Buffs.ImmortalSacrifice))
                        return RPR.PlentifulHarvest;
                }
            }

            return actionID;
        }
    }

    internal class ReaperHellsIngressEgress : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.HellsEgress || actionID == RPR.HellsIngress)
            {
                if (IsEnabled(CustomComboPreset.ReaperRegressFeature))
                {
                    if (level >= RPR.Levels.Regress)
                    {
                        if (IsEnabled(CustomComboPreset.ReaperRegressOption))
                        {
                            var threshold = FindEffect(RPR.Buffs.Threshold);

                            if (threshold != null && threshold.RemainingTime <= 8.5)
                                return RPR.Regress;
                        }
                        else
                        {
                            if (HasEffect(RPR.Buffs.Threshold))
                                return RPR.Regress;
                        }
                    }
                }
            }

            return actionID;
        }
    }
}
