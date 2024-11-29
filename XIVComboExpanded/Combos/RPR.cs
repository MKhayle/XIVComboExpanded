using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

internal static class RPR
{
    public const byte JobID = 39;

    public const uint
        // Single Target
        Slice = 24373,
        WaxingSlice = 24374,
        InfernalSlice = 24375,
        // AoE
        SpinningScythe = 24376,
        NightmareScythe = 24377,
        // Soul Reaver
        Gibbet = 24382,
        Gallows = 24383,
        Guillotine = 24384,
        BloodStalk = 24389,
        UnveiledGibbet = 24390,
        UnveiledGallows = 24391,
        GrimSwathe = 24392,
        Gluttony = 24393,
        // Generators
        SoulSlice = 24380,
        SoulScythe = 24381,
        // Sacrifice
        ArcaneCircle = 24405,
        PlentifulHarvest = 24385,
        // Shroud
        Enshroud = 24394,
        Communio = 24398,
        VoidReaping = 24395,
        CrossReaping = 24396,
        GrimReaping = 24397,
        LemuresSlice = 24399,
        LemuresScythe = 24400,
        Sacrificium = 36969,
        Perfectio = 36973,
        // Misc
        ShadowOfDeath = 24378,
        Harpe = 24386,
        Soulsow = 24387,
        HarvestMoon = 24388,
        HellsIngress = 24401,
        HellsEgress = 24402,
        Regress = 24403;

    public static class Buffs
    {
        public const ushort
            EnhancedHarpe = 2845,
            SoulReaver = 2587,
            Executioner = 3858,
            EnhancedGibbet = 2588,
            EnhancedGallows = 2589,
            EnhancedVoidReaping = 2590,
            EnhancedCrossReaping = 2591,
            ImmortalSacrifice = 2592,
            Enshrouded = 2593,
            Soulsow = 2594,
            Threshold = 2595,
            Oblatio = 3857,          // Sacrificium ready to use
            PerfectioOcculta = 3859, // Turns into Perfectio Parata when Communio is used
            PerfectioParata = 3860;  // Perfectio ready to use
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            WaxingSlice = 5,
            HellsIngress = 20,
            HellsEgress = 20,
            SpinningScythe = 25,
            InfernalSlice = 30,
            NightmareScythe = 45,
            BloodStalk = 50,
            GrimSwathe = 55,
            SoulSlice = 60,
            SoulScythe = 65,
            SoulReaver = 70,
            Regress = 74,
            Gluttony = 76,
            Enshroud = 80,
            Soulsow = 82,
            HarvestMoon = 82,
            EnhancedShroud = 86,
            LemuresScythe = 86,
            PlentifulHarvest = 88,
            Communio = 90,
            Sacrificium = 92,
            Executioner = 96,
            Perfectio = 100;
    }
}

