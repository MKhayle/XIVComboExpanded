namespace XIVComboExpandedPlugin.Combos
{
    internal static class SGE
    {
        public const byte JobID = 40;

        public const uint
            Diagnosis = 24284,
            Druochole = 24296,
            Taurochole = 24303,
            Ixochole = 24299,
            Holos = 24310;

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
            public const ushort
                Dosis = 1,
                Prognosis = 10,
                Druochole = 45,
                Kerachole = 50,
                Taurochole = 62,
                Ixochole = 52,
                Dosis2 = 72,
                Holos = 76,
                Rizomata = 74,
                Dosis3 = 82,
                Pneuma = 90;
        }
    }

    internal class SageTaurocholeDruocholeFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SageTaurocholeDruocholeFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { SGE.Taurochole, SGE.Druochole };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SGE.Taurochole)
            {
                if (level >= SGE.Levels.Taurochole)
                    return CalcBestAction(actionID, SGE.Druochole);
                return SGE.Druochole;
            }

            return actionID;
        }
    }
}
