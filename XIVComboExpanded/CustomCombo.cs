using System;
using System.Linq;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Objects.Enums;
using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Game.ClientState.Statuses;
using Dalamud.Utility;
using XIVComboExpandedPlugin.Attributes;

namespace XIVComboExpandedPlugin.Combos;

/// <summary>
/// Base class for each combo.
/// </summary>
internal abstract partial class CustomCombo
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomCombo"/> class.
    /// </summary>
    protected CustomCombo()
    {
        var presetInfo = this.Preset.GetAttribute<CustomComboInfoAttribute>();
        this.JobID = presetInfo.JobID;
        this.ClassID = this.JobID switch
        {
            ADV.JobID => ADV.ClassID,
            BLM.JobID => BLM.ClassID,
            BRD.JobID => BRD.ClassID,
            DRG.JobID => DRG.ClassID,
            MNK.JobID => MNK.ClassID,
            NIN.JobID => NIN.ClassID,
            PLD.JobID => PLD.ClassID,
            SCH.JobID => SCH.ClassID,
            SMN.JobID => SMN.ClassID,
            WAR.JobID => WAR.ClassID,
            WHM.JobID => WHM.ClassID,
            _ => 0xFF,
        };
    }

    /// <summary>
    /// Gets the preset associated with this combo.
    /// </summary>
    protected internal abstract CustomComboPreset Preset { get; }

    /// <summary>
    /// Gets the class ID associated with this combo.
    /// </summary>
    protected byte ClassID { get; }

    /// <summary>
    /// Gets the job ID associated with this combo.
    /// </summary>
    protected byte JobID { get; }

    /// <summary>
    /// Performs various checks then attempts to invoke the combo.
    /// </summary>
    /// <param name="actionID">Starting action ID.</param>
    /// <param name="level">Player level.</param>
    /// <param name="lastComboMove">Last combo action ID.</param>
    /// <param name="comboTime">Combo timer.</param>
    /// <param name="newActionID">Replacement action ID.</param>
    /// <returns>True if the action has changed, otherwise false.</returns>
    public bool TryInvoke(uint actionID, byte level, uint lastComboMove, float comboTime, out uint newActionID)
    {
        newActionID = 0;

        if (!IsEnabled(this.Preset) || !Service.Configuration.EnablePlugin)
            return false;

        var classJobID = LocalPlayer!.ClassJob.RowId;

        if (classJobID >= 8 && classJobID <= 15)
            classJobID = DOH.JobID;

        if (classJobID >= 16 && classJobID <= 18)
            classJobID = DOL.JobID;

        if (this.JobID != ADV.JobID && this.ClassID != ADV.ClassID &&
            this.JobID != classJobID && this.ClassID != classJobID)
            return false;

        var resultingActionID = this.Invoke(actionID, lastComboMove, comboTime, level);

        if (resultingActionID == 0 || actionID == resultingActionID)
            return false;

        newActionID = resultingActionID;
        return true;
    }

    /// <summary>
    /// Calculate the best action to use, based on cooldown remaining.
    /// If there is a tie, the original is used.
    /// </summary>
    /// <param name="original">The original action.</param>
    /// <param name="actions">Action data.</param>
    /// <returns>The appropriate action to use.</returns>
    protected static uint CalcBestAction(uint original, params uint[] actions)
    {
        static (uint ActionID, CooldownData Data) Compare(
            uint original,
            (uint ActionID, CooldownData Data) a1,
            (uint ActionID, CooldownData Data) a2)
        {
            // This intent of this priority algorithm is to generate a single unified number that results in the
            // following behaviors:
            //   * Any ability that is off cooldown and at maximum charges has maximum (and equal) priority.
            //   * If only one of the two abilities is currently usable, it has a higher priority.
            //   * If both abilities are usable but recharging, the one that will cap soonest has higher priority.
            //   * If neither ability is usable, the one that will be usable soonest has higher priority.
            //
            // Mechanically, if the ability is not available, the result will be a negative number representing the
            // seconds until it is available, so the closer to zero (ie. more positive) the number, the sooner it
            // will be usable.  If the ability IS currently usable, the result will be a positive number (so always
            // higher priority than an ability that is not currently usable), adjusted such that the ability with
            // the shortest time until it reaches charge cap having the largest priority value.
            // Any ability not currently cooling down will have a priority of 1000.
            var a1Priority = a1.Data.Available ? (1000 - a1.Data.TotalCooldownRemaining) : -a1.Data.CooldownRemaining;
            var a2Priority = a2.Data.Available ? (1000 - a2.Data.TotalCooldownRemaining) : -a2.Data.CooldownRemaining;

            if (a1Priority == a2Priority)
                return original == a1.ActionID ? a1 : (original == a2.ActionID ? a2 : a1);

            return a1Priority > a2Priority ? a1 : a2;
        }

        static (uint ActionID, CooldownData Data) Selector(uint actionID)
            => (actionID, GetCooldown(actionID));

        return actions
            .Select(Selector)
            .Aggregate((a1, a2) => Compare(original, a1, a2))
            .ActionID;
    }

    /// <summary>
    /// Invokes the combo.
    /// </summary>
    /// <param name="actionID">Starting action ID.</param>
    /// <param name="lastComboActionID">Last combo action.</param>
    /// <param name="comboTime">Current combo time.</param>
    /// <param name="level">Current player level.</param>
    /// <returns>The replacement action ID.</returns>
    protected abstract uint Invoke(uint actionID, uint lastComboActionID, float comboTime, byte level);
}

