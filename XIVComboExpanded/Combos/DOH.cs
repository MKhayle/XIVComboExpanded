using System;
using System.Collections.Generic;

namespace XIVComboExpandedPlugin.Combos
{
    internal static class DOH
    {
        public const byte ClassID = 0;
        public const byte JobID = 50;

        public const uint
            // Basic Touch
            CrpBasicTouch = 100002,
            BsmBasicTouch = 100016,
            ArmBasicTouch = 100031,
            LtwBasicTouch = 100046,
            WvrBasicTouch = 100061,
            GsmBasicTouch = 100076,
            AlcBasicTouch = 100091,
            CulBasicTouch = 100106,
            // Standard Touch
            CrpStandardTouch = 100004,
            BsmStandardTouch = 100018,
            ArmStandardTouch = 100034,
            LtwStandardTouch = 100048,
            WvrStandardTouch = 100064,
            GsmStandardTouch = 100078,
            AlcStandardTouch = 100093,
            CulStandardTouch = 100109,
            CrpAdvancedTouch = 100411,
            // Advanced Touch
            BsmAdvancedTouch = 100412,
            ArmAdvancedTouch = 100413,
            LtwAdvancedTouch = 100415,
            WvrAdvancedTouch = 100416,
            GsmAdvancedTouch = 100414,
            AlcAdvancedTouch = 100417,
            CulAdvancedTouch = 100418,
            Placeholder = 0;

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
                StandardTouch = 18,
                AdvancedTouch = 84;
        }
    }

    internal class DolTouchCombo : CustomCombo
    {
        private static readonly Dictionary<uint, uint> StandardTouchMap = new()
        {
            { DOH.CrpBasicTouch, DOH.CrpStandardTouch },
            { DOH.BsmBasicTouch, DOH.BsmStandardTouch },
            { DOH.ArmBasicTouch, DOH.ArmStandardTouch },
            { DOH.LtwBasicTouch, DOH.LtwStandardTouch },
            { DOH.WvrBasicTouch, DOH.WvrStandardTouch },
            { DOH.GsmBasicTouch, DOH.GsmStandardTouch },
            { DOH.AlcBasicTouch, DOH.AlcStandardTouch },
            { DOH.CulBasicTouch, DOH.CulStandardTouch },
        };

        private static readonly Dictionary<uint, uint> AdvancedTouchMap = new()
        {
            { DOH.CrpBasicTouch, DOH.CrpAdvancedTouch },
            { DOH.BsmBasicTouch, DOH.BsmAdvancedTouch },
            { DOH.ArmBasicTouch, DOH.ArmAdvancedTouch },
            { DOH.LtwBasicTouch, DOH.LtwAdvancedTouch },
            { DOH.WvrBasicTouch, DOH.WvrAdvancedTouch },
            { DOH.GsmBasicTouch, DOH.GsmAdvancedTouch },
            { DOH.AlcBasicTouch, DOH.AlcAdvancedTouch },
            { DOH.CulBasicTouch, DOH.CulAdvancedTouch },
        };

        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.Disabled; // DohTouchCombo;

        protected internal override uint[] ActionIDs { get; } = new[]
        {
            DOH.CrpBasicTouch,
            DOH.BsmBasicTouch,
            DOH.ArmBasicTouch,
            DOH.LtwBasicTouch,
            DOH.WvrBasicTouch,
            DOH.GsmBasicTouch,
            DOH.AlcBasicTouch,
            DOH.CulBasicTouch,
        };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            var basic = actionID;
            var standard = StandardTouchMap[basic];
            var advanced = AdvancedTouchMap[basic];

            if (level >= DOH.Levels.StandardTouch && lastComboMove == basic)
                return standard;

            if (level >= DOH.Levels.AdvancedTouch && lastComboMove == standard)
                return advanced;

            return actionID;
        }
    }
}