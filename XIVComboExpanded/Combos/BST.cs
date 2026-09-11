namespace XIVComboExpandedPlugin.Combos;

internal static class BST
{
    public const byte JobID = 43;

    public const uint
        SmashAxe = 44879,
        Capture = 44880,
        FirstBattlehorn = 44881,
        Gauge = 44882,
        AxebladeBite = 44883,
        AvalancheAxe = 44884,
        Shieldsplitter = 44885,
        BeastMode = 44886,
        MistralAxe = 44887,
        SpinningAxe = 44888,
        GaleAxe = 44889,
        TemperedRelease = 44890,
        PartingBlow = 44891,
        SecondBattlehorn = 44892,
        ShieldCharge = 44893,
        ThirdBattlehorn = 44894,
        Borrow = 44895,
        Rally = 44905,
        RallyingCheer = 44904,
        Trick = 47093;

    public static class Buffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            SmashAxe = 1,
            PartingBlow = 6,
            AxebladeBite = 2,
            Shieldsplitter = 12;
    }
}

internal class BeastShieldsplitter : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BstAny;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BST.Shieldsplitter)
        {
            if (IsEnabled(CustomComboPreset.BeastmasterShieldsplitterCombo))
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == BST.AxebladeBite && level >= BST.Levels.Shieldsplitter)
                    {
                        return BST.Shieldsplitter;
                    }

                    if (lastComboMove == BST.SmashAxe && level >= BST.Levels.AxebladeBite)
                        return BST.AxebladeBite;
                }

                return BST.SmashAxe;
            }
        }

        return actionID;
    }
}

internal class BeastmasterPartingBlow : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BeastmasterPartingBlowFeature;

    protected override ComboAction Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID is BST.FirstBattlehorn or BST.SecondBattlehorn or BST.ThirdBattlehorn)
        {
            // The horn only starts its recast once the familiar retreats, so it stays visible while it ticks down.
            if (level >= BST.Levels.PartingBlow && IsCooldownUsable(actionID) && CanUseAction(BST.PartingBlow))
            {
                // Each horn carries its own color so the shared Parting Blow tells them apart.
                var tint = actionID switch
                {
                    BST.FirstBattlehorn when IsEnabled(CustomComboPreset.BeastmasterPartingBlowFirstHornTint)
                        => GetTint(CustomComboPreset.BeastmasterPartingBlowFirstHornTint),
                    BST.SecondBattlehorn when IsEnabled(CustomComboPreset.BeastmasterPartingBlowSecondHornTint)
                        => GetTint(CustomComboPreset.BeastmasterPartingBlowSecondHornTint),
                    BST.ThirdBattlehorn when IsEnabled(CustomComboPreset.BeastmasterPartingBlowThirdHornTint)
                        => GetTint(CustomComboPreset.BeastmasterPartingBlowThirdHornTint),
                    _ => null,
                };

                return (BST.PartingBlow, tint);
            }
        }

        return actionID;
    }
}
