using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

internal static class WHM
{
    public const byte ClassID = 6;
    public const byte JobID = 24;

    public const uint
        Stone = 119,
        Aero = 121,
        Cure = 120,
        Medica = 124,
        Raise = 125,
        Medica2 = 133,
        Cure2 = 135,
        PresenceOfMind = 136,
        Holy = 139,
        Benediction = 140,
        Asylum = 3569,
        Tetragrammaton = 3570,
        Assize = 3571,
        PlenaryIndulgence = 7433,
        AfflatusSolace = 16531,
        AfflatusRapture = 16534,
        AfflatusMisery = 16535,
        Temperance = 16536,
        Holy3 = 25860,
        Aquaveil = 25861,
        LiturgyOfTheBell = 25862,
        Glare4 = 37009,
        Medica3 = 37010;

    public static class Buffs
    {
        public const ushort

            Glare4Ready = 3879;
    }

    public static class Debuffs
    {
        public const ushort
            Aero = 143,
            Aero2 = 144,
            Dia = 1871;
    }

    public static class Levels
    {
        public const byte
            Raise = 12,
            Cure2 = 30,
            AfflatusSolace = 52,
            AfflatusMisery = 74,
            AfflatusRapture = 76,
            Glare4 = 92;
    }
}

internal class WhiteMageAfflatusSolace : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WhiteMageSolaceMiseryFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == WHM.AfflatusSolace)
        {
            var gauge = GetJobGauge<WHMGauge>();

            if (level >= WHM.Levels.AfflatusMisery && gauge.BloodLily == 3)
            {
                if (IsEnabled(CustomComboPreset.WhiteMageSolaceMiseryTargetFeature))
                {
                    if (TargetIsEnemy())
                        return WHM.AfflatusMisery;
                }
                else
                {
                    return WHM.AfflatusMisery;
                }
            }
        }

        return actionID;
    }
}

internal class WhiteMageAfflatusRapture : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WhiteMageRaptureMiseryFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == WHM.AfflatusRapture)
        {
            var gauge = GetJobGauge<WHMGauge>();

            if (level >= WHM.Levels.AfflatusMisery && gauge.BloodLily == 3 && TargetIsEnemy())
                return WHM.AfflatusMisery;
        }

        return actionID;
    }
}

internal class WhiteMageHoly : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WhiteMageHolyMiseryFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == WHM.Holy || actionID == WHM.Holy3)
        {
            var gauge = GetJobGauge<WHMGauge>();

            if (level >= WHM.Levels.AfflatusMisery && gauge.BloodLily == 3 && TargetIsEnemy())
                return WHM.AfflatusMisery;
        }

        return actionID;
    }
}

internal class WhiteMageCure2 : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WhmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == WHM.Cure2)
        {
            var gauge = GetJobGauge<WHMGauge>();

            if (IsEnabled(CustomComboPreset.WhiteMageCureFeature))
            {
                if (level < WHM.Levels.Cure2)
                    return WHM.Cure;
            }

            if (IsEnabled(CustomComboPreset.WhiteMageAfflatusFeature))
            {
                if (IsEnabled(CustomComboPreset.WhiteMageSolaceMiseryFeature))
                {
                    if (level >= WHM.Levels.AfflatusMisery && gauge.BloodLily == 3)
                    {
                        if (IsEnabled(CustomComboPreset.WhiteMageSolaceMiseryTargetFeature))
                        {
                            if (TargetIsEnemy())
                                return WHM.AfflatusMisery;
                        }
                        else
                        {
                            return WHM.AfflatusMisery;
                        }
                    }
                }

                if (level >= WHM.Levels.AfflatusSolace && gauge.Lily > 0)
                    return WHM.AfflatusSolace;
            }
        }

        return actionID;
    }
}

internal class WhiteMageMedica : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WhmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == WHM.Medica ||
            (IsEnabled(CustomComboPreset.WhiteMageAfflatusMedicaPlusFeature) &&
                (actionID == WHM.Medica2 || actionID == WHM.Medica3)))
        {
            var gauge = GetJobGauge<WHMGauge>();

            if (IsEnabled(CustomComboPreset.WhiteMageAfflatusFeature))
            {
                if (IsEnabled(CustomComboPreset.WhiteMageRaptureMiseryFeature))
                {
                    if (level >= WHM.Levels.AfflatusMisery && gauge.BloodLily == 3 && TargetIsEnemy())
                        return WHM.AfflatusMisery;
                }

                if (level >= WHM.Levels.AfflatusRapture && gauge.Lily > 0)
                    return WHM.AfflatusRapture;
            }
        }

        return actionID;
    }
}

internal class WhiteMageGlare4Feature : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.WhmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == WHM.Stone)
        {
            if (IsEnabled(CustomComboPreset.WhiteMageDoTFeature) && InCombat() && TargetIsEnemy())
            {
                var aero = FindTargetEffect(WHM.Debuffs.Aero);
                var aero2 = FindTargetEffect(WHM.Debuffs.Aero2);
                var dia = FindTargetEffect(WHM.Debuffs.Dia);

                // have to explicitly check all variants of the dot for some reason else spaghetti code ensues
                if (!(aero?.RemainingTime > 2.8 || aero2?.RemainingTime > 2.8 || dia?.RemainingTime > 2.8))
                    return OriginalHook(WHM.Aero);
            }

            if (IsEnabled(CustomComboPreset.WhiteMageGlare4Feature))
            {
                if (level >= WHM.Levels.Glare4 && HasEffect(WHM.Buffs.Glare4Ready))
                    return WHM.Glare4;
            }
        }

        return actionID;
    }
}