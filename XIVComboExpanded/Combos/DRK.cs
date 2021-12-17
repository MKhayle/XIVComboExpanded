namespace XIVComboExpandedPlugin.Combos
{
    internal static class DRK
    {
        public const byte JobID = 32;

        public const uint
            HardSlash = 3617,
            Unleash = 3621,
            SyphonStrike = 3623,
            Souleater = 3632,
            SaltedEarth = 3639,
            AbyssalDrain = 3641,
            CarveAndSpit = 3643,
            Quietus = 7391,
            Bloodspiller = 7392,
            FloodOfDarkness = 16466,
            EdgeOfDarkness = 16467,
            StalwartSoul = 16468,
            FloodOfShadow = 16469,
            EdgeOfShadow = 16470,
            SaltAndDarkness = 25755,
            Shadowbringer = 25757;

        public static class Buffs
        {
            public const ushort
                BloodWeapon = 742,
                Darkside = 751,
                Delirium = 1972;
        }

        public static class Debuffs
        {
            public const ushort
                Placeholder = 0;
        }

        public static class Levels
        {
            public const byte
                SyphonStrike = 2,
                Souleater = 26,
                FloodOfDarkness = 30,
                EdgeOfDarkness = 40,
                SaltedEarth = 52,
                AbyssalDrain = 56,
                CarveAndSpit = 60,
                Bloodpiller = 62,
                Quietus = 64,
                Delirium = 68,
                StalwartSoul = 72,
                Shadow = 74,
                SaltAndDarkness = 86,
                Shadowbringer = 90;
        }
    }

    internal class DarkSouleaterCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;

        protected internal override uint[] ActionIDs { get; } = new[] { DRK.Souleater };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == DRK.Souleater)
            {
                if (IsEnabled(CustomComboPreset.DarkDeliriumFeature))
                {
                    if (level >= DRK.Levels.Bloodpiller && level >= DRK.Levels.Delirium && HasEffect(DRK.Buffs.Delirium))
                        return DRK.Bloodspiller;
                }

                if (IsEnabled(CustomComboPreset.DarkSouleaterCombo))
                {
                    if (comboTime > 0)
                    {
                        if (lastComboMove == DRK.SyphonStrike && level >= DRK.Levels.Souleater)
                            return DRK.Souleater;

                        if (lastComboMove == DRK.HardSlash && level >= DRK.Levels.SyphonStrike)
                            return DRK.SyphonStrike;
                    }

                    return DRK.HardSlash;
                }
            }

            return actionID;
        }
    }

    internal class DarkStalwartSoulCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;

        protected internal override uint[] ActionIDs { get; } = new[] { DRK.StalwartSoul };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == DRK.StalwartSoul)
            {
                if (IsEnabled(CustomComboPreset.DarkDeliriumFeature))
                {
                    if (level >= DRK.Levels.Quietus && level >= DRK.Levels.Delirium && HasEffect(DRK.Buffs.Delirium))
                        return DRK.Quietus;
                }

                if (IsEnabled(CustomComboPreset.DarkStalwartSoulCombo))
                {
                    if (comboTime > 0)
                    {
                        if (lastComboMove == DRK.Unleash && level >= DRK.Levels.StalwartSoul)
                            return DRK.StalwartSoul;
                    }

                    return DRK.Unleash;
                }
            }

            return actionID;
        }
    }

    internal class DarkShadowbringerFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.Disabled; // DarkShadowbringerFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { DRK.CarveAndSpit, DRK.AbyssalDrain };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == DRK.CarveAndSpit || actionID == DRK.AbyssalDrain)
            {
                if (level >= DRK.Levels.Shadowbringer)
                    return CalcBestAction(actionID, actionID, DRK.Shadowbringer, DRK.SaltedEarth, DRK.SaltAndDarkness);

                if (level >= DRK.Levels.SaltAndDarkness)
                    return CalcBestAction(actionID, actionID, DRK.SaltedEarth, DRK.SaltAndDarkness);

                if (level >= DRK.Levels.AbyssalDrain) // or CarveAndSpit
                    return CalcBestAction(actionID, actionID, DRK.SaltedEarth);

                if (level >= DRK.Levels.SaltedEarth)
                    return DRK.SaltedEarth;
            }

            return actionID;
        }
    }
}
