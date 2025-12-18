using Lumina.Excel.Sheets;

namespace XIVComboExpandedPlugin.Combos;

internal static class ADV
{
    public const byte ClassID = 0;
    public const byte JobID = 0;

    public const uint
        Provoke = 7533,
        Shirk = 7537,
        LowBlow = 7540,
        HeadGraze = 7551,
        Peloton = 7557,
        Swiftcast = 7561,
        LucidDreaming = 7562,
        AngelWhisper = 18317,
        VariantRaise2 = 29734;

    public static class Buffs
    {
        public const ushort
            Swiftcast = 167,
            Medicated = 49,
            Peloton = 1199;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            // Note that unlike class/job abilities, role actions are available even when level-synced below their
            // the level they are learned at.
            LowBlow = 12,
            Swiftcast = 18,
            VariantRaise2 = 90;
    }
}

internal class SwiftRaiseFeature : CustomCombo
{
    protected internal override CustomComboPreset Preset => CustomComboPreset.AdvSwiftcastFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if ((actionID == AST.Ascend && level >= AST.Levels.Ascend) ||
            (actionID == SCH.Resurrection && level >= SCH.Levels.Resurrection) ||
            (actionID == SGE.Egeiro && level >= SGE.Levels.Egeiro) ||
            (actionID == WHM.Raise && level >= WHM.Levels.Raise) ||
			(actionID == BLU.AngelWhisper))
        {
            if (level >= ADV.Levels.Swiftcast && CanUseAction(ADV.Swiftcast) && IsCooldownUsable(ADV.Swiftcast))
                return ADV.Swiftcast;
        }

        if (actionID == RDM.Verraise && level >= RDM.Levels.Verraise && !HasEffect(RDM.Buffs.Dualcast))
        {
            if (IsEnabled(CustomComboPreset.AdvVerRaiseToVerCureFeature))
            {
                if (level >= RDM.Levels.Vercure)
                    return RDM.Vercure;
            }
            else if (!IsEnabled(CustomComboPreset.AdvDisableVerRaiseFeature))
            {
                if (level >= ADV.Levels.Swiftcast && CanUseAction(ADV.Swiftcast) && IsCooldownUsable(ADV.Swiftcast))
                    return ADV.Swiftcast;
            }
        }

        return actionID;
    }
}

internal class VariantRaiseFeature : CustomCombo
{
    protected internal override CustomComboPreset Preset => CustomComboPreset.AdvVariantRaiseFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if ((actionID == AST.Ascend && level >= AST.Levels.Ascend) ||
            (actionID == SCH.Resurrection && level >= SCH.Levels.Resurrection) ||
            (actionID == SGE.Egeiro && level >= SGE.Levels.Egeiro) ||
            (actionID == WHM.Raise && level >= WHM.Levels.Raise) ||
            (actionID == RDM.Verraise && level >= RDM.Levels.Verraise && !HasEffect(RDM.Buffs.Dualcast)) ||
            (actionID == BLU.AngelWhisper))
        {
            // Per Splatoon:
            // 1069: solo
            // 1075: group
            // 1076: savage
            if (level >= ADV.Levels.VariantRaise2 && CurrentTerritory == 1075u)
                return ADV.VariantRaise2;
        }

        return actionID;
    }
}

