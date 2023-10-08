namespace XIVComboExpandedPlugin.Combos;

internal static class PLD
{
    public const byte ClassID = 1;
    public const byte JobID = 19;

    public const uint
        FastBlade = 9,
        RiotBlade = 15,
        ShieldBash = 16,
        FightOrFlight = 20,
        RageOfHalone = 21,
        CircleOfScorn = 23,
        ShieldLob = 24,
        SpiritsWithin = 29,
        GoringBlade = 3538,
        RoyalAuthority = 3539,
        Clemency = 3541,
        TotalEclipse = 7381,
        Requiescat = 7383,
        HolySpirit = 7384,
        LowBlow = 7540,
        Prominence = 16457,
        HolyCircle = 16458,
        Confiteor = 16459,
        Atonement = 16460,
        Expiacion = 25747,
        BladeOfFaith = 25748,
        BladeOfTruth = 25749,
        BladeOfValor = 25750;

    public static class Buffs
    {
        public const ushort
            FightOrFlight = 76,
            Requiescat = 1368,
            SwordOath = 1902,
            DivineMight = 2673,
            ConfiteorReady = 3019;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            FightOrFlight = 2,
            RiotBlade = 4,
            LowBlow = 12,
            SpiritsWithin = 30,
            CircleOfScorn = 50,
            RageOfHalone = 26,
            Prominence = 40,
            GoringBlade = 54,
            RoyalAuthority = 60,
            HolySpirit = 64,
            DivineMagicMastery = 64,
            Requiescat = 68,
            HolyCircle = 72,
            Atonement = 76,
            Confiteor = 80,
            Expiacion = 86,
            BladeOfFaith = 90,
            BladeOfTruth = 90,
            BladeOfValor = 90;
    }
}

internal abstract class PaladinCombo : CustomCombo
{
    protected bool HasMp(uint spell)
    {
        int cost;
        switch (spell)
        {
            case PLD.Clemency:
                cost = 4000;
                break;
            case PLD.HolySpirit:
            case PLD.HolyCircle:
            case PLD.Confiteor:
            case PLD.BladeOfFaith:
            case PLD.BladeOfTruth:
            case PLD.BladeOfValor:
                cost = 2000;
                break;
            default:
                cost = 0;
                break;
        }

        if (LocalPlayer?.Level >= PLD.Levels.DivineMagicMastery)
            cost /= 2;

        return LocalPlayer?.CurrentMp >= cost;
    }
}

internal class PaladinRoyalAuthority : PaladinCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PldAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.RageOfHalone || actionID == PLD.RoyalAuthority)
        {
            // During FoF, prioritize the higher-potency Divine Might cast over Atonement and the normal combo chain
            if (IsEnabled(CustomComboPreset.PaladinRoyalAuthorityFightOrFlightFeature))
            {
                if (HasEffect(PLD.Buffs.FightOrFlight) && HasEffect(PLD.Buffs.DivineMight))
                {
                    if (level >= PLD.Levels.HolySpirit && this.HasMp(PLD.HolySpirit))
                        return PLD.HolySpirit;
                }
            }

            if (IsEnabled(CustomComboPreset.PaladinRoyalAuthorityAtonementFeature))
            {
                if (level >= PLD.Levels.Atonement && lastComboMove != PLD.FastBlade && lastComboMove != PLD.RiotBlade && HasEffect(PLD.Buffs.SwordOath))
                    return PLD.Atonement;
            }

            if (IsEnabled(CustomComboPreset.PaladinRoyalAuthorityCombo))
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == PLD.RiotBlade && level >= PLD.Levels.RageOfHalone)
                    {
                        if (IsEnabled(CustomComboPreset.PaladinRoyalAuthorityDivineMightFeature))
                        {
                            if (HasEffect(PLD.Buffs.DivineMight))
                            {
                                if (level >= PLD.Levels.HolySpirit && this.HasMp(PLD.HolySpirit))
                                    return PLD.HolySpirit;
                            }
                        }

                        // Royal Authority
                        return OriginalHook(PLD.RageOfHalone);
                    }

                    if (lastComboMove == PLD.FastBlade && level >= PLD.Levels.RiotBlade)
                        return PLD.RiotBlade;
                }

                return PLD.FastBlade;
            }
        }

        return actionID;
    }
}

internal class PaladinProminence : PaladinCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PaladinProminenceCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.Prominence)
        {
            // During FoF, prioritize the higher-potency Divine Might cast over the normal combo chain
            if (IsEnabled(CustomComboPreset.PaladinProminenceDivineMightFeature))
            {
                if (HasEffect(PLD.Buffs.FightOrFlight) && HasEffect(PLD.Buffs.DivineMight))
                {
                    if (level >= PLD.Levels.HolyCircle && this.HasMp(PLD.HolyCircle))
                        return PLD.HolyCircle;
                }
            }

            if (comboTime > 0)
            {
                if (lastComboMove == PLD.TotalEclipse && level >= PLD.Levels.Prominence)
                {
                    if (IsEnabled(CustomComboPreset.PaladinProminenceDivineMightFeature))
                    {
                        if (HasEffect(PLD.Buffs.DivineMight))
                        {
                            if (level >= PLD.Levels.HolyCircle && this.HasMp(PLD.HolyCircle))
                                return PLD.HolyCircle;
                        }
                    }

                    return PLD.Prominence;
                }
            }

            return PLD.TotalEclipse;
        }

        return actionID;
    }
}

