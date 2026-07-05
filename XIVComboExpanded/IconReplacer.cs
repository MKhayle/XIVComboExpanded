using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Dalamud.Game.Addon.Lifecycle;
using Dalamud.Game.Addon.Lifecycle.AddonArgTypes;
using Dalamud.Hooking;
using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.GUI;
using XIVComboExpandedPlugin.Combos;

namespace XIVComboExpandedPlugin;

/// <summary>
/// How a picked combo tint is applied to hotbar icons.
/// The renderer computes, per channel: out = in * multiply/100 + add.
/// </summary>
public enum IconColoringMethod
{
    /// <summary>
    /// Full recolor: off-hue midtones are cut while highlights survive as a white-ish core,
    /// dominant channels are amplified, and an ambient glow lights up the background.
    /// Strongest effect — makes the icon look like an official recolored variant.
    /// </summary>
    Vibrant = 0,

    /// <summary>
    /// Multiply only: the icon is shaded with the color, darkening everything that
    /// doesn't match it. Subtle — keeps the artwork's detail, no glow.
    /// </summary>
    Shade = 1,

    /// <summary>
    /// Additive only: the artwork keeps its own shading, but its lighting is pushed
    /// toward the color. Middle ground between Vibrant and Shade.
    /// </summary>
    Glow = 2,
}

/// <summary>
/// This class facilitates the icon replacing.
/// </summary>
internal sealed partial class IconReplacer : IDisposable
{
    private readonly unsafe ActionManager* clientStructActionManager;
    private readonly List<CustomCombo> customCombos;
    private readonly Hook<IsIconReplaceableDelegate> isIconReplaceableHook;
    private readonly Hook<GetIconDelegate> getIconHook;
    private readonly Dictionary<uint, ComboTint> activeIconColors = new();

    // Tracks currently tinted (barIndex, slotIndex) pairs. The game dims unusable actions by
    // writing the icon image node's multiply channels itself, so for each slot we remember the
    // game's own multiply values and what was last written
    private readonly Dictionary<(int bar, int slot), SlotTintState> tintedSlots = new();

    private IntPtr actionManager = IntPtr.Zero;

    /// <summary>
    /// Initializes a new instance of the <see cref="IconReplacer"/> class.
    /// </summary>
    public unsafe IconReplacer(IGameInteropProvider gameInteropProvider)
    {
        this.clientStructActionManager = ActionManager.Instance();

        this.customCombos = Assembly.GetAssembly(typeof(CustomCombo))!.GetTypes()
            .Where(t => !t.IsAbstract && IsDescendant(t, typeof(CustomCombo)))
            .Select(t => Activator.CreateInstance(t))
            .Cast<CustomCombo>()
            .ToList();

        this.getIconHook = gameInteropProvider.HookFromAddress<GetIconDelegate>(FFXIVClientStructs.FFXIV.Client.Game.ActionManager.Addresses.GetAdjustedActionId.Value, this.GetIconDetour);
        this.isIconReplaceableHook = gameInteropProvider.HookFromAddress<IsIconReplaceableDelegate>(Service.Address.IsActionIdReplaceable, this.IsIconReplaceableDetour);

        this.getIconHook.Enable();
        this.isIconReplaceableHook.Enable();

        // PreDraw so the game doesn't fuck up what we've done.
        var actionBarNames = Enumerable.Range(0, 10)
            .Select(i => i == 0 ? "_ActionBar" : $"_ActionBar{i:D2}");
        Service.AddonLifecycle.RegisterListener(AddonEvent.PreDraw, actionBarNames, this.OnActionBarPreDraw);
    }

    private struct SlotTintState
    {
        public byte GameR, GameG, GameB;    // the game's own multiply values (dimming state)
        public byte WroteR, WroteG, WroteB; // the multiply values we last wrote
    }

    /// <summary>
    /// Gets bool determining if action is greyed out or not.
    /// </summary>
    /// <param name="actionID">Action ID.</param>
    /// <param name="targetID">Target ID.</param>
    /// <returns>A bool value of whether the action can be used or not.</returns>
    internal unsafe bool CanUseAction(uint actionID, uint targetID = 0xE000_0000)
    {
        return clientStructActionManager->GetActionStatus(ActionType.Action, actionID, targetID, false, true) == 0;
    }

    private static bool IsDescendant(Type clazz, Type ancestor)
    {
        if (clazz.BaseType == null) return false;
        if (clazz.BaseType == ancestor) return true;
        return IsDescendant(clazz.BaseType, ancestor);
    }

    private delegate ulong IsIconReplaceableDelegate(uint actionID);

    private delegate uint GetIconDelegate(IntPtr actionManager, uint actionID);

    /// <inheritdoc/>
    public void Dispose()
    {
        Service.AddonLifecycle.UnregisterListener(AddonEvent.PreDraw, this.OnActionBarPreDraw);
        this.RestoreAllColors();
        this.getIconHook?.Dispose();
        this.isIconReplaceableHook?.Dispose();
    }

