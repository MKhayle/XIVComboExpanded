using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos
{
    internal static class SMN
    {
        public const byte ClassID = 26;
        public const byte JobID = 27;

        public const uint
            Fester = 181,
            Painflare = 3578,
            Ruin4 = 7426,
            EnkindleBahamut = 7429,
            EnergySyphon = 16510,
            EnergyDrain = 16508,
            SummonCarbuncle = 25798,
            RadiantAegis = 25799,
            SearingLight = 25801,
            Gemshine = 25883,
            PreciousBrilliance = 25884;

        public static class Buffs
        {
            public const ushort
                FurtherRuin = 2701;
        }

        public static class Debuffs
        {
            public const ushort
                Placeholder = 0;
        }

        public static class Levels
        {
            public const byte
                RadiantAegis = 2,
                Ruin3 = 54,
                Ruin4 = 62,
                SearingLight = 66,
                EnkindleBahamut = 70,
                Rekindle = 80,
                SummonPhoenix = 80;
        }
    }

    internal class SummonerEDFesterCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SummonerEDFesterFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { SMN.Fester };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SMN.Fester)
            {
                var gauge = GetJobGauge<SMNGauge>();

                if (!gauge.HasAetherflowStacks)
                    return SMN.EnergyDrain;

                if (IsEnabled(CustomComboPreset.SummonerFesterRuinFeature))
                {
                    if (level >= SMN.Levels.Ruin4 && HasEffect(SMN.Buffs.FurtherRuin))
                        return SMN.Ruin4;
                }

                return SMN.Fester;
            }

            return actionID;
        }
    }

    internal class SummonerESPainflareCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SummonerESPainflareFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { SMN.Painflare };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SMN.Painflare)
            {
                var gauge = GetJobGauge<SMNGauge>();

                if (!gauge.HasAetherflowStacks)
                    return SMN.EnergySyphon;

                if (IsEnabled(CustomComboPreset.SummonerPainflareRuinFeature))
                {
                    if (level >= SMN.Levels.Ruin4 && HasEffect(SMN.Buffs.FurtherRuin))
                        return SMN.Ruin4;
                }
            }

            return actionID;
        }
    }

    internal class SummonerDemiFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SummonerDemiFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { SMN.Gemshine, SMN.PreciousBrilliance };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SMN.Gemshine || actionID == SMN.PreciousBrilliance)
            {
                var gauge = GetJobGauge<SMNGauge>();

                if (level >= SMN.Levels.EnkindleBahamut && !gauge.IsIfritAttuned && !gauge.IsTitanAttuned && !gauge.IsGarudaAttuned)
                    return SMN.EnkindleBahamut;
            }

            return actionID;
        }
    }
}