internal class ReaperSlice : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RPR.InfernalSlice)
        {
            var gauge = GetJobGauge<RPRGauge>();

            if (IsEnabled(CustomComboPreset.ReaperSliceSoulsowFeature))
            {
                if (level >= RPR.Levels.Soulsow && !InCombat() && !HasEffect(RPR.Buffs.Soulsow))
                    return RPR.Soulsow;
            }

            if (level >= RPR.Levels.SoulReaver &&
                (IsEnabled(CustomComboPreset.ReaperSliceGibbetFeature) ||
                IsEnabled(CustomComboPreset.ReaperSliceGallowsFeature)))
            {
                if (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0)
                {
                    if (IsEnabled(CustomComboPreset.ReaperSoulReaverLemuresFeature))
                    {
                        if (level >= RPR.Levels.EnhancedShroud && gauge.VoidShroud >= 2)
                            return RPR.LemuresSlice;

                        if (IsEnabled(CustomComboPreset.ReaperLemuresSacrificiumFeature))
                        {
                            if (level >= RPR.Levels.Sacrificium && HasEffect(RPR.Buffs.Oblatio) &&
                                (gauge.LemureShroud == 2 || (gauge.LemureShroud == 4 &&
                                !IsEnabled(CustomComboPreset.ReaperSacrificiumAdvancedFeature))))
                                return RPR.Sacrificium;
                        }
                    }

                    if (IsEnabled(CustomComboPreset.ReaperSoulReaverCommunioFeature))
                    {
                        if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1)
                            return RPR.Communio;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperReapingEnhancedFeature))
                    {
                        if (HasEffect(RPR.Buffs.EnhancedVoidReaping))
                            return RPR.VoidReaping;

                        if (HasEffect(RPR.Buffs.EnhancedCrossReaping))
                            return RPR.CrossReaping;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperSliceGibbetFeature))
                        return RPR.VoidReaping;

                    return RPR.CrossReaping;
                }

                if (HasEffect(RPR.Buffs.SoulReaver) || HasEffect(RPR.Buffs.Executioner))
                {
                    if (IsEnabled(CustomComboPreset.ReaperSoulReaverEnhancedFeature))
                    {
                        if (HasEffect(RPR.Buffs.EnhancedGibbet))
                            return OriginalHook(RPR.Gibbet);

                        if (HasEffect(RPR.Buffs.EnhancedGallows))
                            return OriginalHook(RPR.Gallows);
                    }

                    if (IsEnabled(CustomComboPreset.ReaperSliceGibbetFeature))
                        return OriginalHook(RPR.Gibbet);

                    return OriginalHook(RPR.Gallows);
                }
            }

            if (IsEnabled(CustomComboPreset.ReaperComboPerfectioFeature))
            {
                if (level >= RPR.Levels.Perfectio && HasEffect(RPR.Buffs.PerfectioParata))
                    return RPR.Perfectio;
            }

            if (level >= RPR.Levels.BloodStalk && IsEnabled(CustomComboPreset.ReaperAutoSoulReaverFeature))
            {
                // Blood Stalk if we're over 90 gauge, or if we're over 50 and the overcap-only feature isn't enabled,
                // or if the auto-Soul Slice feature is enabled and our next action would otherwise be Soul Slice.
                if (gauge.Soul >= 50 && (gauge.Soul > 90 ||
                    !IsEnabled(CustomComboPreset.ReaperReaperAutoBloodStalkOvercapFeature) ||
                    (IsEnabled(CustomComboPreset.ReaperAutoSoulSliceFeature) &&
                    IsCooldownUsable(RPR.SoulSlice) && gauge.Soul > 50)))
                {
                    if (IsEnabled(CustomComboPreset.ReaperSoulReaverGluttonyFeature) &&
                        level >= RPR.Levels.Gluttony && IsCooldownUsable(RPR.Gluttony))
                        return RPR.Gluttony;

                    return OriginalHook(RPR.BloodStalk);
                }
            }

            if (level >= RPR.Levels.SoulSlice && IsEnabled(CustomComboPreset.ReaperAutoSoulSliceFeature))
            {
                if (IsCooldownUsable(RPR.SoulSlice) && gauge.Soul <= 50)
                    return RPR.SoulSlice;
            }

            if (IsEnabled(CustomComboPreset.ReaperSliceCombo))
            {
                if (lastComboMove == RPR.WaxingSlice && level >= RPR.Levels.InfernalSlice)
                    return RPR.InfernalSlice;

                if (lastComboMove == RPR.Slice && level >= RPR.Levels.WaxingSlice)
                    return RPR.WaxingSlice;

                return RPR.Slice;
            }
        }

        return actionID;
    }
}

