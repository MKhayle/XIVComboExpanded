using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos
{
    internal static class AST
    {
        public const byte JobID = 33;

        public const uint
            Benefic = 3594,
            Benefic2 = 3610,
            Draw = 3590,
            Balance = 4401,
            Bole = 4404,
            Arrow = 4402,
            Spear = 4403,
            Ewer = 4405,
            Spire = 4406,
            MinorArcana = 7443,
            Play = 17055,
            CrownPlay = 25869,
            Astrodyne = 25870;

        public static class Buffs
        {
            public const ushort
                LordOfCrownsDrawn = 2054,
                LadyOfCrownsDrawn = 2055;
        }

        public static class Debuffs
        {
            public const ushort
                Placeholder = 0;
        }

        public static class Levels
        {
            public const byte
                Benefic2 = 26,
                Draw = 30,
                Astrodyne = 50,
                MinorArcana = 70,
                CrownPlay = 70;
        }
    }

    internal class AstrologianCardsOnDrawFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.AstAny;

        protected internal override uint[] ActionIDs { get; } = new[] { AST.Play };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == AST.Play)
            {
                var gauge = GetJobGauge<ASTGauge>();

                if (IsEnabled(CustomComboPreset.AstrologianAstrodynePlayFeature))
                {
                    if (level >= AST.Levels.Astrodyne && !gauge.ContainsSeal(SealType.NONE))
                        return AST.Astrodyne;
                }

                if (IsEnabled(CustomComboPreset.AstrologianDrawPlayFeature))
                {
                    if (level >= AST.Levels.Draw && gauge.DrawnCard == CardType.NONE)
                        return AST.Draw;
                }
            }

            return actionID;
        }
    }

    internal class AstrologianMinorArcanaPlayFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.AstrologianMinorArcanaPlayFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { AST.MinorArcana };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == AST.MinorArcana)
            {
                var gauge = GetJobGauge<ASTGauge>();
                if (level >= AST.Levels.CrownPlay && gauge.DrawnCrownCard != CardType.NONE)
                    return OriginalHook(AST.CrownPlay);
            }

            return actionID;
        }
    }

    internal class AstrologianBeneficFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.AstrologianBeneficFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { AST.Benefic2 };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == AST.Benefic2)
            {
                if (level < AST.Levels.Benefic2)
                    return AST.Benefic;
            }

            return actionID;
        }
    }
}
