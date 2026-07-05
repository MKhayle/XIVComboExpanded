namespace XIVComboExpandedPlugin;

/// <summary>
/// A hotbar icon tint: color plus optional coloring-method override.
/// </summary>
internal readonly struct ComboTint
{
    /// <summary>Gets the tint color (0xAARRGGBB, alpha = intensity).</summary>
    public readonly uint Color;

    /// <summary>Gets the coloring method override, or null to use the global setting.</summary>
    public readonly IconColoringMethod? Method;

    public ComboTint(uint color, IconColoringMethod? method)
    {
        Color = color;
        Method = method;
    }
}

/// <summary>
/// Return type for <see cref="Combos.CustomCombo.Invoke"/>.
/// Implicitly convertible from <c>uint</c> (action ID only) or a <c>(uint, ComboTint?)</c>
/// tuple (action ID + tint) so that combos can write either:
/// <code>return OriginalHook(SAM.Hakaze);</code>
/// or:
/// <code>return (OriginalHook(SAM.Hakaze), this.Tint);</code>
/// </summary>
internal readonly struct ComboAction
{
    /// <summary>Gets the replacement action ID. 0 or equal to the original = no replacement.</summary>
    public readonly uint ActionID;

    /// <summary>Gets the optional hotbar icon tint, or null for no tint.</summary>
    public readonly ComboTint? Tint;

    private ComboAction(uint actionID, ComboTint? tint)
    {
        ActionID = actionID;
        Tint = tint;
    }

    public static implicit operator ComboAction(uint actionID)
        => new(actionID, null);

    public static implicit operator ComboAction((uint actionID, ComboTint? tint) tuple)
        => new(tuple.actionID, tuple.tint);
}
