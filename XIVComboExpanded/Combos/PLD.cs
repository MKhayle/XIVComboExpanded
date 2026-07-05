namespace XIVComboExpandedPlugin.Combos;

internal static class PLD
{
    public const byte ClassID = 1;
    public const byte JobID = 19;

    public const uint
        // Single Target
        FastBlade = 9,
        RiotBlade = 15,
        RageOfHalone = 21,
        RoyalAuthority = 3539,
        HolySpirit = 7384,
        Atonement = 16460,
        Supplication = 36918,
        Sepulchre = 36919,

        // AoE
        TotalEclipse = 7381,
        Prominence = 16457,
        HolyCircle = 16458,

        // oGCDs
        CircleOfScorn = 23,
        SpiritsWithin = 29,
        Expiacion = 25747,

        // Confiteor combo
        Confiteor = 16459,
        BladeOfFaith = 25748,
        BladeOfTruth = 25749,
        BladeOfValor = 25750,
        BladeOfHonor = 36922,

        // Cooldowns
        FightOrFlight = 20,
        Requiescat = 7383,
        Imperator = 36921,
        GoringBlade = 3538,

        // Utility
        ShieldBash = 16,
        ShieldLob = 24,
        IronWill = 28,
        IronWillRemoval = 32065,
        Clemency = 3541;

    public static class Buffs
    {
        public const ushort
            FightOrFlight = 76,
            IronWill = 79,
            Requiescat = 1368,
            DivineMight = 2673,
            GoringBladeReady = 3847,
            AtonementReady = 1902,
            SupplicationReady = 3827,
            SepulchreReady = 3828,
            ConfiteorReady = 3019,
            BladeOfHonorReady = 3831;
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
            IronWill = 10,
            ShieldBash = 10,
            SpiritsWithin = 30,
            RageOfHalone = 26,
            Prominence = 40,
            CircleOfScorn = 50,
            GoringBlade = 54,
            RoyalAuthority = 60,
            HolySpirit = 64, // Also includes Divine Magic Mastery, halving MP costs
            Requiescat = 68,
            HolyCircle = 72,
            Atonement = 76, // Also includes Supplication and Sepulchre
            Confiteor = 80,
            Expiacion = 86,
            BladeOfFaith = 90,
            Imperator = 96,
            BladeOfHonor = 100;
    }
}

internal abstract class PaladinCombo : CustomCombo
{
    protected bool HasMp(uint spell)
    {
        int cost = 0;
        switch (spell)
        {
            case PLD.Clemency:
                cost = 2000;
                break;
            case PLD.HolySpirit:
            case PLD.HolyCircle:
            case PLD.Confiteor:
            case PLD.BladeOfFaith:
            case PLD.BladeOfTruth:
            case PLD.BladeOfValor:
                cost = 1000;
                break;
        }

        if (LocalPlayer?.Level >= PLD.Levels.HolySpirit)
            cost /= 2;

        return LocalPlayer?.CurrentMp >= cost;
    }
}

