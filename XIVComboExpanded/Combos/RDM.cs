using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

internal static class RDM
{
    public const byte JobID = 35;

    public const uint
        Jolt = 7503,
        Riposte = 7504,
        Verthunder = 7505,
        Veraero = 7507,
        Scatter = 7509,
        Verfire = 7510,
        Verstone = 7511,
        Zwerchhau = 7512,
        Moulinet = 7513,
        Vercure = 7514,
        Redoublement = 7516,
        Fleche = 7517,
        Acceleration = 7518,
        ContreSixte = 7519,
        Embolden = 7520,
        Manafication = 7521,
        Verraise = 7523,
        Jolt2 = 7524,
        Verflare = 7525,
        Verholy = 7526,
        EnchantedRiposte = 7527,
        EnchantedZwerchhau = 7528,
        EnchantedRedoublement = 7529,
        Verthunder2 = 16524,
        Veraero2 = 16525,
        Impact = 16526,
        Scorch = 16530,
        Verthunder3 = 25855,
        Veraero3 = 25856,
        Resolution = 25858,
        ViceOfThorns = 37005,
        GrandImpact = 37006,
        Prefulgence = 37007;

    public static class Buffs
    {
        public const ushort
            Swiftcast = 167,
            VerfireReady = 1234,
            VerstoneReady = 1235,
            Acceleration = 1238,
            Manafication = 1239,
            Dualcast = 1249,
            LostChainspell = 2560,
            ThornedFlourish = 3876,
            GrandImpactReady = 3877,
            PrefulgenceReady = 3878;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            Jolt = 2,
            Verthunder = 4,
            Veraero = 10,
            Scatter = 15,
            Zwerchhau = 35,
            Fleche = 45,
            Redoublement = 50,
            Acceleration = 50,
            Vercure = 54,
            ContreSixte = 56,
            Embolden = 58,
            Manafication = 60,
            Jolt2 = 62,
            Verraise = 64,
            Impact = 66,
            Verflare = 68,
            Verholy = 70,
            Scorch = 80,
            Veraero3 = 82,
            Verthunder3 = 82,
            Resolution = 90,
            ViceOfThorns = 92,
            GrandImpact = 96,
            Prefulgence = 100;
    }
}

internal class RedMageVeraeroVerthunder : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RdmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RDM.Veraero || actionID == RDM.Veraero3 || actionID == RDM.Verthunder || actionID == RDM.Verthunder3)
        {
            var gauge = GetJobGauge<RDMGauge>();

            if (IsEnabled(CustomComboPreset.RedMageVeraeroVerthunderCapstoneCombo))
            {
                if (HasEffect(RDM.Buffs.PrefulgenceReady) && IsEnabled(CustomComboPreset.RedMageVeraeroVerthunderCapstonePrefulgenceCombo))
                    return RDM.Prefulgence;

                if (lastComboMove == RDM.Scorch && level >= RDM.Levels.Resolution)
                    return RDM.Resolution;

                if ((lastComboMove == RDM.Verflare || lastComboMove == RDM.Verholy) && level >= RDM.Levels.Scorch)
                    return RDM.Scorch;

                if (gauge.ManaStacks == 3)
                {
                    if (actionID == RDM.Verthunder || actionID == RDM.Verthunder3)
                    {
                        if (level >= RDM.Levels.Verflare)
                            return RDM.Verflare;
                    }

                    if (actionID == RDM.Veraero || actionID == RDM.Veraero3)
                    {
                        if (level >= RDM.Levels.Verholy)
                            return RDM.Verholy;

                        // From 68-70
                        if (level >= RDM.Levels.Verflare)
                            return RDM.Verflare;
                    }
                }
            }
        }

        return actionID;
    }
}

internal class RedMageVeraeroVerthunder2 : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RdmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RDM.Veraero2 || actionID == RDM.Verthunder2)
        {
            var gauge = GetJobGauge<RDMGauge>();

            if (IsEnabled(CustomComboPreset.RedMageAoECapstoneCombo))
            {
                if (HasEffect(RDM.Buffs.PrefulgenceReady) && IsEnabled(CustomComboPreset.RedMageAoECapstonePrefulgenceCombo))
                    return RDM.Prefulgence;

                if (lastComboMove == RDM.Scorch && level >= RDM.Levels.Resolution)
                    return RDM.Resolution;

                if ((lastComboMove == RDM.Verflare || lastComboMove == RDM.Verholy) && level >= RDM.Levels.Scorch)
                    return RDM.Scorch;

                // While it transforms natively, we need to include this due to the RedMageAoeFeature below.
                if (gauge.ManaStacks == 3)
                {
                    if (actionID == RDM.Verthunder2)
                    {
                        if (level >= RDM.Levels.Verflare)
                            return RDM.Verflare;
                    }

                    if (actionID == RDM.Veraero2)
                    {
                        if (level >= RDM.Levels.Verholy)
                            return RDM.Verholy;

                        // From 68-70
                        if (level >= RDM.Levels.Verflare)
                            return RDM.Verflare;
                    }
                }
            }

            if (IsEnabled(CustomComboPreset.RedMageAoEFeature))
            {
                if (level >= RDM.Levels.Scatter && (HasEffect(RDM.Buffs.Dualcast) || HasEffect(RDM.Buffs.Acceleration) || HasEffect(RDM.Buffs.Swiftcast) || HasEffect(RDM.Buffs.LostChainspell)))
                    return OriginalHook(RDM.Scatter);
            }
        }

        return actionID;
    }
}

