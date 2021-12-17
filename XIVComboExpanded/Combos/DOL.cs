namespace XIVComboExpandedPlugin.Combos
{
    internal static class DOL
    {
        public const byte ClassID = 0;
        public const byte JobID = 51;

        public const uint
            AgelessWords = 215,
            SolidReason = 232,
            MinWiseToTheWorld = 26521,
            BtnWiseToTheWorld = 26522;

        public static class Buffs
        {
            public const ushort
                EurekaMoment = 2765;
        }

        public static class Debuffs
        {
            public const ushort
                Placeholder = 0;
        }

        public static class Levels
        {
            public const byte
                WiseToTheWorld = 90;
        }
    }

    internal class MinerEurekaFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.Disabled; // DolEurekaFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { DOL.SolidReason, DOL.AgelessWords };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == DOL.SolidReason)
            {
                if (level >= DOL.Levels.WiseToTheWorld && HasEffect(DOL.Buffs.EurekaMoment))
                    return DOL.MinWiseToTheWorld;
            }

            if (actionID == DOL.AgelessWords)
            {
                if (level >= DOL.Levels.WiseToTheWorld && HasEffect(DOL.Buffs.EurekaMoment))
                    return DOL.BtnWiseToTheWorld;
            }

            return actionID;
        }
    }
}