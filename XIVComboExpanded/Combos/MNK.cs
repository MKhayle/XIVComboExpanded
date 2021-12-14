using System.Linq;

using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos
{
    internal static class MNK
    {
        public const byte ClassID = 2;
        public const byte JobID = 20;

        public const uint
            Bootshine = 53,
            DragonKick = 74,
            SnapPunch = 56,
            TwinSnakes = 61,
            ArmOfTheDestroyer = 62,
            Demolish = 66,
            PerfectBalance = 69,
            Rockbreaker = 70,
            Meditation = 3546,
            FourPointFury = 16473,
            Enlightenment = 16474,
            HowlingFist = 25763,
            MasterfulBlitz = 25764;

        public static class Buffs
        {
            public const ushort
                TwinSnakes = 101,
                OpoOpoForm = 107,
                RaptorForm = 108,
                CoerlForm = 109,
                PerfectBalance = 110,
                LeadenFist = 1861,
                FormlessFist = 2513;
        }

        public static class Debuffs
        {
            public const ushort
                Demolish = 246;
        }

        public static class Levels
        {
            public const byte
                Meditation = 15,
                ArmOfTheDestroyer = 26,
                Rockbreaker = 30,
                Demolish = 30,
                FourPointFury = 45,
                HowlingFist = 40,
                DragonKick = 50,
                PerfectBalance = 50,
                FormShift = 52,
                MasterfulBlitz = 60,
                Enlightenment = 70,
                ShadowOfTheDestroyer = 82;
        }
    }

    internal class MonkAoECombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MonkAoECombo;

        protected internal override uint[] ActionIDs { get; } = new[] { MNK.Rockbreaker, MNK.FourPointFury };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MNK.Rockbreaker || actionID == MNK.FourPointFury)
            {
                if (IsEnabled(CustomComboPreset.MonkAoEBalanceFeature))
                {
                    var gauge = GetJobGauge<MNKGauge>();

                    if (!gauge.BeastChakra.Contains(BeastChakra.NONE))
                        return OriginalHook(MNK.MasterfulBlitz);
                }
            }

            if (actionID == MNK.Rockbreaker)
            {
                if (level >= MNK.Levels.PerfectBalance && HasEffect(MNK.Buffs.PerfectBalance))
                    return MNK.Rockbreaker;

                if (level >= MNK.Levels.FormShift && HasEffect(MNK.Buffs.FormlessFist))
                    return MNK.Rockbreaker;

                if (level >= MNK.Levels.ArmOfTheDestroyer && HasEffect(MNK.Buffs.OpoOpoForm))
                    // Shadow of the Destroyer
                    return OriginalHook(MNK.ArmOfTheDestroyer);

                if (level >= MNK.Levels.FourPointFury && HasEffect(MNK.Buffs.RaptorForm))
                    return MNK.FourPointFury;

                if (level >= MNK.Levels.Rockbreaker && HasEffect(MNK.Buffs.CoerlForm))
                    return MNK.Rockbreaker;

                // Shadow of the Destroyer
                return OriginalHook(MNK.ArmOfTheDestroyer);
            }

            if (actionID == MNK.FourPointFury)
            {
                var gauge = GetJobGauge<MNKGauge>();

                if (level >= MNK.Levels.ArmOfTheDestroyer && !gauge.BeastChakra.Contains(BeastChakra.OPOOPO))
                    // Shadow of the Destroyer
                    return OriginalHook(MNK.ArmOfTheDestroyer);

                if (level >= MNK.Levels.FourPointFury && !gauge.BeastChakra.Contains(BeastChakra.RAPTOR))
                    return MNK.FourPointFury;

                if (level >= MNK.Levels.Rockbreaker && !gauge.BeastChakra.Contains(BeastChakra.COEURL))
                    return MNK.Rockbreaker;

                // Shadow of the Destroyer
                return OriginalHook(MNK.ArmOfTheDestroyer);
            }

            return actionID;
        }
    }

    internal class MonkHowlingFistMeditationFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MonkHowlingFistMeditationFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { MNK.HowlingFist, MNK.Enlightenment };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MNK.HowlingFist || actionID == MNK.Enlightenment)
            {
                var gauge = GetJobGauge<MNKGauge>();

                if (level >= MNK.Levels.Meditation && gauge.Chakra < 5)
                    return MNK.Meditation;

                // Enlightenment
                return OriginalHook(MNK.HowlingFist);
            }

            return actionID;
        }
    }

    internal class MonkPerfectBalanceFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MonkPerfectBalanceFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { MNK.PerfectBalance };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MNK.PerfectBalance)
            {
                var gauge = GetJobGauge<MNKGauge>();

                if (!gauge.BeastChakra.Contains(BeastChakra.NONE))
                    return OriginalHook(MNK.MasterfulBlitz);
            }

            return actionID;
        }
    }
}
