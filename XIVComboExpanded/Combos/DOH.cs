namespace XIVComboExpandedPlugin.Combos
{
    internal static class DOH
    {
        public const byte ClassID = 0;
        public const byte JobID = 50;

        public const uint
            //Combos
            CrpBasicTouch = 1502,
            CrpStandardTouch = 1516,
            CrpAdvancedTouch = 1519,
            CrpPreciseTouch = 1524,
            CrpIntenseSynthesis = 1514,
            // Focused things
            Observe = 1954,
            CrpFocusedSynthesis = 1536,
            CrpFocusedTouch = 1535;

        public static class Buffs
        {
            public const ushort
                InnerQuiet = 0,
                GreatStrides = 0,
                Innovation = 0,
                Veneration = 0;
        }
        
        public static class Quality
        {
            public const ??
                Good = 0,
                Normal = 0,
                Excelent = 0,
                Poor = 0;
        }

        public static class Debuffs
        {
            public const ushort
                Placeholder = 0;
        }

        public static class Levels
        {
            public const byte
                BasicTouch = 5,
                Observe = 13,
                Veneration = 15,
                StandardTouch = 18,
                GreatStrides = 21,
                Innovation = 26,
                PreciseTouch = 53,
                FocusedSynthesis = 67,
                FocusedTouch = 68,
                IntenseSynthesis = 78,
                AdvancedTouch = 84;
        }
    }
     
    internal class CarpenterAdvancedTouch : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DohTouchCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == DOH.AdvancedTouch)
            {
                //if (level >= DOH.Levels.PreciseTouch && HasEffect(DOH.Quality.???) && IsEnabled(CustomComboPreset.QualityOverrideFeature))
                //  return DOH.PreciseTouch;
                    
                if (comboTime > 0)
                {
                    if (lastComboMove == DOH.StandardTouch && level >= DOH.Levels.AdvancedTouch)
                        return DOH.AdvancedTouch;

                    if (lastComboMove == DOH.BasicTouch && level >= SAM.Levels.Jinpu)
                        return DOH.StandardTouch;
                }
                    return DOH.StandardTouch;

                return DOH.BasicTouch;
            }
            return actionID;
        }
    }
    
    internal class DohBasicSynthesis : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DohSynthesisFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == DOH.BasicSynthesis)
            {
                //if (level >= DOH.Levels.IntenseSynthesis && HasEffect(DOH.Quality.???) && IsEnabled(CustomComboPreset.QualityOverrideFeature))
                //  return DOH.IntenseSynthesis;
                
                return DOH.BasicSynthesis;
            }

            return actionID;
        }
    }

}