internal class PaladinRoyalAuthority : PaladinCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PldAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.RageOfHalone || actionID == PLD.RoyalAuthority)
        {
            var inMeleeRange = InMeleeRange(); // Only calculate this once, to save some CPU cycles

            if (IsEnabled(CustomComboPreset.PaladinRoyalAuthorityGoringBladeFeature) &&
                IsEnabled(CustomComboPreset.PaladinGoringBladeBeforeConfiteorFeature) &&
                OriginalHook(PLD.FightOrFlight) == PLD.GoringBlade && inMeleeRange)
                return PLD.GoringBlade;

            if (level >= PLD.Levels.Confiteor && IsEnabled(CustomComboPreset.PaladinComboConfiteorFeature))
            {
                if (HasEffect(PLD.Buffs.BladeOfHonorReady))
                    return PLD.BladeOfHonor;

                var original = OriginalHook(PLD.Confiteor);
                if (original != PLD.Confiteor)
                    return original;

                if (HasEffect(PLD.Buffs.ConfiteorReady))
                    return PLD.Confiteor;
            }

            if (IsEnabled(CustomComboPreset.PaladinRoyalAuthorityGoringBladeFeature) &&
                OriginalHook(PLD.FightOrFlight) == PLD.GoringBlade && inMeleeRange)
                return PLD.GoringBlade;

            var fof = FindEffect(PLD.Buffs.FightOrFlight);
            if (fof != null)
            {
                // The goal here is to maximize the potency of the next 3 GCDs.  In order, the priority is:
                //  * Sepulchre (540p)
                //  * Holy Spirit, Supplication (500p)
                //  * Atonement, Royal Authority (460p).
                // Notably, if we enter FoF with both Atonement and Holy Spirit available, using the full
                // Atonement combo yields 40 more potency than using Holy Spirit + Atonement + Supplication.
                // Optimal combos, in descending order, depending on when we enter FoF:
                //   * Holy Spirit -> Supplication -> Sepulchre (1540p)
                //   * Sepulchre -> Royal Authority -> Holy Spirit (1500p)
                //   * Atonement -> Supplication -> Sepulchre (1500p)
                //   * Supplication -> Sepulchre -> Royal Authority (1500p)
                //   * Royal Authority -> Holy Spirit -> Atonement (1460p)
                // Note: Technically, this is only true after level 94's Melee Mastery II trait, as prior to
                // that, Holy Spirit with Divine Might (450p) has 10 more potency than Sepulchre (440p),
                // rather than being equal.  However, since optimizing gains or losses of only 10p
                // doesn't really matter at all while leveling, we don't bother to adjust this logic for lower
                // levels, except where Atonement isn't yet learned.
                if (level >= PLD.Levels.Atonement &&
                    IsEnabled(CustomComboPreset.PaladinRoyalAuthorityAtonementComboFeature))
                {
                    // These use a fixed 2.5s, with some buffer, for the GCD, both because Paladin GCD length
                    // actually scales with two separate stats (some with skill speed, others with spell speed),
                    // and because Paladins ideally don't want to use ANY skill or spell speed on their gear.
                    // If the player happens to have some skill/spell speed, the result here will just be a bit
                    // of additional buffer on the timers.
                    if (HasEffect(PLD.Buffs.SepulchreReady) && inMeleeRange)
                        return PLD.Sepulchre;

                    if (HasEffect(PLD.Buffs.SupplicationReady) && inMeleeRange &&
                        (!IsEnabled(CustomComboPreset.PaladinFoFOptimizeFeature) ||
                        fof.RemainingTime > 3 || !HasEffect(PLD.Buffs.DivineMight)))
                        return PLD.Supplication;

                    if (HasEffect(PLD.Buffs.AtonementReady) && inMeleeRange &&
                        (!IsEnabled(CustomComboPreset.PaladinFoFOptimizeFeature) ||
                        fof.RemainingTime > 6 || !HasEffect(PLD.Buffs.DivineMight)))
                        return PLD.Atonement;
                }

                if (IsEnabled(CustomComboPreset.PaladinFightOrFlightDivineMightFeature) &&
                    this.HasMp(PLD.HolySpirit) && HasEffect(PLD.Buffs.DivineMight))
                    return PLD.HolySpirit;
            }

            if (IsEnabled(CustomComboPreset.PaladinFightOrFlightDivineMightFeature) &&
                this.HasMp(PLD.HolySpirit) && HasEffect(PLD.Buffs.Requiescat))
                return PLD.HolySpirit;

            // Outside of FoF, we want to use Atonement immediately following Royal Authority, since it's in the lowest
            // rung of potencies for FoF.  We delay the rest of the Atonement combo AND using Divine Might until they'd
            // be overwritten by a new Royal Authority combo.  The specifically order we use them in prior to Royal
            // Authority, assuming we're continuously in melee range, is Supplication -> Holy Spirit -> Sepulchre.
            // This delays using the highest-potency Sepulchre until as late as possible, giving as many opportunities
            // as possible for it to end up in FoF.  Notably, this gives us an extra 40p if we enter FoF between the
            // 2nd GCD prior to Royal Authority and the GCD immediately prior to it.
            //
            // Supplication is used before Divine Might for two reasons: it provides an extra GCD during the "standard"
            // combo sequence (outside FoF) where we have it available for handling a disconnect, and it means that if
            // we enter FoF between the 2nd and 3rd GCDs prior to Royal Authority, that Divine Might now protects TWO
            // GCDs during FoF from disconnects where we otherwise wouldn't have any disconnect protection at all.
            // Basically, Holy Spirit (w/ Divine Might) and Supplication have identical potencies, but Holy Spirit is
            // the more flexible of the two, both because it is ranged and because it does not strictly need to be used
            // prior to Sepulchre during FoF, so we prefer to have it available during FoF over Supplication.
            if (IsEnabled(CustomComboPreset.PaladinRoyalAuthorityAtonementComboFeature) &&
                level >= PLD.Levels.Atonement && inMeleeRange)
            {
                var supplication = FindEffect(PLD.Buffs.SupplicationReady);
                if (supplication != null && inMeleeRange && (
                    lastComboMove == PLD.RiotBlade || supplication.RemainingTime < 4 ||
                    !IsEnabled(CustomComboPreset.PaladinFoFOptimizeFeature)))
                    return PLD.Supplication;

                if (HasEffect(PLD.Buffs.AtonementReady))
                    return PLD.Atonement;
            }

            if (level >= PLD.Levels.HolySpirit &&
                IsEnabled(CustomComboPreset.PaladinRoyalAuthorityDivineMightFeature) &&
                IsEnabled(CustomComboPreset.PaladinFoFOptimizeFeature))
            {
                var divineMight = FindEffect(PLD.Buffs.DivineMight);
                if (this.HasMp(PLD.HolySpirit) && divineMight != null &&
                    (!inMeleeRange || lastComboMove == PLD.RiotBlade || divineMight.RemainingTime < 4))
                    return PLD.HolySpirit;
            }

            if (IsEnabled(CustomComboPreset.PaladinRoyalAuthorityAtonementComboFeature) &&
                level >= PLD.Levels.Atonement)
            {
                var sepulchre = FindEffect(PLD.Buffs.SepulchreReady);
                if (sepulchre != null && inMeleeRange && (
                    lastComboMove == PLD.RiotBlade || sepulchre.RemainingTime < 4 ||
                    !IsEnabled(CustomComboPreset.PaladinFoFOptimizeFeature)))
                    return PLD.Sepulchre;
            }

            // Divine Might after Atonement combo if not doing optimization, just to handle potential melee disconnects
            // during that time.
            if (level >= PLD.Levels.HolySpirit &&
                IsEnabled(CustomComboPreset.PaladinRoyalAuthorityDivineMightFeature) &&
                !IsEnabled(CustomComboPreset.PaladinFoFOptimizeFeature))
            {
                if (this.HasMp(PLD.HolySpirit) && HasEffect(PLD.Buffs.DivineMight))
                    return PLD.HolySpirit;
            }

            if (IsEnabled(CustomComboPreset.PaladinRoyalAuthorityCombo))
            {
                if (lastComboMove == PLD.RiotBlade && level >= PLD.Levels.RageOfHalone)
                    return OriginalHook(PLD.RageOfHalone);

                if (lastComboMove == PLD.FastBlade && level >= PLD.Levels.RiotBlade)
                    return PLD.RiotBlade;

                return PLD.FastBlade;
            }
        }

        return actionID;
    }
}

