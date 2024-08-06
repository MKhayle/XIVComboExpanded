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

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", PCT.JobID)]
    PctAny = AdvAny + PCT.JobID,

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

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", VPR.JobID)]
    VprAny = AdvAny + VPR.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", WAR.JobID)]
    WarAny = AdvAny + WAR.JobID,

    [CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", WHM.JobID)]
    WhmAny = AdvAny + WHM.JobID,

    [CustomComboInfo("Disabled", "This should not be used.", ADV.JobID)]
    Disabled = 99999,

    #endregion
    // ====================================================================================
    #region ADV

    [CustomComboInfo("Swift Raise Feature", "Replace Ascend, Ressurection, Egeiro, Raise, Verraise, and Angel Whisper with Swiftcast when it is off cooldown (and Dualcast isn't up).", ADV.JobID)]
    AdvSwiftcastFeature = 1000,

    [ParentCombo(AdvSwiftcastFeature)]
    [ConflictingCombos(AdvVerRaiseToVerCureFeature)]
    [CustomComboInfo("Disable for VerRaise", "Doesn't apply this feature to RDM's VerRaise.", ADV.JobID)]
    AdvDisableVerRaiseFeature = 1002,

    [ParentCombo(AdvSwiftcastFeature)]
    [ConflictingCombos(AdvDisableVerRaiseFeature)]
    [CustomComboInfo("Replace VerRaise by Vercure instead", "Do those puny dead bodies really deserve you wasting 2 GCDs?", ADV.JobID)]
    AdvVerRaiseToVerCureFeature = 1003,

    [CustomComboInfo("Variant Raise Feature", "Replace Ascend, Ressurection, Egeiro, Raise, Verraise, and Angel Whisper with Variant Raise II when in a variant dungeon.", ADV.JobID)]
    AdvVariantRaiseFeature = 1001,

    [CustomComboInfo("Stance over Provoke", "Replace Provoke with Iron Will, Defiance, Grit or Royal Guard when it is off cooldown and your stance isn't up.", ADV.JobID)]
    AdvStanceProvokeFeature = 1004,

    [ParentCombo(AdvStanceProvokeFeature)]
    [CustomComboInfo("Stance Removal while on CD", "Replace Provoke by your Stance removal action when Provoke is on cooldown. Be careful with this option as you won't be able to track Provoke's cooldown.", ADV.JobID)]
    AdvStanceBackProvokeFeature = 1005,

    [CustomComboInfo("Stance Removal over Shirk", "Replace Shirk by your Stance removal action when it is on cooldown and your stance is up.", ADV.JobID)]
    AdvShirkStanceFeature = 1006,

    #endregion
    // ====================================================================================
    #region ASTROLOGIAN

    [CustomComboInfo("Malefic to Astral/Umbral Draw", "Replace Malefic with Astral/Umbral Draw when no card is drawn and you can draw.", AST.JobID)]
    AstrologianMaleficDrawFeature = 3320,

    [ParentCombo(AstrologianMaleficDrawFeature)]
    [CustomComboInfo("Play 1 override", "Replace Malefic with Astral/Umbral when Play I isn't drawn yet, even if there are remaining other cards.", AST.JobID)]
    AstrologianDraw1Feature = 3321,

    [CustomComboInfo("Gravity to Astral/Umbral Draw", "Replace Gravity with with Astral/Umbral Draw when no card is drawn and you can draw..", AST.JobID)]
    AstrologianGravityDrawFeature = 3322,

    [CustomComboInfo("Play to Astral/Umbral Draw", "Replace Play I / II / III & Minor Arcana with with Astral/Umbral Draw when no card is drawn and you can draw.", AST.JobID)]
    AstrologianPlayDrawFeature = 3323,

    [CustomComboInfo("Helios to Arcana", "Replace Helios by Lady of Crowns when drawn.", AST.JobID)]
    AstrologianHeliosArcanaFeature = 3324,

    [CustomComboInfo("Malefic/Gravity to Arcana", "Replace Malefic & Gravity by Lord of Crowns when drawn.", AST.JobID)]
    AstrologianMaleficArcanaFeature = 3325,

    [CustomComboInfo("Benefic II to Benefic Level Sync", "Replace Benefic 2 with Benefic when below level 26 in synced content.", AST.JobID)]
    AstrologianBeneficSyncFeature = 3326,

    [SecretCustomCombo]
    [CustomComboInfo("Auto Combust", "Replace Malefic with Combust when it is about to run out.", AST.JobID)]
    AstrologianDoTFeature = 3327,

    #endregion
    // ====================================================================================
    #region BLACK MAGE

    [CustomComboInfo("Enochian Feature", "Replace Fire 4 and Blizzard 4 with whichever action you can currently use.", BLM.JobID)]
    BlackEnochianFeature = 2501,

    [ParentCombo(BlackEnochianFeature)]
    [CustomComboInfo("Flare Star feature", "Replace Fire 4 and Blizzard 4 with Flare Star when you have 6 astral soul.", BLM.JobID)]
    BlackFlareStarFeature = 2523,

    [SecretCustomCombo]
    [ParentCombo(BlackEnochianFeature)]
    [CustomComboInfo("Enochian Despair Feature", "Replace Fire 4 and Blizzard 4 with Despair when in Astral Fire with less than 2400 mana.", BLM.JobID)]
    BlackEnochianDespairFeature = 2510,

    [SecretCustomCombo]
    [ParentCombo(BlackEnochianDespairFeature)]
    [CustomComboInfo("Enochian Despair into Flare Star Feature", "Replace Fire 4 and Blizzard 4 with Flare Star when you have 6 astral soul and 0 mana.", BLM.JobID)]
    BlackEnochianDespairFlareStarFeature = 2524,

    [SecretCustomCombo]
    [ParentCombo(BlackEnochianFeature)]
    [CustomComboInfo("Enochian Timer Feature", "Replace Fire 4 and Blizzard 4 with Fire 3 Proc, Paradox, Instant-Despair, or Blizzard 3 when Enochian is about to run out.", BLM.JobID)]
    BlackEnochianTimerFeature = 2525,

    [ParentCombo(BlackEnochianFeature)]
    [CustomComboInfo("Enochian No Sync Feature", "Fire 4 and Blizzard 4 will not sync to Fire 1 and Blizzard 1.", BLM.JobID)]
    BlackEnochianNoSyncFeature = 2518,

    [CustomComboInfo("Transpose into Umbral Soul", "Replace Transpose with Umbral Soul when Umbral Soul is usable.", BLM.JobID)]
    BlackTransposeUmbralSoulFeature = 2502,

    [CustomComboInfo("Umbral Soul into Transpose", "Replace Umbral Soul with Transpose when Umbral Soul is not usable.", BLM.JobID)]
    BlackUmbralSoulTransposeFeature = 2522,

    [CustomComboInfo("(Between the) Ley Lines", "Replace Ley Lines with BTL when Ley Lines is active.", BLM.JobID)]
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

    [CustomComboInfo("Fire 2 Feature", "(High) Fire 2 becomes Flare when in Astral Fire and is optimal.", BLM.JobID)]
    BlackFire2Feature = 2508,

    [CustomComboInfo("Ice 2 Feature", "(High) Blizzard 2 becomes Freeze in Umbral Ice.", BLM.JobID)]
    BlackBlizzard2Feature = 2509,

    [CustomComboInfo("Fire 2/Ice 2 Option", "Fire 2 and Blizzard 2 will not change unless you're at max Astral Fire or Umbral Ice.", BLM.JobID)]
    BlackFireBlizzard2Option = 2514,

    [CustomComboInfo("Umbral Soul Feature", "Replace your ice spells with Umbral Soul, while in Umbral Ice and having no target.", BLM.JobID)]
    BlackSpellsUmbralSoulFeature = 2517,

    [CustomComboInfo("Scathe/Xenoglossy Feature", "Scathe becomes Xenoglossy when available.", BLM.JobID)]
    BlackScatheFeature = 2507,

    #endregion
    // ====================================================================================
    #region BARD

    [CustomComboInfo("Heavy Shot into Straight Shot", "Replace Heavy Shot with Straight Shot/Refulgent Arrow when available.", BRD.JobID)]
    BardStraightShotUpgradeFeature = 2302,

    [CustomComboInfo("Iron Jaws Feature", "Replace Iron Jaws with Caustic Bite/Stormbite depending on which is not present on the target.", BRD.JobID)]
    BardIronJawsFeature = 2308,

    [SecretCustomCombo]
    [CustomComboInfo("Pre Iron Jaws Feature", "Replace Iron Jaws with Caustic Bite/Stormbite depending on the duration when Iron Jaws is not available.", BRD.JobID)]
    BardPreIronJawsFeature = 2303,

    [SecretCustomCombo]
    [CustomComboInfo("Heavy Shot Iron Jaws Feature", "Replace Heavy shot with Iron Jaws when Caustic Bite/Stormbite is about to run out on the target.", BRD.JobID)]
    BardShotIronJawsFeature = 2322,

    [CustomComboInfo("Burst Shot/Quick Nock into Apex Arrow", "Replace Burst Shot and Quick Nock with Apex Arrow when gauge is full.", BRD.JobID)]
    BardApexFeature = 2304,

    [CustomComboInfo("Quick Nock into Wide Volley/Shadowbite", "Replace Quick Nock with Wide Volley/Shadowbite when available.", BRD.JobID)]
    BardShadowbiteFeature = 2305,

    [ParentCombo(BardShadowbiteFeature)]
    [CustomComboInfo("A Wide Barrage of Shadowbites", "Replace Quick Nock with Barrage when off cooldown and Wide Volley/Shadowbite is available.", BRD.JobID)]
    BardShadowbiteBarrageFeature = 2321,

    [SecretCustomCombo]
    [CustomComboInfo("Perfect Bloodletter Feature", "Replace Bloodletter with Pitch Perfect when Repertoire charges are full.", BRD.JobID)]
    BardPerfectBloodletterFeature = 2315,

    [SecretCustomCombo]
    [CustomComboInfo("Expiring Perfect Bloodletter Feature", "Replace Bloodletter with Pitch Perfect when Wanderers Minuet has less than 2.5 seconds remaining and atleast one Repertoire charge.", BRD.JobID)]
    BardExpiringPerfectBloodletterFeature = 2316,

    [SecretCustomCombo]
    [ConflictingCombos(BardBloodRainFeature)]
    [CustomComboInfo("Bloodletter Feature", "Replace Bloodletter with Empyreal Arrow and Sidewinder depending on which is available.", BRD.JobID)]
    BardBloodletterFeature = 2306,

    [SecretCustomCombo]
    [CustomComboInfo("Rain of Death Feature", "Replace Rain of Death with Empyreal Arrow and Sidewinder depending on which is available.", BRD.JobID)]
    BardRainOfDeathFeature = 2307,

    [SecretCustomCombo]
    [CustomComboInfo("Perfect Rain of Death Feature", "Replace Rain of Death with Pitch Perfect when Repertoire charges are full.", BRD.JobID)]
    BardPerfectRainOfDeathFeature = 2318,

    [SecretCustomCombo]
    [CustomComboInfo("Expiring Perfect Rain of Death Feature", "Replace Rain of Death with Pitch Perfect when Wanderers Minuet has less than 2.5 seconds remaining and atleast one Repertoire charge.", BRD.JobID)]
    BardExpiringPerfectRainOfDeathFeature = 2319,

    [SecretCustomCombo]
    [CustomComboInfo("Empyreal Arrow Feature", "Replace Empyreal Arrow with Sidewinder depending on which is available.", BRD.JobID)]
    BardEmpyrealArrowFeature = 2320,

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

    [CustomComboInfo("Cycling Song Feature", "Replace Mage's Ballad with Wanderer's Minuet, Mage's Ballad, and Army's Paeon, while the previous is on cooldown.", BRD.JobID)]
    BardCyclingSongFeature = 2317,

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

    [SecretCustomCombo]
    [ConflictingCombos(DancerSingleTargetProcs)]
    [CustomComboInfo("Single Target Multibutton", "Replace Cascade with its procs and combos as they activate.", DNC.JobID)]
    DancerSingleTargetMultibutton = 3804,

    [SecretCustomCombo]
    [ConflictingCombos(DancerSingleTargetMultibutton)]
    [CustomComboInfo("Single Target to Procs", "Replace Cascade and Fountain with Reverse Cascade and Fountainfall respectively when available.", DNC.JobID)]
    DancerSingleTargetProcs = 3811,

    [SecretCustomCombo]
    [CustomComboInfo("Single Target Saber Dance", "Replace Cascade, Reverse Cascade, Fountain, and Fountainfall with Saber Dance when at >= 85 Esprit.", DNC.JobID)]
    DancerSingleTargetSabreDance = 3817,

    [SecretCustomCombo]
    [ParentCombo(DancerSingleTargetSabreDance)]
    [CustomComboInfo("Single Target Saber Dance Tech Step", "Use Saber Dance at >= 50 Esprit during Technical Step.", DNC.JobID)]
    DancerSingleTargetSabreDanceTech = 3818,

    [SecretCustomCombo]
    [CustomComboInfo("Single Target Dance of the Dawn", "Replace Cascade, Reverse Cascade, Fountain, and Fountainfall with Dance of the Dawn when available and >= 50 Esprit.", DNC.JobID)]
    DancerSingleTargetDanceOfTheDawn = 3819,

    [SecretCustomCombo]
    [CustomComboInfo("AoE Multibutton", "Replace Windmill with its procs and combos as they activate.", DNC.JobID)]
    DancerAoeMultibutton = 3805,

    [SecretCustomCombo]
    [CustomComboInfo("AoE to Procs", "Replace Windmill and Bladeshower with Rising Windmill and Bloodshower respectively when available.", DNC.JobID)]
    DancerAoeProcs = 3812,

    [SecretCustomCombo]
    [CustomComboInfo("AoE Saber Dance", "Replace Windmill, Rising Windmill, Bladeshower, and Bloodshower with Saber Dance when at >= 85 Esprit.", DNC.JobID)]
    DancerAoeSabreDance = 3820,

    [SecretCustomCombo]
    [ParentCombo(DancerAoeSabreDance)]
    [CustomComboInfo("AoE Saber Dance Tech Step", "Use Saber Dance at >= 50 Esprit during Technical Step.", DNC.JobID)]
    DancerAoeSabreDanceTech = 3821,

    [SecretCustomCombo]
    [CustomComboInfo("AoE Dance of the Dawn", "Replace Windmill, Rising Windmill, Bladeshower, and Bloodshower with Dance of the Dawn when available and >= 50 Esprit.", DNC.JobID)]
    DancerAoeDanceOfTheDawn = 3822,

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

    [CustomComboInfo("Partner Feature", "Replace Standard Step, Devilment, and Technical step by Closed Position if a partner is available, you are in a duty, and and you haven't partner'd yet.", DNC.JobID)]
    DancerPartnerFeature = 3815,

    [ParentCombo(DancerPartnerFeature)]
    [CustomComboInfo("Chocobo Partner Feature", "Also applies if you are out of duty and that your Chocobo is summoned.", DNC.JobID)]
    DancerChocoboPartnerFeature = 3816,

    [CustomComboInfo("Last Dance Feature", "Replace Standard Step by Last Dance if available.", DNC.JobID)]
    DancerLastDanceFeature = 3813,

    [ParentCombo(DancerLastDanceFeature)]
    [CustomComboInfo("Finishing Move Priority", "Priorize Finishing Move over Last Dance when replacing Standard Step.", DNC.JobID)]
    DancerFinishingMovePriorityFeature = 3814,

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

    [CustomComboInfo("Delirium Feature", "Replace Souleater and Stalwart Soul with Bloodspiller & its combo chain and Quietus/Impalement when Delirium is active.", DRK.JobID)]
    DarkDeliriumFeature = 3203,

    [CustomComboInfo("Blood Weapon Feature", "Replace Carve and Spit, and Abyssal Drain with Blood Weapon/Delirium when available.", DRK.JobID)]
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

    [CustomComboInfo("Full Thrust Combo", "Replace Full Thrust with its combo chain.", DRG.JobID)]
    DragoonFullThrustCombo = 2204,

    [ParentCombo(DragoonFullThrustCombo)]
    [CustomComboInfo("Vorpal Thrust Option", "Replace Full Thrust with its combo chain starting instead at Vorpal Thrust, not True Thrust, while no combo is ongoing.", DRG.JobID)]
    DragoonFullThrustComboOption = 2210,

    [ParentCombo(DragoonFullThrustCombo)]
    [CustomComboInfo("Double Chaos Thrust Option", "Replicates the Full Thrust combo while not in the Chaotic Thrust combo.", DRG.JobID)]
    DragoonDoubleFullThrustComboOption = 2215,

    [CustomComboInfo("Chaos Thrust Combo", "Replace Chaos Thrust with its combo chain.", DRG.JobID)]
    DragoonChaosThrustCombo = 2203,

    [ParentCombo(DragoonChaosThrustCombo)]
    [CustomComboInfo("Chaos Thrust Disembowel Option", "Replace Chaos Thrust with its combo chain starting instead at Disembowel, not True Thrust, while no combo is ongoing.", DRG.JobID)]
    DragoonChaosThrustComboOption = 2209,

    [ParentCombo(DragoonChaosThrustCombo)]
    [CustomComboInfo("Double Full Thrust Option", "Replicates the Chaotic Thrust combo while not in the Full Thrust combo.", DRG.JobID)]
    DragoonDoubleChaosComboOption = 2214,

    [CustomComboInfo("Coerthan Torment Combo", "Replace Coerthan Torment with its combo chain.", DRG.JobID)]
    DragoonCoerthanTormentCombo = 2202,

    [CustomComboInfo("Coerthan Torment Wyrmwind Feature", "Replace Coerthan Torment with Wyrmwind Thrust when you have two Firstminds' Focus.", DRG.JobID)]
    DragoonCoerthanWyrmwindFeature = 2207,

    [ConflictingCombos(DragoonStardiverDragonfireDiveFeature)]
    [CustomComboInfo("Stardiver to Nastrond", "Replace Stardiver with Nastrond when Nastrond is off-cooldown, and Geirskogul outside of Life of the Dragon.", DRG.JobID)]
    DragoonStardiverNastrondFeature = 2206,

    [ConflictingCombos(DragoonStardiverNastrondFeature)]
    [CustomComboInfo("Stardiver to Dragonfire Dive", "Replace Stardiver with Dragonfire Dive when the latter is off cooldown (and you have more than 7.5s of LotD left), or outside of Life of the Dragon.", DRG.JobID)]
    DragoonStardiverDragonfireDiveFeature = 2208,

    [CustomComboInfo("Geirskogul to Wyrmwind Thrust", "Replace Geirskogul with Wyrmwind Thrust when available and Geirskogul or Nastrond are on cooldown.", DRG.JobID)]
    DragoonGeirskogulWyrmwindFeature = 2212,

    [CustomComboInfo("Lance Charge to Battle Litany", "Replace Lance Charge Battle Litany when available and Lance Charge is on cooldown.", DRG.JobID)]
    DragoonLanceChargeFeature = 2213,

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

    [CustomComboInfo("Fated Circle Continuation", "Replace Fated Circle with Continuation moves when appropriate.", GNB.JobID)]
    GunbreakerFatedCircleCont = 3714,

    // [SecretCustomCombo]
    // [CustomComboInfo("Sonic Shock Feature", "Replace Bow Shock and Sonic Break with one or the other depending on which is on cooldown.", GNB.JobID)]
    // GunbreakerBowShockSonicBreakFeature = 3704,

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

    [SecretCustomCombo]
    [CustomComboInfo("Expanded Continuation Feature", "Replace Continuation with several abilities, giving a continuation-like followup to several abilities.\nCombo Danger Zone after Keen Edge or Brutal Shell\nCombo Sonic Break after No Mercy\nFollow up Solid Barrel with Double Down, Gnashing Fang combo, or Burst Strike\nFollow up Demon Slaughter with Double Down or Fated Circle\nFollow up Bloodfest with the Reign combo", GNB.JobID)]
    GunbreakerExpandedContinuation = 3715,

    [CustomComboInfo("Trajectory downgrade when level capped", "Replaces Trajectory with Lightning Shot when below level for it.", GNB.JobID)]
    GunbreakerTrajectoryDowngradeFeature = 3716,

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

    [SecretCustomCombo]
    [ConflictingCombos([MonkOpoFeature, MonkRaptorFeature, MonkCoeurlFeature])]
    [CustomComboInfo("monke mode", "One-buttons the basic rotation on Bootshine/Leaping Opo. Neat for beginners, very, very bad for serious players.", MNK.JobID)]
    MonkMonkeyMode = 2021,

    [SecretCustomCombo]
    [ParentCombo(MonkMonkeyMode)]
    [CustomComboInfo("Monkey Bootshine Steeled Meditation Feature", "Replace Bootshine/Leaping Opo with Steeled Meditation when out of combat and the Fifth Chakra is not open.", MNK.JobID)]
    MonkMonkeyMeditationFeature = 2022,

    [SecretCustomCombo]
    [ParentCombo(MonkMonkeyMode)]
    [CustomComboInfo("Monkey Form Shift Feature", "Replace Bootshine/Leaping Opo with Form Shift when out of combat and you don't have Formless Fist.", MNK.JobID)]
    MonkMonkeyFormShiftFeature = 2024,

    [SecretCustomCombo]
    [ParentCombo(MonkMonkeyMode)]
    [CustomComboInfo("Automatic Chakra Feature", "Replace Bootshine/Leaping Opo with The Forbidden Chakra when your Fifth Chakra is open.", MNK.JobID)]
    MonkMonkeyAutoChakraFeature = 2026,

    [ConflictingCombos(MonkMonkeyMode)]
    [CustomComboInfo("Opo feature", "Replace Bootshine/Leaping Opo with Dragon Kick if you don't have any Opo's fury stack.", MNK.JobID)]
    MonkOpoFeature = 2017,

    [ParentCombo(MonkOpoFeature)]
    [CustomComboInfo("Bootshine Steeled Meditation Feature", "Replace Bootshine/Leaping Opo with Steeled Meditation when out of combat and the Fifth Chakra is not open.", MNK.JobID)]
    MonkBootshineMeditationFeature = 2012,

    [ParentCombo(MonkOpoFeature)]
    [CustomComboInfo("Form Shift Feature", "Replace Bootshine/Leaping Opo with Form Shift when out of combat and you don't have Formless Fist.", MNK.JobID)]
    MonkBootshineFormShiftFeature = 2023,

    [SecretCustomCombo]
    [ParentCombo(MonkOpoFeature)]
    [CustomComboInfo("Opomatic Chakra Feature", "Replace Bootshine/Leaping Opo with The Forbidden Chakra when your Fifth Chakra is open.", MNK.JobID)]
    MonkOpoChakraFeature = 2029,

    [ConflictingCombos(MonkMonkeyMode)]
    [CustomComboInfo("Raptor feature", "Replace True Strike with Twin Snakes if you don't have any Raptor's fury stack.", MNK.JobID)]
    MonkRaptorFeature = 2018,

    [ConflictingCombos(MonkMonkeyMode)]
    [CustomComboInfo("Coeurl feature", "Replace Snap Punch with Demolish if you don't have any Coeurl's fury stack.", MNK.JobID)]
    MonkCoeurlFeature = 2019,

    [CustomComboInfo("ST Balance Feature", "Replace Bootshine/Leaping Opo, Dragon Kick, True Strike/Rising Raptor, Twin Snakes, Snap Punch/Pouncing Coeurl and Demolish with Masterful Blitz if you have 3 Beast Chakra.", MNK.JobID)]
    MonkSTBalanceFeature = 2005,

    [CustomComboInfo("Monk AoE Combo", "Replace Masterful Blitz with the AoE combo chain. This was changed from Rockbreaker due to an action queueing bug.", MNK.JobID)]
    MonkAoECombo = 2001,

    [ParentCombo(MonkAoECombo)]
    [CustomComboInfo("Enlightened Meditation Feature", "Replace Masterful Blitz with Enlightened Meditation when out of combat and the Fifth Chakra is not open.", MNK.JobID)]
    MonkAoEMeditationFeature = 2025,

    [ParentCombo(MonkAoECombo)]
    [CustomComboInfo("AoE Form Shift Feature", "Replace Masterful Blitz with Form Shift when out of combat and you don't have Formless Fist.", MNK.JobID)]
    MonkAoEFormShiftFeature = 2027,

    [SecretCustomCombo]
    [ParentCombo(MonkAoECombo)]
    [CustomComboInfo("Automatic AoE Chakra Feature", "Replace Masterful Blitz with Enlightenment when your Fifth Chakra is open.", MNK.JobID)]
    MonkAoEAutoChakraFeature = 2028,

    [CustomComboInfo("Perfect Balance Feature", "Replace Perfect Balance with Masterful Blitz when you have 3 Beast Chakra.", MNK.JobID)]
    MonkPerfectBalanceFeature = 2004,

    [CustomComboInfo("Riddle of Brotherly Fire", "Replace Riddle of Fire with Brotherhood when on cooldown.", MNK.JobID)]
    MonkRiddleOfFireBrotherhood = 2009,

    [CustomComboInfo("Riddle of Fire and Wind", "Replace Riddle of Fire with Riddle of Wind when on cooldown.", MNK.JobID)]
    MonkRiddleOfFireWind = 2010,

    #endregion
    // ====================================================================================
    #region NINJA

    //[ConflictingCombos(NinjaKazematoiFeature)]
    [CustomComboInfo("Aeolian Edge Combo", "Replace Aeolian Edge with its combo chain.", NIN.JobID)]
    NinjaAeolianEdgeCombo = 3002,

    //[ConflictingCombos(NinjaKazematoiFeature)]
    [CustomComboInfo("Armor Crush Combo", "Replace Armor Crush with its combo chain.", NIN.JobID)]
    NinjaArmorCrushCombo = 3001,

    //[SecretCustomCombo]
    //[ConflictingCombos([NinjaAeolianEdgeCombo, NinjaArmorCrushCombo])]
    //[CustomComboInfo("Auto-Refill Kazematoi / Huton Feature", "Replaces Aeolian Edge with Armor Crush when you don't have any Kazematoi left or with its combo chain else.", NIN.JobID)]
    //NinjaKazematoiFeature = 3019,

    [CustomComboInfo("Aeolian Edge / Ninjutsu Feature", "Replace Aeolian Edge with Ninjutsu if any Mudra are used.", NIN.JobID)]
    NinjaAeolianNinjutsuFeature = 3008,

    [CustomComboInfo("Aeolian Edge / Raiju Feature", "Replace the Aeolian Edge combo with Fleeting Raiju when available.", NIN.JobID)]
    NinjaAeolianEdgeRaijuFeature = 3013,

    [CustomComboInfo("Armor Crush / Ninjutsu Feature", "Replace Armor Crush with Ninjutsu if any Mudra are used.", NIN.JobID)]
    NinjaArmorCrushNinjutsuFeature = 3015,

    [CustomComboInfo("Armor Crush / Raiju Feature", "Replace the Armor Crush combo with Forked Raiju when available.", NIN.JobID)]
    NinjaArmorCrushRaijuFeature = 3012,

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

    [CustomComboInfo("Hide to Mug/Dokumori", "Replace Hide with Mug/Dokumori while in combat or hidden.", NIN.JobID)]
    NinjaHideMugFeature = 3007,

    [CustomComboInfo("Hide to Ninjutsu", "Replace Hide with Ninjutsu if any Mudra are active. Takes precedence over Hide to Mug/Dokumori.", NIN.JobID)]
    NinjaHideNinjutsuFeature = 3020,

    #endregion
    // ====================================================================================
    #region PALADIN

    [CustomComboInfo("Royal Authority Combo", "Replace Royal Authority with its combo chain.", PLD.JobID)]
    PaladinRoyalAuthorityCombo = 1902,

    [ParentCombo(PaladinRoyalAuthorityCombo)]
    [CustomComboInfo("Royal Authority Divine Might Feature", "Replace Royal Authority with Holy Spirit when Divine Might would overcap.", PLD.JobID)]
    PaladinRoyalAuthorityDivineMightFeature = 1912,

    [ParentCombo(PaladinRoyalAuthorityCombo)]
    [CustomComboInfo("Royal Authority Fight or Flight Feature", "Replace Royal Authority with Holy Spirit during Fight or Flight when Divine Might is active.", PLD.JobID)]
    PaladinRoyalAuthorityFightOrFlightFeature = 1915,

    [ParentCombo(PaladinRoyalAuthorityCombo)]
    [CustomComboInfo("Royal Authority Atonement Feature", "Replace Royal Authority with Atonement, Supplication & Sepulchre when under the effect of the corresponding buffs.", PLD.JobID)]
    PaladinRoyalAuthorityAtonementComboFeature = 1903,

    [ParentCombo(PaladinRoyalAuthorityCombo)]
    [CustomComboInfo("Royal Authority Confiteor Feature", "Replace Royal Authority with Confiteor and its combo chain when under the effect of Requiescat.", PLD.JobID)]
    PaladinRoyalAuthorityConfiteorComboFeature = 1917,

    [ParentCombo(PaladinRoyalAuthorityCombo)]
    [CustomComboInfo("Royal Authority Goring Blade Feature", "Replace Royal Authority with Goring Blade when available.", PLD.JobID)]
    PaladinRoyalAuthorityGoringBladeComboFeature = 1918,

    [ConflictingCombos(PaladinRoyalAuthorityAtonementComboFeature)]
    [CustomComboInfo("Atonement Follow-up", "Replace Royal Authority by Atonement and its combo chain when under the effect of Atonement Ready.", PLD.JobID)]
    PaladinAtonementCombo = 1921,

    [CustomComboInfo("Prominence Combo", "Replace Prominence with its combo chain.", PLD.JobID)]
    PaladinProminenceCombo = 1904,

    [ParentCombo(PaladinProminenceCombo)]
    [CustomComboInfo("Prominence Divine Might Feature", "Replace Prominence with Holy Circle when Divine Might is active.", PLD.JobID)]
    PaladinProminenceDivineMightFeature = 1913,

    [ParentCombo(PaladinProminenceCombo)]
    [CustomComboInfo("Prominence Confiteor Feature", "Replace Prominence with Confiteor and its combo chain when under the effect of Requiescat.", PLD.JobID)]
    PaladinProminenceConfiteorComboFeature = 1919,

    [ParentCombo(PaladinProminenceCombo)]
    [CustomComboInfo("Prominence Goring Blade Feature", "Replace Prominence with Goring Blade when available.", PLD.JobID)]
    PaladinProminenceGoringBladeComboFeature = 1920,

    [CustomComboInfo("Requiescat Fight or Flight Feature", "Replace Requiescat with Fight or Flight when off cooldown or if it will be ready sooner.", PLD.JobID)]
    PaladinRequiescatFightOrFlightFeature = 1914,

    [CustomComboInfo("Requiescat Confiteor", "Replace Requiescat with Confiteor and combo chain while under the effect of Requiescat, and then with Holy Spirit if there are remaining charges.", PLD.JobID)]
    PaladinRequiescatCombo = 1905,

    [CustomComboInfo("Confiteor Feature", "Replace Holy Spirit/Circle with Confiteor while under the effect of Requiescat.", PLD.JobID)]
    PaladinConfiteorFeature = 1907,

    [CustomComboInfo("Holy Spirit Level Sync", "Replace Holy Spirit with Shield Lob when below level 64 in synced content.", PLD.JobID)]
    PaladinHolySpiritLevelSyncFeature = 1916,

    [SecretCustomCombo]
    [CustomComboInfo("Scornful Spirits Feature", "Replace Spirits Within/Expiacion and Circle of Scorn with whichever is available soonest.", PLD.JobID)]
    PaladinScornfulSpiritsFeature = 1908,

    [CustomComboInfo("Shields on your Feet Feature", "Replace Shield Bash with Low Blow when available.", PLD.JobID)]
    PaladinShieldBashFeature = 1910,

    #endregion
    // ====================================================================================
    #region PICTOMANCER

    [CustomComboInfo("Subtractive Single-Target Combo", "Replace Blizzard in Cyan and its combo chain with Fire in Red and its combo chain when Subtractive Palette is not active.", PCT.JobID)]
    PictomancerSubtractiveSTCombo = 4201,

    [CustomComboInfo("Subtractive AoE Combo", "Replace Blizzard II in Cyan and its combo chain with Fire II in Red and its combo chain when Subtractive Palette is not active.", PCT.JobID)]
    PictomancerSubtractiveAoECombo = 4202,

    [CustomComboInfo("Don't overcap Subtractive", "Replace Fire in Red and Fire II in Red, and their combo chains, with Subtractive Palette if the next cast in the chain would overcap the Palette Gauge.", PCT.JobID)]
    PictomancerSubtractiveAutoCombo = 4205,

    [SecretCustomCombo]
    [ParentCombo(PictomancerSubtractiveAutoCombo)]
    [CustomComboInfo("Subtractive Early Autocast", "Do it as soon as you reach 50 Palette gauge or you are under the effect of Substractive Palette Ready instead.", PCT.JobID)]
    PictomancerSubtractiveEarlyAutoCombo = 4221,

    [SecretCustomCombo]
    [CustomComboInfo("Holy Autocast", "Replace Fire in Red, Fire II in Red, Blizzard in Cyan, Blizzard II in Cyan, and their combo chains, with Holy or Comet if the next cast would overcap the Paint Gauge.", PCT.JobID)]
    PictomancerHolyAutoCombo = 4204,

    [SecretCustomCombo]
    [CustomComboInfo("Rainbow Autocast", "Replace Fire in Red, Fire II in Red, Blizzard in Cyan, Blizzard II in Cyan, and their combo chains, with Rainbow Drip when you have Rainbow Drip Ready.", PCT.JobID)]
    PictomancerRainbowAutoCombo = 4213,

    [SecretCustomCombo]
    [CustomComboInfo("Star Prism Autocast", "Replace Fire in Red, Fire II in Red, Blizzard in Cyan, Blizzard II in Cyan, and their combo chains, with Star Prism when you have Star Prism Ready.", PCT.JobID)]
    PictomancerStarPrismAutoCombo = 4214,

    [SecretCustomCombo]
    [CustomComboInfo("Mog of the Ages Autocast", "Replace Fire in Red, Fire II in Red, Blizzard in Cyan, Blizzard II in Cyan, and their combo chains, with Mog of the Ages and Retribution of the Madeen when they are usable.", PCT.JobID)]
    PictomancerAutoMogCombo = 4220,

    [CustomComboInfo("Creature Muse/Motif Combo", "Replace Creature Motifs with Creature Muses when the Creature Canvas is painted.", PCT.JobID)]
    PictomancerCreatureMotifCombo = 4206,

    [CustomComboInfo("Creature Muse/Mog of the Ages Combo", "Also replace Creature Motifs with Mog of the Ages and Retribution of the Madeen when they are usable.", PCT.JobID)]
    PictomancerCreatureMogCombo = 4207,

    [CustomComboInfo("Weapon Muse/Motif Combo", "Replace Hammer Motif with Striking Muse when the Weapon Canvas is painted.", PCT.JobID)]
    PictomancerWeaponMotifCombo = 4208,

    [CustomComboInfo("Hammer Time", "Replace Hammer Motif with Hammer Brush and its combo chain when they are usable.", PCT.JobID)]
    PictomancerWeaponHammerCombo = 4209,

    [CustomComboInfo("Landscape Muse/Motif Combo", "Replace Starry Sky Motif with Starry Muse when the Landscape Canvas is painted.", PCT.JobID)]
    PictomancerLandscapeMotifCombo = 4210,

    [CustomComboInfo("Landscape Muse/Star Prism Combo", "Replace Starry Muse with Star Prism when it is usable.", PCT.JobID)]
    PictomancerLandscapePrismCombo = 4211,

    [CustomComboInfo("Holy Comet Combo", "Replace Holy in White with Comet in Black when usable.", PCT.JobID)]
    PictomancerHolyCometCombo = 4203,

    [ParentCombo(PictomancerHolyCometCombo)]
    [CustomComboInfo("Rainbow Holy Combo", "Replace Holy in White with Rainbow Drip when under the effect of Rainbow Drip Ready (has priority over Comet in Black).", PCT.JobID)]
    PictomancerRainbowHolyCombo = 4215,

    [CustomComboInfo("Rainbow Drip Starter", "Replace Fire in Red & Fire in Red II with Rainbow Drip when out of combat.", PCT.JobID)]
    PictomancerRainbowStarter = 4216,

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

    [SecretCustomCombo]
    [ParentCombo(ReaperSliceLemuresFeature)]
    [CustomComboInfo("Slice Sacrificium Feature", "Replace Infernal Slice with with Sacrificium after 3 reapings.", RPR.JobID)]
    ReaperSliceSacrificiumFeature = 3946,

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

    [CustomComboInfo("Scythe Lemure's Feature", "Replace Nightmare Scythe with Lemure's Scythe when two or more stacks of Void Shroud are active.", RPR.JobID)]
    ReaperScytheLemuresFeature = 3921,

    [SecretCustomCombo]
    [ParentCombo(ReaperScytheLemuresFeature)]
    [CustomComboInfo("Scythe Sacrificium Feature", "Replace Nightmare Scythe with with Sacrificium after 3 reapings.", RPR.JobID)]
    ReaperScytheSacrificiumFeature = 3945,

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

    [CustomComboInfo("Lemure's Sacrificium Feature", "Replace Lemure's Slice/Scythe with Sacrificium when available and you have fewer than 2 Void Shroud.", RPR.JobID)]
    ReaperLemuresSacrificiumFeature = 3940,

    [ParentCombo(ReaperLemuresSacrificiumFeature)]
    [CustomComboInfo("Prioritize Sacrificium over Lemure's", "Replace Lemure's Slice/Scythe with Sacrificium even when you have 2 Void Shroud.", RPR.JobID)]
    ReaperLemuresSacrificiumPriorityFeature = 3941,

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

    [CustomComboInfo("Slice Perfectio Feature", "Replace Infernal Slice with Perfectio under Perfectio Parata.", RPR.JobID)]
    ReaperSlicePerfectioFeature = 3942,

    [CustomComboInfo("Scythe Perfectio Feature", "Replace Nightmare Scythe with with Perfectio under Perfectio Parata.", RPR.JobID)]
    ReaperScythePerfectioFeature = 3943,

    [CustomComboInfo("Harpe Perfectio Feature", "Replace Harpe with with Perfectio under Perfectio Parata.", RPR.JobID)]
    ReaperHarpePerfectioFeature = 3944,

    #endregion
    // ====================================================================================
    #region RED MAGE

    [CustomComboInfo("Verstone/Verfire Feature", "Replace Verstone/Verfire with Jolt when no proc is available.", RDM.JobID)]
    RedMageVerprocFeature = 3504,

    [ParentCombo(RedMageVerprocFeature)]
    [CustomComboInfo("Deprioritize Grand Impact", "After using Acceleration, prioritize using Verstone/Verfire over Grand Impact if both buffs are active.", RDM.JobID)]
    RedMageVerprocGrandImpactDeprioritize = 3519,

    [CustomComboInfo("Verstone/Verfire Plus Feature", "Replace Verstone/Verfire with Veraero/Verthunder when various instant-cast effects are active.", RDM.JobID)]
    RedMageVerprocPlusFeature = 3505,

    [ParentCombo(RedMageVerprocPlusFeature)]
    [CustomComboInfo("Deprioritize Grand Impact Plus", "After using Acceleration, prioritize using Veraero/Verthunder over Grand Impact if both buffs are active.", RDM.JobID)]
    RedMageGrandImpactDeprioritize = 3517,

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

    [CustomComboInfo("Melee Capstone Combo", "Replace Redoublement and Moulinet with Scorch, Resolution and Prefulgence when available.", RDM.JobID)]
    RedMageMeleeCapstoneCombo = 3503,

    [CustomComboInfo("Acceleration into Grand Impact", "Replace Acceleration with Grand Impact when available.", RDM.JobID)]
    RedMageAccelerationGrandImpactFeature = 3518,

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

    [CustomComboInfo("Dosis Kardia Feature", "Replace Dosis with Kardia when missing Kardion.", SGE.JobID)]
    SageDosisKardiaFeature = 4010,

    [CustomComboInfo("Druochole into Rhizomata Feature", "Replace Druochole with Rhizomata when Addersgall is empty.", SGE.JobID)]
    SageDruocholeRhizomataFeature = 4003,

    [CustomComboInfo("Druochole into Taurochole Feature", "Replace Druochole with Taurochole when off cooldown.\nWarning: This will limit your abiility to use Druochole.", SGE.JobID)]
    SageDruocholeTaurocholeFeature = 4009,

    [CustomComboInfo("Ixochole into Rhizomata Feature", "Replace Ixochole with Rhizomata when Addersgall is empty.", SGE.JobID)]
    SageIxocholeRhizomataFeature = 4004,

    [CustomComboInfo("Kerachole into Rhizomata Feature", "Replace Kerachole with Rhizomata when Addersgall is empty.", SGE.JobID)]
    SageKeracholaRhizomataFeature = 4005,

    [CustomComboInfo("Phlegma into Dyskrasia", "Replace Phlegma with Dyskrasia when no charges remain or have no target.", SGE.JobID)]
    SagePhlegmaDyskrasia = 4008,

    [CustomComboInfo("Phlegma into Toxikon", "Replace Phlegma with Toxikon when no charges rmemain and have Addersting.\nThis takes priority over Phlegma into Dyskrasia.", SGE.JobID)]
    SagePhlegmaToxicon = 4007,

    [CustomComboInfo("Soteria Kardia Feature", "Replace Soteria with Kardia when off cooldown and missing Kardion.", SGE.JobID)]
    SageSoteriaKardionFeature = 4006,

    [CustomComboInfo("Taurochole into Druochole Feature", "Replace Taurochole with Druochole when on cooldown", SGE.JobID)]
    SageTaurocholeDruocholeFeature = 4001,

    [CustomComboInfo("Taurochole into Rhizomata Feature", "Replace Taurochole with Rhizomata when Addersgall is empty.", SGE.JobID)]
    SageTaurocholeRhizomataFeature = 4002,

    [CustomComboInfo("Toxikon into Phlegma Feature", "Replace Toxikon with Phlegma when charges are available.", SGE.JobID)]
    SageToxikonPhlegma = 4011,

    [SecretCustomCombo]
    [CustomComboInfo("Auto Eukrasian Dosis", "Replace Dosis with Eukrasia when Eukrasian Dosis is about to run out.", SGE.JobID)]
    SageDoTFeature = 4012,

    [ParentCombo(SageToxikonPhlegma)]
    [CustomComboInfo("Psyche Combo", "Adds Psyche to Toxikon - Phlegma combo.", SGE.JobID)]
    SageToxikonPhlegmaFeature = 4013,

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

    [CustomComboInfo("Shinten to Zanshin", "Replace Hissatsu: Shinten with Zanshin when available.", SAM.JobID)]
    SamuraiShintenZanshinFeature = 3420,

    [CustomComboInfo("Shinten to Shoha", "Replace Hissatsu: Shinten with Shoha when Meditation is full.", SAM.JobID)]
    SamuraiShintenShohaFeature = 3413,

    [CustomComboInfo("Shinten to Senei", "Replace Hissatsu: Shinten with Senei when available.", SAM.JobID)]
    SamuraiShintenSeneiFeature = 3414,

    [CustomComboInfo("Senei to Guren Level Sync", "Replace Hissatsu: Senei with Guren when level synced below 72.", SAM.JobID)]
    SamuraiSeneiGurenFeature = 3418,

    [CustomComboInfo("Kyuten to Zanshin", "Replace Hissatsu: Kyuten with Zanshin when available.", SAM.JobID)]
    SamuraiKyutenZanshinFeature = 3421,

    [CustomComboInfo("Kyuten to Shoha", "Replace Hissatsu: Kyuten with Shoha when Meditation is full.", SAM.JobID)]
    SamuraiKyutenShohaFeature = 3412,

    [CustomComboInfo("Kyuten to Guren", "Replace Hissatsu: Kyuten with Guren when available.", SAM.JobID)]
    SamuraiKyutenGurenFeature = 3415,

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

    [CustomComboInfo("Sacred Soil Aetherflow", "Replace Sacred Soil with Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
    ScholarSacredSoilAetherflowFeature = 2811,

    [CustomComboInfo("Summon Seraph Feature", "Replace Summon Eos and Selene with Summon Seraph when a summon is out.", SCH.JobID)]
    ScholarSeraphFeature = 2805,

    [CustomComboInfo("Seraphism Feature", "Replace Seraphism with Emergency Tactics as long as you are under its effect.", SCH.JobID)]
    ScholarSeraphismFeature = 2812,

    [CustomComboInfo("Adloquium Level Sync", "Replace Adloquium with Physick when below level 30 in synced content.", SCH.JobID)]
    ScholarAdloquiumSyncFeature = 2810,

    [SecretCustomCombo]
    [CustomComboInfo("Auto Biolysis", "Replace Broil with Biolysis when it is about to run out.", SCH.JobID)]
    ScholarDoTFeature = 2813,

    #endregion
    // ====================================================================================
    #region SUMMONER

    [CustomComboInfo("Ruin Feature", "Change Ruin into Gemburst when attuned.", SMN.JobID)]
    SummonerRuinFeature = 2703,

    [CustomComboInfo("Outburst Feature", "Change Outburst into Precious Brilliance when attuned.", SMN.JobID)]
    SummonerOutburstFeature = 2704,

    [CustomComboInfo("Titan's Favor Ruin Feature", "Change Ruin into Mountain Buster (oGCD) when available.", SMN.JobID)]
    SummonerRuinTitansFavorFeature = 2713,

    [CustomComboInfo("Titan's Favor Outburst Feature", "Change Outburst into Mountain Buster (oGCD) when available.", SMN.JobID)]
    SummonerOutburstTitansFavorFeature = 2714,

    [CustomComboInfo("Gems Titan's Favor Feature", "Change Gemshine and Precious Brilliance into Mountain Buster (oGCD) when available.", SMN.JobID)]
    SummonerShinyTitansFavorFeature = 2707,

    [CustomComboInfo("Ruin 4 to Ruin Feature", "Change Ruin into Ruin4 when available and appropriate.", SMN.JobID)]
    SummonerFurtherRuinFeature = 2705,

    [CustomComboInfo("Ruin 4 to Outburst Feature", "Change Outburst into Ruin4 when available and appropriate.", SMN.JobID)]
    SummonerFurtherOutburstFeature = 2706,

    [CustomComboInfo("Gems Ruin 4 Feature", "Change Gemshine and Precious Brilliance into Ruin 4 when available and appropriate.", SMN.JobID)]
    SummonerFurtherShinyFeature = 2708,

    [CustomComboInfo("Gems Enkindle Feature", "Change Gemshine and Precious Brilliance to Enkindle when Bahamut, Phoenix or Summon Solar Bahamut are summoned.", SMN.JobID)]
    SummonerShinyEnkindleFeature = 2709,

    [CustomComboInfo("Demi Enkindle Feature", "Change Summon Bahamut and Summon Phoenix and Summon Solar Bahamut into Enkindle when Bahamut or Phoenix are summoned.", SMN.JobID)]
    SummonerDemiEnkindleFeature = 2710,

    [CustomComboInfo("Searing Demi Feature", "Change Summon Bahamut, Summon Phoenix and Summon Solar Bahamut into Searing Light when any of them is ready to be summoned, Searing Light is off cooldown, and you are in combat.", SMN.JobID)]
    SummonerDemiSearingLightFeature = 2715,

    [CustomComboInfo("ED Fester/Necrosis Feature", "Change Fester/Necrosis into Energy Drain when out of Aetherflow stacks.", SMN.JobID)]
    SummonerEDFesterFeature = 2701,

    [CustomComboInfo("ES Painflare Feature", "Change Painflare into Energy Syphon when out of Aetherflow stacks.", SMN.JobID)]
    SummonerESPainflareFeature = 2702,

    [CustomComboInfo("Radiant Carbuncle Feature", "Change Radiant Aegis into Summon Carbuncle when no pet has been summoned.", SMN.JobID)]
    SummonerRadiantCarbuncleFeature = 2711,

    [ParentCombo(SummonerRadiantCarbuncleFeature)]
    [CustomComboInfo("Radiant Lux Solaris Feature", "Change Radiant Aegis to Lux Solaris when you have Refulgent Lux ready.", SMN.JobID)]
    SummonerRadiantLuxSolarisFeature = 2718,

    [CustomComboInfo("Demi Carbuncle Feature", "Change Summon Bahamut into Summon Carbuncle when no pet has been summoned.", SMN.JobID)]
    SummonerDemiCarbuncleFeature = 2716,

    [CustomComboInfo("Summon Lux Solaris Feature", "Change Summon Bahamut to Lux Solaris when you have Refulgent Lux ready.", SMN.JobID)]
    SummonerSummonLuxSolarisFeature = 2717,

    #endregion
    // ====================================================================================
    #region VIPER

    [CustomComboInfo("Auto Steel Reaving", "Replace Steel Fangs/Reaving Fangs and Steel Maw/Reaving Maw with whichever is currently empowered. Only affects the first combo hit.", VPR.JobID)]
    ViperAutoSteelReavingFeature = 4124,

    [CustomComboInfo("Serpent's Fang Feature", "Replace Steel Fangs, Reaving Fangs, Steel Maw, and Reaving Maw with Serpent's Tail after finishing a combo.", VPR.JobID)]
    ViperSteelTailFeature = 4101,

    [CustomComboInfo("Steel Coil Feature", "Replace Steel Fangs with Swiftskin's Coil, Reaving Fangs with Hunter's Coil, Steel Maw with Swiftskin's Den, and Reaving Maw with Hunter's Den when usable.  Also replaces Steel Fangs/Maw with both First and Third Generation, and Reaving Fangs/Maw with both Second and Fourth.", VPR.JobID)]
    ViperSteelCoilFeature = 4126,

    [SecretCustomCombo]
    [CustomComboInfo("Twin Coil Feature", "Replace Swiftskin's Coil/Den and Hunter's Coil/Den with their respective Twinblood and Twinfang skills.", VPR.JobID)]
    ViperTwinCoilFeature = 4103,

    [SecretCustomCombo]
    [CustomComboInfo("All-in-one Reawaken Feature", "Replace Reawaken by the Generation skills with their respective Legacies in order.", VPR.JobID)]
    ViperReawakenAIOFeature = 4123,

    [CustomComboInfo("Generation Legacy Feature", "Replaces the Generation skills with their respective Legacies.", VPR.JobID)]
    ViperGenerationLegaciesFeature = 4105,

    [CustomComboInfo("Uncoiled Fury Followup", "Replaces Uncoiled Fury with Uncoiled Twinfang and Uncoiled Twinblood in sequence.", VPR.JobID)]
    ViperUncoiledFollowupFeature = 4107,

    [CustomComboInfo("Fury And Ire", "Replaces Uncoiled Fury with Serpent's Ire when out of Rattling Coil stacks.", VPR.JobID)]
    ViperFuryAndIreFeature = 4108,

    [SecretCustomCombo]
    [CustomComboInfo("Fangs to Vicewinder", "Replaces Steel Fangs and Reaving Fangs to Vicewinder when charges are available and you're not currently in a combo.", VPR.JobID)]
    ViperAutoViceSTFeature = 4109,

    [SecretCustomCombo]
    [CustomComboInfo("Maws to Vicepit", "Replaces Steel Maw and Reaving Maw with Vicepit when charges are available and not you're currently in a combo.", VPR.JobID)]
    ViperAutoViceAoEFeature = 4110,

    [ConflictingCombos(ViperMergeTwinsSerpentFeature)]
    [CustomComboInfo("Merge Twinfang/Twinblood onto Serpent's Tail Feature", "Merge all Twinfang/Twinblood abilities onto Serpent's Tail.", VPR.JobID)]
    ViperMergeSerpentTwinsFeature = 4111,

    [ConflictingCombos(ViperMergeSerpentTwinsFeature)]
    [CustomComboInfo("Merge Serpent's Tail onto Twinfang/Twinblood Feature", "Merge all Serpent's Tail abilities onto Twinfang/Twinblood.", VPR.JobID)]
    ViperMergeTwinsSerpentFeature = 4112,

    // [SecretCustomCombo]
    // [ConflictingCombos(ViperSteelTailFeature)]
    // [CustomComboInfo("Viper PvP Style Main Combo", "Condenses the main combo to a single button, like PvP.\nThe combo detects buffs and debuffs to prioritize skills.\nThe default combo ender is Hindsbane Fang, configurable below.", VPR.JobID)]
    // ViperPvPMainComboFeature = 4113,

    // [SecretCustomCombo]
    // [ConflictingCombos(ViperPvPMainComboStartFlankstingFeature, ViperPvPMainComboStartHindstingFeature)]
    // [ParentCombo(ViperPvPMainComboFeature)]
    // [CustomComboInfo("PvP Combo Start Flanksbane Fang", "With no buffs, end first combo with Flanksbane Fang.", VPR.JobID)]
    // ViperPvPMainComboStartFlanksbaneFeature = 4114,

    // [SecretCustomCombo]
    // [ConflictingCombos(ViperPvPMainComboStartFlanksbaneFeature, ViperPvPMainComboStartHindstingFeature)]
    // [ParentCombo(ViperPvPMainComboFeature)]
    // [CustomComboInfo("PvP Combo Start Flanksting Strike", "With no buffs, end first combo with Flanksting Strike.", VPR.JobID)]
    // ViperPvPMainComboStartFlankstingFeature = 4115,

    // [SecretCustomCombo]
    // [ConflictingCombos(ViperPvPMainComboStartFlanksbaneFeature, ViperPvPMainComboStartFlankstingFeature)]
    // [ParentCombo(ViperPvPMainComboFeature)]
    // [CustomComboInfo("PvP Combo Start Hindsting Strike", "With no buffs, end first combo with Hindsting Strike.", VPR.JobID)]
    // ViperPvPMainComboStartHindstingFeature = 4116,

    // [SecretCustomCombo]
    // [ConflictingCombos(ViperSteelTailAoEFeature)]
    // [CustomComboInfo("Viper PvP Style AoE Combo", "Condenses the main combo to a single button, like PvP.\nThe combo can only detect debuffs on the current target.\nStarts with Jagged Maw by default, configurable below.", VPR.JobID)]
    // ViperPvPMainComboAoEFeature = 4117,

    // [SecretCustomCombo]
    // [ParentCombo(ViperPvPMainComboAoEFeature)]
    // [CustomComboInfo("PvP AoE Combo Start Bloodied Maw", "With no buffs, end first combo with Bloodied Maw.", VPR.JobID)]
    // ViperPvPMainComboAoEStartBloodiedFeature = 4118,

    [SecretCustomCombo]
    [ConflictingCombos(ViperAutoViceSTFeature)]
    [CustomComboInfo("Viper PvP Style Winder Combo", "Condenses the Vicewinder combo to a single button, like PvP.\nStarts with Swiftskin's Coil (rear positional) by default.", VPR.JobID)]
    ViperPvPWinderComboFeature = 4119,

    [SecretCustomCombo]
    [ParentCombo(ViperPvPWinderComboFeature)]
    [CustomComboInfo("Start with Hunter's Coil", "Start with Hunter's Coil (flank positional) instead.", VPR.JobID)]
    ViperPvPWinderComboStartHuntersFeature = 4120,

    [SecretCustomCombo]
    [ConflictingCombos(ViperAutoViceAoEFeature)]
    [CustomComboInfo("Viper PvP Style Pit Combo", "Condenses the Vicepit combo to a single button, like PvP.\nStarts with Swiftskin's Den by default.", VPR.JobID)]
    ViperPvPPitComboFeature = 4121,

    [SecretCustomCombo]
    [ParentCombo(ViperPvPPitComboFeature)]
    [CustomComboInfo("Start with Hunter's Den", "Start with Hunter's Den instead.", VPR.JobID)]
    ViperPvPPitComboStartHuntersFeature = 4122,

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

    [CustomComboInfo("Healthy Balanced Diet Feature", "Replace Bloodwhetting with Thrill of Battle, and then Equilibrium when the preceding is on cooldown.", WAR.JobID)]
    WarriorHealthyBalancedDietFeature = 2112,

    [CustomComboInfo("Primal Beast Feature", "Replace Inner Beast and Steel Cyclone with Primal Rend when available", WAR.JobID)]
    WarriorPrimalBeastFeature = 2107,

    [CustomComboInfo("Primal Release Feature", "Replace Inner Release with Primal Rend when available", WAR.JobID)]
    WarriorPrimalReleaseFeature = 2108,

    #endregion
    // ====================================================================================
    #region WHITE MAGE

    [CustomComboInfo("Solace into Misery", "Replace Afflatus Solace with Afflatus Misery when ready.", WHM.JobID)]
    WhiteMageSolaceMiseryFeature = 2401,

    [CustomComboInfo("Targeted Misery", "Only swap to Afflatus Misery when targeting an enemy.", WHM.JobID)]
    WhiteMageSolaceMiseryTargetFeature = 2406,

    [CustomComboInfo("Rapture into Misery", "Replace Afflatus Rapture with Afflatus Misery when ready and you have an enemy target.", WHM.JobID)]
    WhiteMageRaptureMiseryFeature = 2402,

    [CustomComboInfo("Holy into Misery", "Replace Holy/Holy 3 with Afflatus Misery when ready and you have an enemy target.", WHM.JobID)]
    WhiteMageHolyMiseryFeature = 2405,

    [CustomComboInfo("Cure 2 Level Sync", "Replace Cure 2 with Cure when below level 30 in synced content.", WHM.JobID)]
    WhiteMageCureFeature = 2403,

    [CustomComboInfo("Afflatus Feature", "Replace Cure 2 with Afflatus Solace and Medica with Afflatus Rapture when a Lily is available.", WHM.JobID)]
    WhiteMageAfflatusFeature = 2404,

    [ParentCombo(WhiteMageAfflatusFeature)]
    [CustomComboInfo("Medicafflatus Feature", "Also replaces Medica 2 & Medica 3 with Afflatus Rapture when a Lily is available.", WHM.JobID)]
    WhiteMageAfflatusMedicaPlusFeature = 2408,

    [CustomComboInfo("Glare4 Feature", "Replace Glare 3 with Glare 4 when a stack is available.", WHM.JobID)]
    WhiteMageGlare4Feature = 2407,

    [SecretCustomCombo]
    [CustomComboInfo("Auto Dia", "Replace Glare with Dia when it is about to run out.", WHM.JobID)]
    WhiteMageDoTFeature = 2409,

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

    [ConflictingCombos(DolCastRestFeature)]
    [CustomComboInfo("Cast / Hook Feature", "Replace Cast with Hook when fishing.", DOL.JobID)]
    DolCastHookFeature = 51002,

    [ConflictingCombos(DolCastHookFeature)]
    [CustomComboInfo("Cast / Rest Feature", "Replace Cast with Rest when fishing.", DOL.JobID)]
    DolCastRestFeature = 51008,

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