internal class PaladinHolySpiritHolyCircle : PaladinCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PaladinConfiteorFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.HolySpirit || actionID == PLD.HolyCircle)
        {
            if (level >= PLD.Levels.Confiteor)
            {
                var original = OriginalHook(PLD.Confiteor);
                if (original != PLD.Confiteor)
                    return original;

                if (HasEffect(PLD.Buffs.ConfiteorReady))
                    return PLD.Confiteor;
            }
        }

        return actionID;
    }
}

internal class PaladinHolySpirit : PaladinCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PaladinHolySpiritLevelSyncFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.HolySpirit)
        {
            if (level < PLD.Levels.HolySpirit)
            {
                return PLD.ShieldLob;
            }
        }

        return actionID;
    }
}

internal class PaladinFightOrFlight : PaladinCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PldAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.FightOrFlight)
        {
            if (IsEnabled(CustomComboPreset.PaladinFightOrFlightGoringBladeFeature))
            {
                if (level >= PLD.Levels.GoringBlade && HasEffect(PLD.Buffs.FightOrFlight) && IsOffCooldown(PLD.GoringBlade))
                    return PLD.GoringBlade;
            }
        }

        return actionID;
    }
}

internal class PaladinRequiescat : PaladinCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PldAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.Requiescat)
        {
            if (IsEnabled(CustomComboPreset.PaladinRequiescatCombo))
            {
                // Prioritize Goring Blade over the Confiteor combo.  While Goring Blade deals less damage (700p) than
                // most of the Confiteor combo (900p -> 700p -> 800p -> 900p), Goring Blade uniquely requires melee
                // range to cast, while the entire Confiteor combo chain does not.  Since Requiescat also requires
                // melee range to cast, the most reliable time that the player will be in melee range during the Req
                // buff is immediately following the usage of Req.  This minimizes potential losses and potential
                // cooldown drift if the player is forced out of melee range during the Confiteor combo and is unable
                // to return to melee range by the time it is completed.
                //
                // Since Goring Blade, the entire Confiteor combo, *and* one additional GCD (typically Holy Spirit) fits
                // within even the shortest of party buffs (15s ones like Battle Litany), this should not result in a
                // net reduction in potency, and *may* in fact increase it if someone is slightly late in applying
                // their party buffs, as it shifts the high-potency Confiteor cast back into the party buff window by a
                // single GCD.
                if (IsEnabled(CustomComboPreset.PaladinRequiescatFightOrFlightFeature) && IsEnabled(CustomComboPreset.PaladinFightOrFlightGoringBladeFeature))
                {
                    if (level >= PLD.Levels.GoringBlade && IsOffCooldown(PLD.GoringBlade))
                    {
                        if (IsOnCooldown(PLD.FightOrFlight) && (level < PLD.Levels.Requiescat || IsOnCooldown(PLD.Requiescat)))
                            return PLD.GoringBlade;
                    }
                }

                if (level >= PLD.Levels.Confiteor)
                {
                    // Blade combo
                    var original = OriginalHook(PLD.Confiteor);
                    if (original != PLD.Confiteor)
                        return original;

                    if (HasEffect(PLD.Buffs.ConfiteorReady))
                        return PLD.Confiteor;
                }

                if (level >= PLD.Levels.Requiescat && HasEffect(PLD.Buffs.Requiescat))
                    return PLD.HolySpirit;
            }

            if (IsEnabled(CustomComboPreset.PaladinRequiescatFightOrFlightFeature))
            {
                // Prefer FoF if it is off cooldown, or if it will be ready sooner than Requiescat.  In practice, this
                // means that Req should only be returned if FoF is on cooldown and Req is not, ie. immediately after
                // FoF is cast.  This ensures that the button shows the action that will next be available for use in
                // that hotbar slot, rather than swapping to FoF at the last instant when FoF comes off cooldown a
                // a single weave slot earlier than Req.
                if (level >= PLD.Levels.FightOrFlight)
                    return CalcBestAction(PLD.FightOrFlight, PLD.FightOrFlight, PLD.Requiescat);
            }
        }

        return actionID;
    }
}

internal class PaladinSpiritsWithinCircleOfScorn : PaladinCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PaladinScornfulSpiritsFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.SpiritsWithin || actionID == PLD.Expiacion || actionID == PLD.CircleOfScorn)
        {
            if (level >= PLD.Levels.Expiacion)
                return CalcBestAction(actionID, PLD.Expiacion, PLD.CircleOfScorn);

            if (level >= PLD.Levels.CircleOfScorn)
                return CalcBestAction(actionID, PLD.SpiritsWithin, PLD.CircleOfScorn);

            return PLD.SpiritsWithin;
        }

        return actionID;
    }
}

internal class PaladinShieldBash : PaladinCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PaladinShieldBashFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.ShieldBash)
        {
            if (level >= PLD.Levels.LowBlow && IsOffCooldown(PLD.LowBlow))
                return PLD.LowBlow;
        }

        return actionID;
    }
}