internal class ReaperScythe : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RPR.NightmareScythe)
        {
            var gauge = GetJobGauge<RPRGauge>();

            if (IsEnabled(CustomComboPreset.ReaperScytheSoulsowFeature))
            {
                if (level >= RPR.Levels.Soulsow && !InCombat() && !HasEffect(RPR.Buffs.Soulsow))
                    return RPR.Soulsow;
            }

            if (level >= RPR.Levels.SoulReaver && IsEnabled(CustomComboPreset.ReaperScytheGuillotineFeature))
            {
                if (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0)
                {
                    if (IsEnabled(CustomComboPreset.ReaperSoulReaverLemuresFeature))
                    {
                        if (level >= RPR.Levels.EnhancedShroud && gauge.VoidShroud >= 2)
                            return RPR.LemuresScythe;

                        if (IsEnabled(CustomComboPreset.ReaperLemuresSacrificiumFeature))
                        {
                            if (level >= RPR.Levels.Sacrificium && HasEffect(RPR.Buffs.Oblatio) &&
                                (gauge.LemureShroud == 2 || (gauge.LemureShroud == 4 &&
                                !IsEnabled(CustomComboPreset.ReaperSacrificiumAdvancedFeature))))
                                return RPR.Sacrificium;
                        }
                    }

                    if (IsEnabled(CustomComboPreset.ReaperSoulReaverCommunioFeature))
                    {
                        if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1)
                            return RPR.Communio;
                    }

                    return RPR.GrimReaping;
                }

                if (HasEffect(RPR.Buffs.SoulReaver) || HasEffect(RPR.Buffs.Executioner))
                    return OriginalHook(RPR.Guillotine);
            }

            if (IsEnabled(CustomComboPreset.ReaperComboPerfectioFeature))
            {
                if (level >= RPR.Levels.Perfectio && HasEffect(RPR.Buffs.PerfectioParata))
                    return RPR.Perfectio;
            }

            if (IsEnabled(CustomComboPreset.ReaperScytheHarvestMoonFeature))
            {
                if (level >= RPR.Levels.HarvestMoon && HasEffect(RPR.Buffs.Soulsow) && TargetIsEnemy())
                    return RPR.HarvestMoon;
            }

            if (level >= RPR.Levels.GrimSwathe && IsEnabled(CustomComboPreset.ReaperAutoSoulReaverFeature))
            {
                // Blood Stalk if we're over 90 gauge, or if we're over 50 and the overcap-only feature isn't enabled,
                // or if the auto-Soul Slice feature is enabled and our next action would otherwise be Soul Slice.
                if (gauge.Soul >= 50 && (gauge.Soul > 90 ||
                    !IsEnabled(CustomComboPreset.ReaperReaperAutoBloodStalkOvercapFeature) ||
                    (IsEnabled(CustomComboPreset.ReaperAutoSoulSliceFeature) &&
                    IsCooldownUsable(RPR.SoulScythe) && gauge.Soul > 50)))
                {
                    if (IsEnabled(CustomComboPreset.ReaperSoulReaverGluttonyFeature) &&
                        level >= RPR.Levels.Gluttony && IsCooldownUsable(RPR.Gluttony))
                        return RPR.Gluttony;

                    return OriginalHook(RPR.GrimSwathe);
                }
            }

            if (level >= RPR.Levels.SoulScythe && IsEnabled(CustomComboPreset.ReaperAutoSoulSliceFeature))
            {
                if (IsCooldownUsable(RPR.SoulScythe) && gauge.Soul <= 50)
                    return RPR.SoulScythe;
            }

            if (IsEnabled(CustomComboPreset.ReaperScytheCombo))
            {
                if (lastComboMove == RPR.SpinningScythe && level >= RPR.Levels.NightmareScythe)
                    return RPR.NightmareScythe;

                return RPR.SpinningScythe;
            }
        }

        return actionID;
    }
}

