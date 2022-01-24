using System;
using System.Linq;

using Dalamud.Game.ClientState.Conditions;
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
            TrueStrike = 54,
            ArmOfTheDestroyer = 62,
            Demolish = 66,
            PerfectBalance = 69,
            Rockbreaker = 70,
            Meditation = 3546,
            RiddleOfFire = 7395,
            Brotherhood = 7396,
            FourPointFury = 16473,
            Enlightenment = 16474,
            HowlingFist = 25763,
            MasterfulBlitz = 25764,
            RiddleOfWind = 25766,
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
                TrueStrike = 4,
                SnapPunch = 6,
                Meditation = 15,
                TwinSnakes = 18,
                ArmOfTheDestroyer = 26,
                Rockbreaker = 30,
                Demolish = 30,
                FourPointFury = 45,
                HowlingFist = 40,
                DragonKick = 50,
                PerfectBalance = 50,
                FormShift = 52,
                MasterfulBlitz = 60,
                RiddleOfFire = 68,
                Brotherhood = 70,
                Enlightenment = 70,
                RiddleOfWind = 72,
                ShadowOfTheDestroyer = 82;
        }
    }

    internal class MonkAoECombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MonkAoECombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MNK.MasterfulBlitz)
            {
                var gauge = new MyMNKGauge(GetJobGauge<MNKGauge>());

                // Blitz
                if (!gauge.BeastChakra.Contains(BeastChakra2.NONE))
                    return OriginalHook(MNK.MasterfulBlitz);

                if (level >= MNK.Levels.PerfectBalance && HasEffect(MNK.Buffs.PerfectBalance))
                {
                    // Solar or Both
                    if (!gauge.Nadi.HasFlag(Nadi.SOLAR) || gauge.Nadi.HasFlag(Nadi.LUNAR))
                    {
                        if (level >= MNK.Levels.FourPointFury && !gauge.BeastChakra.Contains(BeastChakra2.RAPTOR))
                            return MNK.FourPointFury;

                        if (level >= MNK.Levels.Rockbreaker && !gauge.BeastChakra.Contains(BeastChakra2.COEURL))
                            return MNK.Rockbreaker;

                        if (level >= MNK.Levels.ArmOfTheDestroyer && !gauge.BeastChakra.Contains(BeastChakra2.OPOOPO))
                            // Shadow of the Destroyer
                            return OriginalHook(MNK.ArmOfTheDestroyer);

                        return level >= MNK.Levels.ShadowOfTheDestroyer
                            ? MNK.ShadowOfTheDestroyer
                            : MNK.Rockbreaker;
                    }

                    // Lunar
                    if (!gauge.Nadi.HasFlag(Nadi.LUNAR))
                    {
                        return level >= MNK.Levels.ShadowOfTheDestroyer
                            ? MNK.ShadowOfTheDestroyer
                            : MNK.Rockbreaker;
                    }
                }

                // FPF with FormShift
                if (level >= MNK.Levels.FormShift && HasEffect(MNK.Buffs.FormlessFist))
                {
                    if (level >= MNK.Levels.FourPointFury)
                        return MNK.FourPointFury;
                }

                // 1-2-3 combo
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

            return actionID;
        }
    }

    internal class MonkHowlingFistEnlightenment : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MonkHowlingFistMeditationFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MNK.HowlingFist || actionID == MNK.Enlightenment)
            {
                var gauge = GetJobGauge<MNKGauge>();

                if (level >= MNK.Levels.Meditation && gauge.Chakra < 5)
                    return MNK.Meditation;
            }

            return actionID;
        }
    }

    internal class MonkDragonKick : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MnkAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MNK.DragonKick)
            {
                var gauge = GetJobGauge<MNKGauge>();

                if (IsEnabled(CustomComboPreset.MonkDragonKickMeditationFeature))
                {
                    if (level >= MNK.Levels.Meditation && gauge.Chakra < 5 && !HasCondition(ConditionFlag.InCombat))
                        return MNK.Meditation;
                }

                if (IsEnabled(CustomComboPreset.MonkDragonKickBalanceFeature))
                {
                    if (!gauge.BeastChakra.Contains(BeastChakra.NONE))
                        return OriginalHook(MNK.MasterfulBlitz);
                }

                if (IsEnabled(CustomComboPreset.MonkBootshineFeature) && !IsEnabled(CustomComboPreset.MonkDragonKickCombo))
                {
                    if (HasEffect(MNK.Buffs.LeadenFist))
                        return MNK.Bootshine;

                    if (level < MNK.Levels.DragonKick)
                        return MNK.Bootshine;
                }

                if (IsEnabled(CustomComboPreset.MonkDragonKickCombo))
                {
                    if (HasEffect(MNK.Buffs.OpoOpoForm) || HasEffect(MNK.Buffs.FormlessFist) || HasEffect(MNK.Buffs.PerfectBalance))
                    {
                        if (IsEnabled(CustomComboPreset.MonkBootshineFeature))
                        {
                            if (HasEffect(MNK.Buffs.LeadenFist))
                                return MNK.Bootshine;
                        }

                        return actionID;
                    }

                    if (HasEffect(MNK.Buffs.RaptorForm)) return MNK.TwinSnakes;

                    if (HasEffect(MNK.Buffs.CoerlForm)) return MNK.Demolish;
                }
            }

            return actionID;
        }
    }

    internal class MonkBootshine : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MnkAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MNK.Bootshine && IsEnabled(CustomComboPreset.MonkBootshineCombo))
            {
                var gauge = GetJobGauge<MNKGauge>();

                if (IsEnabled(CustomComboPreset.MonkBootshineFeature) && IsEnabled(CustomComboPreset.MonkDragonKickMeditationFeature))
                {
                    if (level >= MNK.Levels.Meditation && gauge.Chakra < 5 && !HasCondition(ConditionFlag.InCombat))
                        return MNK.Meditation;
                }

                if (IsEnabled(CustomComboPreset.MonkBootshineFeature) && IsEnabled(CustomComboPreset.MonkDragonKickBalanceFeature))
                {
                    if (!gauge.BeastChakra.Contains(BeastChakra.NONE))
                        return OriginalHook(MNK.MasterfulBlitz);
                }

                if (IsEnabled(CustomComboPreset.MonkDragonKickCombo))
                {
                    if (HasEffect(MNK.Buffs.OpoOpoForm) || HasEffect(MNK.Buffs.FormlessFist) || HasEffect(MNK.Buffs.PerfectBalance))
                    {
                        if (IsEnabled(CustomComboPreset.MonkBootshineFeature))
                        {
                            if (!HasEffect(MNK.Buffs.LeadenFist) && level >= MNK.Levels.DragonKick)
                                return MNK.DragonKick;
                        }

                        return actionID;
                    }

                    if (HasEffect(MNK.Buffs.RaptorForm)) return level < MNK.Levels.TrueStrike ? MNK.Bootshine : MNK.TrueStrike;

                    if (HasEffect(MNK.Buffs.CoerlForm)) return level < MNK.Levels.SnapPunch ? MNK.Bootshine : MNK.SnapPunch;
                }
            }

            return actionID;
        }
    }

    internal class MonkPerfectBalance : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MonkPerfectBalanceFeature;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MNK.PerfectBalance)
            {
                var gauge = GetJobGauge<MNKGauge>();

                if (!gauge.BeastChakra.Contains(BeastChakra.NONE) && level >= MNK.Levels.MasterfulBlitz)
                    // Chakra actions
                    return OriginalHook(MNK.MasterfulBlitz);
            }

            return actionID;
        }
    }

    internal class MonkRiddleOfFire : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MnkAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == MNK.RiddleOfFire)
            {
                if (IsEnabled(CustomComboPreset.MonkRiddleOfFireBrotherhood))
                {
                    if (level >= MNK.Levels.Brotherhood && IsOffCooldown(MNK.Brotherhood) && IsOnCooldown(MNK.RiddleOfFire))
                        return MNK.Brotherhood;
                }

                if (IsEnabled(CustomComboPreset.MonkRiddleOfFireWind))
                {
                    if (level >= MNK.Levels.RiddleOfWind && IsOffCooldown(MNK.RiddleOfWind) && IsOnCooldown(MNK.RiddleOfFire))
                        return MNK.RiddleOfWind;
                }
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

        public BeastChakra2[] BeastChakra => new[]
        {
            *(BeastChakra2*)(this.address + 0x9),
            *(BeastChakra2*)(this.address + 0xA),
            *(BeastChakra2*)(this.address + 0xB),
        };

        public Nadi Nadi => *(Nadi*)(this.address + 0xC);

        public ushort BlitzTimeRemaining => *(ushort*)(this.address + 0xE);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "Pending PR")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:Enumeration items should be documented", Justification = "Pending PR")]
    internal enum BeastChakra2 : byte
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
