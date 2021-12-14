using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos
{
    internal static class RDM
    {
        public const byte JobID = 35;

        public const uint
            Verthunder = 7505,
            Veraero = 7507,
            Scatter = 7509,
            Veraero2 = 16525,
            Verthunder2 = 16524,
            Impact = 16526,
            Redoublement = 7516,
            EnchantedRedoublement = 7529,
            Zwerchhau = 7512,
            EnchantedZwerchhau = 7528,
            Riposte = 7504,
            EnchantedRiposte = 7527,
            Jolt = 7503,
            Verstone = 7511,
            Verfire = 7510,
            Moulinet = 7513,
            Fleche = 7517,
            ContreSixte = 7519,
            Jolt2 = 7524,
            Verholy = 7526,
            Verflare = 7525,
            Scorch = 16530,
            Resolution = 25858;

        public static class Buffs
        {
            public const ushort
                Swiftcast = 167,
                VerfireReady = 1234,
                VerstoneReady = 1235,
                Acceleration = 1238,
                Dualcast = 1249,
                LostChainspell = 2560;
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
                Vercure = 54,
                ContreSixte = 56,
                Jolt2 = 62,
                Verraise = 64,
                Impact = 66,
                Verflare = 68,
                Verholy = 70,
                Scorch = 80,
                Resolution = 90;
        }
    }

    internal class RedMageAoECombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RedMageAoECombo;

        protected internal override uint[] ActionIDs { get; } = new[] { RDM.Veraero2, RDM.Verthunder2 };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RDM.Veraero2 || actionID == RDM.Verthunder2)
            {
                if (level >= RDM.Levels.Scatter && (HasEffect(RDM.Buffs.Dualcast) || HasEffect(RDM.Buffs.Acceleration) || HasEffect(RDM.Buffs.Swiftcast) || HasEffect(RDM.Buffs.LostChainspell)))
                    return OriginalHook(RDM.Scatter);
            }

            return actionID;
        }
    }

    internal class RedMageMeleeCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RedMageMeleeCombo;

        protected internal override uint[] ActionIDs { get; } = new[] { RDM.Redoublement, RDM.Moulinet };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RDM.Redoublement || actionID == RDM.Moulinet)
            {
                var gauge = GetJobGauge<RDMGauge>();

                if (IsEnabled(CustomComboPreset.RedMageMeleeComboPlus))
                {
                    if (lastComboMove == RDM.Scorch && level >= RDM.Levels.Resolution)
                        return RDM.Resolution;

                    if ((lastComboMove == RDM.Verflare || lastComboMove == RDM.Verholy) && level >= RDM.Levels.Scorch)
                        return RDM.Scorch;

                    if (gauge.ManaStacks == 3)
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
                if (lastComboMove == RDM.Zwerchhau && level >= RDM.Levels.Redoublement)
                    // Enchanted
                    return OriginalHook(RDM.Redoublement);

                if ((lastComboMove == RDM.Riposte || lastComboMove == RDM.EnchantedRiposte) && level >= RDM.Levels.Zwerchhau)
                    // Enchanted
                    return OriginalHook(RDM.Zwerchhau);

                // Enchanted
                return OriginalHook(RDM.Riposte);
            }

            return actionID;
        }
    }

    internal class RedMageVerprocCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.RedMageVerprocCombo;

        protected internal override uint[] ActionIDs { get; } = new[] { RDM.Verstone, RDM.Verfire };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RDM.Verstone)
            {
                var gauge = GetJobGauge<RDMGauge>();

                if (lastComboMove == RDM.Scorch && level >= RDM.Levels.Resolution)
                    return RDM.Resolution;

                if ((lastComboMove == RDM.Verflare || lastComboMove == RDM.Verholy) && level >= RDM.Levels.Scorch)
                    return RDM.Scorch;

                if (level >= RDM.Levels.Verholy && gauge.ManaStacks == 3)
                    return RDM.Verholy;

                if (level >= RDM.Levels.Verflare && gauge.ManaStacks == 3)
                    return RDM.Verflare;

                if (IsEnabled(CustomComboPreset.RedMageVerprocComboPlus))
                {
                    if (level >= RDM.Levels.Veraero && (HasEffect(RDM.Buffs.Dualcast) || HasEffect(RDM.Buffs.Acceleration) || HasEffect(RDM.Buffs.Swiftcast) || HasEffect(RDM.Buffs.LostChainspell)))
                        // Veraero3
                        return OriginalHook(RDM.Veraero);
                }

                if (IsEnabled(CustomComboPreset.RedMageVerprocOpenerFeatureStone))
                {
                    if (level >= RDM.Levels.Veraero && !HasCondition(ConditionFlag.InCombat) && !HasEffect(RDM.Buffs.VerstoneReady))
                        // Veraero3
                        return OriginalHook(RDM.Veraero);
                }

                if (HasEffect(RDM.Buffs.VerstoneReady))
                    return RDM.Verstone;

                // Jolt
                return OriginalHook(RDM.Jolt2);
            }

            if (actionID == RDM.Verfire)
            {
                var gauge = GetJobGauge<RDMGauge>();

                if (level >= RDM.Levels.Resolution && lastComboMove == RDM.Scorch)
                    return RDM.Resolution;

                if (level >= RDM.Levels.Scorch && (lastComboMove == RDM.Verflare || lastComboMove == RDM.Verholy))
                    return RDM.Scorch;

                if (level >= RDM.Levels.Verflare && gauge.ManaStacks == 3)
                    return RDM.Verflare;

                if (IsEnabled(CustomComboPreset.RedMageVerprocComboPlus))
                {
                    if (level >= RDM.Levels.Verthunder && (HasEffect(RDM.Buffs.Dualcast) || HasEffect(RDM.Buffs.Acceleration) || HasEffect(RDM.Buffs.Swiftcast) || HasEffect(RDM.Buffs.LostChainspell)))
                        // Verthunder3
                        return OriginalHook(RDM.Verthunder);
                }

                if (IsEnabled(CustomComboPreset.RedMageVerprocOpenerFeatureFire))
                {
                    if (level >= RDM.Levels.Verthunder && !HasCondition(ConditionFlag.InCombat) && !HasEffect(RDM.Buffs.VerfireReady))
                        // Verthunder3
                        return OriginalHook(RDM.Verthunder);
                }

                if (HasEffect(RDM.Buffs.VerfireReady))
                    return RDM.Verfire;

                // Jolt
                return OriginalHook(RDM.Jolt2);
            }

            return actionID;
        }
    }

    internal class RedMageContreFlecheFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.Disabled; // RedMageContreFlecheFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { RDM.Fleche, RDM.ContreSixte };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == RDM.Fleche || actionID == RDM.ContreSixte)
            {
                if (level >= RDM.Levels.ContreSixte)
                    return CalcBestAction(actionID, RDM.Fleche, RDM.ContreSixte);

                if (level >= RDM.Levels.Fleche)
                    return RDM.Fleche;
            }

            return actionID;
        }
    }
}
