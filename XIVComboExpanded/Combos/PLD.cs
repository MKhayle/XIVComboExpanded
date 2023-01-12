namespace XIVComboExpandedPlugin.Combos;

internal static class PLD
{
    public const byte ClassID = 1;
    public const byte JobID = 19;

    public const uint
        FastBlade = 9,
        RiotBlade = 15,
        ShieldBash = 16,
        RageOfHalone = 21,
        CircleOfScorn = 23,
        SpiritsWithin = 29,
        GoringBlade = 3538,
        RoyalAuthority = 3539,
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
            Requiescat = 1368,
            SwordOath = 1902;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            RiotBlade = 4,
            LowBlow = 12,
            SpiritsWithin = 30,
            CircleOfScorn = 50,
            RageOfHalone = 26,
            Prominence = 40,
            GoringBlade = 54,
            RoyalAuthority = 60,
            HolyCircle = 72,
            Atonement = 76,
            Confiteor = 80,
            Expiacion = 86,
            BladeOfFaith = 90,
            BladeOfTruth = 90,
            BladeOfValor = 90;
    }
}

internal class PaladinRoyalAuthority : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PldAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.RageOfHalone || actionID == PLD.RoyalAuthority)
        {
            if (IsEnabled(CustomComboPreset.PaladinRoyalAuthorityAtonementFeature))
            {
                if (level >= PLD.Levels.Atonement && HasEffect(PLD.Buffs.SwordOath) && lastComboMove != PLD.FastBlade && lastComboMove != PLD.RiotBlade)
                    return PLD.Atonement;
            }

            if (IsEnabled(CustomComboPreset.PaladinRoyalAuthorityCombo))
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == PLD.RiotBlade && level >= PLD.Levels.RageOfHalone)
                        // Royal Authority
                        return OriginalHook(PLD.RageOfHalone);

                    if (lastComboMove == PLD.FastBlade && level >= PLD.Levels.RiotBlade)
                        return PLD.RiotBlade;
                }

                return PLD.FastBlade;
            }
        }

        return actionID;
    }
}

internal class PaladinProminence : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PaladinProminenceCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.Prominence)
        {
            if (comboTime > 0)
            {
                if (lastComboMove == PLD.TotalEclipse && level >= PLD.Levels.Prominence)
                    return PLD.Prominence;
            }

            return PLD.TotalEclipse;
        }

        return actionID;
    }
}

internal class PaladinHolySpiritHolyCircle : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PaladinConfiteorFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.HolySpirit || actionID == PLD.HolyCircle)
        {
            if (level >= PLD.Levels.Confiteor && HasEffect(PLD.Buffs.Requiescat))
                return OriginalHook(PLD.Confiteor);
        }

        return actionID;
    }
}

internal class PaladinRequiescat : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PaladinRequiescatCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.Requiescat)
        {
            if (level >= PLD.Levels.Confiteor && HasEffect(PLD.Buffs.Requiescat))
                return OriginalHook(PLD.Confiteor);
        }

        return actionID;
    }
}

internal class PaladinSpiritsWithinCircleOfScorn : CustomCombo
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

internal class PaladinShieldBash : CustomCombo
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