internal class StanceProvokeFeature : CustomCombo
{
    protected internal override CustomComboPreset Preset => CustomComboPreset.AdvStanceProvokeFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == ADV.Provoke)
        {
            int job = (int)LocalPlayer?.ClassJob.RowId;

            if (!HasEffect(PLD.Buffs.IronWill)
                && !HasEffect(WAR.Buffs.Defiance)
                && !HasEffect(DRK.Buffs.Grit)
                && !HasEffect(GNB.Buffs.RoyalGuard))
            {
                if (job == PLD.JobID && level >= PLD.Levels.IronWill)
                    return PLD.IronWill;
                if (job == WAR.JobID && level >= WAR.Levels.Defiance)
                    return WAR.Defiance;
                if (job == DRK.JobID && level >= DRK.Levels.Grit)
                    return DRK.Grit;
                if (job == GNB.JobID && level >= GNB.Levels.RoyalGuard)
                    return GNB.RoyalGuard;
            }

            if (IsEnabled(CustomComboPreset.AdvStanceBackProvokeFeature) && !IsCooldownUsable(ADV.Provoke))
            {
                if (job == PLD.JobID && level >= PLD.Levels.IronWill)
                    return PLD.IronWillRemoval;
                if (job == WAR.JobID && level >= WAR.Levels.Defiance)
                    return WAR.DefianceRemoval;
                if (job == DRK.JobID && level >= DRK.Levels.Grit)
                    return DRK.GritRemoval;
                if (job == GNB.JobID && level >= GNB.Levels.RoyalGuard)
                    return GNB.RoyalGuardRemoval;
            }
        }

        return actionID;
    }
}

internal class ShirkStanceFeature : CustomCombo
{
    protected internal override CustomComboPreset Preset => CustomComboPreset.AdvShirkStanceFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == ADV.Shirk && !IsCooldownUsable(ADV.Shirk))
        {
            int job = (int)LocalPlayer?.ClassJob.RowId;

            if (HasEffect(PLD.Buffs.IronWill)
                || HasEffect(WAR.Buffs.Defiance)
                || HasEffect(DRK.Buffs.Grit)
                || HasEffect(GNB.Buffs.RoyalGuard))
            {
                if (job == PLD.JobID && level >= PLD.Levels.IronWill)
                    return PLD.IronWillRemoval;
                if (job == WAR.JobID && level >= WAR.Levels.Defiance)
                    return WAR.DefianceRemoval;
                if (job == DRK.JobID && level >= DRK.Levels.Grit)
                    return DRK.GritRemoval;
                if (job == GNB.JobID && level >= GNB.Levels.RoyalGuard)
                    return GNB.RoyalGuardRemoval;
            }
        }

        return actionID;
    }
}

internal class HeadGrazePelotonFeature : CustomCombo
{
    protected internal override CustomComboPreset Preset => CustomComboPreset.AdvPelotonSTFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == ADV.HeadGraze && ((int)LocalPlayer?.ClassJob.RowId == BRD.ClassID || (int)LocalPlayer?.ClassJob.RowId == BRD.JobID || (int)LocalPlayer?.ClassJob.RowId == MCH.JobID || (int)LocalPlayer?.ClassJob.RowId == DNC.JobID))
        {
            if (!HasEffect(ADV.Buffs.Peloton) && !InCombat() && CanUseAction(OriginalHook(ADV.Peloton)))
            {
                return ADV.Peloton;
            }
        }

        return actionID;
    }
}


internal class AdvAutoLucidDreamingFeature : CustomCombo
{
    protected internal override CustomComboPreset Preset => CustomComboPreset.AdvAutoLucidDreamingFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (LocalPlayer?.CurrentMp < 5000 && CanUseAction(OriginalHook(ADV.LucidDreaming)) && IsCooldownUsable(ADV.LucidDreaming))
        {
            int job = (int)LocalPlayer?.ClassJob.RowId;
            if (job == WHM.ClassID
            || (job == BLM.ClassID && IsEnabled(CustomComboPreset.AdvEnableBLMLucidFeature))
            || job == WHM.JobID
            || (job == BLM.JobID && IsEnabled(CustomComboPreset.AdvEnableBLMLucidFeature))
            || job == SMN.ClassID
            || job == SMN.JobID
            || job == SCH.JobID
            || job == AST.JobID
            || job == RDM.JobID
            || job == BLU.JobID
            || job == SGE.JobID
            || job == PCT.JobID)
            {
                return ADV.LucidDreaming;
            }
        }

        return actionID;
    }
}