internal class RedMageRedoublementMoulinet : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RdmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RDM.Redoublement || actionID == RDM.Moulinet)
        {
            var gauge = GetJobGauge<RDMGauge>();

            if (IsEnabled(CustomComboPreset.RedMageMeleeCapstoneCombo))
            {
                if (HasEffect(RDM.Buffs.PrefulgenceReady) && IsEnabled(CustomComboPreset.RedMageMeleeCapstonePrefulgenceCombo))
                    return RDM.Prefulgence;

                if (lastComboMove == RDM.Scorch && level >= RDM.Levels.Resolution)
                    return RDM.Resolution;

                if ((lastComboMove == RDM.Verflare || lastComboMove == RDM.Verholy) && level >= RDM.Levels.Scorch)
                    return RDM.Scorch;
            }

            if (IsEnabled(CustomComboPreset.RedMageMeleeManaStacksFeature))
            {
                if (gauge.ManaStacks == 3 && level >= RDM.Levels.Verflare)
                {
                    if (level < RDM.Levels.Verholy)
                        return RDM.Verflare;

                    if (gauge.BlackMana >= gauge.WhiteMana)
                    {
                        if (HasEffect(RDM.Buffs.VerstoneReady) && !HasEffect(RDM.Buffs.VerfireReady) && (gauge.BlackMana - gauge.WhiteMana <= 9))
                            return RDM.Verflare;

                        return RDM.Verholy;
                    }
                    else
                    {
                        if (HasEffect(RDM.Buffs.VerfireReady) && !HasEffect(RDM.Buffs.VerstoneReady) && (gauge.WhiteMana - gauge.BlackMana <= 9))
                            return RDM.Verholy;

                        return RDM.Verflare;
                    }
                }
            }
        }

        if (actionID == RDM.Redoublement)
        {
            if (IsEnabled(CustomComboPreset.RedMageMeleeCombo))
            {
                if (lastComboMove == RDM.Zwerchhau && level >= RDM.Levels.Redoublement)
                    // Enchanted
                    return OriginalHook(RDM.Redoublement);

                if ((lastComboMove == RDM.Riposte || lastComboMove == RDM.EnchantedRiposte) && level >= RDM.Levels.Zwerchhau)
                    // Enchanted
                    return OriginalHook(RDM.Zwerchhau);

                // Enchanted
                return OriginalHook(RDM.Riposte);
            }
        }

        return actionID;
    }
}

