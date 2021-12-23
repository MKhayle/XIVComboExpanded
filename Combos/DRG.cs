using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboVX.Combos {
	internal static class DRG {
		public const byte JobID = 22;

		public const uint
			// Single Target
			TrueThrust = 75,
			VorpalThrust = 78,
			Disembowel = 87,
			FullThrust = 84,
			ChaosThrust = 88,
			HeavensThrust = 25771,
			ChaoticSpring = 25772,
			WheelingThrust = 3556,
			FangAndClaw = 3554,
			RaidenThrust = 16479,
			// AoE
			DoomSpike = 86,
			SonicThrust = 7397,
			CoerthanTorment = 16477,
			DraconianFury = 25770,
			// Combined
			// Jumps
			Jump = 92,
			SpineshatterDive = 95,
			DragonfireDive = 96,
			HighJump = 16478,
			MirageDive = 7399,
			// Dragon
			Stardiver = 16480,
			WyrmwindThrust = 25773;

		public static class Buffs {
			public const ushort
				SharperFangAndClaw = 802,
				EnhancedWheelingThrust = 803,
				DiveReady = 1243;
		}

		public static class Debuffs {
			// public const ushort placeholder = 0;
		}

		public static class Levels {
			public const byte
				VorpalThrust = 4,
				Disembowel = 18,
				FullThrust = 26,
				SpineshatterDive = 45,
				DragonfireDive = 50,
				ChaosThrust = 50,
				HeavensThrust = 86,
				ChaoticSpring = 86,
				FangAndClaw = 56,
				WheelingThrust = 58,
				SonicThrust = 62,
				MirageDive = 68,
				CoerthanTorment = 72,
				HighJump = 74,
				RaidenThrust = 76,
				Stardiver = 80;
		}
	}

	internal class DragoonJumpFeature: CustomCombo {
		protected internal override CustomComboPreset Preset => CustomComboPreset.DragoonJumpFeature;
		protected internal override uint[] ActionIDs { get; } = new[] { DRG.Jump, DRG.HighJump };

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

			if (actionID is DRG.Jump or DRG.HighJump && level >= DRG.Levels.MirageDive && SelfHasEffect(DRG.Buffs.DiveReady))
				return DRG.MirageDive;

			return actionID;
		}
	}

	internal class DragoonCoerthanTormentCombo: CustomCombo {
		protected internal override CustomComboPreset Preset => CustomComboPreset.DragoonCoerthanTormentCombo;
		protected internal override uint[] ActionIDs { get; } = new[] { DRG.CoerthanTorment };

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID is DRG.CoerthanTorment) {

				if (comboTime > 0) {

					if (level >= DRG.Levels.SonicThrust && lastComboMove == DRG.DoomSpike)
						return DRG.SonicThrust;

					if (level >= DRG.Levels.CoerthanTorment && lastComboMove == DRG.SonicThrust)
						return DRG.CoerthanTorment;

				}

				return OriginalHook(DRG.DoomSpike);
			}

			return actionID;
		}
	}

	internal class DragoonChaosThrustCombo: CustomCombo {
		protected internal override CustomComboPreset Preset => CustomComboPreset.DrgAny;
		protected internal override uint[] ActionIDs { get; } = new[] { DRG.ChaosThrust, DRG.ChaoticSpring };

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID is DRG.ChaosThrust or DRG.ChaoticSpring) {

				if (IsEnabled(CustomComboPreset.DragoonFangThrustFeature)
					&& level >= DRG.Levels.FangAndClaw
					&& (SelfHasEffect(DRG.Buffs.SharperFangAndClaw) || SelfHasEffect(DRG.Buffs.EnhancedWheelingThrust))
				)
					return DRG.WheelingThrust;

				if (IsEnabled(CustomComboPreset.DragoonChaosThrustCombo)) {

					if (level >= DRG.Levels.FangAndClaw && SelfHasEffect(DRG.Buffs.SharperFangAndClaw))
						return DRG.FangAndClaw;

					if (level >= DRG.Levels.WheelingThrust && SelfHasEffect(DRG.Buffs.EnhancedWheelingThrust))
						return DRG.WheelingThrust;

					if (comboTime > 0) {

						if (lastComboMove is DRG.Disembowel && level >= DRG.Levels.ChaosThrust)
							return OriginalHook(DRG.ChaosThrust);

						if (lastComboMove is DRG.TrueThrust or DRG.RaidenThrust && level >= DRG.Levels.Disembowel)
							return DRG.Disembowel;

					}

					return OriginalHook(DRG.TrueThrust);
				}
			}

			return actionID;
		}
	}

	internal class DragoonFullThrustCombo: CustomCombo {
		protected internal override CustomComboPreset Preset => CustomComboPreset.DrgAny;
		protected internal override uint[] ActionIDs { get; } = new[] { DRG.FullThrust, DRG.HeavensThrust };

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID is DRG.FullThrust or DRG.HeavensThrust) {

				if (IsEnabled(CustomComboPreset.DragoonFangThrustFeature)
					&& level >= DRG.Levels.FangAndClaw
					&& (SelfHasEffect(DRG.Buffs.SharperFangAndClaw) || SelfHasEffect(DRG.Buffs.EnhancedWheelingThrust))
				)
					return DRG.FangAndClaw;

				if (IsEnabled(CustomComboPreset.DragoonFullThrustCombo)) {

					if (level >= DRG.Levels.WheelingThrust && SelfHasEffect(DRG.Buffs.EnhancedWheelingThrust))
						return DRG.WheelingThrust;

					if (level >= DRG.Levels.FangAndClaw && SelfHasEffect(DRG.Buffs.SharperFangAndClaw))
						return DRG.FangAndClaw;

					if (comboTime > 0) {

						if (level >= DRG.Levels.VorpalThrust && lastComboMove is DRG.TrueThrust or DRG.RaidenThrust)
							return DRG.VorpalThrust;

						if (level >= DRG.Levels.FullThrust && lastComboMove == DRG.VorpalThrust)
							return OriginalHook(DRG.FullThrust);

					}

					return OriginalHook(DRG.TrueThrust);
				}
			}

			return actionID;
		}
	}

	internal class DragoonDiveFeature: CustomCombo {
		protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DragoonDiveFeature;
		protected internal override uint[] ActionIDs { get; } = new[] { DRG.SpineshatterDive, DRG.DragonfireDive, DRG.Stardiver };

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID is DRG.SpineshatterDive or DRG.DragonfireDive or DRG.Stardiver) {

				if (level >= DRG.Levels.Stardiver) {

					if (GetJobGauge<DRGGauge>().IsLOTDActive)
						return PickByCooldown(actionID, DRG.SpineshatterDive, DRG.DragonfireDive, DRG.Stardiver);

					return PickByCooldown(actionID, DRG.SpineshatterDive, DRG.DragonfireDive);
				}

				if (level >= DRG.Levels.DragonfireDive)
					return PickByCooldown(actionID, DRG.SpineshatterDive, DRG.DragonfireDive);

				return DRG.SpineshatterDive;
			}

			return actionID;
		}
	}
}