using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

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
        Kassatsu = 2264,
        Suiton = 2271,
        ArmorCrush = 3563,
        DreamWithinADream = 3566,
        Hellfrog = 7401,
        Bhavacakra = 7402,
        TenChiJin = 7403,
        HakkeMujinsatsu = 16488,
        Meisui = 16489,
        Bunshin = 16493,
        Huraijin = 25876,
        PhantomKamaitachi = 25774,
        ForkedRaiju = 25777,
        FleetingRaiju = 25778,
        Dokumori = 36957,

        // Ninjutsu
        Ten = 2259, // Normal version on your bar, with charges
        Chi = 2261,
        Jin = 2263,
        TenMudra = 18805, // No-cooldown version that only appears during a Mudra cast, after the first symbol
        ChiMudra = 18806,
        JinMudra = 18807;
    public static class Buffs
    {
        public const ushort
            Mudra = 496,
            Kassatsu = 497,
            Suiton = 507,
            Hidden = 614,
            Bunshin = 1954,
            RaijuReady = 2690,
            ShadowWalker = 3848,
            Higi = 3850,
            TenChiJin = 1186;
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
            TrickAttack = 18,
            AeolianEdge = 26,
            Ninjutsu = 30,
            Suiton = 45,
            Kassatsu = 50,
            HakkeMujinsatsu = 52,
            ArmorCrush = 54,
            Huraijin = 60,
            Hellfrog = 62,
            Dokumori = 66,
            Bhavacakra = 68,
            TenChiJin = 70,
            Meisui = 72,
            EnhancedKassatsu = 76,
            Bunshin = 80,
            PhantomKamaitachi = 82,
            Raiju = 90,
            KunaisBane = 92,
            TenriJindo = 100;
    }
}

internal class NinjaAeolianEdge : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == NIN.AeolianEdge)
        {
            var gauge = GetJobGauge<NINGauge>();

            if (IsEnabled(CustomComboPreset.NinjaAeolianNinjutsuFeature))
            {
                if (level >= NIN.Levels.Ninjutsu && HasEffect(NIN.Buffs.Mudra))
                    return OriginalHook(NIN.Ninjutsu);
            }

            if (IsEnabled(CustomComboPreset.NinjaAeolianEdgeFleetingRaijuFeature))
            {
                if (level >= NIN.Levels.Raiju && HasEffect(NIN.Buffs.RaijuReady))
                    return NIN.FleetingRaiju;
            }

            if (level >= NIN.Levels.Raiju && HasEffect(NIN.Buffs.RaijuReady))
            {
                if (IsEnabled(CustomComboPreset.NinjaAeolianEdgeFleetingRaijuFeature))
                    return NIN.FleetingRaiju;

                if (IsEnabled(CustomComboPreset.NinjaAeolianEdgeForkedRaijuFeature))
                    return NIN.ForkedRaiju;
            }

            if (IsEnabled(CustomComboPreset.NinjaKazematoiFeature))
            {
                if (lastComboMove == NIN.GustSlash && level >= NIN.Levels.ArmorCrush && gauge.Kazematoi <= 3 &&
                    (IsEnabled(CustomComboPreset.NinjaOvercapKazematoiFeature) || gauge.Kazematoi == 0))
                    return NIN.ArmorCrush;
            }

            if (IsEnabled(CustomComboPreset.NinjaAeolianEdgeCombo))
            {
                if (lastComboMove == NIN.GustSlash && level >= NIN.Levels.AeolianEdge)
                    return NIN.AeolianEdge;

                if (lastComboMove == NIN.SpinningEdge && level >= NIN.Levels.GustSlash)
                    return NIN.GustSlash;

                return NIN.SpinningEdge;
            }
        }

        return actionID;
    }
}

internal class NinjaArmorCrush : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == NIN.ArmorCrush)
        {
            if (level >= NIN.Levels.Raiju && HasEffect(NIN.Buffs.RaijuReady))
            {
                if (IsEnabled(CustomComboPreset.NinjaArmorCrushFleetingRaijuFeature))
                    return NIN.FleetingRaiju;

                if (IsEnabled(CustomComboPreset.NinjaArmorCrushForkedRaijuFeature))
                    return NIN.ForkedRaiju;
            }

            if (IsEnabled(CustomComboPreset.NinjaArmorCrushNinjutsuFeature))
            {
                if (level >= NIN.Levels.Ninjutsu && HasEffect(NIN.Buffs.Mudra))
                    return OriginalHook(NIN.Ninjutsu);
            }

            if (IsEnabled(CustomComboPreset.NinjaArmorCrushCombo))
            {
                if (lastComboMove == NIN.GustSlash && level >= NIN.Levels.ArmorCrush)
                    return NIN.ArmorCrush;

                if (lastComboMove == NIN.SpinningEdge && level >= NIN.Levels.GustSlash)
                    return NIN.GustSlash;

                return NIN.SpinningEdge;
            }
        }

        return actionID;
    }
}

