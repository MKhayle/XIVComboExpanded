using XIVComboExpandedPlugin.Attributes;
using XIVComboExpandedPlugin.Combos;

namespace XIVComboExpandedPlugin;

/// <summary>
/// Combo presets.
/// </summary>
public enum CustomComboPreset
{
    // ====================================================================================
    #region Misc

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", ADV.JobID)]
    AdvAny = 0,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", AST.JobID)]
    AstAny = AdvAny + AST.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", BLM.JobID)]
    BlmAny = AdvAny + BLM.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", BRD.JobID)]
    BrdAny = AdvAny + BRD.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DNC.JobID)]
    DncAny = AdvAny + DNC.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DOH.JobID)]
    DohAny = AdvAny + DOH.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DOL.JobID)]
    DolAny = AdvAny + DOL.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DRG.JobID)]
    DrgAny = AdvAny + DRG.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DRK.JobID)]
    DrkAny = AdvAny + DRK.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", GNB.JobID)]
    GnbAny = AdvAny + GNB.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", MCH.JobID)]
    MchAny = AdvAny + MCH.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", MNK.JobID)]
    MnkAny = AdvAny + MNK.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", NIN.JobID)]
    NinAny = AdvAny + NIN.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", PLD.JobID)]
    PldAny = AdvAny + PLD.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", RDM.JobID)]
    RdmAny = AdvAny + RDM.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", RPR.JobID)]
    RprAny = AdvAny + RPR.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SAM.JobID)]
    SamAny = AdvAny + SAM.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SCH.JobID)]
    SchAny = AdvAny + SCH.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SGE.JobID)]
    SgeAny = AdvAny + SGE.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SMN.JobID)]
    SmnAny = AdvAny + SMN.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", WAR.JobID)]
    WarAny = AdvAny + WAR.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", WHM.JobID)]
    WhmAny = AdvAny + WHM.JobID,

    [CustomComboInfo("Disabled", "This should not be used.", ADV.JobID)]
    Disabled = 99999,

    #endregion
    // ====================================================================================
    #region ADV

    [CustomComboInfo("Swift Raise Feature", "Replace Ascend, Ressurection, Egeiro, Raise, and Verraise with Swiftcast when it is off cooldown (and Dualcast isn't up).", ADV.JobID)]
    AllSwiftcastFeature = 1000,

    #endregion
    // ====================================================================================
    #region ASTROLOGIAN

    [CustomComboInfo("Malefic to Draw", "Replace Malefic with Draw when no card is drawn and a card is available.", AST.JobID)]
    AstrologianMaleficDrawFeature = 3309,

    [CustomComboInfo("Gravity to Draw", "Replace Gravity with Draw when no card is drawn and a card is available.", AST.JobID)]
    AstrologianGravityDrawFeature = 3310,

    [CustomComboInfo("Play to Draw", "Replace Play with Draw when no card is drawn and a card is available.", AST.JobID)]
    AstrologianPlayDrawFeature = 3301,

    [ParentCombo(AstrologianPlayDrawFeature)]
    [CustomComboInfo("Play to Draw to Astrodyne", "Replace Play with Astrodyne when seals are full and Draw is on Cooldown.", AST.JobID)]
    AstrologianPlayDrawAstrodyneFeature = 3307,

    [CustomComboInfo("Play to Astrodyne", "Replace Play with Astrodyne when seals are full.", AST.JobID)]
    AstrologianPlayAstrodyneFeature = 3304,

    [CustomComboInfo("Draw Lockout", "Replace Draw (not Play to Draw) with Malefic when a card is drawn.", AST.JobID)]
    AstrologianDrawLockoutFeature = 3306,

    [CustomComboInfo("Minor Arcana to Crown Play Feature", "Replace Minor Arcana with Crown Play when a card drawn.", AST.JobID)]
    AstrologianMinorArcanaCrownPlayFeature = 3302,

    [CustomComboInfo("Crown Play to Minor Arcana Feature", "Replace Crown Play with Minor Arcana when no card is drawn.", AST.JobID)]
    AstrologianCrownPlayMinorArcanaFeature = 3308,

    [CustomComboInfo("Benefic 2 to Benefic Level Sync", "Changes Benefic 2 to Benefic when below level 26 in synced content.", AST.JobID)]
    AstrologianBeneficSyncFeature = 3303,

    #endregion
    // ====================================================================================
    #region BLACK MAGE

    [CustomComboInfo("Enochian Feature", "Change Fire 4 or Blizzard 4 to whichever action you can currently use.", BLM.JobID)]
    BlackEnochianFeature = 2501,

    [SecretCustomCombo]
    [ParentCombo(BlackEnochianFeature)]
    [CustomComboInfo("Enochian Despair Feature", "Change Fire 4 or Blizzard 4 to Despair when in Astral Fire with less than 2400 mana.", BLM.JobID)]
    BlackEnochianDespairFeature = 2510,

    [ParentCombo(BlackEnochianFeature)]
    [CustomComboInfo("Enochian No Sync Feature", "Fire 4 and Blizzard 4 will not sync to Fire 1 and Blizzard 1.", BLM.JobID)]
    BlackEnochianNoSyncFeature = 2518,

    [CustomComboInfo("Umbral Soul/Transpose Switcher", "Change Transpose into Umbral Soul when Umbral Soul is usable.", BLM.JobID)]
    BlackManaFeature = 2502,

    [CustomComboInfo("(Between the) Ley Lines", "Change Ley Lines into BTL when Ley Lines is active.", BLM.JobID)]
    BlackLeyLinesFeature = 2503,

    [CustomComboInfo("Fire 1/3 Feature", "Fire 1 becomes Fire 3 outside of Astral Fire, and when Firestarter is up.", BLM.JobID)]
    BlackFireFeature = 2504,

    [ParentCombo(BlackFireFeature)]
    [CustomComboInfo("Fire 1/3 Option", "Fire 1 will stay Fire 3 when not at max Astral Fire.", BLM.JobID)]
    BlackFireOption = 2515,

    [ParentCombo(BlackFireFeature)]
    [CustomComboInfo("Fire 1/3 Option (2)", "Fire 1 does not become Fire 3 outside of Astral Fire.", BLM.JobID)]
    BlackFireOption2 = 2516,

    [CustomComboInfo("Blizzard 1/3 Feature", "Replace Blizzard 1 with Blizzard 3 when unlocked and becomes Paradox when available.", BLM.JobID)]
    BlackBlizzardFeature = 2505,

    [CustomComboInfo("Freeze/Flare Feature", "Freeze and Flare become whichever action you can currently use.", BLM.JobID)]
    BlackFreezeFlareFeature = 2506,

    [CustomComboInfo("Fire 2 Feature", "(High) Fire 2 becomes Flare in Astral Fire with 1 or fewer Umbral Hearts.", BLM.JobID)]
    BlackFire2Feature = 2508,

    [CustomComboInfo("Ice 2 Feature", "(High) Blizzard 2 becomes Freeze in Umbral Ice.", BLM.JobID)]
    BlackBlizzard2Feature = 2509,

    [CustomComboInfo("Fire 2/Ice 2 Option", "Fire 2 and Blizzard 2 will not change unless you're at max Astral Fire or Umbral Ice.", BLM.JobID)]
    BlackFireBlizzard2Option = 2514,

    [CustomComboInfo("Umbral Soul Feature", "Replace your ice spells with Umbral Soul, while in Umbral Ice and having no target.", BLM.JobID)]
    BlackUmbralSoulFeature = 2517,

    [CustomComboInfo("Scathe/Xenoglossy Feature", "Scathe becomes Xenoglossy when available.", BLM.JobID)]
    BlackScatheFeature = 2507,

    #endregion
    // ====================================================================================
    #region BARD

    [CustomComboInfo("Wanderer's into Pitch Perfect", "Replace Wanderer's Minuet with Pitch Perfect while in WM.", BRD.JobID)]
    BardWanderersPitchPerfectFeature = 2301,

    [CustomComboInfo("Heavy Shot into Straight Shot", "Replace Heavy Shot with Straight Shot/Refulgent Arrow when available.", BRD.JobID)]
    BardStraightShotUpgradeFeature = 2302,

    [CustomComboInfo("Iron Jaws Feature", "Replace Iron Jaws with Caustic Bite/Stormbite depending on which is not present on the target.", BRD.JobID)]
    BardIronJawsFeature = 2308,

    [SecretCustomCombo]
    [CustomComboInfo("Pre Iron Jaws Feature", "Replace Iron Jaws with Caustic Bite/Stormbite depending on the duration when Iron Jaws is not available.", BRD.JobID)]
    BardPreIronJawsFeature = 2303,

    [CustomComboInfo("Burst Shot/Quick Nock into Apex Arrow", "Replace Burst Shot and Quick Nock with Apex Arrow when gauge is full.", BRD.JobID)]
    BardApexFeature = 2304,

    [CustomComboInfo("Quick Nock into Shadowbite", "Replace Quick Nock with Shadowbite when available.", BRD.JobID)]
    BardShadowbiteFeature = 2305,

    [SecretCustomCombo]
    [ConflictingCombos(BardBloodRainFeature)]
    [CustomComboInfo("Bloodletter Feature", "Replace Bloodletter with Empyreal Arrow and Sidewinder depending on which is available.", BRD.JobID)]
    BardBloodletterFeature = 2306,

    [SecretCustomCombo]
    [CustomComboInfo("Rain of Death Feature", "Replace Rain of Death with Empyreal Arrow and Sidewinder depending on which is available.", BRD.JobID)]
    BardRainOfDeathFeature = 2307,

    [SecretCustomCombo]
    [CustomComboInfo("Sidewinder Feature", "Replace Sidewinder with Empyreal Arrow depending on which is available.", BRD.JobID)]
    BardSidewinderFeature = 2309,

    [CustomComboInfo("Radiant Voice Feature", "Replace Radiant Finale with Battle Voice if Battle Voice is available.", BRD.JobID)]
    BardRadiantVoiceFeature = 2310,

    [CustomComboInfo("Radiant Strikes Feature", "Replace Radiant Finale with Raging Strikes if Raging Strikes is available.\nThis takes priority over Battle Voice if Radiant Voice is enabled.", BRD.JobID)]
    BardRadiantStrikesFeature = 2311,

    [CustomComboInfo("Barrage Feature", "Replace Barrage with Straight Shot if you have Straight Shot Ready (unless Shadowbite is ready).", BRD.JobID)]
    BardBarrageFeature = 2312,

    [SecretCustomCombo]
    [ConflictingCombos(BardBloodletterFeature)]
    [CustomComboInfo("Bloodletter to Rain of Death", "Replace Bloodletter with Rain of Death if there are no self-applied DoTs on your target.", BRD.JobID)]
    BardBloodRainFeature = 2313,

    #endregion
    // ====================================================================================
    #region DANCER

    [CustomComboInfo("Fan Dance 3 Feature", "Replace Fan Dance and Fan Dance 2 with Fan Dance 3 when available.", DNC.JobID)]
    DancerFanDance3Feature = 3801,

    [ParentCombo(DancerFanDance3Feature)]
    [CustomComboInfo("Fan Dance 4 Feature", "Replace Fan Dance and Fan Dance 2 with Fan Dance 4 when available.", DNC.JobID)]
    DancerFanDance4Feature = 3809,

    [SecretCustomCombo]
    [ConflictingCombos(DancerDanceComboCompatibility)]
    [CustomComboInfo("Dance Step Combo", "Replace Standard Step and Technical Step with each dance step while dancing.", DNC.JobID)]
    DancerDanceStepCombo = 3802,

    [CustomComboInfo("Flourishing Fan Dance 3", "Replace Flourish with Fan Dance 3 when available.", DNC.JobID)]
    DancerFlourishFan3Feature = 3810,

    [CustomComboInfo("Flourishing Fan Dance 4", "Replace Flourish with Fan Dance 4 when available.", DNC.JobID)]
    DancerFlourishFan4Feature = 3808,

    [CustomComboInfo("Flourish Proc Saver", "Replace Flourish with any available procs while off cooldown.", DNC.JobID)]
    DancerFlourishFeature = 3803,

    [ConflictingCombos(DancerSingleTargetProcs)]
    [CustomComboInfo("Single Target Multibutton", "Replace Cascade with its procs and combos as they activate.", DNC.JobID)]
    DancerSingleTargetMultibutton = 3804,

    [ConflictingCombos(DancerSingleTargetMultibutton)]
    [CustomComboInfo("Single Target to Procs", "Replace Cascade and Fountain with Reverse Cascade and Fountainfall respectively when available.", DNC.JobID)]
    DancerSingleTargetProcs = 3811,

    [CustomComboInfo("AoE Multibutton", "Replace Windmill with its procs and combos as they activate.", DNC.JobID)]
    DancerAoeMultibutton = 3805,

    [CustomComboInfo("AoE to Procs", "Replace Windmill and Bladeshower with Rising Wiindmill and Bloodshower respectively when available.", DNC.JobID)]
    DancerAoeProcs = 3812,

    [ConflictingCombos(DancerDanceStepCombo)]
    [CustomComboInfo(
        "Dance Step Feature",
        "Replace arbitrary actions with dance steps while dancing." +
        "\nThis helps ensure you can still dance with combos on, without using auto dance." +
        "\nYou can change the respective actions by inputting action IDs below for each dance step." +
        "\nThe defaults are Cascade, Flourish, Fan Dance and Fan Dance II. If set to 0, they will reset to these actions." +
        "\nYou can get Action IDs with Garland Tools by searching for the action and clicking the cog.",
        DNC.JobID)]
    DancerDanceComboCompatibility = 3806,

    [CustomComboInfo("Devilment Feature", "Replace Devilment with Starfall Dance when active.", DNC.JobID)]
    DancerDevilmentFeature = 3807,

    #endregion
    // ====================================================================================
    #region DARK KNIGHT

    [CustomComboInfo("Souleater Combo", "Replace Souleater with its combo chain.", DRK.JobID)]
    DarkSouleaterCombo = 3201,

    [ParentCombo(DarkSouleaterCombo)]
    [CustomComboInfo("Souleater Overcap Feature", "Replace Souleater with Bloodspiller when the next combo action would cause the Blood Gauge to overcap.", WAR.JobID)]
    DarkSouleaterOvercapFeature = 3206,

    [CustomComboInfo("Stalwart Soul Combo", "Replace Stalwart Soul with its combo chain.", DRK.JobID)]
    DarkStalwartSoulCombo = 3202,

    [ParentCombo(DarkStalwartSoulCombo)]
    [CustomComboInfo("Stalwart Soul Overcap Feature", "Replace Stalwart Soul with Quietus when the next combo action would cause the Blood Gauge to overcap.", WAR.JobID)]
    DarkStalwartSoulOvercapFeature = 3207,

    [CustomComboInfo("Delirium Feature", "Replace Souleater and Stalwart Soul with Bloodspiller and Quietus when Delirium is active.", DRK.JobID)]
    DarkDeliriumFeature = 3203,

    [CustomComboInfo("Blood Weapon Feature", "Replace Carve and Spit, and Abyssal Drain with Blood Weapon when available.", DRK.JobID)]
    DarkBloodWeaponFeature = 3204,

    [CustomComboInfo("Living Shadow Feature", "Replace Quietus and Bloodspiller with Living Shadow when available.", DRK.JobID)]
    DarkLivingShadowFeature = 3205,

    [CustomComboInfo("Living Shadowbringer Feature", "Replace Living Shadow with Shadowbringer when charges are available and your Shadow is present.", DRK.JobID)]
    DarkLivingShadowbringerFeature = 3208,

    [CustomComboInfo("Missing Shadowbringer Feature", "Replace Living Shadow with Shadowbringer when charges are available and Living Shadow is on cooldown.", DRK.JobID)]
    DarkLivingShadowbringerHpFeature = 3209,

    #endregion
    // ====================================================================================
    #region DRAGOON

    [CustomComboInfo("Jump + Mirage Dive", "Replace (High) Jump with Mirage Dive when Dive Ready.", DRG.JobID)]
    DragoonJumpFeature = 2201,

    [CustomComboInfo("Coerthan Torment Combo", "Replace Coerthan Torment with its combo chain.", DRG.JobID)]
    DragoonCoerthanTormentCombo = 2202,

    [CustomComboInfo("Coerthan Torment Wyrmwind Feature", "Replace Coerthan Torment with Wyrmwind Thrust when you have two Firstminds' Focus.", DRG.JobID)]
    DragoonCoerthanWyrmwindFeature = 2207,

    [CustomComboInfo("Chaos Thrust Combo", "Replace Chaos Thrust with its combo chain.", DRG.JobID)]
    DragoonChaosThrustCombo = 2203,

    [ParentCombo(DragoonChaosThrustCombo)]
    [CustomComboInfo("Chaos Thrust Disembowel Option", "Replace Chaos Thrust with its combo chain starting instead at Disembowel, not True Thrust, while no combo is ongoing.", DRG.JobID)]
    DragoonChaosThrustComboOption = 2209,

    [CustomComboInfo("Full Thrust Combo", "Replace Full Thrust with its combo chain.", DRG.JobID)]
    DragoonFullThrustCombo = 2204,

    [ParentCombo(DragoonFullThrustCombo)]
    [CustomComboInfo("Full Thrust Vorpal Thrust Option", "Replace Full Thrust with its combo chain starting instead at Vorpal Thrust, not True Thrust, while no combo is ongoing.", DRG.JobID)]
    DragoonFullThrustComboOption = 2210,

    [CustomComboInfo("Wheeling Thrust / Fang and Claw Option", "Replace Chaos Thrust with Wheeling Thrust and Full Thrust with Fang and Claw when you have either Enhanced Fang and Claw or Wheeling Thrust.", DRG.JobID)]
    DragoonFangThrustFeature = 2205,

    [ConflictingCombos(DragoonStardiverDragonfireDiveFeature)]
    [CustomComboInfo("Stardiver to Nastrond", "Replace Stardiver with Nastrond when Nastrond is off-cooldown, and Geirskogul outside of Life of the Dragon.", DRG.JobID)]
    DragoonStardiverNastrondFeature = 2206,

    [ConflictingCombos(DragoonStardiverNastrondFeature)]
    [CustomComboInfo("Stardiver to Dragonfire Dive", "Replace Stardiver with Dragonfire Dive when the latter is off cooldown (and you have more than 7.5s of LotD left), or outside of Life of the Dragon.", DRG.JobID)]
    DragoonStardiverDragonfireDiveFeature = 2208,

    [SecretCustomCombo]
    [ConflictingCombos(DragoonStardiverDragonfireDiveFeature, DragoonStardiverNastrondFeature)]
    [CustomComboInfo("Dive Dive Dive!", "Replace Spineshatter Dive, Dragonfire Dive, and Stardiver with whichever is available.", DRG.JobID)]
    DragoonDiveFeature = 2211,

    #endregion
    // ====================================================================================
    #region GUNBREAKER

    [CustomComboInfo("Solid Barrel Combo", "Replace Solid Barrel with its combo chain.", GNB.JobID)]
    GunbreakerSolidBarrelCombo = 3701,

    [ParentCombo(GunbreakerSolidBarrelCombo)]
    [CustomComboInfo("Burst Strike Feature", "Replace Solid Barrel with Burst Strike when charges are full.", GNB.JobID)]
    GunbreakerBurstStrikeFeature = 3710,

    [CustomComboInfo("Gnashing Fang Continuation", "Replace Gnashing Fang with Continuation moves when appropriate.", GNB.JobID)]
    GunbreakerGnashingFangCont = 3702,

    [CustomComboInfo("Burst Strike Continuation", "Replace Burst Strike with Continuation moves when appropriate.", GNB.JobID)]
    GunbreakerBurstStrikeCont = 3703,

    [SecretCustomCombo]
    [CustomComboInfo("Sonic Shock Feature", "Replace Bow Shock and Sonic Break with one or the other depending on which is on cooldown.", GNB.JobID)]
    GunbreakerBowShockSonicBreakFeature = 3704,

    [CustomComboInfo("Demon Slaughter Combo", "Replace Demon Slaughter with its combo chain.", GNB.JobID)]
    GunbreakerDemonSlaughterCombo = 3705,

    [ParentCombo(GunbreakerDemonSlaughterCombo)]
    [CustomComboInfo("Fated Circle Feature", "In addition to the Demon Slaughter combo, add Fated Circle when charges are full.", GNB.JobID)]
    GunbreakerFatedCircleFeature = 3706,

    [CustomComboInfo("Empty Bloodfest Feature", "Replace Burst Strike and Fated Circle with Bloodfest if the powder gauge is empty.", GNB.JobID)]
    GunbreakerEmptyBloodfestFeature = 3707,

    [SecretCustomCombo]
    [CustomComboInfo("No Mercy Bow Shock/Sonic Break Feature", "Replace No Mercy with Bow Shock, and then Sonic Break, while No Mercy is active.", GNB.JobID)]
    GunbreakerNoMercyFeature = 3708,

    [CustomComboInfo("No Mercy Double Down Feature", "Replace No Mercy with Double Down while No Mercy is active, 2 cartridges are available, and Double Down is off cooldown.\nThis takes priority over the No Mercy Bow Shock/Sonic Break Feature.", GNB.JobID)]
    GunbreakerNoMercyDoubleDownFeature = 3712,

    [ConflictingCombos(GunbreakerNoMercyFeature)]
    [CustomComboInfo("No Mercy Always Double Down Feature", "Replace No Mercy with Double Down while No Mercy is active.", GNB.JobID)]
    GunbreakerNoMercyAlwaysDoubleDownFeature = 3713,

    [SecretCustomCombo]
    [CustomComboInfo("Double Down Feature", "Replace Burst Strike and Fated Circle with Double Down when available.", GNB.JobID)]
    GunbreakerDoubleDownFeature = 3709,

    #endregion
    // ====================================================================================
    #region MACHINIST

    [CustomComboInfo("(Heated) Shot Combo", "Replace Clean Shot with its combo chain.", MCH.JobID)]
    MachinistMainCombo = 3101,

    [ParentCombo(MachinistMainCombo)]
    [CustomComboInfo("Hypercharge Combo", "Replace Clean Shot combo with Heat Blast while overheated.", MCH.JobID)]
    MachinistHypercomboFeature = 3108,

    [CustomComboInfo("Spread Shot Heat", "Replace Spread Shot with Auto Crossbow when overheated.", MCH.JobID)]
    MachinistSpreadShotFeature = 3102,

    [CustomComboInfo("Hypercharge Feature", "Replace Heat Blast and Auto Crossbow with Hypercharge when not overheated.", MCH.JobID)]
    MachinistOverheatFeature = 3103,

    [CustomComboInfo("Hyperfire Feature", "Replace Hypercharge with Wildfire if available and you have a target.", MCH.JobID)]
    MachinistHyperfireFeature = 3109,

    [CustomComboInfo("Overdrive Feature", "Replace Rook Autoturret and Automaton Queen with Overdrive while active.", MCH.JobID)]
    MachinistOverdriveFeature = 3104,

    [SecretCustomCombo]
    [CustomComboInfo("Gauss Round / Ricochet Feature", "Replace Gauss Round and Ricochet with one or the other depending on which has more charges.", MCH.JobID)]
    MachinistGaussRoundRicochetFeature = 3105,

    [SecretCustomCombo]
    [ParentCombo(MachinistGaussRoundRicochetFeature)]
    [CustomComboInfo("Gauss Round / Ricochet Overheat Option", "Replace Gauss Round and Ricochet with one or the other only while overheated.", MCH.JobID)]
    MachinistGaussRoundRicochetFeatureOption = 3110,

    [SecretCustomCombo]
    [ConflictingCombos(MachinistHotShotChainsawFeature)]
    [CustomComboInfo("Hot Shot (Air Anchor) / Drill / Chainsaw Feature", "Replace Hot Shot (Air Anchor), Drill, and Chainsaw with whichever is available.", MCH.JobID)]
    MachinistHotShotDrillChainsawFeature = 3106,

    [SecretCustomCombo]
    [ConflictingCombos(MachinistHotShotDrillChainsawFeature)]
    [CustomComboInfo("Hot Shot (Air Anchor) / Chainsaw Feature", "Replace Hot Shot (Air Anchor) and Chainsaw with whichever is available.", MCH.JobID)]
    MachinistHotShotChainsawFeature = 3107,

    [SecretCustomCombo]
    [CustomComboInfo("Bioblaster / Chainsaw Feature", "Replace Bioblaster with whichever of Bioblaster or Chainsaw is available.", MCH.JobID)]
    MachinistBioblasterChainsawFeature = 3111,

    #endregion
    // ====================================================================================
    #region MONK

    [CustomComboInfo("Monk AoE Combo", "Replace Masterful Blitz with the AoE combo chain. This was changed from Rockbreaker due to an action queueing bug.", MNK.JobID)]
    MonkAoECombo = 2001,

    [CustomComboInfo("Dragon Kick / Bootshine Feature", "Replace Dragon Kick with Bootshine if Leaden Fist is up.", MNK.JobID)]
    MonkBootshineFeature = 2011,

    [CustomComboInfo("Twin Snakes / True Strike Feature", "Replace Twin Snakes with True Strike if Twin Snakes has more than 6s remaining.", MNK.JobID)]
    MonkTwinSnakesFeature = 2013,

    [ParentCombo(MonkTwinSnakesFeature)]
    [CustomComboInfo("Formless Snakes Option", "While Formless Fist is active, do not replace Twin Snakes.", MNK.JobID)]
    MonkFormlessSnakesOption = 2015,

    [CustomComboInfo("Demolish / Snap Punch Feature", "Replace Demolish with Snap Punch if Demolish has more than 6s remaining on your current target.", MNK.JobID)]
    MonkDemolishFeature = 2014,

    [CustomComboInfo("Dragon Balance Feature", "Replace Dragon Kick with Masterful Blitz if you have 3 Beast Chakra.", MNK.JobID)]
    MonkDragonKickBalanceFeature = 2005,

    [CustomComboInfo("Dragon Meditation Feature", "Replace Dragon Kick with Meditation when out of combat and the Fifth Chakra is not open.", MNK.JobID)]
    MonkDragonKickMeditationFeature = 2012,

    [CustomComboInfo("Howling Fist / Meditation Feature", "Replace Howling Fist with Meditation when the Fifth Chakra is not open.", MNK.JobID)]
    MonkHowlingFistMeditationFeature = 2003,

    [CustomComboInfo("Perfect Balance Feature", "Replace Perfect Balance with Masterful Blitz when you have 3 Beast Chakra.", MNK.JobID)]
    MonkPerfectBalanceFeature = 2004,

    [CustomComboInfo("Riddle of Brotherly Fire", "Replace Riddle of Fire with Brotherhood if the former is on cooldown and the latter is not.", MNK.JobID)]
    MonkRiddleOfFireBrotherhood = 2009,

    [CustomComboInfo("Riddle of Fire and Wind", "Replace Riddle of Fire with Riddle of Wind if the former is on cooldown and the latter is not.", MNK.JobID)]
    MonkRiddleOfFireWind = 2010,

    #endregion
    // ====================================================================================
    #region NINJA

    [CustomComboInfo("Aeolian Edge Combo", "Replace Aeolian Edge with its combo chain.", NIN.JobID)]
    NinjaAeolianEdgeCombo = 3002,

    [SecretCustomCombo]
    [CustomComboInfo("Aeolian Edge / Huton Feature", "Replaces Aeolian Edge with Armor Crush when Huton has less than 30 seconds remaining and Huraijin when missing.", NIN.JobID)]
    NinjaAeolianEdgeHutonFeature = 3019,

    [CustomComboInfo("Aeolian Edge / Ninjutsu Feature", "Replace Aeolian Edge with Ninjutsu if any Mudra are used.", NIN.JobID)]
    NinjaAeolianNinjutsuFeature = 3008,

    [CustomComboInfo("Aeolian Edge / Raiju Feature", "Replace the Aeolian Edge combo with Fleeting Raiju when available.", NIN.JobID)]
    NinjaAeolianEdgeRaijuFeature = 3013,

    [CustomComboInfo("Armor Crush Combo", "Replace Armor Crush with its combo chain.", NIN.JobID)]
    NinjaArmorCrushCombo = 3001,

    [CustomComboInfo("Armor Crush / Ninjutsu Feature", "Replace Armor Crush with Ninjutsu if any Mudra are used.", NIN.JobID)]
    NinjaArmorCrushNinjutsuFeature = 3015,

    [CustomComboInfo("Armor Crush / Raiju Feature", "Replace the Armor Crush combo with Forked Raiju when available.", NIN.JobID)]
    NinjaArmorCrushRaijuFeature = 3012,

    [CustomComboInfo("Huraijin / Armor Crush Combo", "Replace Huraijin with Armor Crush after using Gust Slash.", NIN.JobID)]
    NinjaHuraijinArmorCrushCombo = 3010,

    [CustomComboInfo("Huraijin / Ninjutsu Feature", "Replace Huraijin with Ninjutsu if any Mudra are used.", NIN.JobID)]
    NinjaHuraijinNinjutsuFeature = 3009,

    [ConflictingCombos(NinjaHuraijinFleetingRaijuFeature)]
    [CustomComboInfo("Huraijin / Forked Raiju Feature", "Replace Huraijin with Forked Raiju when available.", NIN.JobID)]
    NinjaHuraijinForkedRaijuFeature = 3011,

    [ConflictingCombos(NinjaHuraijinForkedRaijuFeature)]
    [CustomComboInfo("Huraijin / Fleeting Raiju Option", "Replace Huraijin with Fleeting Raiju when available.", NIN.JobID)]
    NinjaHuraijinFleetingRaijuFeature = 3014,

    [CustomComboInfo("Hakke Mujinsatsu Combo", "Replace Hakke Mujinsatsu with its combo chain.", NIN.JobID)]
    NinjaHakkeMujinsatsuCombo = 3003,

    [CustomComboInfo("Hakke Mujinsatsu / Ninjutsu Feature", "Replace Hakke Mujinsatsu with Ninjutsu if any Mudra are used.", NIN.JobID)]
    NinjaHakkeMujinsatsuNinjutsuFeature = 3016,

    [ConflictingCombos(NinjaNinjitsuFleetingRaijuFeature)]
    [CustomComboInfo("Ninjitsu / Forked Raiju Feature", "Replace Ninjitsu with Forked Raiju when available and no Mudra are active.", NIN.JobID)]
    NinjaNinjitsuForkedRaijuFeature = 3017,

    [ConflictingCombos(NinjaNinjitsuForkedRaijuFeature)]
    [CustomComboInfo("Ninjitsu / Fleeting Raiju Feature", "Replace Ninjitsu with Fleeting Raiju when available and no Mudra are active.", NIN.JobID)]
    NinjaNinjitsuFleetingRaijuFeature = 3018,

    [CustomComboInfo("Kassatsu to Trick", "Replace Kassatsu with Trick Attack while Suiton or Hidden is up.\nCooldown tracking plugin recommended.", NIN.JobID)]
    NinjaKassatsuTrickFeature = 3004,

    [CustomComboInfo("Ten Chi Jin to Meisui", "Replace Ten Chi Jin (the move) with Meisui while Suiton is up.\nCooldown tracking plugin recommended.", NIN.JobID)]
    NinjaTCJMeisuiFeature = 3005,

    [CustomComboInfo("Kassatsu Chi/Jin Feature", "Replace Chi with Jin while Kassatsu is up if you have Enhanced Kassatsu.", NIN.JobID)]
    NinjaKassatsuChiJinFeature = 3006,

    [CustomComboInfo("Hide to Mug", "Replace Hide with Mug while in combat.", NIN.JobID)]
    NinjaHideMugFeature = 3007,

    #endregion
    // ====================================================================================
    #region PALADIN

    [CustomComboInfo("Goring Blade Combo", "Replace Goring Blade with its combo chain.", PLD.JobID)]
    PaladinGoringBladeCombo = 1901,

    [ConflictingCombos(PaladinRoyalAuthorityAtonementFeature)]
    [CustomComboInfo("Goring Blade Atonement Feature", "Replace Goring Blade with Atonement when under the effect of Sword Oath.", PLD.JobID)]
    PaladinGoringBladeAtonementFeature = 1909,

    [CustomComboInfo("Royal Authority Combo", "Replace Royal Authority with its combo chain.", PLD.JobID)]
    PaladinRoyalAuthorityCombo = 1902,

    [ConflictingCombos(PaladinGoringBladeAtonementFeature)]
    [CustomComboInfo("Royal Authority Atonement Feature", "Replace Royal Authority with Atonement when under the effect of Sword Oath.", PLD.JobID)]
    PaladinRoyalAuthorityAtonementFeature = 1903,

    [CustomComboInfo("Prominence Combo", "Replace Prominence with its combo chain.", PLD.JobID)]
    PaladinProminenceCombo = 1904,

    [CustomComboInfo("Requiescat Confiteor", "Replace Requiescat with Confiteor while under the effect of Requiescat.", PLD.JobID)]
    PaladinRequiescatCombo = 1905,

    [SecretCustomCombo]
    [CustomComboInfo("Confiteor Feature", "Replace Holy Spirit/Circle with Confiteor when Requiescat is up and MP is under 2000 or only one stack remains.", PLD.JobID)]
    PaladinConfiteorFeature = 1907,

    [SecretCustomCombo]
    [CustomComboInfo("Scornful Spirits Feature", "Replace Spirits Within and Circle of Scorn with whichever is available soonest.", PLD.JobID)]
    PaladinScornfulSpiritsFeature = 1908,

    [CustomComboInfo("Shields on your Feet Feature", "Replace Shield Bash with Low Blow when available.", PLD.JobID)]
    PaladinShieldBashFeature = 1910,

    #endregion
    // ====================================================================================
    #region REAPER

    [CustomComboInfo("Slice Combo", "Replace Infernal Slice with its combo chain.", RPR.JobID)]
    ReaperSliceCombo = 3901,

    [ConflictingCombos(ReaperSliceGallowsFeature)]
    [CustomComboInfo("Slice Gibbet Feature", "Replace Infernal Slice with Gibbet while Reaving or Enshrouded.", RPR.JobID)]
    ReaperSliceGibbetFeature = 3903,

    [ConflictingCombos(ReaperSliceGibbetFeature)]
    [CustomComboInfo("Slice Gallows Feature", "Replace Infernal Slice with Gallows while Reaving or Enshrouded.", RPR.JobID)]
    ReaperSliceGallowsFeature = 3904,

    [CustomComboInfo("Slice Enhanced Soul Reaver Feature", "Replace Infernal Slice with whichever of Gibbet or Gallows is currently enhanced while Reaving.", RPR.JobID)]
    ReaperSliceEnhancedSoulReaverFeature = 3913,

    [CustomComboInfo("Slice Enhanced Enshrouded Feature", "Replace Infernal Slice with whichever of Gibbet or Gallows is currently enhanced while Enshrouded.", RPR.JobID)]
    ReaperSliceEnhancedEnshroudedFeature = 3914,

    [CustomComboInfo("Slice Lemure's Feature", "Replace Infernal Slice with Lemure's Slice when two or more stacks of Void Shroud are active.", RPR.JobID)]
    ReaperSliceLemuresFeature = 3919,

    [CustomComboInfo("Slice Communio Feature", "Replace Infernal Slice with Communio when one stack of Shroud is left.", RPR.JobID)]
    ReaperSliceCommunioFeature = 3920,

    [CustomComboInfo("Slice Soulsow Feature", "Replace Infernal Slice with Soulsow when out of combat and not active.", RPR.JobID)]
    ReaperSliceSoulsowFeature = 3930,

    [ConflictingCombos(ReaperShadowGibbetFeature)]
    [CustomComboInfo("Shadow Gallows Feature", "Replace Shadow of Death with Gallows while Reaving or Enshrouded.", RPR.JobID)]
    ReaperShadowGallowsFeature = 3905,

    [ConflictingCombos(ReaperShadowGallowsFeature)]
    [CustomComboInfo("Shadow Gibbet Feature", "Replace Shadow of Death with Gibbet while Reaving or Enshrouded.", RPR.JobID)]
    ReaperShadowGibbetFeature = 3906,

    [CustomComboInfo("Shadow Lemure's Feature", "Replace Shadow of Death with Lemure's Slice when two or more stacks of Void Shroud are active.", RPR.JobID)]
    ReaperShadowLemuresFeature = 3923,

    [CustomComboInfo("Shadow Communio Feature", "Replace Shadow of Death with Communio when one stack of Shroud is left.", RPR.JobID)]
    ReaperShadowCommunioFeature = 3924,

    [CustomComboInfo("Shadow Soulsow Feature", "Replace Shadow of Death with Soulsow when out of combat, not active, and you have no target.", RPR.JobID)]
    ReaperShadowSoulsowFeature = 3929,

    [ConflictingCombos(ReaperSoulGibbetFeature)]
    [CustomComboInfo("Soul Gallows Feature", "Replace Soul Slice with Gallows while Reaving or Enshrouded.", RPR.JobID)]
    ReaperSoulGallowsFeature = 3925,

    [ConflictingCombos(ReaperSoulGallowsFeature)]
    [CustomComboInfo("Soul Gibbet Feature", "Replace Soul Slice with Gibbet while Reaving or Enshrouded.", RPR.JobID)]
    ReaperSoulGibbetFeature = 3926,

    [CustomComboInfo("Soul Lemure's Feature", "Replace Soul Slice with Lemure's Slice when two or more stacks of Void Shroud are active.", RPR.JobID)]
    ReaperSoulLemuresFeature = 3927,

    [CustomComboInfo("Soul Communio Feature", "Replace Soul Slice with Communio when one stack of Shroud is left.", RPR.JobID)]
    ReaperSoulCommunioFeature = 3928,

    [CustomComboInfo("Soul Overcap Feature", "Replace Soul Slice with Blood Stalk not Enshrouded and greater-than 50 Soul Gauge is present.", RPR.JobID)]
    ReaperSoulOvercapFeature = 3934,

    [CustomComboInfo("Soul (Scythe) Overcap Feature", "Replace Soul Scythe with Grim Swathe when not Enshrouded and greater-than 50 Soul Gauge is present.", RPR.JobID)]
    ReaperSoulScytheOvercapFeature = 3935,

    [CustomComboInfo("Scythe Combo", "Replace Nightmare Scythe with its combo chain.", RPR.JobID)]
    ReaperScytheCombo = 3902,

    [CustomComboInfo("Scythe Guillotine Feature", "Replace Nightmare Scythe with Guillotine while Reaving or Enshrouded.", RPR.JobID)]
    ReaperScytheGuillotineFeature = 3907,

    [CustomComboInfo("Scythe Lemure's Feature", "Replace Nightmare Scythe with Lemure's Slice when two or more stacks of Void Shroud are active.", RPR.JobID)]
    ReaperScytheLemuresFeature = 3921,

    [CustomComboInfo("Scythe Communio Feature", "Replace Nightmare Scythe with Communio when one stack is left of Shroud.", RPR.JobID)]
    ReaperScytheCommunioFeature = 3922,

    [CustomComboInfo("Scythe Soulsow Feature", "Replace Nightmare Scythe with Soulsow when out of combat and not active.", RPR.JobID)]
    ReaperScytheSoulsowFeature = 3931,

    [CustomComboInfo("Scythe Harvest Moon Feature", "Replace Nightmare Scythe with Harvest Moon when Soulsow is active and you have a target.", RPR.JobID)]
    ReaperScytheHarvestMoonFeature = 3932,

    [CustomComboInfo("Enhanced Soul Reaver Feature", "Replace Gibbet and Gallows with whichever is currently enhanced while Reaving.", RPR.JobID)]
    ReaperEnhancedSoulReaverFeature = 3917,

    [CustomComboInfo("Enhanced Enshrouded Feature", "Replace Gibbet and Gallows with whichever is currently enhanced while Enshrouded.", RPR.JobID)]
    ReaperEnhancedEnshroudedFeature = 3918,

    [CustomComboInfo("Lemure's Soul Reaver Feature", "Replace Gibbet, Gallows, and Guillotine with Lemure's Slice or Scythe when two or more stacks of Void Shroud are active.", RPR.JobID)]
    ReaperLemuresSoulReaverFeature = 3911,

    [CustomComboInfo("Communio Soul Reaver Feature", "Replace Gibbet, Gallows, and Guillotine with Communio when one stack is left of Shroud.", RPR.JobID)]
    ReaperCommunioSoulReaverFeature = 3912,

    [CustomComboInfo("Enshroud Communio Feature", "Replace Enshroud with Communio when Enshrouded.", RPR.JobID)]
    ReaperEnshroudCommunioFeature = 3909,

    [CustomComboInfo("Blood Stalk Gluttony Feature", "Replace Blood Stalk with Gluttony when available and greater-than-or-equal-to 50 Soul Gauge is present.", RPR.JobID)]
    ReaperBloodStalkGluttonyFeature = 3915,

    [CustomComboInfo("Grim Swathe Gluttony Feature", "Replace Grim Swathe with Gluttony when available and greater-than-or-equal-to 50 Soul Gauge is present.", RPR.JobID)]
    ReaperGrimSwatheGluttonyFeature = 3916,

    [CustomComboInfo("Arcane Harvest Feature", "Replace Arcane Circle with Plentiful Harvest when you have stacks of Immortal Sacrifice.", RPR.JobID)]
    ReaperHarvestFeature = 3908,

    [CustomComboInfo("Regress Feature", "Replace Hell's Ingress and Egress turn with Regress when Threshold is active, instead of just the opposite of the one used.", RPR.JobID)]
    ReaperRegressFeature = 3910,

    [ParentCombo(ReaperRegressFeature)]
    [CustomComboInfo("Delayed Regress Option", "Replace the action used with Regress only after 1.5 seconds have elapsed on Threshold.", RPR.JobID)]
    ReaperRegressOption = 3933,

    [CustomComboInfo("Harpe Soulsow Feature", "Replace Harpe with Soulsow when not active and out of combat or you have no target.", RPR.JobID)]
    ReaperHarpeHarvestSoulsowFeature = 3936,

    [CustomComboInfo("Harpe Harvest Moon Feature", "Replace Harpe with Harvest Moon when Soulsow is active and you are in combat.", RPR.JobID)]
    ReaperHarpeHarvestMoonFeature = 3937,

    [ParentCombo(ReaperHarpeHarvestMoonFeature)]
    [CustomComboInfo("Enhanced Harpe Option", "Prevent replacing Harpe with Harvest Moon when Enhanced Harpe is active.", RPR.JobID)]
    ReaperHarpeHarvestMoonEnhancedFeature = 3939,

    [ParentCombo(ReaperHarpeHarvestMoonFeature)]
    [CustomComboInfo("Combat Option", "Prevent replacing Harpe with Harvest Moon when not in combat.", RPR.JobID)]
    ReaperHarpeHarvestMoonCombatFeature = 3938,

    #endregion
    // ====================================================================================
    #region RED MAGE

    [CustomComboInfo("Verstone/Verfire Feature", "Replace Verstone/Verfire with Jolt/Scorch when no proc is available.", RDM.JobID)]
    RedMageVerprocFeature = 3504,

    [CustomComboInfo("Verstone/Verfire Plus Feature", "Replace Verstone/Verfire with Veraero/Verthunder when various instant-cast effects are active.", RDM.JobID)]
    RedMageVerprocPlusFeature = 3505,

    [CustomComboInfo("Verstone/Verfire Plus Opener Feature (Stone)", "Replace Verstone with Veraero when out of combat.", RDM.JobID)]
    RedMageVerprocOpenerStoneFeature = 3506,

    [CustomComboInfo("Verstone/Verfire Plus Opener Feature (Fire)", "Replace Verfire with Verthunder when out of combat.", RDM.JobID)]
    RedMageVerprocOpenerFireFeature = 3507,

    [CustomComboInfo("Verstone/Verfire Mana Stacks Feature", "Replace Verstone/Verfire with Verflare/Verholy at 3 mana stacks.", RDM.JobID)]
    RedMageVerprocManaStacksFeature = 3515,

    [CustomComboInfo("Verstone/Verfire Capstone Combo", "Replace Verstone/Verfire with Scorch and Resolution when available.", RDM.JobID)]
    RedMageVerprocCapstoneCombo = 3513,

    [CustomComboInfo("Veraero/Verthunder Capstone Combo", "Replace Veraero/Verthunder with Scorch and Resolution when available.", RDM.JobID)]
    RedMageVeraeroVerthunderCapstoneCombo = 3512,

    [CustomComboInfo("AoE Combo", "Replace Veraero/Verthunder 2 with Impact when various instant-cast effects are active.", RDM.JobID)]
    RedMageAoEFeature = 3501,

    [CustomComboInfo("AoE Capstone Combo", "Replace Veraero/Verthunder 2 with Scorch and Resolution when available.", RDM.JobID)]
    RedMageAoECapstoneCombo = 3514,

    [CustomComboInfo("Melee combo", "Replace Redoublement with its combo chain, following enchantment rules.", RDM.JobID)]
    RedMageMeleeCombo = 3502,

    [CustomComboInfo("Melee Mana Stacks Feature", "Replace Redoublement and Moulinet with Verflare/Verholy at 3 mana stacks, using whichever mana color is lower.", RDM.JobID)]
    RedMageMeleeManaStacksFeature = 3516,

    [CustomComboInfo("Melee Capstone Combo", "Replace Redoublement and Moulinet with Scorch and Resolution when available.", RDM.JobID)]
    RedMageMeleeCapstoneCombo = 3503,

    [CustomComboInfo("Acceleration into Swiftcast", "Replace Acceleration with Swiftcast when on cooldown or synced.", RDM.JobID)]
    RedMageAccelerationSwiftcastFeature = 3509,

    [ParentCombo(RedMageAccelerationSwiftcastFeature)]
    [CustomComboInfo("Acceleration with Swiftcast first", "Replace Acceleration with Swiftcast when neither are on cooldown.", RDM.JobID)]
    RedMageAccelerationSwiftcastOption = 3511,

    [CustomComboInfo("Embolden to Manaification", "Replace Embolden with Manafication if the former is on cooldown and the latter is not.", RDM.JobID)]
    RedMageEmboldenFeature = 3510,

    [SecretCustomCombo]
    [CustomComboInfo("Contre Sixte / Fleche Feature", "Replace Contre Sixte and Fleche with whichever is available.", RDM.JobID)]
    RedMageContreFlecheFeature = 3508,

    #endregion
    // ====================================================================================
    #region SAGE

    [CustomComboInfo("Taurochole Into Druochole Feature", "Replace Taurochole with Druochole when on cooldown", SGE.JobID)]
    SageTaurocholeDruocholeFeature = 4001,

    [CustomComboInfo("Taurochole Into Rhizomata Feature", "Replace Taurochole with Rhizomata when Addersgall is empty.", SGE.JobID)]
    SageTaurocholeRhizomataFeature = 4002,

    [CustomComboInfo("Druochole Into Rhizomata Feature", "Replace Druochole with Rhizomata when Addersgall is empty.", SGE.JobID)]
    SageDruocholeRhizomataFeature = 4003,

    [CustomComboInfo("Ixochole Into Rhizomata Feature", "Replace Ixochole with Rhizomata when Addersgall is empty.", SGE.JobID)]
    SageIxocholeRhizomataFeature = 4004,

    [CustomComboInfo("Kerachole Into Rhizomata Feature", "Replace Kerachole with Rhizomata when Addersgall is empty.", SGE.JobID)]
    SageKeracholaRhizomataFeature = 4005,

    [CustomComboInfo("Soteria Kardia Feature", "Replace Soteria with Kardia when off cooldown and missing Kardion.", SGE.JobID)]
    SageSoteriaKardionFeature = 4006,

    [CustomComboInfo("Phlegma into Toxikon", "Replace Phlegma with Toxikon when no charges rmemain and have Addersting.\nThis takes priority over Phlegma into Dyskrasia.", SGE.JobID)]
    SagePhlegmaToxicon = 4007,

    [CustomComboInfo("Phlegma into Dyskrasia", "Replace Phlegma with Dyskrasia when no charges remain or have no target.", SGE.JobID)]
    SagePhlegmaDyskrasia = 4008,

    [ParentCombo(SagePhlegmaToxicon)]
    [CustomComboInfo("Reverse Swapped Ability", "Replace Toxikon with Phlegma when you have charges of Phlemga available.", SGE.JobID)]
    SageToxiconPhlegma = 4009,

    #endregion
    // ====================================================================================
    #region SAMURAI

    [CustomComboInfo("Yukikaze Combo", "Replace Yukikaze with its combo chain.", SAM.JobID)]
    SamuraiYukikazeCombo = 3401,

    [CustomComboInfo("Gekko Combo", "Replace Gekko with its combo chain.", SAM.JobID)]
    SamuraiGekkoCombo = 3402,

    [ParentCombo(SamuraiGekkoCombo)]
    [CustomComboInfo("Gekko Combo Option", "Start the Gekko combo chain with Jinpu instead of Hakaze.", SAM.JobID)]
    SamuraiGekkoOption = 3416,

    [CustomComboInfo("Kasha Combo", "Replace Kasha with its combo chain.", SAM.JobID)]
    SamuraiKashaCombo = 3403,

    [ParentCombo(SamuraiKashaCombo)]
    [CustomComboInfo("Kasha Combo Option", "Start the Kasha combo chain with Shifu instead of Hakaze.", SAM.JobID)]
    SamuraiKashaOption = 3417,

    [CustomComboInfo("Mangetsu Combo", "Replace Mangetsu with its combo chain.", SAM.JobID)]
    SamuraiMangetsuCombo = 3404,

    [CustomComboInfo("Oka Combo", "Replace Oka with its combo chain.", SAM.JobID)]
    SamuraiOkaCombo = 3405,

    [ConflictingCombos(SamuraiIaijutsuTsubameGaeshiFeature)]
    [CustomComboInfo("Tsubame-gaeshi to Iaijutsu", "Replace Tsubame-gaeshi with Iaijutsu when Sen is empty.", SAM.JobID)]
    SamuraiTsubameGaeshiIaijutsuFeature = 3407,

    [ConflictingCombos(SamuraiIaijutsuShohaFeature)]
    [CustomComboInfo("Tsubame-gaeshi to Shoha", "Replace Tsubame-gaeshi with Shoha when meditation is 3.", SAM.JobID)]
    SamuraiTsubameGaeshiShohaFeature = 3408,

    [ConflictingCombos(SamuraiTsubameGaeshiIaijutsuFeature)]
    [CustomComboInfo("Iaijutsu to Tsubame-gaeshi", "Replace Iaijutsu with Tsubame-gaeshi when Sen is not empty.", SAM.JobID)]
    SamuraiIaijutsuTsubameGaeshiFeature = 3409,

    [ConflictingCombos(SamuraiTsubameGaeshiShohaFeature)]
    [CustomComboInfo("Iaijutsu to Shoha", "Replace Iaijutsu with Shoha when meditation is 3.", SAM.JobID)]
    SamuraiIaijutsuShohaFeature = 3410,

    [CustomComboInfo("Senei to Guren Level Sync", "Replace Hissatsu: Senei with Guren when level synced below 72.", SAM.JobID)]
    SamuraiSeneiGurenFeature = 3418,

    [CustomComboInfo("Shinten to Senei", "Replace Hissatsu: Shinten with Senei when available.", SAM.JobID)]
    SamuraiShintenSeneiFeature = 3414,

    [CustomComboInfo("Shinten to Shoha", "Replace Hissatsu: Shinten with Shoha when Meditation is full.", SAM.JobID)]
    SamuraiShintenShohaFeature = 3413,

    [CustomComboInfo("Kyuten to Guren", "Replace Hissatsu: Kyuten with Guren when available.", SAM.JobID)]
    SamuraiKyutenGurenFeature = 3415,

    [CustomComboInfo("Kyuten to Shoha II", "Replace Hissatsu: Kyuten with Shoha II when Meditation is full.", SAM.JobID)]
    SamuraiKyutenShoha2Feature = 3412,

    [CustomComboInfo("Ikishoten Namikiri Feature", "Replace Ikishoten with Ogi Namikiri and then Kaeshi Namikiri when available.", SAM.JobID)]
    SamuraiIkishotenNamikiriFeature = 3411,

    [ParentCombo(SamuraiIkishotenNamikiriFeature)]
    [CustomComboInfo("Ikishoten Shoha Feature", "Replace Ikishoten with Shoha when Meditation is full.", SAM.JobID)]
    SamuraiIkishotenShohaFeature = 3419,

    #endregion
    // ====================================================================================
    #region SCHOLAR

    [CustomComboInfo("Seraph Fey Blessing/Consolation", "Replace Fey Blessing with Consolation when Seraph is out.", SCH.JobID)]
    ScholarSeraphConsolationFeature = 2801,

    [CustomComboInfo("Lustrate to Recitation", "Replace Lustrate with Recitation when Recitation is off cooldown.", SCH.JobID)]
    ScholarLustrateRecitationFeature = 2807,

    [CustomComboInfo("Lustrate to Excogitation", "Replace Lustrate with Excogitation when Excogitation is off cooldown.", SCH.JobID)]
    ScholarLustrateExcogitationFeature = 2808,

    [CustomComboInfo("Excogitation to Recitation", "Replace Excogitation with Recitation when Recitation is off cooldown.", SCH.JobID)]
    ScholarExcogitationRecitationFeature = 2806,

    [CustomComboInfo("Excogitation to Lustrate", "Replace Excogitation with Lustrate when Excogitation is on cooldown.", SCH.JobID)]
    ScholarExcogitationLustrateFeature = 2809,

    [CustomComboInfo("ED Aetherflow", "Replace Energy Drain with Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
    ScholarEnergyDrainAetherflowFeature = 2802,

    [CustomComboInfo("Lustrous Aetherflow", "Replace Lustrate with Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
    ScholarLustrateAetherflowFeature = 2803,

    [CustomComboInfo("Indomitable Aetherflow", "Replace Indomitability with Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
    ScholarIndomAetherflowFeature = 2804,

    [CustomComboInfo("Summon Seraph Feature", "Replace Summon Eos and Selene with Summon Seraph when a summon is out.", SCH.JobID)]
    ScholarSeraphFeature = 2805,

    #endregion
    // ====================================================================================
    #region SUMMONER

    [CustomComboInfo("ED Fester Feature", "Change Fester into Energy Drain when out of Aetherflow stacks.", SMN.JobID)]
    SummonerEDFesterFeature = 2701,

    [CustomComboInfo("ES Painflare Feature", "Change Painflare into Energy Syphon when out of Aetherflow stacks.", SMN.JobID)]
    SummonerESPainflareFeature = 2702,

    [CustomComboInfo("Ruin Feature", "Change Ruin into Gemburst when attuned.", SMN.JobID)]
    SummonerRuinFeature = 2703,

    [CustomComboInfo("Titan's Favor Ruin Feature", "Change Ruin into Mountain Buster (oGCD) when available.", SMN.JobID)]
    SummonerRuinTitansFavorFeature = 2713,

    [CustomComboInfo("Further Ruin Feature", "Change Ruin into Ruin4 when available and appropriate.", SMN.JobID)]
    SummonerFurtherRuinFeature = 2705,

    [CustomComboInfo("Outburst Feature", "Change Outburst into Precious Brilliance when attuned.", SMN.JobID)]
    SummonerOutburstFeature = 2704,

    [CustomComboInfo("Titan's Favor Outburst Feature", "Change Outburst into Mountain Buster (oGCD) when available.", SMN.JobID)]
    SummonerOutburstTitansFavorFeature = 2714,

    [CustomComboInfo("Further Outburst Feature", "Change Outburst into Ruin4 when available and appropriate.", SMN.JobID)]
    SummonerFurtherOutburstFeature = 2706,

    [CustomComboInfo("Shiny Titan's Favor Feature", "Change Gemshine and Precious Brilliance into Mountain Buster (oGCD) when available.", SMN.JobID)]
    SummonerShinyTitansFavorFeature = 2707,

    [CustomComboInfo("Further Shiny Feature", "Change Gemshine and Precious Brilliance into Ruin4 when available and appropriate.", SMN.JobID)]
    SummonerFurtherShinyFeature = 2708,

    [CustomComboInfo("Shiny Enkindle Feature", "Change Gemshine and Precious Brilliance to Enkindle when Bahamut or Phoenix are summoned.", SMN.JobID)]
    SummonerShinyEnkindleFeature = 2709,

    [CustomComboInfo("Demi Enkindle Feature", "Change Summon Bahamut and Summon Phoenix into Enkindle when Bahamut or Phoenix are summoned.", SMN.JobID)]
    SummonerDemiEnkindleFeature = 2710,

    [CustomComboInfo("Searing Demi Feature", "Change Summon Bahamut and Summon Phoenix into Searing Light when Bahamut is ready to be summoned, Searing Light is off cooldown, and you are in combat.", SMN.JobID)]
    SummonerDemiSearingLightFeature = 2715,

    [CustomComboInfo("Radiant Carbuncle Feature", "Change Radiant Aegis into Summon Carbuncle when no pet has been summoned.", SMN.JobID)]
    SummonerRadiantCarbuncleFeature = 2711,

    [CustomComboInfo("Searing Carbuncle Feature", "Change Searing Light into Summon Carbuncle when no pet has been summoned.", SMN.JobID)]
    SummonerSearingCarbuncleFeature = 2712,

    #endregion
    // ====================================================================================
    #region WARRIOR

    [CustomComboInfo("Storms Path Combo", "Replace Storms Path with its combo chain.", WAR.JobID)]
    WarriorStormsPathCombo = 2101,

    [ParentCombo(WarriorStormsPathCombo)]
    [CustomComboInfo("Storms Path Overcap Feature", "Replace Storms Path with Fell Cleave when the next combo action would cause the Beast Gauge to overcap.", WAR.JobID)]
    WarriorStormsPathOvercapFeature = 2104,

    [ParentCombo(WarriorStormsPathCombo)]
    [CustomComboInfo("Storms Path Inner Release Feature", "Replace Storms Path with Fell Cleave when Inner Release is active.", WAR.JobID)]
    WarriorStormsPathInnerReleaseFeature = 2110,

    [CustomComboInfo("Storms Eye Combo", "Replace Storms Eye with its combo chain.", WAR.JobID)]
    WarriorStormsEyeCombo = 2102,

    [CustomComboInfo("Mythril Tempest Combo", "Replace Mythril Tempest with its combo chain.", WAR.JobID)]
    WarriorMythrilTempestCombo = 2103,

    [CustomComboInfo("Mythril Tempest Target Option", "Replace Mythril Tempest only when you have a target.", WAR.JobID)]
    WarriorMythrilTempestTargetOption = 2113,

    [ParentCombo(WarriorMythrilTempestCombo)]
    [CustomComboInfo("Mythril Tempest Overcap Feature", "Replace Mythril Tempest with Decimate the next combo action would cause the Beast Gauge to overcap.", WAR.JobID)]
    WarriorMythrilTempestOvercapFeature = 2105,

    [ParentCombo(WarriorMythrilTempestCombo)]
    [CustomComboInfo("Mythril Tempest Inner Release Feature", "Replace Mythril Tempest with Decimate when Inner Release is active.", WAR.JobID)]
    WarriorMythrilTempestInnerReleaseFeature = 2111,

    [CustomComboInfo("Angry Beast Feature", "Replace Inner Beast and Steel Cyclone with Infuriate when less then 50 Beast Gauge is available.", WAR.JobID)]
    WarriorInfuriateBeastFeature = 2109,

    [CustomComboInfo("Nascent Flash Level Sync", "Replace Nascent Flash with Raw intuition when Synced.", WAR.JobID)]
    WarriorNascentFlashSyncFeature = 2106,

    [CustomComboInfo("Healthy Balanaced Diet Feature", "Replace Bloodwhetting with Thrill of Battle, and then Equilibrium when the preceding is on cooldown.", WAR.JobID)]
    WarriorHealthyBalancedDietFeature = 2112,

    [CustomComboInfo("Primal Beast Feature", "Replace Inner Beast and Steel Cyclone with Primal Rend when available", WAR.JobID)]
    WarriorPrimalBeastFeature = 2107,

    [CustomComboInfo("Primal Release Feature", "Replace Inner Release with Primal Rend when available", WAR.JobID)]
    WarriorPrimalReleaseFeature = 2108,

    #endregion
    // ====================================================================================
    #region WHITE MAGE

    [CustomComboInfo("Solace into Misery", "Replace Afflatus Solace with Afflatus Misery when Misery is ready to be used.", WHM.JobID)]
    WhiteMageSolaceMiseryFeature = 2401,

    [CustomComboInfo("Rapture into Misery", "Replace Afflatus Rapture with Afflatus Misery when Misery is ready to be used and you have a target.", WHM.JobID)]
    WhiteMageRaptureMiseryFeature = 2402,

    [CustomComboInfo("Holy into Misery", "Replace Holy/Holy 3 with Afflatus Misery when Misery is ready to be used and you have a target.", WHM.JobID)]
    WhiteMageHolyMiseryFeature = 2405,

    [CustomComboInfo("Cure 2 Level Sync", "Replace Cure 2 with Cure when below level 30 in synced content.", WHM.JobID)]
    WhiteMageCureFeature = 2403,

    [CustomComboInfo("Afflatus Feature", "Replace Cure 2 with Afflatus Solace and Medica with Afflatus Rapture, when lilies are up.", WHM.JobID)]
    WhiteMageAfflatusFeature = 2404,

    #endregion
    // ====================================================================================
    #region DOH

    // [CustomComboInfo("Placeholder", "Placeholder.", DOH.JobID)]
    // DohPlaceholder = 50001,

    #endregion
    // ====================================================================================
    #region DOL

    [CustomComboInfo("Eureka Feature", "Replace Ageless Words and Solid Reason with Wise to the World when available.", DOL.JobID)]
    DolEurekaFeature = 51001,

    [CustomComboInfo("Cast / Hook Feature", "Replace Cast with Hook when fishing.", DOL.JobID)]
    DolCastHookFeature = 51002,

    [CustomComboInfo("Cast / Gig Feature", "Replace Cast with Gig when underwater.", DOL.JobID)]
    DolCastGigFeature = 51003,

    [CustomComboInfo("Surface Slap / Veteran Trade Feature", "Replace Surface Slap with Veteran Trade when underwater.", DOL.JobID)]
    DolSurfaceTradeFeature = 51004,

    [CustomComboInfo("Prize Catch / Nature's Bounty Feature", "Replace Prize Catch with Nature's Bounty when underwater.", DOL.JobID)]
    DolPrizeBountyFeature = 51005,

    [CustomComboInfo("Snagging / Salvage Feature", "Replace Snagging with Salvage when underwater.", DOL.JobID)]
    DolSnaggingSalvageFeature = 51006,

    [CustomComboInfo("Cast Light / Electric Current Feature", "Replace Cast Light with Electric Current when underwater.", DOL.JobID)]
    DolCastLightElectricCurrentFeature = 51007,

    #endregion
    // ====================================================================================
}