internal class ReaperShadowOfDeath : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RPR.ShadowOfDeath)
        {
            var gauge = GetJobGauge<RPRGauge>();

            if (level >= RPR.Levels.SoulReaver &&
                (IsEnabled(CustomComboPreset.ReaperShadowGibbetFeature) ||
                IsEnabled(CustomComboPreset.ReaperShadowGallowsFeature)))
            {
                if (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0 &&
                    (IsEnabled(CustomComboPreset.ReaperShadowGibbetEnshroudedFeature) ||
                    IsEnabled(CustomComboPreset.ReaperShadowGallowsEnshroudedFeature)))
                {
                    if (IsEnabled(CustomComboPreset.ReaperSoulReaverLemuresFeature))
                    {
                        if (level >= RPR.Levels.EnhancedShroud && gauge.VoidShroud >= 2)
                            return RPR.LemuresSlice;

                        if (IsEnabled(CustomComboPreset.ReaperLemuresSacrificiumFeature))
                        {
                            if (level >= RPR.Levels.Sacrificium && HasEffect(RPR.Buffs.Oblatio) &&
                                (gauge.LemureShroud == 2 || (gauge.LemureShroud == 4 &&
                                !IsEnabled(CustomComboPreset.ReaperSacrificiumAdvancedFeature))))
                                return RPR.Sacrificium;
                        }
                    }

                    if (IsEnabled(CustomComboPreset.ReaperSoulReaverCommunioFeature))
                    {
                        if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1)
                            return RPR.Communio;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperReapingEnhancedFeature))
                    {
                        if (HasEffect(RPR.Buffs.EnhancedVoidReaping))
                            return RPR.VoidReaping;

                        if (HasEffect(RPR.Buffs.EnhancedCrossReaping))
                            return RPR.CrossReaping;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperShadowGibbetEnshroudedFeature))
                        return RPR.VoidReaping;

                    return RPR.CrossReaping;
                }

                if (HasEffect(RPR.Buffs.SoulReaver) || HasEffect(RPR.Buffs.Executioner))
                {
                    if (IsEnabled(CustomComboPreset.ReaperSoulReaverEnhancedFeature))
                    {
                        if (HasEffect(RPR.Buffs.EnhancedGibbet))
                            return OriginalHook(RPR.Gibbet);

                        if (HasEffect(RPR.Buffs.EnhancedGallows))
                            return OriginalHook(RPR.Gallows);
                    }

                    if (IsEnabled(CustomComboPreset.ReaperShadowGibbetFeature))
                        return OriginalHook(RPR.Gibbet);

                    return OriginalHook(RPR.Gallows);
                }
            }
        }

        return actionID;
    }
}

internal class ReaperSoulSlice : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RPR.SoulSlice)
        {
            var gauge = GetJobGauge<RPRGauge>();

            if (level >= RPR.Levels.SoulReaver &&
                (IsEnabled(CustomComboPreset.ReaperSoulGallowsFeature) ||
                IsEnabled(CustomComboPreset.ReaperSoulGibbetFeature)))
            {
                if (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0)
                {
                    if (IsEnabled(CustomComboPreset.ReaperSoulReaverLemuresFeature))
                    {
                        if (level >= RPR.Levels.EnhancedShroud && gauge.VoidShroud >= 2)
                            return RPR.LemuresSlice;

                        if (IsEnabled(CustomComboPreset.ReaperLemuresSacrificiumFeature))
                        {
                            if (level >= RPR.Levels.Sacrificium && HasEffect(RPR.Buffs.Oblatio) &&
                                (gauge.LemureShroud == 2 || (gauge.LemureShroud == 4 &&
                                !IsEnabled(CustomComboPreset.ReaperSacrificiumAdvancedFeature))))
                                return RPR.Sacrificium;
                        }
                    }

                    if (IsEnabled(CustomComboPreset.ReaperSoulReaverCommunioFeature))
                    {
                        if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1)
                            return RPR.Communio;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperReapingEnhancedFeature))
                    {
                        if (HasEffect(RPR.Buffs.EnhancedVoidReaping))
                            return RPR.VoidReaping;

                        if (HasEffect(RPR.Buffs.EnhancedCrossReaping))
                            return RPR.CrossReaping;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperSoulGibbetFeature))
                        return RPR.VoidReaping;

                    return RPR.CrossReaping;
                }

                if (HasEffect(RPR.Buffs.SoulReaver) || HasEffect(RPR.Buffs.Executioner))
                {
                    if (IsEnabled(CustomComboPreset.ReaperSoulReaverEnhancedFeature))
                    {
                        if (HasEffect(RPR.Buffs.EnhancedGibbet))
                            return OriginalHook(RPR.Gibbet);

                        if (HasEffect(RPR.Buffs.EnhancedGallows))
                            return OriginalHook(RPR.Gallows);
                    }

                    if (IsEnabled(CustomComboPreset.ReaperSoulGibbetFeature))
                        return OriginalHook(RPR.Gibbet);

                    return OriginalHook(RPR.Gallows);
                }

                if (level >= RPR.Levels.BloodStalk && IsEnabled(CustomComboPreset.ReaperAutoSoulReaverFeature))
                {
                    if (gauge.Soul >= 50 && (gauge.Soul > 50 ||
                        !IsEnabled(CustomComboPreset.ReaperReaperAutoBloodStalkOvercapFeature)))
                    {
                        if (IsEnabled(CustomComboPreset.ReaperSoulReaverGluttonyFeature) &&
                            level >= RPR.Levels.Gluttony && IsCooldownUsable(RPR.Gluttony))
                            return RPR.Gluttony;

                        return OriginalHook(RPR.BloodStalk);
                    }
                }
            }
        }

        return actionID;
    }
}