/// <summary>
/// Passthrough methods and properties to IconReplacer. Shortens what it takes to call each method.
/// </summary>
internal abstract partial class CustomCombo
{
    /// <summary>
    /// Gets the player or null.
    /// </summary>
    protected static IPlayerCharacter? LocalPlayer
        => Service.ClientState.LocalPlayer;

    /// <summary>
    /// Gets the current target or null.
    /// </summary>
    protected static IGameObject? CurrentTarget
        => Service.TargetManager.Target;

    /// <summary>
    /// Gets the current territory type.
    /// </summary>
    protected static ushort CurrentTerritory
        => Service.ClientState.TerritoryType;

    /// <summary>
    /// Calls the original hook.
    /// </summary>
    /// <param name="actionID">Action ID.</param>
    /// <returns>The result from the hook.</returns>
    protected static uint OriginalHook(uint actionID)
        => Service.IconReplacer.OriginalHook(actionID);

    /// <summary>
    /// Compare the original hook to the given action ID.
    /// </summary>
    /// <param name="actionID">Action ID.</param>
    /// <returns>A value indicating whether the action would be modified.</returns>
    protected static bool IsOriginal(uint actionID)
        => Service.IconReplacer.OriginalHook(actionID) == actionID;

    /// <summary>
    /// Determine if the given preset is enabled.
    /// </summary>
    /// <param name="preset">Preset to check.</param>
    /// <returns>A value indicating whether the preset is enabled.</returns>
    protected static bool IsEnabled(CustomComboPreset preset)
        => (int)preset < 100 || Service.Configuration.IsEnabled(preset);

    /// <summary>
    /// Gets bool determining if action is greyed out or not.
    /// </summary>
    /// <param name="actionID">Action ID.</param>
    /// <returns>A bool value of whether the action can be used or not.</returns>
    protected static bool CanUseAction(uint actionID) => Service.IconReplacer.CanUseAction(actionID);

    /// <summary>
    /// Find if the player has a certain condition.
    /// </summary>
    /// <param name="flag">Condition flag.</param>
    /// <returns>A value indicating whether the player is in the condition.</returns>
    protected static bool HasCondition(ConditionFlag flag)
        => Service.Condition[flag];

