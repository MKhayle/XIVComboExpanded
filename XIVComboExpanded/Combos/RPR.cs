namespace XIVComboExpandedPlugin.Combos
{
    internal static class RPR
    {
        public const byte JobID = byte.MaxValue;

        public const uint
            // Single Target
            Slice = uint.MaxValue,
            WaxingSlice = uint.MaxValue,
            InfernalSlice = uint.MaxValue,
            // AoE
            SpinningScythe = uint.MaxValue,
            NightmareScythe = uint.MaxValue,
            // Shroud
            Enshroud = uint.MaxValue,
            Communio = uint.MaxValue,
            ArcaneCircle = uint.MaxValue,
            PlentifulHarvest = uint.MaxValue;

        public static class Buffs
        {
            public const ushort
                Enshrouded = ushort.MaxValue,
                ImmortalSacrifice = ushort.MaxValue;
        }

        public static class Debuffs
        {
            public const ushort
                Placeholder = 0;
        }

        public static class Levels
        {
            public const byte
                Slice = 1,
                WaxingSlice = 5,
                SpinningScythe = 25,
                InfernalSlice = 30,
                NightmareScythe = 45,
                Enshroud = 80,
                PlentifulHarvest = 88,
                Communio = 90;
        }
    }

    internal class ReaperSliceCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperSliceCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.Slice)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == RPR.Slice && level >= RPR.Levels.WaxingSlice)
                        return RPR.WaxingSlice;

                    if (lastComboMove == RPR.WaxingSlice && level >= RPR.Levels.InfernalSlice)
                        return RPR.InfernalSlice;
                }

                return RPR.Slice;
            }

            return actionID;
        }
    }

    internal class ReaperScytheCombo : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperScytheCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.SpinningScythe)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == RPR.SpinningScythe && level >= RPR.Levels.NightmareScythe)
                        return RPR.NightmareScythe;
                }

                return RPR.Slice;
            }

            return actionID;
        }
    }

    internal class EnshroudCommunioFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperEnshroudCommunioFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.Enshroud)
            {
                if (level >= RPR.Levels.Communio && HasEffect(RPR.Buffs.Enshrouded))
                    return RPR.Communio;

                return RPR.Enshroud;
            }

            return actionID;
        }
    }

    internal class ReaperHarvestFeature : CustomCombo
    {
        protected override CustomComboPreset Preset => CustomComboPreset.ReaperHarvestFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RPR.ArcaneCircle)
            {
                if (HasEffect(RPR.Buffs.ImmortalSacrifice) && level >= RPR.Levels.PlentifulHarvest)
                    return RPR.PlentifulHarvest;
            }

            return actionID;
        }
    }
}