    /// <summary>
    /// Calls the original hook.
    /// </summary>
    /// <param name="actionID">Action ID.</param>
    /// <returns>The result from the hook.</returns>
    internal uint OriginalHook(uint actionID)
        => this.getIconHook.Original(this.actionManager, actionID);

    private unsafe uint GetIconDetour(IntPtr actionManager, uint actionID)
    {
        this.actionManager = actionManager;

        try
        {
            if (Service.ObjectTable.LocalPlayer == null)
                return this.OriginalHook(actionID);

            var lastComboMove = *(uint*)Service.Address.LastComboMove;
            var comboTime = *(float*)Service.Address.ComboTimer;
            var level = Service.ObjectTable.LocalPlayer?.Level ?? 0;

            foreach (var combo in this.customCombos)
            {
                if (combo.TryInvoke(actionID, level, lastComboMove, comboTime, out var newActionID, out var tint))
                {
                    // Colors are 0xAARRGGBB; a zero alpha means no tint.
                    if (tint.HasValue && (tint.Value.Color >> 24) != 0)
                        this.activeIconColors[actionID] = tint.Value;
                    else
                        this.activeIconColors.Remove(actionID);
                    return newActionID;
                }
            }

            // No combo active for this action — clear any stale color.
            this.activeIconColors.Remove(actionID);
            return this.OriginalHook(actionID);
        }
        catch (Exception ex)
        {
            Service.PluginLog.Error(ex, "Don't crash the game");
            return this.OriginalHook(actionID);
        }
    }

    private ulong IsIconReplaceableDetour(uint actionID) => 1;

    // -------------------------------------------------------------------------
    // Hotbar icon coloring
    // -------------------------------------------------------------------------

    private unsafe void OnActionBarPreDraw(AddonEvent eventType, AddonArgs args)
    {
        if (Service.ObjectTable.LocalPlayer == null) return;

        // When recoloring is disabled, restore any previously tinted slots and stop.
        if (!Service.Configuration.EnableIconRecoloring)
        {
            if (this.tintedSlots.Count > 0)
                this.RestoreAllColors();
            return;
        }

        if (this.activeIconColors.Count == 0 && this.tintedSlots.Count == 0) return;

        try
        {
            var addon = (AddonActionBar*)args.Addon.Address;
            var name = args.AddonName;
            var barIdx = name == "_ActionBar" ? 0 : int.Parse(name["_ActionBar".Length..]);
            this.ApplyColorsToAddon(addon, barIdx);
        }
        catch (Exception ex)
        {
            Service.PluginLog.Error(ex, "Icon color update failed");
        }
    }

    private unsafe void ApplyColorsToAddon(AddonActionBar* addon, int barIdx)
    {
        var hotbarModule = RaptureHotbarModule.Instance();
        if (hotbarModule == null) return;

        var hotbarId = addon->RaptureHotbarId;
        var slotCount = addon->SlotCount;
        if (slotCount == 0) return;

        for (var si = 0; si < slotCount; si++)
        {
            // Tint only the icon's texture itself — tinting the slot component node would also
            // recolor its other children (frame, hover/press glow, combo border)
            var imageNode = GetIconImageNode(addon, si);
            if (imageNode == null) continue;

            var slotKey = (barIdx, si);
            var hotbarSlot = hotbarModule->GetSlotById(hotbarId, (uint)si);

            if (hotbarSlot != null
                && hotbarSlot->CommandType == RaptureHotbarModule.HotbarSlotType.Action
                && this.activeIconColors.TryGetValue(hotbarSlot->CommandId, out var tint))
            {
                // dims unusable/out-of-range actions by writing this node's multiply channels itself
                var curR = imageNode->MultiplyRed;
                var curG = imageNode->MultiplyGreen;
                var curB = imageNode->MultiplyBlue;
                if (!this.tintedSlots.TryGetValue(slotKey, out var st)
                    || curR != st.WroteR || curG != st.WroteG || curB != st.WroteB)
                {
                    st.GameR = curR;
                    st.GameG = curG;
                    st.GameB = curB;
                }

                // The color's own alpha component is the tint intensity.
                var alpha = ((tint.Color >> 24) & 0xFF) / 255f;

                // The additive glow is applied after all multiplies, so it must be faded
                // manually by the game's dimming or it overpowers a dimmed icon.
                var dim = (st.GameR + st.GameG + st.GameB) / 300f;

                var method = tint.Method ?? Service.Configuration.ColoringMethod;
                var (r, g, b) = ColorToMultiply(tint.Color, alpha, method);
                var (ar, ag, ab) = ColorToAdd(tint.Color, alpha * Math.Min(dim, 1f), method);
                r = (byte)Math.Min(st.GameR * r / 100, 255);
                g = (byte)Math.Min(st.GameG * g / 100, 255);
                b = (byte)Math.Min(st.GameB * b / 100, 255);

                imageNode->MultiplyRed = r;
                imageNode->MultiplyGreen = g;
                imageNode->MultiplyBlue = b;
                imageNode->AddRed = ar;
                imageNode->AddGreen = ag;
                imageNode->AddBlue = ab;

                st.WroteR = r;
                st.WroteG = g;
                st.WroteB = b;
                this.tintedSlots[slotKey] = st;
            }
            else if (this.tintedSlots.TryGetValue(slotKey, out var st))
            {
                imageNode->MultiplyRed = st.GameR;
                imageNode->MultiplyGreen = st.GameG;
                imageNode->MultiplyBlue = st.GameB;
                imageNode->AddRed = 0;
                imageNode->AddGreen = 0;
                imageNode->AddBlue = 0;
                this.tintedSlots.Remove(slotKey);
            }
        }
    }

