using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos
{
    internal static class WHM
    {
        public const byte ClassID = 6;
        public const byte JobID = 24;

        public const uint
            Cure = 120,
            Medica = 124,
            Cure2 = 135,
            AfflatusSolace = 16531,
            AfflatusRapture = 16534,
            AfflatusMisery = 16535;

        public static class Buffs
        {
            public const ushort
                Placeholder = 0;
        }

        public static class Debuffs
        {
            public const ushort
                Placeholder = 0;
        }

        public static class Levels
        {
            public const byte
                Cure2 = 30,
                AfflatusSolace = 52,
                AfflatusMisery = 74,
                AfflatusRapture = 76;
        }
    }

    internal class WhiteMageSolaceMiseryFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WhiteMageSolaceMiseryFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { WHM.AfflatusSolace };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == WHM.AfflatusSolace)
            {
                var gauge = GetJobGauge<WHMGauge>();

                if (level >= WHM.Levels.AfflatusMisery && gauge.BloodLily == 3)
                    return WHM.AfflatusMisery;
            }

            return actionID;
        }
    }

    internal class WhiteMageRaptureMiseryFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WhiteMageRaptureMiseryFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { WHM.AfflatusRapture };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == WHM.AfflatusRapture)
            {
                var gauge = GetJobGauge<WHMGauge>();

                if (level >= WHM.Levels.AfflatusMisery && gauge.BloodLily == 3)
                    return WHM.AfflatusMisery;
            }

            return actionID;
        }
    }

    internal class WhiteMageCureFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WhiteMageCureFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { WHM.Cure2 };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == WHM.Cure2)
            {
                if (level < WHM.Levels.Cure2)
                    return WHM.Cure;
            }

            return actionID;
        }
    }

    internal class WhiteMageAfflatusFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WhmAny;

        protected internal override uint[] ActionIDs { get; } = new[] { WHM.Cure2, WHM.Medica };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == WHM.Cure2)
            {
                var gauge = GetJobGauge<WHMGauge>();

                if (IsEnabled(CustomComboPreset.WhiteMageSolaceMiseryFeature))
                {
                    if (level >= WHM.Levels.AfflatusMisery && gauge.BloodLily == 3)
                        return WHM.AfflatusMisery;
                }

                if (IsEnabled(CustomComboPreset.WhiteMageAfflatusFeature))
                {
                    if (level >= WHM.Levels.AfflatusSolace && gauge.Lily > 0)
                        return WHM.AfflatusSolace;
                }
            }

            if (actionID == WHM.Medica)
            {
                var gauge = GetJobGauge<WHMGauge>();

                if (IsEnabled(CustomComboPreset.WhiteMageRaptureMiseryFeature))
                {
                    if (level >= WHM.Levels.AfflatusMisery && gauge.BloodLily == 3)
                        return WHM.AfflatusMisery;
                }

                if (IsEnabled(CustomComboPreset.WhiteMageAfflatusFeature))
                {
                    if (level >= WHM.Levels.AfflatusRapture && gauge.Lily > 0)
                        return WHM.AfflatusRapture;
                }
            }

            return actionID;
        }
    }
}
