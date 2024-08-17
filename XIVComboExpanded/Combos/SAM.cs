using System.Linq;
using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

internal static class SAM
{
    public const byte JobID = 34;

    public const uint
        // Single target
        Hakaze = 7477,
        Jinpu = 7478,
        Shifu = 7479,
        Yukikaze = 7480,
        Gekko = 7481,
        Kasha = 7482,
        Gyofu = 36963,
        // AoE
        Fuga = 7483,
        Mangetsu = 7484,
        Oka = 7485,
        Fuko = 25780,
        // Iaijutsu and Tsubame
        Iaijutsu = 7867,
        TsubameGaeshi = 16483,
        KaeshiHiganbana = 16484,
        Shoha = 16487,
        // Misc
        HissatsuShinten = 7490,
        HissatsuKyuten = 7491,
        HissatsuSenei = 16481,
        HissatsuGuren = 7496,
        Ikishoten = 16482,
        // Shoha2 = 25779,
        OgiNamikiri = 25781,
        KaeshiNamikiri = 25782,
        Zanshin = 36964;

    public static class Buffs
    {
        public const ushort
            MeikyoShisui = 1233,
            EyesOpen = 1252,
            Jinpu = 1298,
            Shifu = 1299,
            OgiNamikiriReady = 2959,
            ZanshinReady = 3855;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            Jinpu = 4,
            Shifu = 18,
            Gekko = 30,
            Mangetsu = 35,
            Kasha = 40,
            Oka = 45,
            Yukikaze = 50,
            MeikyoShisui = 50,
            HissatsuKyuten = 64,
            HissatsuGuren = 70,
            HissatsuSenei = 72,
            TsubameGaeshi = 76,
            Shoha = 80,
            // Shoha2 = 82,
            Hyosetsu = 86,
            Fuko = 86,
            OgiNamikiri = 90,
            Zanshin = 96;
    }
}

internal class SamuraiYukikaze : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiYukikazeCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.Yukikaze)
        {
            if (level >= SAM.Levels.MeikyoShisui && HasEffect(SAM.Buffs.MeikyoShisui))
                return SAM.Yukikaze;

            if (comboTime > 0)
            {
                if ((lastComboMove == SAM.Hakaze || lastComboMove == SAM.Gyofu) && level >= SAM.Levels.Yukikaze)
                    return SAM.Yukikaze;
            }

            return OriginalHook(SAM.Hakaze);
        }

        return actionID;
    }
}

internal class SamuraiGekko : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiGekkoCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.Gekko)
        {
            if (level >= SAM.Levels.MeikyoShisui && HasEffect(SAM.Buffs.MeikyoShisui))
                return SAM.Gekko;

            if (comboTime > 0)
            {
                if (lastComboMove == SAM.Jinpu && level >= SAM.Levels.Gekko)
                    return SAM.Gekko;

                if ((lastComboMove == SAM.Hakaze || lastComboMove == SAM.Gyofu) && level >= SAM.Levels.Jinpu)
                    return SAM.Jinpu;
            }

            if (IsEnabled(CustomComboPreset.SamuraiGekkoOption))
                return SAM.Jinpu;

            return OriginalHook(SAM.Hakaze);
        }

        return actionID;
    }
}

internal class SamuraiKasha : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiKashaCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.Kasha)
        {
            if (level >= SAM.Levels.MeikyoShisui && HasEffect(SAM.Buffs.MeikyoShisui))
                return SAM.Kasha;

            if (comboTime > 0)
            {
                if (lastComboMove == SAM.Shifu && level >= SAM.Levels.Kasha)
                    return SAM.Kasha;

                if ((lastComboMove == SAM.Hakaze || lastComboMove == SAM.Gyofu) && level >= SAM.Levels.Shifu)
                    return SAM.Shifu;
            }

            if (IsEnabled(CustomComboPreset.SamuraiKashaOption))
                return SAM.Shifu;

            return OriginalHook(SAM.Hakaze);
        }

        return actionID;
    }
}

internal class SamuraiMangetsu : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiMangetsuCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.Mangetsu)
        {
            if (level >= SAM.Levels.MeikyoShisui && HasEffect(SAM.Buffs.MeikyoShisui))
                return SAM.Mangetsu;

            if (comboTime > 0)
            {
                if ((lastComboMove == SAM.Fuga || lastComboMove == SAM.Fuko) && level >= SAM.Levels.Mangetsu)
                    return SAM.Mangetsu;
            }

            // Fuko
            return OriginalHook(SAM.Fuga);
        }

        return actionID;
    }
}

internal class SamuraiOka : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiOkaCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.Oka)
        {
            if (level >= SAM.Levels.MeikyoShisui && HasEffect(SAM.Buffs.MeikyoShisui))
                return SAM.Oka;

            if (comboTime > 0)
            {
                if ((lastComboMove == SAM.Fuga || lastComboMove == SAM.Fuko) && level >= SAM.Levels.Oka)
                    return SAM.Oka;
            }

            // Fuko
            return OriginalHook(SAM.Fuga);
        }

        return actionID;
    }
}
internal class SamuraiIaijutsu : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.Iaijutsu)
        {
            var gauge = GetJobGauge<SAMGauge>();

            if (IsEnabled(CustomComboPreset.SamuraiIaijutsuShohaFeature))
            {
                if (level >= SAM.Levels.Shoha && gauge.MeditationStacks >= 3)
                    return SAM.Shoha;
            }

            if (IsEnabled(CustomComboPreset.SamuraiIaijutsuTsubameGaeshiFeature) && level >= SAM.Levels.TsubameGaeshi)
            {
                if (IsEnabled(CustomComboPreset.SamuraiIaijutsuSingleSenNoReplaceTsubameFeature))
                {
                    var hasSingleSen = new[] { gauge.HasSetsu, gauge.HasGetsu, gauge.HasKa }.Count(b => b) == 1;
                    if (hasSingleSen)
                    {
                        return actionID;
                    }
                }

                var original = OriginalHook(SAM.TsubameGaeshi);
                if (CanUseAction(original))
                    return original;
            }
        }

        return actionID;
    }
}