internal class PaladinProminence : PaladinCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PldAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.Prominence)
        {
            if (IsEnabled(CustomComboPreset.PaladinProminenceGoringBladeFeature) &&
                IsEnabled(CustomComboPreset.PaladinGoringBladeBeforeConfiteorFeature) &&
                OriginalHook(PLD.FightOrFlight) == PLD.GoringBlade)
                return PLD.GoringBlade;

            if (level >= PLD.Levels.Confiteor && IsEnabled(CustomComboPreset.PaladinComboConfiteorFeature))
            {
                var original = OriginalHook(PLD.Confiteor);
                if (original != PLD.Confiteor)
                    return original;

                if (HasEffect(PLD.Buffs.BladeOfHonorReady))
                    return PLD.BladeOfHonor;

                if (HasEffect(PLD.Buffs.ConfiteorReady))
                    return PLD.Confiteor;
            }

            if (IsEnabled(CustomComboPreset.PaladinProminenceGoringBladeFeature) &&
                OriginalHook(PLD.FightOrFlight) == PLD.GoringBlade)
                return PLD.GoringBlade;

            // During FoF, use Holy Circle if Divine Might OR Requiescat is up.  This only captures remaining charges of
            // Requiescat after the Confiteor combo above, which only happens when the player is under the level for the
            // full 4-part Confiteor combo (level 90), or if they somehow break the combo.
            if (level >= PLD.Levels.HolyCircle && this.HasMp(PLD.HolyCircle))
            {
                var divineMight = FindEffect(PLD.Buffs.DivineMight);
                if (IsEnabled(CustomComboPreset.PaladinFightOrFlightDivineMightFeature) &&
                    HasEffect(PLD.Buffs.FightOrFlight) &&
                    (divineMight != null || HasEffect(PLD.Buffs.Requiescat)))
                    return PLD.HolyCircle;

                if (IsEnabled(CustomComboPreset.PaladinProminenceDivineMightFeature) && divineMight != null &&
                   (lastComboMove == PLD.TotalEclipse || divineMight.RemainingTime < 4 ||
                   !IsEnabled(CustomComboPreset.PaladinFoFOptimizeFeature)))
                   return PLD.HolyCircle;
            }

            if (IsEnabled(CustomComboPreset.PaladinProminenceCombo))
            {
                if (lastComboMove == PLD.TotalEclipse && level >= PLD.Levels.Prominence)
                    return PLD.Prominence;

                return PLD.TotalEclipse;
            }
        }

        return actionID;
    }
}