internal class NinjaHakkeMujinsatsu : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == NIN.HakkeMujinsatsu)
        {
            if (IsEnabled(CustomComboPreset.NinjaHakkeMujinsatsuNinjutsuFeature))
            {
                if (level >= NIN.Levels.Ninjutsu && HasEffect(NIN.Buffs.Mudra))
                    return OriginalHook(NIN.Ninjutsu);
            }

            if (IsEnabled(CustomComboPreset.NinjaHakkeMujinsatsuCombo))
            {
                if (lastComboMove == NIN.DeathBlossom && level >= NIN.Levels.HakkeMujinsatsu)
                    return NIN.HakkeMujinsatsu;

                return NIN.DeathBlossom;
            }
        }

        return actionID;
    }
}

internal class NinjaKassatsu : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinjaKassatsuTrickFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == NIN.Kassatsu)
        {
            if (level >= NIN.Levels.TrickAttack && IsCooldownUsable(NIN.TrickAttack) &&
                ((level >= NIN.Levels.Hide && HasEffect(NIN.Buffs.Hidden)) ||
                (level >= NIN.Levels.Suiton && HasEffect(NIN.Buffs.ShadowWalker))))
                return OriginalHook(NIN.TrickAttack);
        }

        return actionID;
    }
}

internal class NinjaHide : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == NIN.Hide)
        {
            if (IsEnabled(CustomComboPreset.NinjaHideNinjutsuFeature) &&
                level >= NIN.Levels.Ninjutsu && HasEffect(NIN.Buffs.Mudra))
                return OriginalHook(NIN.Ninjutsu);

            if (IsEnabled(CustomComboPreset.NinjaHideMugFeature) && level >= NIN.Levels.Mug &&
                (InCombat() || HasEffect(NIN.Buffs.Hidden)))
            {
                return OriginalHook(NIN.Mug);
            }
        }

        return actionID;
    }
}

internal class NinjaChi : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinjaKassatsuChiJinFeature;

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

internal class NinjaTenChiJin : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinjaTCJMeisuiFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == NIN.TenChiJin)
        {
            if (level >= NIN.Levels.Meisui && HasEffect(NIN.Buffs.ShadowWalker))
                return NIN.Meisui;
        }

        return actionID;
    }
}

internal class NinjaNinjutsu : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinAny;

    protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
    {
        if (actionID == NIN.Ninjutsu)
        {
            if (level >= NIN.Levels.Raiju && HasEffect(NIN.Buffs.RaijuReady) && !HasEffect(NIN.Buffs.Mudra))
            {
                if (IsEnabled(CustomComboPreset.NinjaNinjutsuForkedRaijuFeature))
                    return NIN.ForkedRaiju;

                if (IsEnabled(CustomComboPreset.NinjaNinjutsuFleetingRaijuFeature))
                    return NIN.FleetingRaiju;
            }
        }

        return actionID;
    }
}

internal class NinjaFrogLevelSync : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinjaFrogLevelSyncFeature;

    protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
    {
        if (actionID == NIN.Bhavacakra)
        {
            if (level < NIN.Levels.Bhavacakra)
            {
                return NIN.Hellfrog;
            }
        }

        return actionID;
    }
}

internal class KassatsuTrickDream : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinjaDreamyTrickAttack;
    protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
    {
        if (actionID == NIN.Kassatsu)
        {
            if (!IsCooldownUsable(NIN.Kassatsu) && HasEffect(NIN.Buffs.ShadowWalker))
                return OriginalHook(NIN.TrickAttack);
        }

        if (actionID == NIN.Kassatsu && !IsCooldownUsable(NIN.Kassatsu) && !IsCooldownUsable(NIN.TrickAttack))
            return NIN.DreamWithinADream;

        return actionID;
    }
}

internal class NinjaDokumoriConsolidationCombo : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.NinjaDokumoriConsolidationCombo;
    protected override uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level)
    {
        if (actionID == NIN.Dokumori && !IsCooldownUsable(NIN.Dokumori))
        {
            // Trigger Ten Chi Jin
            if (level >= NIN.Levels.TenChiJin && IsCooldownUsable(NIN.TenChiJin) && !HasEffect(NIN.Buffs.TenChiJin))
                return NIN.TenChiJin;

            // TCJ sequence
            // TODO - Find a way to get the mudra steps for ten chi jin consolidated also.
            if (level >= NIN.Levels.TenChiJin && !IsCooldownUsable(NIN.TenChiJin) && HasEffect(NIN.Buffs.TenChiJin))
            {
               float tcj = FindEffect(NIN.Buffs.TenChiJin).RemainingTime;
               if (tcj > 5)
                return OriginalHook(NIN.Ten);
               if (tcj > 4)
                return OriginalHook(NIN.Chi);
               if (tcj > 3)
                return OriginalHook(NIN.Jin);
            }

            // Meisui
            if (IsCooldownUsable(NIN.Meisui) && HasEffect(NIN.Buffs.ShadowWalker))
            {
                return NIN.Meisui;
            }
        }

        return actionID; // Default, don’t update LastActionID
    }
}