internal class SamuraiShinten : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.HissatsuShinten)
        {
            var gauge = GetJobGauge<SAMGauge>();

            if (IsEnabled(CustomComboPreset.SamuraiShintenIaijutsuFeature))
            {
                var original = OriginalHook(SAM.Iaijutsu);
                if (original != SAM.Iaijutsu && IsCooldownUsable(original))
                    return original;
            }

            if (IsEnabled(CustomComboPreset.SamuraiShintenTsubameGaeshiFeature))
            {
                var original = OriginalHook(SAM.TsubameGaeshi);
                if (original != SAM.Iaijutsu && IsCooldownUsable(original))
                    return original;
            }

            if (IsEnabled(CustomComboPreset.SamuraiShintenZanshinFeature))
            {
                if (level >= SAM.Levels.Zanshin && HasEffect(SAM.Buffs.ZanshinReady))
                    return SAM.Zanshin;
            }

            if (IsEnabled(CustomComboPreset.SamuraiShintenShohaFeature))
            {
                if (level >= SAM.Levels.Shoha && gauge.MeditationStacks >= 3)
                    return SAM.Shoha;
            }

            if (IsEnabled(CustomComboPreset.SamuraiShintenSeneiFeature))
            {
                if (level >= SAM.Levels.HissatsuSenei && IsCooldownUsable(SAM.HissatsuSenei))
                    return SAM.HissatsuSenei;

                if (IsEnabled(CustomComboPreset.SamuraiSeneiGurenFeature))
                {
                    if (level >= SAM.Levels.HissatsuGuren && level < SAM.Levels.HissatsuSenei && IsCooldownUsable(SAM.HissatsuGuren))
                        return SAM.HissatsuGuren;
                }
            }

            if (IsEnabled(CustomComboPreset.SamuraiShintenOgaNamikiriFeature))
            {
                if (gauge.Kaeshi == Kaeshi.NAMIKIRI)
                    return SAM.KaeshiNamikiri;

                if (HasEffect(SAM.Buffs.OgiNamikiriReady))
                    return SAM.OgiNamikiri;
            }
        }

        return actionID;
    }
}

internal class SamuraiSenei : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.HissatsuSenei)
        {
            if (IsEnabled(CustomComboPreset.SamuraiSeneiGurenFeature))
            {
                if (level >= SAM.Levels.HissatsuGuren && level < SAM.Levels.HissatsuSenei)
                    return SAM.HissatsuGuren;
            }
        }

        return actionID;
    }
}

internal class SamuraiKyuten : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.HissatsuKyuten)
        {
            var gauge = GetJobGauge<SAMGauge>();

            if (IsEnabled(CustomComboPreset.SamuraiKyutenIaijutsuFeature))
            {
                var original = OriginalHook(SAM.Iaijutsu);
                if (original != SAM.Iaijutsu && IsCooldownUsable(original))
                    return original;
            }

            if (IsEnabled(CustomComboPreset.SamuraiKyutenTsubameGaeshiFeature))
            {
                var original = OriginalHook(SAM.TsubameGaeshi);
                if (original != SAM.Iaijutsu && IsCooldownUsable(original))
                    return original;
            }

            if (IsEnabled(CustomComboPreset.SamuraiKyutenZanshinFeature))
            {
                if (level >= SAM.Levels.Zanshin && HasEffect(SAM.Buffs.ZanshinReady))
                    return SAM.Zanshin;
            }

            if (IsEnabled(CustomComboPreset.SamuraiKyutenShohaFeature))
            {
                if (level >= SAM.Levels.Shoha && gauge.MeditationStacks >= 3)
                    return SAM.Shoha;
            }

            if (IsEnabled(CustomComboPreset.SamuraiKyutenGurenFeature))
            {
                if (level >= SAM.Levels.HissatsuGuren && IsCooldownUsable(SAM.HissatsuGuren))
                    return SAM.HissatsuGuren;
            }

            if (IsEnabled(CustomComboPreset.SamuraiKyutenOgaNamikiriFeature))
            {
                if (gauge.Kaeshi == Kaeshi.NAMIKIRI)
                    return SAM.KaeshiNamikiri;

                if (HasEffect(SAM.Buffs.OgiNamikiriReady))
                    return SAM.OgiNamikiri;
            }
        }

        return actionID;
    }
}

internal class SamuraiIkishoten : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiIkishotenNamikiriFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.Ikishoten)
        {
            if (level >= SAM.Levels.OgiNamikiri)
            {
                var gauge = GetJobGauge<SAMGauge>();

                if (IsEnabled(CustomComboPreset.SamuraiIkishotenShohaFeature))
                {
                    if (level >= SAM.Levels.Shoha && gauge.MeditationStacks >= 3)
                        return SAM.Shoha;
                }

                if (gauge.Kaeshi == Kaeshi.NAMIKIRI)
                    return SAM.KaeshiNamikiri;

                if (HasEffect(SAM.Buffs.OgiNamikiriReady))
                    return SAM.OgiNamikiri;
            }
        }

        return actionID;
    }
}
