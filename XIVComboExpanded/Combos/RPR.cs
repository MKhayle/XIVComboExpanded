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
            Communio = 24398;

        public static class Buffs
        {
            public const ushort
                SoulReaver = 2587,
                ImmortalSacrifice = 2592,
                EnhancedGibbet = 2588,
                EnhancedGallows = 2589,
                EnhancedVoidReaping = 2590,
                EnhancedCrossReaping = 2591,
                Enshrouded = 2593;
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
                SpinningScythe = 25,
                InfernalSlice = 30,
                NightmareScythe = 45,
                BloodStalk = 50,
                GrimSwathe = 55,
                Gibbet = 70,
                Gallows = 70,
                Guillotine = 70,
                Enshroud = 80,
                PlentifulHarvest = 88,
                Communio = 90;
        }
    }

    internal class ReaperSoulReaverFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.Disabled; // ReaperSoulReaverFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { RPR.InfernalSlice, RPR.BloodStalk, RPR.NightmareScythe };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.InfernalSlice)
            {
                if (HasEffect(RPR.Buffs.SoulReaver) || HasEffect(RPR.Buffs.Enshrouded))
                    return OriginalHook(RPR.Gibbet);
            }

            if (actionID == RPR.BloodStalk)
            {
                if (HasEffect(RPR.Buffs.SoulReaver) || HasEffect(RPR.Buffs.Enshrouded))
                    return OriginalHook(RPR.Gallows);
            }

            if (actionID == RPR.NightmareScythe)
            {
                if (HasEffect(RPR.Buffs.SoulReaver) || HasEffect(RPR.Buffs.Enshrouded))
                    return OriginalHook(RPR.Guillotine);
            }

            return actionID;
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

    internal class GibbetSliceCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperGibbetSliceCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.Gibbet)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == RPR.Slice && level >= RPR.Levels.WaxingSlice)
                        return RPR.WaxingSlice;

                    if (lastComboMove == RPR.WaxingSlice && level >= RPR.Levels.InfernalSlice)
                        return RPR.InfernalSlice;
                }

                // Check if we're in Soul Reaver or Enshrouded
                if (HasEffect(RPR.Buffs.SoulReaver) || HasEffect(RPR.Buffs.Enshrouded))
                {
                    // If we have Enhanced Gibbet/Void Reaping and Soul Reaver/Shroud, this should always be next cast
                    if ((HasEffect(RPR.Buffs.EnhancedGibbet) || HasEffect(RPR.Buffs.EnhancedVoidReaping)) && level >= RPR.Levels.Gibbet)
                        return RPR.Gibbet;
                    // Same for Gallows
                    if ((HasEffect(RPR.Buffs.EnhancedGallows) || HasEffect(RPR.Buffs.EnhancedCrossReaping)) && level >= RPR.Levels.Gallows)
                        return RPR.Gallows;

                    // If we don't have enhanced, but are in Soul Reaver/Shroud, return Gibbet
                    if (level >= RPR.Levels.Gibbet)
                        return RPR.Gibbet;
                }

                // Return slice if nothing else to do
                return RPR.Slice;
            }

            return actionID;
        }
    }

    internal class GallowsSliceCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperGallowsSliceCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.Gallows)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == RPR.Slice && level >= RPR.Levels.WaxingSlice)
                        return RPR.WaxingSlice;

                    if (lastComboMove == RPR.WaxingSlice && level >= RPR.Levels.InfernalSlice)
                        return RPR.InfernalSlice;
                }

                // Check if we're in Soul Reaver or Shroud
                if (HasEffect(RPR.Buffs.SoulReaver) || HasEffect(RPR.Buffs.Enshrouded))
                {
                    // If we have Enhanced Gibbet/Void Reaping and Soul Reaver/Shroud, this should always be next cast
                    if ((HasEffect(RPR.Buffs.EnhancedGibbet) || HasEffect(RPR.Buffs.EnhancedVoidReaping)) && level >= RPR.Levels.Gibbet)
                        return RPR.Gibbet;
                    // Same for Gallows
                    if ((HasEffect(RPR.Buffs.EnhancedGallows) || HasEffect(RPR.Buffs.EnhancedCrossReaping)) && level >= RPR.Levels.Gallows)
                        return RPR.Gallows;

                    // If we don't have enhanced, but are in Soul Reaver/Shroud, return Gibbet
                    if (level >= RPR.Levels.Gibbet)
                        return RPR.Gallows;
                }

                // Return slice if nothing else to do
                return RPR.Slice;
            }

            return actionID;
        }
    }

    internal class GuillotineScytheCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperGuillotineScytheCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.Guillotine)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == RPR.SpinningScythe && level >= RPR.Levels.NightmareScythe)
                        return RPR.NightmareScythe;
                }

                // If we're in Soul Reaver/Shroud, return Guillotine
                if ((HasEffect(RPR.Buffs.SoulReaver) || HasEffect(RPR.Buffs.Enshrouded)) && level >= RPR.Levels.Guillotine)
                    return RPR.Guillotine;

                return RPR.SpinningScythe;
            }

            return actionID;
        }
    }
}
