using Dalamud.Game.ClientState.Conditions;

namespace XIVComboExpandedPlugin.Combos
{
    internal static class NIN
    {
        public const byte ClassID = 29;
        public const byte JobID = 30;

        public const uint
            SpinningEdge = 2240,
            GustSlash = 2242,
            Hide = 2245,
            Assassinate = 8814,
            Mug = 2248,
            DeathBlossom = 2254,
            AeolianEdge = 2255,
            TrickAttack = 2258,
            Ninjutsu = 2260,
            Chi = 2261,
            JinNormal = 2263,
            Kassatsu = 2264,
            ArmorCrush = 3563,
            DreamWithinADream = 3566,
            TenChiJin = 7403,
            HakkeMujinsatsu = 16488,
            Meisui = 16489,
            Jin = 18807,
            Bunshin = 16493,
            Huraijin = 25876,
            PhantomKamaitachi = 25774,
            ForkedRaiju = 25777,
            FleetingRaiju = 25778;

        public static class Buffs
        {
            public const ushort
                Mudra = 496,
                Kassatsu = 497,
                Suiton = 507,
                Hidden = 614,
                Bunshin = 1954,
                ForkedRaijuReady = 2690,
                FleetingRaijuReady = 2691;
        }

        public static class Debuffs
        {
            public const ushort
                Placeholder = 0;
        }

        public static class Levels
        {
            public const byte
                GustSlash = 4,
                Hide = 10,
                Mug = 15,
                AeolianEdge = 26,
                Ninjitsu = 30,
                Suiton = 45,
                HakkeMujinsatsu = 52,
                ArmorCrush = 54,
                Huraijin = 60,
                TenChiJin = 70,
                Meisui = 72,
                EnhancedKassatsu = 76,
                Bunshin = 80,
                PhantomKamaitachi = 82,
                ForkedRaiju = 90;
        }
    }

    internal class NinjaGCDNinjutsuFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinjaGCDNinjutsuFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { NIN.AeolianEdge, NIN.ArmorCrush, NIN.HakkeMujinsatsu };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == NIN.AeolianEdge || actionID == NIN.ArmorCrush || actionID == NIN.HakkeMujinsatsu)
            {
                if (level >= NIN.Levels.Ninjitsu && HasEffect(NIN.Buffs.Mudra))
                    return OriginalHook(NIN.Ninjutsu);
            }

            return actionID;
        }
    }

    internal class NinjaArmorCrushCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinAny;

        protected internal override uint[] ActionIDs { get; } = new[] { NIN.ArmorCrush };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == NIN.ArmorCrush)
            {
                if (IsEnabled(CustomComboPreset.NinjaArmorCrushRaijuFeature))
                {
                    if (level >= NIN.Levels.ForkedRaiju && HasEffect(NIN.Buffs.FleetingRaijuReady))
                        return NIN.FleetingRaiju;

                    if (level >= NIN.Levels.ForkedRaiju && HasEffect(NIN.Buffs.ForkedRaijuReady))
                        return NIN.ForkedRaiju;
                }

                if (IsEnabled(CustomComboPreset.NinjaArmorCrushCombo))
                {
                    if (comboTime > 0)
                    {
                        if (lastComboMove == NIN.GustSlash && level >= NIN.Levels.ArmorCrush)
                            return NIN.ArmorCrush;

                        if (lastComboMove == NIN.SpinningEdge && level >= NIN.Levels.GustSlash)
                            return NIN.GustSlash;
                    }

                    return NIN.SpinningEdge;
                }
            }

            return actionID;
        }
    }

    internal class NinjaAeolianEdgeCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinAny;

        protected internal override uint[] ActionIDs { get; } = new[] { NIN.AeolianEdge };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == NIN.AeolianEdge)
            {
                if (IsEnabled(CustomComboPreset.NinjaAeolianEdgeRaijuFeature))
                {
                    if (level >= NIN.Levels.ForkedRaiju && HasEffect(NIN.Buffs.FleetingRaijuReady))
                        return NIN.FleetingRaiju;

                    if (level >= NIN.Levels.ForkedRaiju && HasEffect(NIN.Buffs.ForkedRaijuReady))
                        return NIN.ForkedRaiju;
                }

                if (IsEnabled(CustomComboPreset.NinjaAeolianEdgeCombo))
                {
                    if (comboTime > 0)
                    {
                        if (lastComboMove == NIN.GustSlash && level >= NIN.Levels.AeolianEdge)
                            return NIN.AeolianEdge;

                        if (lastComboMove == NIN.SpinningEdge && level >= NIN.Levels.GustSlash)
                            return NIN.GustSlash;
                    }

                    return NIN.SpinningEdge;
                }
            }

            return actionID;
        }
    }

    internal class NinjaHakkeMujinsatsuCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinjaHakkeMujinsatsuCombo;

        protected internal override uint[] ActionIDs { get; } = new[] { NIN.HakkeMujinsatsu };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == NIN.HakkeMujinsatsu)
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == NIN.DeathBlossom && level >= NIN.Levels.HakkeMujinsatsu)
                        return NIN.HakkeMujinsatsu;
                }

                return NIN.DeathBlossom;
            }

            return actionID;
        }
    }

    internal class NinjaKassatsuTrickFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinjaKassatsuTrickFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { NIN.Kassatsu };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == NIN.Kassatsu)
            {
                if (level >= NIN.Levels.Hide && HasEffect(NIN.Buffs.Hidden))
                    return NIN.TrickAttack;

                if (level >= NIN.Levels.Suiton && HasEffect(NIN.Buffs.Suiton))
                    return NIN.TrickAttack;
            }

            return actionID;
        }
    }

    internal class NinjaHideMugFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinjaHideMugFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { NIN.Hide };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == NIN.Hide)
            {
                if (level >= NIN.Levels.Mug && HasCondition(ConditionFlag.InCombat))
                    return NIN.Mug;
            }

            return actionID;
        }
    }

    internal class NinjaKassatsuChiJinFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinjaKassatsuChiJinFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { NIN.Chi };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == NIN.Chi)
            {
                if (level >= NIN.Levels.EnhancedKassatsu && HasEffect(NIN.Buffs.Kassatsu))
                    return NIN.Jin;
            }

            return actionID;
        }
    }

    internal class NinjaTCJMeisuiFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinjaTCJMeisuiFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { NIN.TenChiJin };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == NIN.TenChiJin)
            {
                if (level >= NIN.Levels.Meisui && HasEffect(NIN.Buffs.Suiton))
                    return NIN.Meisui;
            }

            return actionID;
        }
    }

    internal class NinjaBunshinKamaitachiFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinjaBunshinKamaitachiFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { NIN.Bunshin };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == NIN.Bunshin)
            {
                if (level >= NIN.Levels.PhantomKamaitachi && HasEffect(NIN.Buffs.Bunshin))
                    return NIN.PhantomKamaitachi;
            }

            return actionID;
        }
    }

    internal class NinjaHuraijinRaijuFeature : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinjaHuraijinRaijuFeature;

        protected internal override uint[] ActionIDs { get; } = new[] { NIN.Huraijin };

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == NIN.Huraijin)
            {
                if (level >= NIN.Levels.ForkedRaiju && HasEffect(NIN.Buffs.FleetingRaijuReady))
                    return NIN.FleetingRaiju;

                if (level >= NIN.Levels.ForkedRaiju && HasEffect(NIN.Buffs.ForkedRaijuReady))
                    return NIN.ForkedRaiju;
            }

            return actionID;
        }
    }
}
