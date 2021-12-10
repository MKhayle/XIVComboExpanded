using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos
{
    internal static class SMN
    {
        public const byte ClassID = 26;
        public const byte JobID = 27;

        public const uint
            Ruin = 163,
            Ruin2 = 172,
            Fester = 181,
            Painflare = 3578,
            Ruin3 = 3579,
            Ruin4 = 7426,
            EnkindleBahamut = 7429,
            EnergySyphon = 16510,
            Outburst = 16511,
            EnergyDrain = 16508,
            SummonCarbuncle = 25798,
            RadiantAegis = 25799,
            SearingLight = 25801,
            TriDisaster = 25826,
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
                Gemshine = 6,
                EnergyDrain = 10,
                PreciousBrilliance = 26,
                Painflare = 40,
                EnergySyphon = 52,
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

                if (level >= SMN.Levels.EnergyDrain && !gauge.HasAetherflowStacks)
                    return SMN.EnergyDrain;
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

                if (level >= SMN.Levels.EnergySyphon && !gauge.HasAetherflowStacks)
                    return SMN.EnergySyphon;
            }

            return actionID;
        }
    }

    internal class SummonerShinyRuinFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SummonerShinyRuinFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { SMN.Ruin, SMN.Ruin2, SMN.Ruin3 };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SMN.Ruin || actionID == SMN.Ruin2 || actionID == SMN.Ruin3)
            {
                var gauge = GetJobGauge<SMNGauge>();

                if (level >= SMN.Levels.Gemshine && (gauge.IsIfritAttuned || gauge.IsTitanAttuned || gauge.IsGarudaAttuned))
                    return OriginalHook(SMN.Gemshine);

                if (IsEnabled(CustomComboPreset.SummonerShinyRuinFeature))
                {
                    if (level >= SMN.Levels.Ruin4 && gauge.SummonTimerRemaining == 0 && gauge.AttunmentTimerRemaining == 0 && HasEffect(SMN.Buffs.FurtherRuin))
                        return SMN.Ruin4;
                }
            }

            return actionID;
        }
    }

    internal class SummonerShinyOutburstFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SummonerShinyOutburstFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { SMN.Outburst, SMN.TriDisaster };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SMN.Outburst || actionID == SMN.TriDisaster)
            {
                var gauge = GetJobGauge<SMNGauge>();

                if (level >= SMN.Levels.PreciousBrilliance && (gauge.IsIfritAttuned || gauge.IsTitanAttuned || gauge.IsGarudaAttuned))
                    return OriginalHook(SMN.PreciousBrilliance);

                if (IsEnabled(CustomComboPreset.SummonerFurtherOutburstFeature))
                {
                    if (level >= SMN.Levels.Ruin4 && gauge.SummonTimerRemaining == 0 && gauge.AttunmentTimerRemaining == 0 && HasEffect(SMN.Buffs.FurtherRuin))
                        return SMN.Ruin4;
                }
            }

            return actionID;
        }
    }

    internal class SummonerFurtherRuinFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SummonerFurtherRuinFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { SMN.Ruin, SMN.Ruin2, SMN.Ruin3 };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SMN.Ruin || actionID == SMN.Ruin2 || actionID == SMN.Ruin3)
            {
                var gauge = GetJobGauge<SMNGauge>();

                if (level >= SMN.Levels.Ruin4 && gauge.SummonTimerRemaining == 0 && gauge.AttunmentTimerRemaining == 0 && HasEffect(SMN.Buffs.FurtherRuin))
                    return SMN.Ruin4;
            }

            return actionID;
        }
    }

    internal class SummonerFurtherOutburstFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.SummonerFurtherOutburstFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { SMN.Outburst, SMN.TriDisaster };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == SMN.Outburst || actionID == SMN.TriDisaster)
            {
                var gauge = GetJobGauge<SMNGauge>();

                if (level >= SMN.Levels.Ruin4 && gauge.SummonTimerRemaining == 0 && gauge.AttunmentTimerRemaining == 0 && HasEffect(SMN.Buffs.FurtherRuin))
                    return SMN.Ruin4;
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
                    // Rekindle
                    return OriginalHook(SMN.EnkindleBahamut);
            }

            return actionID;
        }
    }
}