internal class RedMageVerstoneVerfire : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RdmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RDM.Verstone)
        {
            var gauge = GetJobGauge<RDMGauge>();

            if (IsEnabled(CustomComboPreset.RedMageVerprocCapstoneCombo))
            {
                if (HasEffect(RDM.Buffs.PrefulgenceReady) && IsEnabled(CustomComboPreset.RedMageVerprocCapstonePrefulgenceCombo))
                    return RDM.Prefulgence;

                if (lastComboMove == RDM.Scorch && level >= RDM.Levels.Resolution)
                    return RDM.Resolution;

                if ((lastComboMove == RDM.Verflare || lastComboMove == RDM.Verholy) && level >= RDM.Levels.Scorch)
                    return RDM.Scorch;
            }

            if (IsEnabled(CustomComboPreset.RedMageVerprocManaStacksFeature))
            {
                if (gauge.ManaStacks == 3)
                {
                    if (level >= RDM.Levels.Verholy)
                        return RDM.Verholy;

                    // From 68-70
                    if (level >= RDM.Levels.Verflare)
                        return RDM.Verflare;
                }
            }

            if (IsEnabled(CustomComboPreset.RedMageVerprocPlusFeature))
            {
                if (!IsEnabled(CustomComboPreset.RedMageGrandImpactDeprioritize) && HasEffect(RDM.Buffs.GrandImpactReady))
                    return RDM.GrandImpact;

                if (level >= RDM.Levels.Veraero && (HasEffect(RDM.Buffs.Dualcast) || HasEffect(RDM.Buffs.Acceleration) || HasEffect(RDM.Buffs.Swiftcast) || HasEffect(RDM.Buffs.LostChainspell)))
                    // Veraero3
                    return OriginalHook(RDM.Veraero);
            }

            if (IsEnabled(CustomComboPreset.RedMageVerprocOpenerStoneFeature))
            {
                if (level >= RDM.Levels.Veraero && !InCombat() && !HasEffect(RDM.Buffs.VerstoneReady))
                    // Veraero3
                    return OriginalHook(RDM.Veraero);
            }

            if (IsEnabled(CustomComboPreset.RedMageVerprocFeature))
            {
                if (!IsEnabled(CustomComboPreset.RedMageVerprocGrandImpactDeprioritize) && HasEffect(RDM.Buffs.GrandImpactReady))
                    return RDM.GrandImpact;

                if (HasEffect(RDM.Buffs.VerstoneReady))
                    return RDM.Verstone;

                // Jolt
                return OriginalHook(RDM.Jolt2);
            }
        }

        if (actionID == RDM.Verfire)
        {
            var gauge = GetJobGauge<RDMGauge>();

            if (IsEnabled(CustomComboPreset.RedMageVerprocCapstoneCombo))
            {
                if (lastComboMove == RDM.Scorch && level >= RDM.Levels.Resolution)
                    return RDM.Resolution;

                if ((lastComboMove == RDM.Verflare || lastComboMove == RDM.Verholy) && level >= RDM.Levels.Scorch)
                    return RDM.Scorch;
            }

            if (IsEnabled(CustomComboPreset.RedMageVerprocManaStacksFeature))
            {
                if (gauge.ManaStacks == 3)
                {
                    if (level >= RDM.Levels.Verflare)
                        return RDM.Verflare;
                }
            }

            if (IsEnabled(CustomComboPreset.RedMageVerprocPlusFeature))
            {
                if (!IsEnabled(CustomComboPreset.RedMageGrandImpactDeprioritize) && HasEffect(RDM.Buffs.GrandImpactReady))
                    return RDM.GrandImpact;

                if (level >= RDM.Levels.Verthunder && (HasEffect(RDM.Buffs.Dualcast) || HasEffect(RDM.Buffs.Acceleration) || HasEffect(RDM.Buffs.Swiftcast) || HasEffect(RDM.Buffs.LostChainspell)))
                    // Verthunder3
                    return OriginalHook(RDM.Verthunder);
            }

            if (IsEnabled(CustomComboPreset.RedMageVerprocOpenerFireFeature))
            {
                if (level >= RDM.Levels.Verthunder && !InCombat() && !HasEffect(RDM.Buffs.VerfireReady))
                    // Verthunder3
                    return OriginalHook(RDM.Verthunder);
            }

            if (IsEnabled(CustomComboPreset.RedMageVerprocFeature))
            {
                if (!IsEnabled(CustomComboPreset.RedMageVerprocGrandImpactDeprioritize) && HasEffect(RDM.Buffs.GrandImpactReady))
                    return RDM.GrandImpact;

                if (HasEffect(RDM.Buffs.VerfireReady))
                    return RDM.Verfire;

                // Jolt
                return OriginalHook(RDM.Jolt2);
            }
        }

        return actionID;
    }
}

internal class RedMageAcceleration : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RdmAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RDM.Acceleration)
        {
            if (level >= RDM.Levels.Acceleration)
            {
                if (IsEnabled(CustomComboPreset.RedMageAccelerationGrandImpactFeature) && HasEffect(RDM.Buffs.GrandImpactReady))
                    return RDM.GrandImpact;

                if (IsEnabled(CustomComboPreset.RedMageAccelerationSwiftcastFeature))
                {
                    if (IsEnabled(CustomComboPreset.RedMageAccelerationSwiftcastOption))
                    {
                        if (IsCooldownUsable(RDM.Acceleration) && IsCooldownUsable(ADV.Swiftcast))
                            return ADV.Swiftcast;
                    }

                    if (IsCooldownUsable(RDM.Acceleration))
                        return RDM.Acceleration;

                    if (IsCooldownUsable(ADV.Swiftcast))
                        return ADV.Swiftcast;
                }

                return RDM.Acceleration;
            }

            if (level >= ADV.Levels.Swiftcast)
                return ADV.Swiftcast;
        }

        return actionID;
    }
}

internal class RedMageEmbolden : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RedMageEmboldenFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RDM.Embolden)
        {
            if (level >= RDM.Levels.Manafication && !IsCooldownUsable(RDM.Embolden))
            {
                if (IsCooldownUsable(RDM.Manafication))
                    return RDM.Manafication;
                if (HasEffect(RDM.Buffs.ThornedFlourish))
                    return RDM.ViceOfThorns;
                if (HasEffect(RDM.Buffs.PrefulgenceReady) || HasEffect(RDM.Buffs.Manafication))
                    return RDM.Prefulgence;
            }
        }

        return actionID;
    }
}

internal class RedMageContreSixteFleche : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RedMageContreFlecheFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == RDM.ContreSixte || actionID == RDM.Fleche)
        {
            if (level >= RDM.Levels.ContreSixte)
                return CalcBestAction(actionID, RDM.Fleche, RDM.ContreSixte);

            if (level >= RDM.Levels.Fleche)
                return RDM.Fleche;
        }

        return actionID;
    }
}