internal class PaladinHolySpiritHolyCircle : PaladinCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PaladinHolyConfiteorFeature;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.HolySpirit || actionID == PLD.HolyCircle)
        {
            if (level >= PLD.Levels.Confiteor)
            {
                if (HasEffect(PLD.Buffs.BladeOfHonorReady))
                    return PLD.BladeOfHonor;

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

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.HolySpirit && level < PLD.Levels.HolySpirit)
            return PLD.ShieldLob;

        return actionID;
    }
}

internal class PaladinShieldLobHolySpirit : PaladinCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PaladinShieldLobDivineMightFeature;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.ShieldLob
            && level >= PLD.Levels.HolySpirit
            && this.HasMp(PLD.HolySpirit)
            && HasEffect(PLD.Buffs.DivineMight))
                return PLD.HolySpirit;

        return actionID;
    }
}

internal class PaladinRequiescat : PaladinCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PldAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.Requiescat || actionID == PLD.Imperator)
        {
            var requiescat = GetCooldown(PLD.Requiescat);

            if (IsEnabled(CustomComboPreset.PaladinRequiescatFightOrFlightFeature) &&
                IsEnabled(CustomComboPreset.PaladinGoringBladeBeforeConfiteorFeature) &&
                OriginalHook(PLD.FightOrFlight) == PLD.GoringBlade &&
                requiescat.CooldownRemaining > 5 && InMeleeRange())
                return PLD.GoringBlade;

            if (level >= PLD.Levels.Confiteor && IsEnabled(CustomComboPreset.PaladinRequiescatConfiteorFeature))
            {
                if (HasEffect(PLD.Buffs.BladeOfHonorReady))
                    return PLD.BladeOfHonor;

                var original = OriginalHook(PLD.Confiteor);
                if (original != PLD.Confiteor)
                    return original;

                if (HasEffect(PLD.Buffs.ConfiteorReady))
                    return PLD.Confiteor;
            }

            if (IsEnabled(CustomComboPreset.PaladinRequiescatFightOrFlightFeature) &&
                OriginalHook(PLD.FightOrFlight) == PLD.GoringBlade &&
                requiescat.CooldownRemaining > 5 && InMeleeRange())
                return PLD.GoringBlade;

            // This captures any remaining charges of Requiescat after the Confiteor combo above, which only happens
            // when the player is under the level for the full 4-part Confiteor combo (level 90), or if they somehow
            // break the combo.
            if (IsEnabled(CustomComboPreset.PaladinRequiescatConfiteorFeature) &&
                level >= PLD.Levels.Requiescat && HasEffect(PLD.Buffs.Requiescat))
                return PLD.HolySpirit;

            if (IsEnabled(CustomComboPreset.PaladinRequiescatFightOrFlightFeature))
            {
                if (level >= PLD.Levels.FightOrFlight)
                {
                    if (level < PLD.Levels.Requiescat)
                        return PLD.FightOrFlight;

                    // Prefer FoF if it is off cooldown, or if it will be ready sooner than Requiescat.  In practice, this
                    // means that Req should only be returned if FoF is on cooldown and Req is not, ie. immediately after
                    // FoF is cast.  This ensures that the button shows the action that will next be available for use in
                    // that hotbar slot, rather than swapping to FoF at the last instant when FoF comes off cooldown a
                    // a single weave slot earlier than Req.

                    if (level >= PLD.Levels.Imperator)
                        return OriginalHook(CalcBestAction(PLD.FightOrFlight, PLD.FightOrFlight, PLD.Imperator));

                    return OriginalHook(CalcBestAction(PLD.FightOrFlight, PLD.FightOrFlight, PLD.Requiescat));
                }
            }
        }

        return actionID;
    }
}

internal class PaladinSpiritsWithinCircleOfScorn : PaladinCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PaladinScornfulSpiritsFeature;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
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

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.ShieldBash)
        {
            if (level < PLD.Levels.ShieldBash || (IsCooldownUsable(ADV.LowBlow) && CanUseAction(ADV.LowBlow)))
                return ADV.LowBlow;
        }

        return actionID;
    }
}
