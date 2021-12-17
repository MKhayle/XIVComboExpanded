using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos
{
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
            Shoha2 = 25779,
            OgiNamikiri = 25781,
            KaeshiNamikiri = 25782;

        public static class Buffs
        {
            public const ushort
                MeikyoShisui = 1233,
                EyesOpen = 1252,
                Jinpu = 1298,
                Shifu = 1299,
                OgiNamikiriReady = 2959;
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
                Shoha2 = 82,
                Hyosetsu = 86,
                Fuko = 86,
                OgiNamikiri = 90;
        }
    }

    internal class SamuraiYukikazeCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiYukikazeCombo;

        protected internal override uint[] ActionIDs { get; } = new[] { SAM.Yukikaze };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.Yukikaze)
            {
                if (level >= SAM.Levels.MeikyoShisui && HasEffect(SAM.Buffs.MeikyoShisui))
                    return SAM.Yukikaze;

                if (comboTime > 0)
                {
                    if (lastComboMove == SAM.Hakaze && level >= SAM.Levels.Yukikaze)
                        return SAM.Yukikaze;
                }

                return SAM.Hakaze;
            }

            return actionID;
        }
    }

    internal class SamuraiGekkoCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiGekkoCombo;

        protected internal override uint[] ActionIDs { get; } = new[] { SAM.Gekko };

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

                    if (lastComboMove == SAM.Hakaze && level >= SAM.Levels.Jinpu)
                        return SAM.Jinpu;
                }

                if (IsEnabled(CustomComboPreset.SamuraiGekkoOption))
                    return SAM.Jinpu;

                return SAM.Hakaze;
            }

            return actionID;
        }
    }

    internal class SamuraiKashaCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiKashaCombo;

        protected internal override uint[] ActionIDs { get; } = new[] { SAM.Kasha };

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

                    if (lastComboMove == SAM.Hakaze && level >= SAM.Levels.Shifu)
                        return SAM.Shifu;
                }

                if (IsEnabled(CustomComboPreset.SamuraiKashaOption))
                    return SAM.Shifu;

                return SAM.Hakaze;
            }

            return actionID;
        }
    }

    internal class SamuraiMangetsuCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiMangetsuCombo;

        protected internal override uint[] ActionIDs { get; } = new[] { SAM.Mangetsu };

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

    internal class SamuraiOkaCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiOkaCombo;

        protected internal override uint[] ActionIDs { get; } = new[] { SAM.Oka };

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

    internal class SamuraiTsubameFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamAny;

        protected internal override uint[] ActionIDs { get; } = new[] { SAM.TsubameGaeshi };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.TsubameGaeshi)
            {
                var gauge = GetJobGauge<SAMGauge>();

                if (IsEnabled(CustomComboPreset.SamuraiTsubameGaeshiShohaFeature))
                {
                    if (level >= SAM.Levels.Shoha && gauge.MeditationStacks >= 3)
                        return SAM.Shoha;
                }

                if (IsEnabled(CustomComboPreset.SamuraiTsubameGaeshiIaijutsuFeature))
                {
                    if (level >= SAM.Levels.TsubameGaeshi && gauge.Sen == Sen.NONE)
                        return OriginalHook(SAM.TsubameGaeshi);

                    return OriginalHook(SAM.Iaijutsu);
                }
            }

            return actionID;
        }
    }

    internal class SamuraiIaijutsuFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamAny;

        protected internal override uint[] ActionIDs { get; } = new[] { SAM.Iaijutsu };

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

                if (IsEnabled(CustomComboPreset.SamuraiIaijutsuTsubameGaeshiFeature))
                {
                    if (level >= SAM.Levels.TsubameGaeshi && gauge.Sen == Sen.NONE)
                        return OriginalHook(SAM.TsubameGaeshi);

                    return OriginalHook(SAM.Iaijutsu);
                }
            }

            return actionID;
        }
    }

    internal class SamuraiShinten : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamAny;

        protected internal override uint[] ActionIDs { get; } = new[] { SAM.HissatsuShinten };

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

                if (IsEnabled(CustomComboPreset.SamuraiShintenSeneiFeature))
                {
                    if (level >= SAM.Levels.HissatsuSenei && GetCooldown(SAM.HissatsuSenei).CooldownRemaining == 0)
                        return SAM.HissatsuSenei;
                }
            }

            return actionID;
        }
    }

    internal class SamuraiKyuten : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamAny;

        protected internal override uint[] ActionIDs { get; } = new[] { SAM.HissatsuKyuten };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.HissatsuKyuten)
            {
                var gauge = GetJobGauge<SAMGauge>();

                if (IsEnabled(CustomComboPreset.SamuraiKyutenShoha2Feature))
                {
                    if (level >= SAM.Levels.Shoha2 && gauge.MeditationStacks >= 3)
                        return SAM.Shoha2;
                }

                if (IsEnabled(CustomComboPreset.SamuraiKyutenGurenFeature))
                {
                    if (level >= SAM.Levels.HissatsuGuren && GetCooldown(SAM.HissatsuGuren).CooldownRemaining == 0)
                        return SAM.HissatsuGuren;
                }
            }

            return actionID;
        }
    }

    internal class SamuraiIkishotenNamikiriFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SamuraiIkishotenNamikiriFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { SAM.Ikishoten };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SAM.Ikishoten)
            {
                if (level >= SAM.Levels.OgiNamikiri)
                {
                    var gauge = GetJobGauge<SAMGauge>();

                    if (level >= SAM.Levels.Shoha && gauge.MeditationStacks >= 3)
                        return SAM.Shoha;

                    if (gauge.Kaeshi == Kaeshi.NAMIKIRI)
                        return SAM.KaeshiNamikiri;

                    if (HasEffect(SAM.Buffs.OgiNamikiriReady))
                        return SAM.OgiNamikiri;
                }
            }

            return actionID;
        }
    }
}
