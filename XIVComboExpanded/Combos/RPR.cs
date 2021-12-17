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
            BloodStalk = 24389,
            Gibbet = 24382,
            Gallows = 24383,
            Guillotine = 24384,
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
            HellsIngress = 24401,
            HellsEgress = 24402,
            Regress = 24403;

        public static class Buffs
        {
            public const ushort
                SoulReaver = 2587,
                ImmortalSacrifice = 2592,
                EnhancedGibbet = 2588,
                EnhancedGallows = 2589,
                EnhancedVoidReaping = 2590,
                EnhancedCrossReaping = 2591,
                Enshrouded = 2593,
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
                Enshroud = 80,
                LemuresSlice = 86,
                LemuresScythe = 86,
                PlentifulHarvest = 88,
                Communio = 90;
        }
    }

    internal class ReaperSliceCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ReaperSliceCombo;

        protected internal override uint[] ActionIDs { get; } = new[] { RPR.InfernalSlice };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.InfernalSlice)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (level >= RPR.Levels.Enshroud && HasEffect(RPR.Buffs.Enshrouded))
                {
                    if (IsEnabled(CustomComboPreset.ReaperCommunioSoulReaverFeature))
                    {
                        if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1 && gauge.VoidShroud == 0)
                            return RPR.Communio;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperLemuresSoulReaverFeature))
                    {
                        if (level >= RPR.Levels.LemuresSlice && gauge.VoidShroud >= 2)
                            return RPR.LemuresSlice;
                    }
                }

                if (IsEnabled(CustomComboPreset.ReaperSoulReaverGibbetFeature))
                {
                    if ((level >= RPR.Levels.SoulReaver && HasEffect(RPR.Buffs.SoulReaver)) ||
                        (level >= RPR.Levels.Enshroud && HasEffect(RPR.Buffs.Enshrouded)))
                    {
                        if (IsEnabled(CustomComboPreset.ReaperSoulReaverGibbetOption))
                            // Cross Reaping
                            return OriginalHook(RPR.Gallows);

                        // Void Reaping
                        return OriginalHook(RPR.Gibbet);
                    }
                }

                if (comboTime > 0)
                {
                    if (lastComboMove == RPR.WaxingSlice && level >= RPR.Levels.InfernalSlice)
                        return RPR.InfernalSlice;

                    if (lastComboMove == RPR.Slice && level >= RPR.Levels.WaxingSlice)
                        return RPR.WaxingSlice;
                }

                return RPR.Slice;
            }

            return actionID;
        }
    }

    internal class ReaperScytheCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ReaperScytheCombo;

        protected internal override uint[] ActionIDs { get; } = new[] { RPR.NightmareScythe };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.NightmareScythe)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (level >= RPR.Levels.Enshroud && HasEffect(RPR.Buffs.Enshrouded))
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

                if (IsEnabled(CustomComboPreset.ReaperSoulReaverGuillotineFeature))
                {
                    if ((level >= RPR.Levels.SoulReaver && HasEffect(RPR.Buffs.SoulReaver)) ||
                        (level >= RPR.Levels.Enshroud && HasEffect(RPR.Buffs.Enshrouded)))
                        // Grim Reaping
                        return OriginalHook(RPR.Guillotine);
                }

                if (comboTime > 0)
                {
                    if (lastComboMove == RPR.SpinningScythe && level >= RPR.Levels.NightmareScythe)
                        return RPR.NightmareScythe;
                }

                return RPR.SpinningScythe;
            }

            return actionID;
        }
    }

    internal class ReaperSoulReaverFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ReaperSoulReaverGallowsFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { RPR.ShadowOfDeath };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.ShadowOfDeath)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (level >= RPR.Levels.Enshroud && HasEffect(RPR.Buffs.Enshrouded))
                {
                    if (IsEnabled(CustomComboPreset.ReaperCommunioSoulReaverFeature))
                    {
                        if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1 && gauge.VoidShroud == 0)
                            return RPR.Communio;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperLemuresSoulReaverFeature))
                    {
                        if (level >= RPR.Levels.LemuresSlice && gauge.VoidShroud >= 2)
                            return RPR.LemuresSlice;
                    }
                }

                if (level >= RPR.Levels.SoulReaver)
                {
                    if ((level >= RPR.Levels.SoulReaver && HasEffect(RPR.Buffs.SoulReaver)) ||
                        (level >= RPR.Levels.Enshroud && HasEffect(RPR.Buffs.Enshrouded)))
                    {
                        if (IsEnabled(CustomComboPreset.ReaperSoulReaverGallowsOption))
                            // Void Reaping
                            return OriginalHook(RPR.Gibbet);

                        // Cross Reaping
                        return OriginalHook(RPR.Gallows);
                    }
                }
            }

            return actionID;
        }
    }

    internal class ReaperLemuresSoulReaverFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ReaperLemuresSoulReaverFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { RPR.Gibbet, RPR.Gallows, RPR.Guillotine };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.Gibbet || actionID == RPR.Gallows)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (level >= RPR.Levels.Enshroud && HasEffect(RPR.Buffs.Enshrouded))
                {
                    if (IsEnabled(CustomComboPreset.ReaperCommunioSoulReaverFeature))
                    {
                        if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1 && gauge.VoidShroud == 0)
                            return RPR.Communio;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperLemuresSoulReaverFeature))
                    {
                        if (level >= RPR.Levels.LemuresSlice && gauge.VoidShroud >= 2)
                            return RPR.LemuresSlice;
                    }
                }
            }

            if (actionID == RPR.Guillotine)
            {
                var gauge = GetJobGauge<RPRGauge>();

                if (level >= RPR.Levels.Enshroud && HasEffect(RPR.Buffs.Enshrouded))
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

    internal class ReaperHarvestFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ReaperHarvestFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { RPR.ArcaneCircle };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.ArcaneCircle)
            {
                if (level >= RPR.Levels.PlentifulHarvest && HasEffect(RPR.Buffs.ImmortalSacrifice))
                    return RPR.PlentifulHarvest;
            }

            return actionID;
        }
    }

    internal class EnshroudCommunioFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ReaperEnshroudCommunioFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { RPR.Enshroud };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.Enshroud)
            {
                if (level >= RPR.Levels.Communio && HasEffect(RPR.Buffs.Enshrouded))
                    return RPR.Communio;
            }

            return actionID;
        }
    }

    internal class ReaperRegressFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ReaperRegressFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { RPR.HellsIngress, RPR.HellsEgress };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.HellsEgress || actionID == RPR.HellsIngress)
            {
                if (level >= RPR.Levels.Regress && HasEffect(RPR.Buffs.Threshold))
                    return RPR.Regress;
            }

            return actionID;
        }
    }
}