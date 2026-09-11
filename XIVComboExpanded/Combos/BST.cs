using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboExpandedPlugin.Combos;

internal static class BST
{
    public const byte JobID = 43;

    public const uint
        SmashAxe = 44879,
        AxebladeBite = 44883,
        Shieldsplitter = 44885;

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
                    if (lastComboMove == BST.AxebladeBite)
                    {
                        return BST.Shieldsplitter;
                    }

                    if (lastComboMove == BST.SmashAxe)
                        return BST.AxebladeBite;
                }

                return BST.SmashAxe;
            }
        }

        return actionID;
    }
}