    /// <summary>
    /// Find if the player is in combat.
    /// </summary>
    /// <returns>A value indicating whether the player is in combat.</returns>
    protected static bool InCombat()
        => Service.Condition[ConditionFlag.InCombat];

    /// <summary>
    /// Find if the player has a target.
    /// </summary>
    /// <returns>A value indicating whether the player has a target.</returns>
    protected static bool HasTarget()
        => CurrentTarget is not null;

    /// <summary>
    /// Find if the current target is an enemy.
    /// </summary>
    /// <returns>A value indicating whether the target is an enemy.</returns>
    protected static bool TargetIsEnemy()
        => HasTarget() && CurrentTarget?.ObjectKind == ObjectKind.BattleNpc && CurrentTarget?.SubKind == 5;

    /// <summary>
    /// Find if the player has a pet present.
    /// </summary>
    /// <returns>A value indicating whether the player has a pet present.</returns>
    protected static bool HasPetPresent()
        => Service.BuddyList.PetBuddy != null;

    /// <summary>
    /// Find if the player has a companion present.
    /// </summary>
    /// <returns>A value indicating whether the player has a companion present.</returns>
    protected static bool HasCompanionPresent()
        => Service.BuddyList.CompanionBuddy != null;

    /// <summary>
    /// Find if an effect on the player exists.
    /// The effect may be owned by the player or unowned.
    /// </summary>
    /// <param name="effectID">Status effect ID.</param>
    /// <returns>A value indicating if the effect exists.</returns>
    protected static bool HasEffect(ushort effectID)
        => FindEffect(effectID) is not null;

    /// <summary>
    /// Finds an effect on the player.
    /// The effect must be owned by the player or unowned.
    /// </summary>
    /// <param name="effectID">Status effect ID.</param>
    /// <returns>Status object or null.</returns>
    protected static IStatus? FindEffect(ushort effectID)
        => FindEffect(effectID, LocalPlayer, LocalPlayer?.EntityId);

    /// <summary>
    /// Find if an effect on the target exists.
    /// The effect must be owned by the player or unowned.
    /// </summary>
    /// <param name="effectID">Status effect ID.</param>
    /// <returns>A value indicating if the effect exists.</returns>
    protected static bool TargetHasEffect(ushort effectID)
        => FindTargetEffect(effectID) is not null;

    /// <summary>
    /// Finds an effect on the current target.
    /// The effect must be owned by the player or unowned.
    /// </summary>
    /// <param name="effectID">Status effect ID.</param>
    /// <returns>Status object or null.</returns>
    protected static IStatus? FindTargetEffect(ushort effectID)
        => FindEffect(effectID, CurrentTarget, LocalPlayer?.EntityId);

    /// <summary>
    /// Find if an effect on the player exists.
    /// The effect may be owned by anyone or unowned.
    /// </summary>
    /// <param name="effectID">Status effect ID.</param>
    /// <returns>A value indicating if the effect exists.</returns>
    protected static bool HasEffectAny(ushort effectID)
        => FindEffectAny(effectID) is not null;

    /// <summary>
    /// Finds an effect on the player.
    /// The effect may be owned by anyone or unowned.
    /// </summary>
    /// <param name="effectID">Status effect ID.</param>
    /// <returns>Status object or null.</returns>
    protected static IStatus? FindEffectAny(ushort effectID)
        => FindEffect(effectID, LocalPlayer, null);

    /// <summary>
    /// Find if an effect on the target exists.
    /// The effect may be owned by anyone or unowned.
    /// </summary>
    /// <param name="effectID">Status effect ID.</param>
    /// <returns>A value indicating if the effect exists.</returns>
    protected static bool TargetHasEffectAny(ushort effectID)
        => FindTargetEffectAny(effectID) is not null;

    /// <summary>
    /// Finds an effect on the current target.
    /// The effect may be owned by anyone or unowned.
    /// </summary>
    /// <param name="effectID">Status effect ID.</param>
    /// <returns>Status object or null.</returns>
    protected static IStatus? FindTargetEffectAny(ushort effectID)
        => FindEffect(effectID, CurrentTarget, null);

