using System;
using System.Linq;

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
            MasterfulBlitz = 25764,
            ShadowOfTheDestroyer = 25767;

        public static class Buffs
        {
            public const ushort
                TwinSnakes = 101,
                OpoOpoForm = 107,
                RaptorForm = 108,
                CoerlForm = 109,
                PerfectBalance = 110,
                LeadenFist = 1861,
                FormlessFist = 2513,
                DisciplinedFist = 3001;
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
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MnkAny;

        protected internal override uint[] ActionIDs { get; } = new[] { MNK.Rockbreaker, MNK.FourPointFury };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MNK.Rockbreaker)
            {
                var gauge = new MyMNKGauge(GetJobGauge<MNKGauge>());

                if (IsEnabled(CustomComboPreset.MonkAoEBalanceFeature))
                {
                    if (!gauge.BeastChakra.Contains(BeastChakra.NONE))
                        return OriginalHook(MNK.MasterfulBlitz);
                }

                if (IsEnabled(CustomComboPreset.MonkAoESolarFeature))
                {
                    if (level >= MNK.Levels.PerfectBalance && HasEffect(MNK.Buffs.PerfectBalance) && (!gauge.Nadi.HasFlag(Nadi.SOLAR) || gauge.Nadi == (Nadi.LUNAR | Nadi.SOLAR)))
                    {
                        // Refresh Disciplined Fist if missing or about to expire
                        var fist = FindEffect(MNK.Buffs.DisciplinedFist);
                        if (level >= MNK.Levels.FourPointFury && !gauge.BeastChakra.Contains(BeastChakra.RAPTOR) && (fist == null || fist.RemainingTime < 3))
                            return MNK.FourPointFury;

                        if (level >= MNK.Levels.ArmOfTheDestroyer && !gauge.BeastChakra.Contains(BeastChakra.OPOOPO))
                            // Shadow of the Destroyer
                            return OriginalHook(MNK.ArmOfTheDestroyer);

                        if (level >= MNK.Levels.Rockbreaker && !gauge.BeastChakra.Contains(BeastChakra.COEURL))
                            return MNK.Rockbreaker;

                        if (level >= MNK.Levels.FourPointFury && !gauge.BeastChakra.Contains(BeastChakra.RAPTOR))
                            return MNK.FourPointFury;

                        return level >= MNK.Levels.ShadowOfTheDestroyer
                            ? MNK.ShadowOfTheDestroyer
                            : MNK.Rockbreaker;
                    }
                }

                if (IsEnabled(CustomComboPreset.MonkAoELunarFeature))
                {
                    if (level >= MNK.Levels.PerfectBalance && HasEffect(MNK.Buffs.PerfectBalance) && !gauge.Nadi.HasFlag(Nadi.LUNAR))
                    {
                        return level >= MNK.Levels.ShadowOfTheDestroyer
                            ? MNK.ShadowOfTheDestroyer
                            : MNK.Rockbreaker;
                    }
                }

                if (IsEnabled(CustomComboPreset.MonkAoEDisciplinedFeature))
                {
                    if (level >= MNK.Levels.FormShift && HasEffect(MNK.Buffs.FormlessFist))
                    {
                        if (level >= MNK.Levels.FourPointFury)
                            return MNK.FourPointFury;
                    }
                }

                if (IsEnabled(CustomComboPreset.MonkAoECombo))
                {
                    if (level >= MNK.Levels.FourPointFury && HasEffect(MNK.Buffs.RaptorForm))
                        return MNK.FourPointFury;

                    if (level >= MNK.Levels.ArmOfTheDestroyer && HasEffect(MNK.Buffs.OpoOpoForm))
                        // Shadow of the Destroyer
                        return OriginalHook(MNK.ArmOfTheDestroyer);

                    if (level >= MNK.Levels.Rockbreaker && HasEffect(MNK.Buffs.CoerlForm))
                        return MNK.Rockbreaker;

                    // Shadow of the Destroyer
                    return OriginalHook(MNK.ArmOfTheDestroyer);
                }
            }

            if (actionID == MNK.FourPointFury)
            {
                if (IsEnabled(CustomComboPreset.MonkAoEFpfFeature))
                {
                    if (level >= MNK.Levels.PerfectBalance && HasEffect(MNK.Buffs.PerfectBalance))
                    {
                        return level >= MNK.Levels.ShadowOfTheDestroyer
                            ? MNK.ShadowOfTheDestroyer
                            : MNK.Rockbreaker;
                    }
                }
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
                var gauge = new MyMNKGauge(GetJobGauge<MNKGauge>());

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
                var gauge = new MyMNKGauge(GetJobGauge<MNKGauge>());

                if (!gauge.BeastChakra.Contains(BeastChakra.NONE))
                    return OriginalHook(MNK.MasterfulBlitz);
            }

            return actionID;
        }
    }

    internal unsafe class MyMNKGauge
    {
        private readonly IntPtr address;

        internal MyMNKGauge(MNKGauge gauge)
        {
            this.address = gauge.Address;
        }

        public byte Chakra => *(byte*)(this.address + 0x8);

        public BeastChakra[] BeastChakra => new[]
        {
            *(BeastChakra*)(this.address + 0x9),
            *(BeastChakra*)(this.address + 0xA),
            *(BeastChakra*)(this.address + 0xB),
        };

        public Nadi Nadi => *(Nadi*)(this.address + 0xC);

        public ushort BlitzTimeRemaining => *(ushort*)(this.address + 0xE);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "Pending PR")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:Enumeration items should be documented", Justification = "Pending PR")]
    internal enum BeastChakra : byte
    {
        NONE = 0,
        COEURL = 1,
        OPOOPO = 2,
        RAPTOR = 3,
    }

    [Flags]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:Enumeration items should be documented", Justification = "Pending PR")]
    internal enum Nadi : byte
    {
        NONE = 0,
        LUNAR = 2,
        SOLAR = 4,
    }
}
