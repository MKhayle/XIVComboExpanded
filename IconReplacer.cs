using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using Dalamud.Game.ClientState;
using Dalamud.Game.ClientState.Actors.Types;
using Dalamud.Game.Text;
using Dalamud.Hooking;
using Dalamud.Plugin;

using XIVComboVeryExpandedPlugin.Combos;

using Structs = Dalamud.Game.ClientState.Structs;

namespace XIVComboVeryExpandedPlugin {
	// why would you make me do this
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Leftover from original fork")]
	internal class IconReplacer {
		private readonly DalamudPluginInterface Interface;
		private readonly PluginAddressResolver Address;
		private readonly XIVComboVeryExpandedConfiguration Configuration;

		private delegate ulong IsIconReplaceableDelegate(uint actionID);
		private delegate uint GetIconDelegate(IntPtr actionManager, uint actionID);
		private delegate IntPtr GetActionCooldownSlotDelegate(IntPtr actionManager, int cooldownGroup);

		private readonly Hook<IsIconReplaceableDelegate> IsIconReplaceableHook;
		private readonly Hook<GetIconDelegate> GetIconHook;

		private readonly GetActionCooldownSlotDelegate GetActionCooldownSlot;
		private IntPtr ActionManager = IntPtr.Zero;

		private readonly HashSet<uint> CustomIds = new();
		private List<CustomCombo> CustomCombos;

		public IconReplacer(DalamudPluginInterface pluginInterface, XIVComboVeryExpandedConfiguration configuration) {
			this.Interface = pluginInterface;
			this.Configuration = configuration;

			this.Address = new PluginAddressResolver();
			this.Address.Setup(pluginInterface.TargetModuleScanner);

			CustomCombo.Initialize(this, configuration);
			this.UpdateCustomCombos();

			this.UpdateEnabledActionIDs();

			this.GetActionCooldownSlot = Marshal.GetDelegateForFunctionPointer<GetActionCooldownSlotDelegate>(this.Address.GetActionCooldown);

			this.GetIconHook = new Hook<GetIconDelegate>(this.Address.GetIcon, this.GetIconDetour);
			this.IsIconReplaceableHook = new Hook<IsIconReplaceableDelegate>(this.Address.IsIconReplaceable, this.IsIconReplaceableDetour);

			this.GetIconHook.Enable();
			this.IsIconReplaceableHook.Enable();

		}

		internal void Dispose() {
			this.GetIconHook.Dispose();
			this.IsIconReplaceableHook.Dispose();
		}

		private void UpdateCustomCombos() {
			this.CustomCombos = Assembly.GetAssembly(typeof(CustomCombo)).GetTypes()
				.Where(t => t.BaseType == typeof(CustomCombo))
				.Select(t => Activator.CreateInstance(t))
				.Cast<CustomCombo>()
				.ToList();
		}

		/// <summary>
		/// Maps to <see cref="XIVComboVeryExpandedConfiguration.EnabledActions"/>, these actions can potentially update their icon per the user configuration.
		/// </summary>
		public void UpdateEnabledActionIDs() {
			HashSet<uint> actionIDs = Enum
				.GetValues(typeof(CustomComboPreset))
				.Cast<CustomComboPreset>()
				.Select(preset => preset.GetAttribute<CustomComboInfoAttribute>())
				.OfType<CustomComboInfoAttribute>()
				.SelectMany(comboInfo => comboInfo.ActionIDs)
				.Concat(this.Configuration.DancerDanceCompatActionIDs)
				.ToHashSet();
			this.CustomIds.Clear();
			this.CustomIds.UnionWith(actionIDs);
		}

		public uint GetNewAction(uint actionID, uint lastComboMove, float comboTime, byte level) {
			foreach (CustomCombo combo in this.CustomCombos) {
				if (combo.TryInvoke(actionID, lastComboMove, comboTime, level, out uint newActionID))
					return newActionID;
			}
			return this.OriginalHook(actionID);
		}

		private ulong IsIconReplaceableDetour(uint actionID) => 1;

		/// <summary>
		/// Replace an ability with another ability
		/// actionID is the original ability to be "used"
		/// Return either actionID (itself) or a new Action table ID as the
		/// ability to take its place.
		/// I tend to make the "combo chain" button be the last move in the combo
		/// For example, Souleater combo on DRK happens by dragging Souleater
		/// onto your bar and mashing it.
		/// </summary>
		private uint GetIconDetour(IntPtr actionManager, uint actionID) {
			try {
				this.ActionManager = actionManager;

				if (this.LocalPlayer == null || !this.CustomIds.Contains(actionID))
					return this.OriginalHook(actionID);

				return this.GetNewAction(actionID, this.LastComboMove, this.ComboTime, this.LocalPlayer.Level);
			}
			catch (Exception ex) {
				PluginLog.Error(ex, "Don't crash the game");
				return this.GetIconHook.Original(actionManager, actionID);
			}
		}