internal class ReaperSoulScythe : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RPR.SoulScythe)
        {
            var gauge = GetJobGauge<RPRGauge>();

            if (level >= RPR.Levels.SoulReaver && IsEnabled(CustomComboPreset.ReaperSoulScytheGuillotineFeature))
            {
                if (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0)
                {
                    if (IsEnabled(CustomComboPreset.ReaperSoulReaverLemuresFeature))
                    {
                        if (level >= RPR.Levels.EnhancedShroud && gauge.VoidShroud >= 2)
                            return RPR.LemuresScythe;

                        if (IsEnabled(CustomComboPreset.ReaperLemuresSacrificiumFeature))
                        {
                            if (level >= RPR.Levels.Sacrificium && HasEffect(RPR.Buffs.Oblatio) &&
                                (gauge.LemureShroud == 2 || (gauge.LemureShroud == 4 &&
                                !IsEnabled(CustomComboPreset.ReaperSacrificiumAdvancedFeature))))
                                return RPR.Sacrificium;
                        }
                    }

                    if (IsEnabled(CustomComboPreset.ReaperSoulReaverCommunioFeature))
                    {
                        if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1)
                            return RPR.Communio;
                    }

                    return RPR.GrimReaping;
                }

                if (HasEffect(RPR.Buffs.SoulReaver) || HasEffect(RPR.Buffs.Executioner))
                    return OriginalHook(RPR.Guillotine);

                if (level >= RPR.Levels.GrimSwathe && IsEnabled(CustomComboPreset.ReaperAutoSoulReaverFeature))
                {
                    if (gauge.Soul >= 50 && (gauge.Soul > 50 ||
                        !IsEnabled(CustomComboPreset.ReaperReaperAutoBloodStalkOvercapFeature)))
                    {
                        if (IsEnabled(CustomComboPreset.ReaperSoulReaverGluttonyFeature) &&
                            level >= RPR.Levels.Gluttony && IsCooldownUsable(RPR.Gluttony))
                            return RPR.Gluttony;

                        return OriginalHook(RPR.GrimSwathe);
                    }
                }
            }
        }

        return actionID;
    }
}

internal class ReaperBloodStalk : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RPR.BloodStalk)
        {
            var gauge = GetJobGauge<RPRGauge>();

            if (IsEnabled(CustomComboPreset.ReaperLemuresSacrificiumFeature) &&
                level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0)
            {
                if (level >= RPR.Levels.EnhancedShroud && gauge.VoidShroud >= 2)
                    return RPR.LemuresSlice;

                if (IsEnabled(CustomComboPreset.ReaperLemuresSacrificiumFeature))
                {
                    if (level >= RPR.Levels.Sacrificium && HasEffect(RPR.Buffs.Oblatio) &&
                        (gauge.LemureShroud == 2 || (gauge.LemureShroud == 4 &&
                        !IsEnabled(CustomComboPreset.ReaperSacrificiumAdvancedFeature))))
                        return RPR.Sacrificium;
                }
            }

            if (IsEnabled(CustomComboPreset.ReaperSoulReaverGluttonyFeature) &&
                level >= RPR.Levels.Gluttony && IsCooldownUsable(RPR.Gluttony) &&
                gauge.EnshroudedTimeRemaining == 0)
                return RPR.Gluttony;
        }

        return actionID;
    }
}

