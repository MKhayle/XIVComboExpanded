using System;

namespace XIVComboExpandedPlugin.Attributes;

/// <summary>
/// Attribute marking combos that can return the same action as another combo (e.g. several
/// combo chains sharing the same starter action). These presets get a color picker in the
/// combos tab so the user can tint their hotbar icon and tell them apart.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
internal class TintableComboAttribute : Attribute
{
}
