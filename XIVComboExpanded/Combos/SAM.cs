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
        MidareSetsugekka = 7487,
        TenkaGoken = 7488,
        Higanbana = 7489,
        TsubameGaeshi = 16483,
        KaeshiGoken = 16485,
        KaeshiSetsugekka = 16486,
        TendoGoken = 36965,
        TendoSetsugekka = 36966,
        TendoKaeshiGoken = 36967,
        TendoKaeshiSetsugekka = 36968,
        // Misc
        HissatsuShinten = 7490,
        HissatsuKyuten = 7491,
        HissatsuSenei = 16481,
        HissatsuGuren = 7496,
        Ikishoten = 16482,
        Shoha = 16487,
        OgiNamikiri = 25781,
        KaeshiNamikiri = 25782,
        Zanshin = 36964;

    public static class Buffs
    {
        public const ushort
            MeikyoShisui = 1233,
            EyesOpen = 1252,
            Fugetsu = 1298, // From Jinpu and Mangetsu
            Fuka = 1299,    // From Shifu and Oka
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
            Enpi = 15,
            Shifu = 18,
            Fuga = 26,
            Gekko = 30,
            Higanbana = 30,
            Mangetsu = 35,
            Kasha = 40,
            TenkaGoken = 40,
            Oka = 45,
            Yukikaze = 50,
            MeikyoShisui = 50,
            MidareSetsugekka = 50,
            HissatsuShinten = 52,
            HissatsuGyoten = 54,
            HissatsuYaten = 56,
            HissatsuKyuten = 64,
            Ikishoten = 68,
            HissatsuGuren = 70,
            HissatsuSenei = 72,
            TsubameGaeshi = 74,
            Shoha = 80,
            Hyosetsu = 86,
            Fuko = 86,
            OgiNamikiri = 90,
            Zanshin = 96,
            Tendo = 100;
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

                if ((lastComboMove == SAM.Hakaze || lastComboMove == SAM.Gyofu) && level >= SAM.Levels.Yukikaze)
                    return SAM.Yukikaze;

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

                if (lastComboMove == SAM.Jinpu && level >= SAM.Levels.Gekko)
                    return SAM.Gekko;

                if ((lastComboMove == SAM.Hakaze || lastComboMove == SAM.Gyofu) && level >= SAM.Levels.Jinpu)
                    return SAM.Jinpu;

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

                if (lastComboMove == SAM.Shifu && level >= SAM.Levels.Kasha)
                    return SAM.Kasha;

                if ((lastComboMove == SAM.Hakaze || lastComboMove == SAM.Gyofu) && level >= SAM.Levels.Shifu)
                    return SAM.Shifu;

                if (IsEnabled(CustomComboPreset.SamuraiKashaOption))
                    return SAM.Shifu;

                return OriginalHook(SAM.Hakaze);
        }

        return actionID;
    }
}

internal class SamuraiMangetsu : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiAoECombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.Mangetsu || actionID == SAM.Oka)
        {
            if (level >= SAM.Levels.Mangetsu && level < SAM.Levels.Oka)
                return SAM.Mangetsu;

            if (level > SAM.Levels.Fuga && level < SAM.Levels.Mangetsu)
                return SAM.Fuga;

            var iaijutsu = OriginalHook(SAM.Iaijutsu);
            var tsubame = OriginalHook(SAM.TsubameGaeshi);

            if (level >= SAM.Levels.TsubameGaeshi && IsEnabled(CustomComboPreset.SamuraiAutoAoEFinaleFeature) &&
                IsEnabled(CustomComboPreset.SamuraiIaijutsuTsubameGaeshiFeature) &&
                (tsubame == SAM.KaeshiGoken || tsubame == SAM.TendoKaeshiGoken))
                return tsubame;

            if (level >= SAM.Levels.TenkaGoken && IsEnabled(CustomComboPreset.SamuraiAutoAoEFinaleFeature) &&
                (iaijutsu == SAM.TenkaGoken || iaijutsu == SAM.TendoGoken))
                return iaijutsu;

            var gauge = GetJobGauge<SAMGauge>();
            var fuka = FindEffect(SAM.Buffs.Fuka);
            var fukaTime = fuka != null ? fuka.RemainingTime : 0;
            var fugetsu = FindEffect(SAM.Buffs.Fugetsu);
            var fugetsuTime = fugetsu != null ? fugetsu.RemainingTime : 0;

            if ((level >= SAM.Levels.Oka && (lastComboMove == SAM.Fuga || lastComboMove == SAM.Fuko)) ||
                (level >= SAM.Levels.MeikyoShisui && HasEffect(SAM.Buffs.MeikyoShisui)))
            {
                if (IsEnabled(CustomComboPreset.SamuraiAutoAoEFeature) && actionID == SAM.Mangetsu &&
                    gauge.HasGetsu && !gauge.HasKa)
                    return SAM.Oka;

                if (IsEnabled(CustomComboPreset.SamuraiAutoAoEFeature) && actionID == SAM.Oka &&
                    !gauge.HasGetsu && gauge.HasKa)
                    return SAM.Mangetsu;

                if (IsEnabled(CustomComboPreset.SamuraiAutoAoEBuffFeature) && actionID == SAM.Mangetsu &&
                    (gauge.HasGetsu == gauge.HasKa) && fukaTime < fugetsuTime)
                    return SAM.Oka;

                if (IsEnabled(CustomComboPreset.SamuraiAutoAoEBuffFeature) && actionID == SAM.Oka &&
                    (gauge.HasGetsu == gauge.HasKa) && fugetsuTime < fukaTime)
                    return SAM.Mangetsu;

                return actionID;
            }

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

            if (level >= SAM.Levels.TsubameGaeshi && IsEnabled(CustomComboPreset.SamuraiIaijutsuTsubameGaeshiFeature) &&
                CanUseAction(OriginalHook(SAM.TsubameGaeshi)) && (OriginalHook(SAM.Iaijutsu) != SAM.Higanbana ||
                !IsEnabled(CustomComboPreset.SamuraiIaijutsuSingleSenNoReplaceTsubameFeature)))
                return OriginalHook(SAM.TsubameGaeshi);
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

            if (IsEnabled(CustomComboPreset.SamuraiShintenShohaFeature))
            {
                if (level >= SAM.Levels.Shoha && gauge.MeditationStacks >= 3)
                    return SAM.Shoha;
            }

            if (IsEnabled(CustomComboPreset.SamuraiShintenZanshinFeature))
            {
                if (level >= SAM.Levels.Zanshin && HasEffect(SAM.Buffs.ZanshinReady))
                    return SAM.Zanshin;
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
        }

        return actionID;
    }
}

internal class SamuraiGuren : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == SAM.HissatsuGuren)
        {
            var gauge = GetJobGauge<SAMGauge>();

            if (IsEnabled(CustomComboPreset.SamuraiGurenZanshinFeature))
            {
                if (level >= SAM.Levels.Zanshin && HasEffect(SAM.Buffs.ZanshinReady))
                    return SAM.Zanshin;
            }

            if (IsEnabled(CustomComboPreset.SamuraiGurenShohaFeature))
            {
                if (level >= SAM.Levels.Shoha && gauge.MeditationStacks >= 3)
                    return SAM.Shoha;
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