internal class ReaperGrimSwathe : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RPR.GrimSwathe)
        {
            var gauge = GetJobGauge<RPRGauge>();

            if (IsEnabled(CustomComboPreset.ReaperLemuresSacrificiumFeature) &&
                level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0)
            {
                if (level >= RPR.Levels.EnhancedShroud && gauge.VoidShroud >= 2)
                    return RPR.LemuresScythe;

                if (IsEnabled(CustomComboPreset.ReaperLemuresSacrificiumFeature))
                {
                    if (level >= RPR.Levels.Sacrificium && HasEffect(RPR.Buffs.Oblatio) &&
                        (gauge.LemureShroud == 2 || (gauge.LemureShroud == 4 &&
                        !IsEnabled(CustomComboPreset.ReaperSacrificiumAdvancedFeature))))
                        return RPR.Sacrificium;
                }
            }

            if (IsEnabled(CustomComboPreset.ReaperSoulReaverGluttonyFeature) &&
                level >= RPR.Levels.Gluttony && IsCooldownUsable(RPR.Gluttony) &&
                gauge.EnshroudedTimeRemaining == 0)
                return RPR.Gluttony;
        }

        return actionID;
    }
}

internal class ReaperGibbetGallowsGuillotine : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RPR.Gibbet || actionID == RPR.Gallows)
        {
            var gauge = GetJobGauge<RPRGauge>();

            if (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0)
            {
                if (IsEnabled(CustomComboPreset.ReaperSoulReaverLemuresFeature))
                {
                    if (level >= RPR.Levels.Sacrificium &&
                        IsEnabled(CustomComboPreset.ReaperLemuresSacrificiumFeature))
                    {
                        if (gauge.VoidShroud >= 2)
                            return RPR.LemuresSlice;

                        if (HasEffect(RPR.Buffs.Oblatio) &&
                            (gauge.LemureShroud == 2 || (gauge.LemureShroud == 4 &&
                            !IsEnabled(CustomComboPreset.ReaperSacrificiumAdvancedFeature))))
                            return RPR.Sacrificium;
                    }

                    if (level >= RPR.Levels.EnhancedShroud && gauge.VoidShroud >= 2)
                        return RPR.LemuresSlice;
                }

                if (IsEnabled(CustomComboPreset.ReaperSoulReaverCommunioFeature))
                {
                    if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1)
                        return RPR.Communio;
                }

                if (IsEnabled(CustomComboPreset.ReaperReapingEnhancedFeature))
                {
                    if (HasEffect(RPR.Buffs.EnhancedVoidReaping))
                        return RPR.VoidReaping;

                    if (HasEffect(RPR.Buffs.EnhancedCrossReaping))
                        return RPR.CrossReaping;
                }

                return actionID;
            }

            if (level >= RPR.Levels.SoulReaver && IsEnabled(CustomComboPreset.ReaperSoulReaverEnhancedFeature) &&
                (HasEffect(RPR.Buffs.SoulReaver) || HasEffect(RPR.Buffs.Executioner)))
            {
                if (HasEffect(RPR.Buffs.EnhancedGibbet))
                    return OriginalHook(RPR.Gibbet);

                if (HasEffect(RPR.Buffs.EnhancedGallows))
                    return OriginalHook(RPR.Gallows);
            }
        }

        if (actionID == RPR.Guillotine)
        {
            var gauge = GetJobGauge<RPRGauge>();

            if (level >= RPR.Levels.Enshroud && gauge.EnshroudedTimeRemaining > 0)
            {
                if (IsEnabled(CustomComboPreset.ReaperSoulReaverLemuresFeature))
                {
                    if (level >= RPR.Levels.EnhancedShroud && gauge.VoidShroud >= 2)
                        return RPR.LemuresScythe;

                    if (IsEnabled(CustomComboPreset.ReaperLemuresSacrificiumFeature))
                    {
                        if (level >= RPR.Levels.Sacrificium && HasEffect(RPR.Buffs.Oblatio) &&
                            (gauge.LemureShroud == 2 || (gauge.LemureShroud == 4 &&
                            !IsEnabled(CustomComboPreset.ReaperSacrificiumAdvancedFeature))))
                            return RPR.Sacrificium;
                    }
                }

                if (IsEnabled(CustomComboPreset.ReaperSoulReaverCommunioFeature))
                {
                    if (level >= RPR.Levels.Communio && gauge.LemureShroud == 1)
                        return RPR.Communio;
                }
            }
        }

        return actionID;
    }
}

