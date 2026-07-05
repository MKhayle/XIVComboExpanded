using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

internal static class DRK
{
    public const byte JobID = 32;

    public const uint
        HardSlash = 3617,
        Unleash = 3621,
        SyphonStrike = 3623,
        Grit = 3629,
        Souleater = 3632,
        BloodWeapon = 3625,
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
        LivingShadow = 16472,
        SaltAndDarkness = 25755,
        Shadowbringer = 25757,
        GritRemoval = 32067,
        Delirium = 7390,
        ScarletDelirium = 36928,
        Comeuppance = 36929,
        Torcleaver = 36930,
        Impalement = 36931,
        Disesteem = 36932;

    public static class Buffs
    {
        public const ushort
            BloodWeapon = 742,
            Grit = 743,
            Darkside = 751,
            Delirium = 1972,
            ScarletDelirium = 3836,
            Scorn = 3837;
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
            Grit = 10,
            Souleater = 26,
            FloodOfDarkness = 30,
            BloodWeapon = 35,
            EdgeOfDarkness = 40,
            StalwartSoul = 40,
            SaltedEarth = 52,
            AbyssalDrain = 56,
            CarveAndSpit = 60,
            Bloodspiller = 62,
            Quietus = 64,
            Delirium = 68,
            Shadow = 74,
            LivingShadow = 80,
            SaltAndDarkness = 86,
            Shadowbringer = 90,
            ScarletDelirium = 96,
            Comeuppance = 96,
            Torcleaver = 96,
            Impalement = 96,
            Disesteem = 100;
    }
}

internal class DarkSouleater : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRK.Souleater)
        {
            var gauge = GetJobGauge<DRKGauge>();

            if (IsEnabled(CustomComboPreset.DarkDeliriumFeature))
            {
                if (
                    level >= DRK.Levels.Bloodspiller
                    && level >= DRK.Levels.Delirium
                    && (HasEffect(DRK.Buffs.Delirium) || HasEffect(DRK.Buffs.ScarletDelirium)))
                    return OriginalHook(DRK.Bloodspiller);
            }

            if (IsEnabled(CustomComboPreset.DarkSouleaterCombo))
            {
                if (IsEnabled(CustomComboPreset.DarkSouleaterOvercapFeature))
                {
                    if (IsEnabled(CustomComboPreset.DarkSouleaterOvercapOptimizedFeature))
                    {
                        if (level >= DRK.Levels.Bloodspiller && gauge.Blood > 70 && GetCooldown(DRK.Delirium).CooldownRemaining < 5.0)
                            return OriginalHook(DRK.Bloodspiller);
                    }
                    if (level >= DRK.Levels.Bloodspiller && gauge.Blood > 90 && HasEffect(DRK.Buffs.BloodWeapon))
                        return OriginalHook(DRK.Bloodspiller);
                }

                if (IsEnabled(CustomComboPreset.DarkDisesteemComboFeature))
                {
                    if (level >= DRK.Levels.Disesteem && HasEffect(DRK.Buffs.Scorn))
                        return DRK.Disesteem;
                }

                if (comboTime > 0)
                {
                    if (lastComboMove == DRK.SyphonStrike && level >= DRK.Levels.Souleater)
                    {
                        if (IsEnabled(CustomComboPreset.DarkSouleaterOvercapFeature))
                        {
                            if (level >= DRK.Levels.Bloodspiller && (gauge.Blood > 80 || (gauge.Blood > 70 && HasEffect(DRK.Buffs.BloodWeapon))))
                                return OriginalHook(DRK.Bloodspiller);
                        }

                        return DRK.Souleater;
                    }

                    if (lastComboMove == DRK.HardSlash && level >= DRK.Levels.SyphonStrike)
                        return DRK.SyphonStrike;
                }

                return DRK.HardSlash;
            }
        }

        return actionID;
    }
}