		#region Getters

		internal bool HasCondition(ConditionFlag flag) => this.Interface.ClientState.Condition[flag];

		internal PlayerCharacter LocalPlayer => this.Interface.ClientState.LocalPlayer;

		internal Actor CurrentTarget => this.Interface.ClientState.Targets.CurrentTarget;

		internal uint LastComboMove => (uint)Marshal.ReadInt32(this.Address.LastComboMove);

		internal float ComboTime => Marshal.PtrToStructure<float>(this.Address.ComboTimer);

		internal T GetJobGauge<T>() => this.Interface.ClientState.JobGauges.Get<T>();

		internal uint OriginalHook(uint actionID) => this.GetIconHook.Original(this.ActionManager, actionID);

		#endregion

		#region Effects

		internal bool HasEffect(short effectId) => this.FindEffect(effectId) != null;

		internal bool TargetHasEffect(short effectId) => this.FindTargetEffect(effectId) != null;

		internal Structs.StatusEffect? FindEffect(short effectId) => FindEffect(effectId, this.LocalPlayer, null);

		internal float EffectDuration(short effectId) {
			Structs.StatusEffect? eff = this.FindEffect(effectId);
			if (eff.HasValue)
				return (byte)eff?.Duration;
			return 0;
		}

		internal float EffectStacks(short effectId) {
			Structs.StatusEffect? eff = this.FindEffect(effectId);
			if (eff.HasValue)
				return (byte)eff?.StackCount;
			return 0;
		}

		internal float TargetEffectDuration(short effectId) {
			Structs.StatusEffect? eff = this.FindTargetEffect(effectId);
			if (eff.HasValue)
				return (byte)eff?.Duration;
			return 0;
		}

		internal float TargetEffectStacks(short effectId) {
			Structs.StatusEffect? eff = this.FindTargetEffect(effectId);
			if (eff.HasValue)
				return (byte)eff?.StackCount;
			return 0;
		}

		internal Structs.StatusEffect? FindTargetEffect(short effectId) => FindEffect(effectId, this.CurrentTarget, this.LocalPlayer?.ActorId);

		internal static Structs.StatusEffect? FindEffect(short effectId, Actor actor, int? ownerId) {
			if (actor == null)
				return null;

			foreach (Structs.StatusEffect status in actor.StatusEffects) {
				if (status.EffectId == effectId) {
					if (!ownerId.HasValue || status.OwnerId == ownerId)
						return status;
				}
			}

			return null;
		}

		#endregion

		#region Cooldowns

		private readonly Dictionary<uint, byte> CooldownGroups = new();

		private byte GetCooldownGroup(uint actionID) {
			if (this.CooldownGroups.TryGetValue(actionID, out byte cooldownGroup))
				return cooldownGroup;

			Lumina.Excel.ExcelSheet<Lumina.Excel.GeneratedSheets.Action> sheet = this.Interface.Data.GetExcelSheet<Lumina.Excel.GeneratedSheets.Action>();
			Lumina.Excel.GeneratedSheets.Action row = sheet.GetRow(actionID);

			return this.CooldownGroups[actionID] = row.CooldownGroup;
		}

		internal CooldownData GetCooldown(uint actionID) {
			byte cooldownGroup = this.GetCooldownGroup(actionID);
			if (this.ActionManager == IntPtr.Zero)
				return new CooldownData() { ActionID = actionID };

			IntPtr cooldownPtr = this.GetActionCooldownSlot(this.ActionManager, cooldownGroup - 1);
			return Marshal.PtrToStructure<CooldownData>(cooldownPtr);
		}

		#endregion
	}

	[StructLayout(LayoutKind.Explicit)]
	internal struct CooldownData {
		[FieldOffset(0x0)] public bool IsCooldown;
		[FieldOffset(0x4)] public uint ActionID;
		[FieldOffset(0x8)] public float CooldownElapsed;
		[FieldOffset(0xC)] public float CooldownTotal;

		public float CooldownRemaining => this.IsCooldown ? this.CooldownTotal - this.CooldownElapsed : 0;
	}
}