internal class ReaperEnshroud : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RPR.Enshroud)
        {
            var gauge = GetJobGauge<RPRGauge>();

            if (IsEnabled(CustomComboPreset.ReaperEnshroudCommunioFeature))
            {
                if (level >= RPR.Levels.Communio && gauge.EnshroudedTimeRemaining > 0)
                    return RPR.Communio;
            }

            if (IsEnabled(CustomComboPreset.ReaperEnshroudPerfectioFeature))
            {
                if (level >= RPR.Levels.Perfectio && HasEffect(RPR.Buffs.PerfectioParata))
                    return RPR.Perfectio;
            }
        }

        return actionID;
    }
}

internal class ReaperArcaneCircle : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RPR.ArcaneCircle)
        {
            if (IsEnabled(CustomComboPreset.ReaperArcaneHarvestFeature))
            {
                if (level >= RPR.Levels.PlentifulHarvest && HasEffect(RPR.Buffs.ImmortalSacrifice))
                    return RPR.PlentifulHarvest;

                if (IsEnabled(CustomComboPreset.ReaperPerfectHarvestFeature) &&
                    level >= RPR.Levels.Perfectio && HasEffect(RPR.Buffs.PerfectioParata))
                        return RPR.Perfectio;
            }
        }

        return actionID;
    }
}

internal class ReaperPlentifulHarvest : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RPR.PlentifulHarvest)
        {
            if (IsEnabled(CustomComboPreset.ReaperPerfectHarvestFeature) &&
                level >= RPR.Levels.Perfectio && HasEffect(RPR.Buffs.PerfectioParata))
                    return RPR.Perfectio;
        }

        return actionID;
    }
}

internal class ReaperHellsIngressEgress : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RPR.HellsEgress || actionID == RPR.HellsIngress)
        {
            if (level >= RPR.Levels.Regress && IsEnabled(CustomComboPreset.ReaperRegressFeature))
            {
                var threshold = FindEffect(RPR.Buffs.Threshold);
                if (threshold != null && (threshold.RemainingTime <= 8.5 ||
                    IsEnabled(CustomComboPreset.ReaperRegressOption)))
                    return RPR.Regress;
            }
        }

        return actionID;
    }
}

internal class ReaperHarpe : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RprAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RPR.Harpe)
        {
            if (IsEnabled(CustomComboPreset.ReaperHarpeSacrificiumFeature))
            {
                if (level >= RPR.Levels.Sacrificium && HasEffect(RPR.Buffs.Oblatio))
                    return RPR.Sacrificium;
            }

            if (IsEnabled(CustomComboPreset.ReaperHarpeHarvestSoulsowFeature))
            {
                if (level >= RPR.Levels.Soulsow && !HasEffect(RPR.Buffs.Soulsow) && (!InCombat() || !TargetIsEnemy()))
                    return RPR.Soulsow;
            }

            if (IsEnabled(CustomComboPreset.ReaperHarpePerfectioFeature))
            {
                if (level >= RPR.Levels.Perfectio && HasEffect(RPR.Buffs.PerfectioParata))
                    return RPR.Perfectio;
            }

            if (IsEnabled(CustomComboPreset.ReaperHarpeHarvestMoonFeature))
            {
                if (level >= RPR.Levels.HarvestMoon && HasEffect(RPR.Buffs.Soulsow))
                {
                    if (IsEnabled(CustomComboPreset.ReaperHarpeHarvestMoonEnhancedFeature))
                    {
                        if (HasEffect(RPR.Buffs.EnhancedHarpe))
                            return RPR.Harpe;
                    }

                    if (IsEnabled(CustomComboPreset.ReaperHarpeHarvestMoonCombatFeature))
                    {
                        if (!InCombat())
                            return RPR.Harpe;
                    }

                    return RPR.HarvestMoon;
                }
            }
        }

        return actionID;
    }
}