internal class DarkStalwartSoul : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRK.StalwartSoul)
        {
            var gauge = GetJobGauge<DRKGauge>();

            if (IsEnabled(CustomComboPreset.DarkDeliriumFeature))
            {
                if (
                    level >= DRK.Levels.Quietus
                    && level >= DRK.Levels.Delirium
                    && (HasEffect(DRK.Buffs.Delirium) || HasEffect(DRK.Buffs.ScarletDelirium)))
                    return OriginalHook(DRK.Quietus);
            }

            if (IsEnabled(CustomComboPreset.DarkStalwartSoulCombo))
            {
                if (IsEnabled(CustomComboPreset.DarkStalwartSoulOvercapFeature))
                {
                    if (IsEnabled(CustomComboPreset.DarkStalwartSoulOvercapOptimizedFeature))
                    {
                        if (level >= DRK.Levels.Quietus && gauge.Blood > 70 && GetCooldown(DRK.Delirium).CooldownRemaining < 5.0)
                            return OriginalHook(DRK.Quietus);
                    }
                    if (level >= DRK.Levels.Quietus && gauge.Blood > 90 && HasEffect(DRK.Buffs.BloodWeapon))
                        return OriginalHook(DRK.Quietus);
                }

                if (IsEnabled(CustomComboPreset.DarkDisesteemComboFeature))
                {
                    if (level >= DRK.Levels.Disesteem && HasEffect(DRK.Buffs.Scorn))
                        return DRK.Disesteem;
                }

                if (comboTime > 0)
                {
                    if (lastComboMove == DRK.Unleash && level >= DRK.Levels.StalwartSoul)
                    {
                        if (IsEnabled(CustomComboPreset.DarkStalwartSoulOvercapFeature))
                        {
                            if (level >= DRK.Levels.Quietus && (gauge.Blood > 80 || (gauge.Blood > 70 && HasEffect(DRK.Buffs.BloodWeapon))))
                                return OriginalHook(DRK.Quietus);
                        }

                        return DRK.StalwartSoul;
                    }
                }

                return DRK.Unleash;
            }
        }

        return actionID;
    }
}

internal class DarkCarveAndSpitAbyssalDrain : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRK.CarveAndSpit || actionID == DRK.AbyssalDrain)
        {
            if (IsEnabled(CustomComboPreset.DarkBloodWeaponFeature))
            {
                if (actionID == DRK.AbyssalDrain && level < DRK.Levels.AbyssalDrain)
                    return OriginalHook(DRK.BloodWeapon);

                if (actionID == DRK.CarveAndSpit && level < DRK.Levels.CarveAndSpit)
                    return OriginalHook(DRK.BloodWeapon);

                if (level >= DRK.Levels.BloodWeapon && IsCooldownUsable(DRK.BloodWeapon))
                    return OriginalHook(DRK.BloodWeapon);
            }
        }

        return actionID;
    }
}

internal class DarkQuietusBloodspiller : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRK.Quietus || actionID == DRK.Bloodspiller)
        {
            var gauge = GetJobGauge<DRKGauge>();

            if (IsEnabled(CustomComboPreset.DarkLivingShadowFeature))
            {
                if (level >= DRK.Levels.LivingShadow && IsCooldownUsable(DRK.LivingShadow))
                    return DRK.LivingShadow;
            }

            if (IsEnabled(CustomComboPreset.DarkDisesteemFeature))
            {
                if (level >= DRK.Levels.Disesteem && HasEffect(DRK.Buffs.Scorn))
                    return DRK.Disesteem;
            }
        }

        return actionID;
    }
}

internal class DarkLivingShadow : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRK.LivingShadow)
        {
            var gauge = GetJobGauge<DRKGauge>();

            if (IsEnabled(CustomComboPreset.DarkLivingShadowbringerFeature))
            {
                if (level >= DRK.Levels.Shadowbringer && gauge.ShadowTimeRemaining > 0 && IsCooldownUsable(DRK.Shadowbringer))
                    return DRK.Shadowbringer;
            }

            if (IsEnabled(CustomComboPreset.DarkLivingShadowbringerHpFeature))
            {
                if (level >= DRK.Levels.Shadowbringer && IsCooldownUsable(DRK.Shadowbringer) && !IsCooldownUsable(DRK.LivingShadow))
                    return DRK.Shadowbringer;
            }
        }

        return actionID;
    }
}
