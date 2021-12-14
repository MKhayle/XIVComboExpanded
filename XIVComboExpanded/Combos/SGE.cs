namespace XIVComboExpandedPlugin.Combos
{
    internal static class SGE
    {
        public const byte JobID = 40;

        public const uint
            Dosis = 0,
            Diagnosis = 24284,
            Holos = 24310,
            Ixochole = 24299,
            Taurochole = 0,
            Druochole = 0,
            Toxikon = 0,
            Phlegma = 0;

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
    
    internal class SageDosisPhlegmaFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SageDosisPhlegmaFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { SGE.Phlegma, SGE.Toxikon, SGE.Pneuma };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SGE.Dosis && !HasEffect(SGE.Buffs.Eukrasia))
            {
                if (level >= SGE.Level.Pneuma && IsEnabled(CustomComboPreset.DosisPneumaFeature))
                    return CalcBestAction(actionID, SGE.Pneuma);
                if (level >= SGE.Level.Toxikon && IsEnabled(CustomComboPreset.DosisToxikonFeature))
                    return CalcBestAction(actionID, SGE.Toxikon);
                if (level >= SGE.Level.Phlegma)
                    return CalcBestAction(actionID, SGE.Phlegma);

                return SGE.Dosis;
            }

            return actionID;
        }
    }
    
    internal class SageTaurocholeDruocholeFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SageTaurocholeDruocholeFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { SGE.Taurochole, SGE.Druochole };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SGE.Druochole)
            {
                if (level >= SGE.Level.Taurochole)
                    return CalcBestAction(actionID, SGE.Taurochole);

                return SGE.Druochole;
            }

            return actionID;
        }
    }
    
    internal class SageDyskrasiaPhlegmaToxikonFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SageDyskrasiaPhlegmaToxikonFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { SGE.Phlegma, SGE.Toxikon, SGE.Pneuma };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SGE.Dyskrasia)
            {
                if (level >= SGE.Level.Pneuma && IsEnabled(CustomComboPreset.DyskrasiaPneumaFeature))
                    return CalcBestAction(actionID, SGE.Pneuma);
                if (level >= SGE.Level.Toxikon && IsEnabled(CustomComboPreset.DyskrasiaToxikonFeature))
                    return CalcBestAction(actionID, SGE.Toxikon);
                if (level >= SGE.Level.Phlegma)
                    return CalcBestAction(actionID, SGE.Phlegma);

                return SGE.Dyskrasia;
            }

            return actionID;
        }
    }
}