    /// <summary>
    /// Finds an effect on the given object.
    /// </summary>
    /// <param name="effectID">Status effect ID.</param>
    /// <param name="obj">Object to look for effects on.</param>
    /// <param name="sourceID">Source object ID.</param>
    /// <returns>Status object or null.</returns>
    protected static IStatus? FindEffect(ushort effectID, IGameObject? obj, uint? sourceID)
        => Service.ComboCache.GetStatus(effectID, obj, sourceID);

    /// <summary>
    /// Gets the cooldown data for an action.
    /// </summary>
    /// <param name="actionID">Action ID to check.</param>
    /// <returns>Cooldown data.</returns>
    protected static CooldownData GetCooldown(uint actionID)
        => Service.ComboCache.GetCooldown(actionID);

    /// <summary>
    /// Checks whether the player is in a party.
    /// </summary>
    /// <returns>True or false.</returns>
    protected static bool IsInInstance()
        => Service.DutyState.IsDutyStarted;

    /// <summary>
    /// Checks whether the player is in a party.
    /// </summary>
    /// <returns>True or false.</returns>
    protected static bool IsInParty()
        => Service.PartyList.Count > 0 ? true : false;

    /// <summary>
    /// Gets a value indicating whether an action is currently usable based on its cooldown
    /// For a charge-based ability, this returns true if the ability has any charges available.
    /// </summary>
    /// <param name="actionID">Action ID to check.</param>
    /// <returns>True or false.</returns>
    protected static bool IsCooldownUsable(uint actionID)
        => GetCooldown(actionID).Available;

    /// <summary>
    /// Gets a value indicating whether an action is currently recharging.
    /// For a non-charge-based ability, this is equivalent to !IsCooldownUsable()
    /// For a charge-based ability, this returns true if the ability has less than maximum charges,
    /// so a charge-based ability may still be usable if this returns true.
    /// </summary>
    /// <param name="actionID">Action ID to check.</param>
    /// <returns>True or false.</returns>
    protected static bool IsRecharging(uint actionID)
        => GetCooldown(actionID).IsCooldown;

    /// <summary>
    /// Get the current number of charges remaining for an action.
    /// </summary>
    /// <param name="actionID">Action ID to check.</param>
    /// <returns>Number of charges.</returns>
    protected static ushort GetRemainingCharges(uint actionID)
        => GetCooldown(actionID).RemainingCharges;

    /// <summary>
    /// Get the maximum number of charges for an action.
    /// </summary>
    /// <param name="actionID">Action ID to check.</param>
    /// <returns>Number of charges.</returns>
    protected static ushort GetMaxCharges(uint actionID)
        => GetCooldown(actionID).MaxCharges;

    /// <summary>
    /// Get a job gauge.
    /// </summary>
    /// <typeparam name="T">Type of job gauge.</typeparam>
    /// <returns>The job gauge.</returns>
    protected static T GetJobGauge<T>() where T : JobGaugeBase
        => Service.ComboCache.GetJobGauge<T>();

    /// <summary>
    /// Gets the distance from the target.
    /// </summary>
    /// <returns>Double representing the distance from the target.</returns>
    protected static double GetTargetDistance()
    {
        if (CurrentTarget is null)
            return 0;

        if (CurrentTarget is not IBattleChara chara)
            return 0;

        double distanceX = chara.YalmDistanceX;
        double distanceY = chara.YalmDistanceZ;

        return Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));
    }

    /// <summary>
    /// Gets a value indicating whether you are in melee range from the current target.
    /// </summary>
    /// <returns>Bool indicating whether you are in melee range.</returns>
    protected static bool InMeleeRange()
    {
        var distance = GetTargetDistance();

        if (distance == 0)
            return true;

        if (distance > 3)
            return false;

        return true;
    }
}