    private static unsafe AtkImageNode* GetIconImageNode(AddonActionBar* addon, int si)
    {
        var dragDrop = addon->ActionBarSlotVector[si].ComponentDragDrop;
        if (dragDrop == null) return null;

        var iconComponent = dragDrop->AtkComponentIcon;
        if (iconComponent == null) return null;

        return iconComponent->IconImage;
    }

    private unsafe void RestoreAllColors()
    {
        foreach (var ((barIdx, si), st) in this.tintedSlots)
        {
            var addonName = barIdx == 0 ? "_ActionBar" : $"_ActionBar{barIdx:D2}";
            var addonWrapper = Service.GameGui.GetAddonByName(addonName);
            if (addonWrapper.IsNull) continue;

            var addon = (AddonActionBar*)addonWrapper.Address;
            if (si >= addon->SlotCount) continue;

            var imageNode = GetIconImageNode(addon, si);
            if (imageNode == null) continue;

            // Restore the game's own multiply values, not neutral — the slot may be dimmed.
            imageNode->MultiplyRed = st.GameR;
            imageNode->MultiplyGreen = st.GameG;
            imageNode->MultiplyBlue = st.GameB;
            imageNode->AddRed = 0;
            imageNode->AddGreen = 0;
            imageNode->AddBlue = 0;
        }

        this.tintedSlots.Clear();
        this.activeIconColors.Clear();
    }

    // Affine colorize model — per channel the game renders: out = in * multiply/100 + add.
    // The Vibrant method is calibrated so a strongly-hued icon is re-hued into its counterpart
    // Shade uses only the multiply half ; Glow uses only the add half
    private const float MultiplyBase = 70f;   // multiply for a channel at zero tint intensity
    private const float MultiplyRange = 130f; // extra multiply at full tint intensity (max 200 = 2x)
    private const float AddRange = 90f;       // add offset magnitude at full (+) / zero (-) intensity

    /// <summary>
    /// Converts a 0xRRGGBB color to AtkResNode multiply channel values (0–255, where 100 = neutral)
    /// for the given coloring method, blended toward neutral by <paramref name="alpha"/>
    /// (0 = no tint, 1 = full tint).
    /// </summary>
    private static (byte r, byte g, byte b) ColorToMultiply(uint color, float alpha, IconColoringMethod method)
    {
        var cr = ((color >> 16) & 0xFF) / 255f;
        var cg = ((color >> 8) & 0xFF) / 255f;
        var cb = (color & 0xFF) / 255f;

        float mr, mg, mb;
        switch (method)
        {
            case IconColoringMethod.Shade:
                // Straight multiply: full-intensity channels stay neutral, others darken.
                mr = cr * 100f;
                mg = cg * 100f;
                mb = cb * 100f;
                break;
            case IconColoringMethod.Glow:
                // Additive only — leave the multiply channels untouched.
                return (100, 100, 100);
            default:
                mr = MultiplyBase + (cr * MultiplyRange);
                mg = MultiplyBase + (cg * MultiplyRange);
                mb = MultiplyBase + (cb * MultiplyRange);
                break;
        }

        return (
            (byte)(100 + (int)((mr - 100) * alpha)),
            (byte)(100 + (int)((mg - 100) * alpha)),
            (byte)(100 + (int)((mb - 100) * alpha)));
    }

    /// <summary>
    /// Converts a 0xRRGGBB color to AtkResNode additive channel values (signed, 0 = neutral)
    /// for the given coloring method, scaled by <paramref name="alpha"/>.
    /// </summary>
    private static (short r, short g, short b) ColorToAdd(uint color, float alpha, IconColoringMethod method)
    {
        if (method == IconColoringMethod.Shade)
            return (0, 0, 0);

        var ar = ((((color >> 16) & 0xFF) / 255f * 2f) - 1f) * AddRange;
        var ag = ((((color >> 8) & 0xFF) / 255f * 2f) - 1f) * AddRange;
        var ab = (((color & 0xFF) / 255f * 2f) - 1f) * AddRange;
        return (
            (short)(ar * alpha),
            (short)(ag * alpha),
            (short)(ab * alpha));
    }
}
