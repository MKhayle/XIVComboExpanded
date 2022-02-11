using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboVX.Combos {
	internal static class DNC {
		public const byte JobID = 38;

		public const uint
			// Single Target
			Cascade = 15989,
			Fountain = 15990,
			ReverseCascade = 15991,
			Fountainfall = 15992,
			// AoE
			Windmill = 15993,
			Bladeshower = 15994,
			RisingWindmill = 15995,
			Bloodshower = 15996,
			// Dancing
			StandardStep = 15997,
			TechnicalStep = 15998,
			Tillana = 25790,
			// Fans
			FanDance1 = 16007,
			FanDance2 = 16008,
			FanDance3 = 16009,
			FanDance4 = 25791,
			// Other
			SaberDance = 16005,
			EnAvant = 16010,
			Devilment = 16011,
			Flourish = 16013,
			Improvisation = 16014,
			StarfallDance = 25792;

		public static class Buffs {
			public const ushort
				FlourishingSymmetry = 2693,
				FlourishingFlow = 2694,
				FlourishingFinish = 2698,
				FlourishingStarfall = 2700,
				StandardStep = 1818,
				TechnicalStep = 1819,
				ThreefoldFanDance = 1820,
				FourfoldFanDance = 2699;
		}

		public static class Debuffs {
			// public const ushort placeholder = 0;
		}

		public static class Levels {
			public const byte
				Fountain = 2,
				Windmill = 15,
				StandardStep = 15,
				ReverseCascade = 20,
				Bladeshower = 25,
				RisingWindmill = 35,
				Fountainfall = 40,
				Bloodshower = 45,
				FanDance3 = 66,
				TechnicalStep = 70,
				Tillana = 82,
				FanDance4 = 86,
				StarfallDance = 90;

		}
	}

	internal class DancerDanceComboCompatibility: CustomCombo {
		public override CustomComboPreset Preset => CustomComboPreset.DancerDanceComboCompatibility;
		public override uint[] ActionIDs => Service.Configuration.DancerDanceCompatActionIDs;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (level >= DNC.Levels.StandardStep && GetJobGauge<DNCGauge>().IsDancing) {
				uint[] actionIDs = this.ActionIDs;

				if (actionID == actionIDs[0] || (actionIDs[0] == 0 && actionID is DNC.Cascade))
					return OriginalHook(DNC.Cascade);

				if (actionID == actionIDs[1] || (actionIDs[1] == 0 && actionID is DNC.Flourish))
					return OriginalHook(DNC.Fountain);

				if (actionID == actionIDs[2] || (actionIDs[2] == 0 && actionID is DNC.FanDance1))
					return OriginalHook(DNC.ReverseCascade);

				if (actionID == actionIDs[3] || (actionIDs[3] == 0 && actionID is DNC.FanDance2))
					return OriginalHook(DNC.Fountainfall);

			}

			return actionID;
		}
	}

	internal class DancerFanDanceCombos: CustomCombo {
		public override CustomComboPreset Preset => CustomComboPreset.DncAny;
		public override uint[] ActionIDs { get; } = new[] { DNC.FanDance1, DNC.FanDance2 };

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			bool can4 = level >= DNC.Levels.FanDance4 && SelfHasEffect(DNC.Buffs.FourfoldFanDance);
			bool can3 = level >= DNC.Levels.FanDance3 && SelfHasEffect(DNC.Buffs.ThreefoldFanDance);

			if (actionID is DNC.FanDance1) {
				if (IsEnabled(CustomComboPreset.DancerFanDance14Combo) && can4)
					return DNC.FanDance4;
				if (IsEnabled(CustomComboPreset.DancerFanDance13Combo) && can3)
					return DNC.FanDance3;
			}
			else if (actionID is DNC.FanDance2) {
				if (IsEnabled(CustomComboPreset.DancerFanDance24Combo) && can4)
					return DNC.FanDance4;
				if (IsEnabled(CustomComboPreset.DancerFanDance23Combo) && can3)
					return DNC.FanDance3;
			}

			return actionID;
		}
	}

	internal class DancerDanceStepCombo: CustomCombo {
		public override CustomComboPreset Preset => CustomComboPreset.DancerDanceStepCombo;
		public override uint[] ActionIDs { get; } = new[] { DNC.StandardStep, DNC.TechnicalStep };

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

			if (level >= DNC.Levels.StandardStep) {
				DNCGauge gauge = GetJobGauge<DNCGauge>();

				if (gauge.IsDancing) {
					bool fast = SelfHasEffect(DNC.Buffs.StandardStep);
					int max = fast ? 2 : 4;
					byte done = gauge.CompletedSteps;

					if (gauge.CompletedSteps >= max) {
						Service.Logger.debug($"No further dance steps (finished {done})");
						return OriginalHook(fast ? DNC.StandardStep : DNC.TechnicalStep);
					}

					Service.Logger.debug($"Next dance step ({done + 1}) is #{gauge.NextStep}");
					return gauge.NextStep;
				}
			}

			return actionID;
		}
	}

	internal class DancerFlourishFeature: CustomCombo {
		public override CustomComboPreset Preset => CustomComboPreset.DancerFlourishFeature;
		public override uint[] ActionIDs { get; } = new[] { DNC.Flourish };

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

			if (level >= DNC.Levels.FanDance4 && SelfHasEffect(DNC.Buffs.FourfoldFanDance))
				return DNC.FanDance4;

			if (IsEnabled(CustomComboPreset.DancerFlourishLimitedFeature)
				|| (IsEnabled(CustomComboPreset.DancerFlourishCooldownFeature) && IsOnCooldown(actionID))
			) {
				return actionID;
			}

			if (level >= DNC.Levels.Fountainfall && SelfHasEffect(DNC.Buffs.FlourishingFlow))
				return DNC.Fountainfall;

			if (level >= DNC.Levels.ReverseCascade && SelfHasEffect(DNC.Buffs.FlourishingSymmetry))
				return DNC.ReverseCascade;

			if (level >= DNC.Levels.FanDance3 && SelfHasEffect(DNC.Buffs.ThreefoldFanDance))
				return DNC.FanDance3;

			return actionID;
		}
	}

	internal class DancerSingleTargetMultibutton: CustomCombo {
		public override CustomComboPreset Preset => CustomComboPreset.DancerSingleTargetMultibutton;
		public override uint[] ActionIDs { get; } = new[] { DNC.Cascade };

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

			if (level >= DNC.Levels.Fountainfall && SelfHasEffect(DNC.Buffs.FlourishingFlow))
				return DNC.Fountainfall;

			if (level >= DNC.Levels.ReverseCascade && SelfHasEffect(DNC.Buffs.FlourishingSymmetry))
				return DNC.ReverseCascade;

			if (lastComboMove is DNC.Cascade && level >= DNC.Levels.Fountain)
				return DNC.Fountain;

			return actionID;
		}
	}

	internal class DancerAoeMultibutton: CustomCombo {
		public override CustomComboPreset Preset => CustomComboPreset.DancerAoeMultibutton;
		public override uint[] ActionIDs { get; } = new[] { DNC.Windmill };

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

			if (level >= DNC.Levels.Bloodshower && SelfHasEffect(DNC.Buffs.FlourishingFlow))
				return DNC.Bloodshower;

			if (level >= DNC.Levels.RisingWindmill && SelfHasEffect(DNC.Buffs.FlourishingSymmetry))
				return DNC.RisingWindmill;

			if (lastComboMove is DNC.Windmill && level >= DNC.Levels.Bladeshower)
				return DNC.Bladeshower;

			return actionID;
		}
	}

	internal class DancerDevilmentFeature: CustomCombo {
		public override CustomComboPreset Preset { get; } = CustomComboPreset.DancerDevilmentFeature;
		public override uint[] ActionIDs { get; } = new[] { DNC.Devilment };

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

			if (level >= DNC.Levels.StarfallDance && SelfHasEffect(DNC.Buffs.FlourishingStarfall))
				return DNC.StarfallDance;

			return actionID;
		}
	}
}