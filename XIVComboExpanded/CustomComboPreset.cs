using System;
using XIVComboExpandedPlugin.Attributes;
using XIVComboExpandedPlugin.Combos;

using UTL = XIVComboExpandedPlugin.Attributes.IconsComboAttribute;

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

    [SectionCombo("Tank Role Actions")]
    [IconsCombo([ADV.Provoke, UTL.ArrowLeft, PLD.IronWill, WAR.Defiance, DRK.Grit, GNB.RoyalGuard])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Stance over Provoke", "Replace Provoke with Iron Will, Defiance, Grit or Royal Guard when it is off cooldown and your stance isn't up.", ADV.JobID)]
    AdvStanceProvokeFeature = 1004,

    [SectionCombo("Tank Role Actions")]
    [IconsCombo([ADV.Provoke, UTL.ArrowLeft, PLD.IronWillRemoval, WAR.DefianceRemoval, DRK.GritRemoval, GNB.RoyalGuardRemoval])]
    [ParentCombo(AdvStanceProvokeFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Stance Removal while on CD", "Replace Provoke by your Stance removal action when Provoke is on cooldown. Be careful with this option as you won't be able to track Provoke's cooldown.", ADV.JobID)]
    AdvStanceBackProvokeFeature = 1005,

    [SectionCombo("Tank Role Actions")]
    [IconsCombo([ADV.Shirk, UTL.ArrowLeft, PLD.IronWillRemoval, WAR.DefianceRemoval, DRK.GritRemoval, GNB.RoyalGuardRemoval])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Stance Removal over Shirk", "Replace Shirk by your Stance removal action when it is on cooldown and your stance is up.", ADV.JobID)]
    AdvShirkStanceFeature = 1006,

    [SectionCombo("Ranged Role Actions")]
    [IconsCombo([ADV.HeadGraze, UTL.ArrowLeft, ADV.Peloton])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Silent Peloton", "Replace Head Graze by Peloton when out of combat and you aren't already under its effect.", ADV.JobID)]
    AdvPelotonSTFeature = 1007,

    [SectionCombo("Raising Features")]
    [IconsCombo([ADV.Swiftcast, UTL.ArrowLeft, WHM.Raise, SCH.Resurrection, AST.Ascend, RDM.Verraise, SGE.Egeiro, BLU.AngelWhisper])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Swift Raise Feature", "Replace Ascend, Resurrection, Egeiro, Raise, Verraise, and Angel Whisper with Swiftcast when it is off cooldown (and Dualcast isn't up).", ADV.JobID)]
    AdvSwiftcastFeature = 1000,

    [SectionCombo("Raising Features")]
    [IconsCombo([UTL.Forbidden, RDM.Verraise])]
    [ParentCombo(AdvSwiftcastFeature)]
    [ConflictingCombos(AdvVerRaiseToVerCureFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Disable for VerRaise", "Doesn't apply this feature to RDM's VerRaise.", ADV.JobID)]
    AdvDisableVerRaiseFeature = 1002,

    [SectionCombo("Raising Features")]
    [IconsCombo([RDM.Vercure, UTL.ArrowLeft, RDM.Verraise])]
    [ParentCombo(AdvSwiftcastFeature)]
    [ConflictingCombos(AdvDisableVerRaiseFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Replace VerRaise by Vercure instead", "Do those puny dead bodies really deserve you wasting 2 GCDs?", ADV.JobID)]
    AdvVerRaiseToVerCureFeature = 1003,

    [SectionCombo("Raising Features")]
    [IconsCombo([ADV.VariantRaise2, UTL.ArrowLeft, WHM.Raise, SCH.Resurrection, AST.Ascend, RDM.Verraise, SGE.Egeiro, BLU.AngelWhisper])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Variant Raise Feature", "Replace Ascend, Ressurection, Egeiro, Raise, Verraise, and Angel Whisper with Variant Raise II when in a variant dungeon.", ADV.JobID)]
    AdvVariantRaiseFeature = 1001,

    [SectionCombo("Casters & Healers Role Actions")]
    [IconsCombo([ADV.LucidDreaming, UTL.ArrowLeft, UTL.ArrowLeft, UTL.ArrowLeft, UTL.Danger])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Automatic Dreams", "Replace EVERY SPELL AND ABILITY with Lucid Dreaming whenever your MP drop under 5000, it's off cooldown and you are a Healer or Caster (except BLM/THM). Use with caution.", ADV.JobID)]
    AdvAutoLucidDreamingFeature = 1008,

    [SectionCombo("Casters & Healers Role Actions")]
    [IconsCombo([ADV.LucidDreaming, UTL.Idea])]
    [ParentCombo(AdvAutoLucidDreamingFeature)]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Enable for BLM", "Also apply this feature to Black Mage and Thaumaturge\nAre you REALLY sure you want to do this?", ADV.JobID)]
    AdvEnableBLMLucidFeature = 1009,

    #endregion
    // ====================================================================================
    #region ASTROLOGIAN

    [IconsCombo([AST.Malefic, UTL.ArrowLeft, AST.Combust, UTL.Blank, AST.Debuffs.Combust, UTL.Clock])]
    [SectionCombo("Single Target")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Auto Combust", "Replace Malefic with Combust when it is about to run out.", AST.JobID)]
    AstrologianDoTFeature = 3327,

    [SectionCombo("Draw features")]
    [IconsCombo([AST.Play1, AST.Play2, AST.Play3, AST.MinorArcanaDT, UTL.ArrowLeft, AST.AstralDraw, AST.UmbralDraw])]
    [CustomComboInfo("Play to Astral/Umbral Draw", "Replace Play I / II / III & Minor Arcana with with Astral/Umbral Draw when no card is drawn and you can draw.", AST.JobID)]
    AstrologianPlayDrawFeature = 3323,

    [SectionCombo("Draw features")]
    [IconsCombo([AST.Malefic, UTL.ArrowLeft, AST.AstralDraw, AST.UmbralDraw])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Malefic to Astral/Umbral Draw", "Replace Malefic with Astral/Umbral Draw when no card is drawn and you can draw.", AST.JobID)]
    AstrologianMaleficDrawFeature = 3320,

    [SectionCombo("Draw features")]
    [IconsCombo([AST.Malefic, UTL.ArrowLeft, AST.AstralDraw, AST.UmbralDraw, UTL.Blank, UTL.Clock, AST.Play1])]
    [ParentCombo(AstrologianMaleficDrawFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Play 1 override", "Replace Malefic with Astral/Umbral when Play I isn't drawn yet, even if there are remaining other cards.", AST.JobID)]
    AstrologianDraw1Feature = 3321,

    [SectionCombo("Draw features")]
    [IconsCombo([AST.Gravity, UTL.ArrowLeft, AST.AstralDraw, AST.UmbralDraw])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Gravity to Astral/Umbral Draw", "Replace Gravity with with Astral/Umbral Draw when no card is drawn and you can draw.", AST.JobID)]
    AstrologianGravityDrawFeature = 3322,

    [SectionCombo("Minor Arcanas")]
    [IconsCombo([AST.Helios, UTL.ArrowLeft, AST.LadyofCrowns])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Helios to Arcana", "Replace Helios by Lady of Crowns when drawn.", AST.JobID)]
    AstrologianHeliosArcanaFeature = 3324,

    [SectionCombo("Minor Arcanas")]
    [IconsCombo([AST.Malefic, UTL.ArrowLeft, AST.LordOfCrowns])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Malefic/Gravity to Arcana", "Replace Malefic & Gravity by Lord of Crowns when drawn.", AST.JobID)]
    AstrologianMaleficArcanaFeature = 3325,

    [SectionCombo("Level Synchronization")]
    [IconsCombo([AST.Benefic, UTL.ArrowLeft, AST.Benefic2])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Benefic II to Benefic Level Sync", "Replace Benefic 2 with Benefic when below level 26 in synced content.", AST.JobID)]
    AstrologianBeneficSyncFeature = 3326,

    #endregion
    // ====================================================================================
    #region BLACK MAGE

    [IconsCombo([BLM.Fire4, UTL.Cycle, BLM.Blizzard4])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Enochian Feature", "Replace Fire 4 and Blizzard 4 with whichever action you can currently use.", BLM.JobID)]
    BlackEnochianFeature = 2501,

    [IconsCombo([BLM.Fire4, BLM.Blizzard4, UTL.ArrowLeft, BLM.FlareStar, UTL.Blank, BLM.FlareStar, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ParentCombo(BlackEnochianFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Flare Star Feature", "Replace Fire 4 and Blizzard 4 with Flare Star when you have 6 astral soul.", BLM.JobID)]
    BlackFlareStarFeature = 2523,

    [IconsCombo([BLM.Fire4, BLM.Blizzard4, UTL.ArrowLeft, BLM.Despair, UTL.Blank, UTL.Idea])]
    [SectionCombo("Single Target")]
    [ParentCombo(BlackEnochianFeature)]
    [SecretCustomCombo]
    [CustomComboInfo("Enochian Despair Feature", "Replace Fire 4 and Blizzard 4 with Despair when in Astral Fire with less than 2400 mana.\n\nThis is an optimization feature since Despair requires at least 800 mp to cast, and Fire 4 costs 1600 mp at max Astral Fire. Therefore, casting a Fire 4 when less than 2400 mp does not leave enough mana for despair. Since Despair is stronger than Fire 4 this feature will always be optimal, even accounting for unusual mp levels from death or rotation mistakes.", BLM.JobID)]
    BlackEnochianDespairFeature = 2510,

    [IconsCombo([BLM.Fire4, BLM.Blizzard4, UTL.ArrowLeft, BLM.Despair, UTL.ArrowLeft, BLM.FlareStar, UTL.Blank, UTL.Idea])]
    [SectionCombo("Single Target")]
    [ParentCombo(BlackEnochianDespairFeature)]
    [ConflictingCombos(BlackFlareStarFeature)]
    [SecretCustomCombo]
    [CustomComboInfo("Enochian Despair into Flare Star Feature", "Replace Fire 4 and Blizzard 4 with Flare Star when you have 6 astral soul and 0 mana, or when optimal.\n\nSince Despair refreshes Astral Fire, casting Flare Star afterwards is safer instead of cramming it with Fire 4s. Exceptions are during the Dawntrail opener, or manafont is used before casting Flare Star from the previous fire phase.", BLM.JobID)]
    BlackEnochianDespairFlareStarFeature = 2524,

    [IconsCombo([BLM.Fire4, BLM.Blizzard4, UTL.ArrowLeft, ADV.Swiftcast, BLM.Triplecast, BLM.Despair, UTL.Blank, BLM.Buffs.Firestarter, BLM.Fire3, UTL.Blank, BLM.Paradox, UTL.Blank, UTL.Clock])]
    [SectionCombo("Single Target")]
    [ParentCombo(BlackEnochianFeature)]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Enochian Timer Feature", "Replace Fire 4 and Blizzard 4 with Instant-Despair, Fire 3 Proc, Paradox, or Blizzard 3 when Enochian is about to run out.", BLM.JobID)]
    BlackEnochianTimerFeature = 2525,

    [IconsCombo([BLM.Fire4, BLM.Blizzard4, UTL.Cross, UTL.ArrowLeft, BLM.Fire, BLM.Blizzard])]
    [SectionCombo("Single Target")]
    [ParentCombo(BlackEnochianFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Enochian No Sync Feature", "Fire 4 and Blizzard 4 will not sync to Fire 1 and Blizzard 1.", BLM.JobID)]
    BlackEnochianNoSyncFeature = 2518,

    [IconsCombo([BLM.Fire, UTL.ArrowLeft, BLM.Fire3,  UTL.Blank, BLM.Buffs.Firestarter, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Fire 1/3 Feature", "Fire 1 becomes Fire 3 outside of Astral Fire, and when Firestarter is up.", BLM.JobID)]
    BlackFireFeature = 2504,

    [IconsCombo([BLM.Fire, UTL.Cross, UTL.ArrowLeft, BLM.Fire3, UTL.Blank, UTL.Danger])]
    [SectionCombo("Single Target")]
    [ParentCombo(BlackFireFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Fire 1/3 Option", "Fire 1 will stay Fire 3 when not at max Astral Fire.", BLM.JobID)]
    BlackFireOption = 2515,

    [IconsCombo([BLM.Fire, UTL.Cross, UTL.ArrowLeft, BLM.Fire3, UTL.Blank, UTL.Plus, UTL.Danger])]
    [SectionCombo("Single Target")]
    [ParentCombo(BlackFireFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Fire 1/3 Option (2)", "Fire 1 does not become Fire 3 outside of Astral Fire.", BLM.JobID)]
    BlackFireOption2 = 2516,

    [IconsCombo([BLM.Blizzard, UTL.ArrowLeft, BLM.Blizzard3, UTL.Cycle, BLM.Paradox, UTL.Blank, BLM.Paradox, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Blizzard 1/3 Feature", "Replace Blizzard 1 with Blizzard 3 when unlocked and becomes Paradox when available.", BLM.JobID)]
    BlackBlizzardFeature = 2505,

    [IconsCombo([BLM.Scathe, UTL.ArrowLeft, BLM.Xenoglossy, UTL.Blank, BLM.Xenoglossy, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Scathe/Xenoglossy Feature", "Scathe becomes Xenoglossy when available.", BLM.JobID)]
    BlackScatheFeature = 2507,

    [IconsCombo([BLM.Freeze, UTL.Cycle, BLM.Flare])]
    [SectionCombo("Area of Effect")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Freeze/Flare Feature", "Freeze and Flare become whichever action you can currently use.", BLM.JobID)]
    BlackFreezeFlareFeature = 2506,

    [IconsCombo([BLM.HighFire2, UTL.ArrowLeft, BLM.Flare, UTL.ArrowLeft, BLM.FlareStar, UTL.Blank, UTL.Idea])]
    [SectionCombo("Area of Effect")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Fire 2 Feature", "(High) Fire 2 becomes Flare and Flare Star when in Astral Fire and is optimal.", BLM.JobID)]
    BlackFire2Feature = 2508,

    [IconsCombo([BLM.HighBlizzard2, UTL.ArrowLeft, BLM.Freeze])]
    [SectionCombo("Area of Effect")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Ice 2 Feature", "(High) Blizzard 2 becomes Freeze in Umbral Ice.", BLM.JobID)]
    BlackBlizzard2Feature = 2509,

    [IconsCombo([BLM.HighBlizzard2, BLM.HighFire2, UTL.Cross, UTL.ArrowLeft, BLM.Freeze, BLM.Flare, UTL.Blank, UTL.Danger])]
    [SectionCombo("Area of Effect")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Fire 2/Ice 2 Option", "Fire 2 and Blizzard 2 will not change unless you're at max Astral Fire or Umbral Ice.", BLM.JobID)]
    BlackFireBlizzard2Option = 2514,

    [IconsCombo([BLM.Transpose, UTL.ArrowLeft, BLM.UmbralSoul, UTL.Blank, BLM.UmbralSoul, UTL.Checkmark])]
    [SectionCombo("Umbral Soul Features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Transpose into Umbral Soul", "Replace Transpose with Umbral Soul when Umbral Soul is usable.", BLM.JobID)]
    BlackTransposeUmbralSoulFeature = 2502,

    [IconsCombo([BLM.UmbralSoul, UTL.ArrowLeft, BLM.Transpose, UTL.Blank, BLM.UmbralSoul, UTL.Cross])]
    [SectionCombo("Umbral Soul Features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Umbral Soul into Transpose", "Replace Umbral Soul with Transpose when Umbral Soul is not usable.", BLM.JobID)]
    BlackUmbralSoulTransposeFeature = 2522,

    [IconsCombo([BLM.Blizzard3, UTL.ArrowLeft, BLM.UmbralSoul, UTL.Blank, UTL.Enemy, UTL.Cross])]
    [SectionCombo("Umbral Soul Features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Umbral Soul Feature", "Replace your ice spells with Umbral Soul, while in Umbral Ice and having no target.", BLM.JobID)]
    BlackSpellsUmbralSoulFeature = 2517,

    [IconsCombo([BLM.LeyLines, UTL.ArrowLeft, BLM.BetweenTheLines])]
    [SectionCombo("Abilities Features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("(Between the) Ley Lines", "Replace Ley Lines with Between the Ley Lines when available.", BLM.JobID)]
    BlackLeyLinesFeature = 2503,

    [IconsCombo([BLM.Retrace, UTL.Cross])]
    [SectionCombo("Abilities Features")]
    [ParentCombo(BlackLeyLinesFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("(Between the [Retraced]) Ley Lines", "Only replace Ley Lines with Between the Ley Lines when Retrace is already on cooldown.", BLM.JobID)]
    BlackLeyLinesRetraceFeature = 2526,

    #endregion
    // ====================================================================================
    #region BARD

    [IconsCombo([BRD.StraightShot, UTL.ArrowLeft, BRD.HeavyShot, UTL.Blank, BRD.Buffs.HawksEye, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Heavy Shot into Straight Shot", "Replace Heavy Shot with Straight Shot/Refulgent Arrow when available.", BRD.JobID)]
    BardStraightShotUpgradeFeature = 2302,

    [IconsCombo([BRD.IronJaws, UTL.ArrowLeft, BRD.VenomousBite, UTL.Cycle, BRD.Windbite, UTL.Blank, UTL.Blank, UTL.Blank, UTL.Danger])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Iron Jaws Feature", "Replace Iron Jaws with Venomous Bite/Windbite depending on which is not present on the target.", BRD.JobID)]
    BardIronJawsFeature = 2308,

    [IconsCombo([BRD.IronJaws, UTL.ArrowLeft, BRD.VenomousBite, UTL.Cycle, BRD.Windbite, UTL.Blank, UTL.Blank, BRD.IronJaws, UTL.Cross])]
    [SectionCombo("Single Target")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Locked Iron Jaws", "Replace Iron Jaws with Venomous Bite/Windbite depending on the duration when Iron Jaws is not available.", BRD.JobID)]
    BardPreIronJawsFeature = 2303,

    [IconsCombo([BRD.BurstShot, BRD.QuickNock, UTL.ArrowLeft, BRD.ApexArrow, UTL.Blank, UTL.Blank, BRD.ApexArrow, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Burst Shot/Quick Nock into Apex Arrow", "Replace Burst Shot and Quick Nock with Apex Arrow when gauge is full.", BRD.JobID)]
    BardApexFeature = 2304,

    [IconsCombo([BRD.HeavyShot, UTL.ArrowLeft, BRD.IronJaws,  UTL.Blank, BRD.Debuffs.CausticBite, BRD.Debuffs.Windbite, UTL.Danger])]
    [SectionCombo("Single Target")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Heavy Shot Iron Jaws Feature", "Replace Heavy shot with Iron Jaws when Venomous Bite/Windbite is less than 5 seconds on the target.", BRD.JobID)]
    BardShotIronJawsFeature = 2322,

    [IconsCombo([BRD.HeavyShot, UTL.ArrowLeft, BRD.IronJaws, UTL.Blank, BRD.Debuffs.CausticBite, BRD.Debuffs.Windbite, UTL.Idea])]
    [SectionCombo("Single Target")]
    [ParentCombo(BardShotIronJawsFeature)]
    [SecretCustomCombo]
    [CustomComboInfo("Heavy Shot Iron Jaws Optimized Option", "Replace Heavy shot with Iron Jaws when Venomous Bite/Windbite is less than 2.8 seconds on the target instead of 5 seconds.", BRD.JobID)]
    BardShotIronJawsOption = 2323,

    [IconsCombo([BRD.Bloodletter, UTL.ArrowLeft, BRD.EmpyrealArrow, UTL.Cycle, BRD.Bloodletter, UTL.Cycle, BRD.Sidewinder])]
    [SectionCombo("Single Target")]
    [AccessibilityCustomCombo]
    [ConflictingCombos(BardBloodRainFeature)]
    [CustomComboInfo("Bloodletter Feature", "Replace Bloodletter with Empyreal Arrow and Sidewinder depending on which is available.", BRD.JobID)]
    BardBloodletterFeature = 2306,

    [IconsCombo([BRD.EmpyrealArrow, UTL.ArrowLeft, BRD.EmpyrealArrow, UTL.Cycle, BRD.Sidewinder])]
    [SectionCombo("Single Target")]
    [SecretCustomCombo]
    [CustomComboInfo("Empyreal Arrow Feature", "Replace Empyreal Arrow with Sidewinder depending on which is available.", BRD.JobID)]
    BardEmpyrealArrowFeature = 2320,

    [IconsCombo([BRD.Sidewinder, UTL.ArrowLeft, BRD.Sidewinder, UTL.Cycle, BRD.EmpyrealArrow])]
    [SectionCombo("Single Target")]
    [SecretCustomCombo]
    [CustomComboInfo("Sidewinder Feature", "Replace Sidewinder with Empyreal Arrow depending on which is available.", BRD.JobID)]
    BardSidewinderFeature = 2309,

    [IconsCombo([BRD.QuickNock, UTL.ArrowLeft, BRD.WideVolley, UTL.Blank, UTL.Blank, BRD.Buffs.HawksEye, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Quick Nock into Wide Volley/Shadowbite", "Replace Quick Nock with Wide Volley/Shadowbite when available.", BRD.JobID)]
    BardShadowbiteFeature = 2305,

    [IconsCombo([BRD.QuickNock, UTL.ArrowLeft, BRD.Barrage, UTL.Blank, UTL.Blank, BRD.Barrage, UTL.Clock])]
    [SectionCombo("Area of Effect")]
    [ParentCombo(BardShadowbiteFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("A Wide Barrage of Shadowbites", "Replace Quick Nock with Barrage when off cooldown.", BRD.JobID)]
    BardShadowbiteBarrageFeature = 2321,

    [IconsCombo([BRD.RainOfDeath, UTL.ArrowLeft, BRD.EmpyrealArrow, UTL.Cycle, BRD.Sidewinder])]
    [SectionCombo("Area of Effect")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Rain of Death Feature", "Replace Rain of Death with Empyreal Arrow and Sidewinder depending on which is available.", BRD.JobID)]
    BardRainOfDeathFeature = 2307,

    [IconsCombo([BRD.Bloodletter, UTL.ArrowLeft, BRD.RainOfDeath, UTL.Blank, BRD.Debuffs.CausticBite, BRD.Debuffs.Windbite, UTL.Cross])]
    [SectionCombo("Area of Effect")]
    [SecretCustomCombo]
    [ConflictingCombos(BardBloodletterFeature)]
    [CustomComboInfo("Bloodletter to Rain of Death", "Replace Bloodletter with Rain of Death if there are no self-applied DoTs on your target.", BRD.JobID)]
    BardBloodRainFeature = 2313,

    [IconsCombo([BRD.Bloodletter, UTL.ArrowLeft, BRD.PitchPerfect, UTL.Blank, BRD.PitchPerfect, UTL.Checkmark])]
    [SectionCombo("Pitch Perfect")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Perfect Bloodletter Feature", "Replace Bloodletter with Pitch Perfect when Repertoire charges are full.", BRD.JobID)]
    BardPerfectBloodletterFeature = 2315,

    [IconsCombo([BRD.Bloodletter, UTL.ArrowLeft, BRD.PitchPerfect, UTL.Blank, BRD.PitchPerfect, UTL.Clock])]
    [SectionCombo("Pitch Perfect")]
    [SecretCustomCombo]
    [CustomComboInfo("Expiring Perfect Bloodletter Feature", "Replace Bloodletter with Pitch Perfect when Wanderers Minuet has less than 2.5 seconds remaining and at least one Repertoire charge.", BRD.JobID)]
    BardExpiringPerfectBloodletterFeature = 2316,

    [IconsCombo([BRD.RainOfDeath, UTL.ArrowLeft, BRD.PitchPerfect, UTL.Blank, BRD.PitchPerfect, UTL.Checkmark])]
    [SectionCombo("Pitch Perfect")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Perfect Rain of Death Feature", "Replace Rain of Death with Pitch Perfect when Repertoire charges are full.", BRD.JobID)]
    BardPerfectRainOfDeathFeature = 2318,

    [IconsCombo([BRD.RainOfDeath, UTL.ArrowLeft, BRD.PitchPerfect, UTL.Blank, BRD.PitchPerfect, UTL.Clock])]
    [SectionCombo("Pitch Perfect")]
    [SecretCustomCombo]
    [CustomComboInfo("Expiring Perfect Rain of Death Feature", "Replace Rain of Death with Pitch Perfect when Wanderers Minuet has less than 2.5 seconds remaining and atleast one Repertoire charge.", BRD.JobID)]
    BardExpiringPerfectRainOfDeathFeature = 2319,

    [IconsCombo([BRD.MagesBallad, UTL.ArrowLeft, BRD.WanderersMinuet, UTL.Cycle, BRD.MagesBallad, UTL.Cycle, BRD.ArmysPaeon])]
    [ExpandedCustomCombo]
    [SectionCombo("Song features")]
    [CustomComboInfo("Cycling Song Feature", "Replace Mage's Ballad with Wanderer's Minuet, Mage's Ballad, and Army's Paeon, while the previous is on cooldown.", BRD.JobID)]
    BardCyclingSongFeature = 2317,

    [IconsCombo([BRD.RadiantFinale, UTL.ArrowLeft, BRD.BattleVoice, UTL.Blank, BRD.BattleVoice, UTL.Checkmark])]
    [SectionCombo("Song features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Radiant Voice Feature", "Replace Radiant Finale with Battle Voice if Battle Voice is available.", BRD.JobID)]
    BardRadiantVoiceFeature = 2310,

    [IconsCombo([BRD.RadiantFinale, UTL.ArrowLeft, BRD.RagingStrikes, UTL.Blank, BRD.RagingStrikes, UTL.Checkmark])]
    [SectionCombo("Song features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Radiant Strikes Feature", "Replace Radiant Finale with Raging Strikes if Raging Strikes is available.\nThis takes priority over Battle Voice if Radiant Voice is enabled.", BRD.JobID)]
    BardRadiantStrikesFeature = 2311,

    #endregion
    // ====================================================================================
    #region DANCER

    [IconsCombo([DNC.Cascade, UTL.ArrowLeft, DNC.ReverseCascade, UTL.Blank, DNC.Fountain, UTL.ArrowLeft, DNC.Fountainfall])]
    [SectionCombo("Single Target")]
    [ConflictingCombos(DancerSingleTargetMultibutton)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Single Target to Procs", "Replace Cascade and Fountain with Reverse Cascade and Fountainfall respectively when available.", DNC.JobID)]
    DancerSingleTargetProcs = 3811,

    [IconsCombo([DNC.Cascade, UTL.Blank, DNC.Cascade, UTL.ArrowLeft, DNC.ReverseCascade, UTL.Plus, DNC.Fountain, UTL.ArrowLeft, DNC.Fountainfall])]
    [SectionCombo("Single Target")]
    [ConflictingCombos(DancerSingleTargetProcs)]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Single Target Multibutton", "Replace Cascade with its procs and combos as they activate.", DNC.JobID)]
    DancerSingleTargetMultibutton = 3804,

    [IconsCombo([DNC.Windmill, UTL.ArrowLeft, DNC.RisingWindmill, UTL.Blank, DNC.Bladeshower, UTL.ArrowLeft, DNC.Bloodshower])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("AoE to Procs", "Replace Windmill and Bladeshower with Rising Windmill and Bloodshower respectively when available.", DNC.JobID)]
    DancerAoeProcs = 3812,

    [IconsCombo([DNC.Windmill, UTL.Blank, DNC.Windmill, UTL.ArrowLeft, DNC.RisingWindmill, UTL.Plus, DNC.Bladeshower, UTL.ArrowLeft, DNC.Bloodshower])]
    [SectionCombo("Area of Effect")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("AoE Multibutton", "Replace Windmill with its procs and combos as they activate.", DNC.JobID)]
    DancerAoeMultibutton = 3805,

    [IconsCombo([DNC.Cascade, DNC.Windmill, UTL.ArrowLeft, DNC.SaberDance, UTL.Idea])]
    [SectionCombo("Saber Dance features")]
    [SecretCustomCombo]
    [CustomComboInfo("Automatic Saber Dance", "Replace all single-target and AoE combo actions with Saber Dance when at >= 50 Esprit.", DNC.JobID)]
    DancerAutoSaberDance = 3817,

    [IconsCombo([DNC.Cascade, UTL.ArrowLeft, DNC.SaberDance, UTL.Idea, UTL.Danger])]
    [ParentCombo(DancerAutoSaberDance)]
    [SectionCombo("Saber Dance features")]
    [SecretCustomCombo]
    [CustomComboInfo("Single-Target 85 Esprit", "Only replace single-target combo actions with Saber Dance when at >= 85 Esprit instead of 50.\n\nNOTE: This is intended to permit greater pooling of Esprit for burst windows, while still minimizing the risk of overcapping.", DNC.JobID)]
    DancerAutoSaberDanceST85Esprit = 3823,

    [IconsCombo([DNC.Cascade, UTL.ArrowLeft, DNC.SaberDance, UTL.Plus, DNC.TechnicalStep])]
    [ParentCombo(DancerAutoSaberDanceST85Esprit)]
    [SectionCombo("Saber Dance features")]
    [SecretCustomCombo]
    [CustomComboInfo("Single-Target 50 Esprit in Tech Step", "Use Saber Dance at >= 50 Esprit during Technical Step.", DNC.JobID)]
    DancerAutoSaberDanceSTTech = 3818,

    [IconsCombo([DNC.Cascade, UTL.ArrowLeft, DNC.DanceOfTheDawn])]
    [ParentCombo(DancerAutoSaberDanceST85Esprit)]
    [SectionCombo("Saber Dance features")]
    [SecretCustomCombo]
    [CustomComboInfo("Single Target Dance of the Dawn", "Use Dance of the Dawn at >= 50 Esprit when available.", DNC.JobID)]
    DancerAutoSaberDanceSTDawn = 3819,

    [IconsCombo([DNC.Windmill, UTL.ArrowLeft, DNC.SaberDance, UTL.Idea, UTL.Danger])]
    [ParentCombo(DancerAutoSaberDance)]
    [SectionCombo("Saber Dance features")]
    [SecretCustomCombo]
    [CustomComboInfo("AoE 85 Esprit", "Only replace AoE combo actions with Saber Dance when at >= 85 Esprit instead of 50.\n\nNOTE: This is intended to permit greater pooling of Esprit for burst windows, while still minimizing the risk of overcapping.", DNC.JobID)]
    DancerAutoSaberDanceAoE85Esprit = 3820,

    [IconsCombo([DNC.Windmill, UTL.ArrowLeft, DNC.SaberDance, UTL.Plus, DNC.TechnicalStep])]
    [ParentCombo(DancerAutoSaberDanceAoE85Esprit)]
    [SectionCombo("Saber Dance features")]
    [SecretCustomCombo]
    [CustomComboInfo("AoE 50 Esprit in Tech Step", "Use Saber Dance at >= 50 Esprit during Technical Step.", DNC.JobID)]
    DancerAutoSaberDanceAoETech = 3821,

    [IconsCombo([DNC.Windmill, UTL.ArrowLeft, DNC.DanceOfTheDawn])]
    [ParentCombo(DancerAutoSaberDanceAoE85Esprit)]
    [SectionCombo("Saber Dance features")]
    [SecretCustomCombo]
    [CustomComboInfo("AoE Dance of the Dawn", "Use Dance of the Dawn at >= 50 Esprit when available.", DNC.JobID)]
    DancerAutoSaberDanceAoEDawn = 3822,

    [IconsCombo([DNC.FanDance1, DNC.FanDance2, UTL.ArrowLeft, DNC.FanDance3, UTL.Blank, DNC.Buffs.ThreefoldFanDance, UTL.Checkmark])]
    [SectionCombo("Fan features")]
    [CustomComboInfo("Fan Dance 3 Feature", "Replace Fan Dance and Fan Dance 2 with Fan Dance 3 when available.", DNC.JobID)]
    DancerFanDance3Feature = 3801,

    [IconsCombo([DNC.Cascade, DNC.ReverseCascade, DNC.Fountain, DNC.Fountainfall, UTL.ArrowLeft, DNC.FanDance1, UTL.Blank, DNC.FanDance1, UTL.Checkmark])]
    [SectionCombo("Fan features")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Single Target Feather Overcap Feature", "Replace Cascade, Reverse Cascade, Fountain and Fountainfall by Fan Dance if at maximum feathers.", DNC.JobID)]
    DancerFanFeatherOvercap = 3825,

    [IconsCombo([DNC.Cascade, DNC.ReverseCascade, DNC.Fountain, DNC.Fountainfall, UTL.ArrowLeft, DNC.FanDance3, UTL.Blank, DNC.Buffs.ThreefoldFanDance, UTL.Checkmark])]
    [SectionCombo("Fan features")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Auto-Fan Dance 3", "Replace Cascade, Reverse Cascade, Fountain and Fountainfall by Fan Dance 3 if you have the Threefold Fan Dance buff.", DNC.JobID)]
    DancerFan3FeatherOvercap = 3827,

    [IconsCombo([DNC.Windmill, DNC.RisingWindmill, DNC.Bladeshower, DNC.Bloodshower, UTL.ArrowLeft, DNC.FanDance2, UTL.Blank, DNC.FanDance2, UTL.Checkmark])]
    [SectionCombo("Fan features")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("AoE Feather Overcap Feature", "Replace Windmill, Rising Windmill, Bladeshower and Bloodshower by Fan Dance 2 if at maximum feathers.", DNC.JobID)]
    DancerFanFeatherAoEOvercap = 3826,

    [IconsCombo([DNC.Windmill, DNC.RisingWindmill, DNC.Bladeshower, DNC.Bloodshower, UTL.ArrowLeft, DNC.FanDance3, UTL.Blank, DNC.Buffs.ThreefoldFanDance, UTL.Checkmark])]
    [SectionCombo("Fan features")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("AoE Auto-Fan Dance 3", "Replace Windmill, Rising Windmill, Bladeshower and Bloodshower  by Fan Dance 3 if you have the Threefold Fan Dance buff.", DNC.JobID)]
    DancerFan3FeatherAoEOvercap = 3828,

    [IconsCombo([DNC.FanDance1, DNC.FanDance2, UTL.ArrowLeft, DNC.FanDance4, UTL.Blank, DNC.Buffs.FourfoldFanDance, UTL.Checkmark])]
    [SectionCombo("Fan features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Fan Dance 4 Feature", "Replace Fan Dance and Fan Dance 2 with Fan Dance 4 when available.\n\nNOTE: If enabled with Fance Dance 3 Feature, Fan Dance 3 has priority over Fan Dance 4.", DNC.JobID)]
    DancerFanDance4Feature = 3809,

    [IconsCombo([DNC.FanDance4, UTL.Forbidden, UTL.Danger])]
    [SectionCombo("Fan features")]
    [ParentCombo(DancerFanDance4Feature)]
    [SecretCustomCombo]
    [CustomComboInfo("Except at max feathers", "Don't replace Fan Dance and Fan Dance 2 with Fan Dance 4 if at maximum feathers.", DNC.JobID)]
    DancerFanDance4MaxFeathers = 3824,

    [IconsCombo([DNC.Flourish, UTL.ArrowLeft, DNC.FanDance3, UTL.Blank, DNC.FanDance3, UTL.Checkmark])]
    [SectionCombo("Fan features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Flourishing Fan Dance 3", "Replace Flourish with Fan Dance 3 when available.", DNC.JobID)]
    DancerFlourishFan3Feature = 3810,

    [IconsCombo([DNC.Flourish, UTL.ArrowLeft, DNC.FanDance4, UTL.Blank, DNC.Buffs.FourfoldFanDance, UTL.Checkmark])]
    [SectionCombo("Fan features")]
    [CustomComboInfo("Flourishing Fan Dance 4", "Replace Flourish with Fan Dance 4 when available.", DNC.JobID)]
    DancerFlourishFan4Feature = 3808,

    [IconsCombo([DNC.StandardStep, DNC.Devilment, DNC.TechnicalStep, UTL.ArrowLeft, DNC.ClosedPosition, UTL.Blank, UTL.Party, UTL.Duty, UTL.Checkmark])]
    [SectionCombo("Partner features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Partner Feature", "Replace Standard Step, Devilment, and Technical step by Closed Position if a partner is available, you are in a duty, and and you haven't partner'd yet.", DNC.JobID)]
    DancerPartnerFeature = 3815,

    [IconsCombo([DNC.StandardStep, DNC.Devilment, DNC.TechnicalStep, UTL.ArrowLeft, DNC.ClosedPosition, UTL.Blank, UTL.Blank, UTL.PartnerChocobo, UTL.Checkmark])]
    [SectionCombo("Partner features")]
    [ExpandedCustomCombo]
    [ParentCombo(DancerPartnerFeature)]
    [CustomComboInfo("Chocobo Partner Feature", "Also applies if you are out of duty and that your Chocobo is summoned.", DNC.JobID)]
    DancerChocoboPartnerFeature = 3816,

    [IconsCombo([DNC.Devilment, UTL.ArrowLeft, DNC.StarfallDance, UTL.Blank, DNC.Buffs.FlourishingStarfall, UTL.Checkmark])]
    [SectionCombo("Dances features")]
    [CustomComboInfo("Devilment Feature", "Replace Devilment with Starfall Dance when active.", DNC.JobID)]
    DancerDevilmentFeature = 3807,

    [IconsCombo([DNC.StandardStep, UTL.ArrowLeft, DNC.LastDance, UTL.Blank, DNC.Buffs.LastDanceReady, UTL.Checkmark])]
    [SectionCombo("Dances features")]
    [CustomComboInfo("Last Dance Feature", "Replace Standard Step by Last Dance if available.", DNC.JobID)]
    DancerLastDanceFeature = 3813,

    [IconsCombo([DNC.StandardStep, UTL.ArrowLeft, DNC.FinishingMove, UTL.ArrowLeft, DNC.LastDance, UTL.Blank, DNC.Buffs.LastDanceReady, UTL.Checkmark])]
    [SectionCombo("Dances features")]
    [SecretCustomCombo]
    [ParentCombo(DancerLastDanceFeature)]
    [CustomComboInfo("Finishing Move Priority", "Priorize Finishing Move over Last Dance when replacing Standard Step.\n\nNOTE: This is strongly discouraged, as Finishing Move will overwrite and waste the Last Dance buff.", DNC.JobID)]
    DancerFinishingMovePriorityFeature = 3814,

    [IconsCombo([DNC.StandardStep, DNC.TechnicalStep, UTL.ArrowLeft, DNC.Emboite, UTL.Cycle, DNC.Entrechat, UTL.Cycle, DNC.Jete, UTL.Cycle, DNC.Pirouette])]
    [SectionCombo("Dances features")]
    [ConflictingCombos(DancerDanceComboCompatibility)]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Dance Step Combo", "Replace Standard Step and Technical Step with each dance step while dancing.", DNC.JobID)]
    DancerDanceStepCombo = 3802,

    [IconsCombo([DNC.Emboite, DNC.Entrechat, DNC.Jete, DNC.Pirouette])]
    [SectionCombo("Dances features")]
    [ConflictingCombos(DancerDanceStepCombo)]
    [AccessibilityCustomCombo]
    [CustomComboInfo(
        "Dance Step Feature",
        "Replace arbitrary actions with dance steps while dancing." +
        "\nThis helps ensure you can still dance with combos on, without using auto dance." +
        "\nYou can change the respective actions by inputting action IDs below for each dance step." +
        "\nThe defaults are Cascade, Flourish, Fan Dance and Fan Dance II. If set to 0, they will reset to these actions." +
        "\nYou can get Action IDs with Garland Tools by searching for the action and clicking the cog.",
        DNC.JobID)]
    DancerDanceComboCompatibility = 3806,

    #endregion
    // ====================================================================================
    #region DARK KNIGHT

    [SectionCombo("Single Target")]
    [IconsCombo([DRK.Souleater, UTL.ArrowLeft, DRK.SyphonStrike, UTL.ArrowLeft, DRK.HardSlash])]
    [CustomComboInfo("Souleater Combo", "Replace Souleater with its combo chain.", DRK.JobID)]
    DarkSouleaterCombo = 3201,

    [SectionCombo("Single Target")]
    [IconsCombo([DRK.Souleater, UTL.ArrowLeft, DRK.Bloodspiller, UTL.Blank, UTL.Danger])]
    [ParentCombo(DarkSouleaterCombo)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Souleater Overcap Feature", "Replace Souleater with Bloodspiller when the next combo action would cause the Blood Gauge to overcap.", WAR.JobID)]
    DarkSouleaterOvercapFeature = 3206,

    [SectionCombo("Area of Effect")]
    [IconsCombo([DRK.StalwartSoul, UTL.ArrowLeft, DRK.Unleash])]
    [CustomComboInfo("Stalwart Soul Combo", "Replace Stalwart Soul with its combo chain.", DRK.JobID)]
    DarkStalwartSoulCombo = 3202,

    [SectionCombo("Area of Effect")]
    [IconsCombo([DRK.StalwartSoul, UTL.ArrowLeft, DRK.Quietus, UTL.Blank, UTL.Danger])]
    [ParentCombo(DarkStalwartSoulCombo)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Stalwart Soul Overcap Feature", "Replace Stalwart Soul with Quietus when the next combo action would cause the Blood Gauge to overcap.", WAR.JobID)]
    DarkStalwartSoulOvercapFeature = 3207,

    [SectionCombo("Blood Weapon")]
    [IconsCombo([DRK.Souleater, DRK.StalwartSoul, UTL.ArrowLeft, DRK.Bloodspiller, DRK.Quietus, UTL.Blank, DRK.Buffs.Delirium, UTL.Checkmark])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Delirium Feature", "Replace Souleater and Stalwart Soul with Bloodspiller (& its combo chain) and Quietus/Impalement when Delirium is active.", DRK.JobID)]
    DarkDeliriumFeature = 3203,

    [SectionCombo("Blood Weapon")]
    [IconsCombo([DRK.CarveAndSpit, DRK.AbyssalDrain, UTL.ArrowLeft, DRK.BloodWeapon, UTL.Blank, DRK.BloodWeapon, UTL.Checkmark])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Blood Weapon Feature", "Replace Carve and Spit, and Abyssal Drain with Blood Weapon/Delirium when available.", DRK.JobID)]
    DarkBloodWeaponFeature = 3204,

    [SectionCombo("Living Shadow")]
    [IconsCombo([DRK.Bloodspiller, DRK.Quietus, UTL.ArrowLeft, DRK.LivingShadow, UTL.Blank, DRK.LivingShadow, UTL.Checkmark])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Living Shadow Feature", "Replace Quietus and Bloodspiller with Living Shadow when available.", DRK.JobID)]
    DarkLivingShadowFeature = 3205,

    [SectionCombo("Living Shadow")]
    [IconsCombo([DRK.Shadowbringer, UTL.ArrowLeft, DRK.LivingShadow, UTL.Blank, DRK.LivingShadow, UTL.Checkmark])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Living Shadowbringer Feature", "Replace Living Shadow with Shadowbringer when charges are available and your Shadow is present.", DRK.JobID)]
    DarkLivingShadowbringerFeature = 3208,

    [SectionCombo("Living Shadow")]
    [IconsCombo([DRK.Shadowbringer, UTL.ArrowLeft, DRK.LivingShadow, UTL.Blank, DRK.LivingShadow, UTL.Clock])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Missing Shadowbringer Feature", "Replace Living Shadow with Shadowbringer when charges are available and Living Shadow is on cooldown.", DRK.JobID)]
    DarkLivingShadowbringerHpFeature = 3209,

    #endregion
    // ====================================================================================
    #region DRAGOON

    [IconsCombo([DRG.RaidenThrust, DRG.VorpalThrust, DRG.Disembowel, DRG.FullThrust, DRG.ChaosThrust, DRG.FangAndClaw, DRG.WheelingThrust, DRG.Drakesbane, UTL.Cycle])]
    [SectionCombo("Single Target")]
    [AccessibilityCustomCombo]
    [ConflictingCombos(DragoonFullThrustCombo, DragoonChaosThrustCombo)]
    [CustomComboInfo("All-In-One Combo", "Replace Full Thrust and Chaos Thrust with the entire 10-part combo chain, auto-selecting the Chaos Thrust combo as needed to refresh Power Surge or the bleed\n\nNOTE: This can cause you to miss positionals.", DRG.JobID)]
    DragoonAllInOneCombo = 2216,

    [IconsCombo([DRG.RaidenThrust, UTL.ArrowLeft, DRG.Drakesbane, UTL.ArrowLeft, DRG.FangAndClaw, UTL.ArrowLeft, DRG.FullThrust, UTL.ArrowLeft, DRG.VorpalThrust, UTL.ArrowLeft, DRG.TrueThrust])]
    [ConflictingCombos(DragoonAllInOneCombo)]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Full Thrust Combo", "Replace Full Thrust with its combo chain.", DRG.JobID)]
    DragoonFullThrustCombo = 2204,

    [IconsCombo([DRG.RaidenThrust, UTL.ArrowLeft, DRG.Drakesbane, UTL.ArrowLeft, DRG.FangAndClaw, UTL.ArrowLeft, DRG.FullThrust, UTL.ArrowLeft, DRG.VorpalThrust, UTL.Blank, UTL.Blank2])]
    [SectionCombo("Single Target")]
    [ParentCombo(DragoonFullThrustCombo)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Vorpal Thrust Option", "Replace Full Thrust with its combo chain starting with Vorpal Thrust instead of True Thrust, while no combo is ongoing.", DRG.JobID)]
    DragoonFullThrustComboOption = 2210,

    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [ParentCombo(DragoonFullThrustCombo)]
    [CustomComboInfo("Double Chaos Thrust Option", "After using Disembowel, replicates the remainder of the Chaos Thrust combo on Full Thrust, starting at Chaos Thrust. Combined with the Double Full Thrust Option, this allows you to select which combo to use at the 2nd combo step, but the remainder of both combos will be on both buttons.", DRG.JobID)]
    DragoonDoubleChaosThrustComboOption = 2215,

    [IconsCombo([DRG.RaidenThrust, UTL.ArrowLeft, DRG.Drakesbane, UTL.ArrowLeft, DRG.WheelingThrust, UTL.ArrowLeft, DRG.ChaosThrust, UTL.ArrowLeft, DRG.Disembowel, UTL.ArrowLeft, DRG.TrueThrust])]
    [SectionCombo("Single Target")]
    [ConflictingCombos(DragoonAllInOneCombo)]
    [CustomComboInfo("Chaos Thrust Combo", "Replace Chaos Thrust with its combo chain.", DRG.JobID)]
    DragoonChaosThrustCombo = 2203,

    [IconsCombo([DRG.RaidenThrust, UTL.ArrowLeft, DRG.Drakesbane, UTL.ArrowLeft, DRG.WheelingThrust, UTL.ArrowLeft, DRG.ChaosThrust, UTL.ArrowLeft, DRG.Disembowel, UTL.Blank, UTL.Blank2])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [ParentCombo(DragoonChaosThrustCombo)]
    [CustomComboInfo("Chaos Thrust Disembowel Option", "Replace Chaos Thrust with its combo chain starting with Disembowel instead of True Thrust, while no combo is ongoing.", DRG.JobID)]
    DragoonChaosThrustComboOption = 2209,

    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [ParentCombo(DragoonChaosThrustCombo)]
    [CustomComboInfo("Double Full Thrust Option", "After using Vorpal Thrust, replicates the remainder of the Full Thrust combo on Chaos Thrust, starting at Full Thrust. Combined with the Double Choas Thrust Option, this allows you to select which combo to use at the 2nd combo step, but the remainder of both combos will be on both buttons.", DRG.JobID)]
    DragoonDoubleFullThrustComboOption = 2214,

    [IconsCombo([DRG.FullThrust, DRG.ChaosThrust, UTL.ArrowLeft, DRG.WyrmwindThrust, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Full Chaos Wyrmwind Feature", "Replace Full Thrust and Chaos Thrust with Wyrmwind Thrust when you have two Firstminds' Focus.", DRG.JobID)]
    DragoonFullChaosWyrmwindFeature = 2217,

    [IconsCombo([DRG.CoerthanTorment, UTL.ArrowLeft, DRG.SonicThrust, UTL.ArrowLeft, DRG.DoomSpike])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Coerthan Torment Combo", "Replace Coerthan Torment with its combo chain.", DRG.JobID)]
    DragoonCoerthanTormentCombo = 2202,

    [IconsCombo([DRG.CoerthanTorment, UTL.ArrowLeft, DRG.WyrmwindThrust, UTL.Blank, DRG.WyrmwindThrust, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Coerthan Torment Wyrmwind Feature", "Replace Coerthan Torment with Wyrmwind Thrust when you have two Firstminds' Focus.", DRG.JobID)]
    DragoonCoerthanWyrmwindFeature = 2207,

    [IconsCombo([DRG.Geirskogul, UTL.ArrowLeft, DRG.WyrmwindThrust, UTL.Blank, DRG.Geirskogul, UTL.Clock])]
    [SectionCombo("Ability features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Geirskogul to Wyrmwind Thrust", "Replace Geirskogul with Wyrmwind Thrust when available and Geirskogul or Nastrond are on cooldown.", DRG.JobID)]
    DragoonGeirskogulWyrmwindFeature = 2212,

    [IconsCombo([DRG.Stardiver, UTL.ArrowLeft, DRG.Nastrond, DRG.Geirskogul, UTL.Blank, DRG.Nastrond, UTL.Clock])]
    [SectionCombo("Ability features")]
    [ConflictingCombos(DragoonStardiverDragonfireDiveFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Stardiver to Nastrond", "Replace Stardiver with Nastrond when Nastrond is off-cooldown, and Geirskogul outside of Life of the Dragon.", DRG.JobID)]
    DragoonStardiverNastrondFeature = 2206,

    [IconsCombo([DRG.Stardiver, UTL.ArrowLeft, DRG.DragonfireDive, UTL.Blank, DRG.DragonfireDive, UTL.Clock])]
    [SectionCombo("Ability features")]
    [ConflictingCombos(DragoonStardiverNastrondFeature)]
    [SecretCustomCombo]
    [CustomComboInfo("Stardiver to Dragonfire Dive", "Replace Stardiver with Dragonfire Dive when the latter is off cooldown (and you have more than 7.5s of LotD left), or outside of Life of the Dragon.", DRG.JobID)]
    DragoonStardiverDragonfireDiveFeature = 2208,

    [IconsCombo([DRG.BattleLitany, UTL.ArrowLeft, DRG.LanceCharge, UTL.Blank, DRG.LanceCharge, UTL.Clock])]
    [SectionCombo("Buffs")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Lance Charge to Battle Litany", "Replace Lance Charge with Battle Litany when available and Lance Charge is on cooldown.", DRG.JobID)]
    DragoonLanceChargeFeature = 2213,

    #endregion
    // ====================================================================================
    #region GUNBREAKER

    [SectionCombo("Single Target")]
    [IconsCombo([GNB.SolidBarrel, UTL.ArrowLeft, GNB.BrutalShell, UTL.ArrowLeft, GNB.KeenEdge])]
    [CustomComboInfo("Solid Barrel Combo", "Replace Solid Barrel with its combo chain.", GNB.JobID)]
    GunbreakerSolidBarrelCombo = 3701,

    [SectionCombo("Single Target")]
    [IconsCombo([GNB.SolidBarrel, UTL.ArrowLeft, GNB.BurstStrike, UTL.Blank, UTL.Blank, UTL.Danger])]
    [ParentCombo(GunbreakerSolidBarrelCombo)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Burst Strike Feature", "Replace Solid Barrel with Burst Strike when charges are full.", GNB.JobID)]
    GunbreakerBurstStrikeFeature = 3710,

    [SectionCombo("Single Target")]
    [IconsCombo([GNB.BurstStrike, UTL.ArrowLeft, GNB.DoubleDown])]
    [AccessibilityCustomCombo]
    [ParentCombo(GunbreakerSolidBarrelCombo)]
    [CustomComboInfo("Double Down Burst Feature", "In addition to the Solid Barrel combo, replace it with Double Down when charges are full. Takes priority over Burst Strike.", GNB.JobID)]
    GunbreakerDoubleDownFeatureST = 3709,

    [SectionCombo("Single Target")]
    [IconsCombo([GNB.Hypervelocity, UTL.ArrowLeft, GNB.BurstStrike, UTL.Blank, GNB.Buffs.ReadyToBlast, UTL.Checkmark])]
    [CustomComboInfo("Burst Strike Continuation", "Replace Burst Strike with Continuation moves when appropriate.", GNB.JobID)]
    GunbreakerBurstStrikeCont = 3703,

    [SectionCombo("Single Target")]
    [IconsCombo([GNB.EyeGouge, UTL.ArrowLeft, GNB.WickedTalon, UTL.ArrowLeft, GNB.AbdomenTear, UTL.ArrowLeft, GNB.SavageClaw, UTL.ArrowLeft, GNB.JugularRip, UTL.ArrowLeft, GNB.GnashingFang])]
    [CustomComboInfo("Gnashing Fang Continuation", "Replace Gnashing Fang with Continuation moves when appropriate.", GNB.JobID)]
    GunbreakerGnashingFangCont = 3702,

    [SectionCombo("Single Target")]
    [IconsCombo([GNB.BurstStrike, UTL.ArrowLeft, GNB.GnashingFang])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Burst Strike into Gnashing Fang", "Replace Burst Strike with Gnashing Fang if available.", GNB.JobID)]
    GunbreakerBurstStrikeGnashingFang = 3724,

    [SectionCombo("Single Target")]
    [IconsCombo([GNB.BurstStrike, UTL.ArrowLeft, GNB.DangerZone])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Burst Strike into Danger Zone", "Replace Burst Strike with Danger Zone if available.", GNB.JobID)]
    GunbreakerBurstStrikeDangerZone = 3725,

    [SectionCombo("Area of Effect")]
    [IconsCombo([GNB.DemonSlaughter, UTL.ArrowLeft, GNB.DemonSlice])]
    [CustomComboInfo("Demon Slaughter Combo", "Replace Demon Slaughter with its combo chain.", GNB.JobID)]
    GunbreakerDemonSlaughterCombo = 3705,

    [SectionCombo("Area of Effect")]
    [IconsCombo([GNB.DemonSlaughter, UTL.ArrowLeft, GNB.FatedCircle, UTL.Blank, UTL.Blank, UTL.Danger])]
    [ParentCombo(GunbreakerDemonSlaughterCombo)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Fated Circle Feature", "In addition to the Demon Slaughter combo, add Fated Circle when charges are full.", GNB.JobID)]
    GunbreakerFatedCircleFeature = 3706,

    [SectionCombo("Area of Effect")]
    [IconsCombo([GNB.FatedCircle, UTL.ArrowLeft, GNB.DoubleDown])]
    [ParentCombo(GunbreakerDemonSlaughterCombo)]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Double Down Fated Feature", "In addition to the Demon Slaughter combo, replace it with Double Down when charges are full. Takes priority over Fated Circle.", GNB.JobID)]
    GunbreakerDoubleDownFeatureAoE = 3723,

    [SectionCombo("Area of Effect")]
    [IconsCombo([GNB.FatedCircle, UTL.ArrowLeft, GNB.FatedBrand, UTL.Blank, GNB.Buffs.ReadyToFated, UTL.Checkmark])]
    [CustomComboInfo("Fated Circle Continuation", "Replace Fated Circle with Continuation moves when appropriate.", GNB.JobID)]
    GunbreakerFatedCircleCont = 3714,

    [SectionCombo("No Mercy")]
    [IconsCombo([GNB.NoMercy, UTL.ArrowLeft, GNB.DoubleDown, UTL.Blank, GNB.Buffs.NoMercy, UTL.Checkmark])]
    [ConflictingCombos(GunbreakerNoMercyFeature)]
    [AccessibilityCustomCombo]
    [CustomComboInfo("No Mercy Always Double Down Feature", "Replace No Mercy with Double Down while No Mercy is active.", GNB.JobID)]
    GunbreakerNoMercyAlwaysDoubleDownFeature = 3713,

    [SectionCombo("No Mercy")]
    [IconsCombo([GNB.NoMercy, UTL.ArrowLeft, GNB.DoubleDown, UTL.Blank, GNB.SonicBreak, UTL.Clock])]
    [SecretCustomCombo]
    [CustomComboInfo("No Mercy Double Down Feature", "Replace No Mercy with Double Down while No Mercy is active, 2 cartridges are available, and Double Down is off cooldown.\nThis takes priority over the No Mercy Bow Shock/Sonic Break Feature.", GNB.JobID)]
    GunbreakerNoMercyDoubleDownFeature = 3712,

    [SectionCombo("No Mercy")]
    [IconsCombo([GNB.NoMercy, UTL.ArrowLeft, GNB.BowShock, UTL.Blank, GNB.SonicBreak, UTL.Clock])]
    [SecretCustomCombo]
    [CustomComboInfo("No Mercy Bow Shock", "Replace No Mercy with Bow Shock while No Mercy is active and Sonic Break has been used or the GCD is active.", GNB.JobID)]
    GunbreakerNoMercyFeature = 3708,

    [SectionCombo("Buffs")]
    [IconsCombo([GNB.BurstStrike, GNB.FatedCircle, UTL.ArrowLeft, GNB.Bloodfest, UTL.Blank, UTL.Blank, UTL.Danger])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Empty Bloodfest Feature", "Replace Burst Strike and Fated Circle with Bloodfest if the powder gauge is empty.", GNB.JobID)]
    GunbreakerEmptyBloodfestFeature = 3707,

    [SectionCombo("Buffs")]
    [IconsCombo([GNB.BowShock, UTL.Cycle, GNB.SonicBreak])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Sonic Shock Feature", "Replace both Sonic Break and Bow Shock with the former when it is available and you are not on GCD, and the latter when it is not on CD and either Sonic Break is not available or you are on GCD.", GNB.JobID)]
    GunbreakerBowShockSonicBreakFeature = 3704,

    [IconsCombo([GNB.Continuation, UTL.ArrowLeft, GNB.DangerZone, UTL.Cycle, GNB.SonicBreak, UTL.Cycle, GNB.DoubleDown, GNB.GnashingFang, GNB.BurstStrike, UTL.Cycle, GNB.DoubleDown, GNB.FatedCircle, UTL.Cycle, GNB.ReignOfBeasts])]
    [SectionCombo("Alternative Playstyle")]
    [SecretCustomCombo]
    [CustomComboInfo("Expanded Continuation Feature", "Replace Continuation with several abilities, giving a continuation-like followup to several abilities.\n" +
        "Becomes Bow Shock if it is available" +
        "Combo Danger Zone after Keen Edge or Brutal Shell" +
        "\nCombo Sonic Break after No Mercy" +
        "\nFollow up Solid Barrel with Double Down, Gnashing Fang combo, or Burst Strike" +
        "\nFollow up Demon Slaughter with Double Down or Fated Circle" +
        "\nFollow up Bloodfest with the Reign combo.", GNB.JobID)]
    GunbreakerExpandedContinuation = 3715,

    [IconsCombo([GNB.Continuation, UTL.ArrowLeft, GNB.BowShock, UTL.Cross])]
    [SectionCombo("Alternative Playstyle")]
    [ParentCombo(GunbreakerExpandedContinuation)]
    [SecretCustomCombo]
    [CustomComboInfo("Disable Bow Shock", "Disable Bow Shock when available for the Expanded Continuation.", GNB.JobID)]
    GunbreakerExpandedContinuationDisableBowShock = 3721,

    [IconsCombo([GNB.Continuation, UTL.ArrowLeft, GNB.DangerZone, UTL.Cross])]
    [SectionCombo("Alternative Playstyle")]
    [ParentCombo(GunbreakerExpandedContinuation)]
    [SecretCustomCombo]
    [CustomComboInfo("Disable Danger Zone", "Disable Danger Zone after Keen Edge or Brutal Shell for the Expanded Continuation.", GNB.JobID)]
    GunbreakerExpandedContinuationDisableDangerZone = 3722,

    [IconsCombo([GNB.Continuation, UTL.ArrowLeft, GNB.SonicBreak, UTL.Cross])]
    [SectionCombo("Alternative Playstyle")]
    [ParentCombo(GunbreakerExpandedContinuation)]
    [SecretCustomCombo]
    [CustomComboInfo("Disable Sonic Break", "Disable Sonic Break after No Mercy for the Expanded Continuation.", GNB.JobID)]
    GunbreakerExpandedContinuationDisableSonicBreak = 3717,

    [IconsCombo([GNB.Continuation, UTL.ArrowLeft, GNB.DoubleDown, GNB.GnashingFang, GNB.BurstStrike, UTL.Cross])]
    [SectionCombo("Alternative Playstyle")]
    [ParentCombo(GunbreakerExpandedContinuation)]
    [SecretCustomCombo]
    [CustomComboInfo("Disable Solid Barrel Follow-up", "Disable the follow up Solid Barrel with Double Down, Gnashing Fang combo, or Burst Strike.", GNB.JobID)]
    GunbreakerExpandedContinuationDisableSolidBarrel = 3718,

    [IconsCombo([GNB.Continuation, UTL.ArrowLeft, GNB.DoubleDown, GNB.FatedCircle, UTL.Cross])]
    [SectionCombo("Alternative Playstyle")]
    [ParentCombo(GunbreakerExpandedContinuation)]
    [SecretCustomCombo]
    [CustomComboInfo("Disable Demon Slaughter Follow-up", "Disable the follow up Demon Slaughter with Double Down or Fated Circle.", GNB.JobID)]
    GunbreakerExpandedContinuationDisableDemonSlaughter = 3719,

    [IconsCombo([GNB.Continuation, UTL.ArrowLeft, GNB.ReignOfBeasts, UTL.Cross])]
    [SectionCombo("Alternative Playstyle")]
    [ParentCombo(GunbreakerExpandedContinuation)]
    [SecretCustomCombo]
    [CustomComboInfo("Disable Bloodfest Follow-up", "Disable the follow up Bloodfest with the Reign combo.", GNB.JobID)]
    GunbreakerExpandedContinuationDisableBloodfest = 3720,

    [IconsCombo([GNB.Trajectory, UTL.ArrowLeft, GNB.LightningShot])]
    [SectionCombo("Level Synchronization")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Trajectory downgrade when level capped", "Replaces Trajectory with Lightning Shot when below level for it.", GNB.JobID)]
    GunbreakerTrajectoryDowngradeFeature = 3716,

    #endregion
    // ====================================================================================
    #region MACHINIST

    [IconsCombo([MCH.CleanShot, UTL.ArrowLeft, MCH.SplitShot, UTL.ArrowLeft, MCH.SlugShot])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("(Heated) Shot Combo", "Replace Clean Shot with its combo chain.", MCH.JobID)]
    MachinistMainCombo = 3101,

    [IconsCombo([MCH.CleanShot, UTL.ArrowLeft, MCH.HeatBlast, UTL.Blank, MCH.Buffs.Overheat, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ParentCombo(MachinistMainCombo)]
    [CustomComboInfo("Hypercharge Combo", "Replace Clean Shot combo with Heat Blast while overheated.", MCH.JobID)]
    MachinistHypercomboFeature = 3108,

    [IconsCombo([MCH.HotShot, UTL.Cycle, MCH.Drill, UTL.Cycle, MCH.Chainsaw])]
    [SectionCombo("Single Target")]
    [AccessibilityCustomCombo]
    [ConflictingCombos(MachinistHotShotChainsawFeature)]
    [CustomComboInfo("Hot Shot (Air Anchor) / Drill / Chainsaw Feature", "Replace Hot Shot (Air Anchor), Drill, and Chainsaw with whichever is available.", MCH.JobID)]
    MachinistHotShotDrillChainsawFeature = 3106,

    [IconsCombo([MCH.HotShot, UTL.Cycle, MCH.Chainsaw])]
    [SectionCombo("Single Target")]
    [SecretCustomCombo]
    [ConflictingCombos(MachinistHotShotDrillChainsawFeature)]
    [CustomComboInfo("Hot Shot (Air Anchor) / Chainsaw Feature", "Replace Hot Shot (Air Anchor) and Chainsaw with whichever is available.", MCH.JobID)]
    MachinistHotShotChainsawFeature = 3107,

    [IconsCombo([MCH.SpreadShot, UTL.ArrowLeft, MCH.AutoCrossbow, UTL.Blank, MCH.Buffs.Overheat, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Spread Shot Heat", "Replace Spread Shot with Auto Crossbow when overheated.", MCH.JobID)]
    MachinistSpreadShotFeature = 3102,

    [IconsCombo([MCH.Bioblaster, UTL.Cycle, MCH.Chainsaw])]
    [SectionCombo("Area of Effect")]
    [SecretCustomCombo]
    [CustomComboInfo("Bioblaster / Chainsaw Feature", "Replace Bioblaster with whichever of Bioblaster or Chainsaw is available.", MCH.JobID)]
    MachinistBioblasterChainsawFeature = 3111,

    [IconsCombo([MCH.HeatBlast, MCH.AutoCrossbow, UTL.ArrowLeft, MCH.Hypercharge, UTL.Blank, MCH.Buffs.Overheat, UTL.Cross])]
    [SectionCombo("Ability features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Hypercharge Feature", "Replace Heat Blast and Auto Crossbow with Hypercharge when not overheated.", MCH.JobID)]
    MachinistOverheatFeature = 3103,

    [IconsCombo([MCH.Hypercharge, UTL.ArrowLeft, MCH.Wildfire])]
    [SectionCombo("Ability features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Hyperfire Feature", "Replace Hypercharge with Wildfire if available and you have a target.", MCH.JobID)]
    MachinistHyperfireFeature = 3109,

    [IconsCombo([MCH.GaussRound, UTL.Cycle, MCH.Ricochet])]
    [SectionCombo("Ability features")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Gauss Round / Double Check & Ricochet / Checkmate Feature", "Replace Gauss Round / Double Check & Ricochet / Checkmate with one or the other depending on which has more charges.", MCH.JobID)]
    MachinistGaussRoundRicochetFeature = 3105,

    [IconsCombo([MCH.GaussRound, UTL.Cycle, MCH.Ricochet, UTL.Blank, MCH.Buffs.Overheat, UTL.Checkmark])]
    [SectionCombo("Ability features")]
    [SecretCustomCombo]
    [ParentCombo(MachinistGaussRoundRicochetFeature)]
    [CustomComboInfo("Gauss Round / Double Check & Ricochet / Checkmate Overheat Option", "Replace Gauss Round / Double Check & Ricochet / Checkmate with one or the other only while overheated.", MCH.JobID)]
    MachinistGaussRoundRicochetFeatureOption = 3110,

    [IconsCombo([MCH.RookOverdrive, UTL.ArrowLeft, MCH.RookAutoturret, UTL.Blank, MCH.RookAutoturret, UTL.Checkmark])]
    [SectionCombo("Ability features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Overdrive Feature", "Replace Rook Autoturret and Automaton Queen with Overdrive while active.", MCH.JobID)]
    MachinistOverdriveFeature = 3104,

    #endregion
    // ====================================================================================
    #region MONK

    [IconsCombo([MNK.Bootshine, UTL.ArrowLeft, MNK.DragonKick])]
    [SectionCombo("Single Target")]
    [ConflictingCombos(MonkMonkeyMode)]
    [CustomComboInfo("Opo Feature", "Replace Bootshine/Leaping Opo with Dragon Kick if you don't have any Opo's fury stack.", MNK.JobID)]
    MonkOpoFeature = 2017,

    [IconsCombo([MNK.Bootshine, UTL.ArrowLeft, MNK.SteeledPeak, UTL.Blank, MNK.SteeledMeditation, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ParentCombo(MonkOpoFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Opomatic Chakra Feature", "Replace Bootshine/Leaping Opo with Steel Peak/The Forbidden Chakra when your Fifth Chakra is open.", MNK.JobID)]
    MonkOpoChakraFeature = 2029,

    [IconsCombo([MNK.Bootshine, UTL.ArrowLeft, MNK.SteeledMeditation, UTL.Blank, UTL.OutOfBattle, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ParentCombo(MonkOpoFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Bootshine Steeled Meditation Feature", "Replace Bootshine/Leaping Opo with Steeled Meditation when out of combat and the Fifth Chakra is not open.", MNK.JobID)]
    MonkBootshineMeditationFeature = 2012,

    [IconsCombo([MNK.Bootshine, UTL.ArrowLeft, MNK.FormShift, UTL.Blank, UTL.OutOfBattle, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ParentCombo(MonkOpoFeature)]
    [SecretCustomCombo]
    [CustomComboInfo("Form Shift Feature", "Replace Bootshine/Leaping Opo with Form Shift when out of combat and you don't have Formless Fist.", MNK.JobID)]
    MonkBootshineFormShiftFeature = 2023,

    [IconsCombo([MNK.TrueStrike, UTL.ArrowLeft, MNK.TwinSnakes])]
    [SectionCombo("Single Target")]
    [ConflictingCombos(MonkMonkeyMode)]
    [CustomComboInfo("Raptor Feature", "Replace True Strike with Twin Snakes if you don't have any Raptor's fury stack.", MNK.JobID)]
    MonkRaptorFeature = 2018,

    [IconsCombo([MNK.SnapPunch, UTL.ArrowLeft, MNK.Demolish])]
    [SectionCombo("Single Target")]
    [ConflictingCombos(MonkMonkeyMode)]
    [CustomComboInfo("Coeurl Feature", "Replace Snap Punch with Demolish if you don't have any Coeurl's fury stack.", MNK.JobID)]
    MonkCoeurlFeature = 2019,

    [IconsCombo([MNK.PerfectBalance, UTL.ArrowLeft, MNK.MasterfulBlitz, UTL.Blank, UTL.Blank, UTL.Checkmark])]
    [SectionCombo("Masterful Blitz")]
    [CustomComboInfo("Perfect Balance Feature", "Replace Perfect Balance with Masterful Blitz when you have 3 Beast Chakra.", MNK.JobID)]
    MonkPerfectBalanceFeature = 2004,

    [IconsCombo([MNK.Bootshine, MNK.DragonKick, MNK.TrueStrike, MNK.TwinSnakes, MNK.SnapPunch, MNK.Demolish, UTL.ArrowLeft, MNK.MasterfulBlitz, UTL.Blank, UTL.Blank, UTL.Checkmark])]
    [SectionCombo("Masterful Blitz")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Single Target Perfect Balance Feature", "Replace Bootshine/Leaping Opo, Dragon Kick, True Strike/Rising Raptor, Twin Snakes, Snap Punch/Pouncing Coeurl and Demolish with Masterful Blitz if you have 3 Beast Chakra.", MNK.JobID)]
    MonkSTBalanceFeature = 2005,

    [IconsCombo([MNK.Rockbreaker, UTL.ArrowLeft, MNK.FourPointFury, UTL.ArrowLeft, MNK.ArmOfTheDestroyer, UTL.ArrowLeft, UTL.ArrowLeft, MNK.MasterfulBlitz])]
    [SectionCombo("Area of Effect")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Monk AoE Combo", "Replace Masterful Blitz with the AoE combo chain.", MNK.JobID)]
    MonkAoECombo = 2001,

    [IconsCombo([MNK.MasterfulBlitz, UTL.ArrowLeft, MNK.SteeledPeak, UTL.Blank, MNK.EnlightenedMeditation, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [AccessibilityCustomCombo]
    [ParentCombo(MonkAoECombo)]
    [CustomComboInfo("Automatic AoE Chakra Feature", "Replace Masterful Blitz with Enlightenment when your Fifth Chakra is open.", MNK.JobID)]
    MonkAoEAutoChakraFeature = 2028,

    [IconsCombo([MNK.MasterfulBlitz, UTL.ArrowLeft, MNK.EnlightenedMeditation, UTL.Blank, UTL.OutOfBattle, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [ParentCombo(MonkAoECombo)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Enlightened Meditation Feature", "Replace Masterful Blitz with Enlightened Meditation when out of combat and the Fifth Chakra is not open.", MNK.JobID)]
    MonkAoEMeditationFeature = 2025,

    [IconsCombo([MNK.MasterfulBlitz, UTL.ArrowLeft, MNK.FormShift, UTL.Blank, UTL.OutOfBattle, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [ParentCombo(MonkAoECombo)]
    [SecretCustomCombo]
    [CustomComboInfo("AoE Form Shift Feature", "Replace Masterful Blitz with Form Shift when out of combat and you don't have Formless Fist.", MNK.JobID)]
    MonkAoEFormShiftFeature = 2027,

    [IconsCombo([MNK.RiddleOfFire, UTL.ArrowLeft, MNK.Brotherhood, UTL.Blank, MNK.RiddleOfFire, UTL.Clock])]
    [SectionCombo("Self-Buffs")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Riddle of Brotherly Fire", "Replace Riddle of Fire with Brotherhood when on cooldown.", MNK.JobID)]
    MonkRiddleOfFireBrotherhood = 2009,

    [IconsCombo([MNK.RiddleOfFire, UTL.ArrowLeft, MNK.RiddleOfWind, UTL.Blank, MNK.RiddleOfFire, UTL.Clock])]
    [SectionCombo("Self-Buffs")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Riddle of Fire and Wind", "Replace Riddle of Fire with Riddle of Wind when on cooldown.", MNK.JobID)]
    MonkRiddleOfFireWind = 2010,

    [IconsCombo([MNK.Bootshine, UTL.ArrowLeft, UTL.Opo])]
    [SectionCombo("Monkey Mode")]
    [ConflictingCombos([MonkOpoFeature, MonkRaptorFeature, MonkCoeurlFeature])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Monkey Mode", "One-buttons the basic rotation on Bootshine/Leaping Opo. Neat for beginners, very, very bad for serious players.", MNK.JobID)]
    MonkMonkeyMode = 2021,

    [IconsCombo([MNK.Bootshine, UTL.ArrowLeft, MNK.SteeledPeak, UTL.Blank, MNK.SteeledMeditation, UTL.Checkmark])]
    [SectionCombo("Monkey Mode")]
    [ParentCombo(MonkMonkeyMode)]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Automatic Chakra Feature", "Replace Bootshine/Leaping Opo with The Forbidden Chakra when your Fifth Chakra is open.", MNK.JobID)]
    MonkMonkeyAutoChakraFeature = 2026,

    [IconsCombo([MNK.Bootshine, UTL.ArrowLeft, MNK.SteeledMeditation, UTL.Blank, UTL.OutOfBattle, UTL.Checkmark])]
    [SectionCombo("Monkey Mode")]
    [ParentCombo(MonkMonkeyMode)]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Monkey Bootshine Steeled Meditation Feature", "Replace Bootshine/Leaping Opo with Steeled Meditation when out of combat and the Fifth Chakra is not open.", MNK.JobID)]
    MonkMonkeyMeditationFeature = 2022,

    [IconsCombo([MNK.Bootshine, UTL.ArrowLeft, MNK.FormShift, UTL.Blank, UTL.OutOfBattle, UTL.Checkmark])]
    [SectionCombo("Monkey Mode")]
    [ParentCombo(MonkMonkeyMode)]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Monkey Form Shift Feature", "Replace Bootshine/Leaping Opo with Form Shift when out of combat and you don't have Formless Fist.", MNK.JobID)]
    MonkMonkeyFormShiftFeature = 2024,

    #endregion
    // ====================================================================================
    #region NINJA

    [IconsCombo([NIN.AeolianEdge, UTL.ArrowLeft, NIN.GustSlash, UTL.ArrowLeft, NIN.SpinningEdge])]
    [SectionCombo("Single Target")]
    [ConflictingCombos(NinjaKazematoiFeature)]
    [CustomComboInfo("Aeolian Edge Combo", "Replace Aeolian Edge with its combo chain.", NIN.JobID)]
    NinjaAeolianEdgeCombo = 3002,

    [IconsCombo([NIN.ArmorCrush, UTL.ArrowLeft, NIN.GustSlash, UTL.ArrowLeft, NIN.SpinningEdge])]
    [SectionCombo("Single Target")]
    [ConflictingCombos(NinjaKazematoiFeature)]
    [CustomComboInfo("Armor Crush Combo", "Replace Armor Crush with its combo chain.", NIN.JobID)]
    NinjaArmorCrushCombo = 3001,

    [IconsCombo([NIN.ArmorCrush, UTL.Cycle, NIN.AeolianEdge, UTL.ArrowLeft, NIN.GustSlash, UTL.ArrowLeft, NIN.SpinningEdge])]
    [SectionCombo("Single Target")]
    [AccessibilityCustomCombo]
    [ConflictingCombos([NinjaAeolianEdgeCombo, NinjaArmorCrushCombo])]
    [CustomComboInfo("Auto-Refill Kazematoi / Huton Feature", "Replace Aeolian Edge with Armor Crush when you don't have any Kazematoi left or with its combo chain else.", NIN.JobID)]
    NinjaKazematoiFeature = 3019,

    [IconsCombo([NIN.ArmorCrush, UTL.Cycle, NIN.AeolianEdge, UTL.ArrowLeft, NIN.GustSlash, UTL.ArrowLeft, NIN.SpinningEdge])]
    [SectionCombo("Single Target")]
    [SecretCustomCombo]
    [ParentCombo(NinjaKazematoiFeature)]
    [CustomComboInfo("Kazematoi Overcap Feature", "Instead only replace Armor Crush with Aeolian Edge when you are about to overcap Kazematoi stacks or with its combo chain else.", NIN.JobID)]
    NinjaOvercapKazematoiFeature = 3021,

    [IconsCombo([NIN.AeolianEdge, UTL.ArrowLeft, NIN.Ninjutsu, UTL.Blank, NIN.Ninjutsu, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Aeolian Edge / Ninjutsu Feature", "Replace Aeolian Edge with Ninjutsu if any Mudra are used.", NIN.JobID)]
    NinjaAeolianNinjutsuFeature = 3008,

    [IconsCombo([NIN.ArmorCrush, UTL.ArrowLeft, NIN.Ninjutsu, UTL.Blank, NIN.Ninjutsu, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Armor Crush / Ninjutsu Feature", "Replace Armor Crush with Ninjutsu if any Mudra are used.", NIN.JobID)]
    NinjaArmorCrushNinjutsuFeature = 3015,

    [IconsCombo([NIN.AeolianEdge, UTL.ArrowLeft, NIN.FleetingRaiju, UTL.Blank, NIN.Buffs.RaijuReady, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Aeolian Edge / Raiju Feature", "Replace the Aeolian Edge combo with Fleeting Raiju when available.", NIN.JobID)]
    NinjaAeolianEdgeRaijuFeature = 3013,

    [IconsCombo([NIN.ArmorCrush, UTL.ArrowLeft, NIN.ForkedRaiju, UTL.Blank, NIN.Buffs.RaijuReady, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Armor Crush / Raiju Feature", "Replace the Armor Crush combo with Forked Raiju when available.", NIN.JobID)]
    NinjaArmorCrushRaijuFeature = 3012,

    [IconsCombo([NIN.HakkeMujinsatsu, UTL.ArrowLeft, NIN.DeathBlossom])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Hakke Mujinsatsu Combo", "Replace Hakke Mujinsatsu with its combo chain.", NIN.JobID)]
    NinjaHakkeMujinsatsuCombo = 3003,

    [IconsCombo([NIN.HakkeMujinsatsu, UTL.ArrowLeft, NIN.Ninjutsu, UTL.Blank, NIN.Ninjutsu, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Hakke Mujinsatsu / Ninjutsu Feature", "Replace Hakke Mujinsatsu with Ninjutsu if any Mudra are used.", NIN.JobID)]
    NinjaHakkeMujinsatsuNinjutsuFeature = 3016,

    [IconsCombo([NIN.Ninjutsu, UTL.ArrowLeft, NIN.ForkedRaiju, UTL.Blank, NIN.Buffs.RaijuReady, UTL.Checkmark, NIN.Ninjutsu, UTL.Cross])]
    [SectionCombo("Ninjutsu features")]
    [ConflictingCombos(NinjaNinjutsuFleetingRaijuFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Ninjutsu / Forked Raiju Feature", "Replace Ninjutsu with Forked Raiju when available and no Mudra are active.", NIN.JobID)]
    NinjaNinjutsuForkedRaijuFeature = 3017,

    [IconsCombo([NIN.Ninjutsu, UTL.ArrowLeft, NIN.FleetingRaiju, UTL.Blank, NIN.Buffs.RaijuReady, UTL.Checkmark, NIN.Ninjutsu, UTL.Cross])]
    [SectionCombo("Ninjutsu features")]
    [ConflictingCombos(NinjaNinjutsuForkedRaijuFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Ninjutsu / Fleeting Raiju Feature", "Replace Ninjutsu with Fleeting Raiju when available and no Mudra are active.", NIN.JobID)]
    NinjaNinjutsuFleetingRaijuFeature = 3018,

    [IconsCombo([NIN.Kassatsu, UTL.ArrowLeft, NIN.TrickAttack, UTL.Blank, UTL.Blank, NIN.Buffs.ShadowWalker, NIN.Buffs.Hidden, UTL.Checkmark])]
    [SectionCombo("Ninjutsu features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Kassatsu to Trick", "Replace Kassatsu with Trick Attack while Suiton or Hidden is up.\nCooldown tracking plugin recommended.", NIN.JobID)]
    NinjaKassatsuTrickFeature = 3004,

    [IconsCombo([NIN.Chi, UTL.ArrowLeft, NIN.Jin, UTL.Blank, NIN.Buffs.Kassatsu, UTL.Checkmark])]
    [SectionCombo("Ninjutsu features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Kassatsu Chi/Jin Feature", "Replace Chi with Jin while Kassatsu is up if you have Enhanced Kassatsu.", NIN.JobID)]
    NinjaKassatsuChiJinFeature = 3006,

    [IconsCombo([NIN.TenChiJin, UTL.ArrowLeft, NIN.Meisui, UTL.Blank, NIN.Buffs.ShadowWalker, UTL.Checkmark])]
    [SectionCombo("Ninjutsu features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Ten Chi Jin to Meisui", "Replace Ten Chi Jin (the move) with Meisui while Suiton is up.\nCooldown tracking plugin recommended.", NIN.JobID)]
    NinjaTCJMeisuiFeature = 3005,

    [IconsCombo([NIN.Hide, UTL.ArrowLeft, NIN.Mug, UTL.Blank, NIN.Buffs.Hidden, UTL.OutOfBattle])]
    [SectionCombo("Hide features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Hide to Mug/Dokumori", "Replace Hide with Mug/Dokumori while in combat or hidden.", NIN.JobID)]
    NinjaHideMugFeature = 3007,

    [IconsCombo([NIN.Hide, UTL.ArrowLeft, NIN.Ninjutsu, UTL.Blank, NIN.Ninjutsu, UTL.Checkmark])]
    [SectionCombo("Hide features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Hide to Ninjutsu", "Replace Hide with Ninjutsu if any Mudra are active. Takes precedence over Hide to Mug/Dokumori.", NIN.JobID)]
    NinjaHideNinjutsuFeature = 3020,

    #endregion
    // ====================================================================================
    #region PALADIN

    [IconsCombo([PLD.RoyalAuthority, UTL.ArrowLeft, PLD.RiotBlade, UTL.ArrowLeft, PLD.FastBlade])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Royal Authority Combo", "Replace Royal Authority/Rage of Halone with its combo chain.", PLD.JobID)]
    PaladinRoyalAuthorityCombo = 1902,

    [IconsCombo([PLD.RoyalAuthority, UTL.ArrowLeft, PLD.Atonement, PLD.Supplication, PLD.Sepulchre])]
    [SectionCombo("Single Target")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Royal Authority Atonement Feature", "Replace Royal Authority with Atonement, Supplication & Sepulchre when under the effect of the corresponding buffs.\nNOTE: Does not require the Royal Authority Combo, if you prefer to do your standard 1-2-3 combo yourself.", PLD.JobID)]
    PaladinRoyalAuthorityAtonementComboFeature = 1903,

    [IconsCombo([PLD.RoyalAuthority, UTL.ArrowLeft, PLD.HolySpirit, UTL.Blank, PLD.Buffs.DivineMight, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Royal Authority Divine Might Feature", "Replace Royal Authority with Holy Spirit when Divine Might is active.", PLD.JobID)]
    PaladinRoyalAuthorityDivineMightFeature = 1912,

    [IconsCombo([PLD.Prominence, UTL.ArrowLeft, PLD.TotalEclipse])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Prominence Combo", "Replace Prominence with its combo chain.", PLD.JobID)]
    PaladinProminenceCombo = 1904,

    [IconsCombo([PLD.Prominence, UTL.ArrowLeft, PLD.HolyCircle, UTL.Blank, PLD.Buffs.DivineMight, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Prominence Divine Might Feature", "Replace Prominence with Holy Circle when Divine Might is active.", PLD.JobID)]
    PaladinProminenceDivineMightFeature = 1924,

    [IconsCombo([PLD.CircleOfScorn, UTL.Cycle, PLD.SpiritsWithin, UTL.Cycle, PLD.Expiacion])]
    [SectionCombo("Combined/Other")]
    [SecretCustomCombo]
    [CustomComboInfo("Scornful Spirits Feature", "Replace Spirits Within/Expiacion and Circle of Scorn with whichever is available soonest.", PLD.JobID)]
    PaladinScornfulSpiritsFeature = 1908,

    [IconsCombo([PLD.ShieldBash, UTL.ArrowLeft, ADV.LowBlow])]
    [SectionCombo("Combined/Other")]
    [ExpandedCustomCombo]
    [CustomComboInfo("One-Stop Stun Button", "Replace Shield Bash with Low Blow when the latter is off cooldown.", PLD.JobID)]
    PaladinShieldBashFeature = 1910,

    [IconsCombo([PLD.Requiescat, UTL.ArrowLeft, PLD.FightOrFlight])]
    [SectionCombo("Cooldowns")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Requiescat Fight or Flight Feature", "Replace Requiescat with Fight or Flight when off cooldown, when Goring Blade is available, or when Fight or Flight will be off cooldown sooner.\nNOTE: If enabled with Requiescat/Imperator Confiteor, Confiteor and its combo chain will be used prior to Goring Blade.", PLD.JobID)]
    PaladinRequiescatFightOrFlightFeature = 1914,

    [IconsCombo([PLD.Requiescat, UTL.ArrowLeft, PLD.Confiteor, PLD.BladeOfFaith, PLD.BladeOfTruth, PLD.BladeOfValor, PLD.BladeOfHonor])]
    [SectionCombo("Cooldowns")]
    [CustomComboInfo("Requiescat/Imperator Confiteor", "Replace Requiescat/Imperator with Confiteor and combo chain when available, and then with Holy Spirit if there are remaining charges.", PLD.JobID)]
    PaladinRequiescatConfiteorFeature = 1905,

    [IconsCombo([PLD.HolySpirit, PLD.HolyCircle, UTL.ArrowLeft, PLD.Confiteor, PLD.BladeOfFaith, PLD.BladeOfTruth, PLD.BladeOfValor, PLD.BladeOfHonor])]
    [SectionCombo("Cooldowns")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Holy Confiteor Feature", "Replace Holy Spirit/Circle with Confiteor and its combo chain when available.", PLD.JobID)]
    PaladinHolyConfiteorFeature = 1907,

    [IconsCombo([PLD.RoyalAuthority, PLD.Prominence, UTL.ArrowLeft, PLD.Confiteor, PLD.BladeOfFaith, PLD.BladeOfTruth, PLD.BladeOfValor, PLD.BladeOfHonor])]
    [SectionCombo("Cooldowns")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Combo Confiteor Feature", "Replace Royal Authority and Prominence with Confiteor and its combo chain when available.", PLD.JobID)]
    PaladinComboConfiteorFeature = 1917,

    [IconsCombo([PLD.RoyalAuthority, PLD.Atonement, PLD.FastBlade, PLD.RiotBlade, PLD.Supplication, PLD.HolySpirit, PLD.Sepulchre, UTL.Blank, UTL.Idea, UTL.Danger])]
    [SectionCombo("Cooldowns")]
    [SecretCustomCombo]
    [ParentCombo(PaladinComboConfiteorFeature)]
    [CustomComboInfo("Combo Optimize Fight or Flight GCDs", "This is an advance optimization feature that modifies several other combo features to ensure the highest potency attacks are used during the 'spare' 3 GCDs during Fight or Flight.\n\nSpecifically, this feature will delay usage of Divine Might, Supplication, and Sepulchre until they'd be overwritten by another Royal Authority usage, to ensure the next 3 GCDs can always be high-potency (460+) actions.  The actual order of usage of these 3 actions may be counter-intuitive, but they are used in the order and the rotational location that maximizes the potential potency during Fight or Flight, and are in line with rotational guidance from The Balance.  This feature will also dynamically determine which 3 abilities to use during Fight or Flight (after the Confiteor combo) to maximize the potency for those 3 GCDs, using Sepulchre, Supplication, and Holy Spirit, if available, and filling with Atonement and/or Royal Authority.\n\nNOTE: This feature interacts with the following combos, and it is HIGHLY recommended to enable all of them:\n- Royal Authority Atonement Feature\n- Combo Divine Might Feature\n- Combo Fight or Flight Divine Might Feature\n- Royal Authority Goring Blade Feature\n- Prominence Goring Blade Feature", PLD.JobID)]
    PaladinFoFOptimizeFeature = 1922,

    [IconsCombo([PLD.RoyalAuthority, PLD.Prominence, UTL.ArrowLeft, PLD.HolySpirit])]
    [SectionCombo("Cooldowns")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Combo Fight or Flight Divine Might Feature", "Replace Royal Authority with Holy Spirit and Prominence with Holy Circle while both Fight or Flight and Divine Might are active.", PLD.JobID)]
    PaladinFightOrFlightDivineMightFeature = 1915,

    [IconsCombo([PLD.RoyalAuthority, UTL.ArrowLeft, PLD.GoringBlade])]
    [SectionCombo("Cooldowns")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Royal Authority Goring Blade Feature", "Replace Royal Authority and Prominence with Goring Blade when available.\nNOTE: Used after the Confiteor combo if enabled with Combo Confiteor Feature.", PLD.JobID)]
    PaladinRoyalAuthorityGoringBladeFeature = 1918,

    [IconsCombo([PLD.Prominence, UTL.ArrowLeft, PLD.GoringBlade])]
    [SectionCombo("Cooldowns")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Prominence Goring Blade Feature", "Also replace Prominence with Goring Blade when available.\nNOTE: Used after the Confiteor combo if enabled with Combo Confiteor Feature.", PLD.JobID)]
    PaladinProminenceGoringBladeFeature = 1920,

    [IconsCombo([PLD.GoringBlade, UTL.Plus])]
    [SectionCombo("Cooldowns")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Goring Blade before Confiteor", "Use Goring Blade before the Confiteor combo, rather than after it, for any combos that combine the two on the same button.\nNOTE: This is generally not recommended, from an optimization perspective, but can help avoid lost Goring Blade usage if you have to disengage from the boss shortly after using Requiescat.  Confiteor will still be used over Goring Blade if you're not currently in melee range.", PLD.JobID)]
    PaladinGoringBladeBeforeConfiteorFeature = 1923,

    [IconsCombo([PLD.HolySpirit, UTL.ArrowLeft, PLD.ShieldLob])]
    [SectionCombo("Level Synchronization")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Holy Spirit Level Sync", "Replace Holy Spirit with Shield Lob when below level 64 in synced content.", PLD.JobID)]
    PaladinHolySpiritLevelSyncFeature = 1916,

    #endregion
    // ====================================================================================
    #region PICTOMANCER

    [IconsCombo([PCT.BlizzardCyan, UTL.ArrowLeft, PCT.FireRed, UTL.Blank, PCT.SubstractivePalette, UTL.Cross])]
    [SectionCombo("Substractive")]
    [CustomComboInfo("Subtractive Single-Target Combo", "Replace Blizzard in Cyan and its combo chain with Fire in Red and its combo chain when Subtractive Palette is not active.", PCT.JobID)]
    PictomancerSubtractiveSTCombo = 4201,

    [IconsCombo([PCT.ExtraBlizzardCyan, UTL.ArrowLeft, PCT.ExtraFireRed, UTL.Blank, PCT.SubstractivePalette, UTL.Cross])]
    [SectionCombo("Substractive")]
    [CustomComboInfo("Subtractive AoE Combo", "Replace Blizzard II in Cyan and its combo chain with Fire II in Red and its combo chain when Subtractive Palette is not active.", PCT.JobID)]
    PictomancerSubtractiveAoECombo = 4202,

    [IconsCombo([PCT.FireRed, UTL.ArrowLeft, PCT.SubstractivePalette, UTL.Blank, UTL.Blank, UTL.Danger])]
    [SectionCombo("Substractive")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Don't overcap Subtractive", "Replace Fire in Red and Fire II in Red, and their combo chains, with Subtractive Palette if the next cast in the chain would overcap the Palette Gauge.", PCT.JobID)]
    PictomancerSubtractiveAutoCombo = 4205,

    [IconsCombo([PCT.FireRed, UTL.ArrowLeft, PCT.SubstractivePalette, UTL.Blank, PCT.Buffs.SubstractivePalette, UTL.Checkmark])]
    [SectionCombo("Substractive")]
    [AccessibilityCustomCombo]
    [ParentCombo(CustomComboPreset.PictomancerSubtractiveAutoCombo)]
    [CustomComboInfo("Subtractive Early Autocast", "Do it as soon as you reach 50 Palette gauge or you are under the effect of Substractive Palette Ready instead.", PCT.JobID)]
    PictomancerSubtractiveEarlyAutoCombo = 4221,

    [IconsCombo([PCT.CreatureMotif, UTL.ArrowLeft, PCT.PomMuse, PCT.WingedMuse, PCT.ClawedMuse, PCT.FangedMuse, UTL.Blank, PCT.CreatureMotifDrawn, UTL.Checkmark])]
    [SectionCombo("Muses & Motifs")]
    [CustomComboInfo("Creature Muse/Motif Combo", "Replace Creature Motifs with Creature Muses when the Creature Canvas is painted.", PCT.JobID)]
    PictomancerCreatureMotifCombo = 4206,

    [IconsCombo([PCT.CreatureMotif, UTL.ArrowLeft, PCT.MogOftheAges, PCT.Retribution, UTL.Blank, PCT.MogOftheAges, PCT.Retribution, UTL.Checkmark])]
    [SectionCombo("Muses & Motifs")]
    [ParentCombo(PictomancerCreatureMotifCombo)]
    [CustomComboInfo("Creature Muse/Mog of the Ages Combo", "Also replace Creature Motifs with Mog of the Ages and Retribution of the Madeen when they are usable.", PCT.JobID)]
    PictomancerCreatureMogCombo = 4207,

    [IconsCombo([PCT.FireRed, PCT.ExtraFireRed, UTL.ArrowLeft, PCT.MogOftheAges, PCT.Retribution, UTL.Blank, PCT.MogOftheAges, PCT.Retribution, UTL.Checkmark])]
    [SectionCombo("Muses & Motifs")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Mog of the Ages Autocast", "Replace Fire in Red, Fire II in Red, Blizzard in Cyan, Blizzard II in Cyan, and their combo chains, with Mog of the Ages and Retribution of the Madeen when they are usable.", PCT.JobID)]
    PictomancerAutoMogCombo = 4220,

    [IconsCombo([PCT.HammerMotif, UTL.ArrowLeft, PCT.StrikingMuse, UTL.Blank, PCT.WeaponMotifDrawn, UTL.Checkmark])]
    [SectionCombo("Muses & Motifs")]
    [CustomComboInfo("Weapon Muse/Motif Combo", "Replace Hammer Motif with Striking Muse when the Weapon Canvas is painted.", PCT.JobID)]
    PictomancerWeaponMotifCombo = 4208,

    [IconsCombo([PCT.HammerMotif, UTL.ArrowLeft, PCT.HammerStamp, PCT.HammerBrush, PCT.PolishingHammer, UTL.Blank, PCT.Buffs.HammerReady, UTL.Checkmark])]
    [SectionCombo("Muses & Motifs")]
    [CustomComboInfo("Hammer Time", "Replace Hammer Motif with Hammer Brush and its combo chain when they are usable.", PCT.JobID)]
    PictomancerWeaponHammerCombo = 4209,

    [IconsCombo([PCT.LandscapeMotif, UTL.ArrowLeft, PCT.StarryMuse, UTL.Blank, PCT.LandscapeMotifDrawn, UTL.Checkmark])]
    [SectionCombo("Muses & Motifs")]
    [CustomComboInfo("Landscape Muse/Motif Combo", "Replace Starry Sky Motif with Starry Muse when the Landscape Canvas is painted.", PCT.JobID)]
    PictomancerLandscapeMotifCombo = 4210,

    [IconsCombo([PCT.StarryMuse, UTL.ArrowLeft, PCT.StarPrism1, UTL.Blank, PCT.Buffs.StarPrismReady, UTL.Checkmark])]
    [SectionCombo("Muses & Motifs")]
    [CustomComboInfo("Landscape Muse/Star Prism Combo", "Replace Starry Muse with Star Prism when it is usable.", PCT.JobID)]
    PictomancerLandscapePrismCombo = 4211,

    [IconsCombo([PCT.FireRed, UTL.ArrowLeft, PCT.StarryMuse, UTL.Blank, PCT.Buffs.StarPrismReady, UTL.Checkmark])]
    [SectionCombo("Muses & Motifs")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Star Prism Autocast", "Replace Fire in Red, Fire II in Red, Blizzard in Cyan, Blizzard II in Cyan, and their combo chains, with Star Prism when you have Star Prism Ready.", PCT.JobID)]
    PictomancerStarPrismAutoCombo = 4214,

    [IconsCombo([PCT.HolyInWhite, UTL.ArrowLeft, PCT.CometBlack, UTL.Blank, PCT.CometBlack, UTL.Checkmark])]
    [SectionCombo("Holy Comet")]
    [CustomComboInfo("Holy Comet Combo", "Replace Holy in White with Comet in Black when usable.", PCT.JobID)]
    PictomancerHolyCometCombo = 4203,

    [IconsCombo([PCT.HolyInWhite, UTL.ArrowLeft, PCT.RainbowDrip, UTL.Blank, PCT.Buffs.RainbowReady, UTL.Checkmark])]
    [SectionCombo("Holy Comet")]
    [ExpandedCustomCombo]
    [ParentCombo(PictomancerHolyCometCombo)]
    [CustomComboInfo("Rainbow Holy Combo", "Replace Holy in White with Rainbow Drip when under the effect of Rainbow Drip Ready (has priority over Comet in Black).", PCT.JobID)]
    PictomancerRainbowHolyCombo = 4215,

    [IconsCombo([PCT.FireRed, PCT.BlizzardCyan, UTL.ArrowLeft, PCT.HolyInWhite, UTL.Blank, PCT.HolyInWhite, UTL.Danger])]
    [SectionCombo("Holy Comet")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Holy Autocast", "Replace Fire in Red, Fire II in Red, Blizzard in Cyan, Blizzard II in Cyan, and their combo chains, with Holy or Comet if the next cast would overcap the Paint Gauge.", PCT.JobID)]
    PictomancerHolyAutoCombo = 4204,

    [IconsCombo([PCT.FireRed, UTL.ArrowLeft, PCT.RainbowDrip, UTL.Blank, PCT.Buffs.RainbowReady, UTL.Checkmark])]
    [SectionCombo("Rainbow Drip")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Rainbow Autocast", "Replace Fire in Red, Fire II in Red, Blizzard in Cyan, Blizzard II in Cyan, and their combo chains, with Rainbow Drip when you have Rainbow Drip Ready.", PCT.JobID)]
    PictomancerRainbowAutoCombo = 4213,

    [IconsCombo([PCT.FireRed, UTL.ArrowLeft, PCT.RainbowDrip, UTL.Blank, PCT.RainbowDrip, UTL.OutOfBattle])]
    [SectionCombo("Rainbow Drip")]
    [SecretCustomCombo]
    [CustomComboInfo("Rainbow Drip Starter", "Replace Fire in Red & Fire in Red II with Rainbow Drip when out of combat.", PCT.JobID)]
    PictomancerRainbowStarter = 4216,

    #endregion
    // ====================================================================================
    #region REAPER
    // Currently unused: 3913, 3914, 3915, 3919, 3920, 3921, 3922, 3923, 3924, 3927, 3928, 3929, 3935, 3941, 3946

    [IconsCombo([RPR.InfernalSlice, UTL.ArrowLeft, RPR.WaxingSlice, UTL.ArrowLeft, RPR.Slice])]
    [SectionCombo("Main Combos")]
    [CustomComboInfo("Slice Combo", "Replace Infernal Slice with its combo chain.", RPR.JobID)]
    ReaperSliceCombo = 3901,

    [IconsCombo([RPR.NightmareScythe, UTL.ArrowLeft, RPR.SpinningScythe])]
    [SectionCombo("Main Combos")]
    [CustomComboInfo("Scythe Combo", "Replace Nightmare Scythe with its combo chain.", RPR.JobID)]
    ReaperScytheCombo = 3902,

    [IconsCombo([RPR.BloodStalk, RPR.GrimSwathe, UTL.ArrowLeft, RPR.Gluttony])]
    [SectionCombo("Soul Gauge")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Soul Reaver Gluttony Feature", "Replace Blood Stalk and Grim Swathe with Gluttony whenever it is available.  This also applies to any other features that replace other actions with Blood Stalk or Grim Swathe.", RPR.JobID)]
    ReaperSoulReaverGluttonyFeature = 3916,

    [IconsCombo([RPR.InfernalSlice, RPR.NightmareScythe, UTL.ArrowLeft, RPR.SoulSlice, RPR.SoulScythe, UTL.Blank, UTL.Idea, UTL.Danger])]
    [SectionCombo("Soul Gauge")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Automatic Soul Slice", "Replace Infernal Slice with Soul Slice and Nightmare Scythe with Soul Scythe when a charge is available, you are not Reaving or Enshrouded, and you have 50 gauge or less.\n\nNOTE: This will not overcap your gauge by itself, but can easily cause you to overcap with a follow-up GCD when you suddenly gain much more gauge from a GCD than you expected.  It is highly recommended to also enable the Automatic Soul Reaver feature to avoid this.", RPR.JobID)]
    ReaperAutoSoulSliceFeature = 3951,

    [IconsCombo([RPR.SoulSlice, UTL.ArrowLeft, RPR.BloodStalk, UTL.Blank, UTL.Blank, UTL.Idea])]
    [SectionCombo("Soul Gauge")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Automatic Soul Reaver", "Replace all Soul Gauge generating abilities with Blood Stalk or Grim Swathe when at 50 or greater Soul Gauge and you're not currently Reaving or Enshrouded.  This does NOT apply to Harpe or Harvest Moon, however, since those are ranged attacks and also rarely used.\n\nNOTE: This can cause you to miss positionals or use the incorrect Reaving ability if you're not expecting the Blood Stalk usage.  It also has a very high chance of delaying your usage of Gluttony by not having enough gauge available when it comes off cooldown.", RPR.JobID)]
    ReaperAutoSoulReaverFeature = 3934,

    [IconsCombo([RPR.SoulSlice, UTL.ArrowLeft, RPR.BloodStalk, UTL.Blank, UTL.Blank, UTL.Danger])]
    [SectionCombo("Soul Gauge")]
    [ParentCombo(ReaperAutoSoulReaverFeature)]
    [SecretCustomCombo]
    [CustomComboInfo("Soul Reaver Overcap", "Only replace Soul Gauge generating abilities if their next usage would overcap Soul Gauge.\n\nNOTE: This will cause Soul Slice and Soul Scythe to be replaced much earlier than other actions, due to their greater gauge generation.", RPR.JobID)]
    ReaperReaperAutoBloodStalkOvercapFeature = 3948,

    [IconsCombo([RPR.InfernalSlice, UTL.ArrowLeft, RPR.Gibbet])]
    [SectionCombo("Soul Reaver")]
    [ConflictingCombos(ReaperSliceGallowsFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Slice Gibbet Feature", "Replace Infernal Slice with Gibbet while Reaving and Void Reaping while Enshrouded.", RPR.JobID)]
    ReaperSliceGibbetFeature = 3903,

    [IconsCombo([RPR.InfernalSlice, UTL.ArrowLeft, RPR.Gallows])]
    [SectionCombo("Soul Reaver")]
    [ConflictingCombos(ReaperSliceGibbetFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Slice Gallows Feature", "Replace Infernal Slice with Gallows while Reaving and Cross Reaping while Enshrouded.", RPR.JobID)]
    ReaperSliceGallowsFeature = 3904,

    [IconsCombo([RPR.SoulSlice, UTL.ArrowLeft, RPR.Gibbet])]
    [SectionCombo("Soul Reaver")]
    [ConflictingCombos(ReaperSoulGallowsFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Soul Gibbet Feature", "Replace Soul Slice with Gibbet while Reaving and Void Reaping while Enshrouded.", RPR.JobID)]
    ReaperSoulGibbetFeature = 3926,

    [IconsCombo([RPR.SoulSlice, UTL.ArrowLeft, RPR.Gallows])]
    [SectionCombo("Soul Reaver")]
    [ConflictingCombos(ReaperSoulGibbetFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Soul Gallows Feature", "Replace Soul Slice with Gallows while Reaving and Cross Reaping while Enshrouded.", RPR.JobID)]
    ReaperSoulGallowsFeature = 3925,

    [IconsCombo([RPR.ShadowOfDeath, UTL.ArrowLeft, RPR.Gibbet])]
    [SectionCombo("Soul Reaver")]
    [ConflictingCombos(ReaperShadowGallowsFeature)]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Shadow Gibbet Feature", "Replace Shadow of Death with Gibbet while Reaving (but NOT while Enshrouded).\n\nNOTE: Unlike the features for Slice and Soul Slice for Gibbet/Gallows, this feature only works when Reaving, not while Enshrouded.  There is a subfeature available below to also work while Enshrouded.", RPR.JobID)]
    ReaperShadowGibbetFeature = 3906,

    [IconsCombo([RPR.SoulSlice, UTL.ArrowLeft, RPR.BloodStalk, UTL.Blank, RPR.Buffs.Enshrouded, UTL.Danger])]
    [SectionCombo("Soul Reaver")]
    [ParentCombo(ReaperShadowGibbetFeature)]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Shadow Gibbet while Enshrouded", "Also replace Soul Slice when Enshrouded\n\nNOTE: This feature COMPLETELY prevents usage of Shadow of Death during Enshroud, which is a common element of Reaper gameplay, both for refreshing an expiring debuff and for delaying Communio when near raid buff windows.  It is strongly recommended not to use this feature, and to either use the Soul Slice Gibbet feature instead of the Shadow Gibbet one, or use the Slice Enhanced Enshrouded Feature to place all of the Enshrouded actions on the Slice/Scythe combo buttons instead.", RPR.JobID)]
    ReaperShadowGibbetEnshroudedFeature = 3949,

    [IconsCombo([RPR.ShadowOfDeath, UTL.ArrowLeft, RPR.Gallows])]
    [SectionCombo("Soul Reaver")]
    [ConflictingCombos(ReaperShadowGibbetFeature)]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Shadow Gallows Feature", "Replace Shadow of Death with Gallows while Reaving or Enshrouded.\n\nNOTE: Unlike the features for Slice and Soul Slice for Gibbet/Gallows, this feature only works when Reaving, not while Enshrouded.  There is a subfeature available below to also work while Enshrouded.", RPR.JobID)]
    ReaperShadowGallowsFeature = 3905,

    [IconsCombo([RPR.SoulSlice, UTL.ArrowLeft, RPR.BloodStalk, UTL.Blank, RPR.Buffs.Enshrouded, UTL.Danger])]
    [SectionCombo("Soul Reaver")]
    [ParentCombo(ReaperShadowGallowsFeature)]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Shadow Gallows while Enshrouded", "Also replace Soul Slice when Enshrouded\n\nNOTE: This feature COMPLETELY prevents usage of Shadow of Death during Enshroud, which is a common element of Reaper gameplay, both for refreshing an expiring debuff and for delaying Communio when near raid buff windows.  It is strongly recommended not to use this feature, and to either use the Soul Slice Gallows feature instead of the Shadow Gibbet one, or use the Slice Enhanced Enshrouded Feature to place all of the Enshrouded actions on the Slice/Scythe combo buttons instead.", RPR.JobID)]
    ReaperShadowGallowsEnshroudedFeature = 3950,

    [IconsCombo([RPR.NightmareScythe, UTL.ArrowLeft, RPR.Guillotine])]
    [SectionCombo("Soul Reaver")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Scythe Guillotine Feature", "Replace Nightmare Scythe with Guillotine while Reaving or Enshrouded.", RPR.JobID)]
    ReaperScytheGuillotineFeature = 3907,

    [IconsCombo([RPR.Gibbet, UTL.Cycle, RPR.Gallows])]
    [SectionCombo("Soul Reaver")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Soul Reaver Enhanced Feature", "Replace Gibbet and Gallows with whichever is currently enhanced while Reaving.  This also applies to any other features that replace other actions with Gibbet or Gallows.\n\nNOTE: This can cause you to miss positionals on Gibbet and Gallows. ", RPR.JobID)]
    ReaperSoulReaverEnhancedFeature = 3917,

    [IconsCombo([RPR.CrossReaping, UTL.Cycle, RPR.VoidReaping, UTL.Blank, RPR.Buffs.Enshrouded, UTL.Checkmark])]
    [SectionCombo("Enshroud")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Reaping Enhanced Feature", "Replace Void Reaping and Cross Reaping with whichever is currently enhanced while Enshrouded.  This also applies to any other features that replace other actions with Void Reaping or Cross Reaping.", RPR.JobID)]
    ReaperReapingEnhancedFeature = 3918,

    [IconsCombo([RPR.VoidReaping, RPR.CrossReaping, RPR.GrimReaping, UTL.ArrowLeft, RPR.Communio, UTL.Blank, UTL.Blank, UTL.Idea])]
    [SectionCombo("Enshroud")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Reaping Communio Feature", "Replace Void Reaping, Cross Reaping, and Grim Reaping with Communio when one stack of Shroud is left.  This also applies to any other features that replace other actions with Void Reaping,  Cross Reaping, or Grim Reaping.", RPR.JobID)]
    ReaperSoulReaverCommunioFeature = 3912,

    [IconsCombo([RPR.VoidReaping, RPR.CrossReaping, RPR.GrimReaping, UTL.ArrowLeft, RPR.LemuresSlice, RPR.LemuresScythe, UTL.Blank, UTL.Blank, UTL.Idea])]
    [SectionCombo("Enshroud")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Reaping Lemure's Feature", "Replace Void Reaping and Cross Reaping with Lemure's Slice and Grim Reaping with Lemure's Scythe when two or more stacks of Void Shroud are active.  This also applies to any other features that replace other actions with Void Reaping, Cross Reaping, or Grim Reaping.", RPR.JobID)]
    ReaperSoulReaverLemuresFeature = 3911,

    [IconsCombo([RPR.LemuresSlice, RPR.LemuresScythe, UTL.ArrowLeft, RPR.Sacrificium, UTL.Blank, RPR.Buffs.Oblatio, UTL.Checkmark])]
    [SectionCombo("Enshroud")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Lemure's Sacrificium Feature", "Replace Lemure's Slice/Scythe with Sacrificium when available and you have fewer than 2 Void Shroud.  This also applies to any other features that replace other actions with Lemure's Slice or Lemure's Scythe.", RPR.JobID)]
    ReaperLemuresSacrificiumFeature = 3940,

    [IconsCombo([RPR.Sacrificium, UTL.Clock])]
    [SectionCombo("Enshroud")]
    [SecretCustomCombo]
    [ParentCombo(ReaperLemuresSacrificiumFeature)]
    [CustomComboInfo("Sacrificium 3rd weave", "Only replace Lemure's Slice/Scythe with Sacrificium when you have used 3 of the 5 Lemure's Shroud charges (ie. after the third Void/Cross Reaping).\n\nNOTE: This can be superior for certain cooldown windows, due to the first weave window often occurring before raid buffs are active during a double Enshroud sequence.", RPR.JobID)]
    ReaperSacrificiumAdvancedFeature = 3947,

    [IconsCombo([RPR.Enshroud, UTL.ArrowLeft, RPR.Communio, UTL.Blank, RPR.Buffs.Enshrouded, UTL.Checkmark])]
    [SectionCombo("Enshroud")]
    [CustomComboInfo("Enshroud Communio Feature", "Replace Enshroud with Communio when Enshrouded.", RPR.JobID)]
    ReaperEnshroudCommunioFeature = 3909,

    [IconsCombo([RPR.Enshroud, UTL.ArrowLeft, RPR.Perfectio, UTL.Blank, RPR.Buffs.PerfectioParata, UTL.Checkmark])]
    [SectionCombo("Enshroud")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Enshroud Perfectio Feature", "Replace Enshroud with Perfectio when available.", RPR.JobID)]
    ReaperEnshroudPerfectioFeature = 3945,

    [IconsCombo([RPR.ArcaneCircle, UTL.ArrowLeft, RPR.PlentifulHarvest, UTL.Blank, RPR.Buffs.ImmortalSacrifice, UTL.Checkmark])]
    [SectionCombo("Arcane Circle")]
    [CustomComboInfo("Arcane Harvest Feature", "Replace Arcane Circle with Plentiful Harvest when you have stacks of Immortal Sacrifice.", RPR.JobID)]
    ReaperArcaneHarvestFeature = 3908,

    [IconsCombo([RPR.PlentifulHarvest, UTL.ArrowLeft, RPR.Perfectio, UTL.Blank, RPR.Buffs.PerfectioParata, UTL.Checkmark])]
    [SectionCombo("Arcane Circle")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Perfect Harvest Feature", "Replace Plentiful Harvest with Perfectio when available.  This also applies to any other features that replace other actions with Plentiful Harvest.", RPR.JobID)]
    ReaperPerfectHarvestFeature = 3943,

    [IconsCombo([RPR.InfernalSlice, RPR.NightmareScythe, UTL.ArrowLeft, RPR.Perfectio, UTL.Blank, RPR.Buffs.PerfectioParata, UTL.Checkmark])]
    [SectionCombo("Arcane Circle")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Combo Perfectio Feature", "Replace Infernal Slice and Nightmare Scythe with Perfectio when under Perfectio Parata.", RPR.JobID)]
    ReaperComboPerfectioFeature = 3942,

    [IconsCombo([RPR.Harpe, UTL.ArrowLeft, RPR.Perfectio, UTL.Blank, RPR.Buffs.PerfectioParata, UTL.Checkmark])]
    [SectionCombo("Arcane Circle")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Harpe Perfectio Feature", "Replace Harpe with with Perfectio when under Perfectio Parata.", RPR.JobID)]
    ReaperHarpePerfectioFeature = 3944,

    [IconsCombo([RPR.HellsIngress, RPR.HellsEgress, UTL.ArrowLeft, RPR.Regress, UTL.Blank, RPR.Buffs.Threshold])]
    [SectionCombo("Miscellaneous")]
    [CustomComboInfo("Regress Feature", "Replace Hell's Ingress and Egress turn with Regress when Threshold is active, instead of just the opposite of the one used.", RPR.JobID)]
    ReaperRegressFeature = 3910,

    [IconsCombo([RPR.Buffs.Threshold, UTL.Clock])]
    [SectionCombo("Miscellaneous")]
    [ParentCombo(ReaperRegressFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Delayed Regress Option", "Replace the action used with Regress only after 1.5 seconds have elapsed on Threshold.\n\nNOTE: This is to prevent you from immediately using Regress if you are spamming the button for the teleport.", RPR.JobID)]
    ReaperRegressOption = 3933,

    [IconsCombo([RPR.Harpe, UTL.ArrowLeft, RPR.HarvestMoon])]
    [SectionCombo("Harvest Moon")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Harpe Harvest Moon Feature", "Replace Harpe with Harvest Moon when Soulsow is active.", RPR.JobID)]
    ReaperHarpeHarvestMoonFeature = 3937,

    [IconsCombo([UTL.Forbidden, RPR.Buffs.EnhancedHarpe])]
    [SectionCombo("Harvest Moon")]
    [ParentCombo(ReaperHarpeHarvestMoonFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Enhanced Harpe Option", "Prevent replacing Harpe with Harvest Moon when Enhanced Harpe is active.", RPR.JobID)]
    ReaperHarpeHarvestMoonEnhancedFeature = 3939,

    [IconsCombo([UTL.Forbidden, UTL.OutOfBattle])]
    [SectionCombo("Harvest Moon")]
    [ParentCombo(ReaperHarpeHarvestMoonFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Harpe Harvest Moon Only In Combat", "Prevent replacing Harpe with Harvest Moon when not in combat.", RPR.JobID)]
    ReaperHarpeHarvestMoonCombatFeature = 3938,

    [IconsCombo([RPR.NightmareScythe, UTL.ArrowLeft, RPR.HarvestMoon])]
    [SectionCombo("Harvest Moon")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Scythe Harvest Moon Feature", "Replace Nightmare Scythe with Harvest Moon when Soulsow is active, you have an enemy target, and are not Reaving or Enshrouded.", RPR.JobID)]
    ReaperScytheHarvestMoonFeature = 3932,

    [IconsCombo([RPR.Harpe, UTL.ArrowLeft, RPR.Soulsow, UTL.Blank, UTL.OutOfBattle])]
    [SectionCombo("Harvest Moon")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Harpe Soulsow Feature", "Replace Harpe with Soulsow when not active and you're either out of combat or have no target.", RPR.JobID)]
    ReaperHarpeHarvestSoulsowFeature = 3936,

    [IconsCombo([RPR.InfernalSlice, UTL.ArrowLeft, RPR.Soulsow, UTL.Blank, UTL.OutOfBattle])]
    [SectionCombo("Harvest Moon")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Slice Soulsow Feature", "Replace Infernal Slice with Soulsow when not active and out of combat.", RPR.JobID)]
    ReaperSliceSoulsowFeature = 3930,

    [IconsCombo([RPR.NightmareScythe, UTL.ArrowLeft, RPR.Soulsow, UTL.Blank, UTL.OutOfBattle])]
    [SectionCombo("Harvest Moon")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Scythe Soulsow Feature", "Replace Nightmare Scythe with Soulsow when not active and out of combat.", RPR.JobID)]
    ReaperScytheSoulsowFeature = 3931,

    #endregion
    // ====================================================================================
    #region RED MAGE
    [IconsCombo([RDM.Verstone, RDM.Verfire, UTL.ArrowLeft, RDM.Jolt, UTL.Blank, RDM.Buffs.VerstoneReady, RDM.Buffs.VerfireReady, UTL.Cross])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Verstone/Verfire Feature", "Replace Verstone/Verfire with Jolt when no proc is available.", RDM.JobID)]
    RedMageVerprocFeature = 3504,

    [IconsCombo([RDM.Verstone, RDM.Verfire, UTL.ArrowLeft, RDM.GrandImpact, UTL.Cross, UTL.Blank, RDM.Buffs.VerstoneReady, RDM.Buffs.VerfireReady, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ParentCombo(RedMageVerprocFeature)]
    [SecretCustomCombo]
    [CustomComboInfo("Deprioritize Grand Impact", "After using Acceleration, prioritize using Verstone/Verfire over Grand Impact if both buffs are active.", RDM.JobID)]
    RedMageVerprocGrandImpactDeprioritize = 3519,

    [IconsCombo([RDM.Verstone, RDM.Verfire, UTL.ArrowLeft, RDM.Veraero, RDM.Verthunder, UTL.Blank, RDM.Acceleration, ADV.Swiftcast, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Verstone/Verfire Plus Feature", "Replace Verstone/Verfire with Veraero/Verthunder when various instant-cast effects are active.", RDM.JobID)]
    RedMageVerprocPlusFeature = 3505,

    [IconsCombo([RDM.Veraero, RDM.Verthunder, UTL.ArrowLeft, RDM.GrandImpact, UTL.Cross, UTL.Blank, RDM.Buffs.VerstoneReady, RDM.Buffs.VerfireReady, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ParentCombo(RedMageVerprocPlusFeature)]
    [SecretCustomCombo]
    [CustomComboInfo("Deprioritize Grand Impact Plus", "After using Acceleration, prioritize using Veraero/Verthunder over Grand Impact if both buffs are active.", RDM.JobID)]
    RedMageGrandImpactDeprioritize = 3517,

    [IconsCombo([RDM.Verstone, RDM.Verfire, UTL.ArrowLeft, RDM.Verflare, RDM.Verholy, UTL.Blank, RDM.Verflare, RDM.Verholy, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Verstone/Verfire Mana Stacks Feature", "Replace Verstone/Verfire with Verflare/Verholy at 3 mana stacks.", RDM.JobID)]
    RedMageVerprocManaStacksFeature = 3515,

    [IconsCombo([RDM.Verstone, RDM.Verfire, UTL.ArrowLeft, RDM.Scorch, RDM.Resolution, UTL.Blank, RDM.Scorch, RDM.Resolution, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Verstone/Verfire Capstone Combo", "Replace Verstone/Verfire with Scorch and Resolution when available.", RDM.JobID)]
    RedMageVerprocCapstoneCombo = 3513,

    [IconsCombo([RDM.Verstone, RDM.Verfire, UTL.ArrowLeft, RDM.Prefulgence, UTL.Blank, RDM.Buffs.PrefulgenceReady, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [AccessibilityCustomCombo]
    [ParentCombo(RedMageVerprocCapstoneCombo)]
    [CustomComboInfo("Verstone/Verfire Prefulgence Combo", "Also replace Verstone/Verfire by Refulgence when ready.", RDM.JobID)]
    RedMageVerprocCapstonePrefulgenceCombo = 3520,

    [IconsCombo([RDM.Veraero, RDM.Verthunder, UTL.ArrowLeft, RDM.Scorch, RDM.Resolution, UTL.Blank, RDM.Scorch, RDM.Resolution, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Veraero/Verthunder Capstone Combo", "Replace Veraero/Verthunder with Scorch and Resolution when available.", RDM.JobID)]
    RedMageVeraeroVerthunderCapstoneCombo = 3512,

    [IconsCombo([RDM.Veraero, RDM.Verthunder, UTL.ArrowLeft, RDM.Prefulgence, UTL.Blank, RDM.Buffs.PrefulgenceReady, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [AccessibilityCustomCombo]
    [ParentCombo(RedMageVeraeroVerthunderCapstoneCombo)]
    [CustomComboInfo("Veraero/Verthunder Prefulgence Combo", "Also replace Veraero/Verthunder by Refulgence when ready.", RDM.JobID)]
    RedMageVeraeroVerthunderCapstonePrefulgenceCombo = 3521,

    [IconsCombo([RDM.Verstone, UTL.ArrowLeft, RDM.Veraero, UTL.Blank, UTL.OutOfBattle, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [SecretCustomCombo]
    [CustomComboInfo("Verstone/Verfire Plus Opener Feature (Stone)", "Replace Verstone with Veraero when out of combat.", RDM.JobID)]
    RedMageVerprocOpenerStoneFeature = 3506,

    [IconsCombo([RDM.Verfire, UTL.ArrowLeft, RDM.Verthunder, UTL.Blank, UTL.OutOfBattle, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [SecretCustomCombo]
    [CustomComboInfo("Verstone/Verfire Plus Opener Feature (Fire)", "Replace Verfire with Verthunder when out of combat.", RDM.JobID)]
    RedMageVerprocOpenerFireFeature = 3507,

    [IconsCombo([RDM.Veraero2, RDM.Verthunder2, UTL.ArrowLeft, RDM.Impact, UTL.Blank, RDM.Buffs.Acceleration, ADV.Buffs.Swiftcast, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("AoE Combo", "Replace Veraero/Verthunder 2 with Impact when various instant-cast effects are active.", RDM.JobID)]
    RedMageAoEFeature = 3501,

    [IconsCombo([RDM.Veraero2, RDM.Verthunder2, UTL.ArrowLeft, RDM.Scorch, RDM.Resolution, UTL.Blank, RDM.Scorch, RDM.Resolution, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [ExpandedCustomCombo]
    [CustomComboInfo("AoE Capstone Combo", "Replace Veraero/Verthunder 2 with Scorch and Resolution when available.", RDM.JobID)]
    RedMageAoECapstoneCombo = 3514,

    [IconsCombo([RDM.Veraero2, RDM.Verthunder2, UTL.ArrowLeft, RDM.Prefulgence, UTL.Blank, RDM.Buffs.PrefulgenceReady, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [AccessibilityCustomCombo]
    [ParentCombo(RedMageAoECapstoneCombo)]
    [CustomComboInfo("AoE Capstone Prefulgence Combo", "Also replace Veraero/Verthunder 2 by Refulgence when ready.", RDM.JobID)]
    RedMageAoECapstonePrefulgenceCombo = 3522,

    [IconsCombo([RDM.EnchantedRedoublement, RDM.Redoublement, UTL.ArrowLeft, RDM.EnchantedZwerchhau, RDM.Zwerchhau, UTL.ArrowLeft, RDM.EnchantedRiposte, RDM.Riposte])]
    [SectionCombo("Melee features")]
    [CustomComboInfo("Melee Combo", "Replace Redoublement with its combo chain, following enchantment rules.", RDM.JobID)]
    RedMageMeleeCombo = 3502,

    [IconsCombo([RDM.Redoublement, RDM.Moulinet, UTL.ArrowLeft, RDM.Scorch, RDM.Resolution, UTL.Blank, RDM.Scorch, RDM.Resolution, UTL.Checkmark])]
    [SectionCombo("Melee features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Melee Capstone Combo", "Replace Redoublement and Moulinet with Scorch, Resolution when available.", RDM.JobID)]
    RedMageMeleeCapstoneCombo = 3503,

    [IconsCombo([RDM.Redoublement, RDM.Moulinet, UTL.ArrowLeft, RDM.Prefulgence, UTL.Blank, RDM.Buffs.PrefulgenceReady, UTL.Checkmark])]
    [SectionCombo("Melee features")]
    [AccessibilityCustomCombo]
    [ParentCombo(RedMageMeleeCapstoneCombo)]
    [CustomComboInfo("Melee Capstone Prefulgence Combo", "Also replace Redoublement and Moulinet by Refulgence when ready.", RDM.JobID)]
    RedMageMeleeCapstonePrefulgenceCombo = 3523,

    [IconsCombo([RDM.Redoublement, RDM.Moulinet, UTL.ArrowLeft, RDM.Verflare, RDM.Verholy, UTL.Blank, RDM.Verflare, RDM.Verholy, UTL.Checkmark])]
    [SectionCombo("Melee features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Melee Mana Stacks Feature", "Replace Redoublement and Moulinet with Verflare/Verholy at 3 mana stacks, using whichever mana color is lower.", RDM.JobID)]
    RedMageMeleeManaStacksFeature = 3516,

    [IconsCombo([RDM.ContreSixte, UTL.Cycle, RDM.Fleche])]
    [SectionCombo("Abilities features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Contre Sixte / Fleche Feature", "Replace Contre Sixte and Fleche with whichever is available.", RDM.JobID)]
    RedMageContreFlecheFeature = 3508,

    [IconsCombo([RDM.Embolden, UTL.ArrowLeft, RDM.Manafication, UTL.Blank, RDM.Embolden, UTL.Clock])]
    [SectionCombo("Abilities features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Embolden to Manafication", "Replace Embolden with Manafication if the former is on cooldown and the latter is not.", RDM.JobID)]
    RedMageEmboldenFeature = 3510,

    [IconsCombo([RDM.Acceleration, UTL.ArrowLeft, RDM.GrandImpact])]
    [SectionCombo("Abilities features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Acceleration into Grand Impact", "Replace Acceleration with Grand Impact when available.", RDM.JobID)]
    RedMageAccelerationGrandImpactFeature = 3518,

    [IconsCombo([RDM.Acceleration, UTL.ArrowLeft, ADV.Swiftcast, UTL.Blank, RDM.Acceleration, UTL.Cross])]
    [SectionCombo("Abilities features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Acceleration into Swiftcast", "Replace Acceleration with Swiftcast when on cooldown or synced.", RDM.JobID)]
    RedMageAccelerationSwiftcastFeature = 3509,

    [IconsCombo([RDM.Acceleration, UTL.ArrowLeft, ADV.Swiftcast, UTL.Blank, ADV.Swiftcast, UTL.Checkmark])]
    [SectionCombo("Abilities features")]
    [ParentCombo(RedMageAccelerationSwiftcastFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Acceleration with Swiftcast first", "Replace Acceleration with Swiftcast when neither are on cooldown.", RDM.JobID)]
    RedMageAccelerationSwiftcastOption = 3511,

    #endregion
    // ====================================================================================
    #region SAGE

    [IconsCombo([SGE.Dosis, UTL.ArrowLeft, SGE.Eukrasia, UTL.Blank, SGE.Debuffs.EukrasianDosis, UTL.Clock])]
    [SectionCombo("Single Target")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Auto Eukrasian Dosis", "Replace Dosis with Eukrasia when Eukrasian Dosis is about to run out.", SGE.JobID)]
    SageDoTFeature = 4012,

    [IconsCombo([SGE.Dosis, UTL.ArrowLeft, SGE.Psyche, UTL.Blank, SGE.Psyche, UTL.Clock])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Dosis Psyche Feature", "Replace Dosis with Psyche when cooldown is available.", SGE.JobID)]
    SageDosisPsyche = 4014,

    [IconsCombo([SGE.Dyskrasia, UTL.ArrowLeft, SGE.Psyche, UTL.Blank, SGE.Psyche, UTL.Clock])]
    [SectionCombo("Area of Effect")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Dyskrasia Psyche Feature", "Replace Dyskrasia with Psyche when cooldown is available.", SGE.JobID)]
    SagePsycheDyskrasiaFeature = 4015,

    [IconsCombo([SGE.Dosis, UTL.ArrowLeft, SGE.Kardia, UTL.Blank, SGE.Buffs.Kardion, UTL.Cross])]
    [SectionCombo("Kardia features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Dosis Kardia Feature", "Replace Dosis with Kardia when missing Kardion.", SGE.JobID)]
    SageDosisKardiaFeature = 4010,

    [IconsCombo([SGE.Soteria, UTL.ArrowLeft, SGE.Kardia, UTL.Blank, SGE.Buffs.Kardion, UTL.Cross])]
    [SectionCombo("Kardia features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Soteria Kardia Feature", "Replace Soteria with Kardia when off cooldown and missing Kardion.", SGE.JobID)]
    SageSoteriaKardionFeature = 4006,

    [IconsCombo([SGE.Druochole, UTL.ArrowLeft, SGE.Rhizomata, UTL.Blank, UTL.Blank, UTL.Danger])]
    [SectionCombo("Rhizomata features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Druochole into Rhizomata Feature", "Replace Druochole with Rhizomata when Addersgall is empty.", SGE.JobID)]
    SageDruocholeRhizomataFeature = 4003,

    [IconsCombo([SGE.Ixochole, UTL.ArrowLeft, SGE.Rhizomata, UTL.Blank, UTL.Blank, UTL.Danger])]
    [SectionCombo("Rhizomata features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Ixochole into Rhizomata Feature", "Replace Ixochole with Rhizomata when Addersgall is empty.", SGE.JobID)]
    SageIxocholeRhizomataFeature = 4004,

    [IconsCombo([SGE.Taurochole, UTL.ArrowLeft, SGE.Rhizomata, UTL.Blank, UTL.Blank, UTL.Danger])]
    [SectionCombo("Rhizomata features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Taurochole into Rhizomata Feature", "Replace Taurochole with Rhizomata when Addersgall is empty.", SGE.JobID)]
    SageTaurocholeRhizomataFeature = 4002,

    [IconsCombo([SGE.Kerachole, UTL.ArrowLeft, SGE.Rhizomata, UTL.Blank, UTL.Blank, UTL.Danger])]
    [SectionCombo("Rhizomata features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Kerachole into Rhizomata Feature", "Replace Kerachole with Rhizomata when Addersgall is empty.", SGE.JobID)]
    SageKeracholaRhizomataFeature = 4005,

    [IconsCombo([SGE.Phlegma, UTL.ArrowLeft, SGE.Dyskrasia, UTL.Blank, SGE.Psyche, UTL.Checkmark])]
    [SectionCombo("Phlegma features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Phlegma into Psyche", "Replace Phlegma with Psyche when Psyche is available, you're in combat, and have a target.", SGE.JobID)]
    SagePhlegmaPsyche = 4008,

    [IconsCombo([SGE.Phlegma, UTL.ArrowLeft, SGE.Dyskrasia, UTL.Blank, SGE.Phlegma, UTL.Cross])]
    [SectionCombo("Phlegma features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Phlegma into Dyskrasia", "Replace Phlegma with Dyskrasia when no charges remain or have no target.", SGE.JobID)]
    SagePhlegmaDyskrasia = 4016,

    [IconsCombo([SGE.Phlegma, UTL.ArrowLeft, SGE.Toxikon, UTL.Blank, SGE.Phlegma, UTL.Cross])]
    [SectionCombo("Phlegma features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Phlegma into Toxikon", "Replace Phlegma with Toxikon when no charges remain and you have Addersting.\nThis takes priority over Phlegma into Dyskrasia.", SGE.JobID)]
    SagePhlegmaToxikon = 4007,

    [IconsCombo([SGE.Toxikon, UTL.ArrowLeft, SGE.Phlegma, UTL.Blank, SGE.Phlegma, UTL.Checkmark])]
    [SectionCombo("Toxikon features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Toxikon into Phlegma", "Replace Toxikon with Phlegma when charges are available.", SGE.JobID)]
    SageToxikonPhlegma = 4011,

    [IconsCombo([SGE.Toxikon, UTL.ArrowLeft, SGE.Psyche, UTL.Blank, SGE.Psyche, UTL.Checkmark])]
    [SectionCombo("Toxikon features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Toxikon into Psyche", "Replace Toxicon with Psyche when Psyche is available", SGE.JobID)]
    SagePsycheToxikonFeature = 4013,

    [IconsCombo([SGE.Druochole, UTL.ArrowLeft, SGE.Taurochole, UTL.Blank, SGE.Druochole, UTL.Checkmark])]
    [SectionCombo("Somethingchole features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Druochole into Taurochole Feature", "Replace Druochole with Taurochole when off cooldown.\nWarning: This will limit your abiility to use Druochole.", SGE.JobID)]
    SageDruocholeTaurocholeFeature = 4009,

    [IconsCombo([SGE.Taurochole, UTL.ArrowLeft, SGE.Druochole, UTL.Blank, SGE.Taurochole, UTL.Clock])]
    [SectionCombo("Somethingchole features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Taurochole into Druochole Feature", "Replace Taurochole with Druochole when on cooldown", SGE.JobID)]
    SageTaurocholeDruocholeFeature = 4001,

    #endregion
    // ====================================================================================
    #region SAMURAI

    [IconsCombo([SAM.Yukikaze, UTL.ArrowLeft, SAM.Hakaze])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Yukikaze Combo", "Replace Yukikaze with its combo chain.", SAM.JobID)]
    SamuraiYukikazeCombo = 3401,

    [IconsCombo([SAM.Gekko, UTL.ArrowLeft, SAM.Jinpu, UTL.ArrowLeft, SAM.Hakaze])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Gekko Combo", "Replace Gekko with its combo chain.", SAM.JobID)]
    SamuraiGekkoCombo = 3402,

    [IconsCombo([SAM.Gekko, UTL.ArrowLeft, SAM.Jinpu, UTL.Blank, UTL.Blank2])]
    [SectionCombo("Single Target")]
    [ParentCombo(SamuraiGekkoCombo)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Gekko Combo Option", "Start the Gekko combo chain with Jinpu instead of Hakaze.", SAM.JobID)]
    SamuraiGekkoOption = 3416,

    [IconsCombo([SAM.Kasha, UTL.ArrowLeft, SAM.Shifu, UTL.ArrowLeft, SAM.Hakaze])]
    [SectionCombo("Single Target")]
    [CustomComboInfo("Kasha Combo", "Replace Kasha with its combo chain.", SAM.JobID)]
    SamuraiKashaCombo = 3403,

    [IconsCombo([SAM.Kasha, UTL.ArrowLeft, SAM.Shifu, UTL.Blank, UTL.Blank2])]
    [SectionCombo("Single Target")]
    [ParentCombo(SamuraiKashaCombo)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Kasha Combo Option", "Start the Kasha combo chain with Shifu instead of Hakaze.", SAM.JobID)]
    SamuraiKashaOption = 3417,

    [IconsCombo([SAM.Mangetsu, UTL.ArrowLeft, SAM.Fuga])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Mangetsu Combo", "Replace Mangetsu with its combo chain.", SAM.JobID)]
    SamuraiMangetsuCombo = 3404,

    [IconsCombo([SAM.Oka, UTL.ArrowLeft, SAM.Fuga])]
    [SectionCombo("Area of Effect")]
    [CustomComboInfo("Oka Combo", "Replace Oka with its combo chain.", SAM.JobID)]
    SamuraiOkaCombo = 3405,

    [IconsCombo([SAM.Iaijutsu, UTL.ArrowLeft, SAM.TsubameGaeshi])]
    [SectionCombo("Iaijutsu")]
    [CustomComboInfo("Iaijutsu to Tsubame-gaeshi", "Replace Iaijutsu with Tsubame-gaeshi when it is usable", SAM.JobID)]
    SamuraiIaijutsuTsubameGaeshiFeature = 3409,

    [SectionCombo("Iaijutsu")]
    [SecretCustomCombo]
    [CustomComboInfo("Iaijutsu to Tsubame-gaeshi Single Sen", "Don't replace Iaijutsu with a single Sen active", SAM.JobID)]
    [ParentCombo(SamuraiIaijutsuTsubameGaeshiFeature)]
    SamuraiIaijutsuSingleSenNoReplaceTsubameFeature = 3422,

    [IconsCombo([SAM.Iaijutsu, UTL.ArrowLeft, SAM.Shoha, UTL.Blank, SAM.Shoha, UTL.Checkmark])]
    [SectionCombo("Iaijutsu")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Iaijutsu to Shoha", "Replace Iaijutsu with Shoha when meditation is 3.", SAM.JobID)]
    SamuraiIaijutsuShohaFeature = 3410,

    [IconsCombo([SAM.HissatsuShinten, UTL.ArrowLeft, SAM.Zanshin, UTL.Blank, SAM.Zanshin, UTL.Checkmark])]
    [SectionCombo("Shinten")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Shinten to Zanshin", "Replace Hissatsu: Shinten with Zanshin when available.", SAM.JobID)]
    SamuraiShintenZanshinFeature = 3420,

    [IconsCombo([SAM.HissatsuShinten, UTL.ArrowLeft, SAM.Shoha, UTL.Blank, SAM.Shoha, UTL.Checkmark])]
    [SectionCombo("Shinten")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Shinten to Shoha", "Replace Hissatsu: Shinten with Shoha when Meditation is full.", SAM.JobID)]
    SamuraiShintenShohaFeature = 3413,

    [IconsCombo([SAM.HissatsuShinten, UTL.ArrowLeft, SAM.HissatsuSenei, UTL.Blank, SAM.HissatsuSenei, UTL.Checkmark])]
    [SectionCombo("Shinten")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Shinten to Senei", "Replace Hissatsu: Shinten with Senei when available.", SAM.JobID)]
    SamuraiShintenSeneiFeature = 3414,

    [IconsCombo([SAM.HissatsuKyuten, UTL.ArrowLeft, SAM.Zanshin, UTL.Blank, SAM.Zanshin, UTL.Checkmark])]
    [SectionCombo("Kyuten")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Kyuten to Zanshin", "Replace Hissatsu: Kyuten with Zanshin when available.", SAM.JobID)]
    SamuraiKyutenZanshinFeature = 3421,

    [IconsCombo([SAM.HissatsuKyuten, UTL.ArrowLeft, SAM.Iaijutsu])]
    [SectionCombo("Kyuten")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Shinten to Iaijutsu", "Replace Hissatsu: Shinten with Iaijutsu when available.", SAM.JobID)]
    SamuraiShintenIaijutsuFeature = 3428,

    [IconsCombo([SAM.HissatsuKyuten, UTL.ArrowLeft, SAM.TsubameGaeshi])]
    [SectionCombo("Kyuten")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Shinten to Tsubame-gaeshi", "Replace Hissatsu: Shinten with Tsubame-gaeshi when available.", SAM.JobID)]
    SamuraiShintenTsubameGaeshiFeature = 3423,

    [IconsCombo([SAM.HissatsuKyuten, UTL.ArrowLeft, SAM.OgiNamikiri])]
    [SectionCombo("Kyuten")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Shinten to Oga Namikiri", "Replace Hissatsu: Shinten with Oga Namikiri when available.", SAM.JobID)]
    SamuraiShintenOgaNamikiriFeature = 3424,

    [IconsCombo([SAM.HissatsuKyuten, UTL.ArrowLeft, SAM.Shoha, UTL.Blank, SAM.Shoha, UTL.Checkmark])]
    [SectionCombo("Kyuten")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Kyuten to Shoha", "Replace Hissatsu: Kyuten with Shoha when Meditation is full.", SAM.JobID)]
    SamuraiKyutenShohaFeature = 3412,

    [IconsCombo([SAM.HissatsuShinten, UTL.ArrowLeft, SAM.HissatsuGuren, UTL.Blank, SAM.HissatsuGuren, UTL.Checkmark])]
    [SectionCombo("Kyuten")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Kyuten to Guren", "Replace Hissatsu: Kyuten with Guren when available.", SAM.JobID)]
    SamuraiKyutenGurenFeature = 3415,

    [IconsCombo([SAM.HissatsuShinten, UTL.ArrowLeft, SAM.Iaijutsu])]
    [SectionCombo("Kyuten")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Kyuten to Iaijutsu", "Replace Hissatsu: Kyuten with Iaijutsu when available.", SAM.JobID)]
    SamuraiKyutenIaijutsuFeature = 3425,

    [IconsCombo([SAM.HissatsuShinten, UTL.ArrowLeft, SAM.TsubameGaeshi])]
    [SectionCombo("Kyuten")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Kyuten to Tsubame-gaeshi", "Replace Hissatsu: Kyuten with Tsubame-gaeshi when available.", SAM.JobID)]
    SamuraiKyutenTsubameGaeshiFeature = 3426,

    [IconsCombo([SAM.HissatsuShinten, UTL.ArrowLeft, SAM.OgiNamikiri])]
    [SectionCombo("Kyuten")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Kyuten to Oga Namikiri", "Replace Hissatsu: Kyuten with Oga Namikiri when available.", SAM.JobID)]
    SamuraiKyutenOgaNamikiriFeature = 3427,

    [IconsCombo([SAM.Ikishoten, UTL.ArrowLeft, SAM.OgiNamikiri, SAM.KaeshiNamikiri, UTL.Blank, SAM.OgiNamikiri, SAM.KaeshiNamikiri, UTL.Checkmark])]
    [SectionCombo("Ikishoten")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Ikishoten Namikiri Feature", "Replace Ikishoten with Ogi Namikiri and then Kaeshi Namikiri when available.", SAM.JobID)]
    SamuraiIkishotenNamikiriFeature = 3411,

    [IconsCombo([SAM.Ikishoten, UTL.ArrowLeft, SAM.Shoha, UTL.Blank, SAM.Shoha, UTL.Checkmark])]
    [SectionCombo("Ikishoten")]
    [ParentCombo(SamuraiIkishotenNamikiriFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Ikishoten Shoha Feature", "Replace Ikishoten with Shoha when Meditation is full.", SAM.JobID)]
    SamuraiIkishotenShohaFeature = 3419,

    [IconsCombo([SAM.HissatsuSenei, UTL.ArrowLeft, SAM.HissatsuGuren])]
    [SectionCombo("Level Synchronization")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Senei to Guren Level Sync", "Replace Hissatsu: Senei with Guren when level synced below 72.", SAM.JobID)]
    SamuraiSeneiGurenFeature = 3418,

    #endregion
    // ====================================================================================
    #region SCHOLAR

    [IconsCombo([SCH.Ruin, UTL.ArrowLeft, SCH.Bio, UTL.Blank, SCH.Debuffs.Bio, UTL.Clock])]
    [SectionCombo("Single Target")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Auto Bio", "Replace Ruin and its upgrades with Bio and its upgrades when it is about to run out.", SCH.JobID)]
    ScholarDoTFeature = 2813,

    [IconsCombo([SCH.EnergyDrain, UTL.ArrowLeft, SCH.Aetherflow, UTL.Blank, UTL.Blank, UTL.Danger])]
    [SectionCombo("Aetherflow features")]
    [CustomComboInfo("ED Aetherflow", "Replace Energy Drain with Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
    ScholarEnergyDrainAetherflowFeature = 2802,

    [IconsCombo([SCH.Dissipation, UTL.ArrowLeft, SCH.EnergyDrain, UTL.Cycle, SCH.Aetherflow, UTL.Blank, SCH.Dissipation, UTL.Cross])]
    [SectionCombo("Aetherflow features")]
    [ParentCombo(ScholarEnergyDrainAetherflowFeature)]
    [SecretCustomCombo]
    [CustomComboInfo("ED Dissipation", "Replace Dissipation with Energy Drain and Dissipation isn't available, and to Aetherflow when you have no more Aetherflow stacks.\nBe wary that you won't be able to track Aetherflow's cooldown that way, as it will revert to Dissipation whenever neither Aetherflow nor Energy Drain can be used.", SCH.JobID)]
    ScholarDissipationEnergyDrainAetherflowFeature = 2814,

    [IconsCombo([SCH.Lustrate, UTL.ArrowLeft, SCH.Aetherflow, UTL.Blank, UTL.Blank, UTL.Danger])]
    [SectionCombo("Aetherflow features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Lustrous Aetherflow", "Replace Lustrate with Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
    ScholarLustrateAetherflowFeature = 2803,

    [IconsCombo([SCH.Indomitability, UTL.ArrowLeft, SCH.Aetherflow, UTL.Blank, UTL.Blank, UTL.Danger])]
    [SectionCombo("Aetherflow features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Indomitable Aetherflow", "Replace Indomitability with Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
    ScholarIndomAetherflowFeature = 2804,

    [IconsCombo([SCH.SacredSoil, UTL.ArrowLeft, SCH.Aetherflow, UTL.Blank, UTL.Blank, UTL.Danger])]
    [SectionCombo("Aetherflow features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Sacred Soil Aetherflow", "Replace Sacred Soil with Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
    ScholarSacredSoilAetherflowFeature = 2811,

    [IconsCombo([SCH.SummonSeraph, UTL.ArrowLeft, SCH.SummonEos, UTL.Blank, SCH.SummonEos, UTL.Checkmark])]
    [SectionCombo("Seraph features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Summon Seraph Feature", "Replace Summon Eos and Selene with Summon Seraph when a summon is out.", SCH.JobID)]
    ScholarSeraphFeature = 2805,

    [IconsCombo([SCH.Consolation, UTL.ArrowLeft, SCH.FeyBless, UTL.Blank, SCH.SummonSeraph, UTL.Checkmark])]
    [SectionCombo("Seraph features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Seraph Fey Blessing/Consolation", "Replace Fey Blessing with Consolation when Seraph is out.", SCH.JobID)]
    ScholarSeraphConsolationFeature = 2801,

    [IconsCombo([SCH.EmergencyTactics, UTL.ArrowLeft, SCH.Seraphism, UTL.Blank, SCH.Seraphism, UTL.Checkmark])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Seraphism Feature", "Replace Seraphism with Emergency Tactics as long as you are under its effect.", SCH.JobID)]
    ScholarSeraphismFeature = 2812,

    [IconsCombo([SCH.Excogitation, UTL.ArrowLeft, SCH.Recitation])]
    [SectionCombo("Excogitation features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Excogitation to Recitation", "Replace Excogitation with Recitation when Recitation is off cooldown.", SCH.JobID)]
    ScholarExcogitationRecitationFeature = 2806,

    [IconsCombo([SCH.Excogitation, UTL.ArrowLeft, SCH.Lustrate])]
    [SectionCombo("Excogitation features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Excogitation to Lustrate", "Replace Excogitation with Lustrate when Excogitation is on cooldown.", SCH.JobID)]
    ScholarExcogitationLustrateFeature = 2809,

    [IconsCombo([SCH.Lustrate, UTL.ArrowLeft, SCH.Recitation])]
    [SectionCombo("Lustrate features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Lustrate to Recitation", "Replace Lustrate with Recitation when Recitation is off cooldown.", SCH.JobID)]
    ScholarLustrateRecitationFeature = 2807,

    [IconsCombo([SCH.Lustrate, UTL.ArrowLeft, SCH.Excogitation])]
    [SectionCombo("Lustrate features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Lustrate to Excogitation", "Replace Lustrate with Excogitation when Excogitation is off cooldown.", SCH.JobID)]
    ScholarLustrateExcogitationFeature = 2808,

    [IconsCombo([SCH.Physick, UTL.ArrowLeft, SCH.Adloquium])]
    [SectionCombo("Level Synchronization")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Adloquium Level Sync", "Replace Adloquium with Physick when below level 30 in synced content.", SCH.JobID)]
    ScholarAdloquiumSyncFeature = 2810,

    #endregion
    // ====================================================================================
    #region SUMMONER

    [IconsCombo([SMN.Ruin, UTL.ArrowLeft, SMN.Gemshine, UTL.Blank, SMN.Aethercharge, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Ruin Feature", "Replace Ruin with Gemshine when attuned.", SMN.JobID)]
    SummonerRuinFeature = 2703,

    [IconsCombo([SMN.Ruin, UTL.ArrowLeft, SMN.MountainBuster, UTL.Blank, SMN.Buffs.TitansFavor, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Titan's Favor Ruin Feature", "Replace Ruin with Mountain Buster (oGCD) when available.", SMN.JobID)]
    SummonerRuinTitansFavorFeature = 2713,

    [IconsCombo([SMN.Ruin, UTL.ArrowLeft, SMN.Ruin4, UTL.Blank, SMN.Buffs.FurtherRuin, UTL.Checkmark])]
    [SectionCombo("Single Target")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Ruin 4 to Ruin Feature", "Replace Ruin with Ruin4 when available and appropriate.", SMN.JobID)]
    SummonerFurtherRuinFeature = 2705,

    [IconsCombo([SMN.Outburst, UTL.ArrowLeft, SMN.PreciousBrilliance, UTL.Blank, SMN.Aethercharge, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Outburst Feature", "Replace Outburst with Precious Brilliance when attuned.", SMN.JobID)]
    SummonerOutburstFeature = 2704,

    [IconsCombo([SMN.Outburst, UTL.ArrowLeft, SMN.MountainBuster, UTL.Blank, SMN.Buffs.TitansFavor, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Titan's Favor Outburst Feature", "Replace Outburst with Mountain Buster (oGCD) when available.", SMN.JobID)]
    SummonerOutburstTitansFavorFeature = 2714,

    [IconsCombo([SMN.Outburst, UTL.ArrowLeft, SMN.Ruin4, UTL.Blank, SMN.Buffs.FurtherRuin, UTL.Checkmark])]
    [SectionCombo("Area of Effect")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Ruin 4 to Outburst Feature", "Replace Outburst with Ruin4 when available and appropriate.", SMN.JobID)]
    SummonerFurtherOutburstFeature = 2706,

    [IconsCombo([SMN.Fester, UTL.ArrowLeft, SMN.EnergyDrain, UTL.Blank, SMN.EnergyDrain, UTL.Cross])]
    [SectionCombo("Aetherflow features")]
    [CustomComboInfo("ED Fester/Necrosis Feature", "Replace Fester/Necrosis with Energy Drain when out of Aetherflow stacks.", SMN.JobID)]
    SummonerEDFesterFeature = 2701,

    [IconsCombo([SMN.Painflare, UTL.ArrowLeft, SMN.EnergySyphon, UTL.Blank, SMN.EnergySyphon, UTL.Cross])]
    [SectionCombo("Aetherflow features")]
    [CustomComboInfo("ES Painflare Feature", "Replace Painflare with Energy Syphon when out of Aetherflow stacks.", SMN.JobID)]
    SummonerESPainflareFeature = 2702,

    [IconsCombo([SMN.SummonBahamut, UTL.ArrowLeft, SMN.LuxSolaris, UTL.Blank, SMN.Buffs.LuxSolarisReady, UTL.Checkmark])]
    [SectionCombo("Summons features")]
    [CustomComboInfo("Summon Lux Solaris Feature", "Replace Summon Bahamut with Lux Solaris when you have Refulgent Lux ready.", SMN.JobID)]
    SummonerSummonLuxSolarisFeature = 2717,

    [IconsCombo([SMN.SummonBahamut, SMN.SummonPhoenix, SMN.SummonSolarBahamut, UTL.ArrowLeft, SMN.EnkindleBahamut, SMN.EnkindlePhoenix, SMN.EnkindleSolarBahamut, UTL.Blank, SMN.SummonBahamut, SMN.SummonPhoenix, SMN.SummonSolarBahamut, UTL.Checkmark])]
    [SectionCombo("Summons features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Demi Enkindle Feature", "Replace Summon Bahamut, Summon Phoenix and Summon Solar Bahamut with Enkindle when Solar Bahamut, Bahamut or Phoenix are summoned.", SMN.JobID)]
    SummonerDemiEnkindleFeature = 2710,

    [IconsCombo([SMN.SummonBahamut, SMN.SummonPhoenix, SMN.SummonSolarBahamut, UTL.ArrowLeft, SMN.SearingLight, UTL.Blank, SMN.SummonBahamut, SMN.SummonPhoenix, SMN.SummonSolarBahamut, UTL.Checkmark])]
    [SectionCombo("Summons features")]
    [SecretCustomCombo]
    [CustomComboInfo("Searing Demi Feature", "Replace Summon Bahamut, Summon Phoenix and Summon Solar Bahamut with Searing Light when any of them is ready to be summoned, Searing Light is off cooldown, and you are in combat.\nNote: this used to be the optimal behavior for the 6.0 rework. It is now deprecated in favor of the Searing Demi Flash Feature.", SMN.JobID)]
    SummonerDemiSearingLightFeature = 2715,

    [IconsCombo([SMN.SummonBahamut, SMN.SummonPhoenix, SMN.SummonSolarBahamut, UTL.ArrowLeft, SMN.SearingLight, UTL.Blank, SMN.Buffs.RubysGlimmer, UTL.Checkmark, UTL.Plus, SMN.SummonBahamut, SMN.SummonPhoenix, SMN.SummonSolarBahamut, UTL.Clock])]
    [SectionCombo("Summons features")]
    [SecretCustomCombo]
    [CustomComboInfo("Searing Demi Flash Feature", "Replace Summon Bahamut, Summon Phoenix and Summon Solar Bahamut with Searing Light when Ruby's Glimmer is available, Searing Light is off cooldown, Summon Demi is on cooldown, and you are in combat.", SMN.JobID)]
    SummonerSearingDemiFlashFeature = 2719,

    [IconsCombo([SMN.Gemshine, SMN.PreciousBrilliance, UTL.ArrowLeft, SMN.MountainBuster, UTL.Blank, SMN.Buffs.TitansFavor, UTL.Checkmark])]
    [SectionCombo("Gems features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Gems Titan's Favor Feature", "Replace Gemshine and Precious Brilliance with Mountain Buster (oGCD) when available.", SMN.JobID)]
    SummonerShinyTitansFavorFeature = 2707,

    [IconsCombo([SMN.Gemshine, SMN.PreciousBrilliance, UTL.ArrowLeft, SMN.Ruin4, UTL.Blank, SMN.Buffs.FurtherRuin, UTL.Checkmark])]
    [SectionCombo("Gems features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Gems Ruin 4 Feature", "Replace Gemshine and Precious Brilliance with Ruin 4 when available and appropriate.", SMN.JobID)]
    SummonerFurtherShinyFeature = 2708,

    [IconsCombo([SMN.Gemshine, SMN.PreciousBrilliance, UTL.ArrowLeft, SMN.EnkindleBahamut, SMN.EnkindlePhoenix, SMN.EnkindleSolarBahamut, UTL.Blank, SMN.SummonBahamut, SMN.SummonPhoenix, SMN.SummonSolarBahamut, UTL.Checkmark])]
    [SectionCombo("Gems features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Gems Enkindle Feature", "Replace Gemshine and Precious Brilliance with Enkindle when Bahamut, Phoenix or Summon Solar Bahamut are summoned.", SMN.JobID)]
    SummonerShinyEnkindleFeature = 2709,

    [IconsCombo([SMN.RadiantAegis, UTL.ArrowLeft, SMN.SummonCarbuncle, UTL.Blank, SMN.SummonCarbuncle, UTL.Cross])]
    [SectionCombo("Carbuncle features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Radiant Carbuncle Feature", "Replace Radiant Aegis with Summon Carbuncle when no pet has been summoned.", SMN.JobID)]
    SummonerRadiantCarbuncleFeature = 2711,

    [IconsCombo([SMN.RadiantAegis, UTL.ArrowLeft, SMN.LuxSolaris, UTL.Blank, SMN.Buffs.LuxSolarisReady, UTL.Checkmark])]
    [SectionCombo("Carbuncle features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Radiant Lux Solaris Feature", "Replace Radiant Aegis with Lux Solaris when you have Refulgent Lux ready.", SMN.JobID)]
    SummonerRadiantLuxSolarisFeature = 2718,

    [IconsCombo([SMN.SummonBahamut, UTL.ArrowLeft, SMN.SummonCarbuncle, UTL.Blank, SMN.SummonCarbuncle, UTL.Cross])]
    [SectionCombo("Carbuncle features")]
    [ExpandedCustomCombo]
    [CustomComboInfo("Demi Carbuncle Feature", "Replace Summon Bahamut with Summon Carbuncle when no pet has been summoned.", SMN.JobID)]
    SummonerDemiCarbuncleFeature = 2716,

    #endregion
    // ====================================================================================
    #region VIPER

    [SectionCombo("Standard Combos")]
    [IconsCombo([VPR.SteelFangs, UTL.Cycle, VPR.ReavingFangs, UTL.Blank, VPR.SteelMaw, UTL.Cycle, VPR.ReavingMaw])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Auto Steel Reaving", "Replace Steel Fangs/Reaving Fangs and Steel Maw/Reaving Maw with whichever is currently empowered. Only affects the first combo hit.", VPR.JobID)]
    ViperAutoSteelReavingFeature = 4124,

    [SectionCombo("Standard Combos")]
    [IconsCombo([VPR.HindstingStrike, VPR.HindsbaneFang, VPR.FlanksbaneFang, VPR.FlankstingStrike, UTL.Idea, UTL.Blank, VPR.JaggedMaw, VPR.BloodiedMaw, UTL.Idea])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Auto Fang/Bite", "Replace Steel Fangs/Reaving Fangs and Steel Maw/Reaving Maw with whichever of the two available 3rd combo hits is currently empowered. Only affects the third combo hit.\n\nNOTE: This means that, for example, rather than Steel Fangs having Hindsting Strike and Reaving Fangs having Hindsbane Fang, both will have whichever of those two is currently empowered.  If neither is empowered, they'll have whatever they normally have for the 3rd combo hit.", VPR.JobID)]
    ViperAutoFangBiteFeature = 4128,

    [SectionCombo("Standard Combos")]
    [IconsCombo([VPR.SteelFangs, VPR.ReavingFangs, UTL.ArrowLeft, VPR.DeathRattle, UTL.Blank, VPR.SteelMaw, VPR.ReavingMaw, UTL.ArrowLeft, VPR.LastLash])]
    [CustomComboInfo("Serpent's Fang Feature", "Replace Steel Fangs, Reaving Fangs, Steel Maw, and Reaving Maw with Serpent's Tail after finishing a combo.", VPR.JobID)]
    ViperSteelTailFeature = 4101,

    [SectionCombo("Vice Combos")]
    [IconsCombo([VPR.SteelFangs, VPR.ReavingFangs, VPR.SteelMaw, VPR.ReavingMaw, UTL.ArrowLeft, VPR.HuntersCoil, VPR.SwiftskinsCoil, VPR.HuntersDen, VPR.SwiftskinsDen])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Steel Coil Feature", "Replace Steel Fangs with Swiftskin's Coil, Reaving Fangs with Hunter's Coil, Steel Maw with Swiftskin's Den, and Reaving Maw with Hunter's Den when usable.\n\nNOTE: Also replaces Steel Fangs/Maw with both First and Third Generation, and Reaving Fangs/Maw with both Second and Fourth Generation.", VPR.JobID)]
    ViperSteelCoilFeature = 4126,

    [SectionCombo("Vice Combos")]
    [IconsCombo([VPR.HuntersCoil, VPR.SwiftskinsCoil, VPR.HuntersDen, VPR.SwiftskinsDen, UTL.ArrowLeft, VPR.Twinfang, VPR.Twinblood])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Twin Coil Feature", "Replace Swiftskin's Coil/Den and Hunter's Coil/Den with their respective Twinblood and Twinfang skills, in the correct order.", VPR.JobID)]
    ViperTwinCoilFeature = 4103,

    [SectionCombo("Vice Combos")]
    [IconsCombo([VPR.SteelFangs, VPR.ReavingFangs, UTL.ArrowLeft, VPR.Vicewinder])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Fangs to Vicewinder", "Replaces Steel Fangs and Reaving Fangs to Vicewinder when any charges are available and you're not currently in a combo.\n\nNOTE: This can lead to less than ideal usage timing, and does not respect Rattling Coil stacks.", VPR.JobID)]
    ViperAutoViceSTFeature = 4109,

    [SectionCombo("Vice Combos")]
    [IconsCombo([VPR.SteelMaw, VPR.ReavingMaw, UTL.ArrowLeft, VPR.VicePit])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Maws to Vicepit", "Replaces Steel Maw and Reaving Maw with Vicepit when charges are available and not you're currently in a combo.\n\nNOTE: This can lead to less than ideal usage timing, and does not respect Rattling Coil stacks.", VPR.JobID)]
    ViperAutoViceAoEFeature = 4110,

    [SectionCombo("Reawaken")]
    [IconsCombo([VPR.FirstGeneration, VPR.FirstLegacy, VPR.SecondGeneration, VPR.SecondLegacy, VPR.ThirdGeneration, VPR.ThirdLegacy, VPR.FourthGeneration, VPR.FourthLegacy, UTL.Blank])]
    [CustomComboInfo("Generation Legacy Feature", "Replace the Generation skills with their respective Legacies.", VPR.JobID)]
    ViperGenerationLegaciesFeature = 4105,

    [SectionCombo("Reawaken")]
    [IconsCombo([VPR.Reawaken, UTL.ArrowLeft, VPR.FirstGeneration, VPR.FirstLegacy, VPR.SecondGeneration, VPR.SecondLegacy, VPR.ThirdGeneration, VPR.ThirdLegacy, VPR.FourthGeneration, VPR.FourthLegacy, VPR.Ouroboros])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("All-in-one Reawaken Feature", "Replace Reawaken with the Generation skills and their respective Legacies in order.", VPR.JobID)]
    ViperReawakenAIOFeature = 4123,

    [SectionCombo("Reawaken")]
    [IconsCombo([VPR.Reawaken, UTL.ArrowLeft, VPR.SerpentsIre])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Serpent's Ire on Reawaken", "Replace Reawaken with Serpent's Ire when it's up.", VPR.JobID)]
    ViperReawakenIreFeature = 4127,

    [SectionCombo("Uncoiled Fury")]
    [IconsCombo([VPR.UncoiledFury, UTL.ArrowLeft, VPR.UncoiledTwinfang, VPR.UncoiledTwinblood])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Uncoiled Fury Followup", "Replaces Uncoiled Fury with Uncoiled Twinfang and Uncoiled Twinblood in sequence.", VPR.JobID)]
    ViperUncoiledFollowupFeature = 4107,

    [SectionCombo("Uncoiled Fury")]
    [IconsCombo([VPR.UncoiledFury, UTL.ArrowLeft, VPR.SerpentsIre, UTL.Minus])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Fury And Ire", "Replace Uncoiled Fury with Serpent's Ire when out of Rattling Coil stacks.\n\nNOTE: This is strongly discouraged.  Serpent's Ire is not just a Rattling Coil generator, it is also Viper's primary 2-minute cooldown, as it also enables a free Reawaken.  It should be aligned with party buffs, not held and used when you happen to be out of Rattling Coil charges.", VPR.JobID)]
    ViperFuryAndIreFeature = 4108,

    [SectionCombo("Uncoiled Fury")]
    [IconsCombo([VPR.UncoiledFury, UTL.ArrowLeft, VPR.WrithingSnap])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Uncoiled Fury to Writhing Snap", "Replace Uncoiled Fury with Writhing Snap when you are out of Rattling Coil charges.", VPR.JobID)]
    ViperSnapCoilFeature = 4125,

    [SectionCombo("oGCDs")]
    [IconsCombo([VPR.SerpentsTail, UTL.ArrowLeft, VPR.Twinfang, VPR.Twinblood, UTL.Idea])]
    [AccessibilityCustomCombo]
    [ConflictingCombos(ViperMergeTwinsSerpentFeature)]
    [CustomComboInfo("Merge Twinfang/Twinblood onto Serpent's Tail Feature", "Merge all Twinfang/Twinblood abilities onto Serpent's Tail, in the correct order.", VPR.JobID)]
    ViperMergeSerpentTwinsFeature = 4111,

    [SectionCombo("oGCDs")]
    [IconsCombo([VPR.Twinfang, VPR.Twinblood, UTL.ArrowLeft, VPR.SerpentsTail])]
    [ExpandedCustomCombo]
    [ConflictingCombos(ViperMergeSerpentTwinsFeature)]
    [CustomComboInfo("Merge Serpent's Tail onto Twinfang/Twinblood Feature", "Merge all Serpent's Tail abilities onto Twinfang/Twinblood.", VPR.JobID)]
    ViperMergeTwinsSerpentFeature = 4112,

    [SectionCombo("Alternative Playstyle")]
    [IconsCombo([VPR.SteelFangs, UTL.ArrowLeft, VPR.ReavingFangs, VPR.HuntersSting, VPR.SwiftskinsSting, VPR.FlanksbaneFang, VPR.FlankstingStrike, VPR.HindsbaneFang, VPR.HindstingStrike])]
    [SecretCustomCombo]
    [ConflictingCombos(ViperAutoSteelReavingFeature)]
    [CustomComboInfo("Viper PvP Style Main Combo", "Condenses the main combo to a single button, like PvP.\nThe combo detects buffs to prioritize skills.\nThe default combo ender is Hindsting Strike, configurable below.", VPR.JobID)]
    ViperPvPMainComboFeature = 4113,

    [SectionCombo("Alternative Playstyle")]
    [SecretCustomCombo]
    [ConflictingCombos(ViperPvPMainComboStartFlankstingFeature, ViperPvPMainComboStartHindsbaneFeature)]
    [ParentCombo(ViperPvPMainComboFeature)]
    [CustomComboInfo("PvP Combo Start Flanksbane Fang", "With no buffs, end first combo with Flanksbane Fang.", VPR.JobID)]
    ViperPvPMainComboStartFlanksbaneFeature = 4114,

    [SectionCombo("Alternative Playstyle")]
    [SecretCustomCombo]
    [ConflictingCombos(ViperPvPMainComboStartFlanksbaneFeature, ViperPvPMainComboStartHindsbaneFeature)]
    [ParentCombo(ViperPvPMainComboFeature)]
    [CustomComboInfo("PvP Combo Start Flanksting Strike", "With no buffs, end first combo with Flanksting Strike.", VPR.JobID)]
    ViperPvPMainComboStartFlankstingFeature = 4115,

    [SectionCombo("Alternative Playstyle")]
    [SecretCustomCombo]
    [ConflictingCombos(ViperPvPMainComboStartFlanksbaneFeature, ViperPvPMainComboStartFlankstingFeature)]
    [ParentCombo(ViperPvPMainComboFeature)]
    [CustomComboInfo("PvP Combo Start Hindsbane Fang", "With no buffs, end first combo with Hindsbane Fang.", VPR.JobID)]
    ViperPvPMainComboStartHindsbaneFeature = 4116,

    [SectionCombo("Alternative Playstyle")]
    [SecretCustomCombo]
    [IconsCombo([VPR.SteelMaw, UTL.ArrowLeft, VPR.ReavingMaw, VPR.HuntersBite, VPR.SwiftskinsBite, VPR.JaggedMaw, VPR.BloodiedMaw])]
    [CustomComboInfo("Viper PvP Style AoE Combo", "Condenses the main combo to a single button, like PvP.\nStarts with Reaving Maw by default, configurable below.", VPR.JobID)]
    ViperPvPAoEFeature = 4117,

    [SectionCombo("Alternative Playstyle")]
    [SecretCustomCombo]
    [ParentCombo(ViperPvPAoEFeature)]
    [CustomComboInfo("PvP AoE Combo Start Bloodied Maw", "With no buffs, end first combo with Bloodied Maw.", VPR.JobID)]
    ViperPvPMainComboAoEStartBloodiedFeature = 4118,

    [SectionCombo("Alternative Playstyle")]
    [IconsCombo([VPR.Vicewinder, UTL.ArrowLeft, VPR.SwiftskinsCoil, VPR.HuntersCoil])]
    [ExpandedCustomCombo]
    [ConflictingCombos(ViperAutoViceSTFeature)]
    [CustomComboInfo("Viper PvP Style Winder Combo", "Condenses the Vicewinder combo to a single button, like PvP.\nStarts with Swiftskin's Coil (rear positional) by default.\n\nNOTE: Does not include the Twinfang and Twinblood weaves unless the 'Twin Coil Feature' under 'Vice Combos' is also enabled.", VPR.JobID)]
    ViperPvPWinderComboFeature = 4119,

    [SectionCombo("Alternative Playstyle")]
    [IconsCombo([VPR.Vicewinder, UTL.ArrowLeft, VPR.HuntersCoil, VPR.SwiftskinsCoil])]
    [ExpandedCustomCombo]
    [ParentCombo(ViperPvPWinderComboFeature)]
    [CustomComboInfo("Start with Hunter's Coil", "Start with Hunter's Coil (flank positional) instead.", VPR.JobID)]
    ViperPvPWinderComboStartHuntersFeature = 4120,

    [SectionCombo("Alternative Playstyle")]
    [IconsCombo([VPR.VicePit, UTL.ArrowLeft, VPR.SwiftskinsDen, VPR.HuntersDen])]
    [ExpandedCustomCombo]
    [ConflictingCombos(ViperAutoViceAoEFeature)]
    [CustomComboInfo("Viper PvP Style Pit Combo", "Condenses the Vicepit combo to a single button, like PvP.\nStarts with Swiftskin's Den by default.\n\nNOTE: Does not include the Twinfang and Twinblood weaves unless the 'Twin Coil Feature' under 'Vice Combos' is also enabled.", VPR.JobID)]
    ViperPvPPitComboFeature = 4121,

    [SectionCombo("Alternative Playstyle")]
    [IconsCombo([VPR.VicePit, UTL.ArrowLeft, VPR.HuntersDen, VPR.SwiftskinsDen])]
    [ExpandedCustomCombo]
    [ParentCombo(ViperPvPPitComboFeature)]
    [CustomComboInfo("Start with Hunter's Den", "Start with Hunter's Den instead.", VPR.JobID)]
    ViperPvPPitComboStartHuntersFeature = 4122,

    #endregion
    // ====================================================================================
    #region WARRIOR

    [SectionCombo("Single Target")]
    [IconsCombo([WAR.StormsPath, UTL.ArrowLeft, WAR.Maim, UTL.ArrowLeft, WAR.HeavySwing])]
    [CustomComboInfo("Storm's Path Combo", "Replace Storm's Path with its combo chain.", WAR.JobID)]
    WarriorStormsPathCombo = 2101,

    [SectionCombo("Single Target")]
    [IconsCombo([WAR.StormsEye, UTL.ArrowLeft, WAR.Maim, UTL.ArrowLeft, WAR.HeavySwing])]
    [CustomComboInfo("Storm's Eye Combo", "Replace Storms Eye with its combo chain.", WAR.JobID)]
    WarriorStormsEyeCombo = 2102,

    [SectionCombo("Single Target")]
    [IconsCombo([WAR.StormsPath, UTL.ArrowLeft, WAR.InnerBeast, UTL.Blank, WAR.Buffs.InnerRelease, UTL.Checkmark])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Storm's Path Inner Release Feature", "Replace Storm's Path with Inner Beast/Fell Cleave when Inner Release is active.", WAR.JobID)]
    WarriorStormsPathInnerReleaseFeature = 2110,

    [SectionCombo("Single Target")]
    [IconsCombo([WAR.StormsPath, UTL.ArrowLeft, WAR.InnerBeast, UTL.Blank, UTL.Blank, UTL.Danger])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Beast Gauge Overcap Protection (ST)", "Replace Storm's Path and Storm's Eye with Inner Beast/Fell Cleave when the next combo action would cause the Beast Gauge to overcap.\n\nNOTE: if Storm's Path Combo or Storm's Eye Combo are not active, this will ONLY check when Storm's Path/Eye is the next combo action.  If they are active, it will also protect against the 10 gauge gain from Maim.", WAR.JobID)]
    WarriorSTGaugeOvercapProtection = 2104,

    [SectionCombo("Single Target")]
    [IconsCombo([WAR.StormsPath, UTL.ArrowLeft, WAR.StormsEye, UTL.Blank, WAR.Buffs.SurgingTempest, UTL.Idea])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Automatic Surging Tempest", "Replace Storm's Path with Storm's Eye whenever Surging Tempest is below 30 seconds.", WAR.JobID)]
    WarriorAutoSurgingTempestFeature = 2113,

    [SectionCombo("Single Target")]
    [IconsCombo([WAR.StormsPath, UTL.ArrowLeft, WAR.StormsEye, UTL.Blank, WAR.Buffs.SurgingTempest, UTL.Danger])]
    [ParentCombo(WarriorAutoSurgingTempestFeature)]
    [SecretCustomCombo]
    [CustomComboInfo("Optimize Surging Tempest", "Optimize refresh of Surging Tempest to avoid overcapping when Inner Release is used, and to maximize potency during potions  This will defer refreshing Surging Tempest if the buff would be at greater than 50 seconds when Inner Release comes off cooldown, and will allow the buff to go as low as 10 seconds remaining while a DPS potion is active, to potentially squeeze in an extra Storm's Path during the potion effect.", WAR.JobID)]
    WarriorOptimizeSurgingTempestFeature = 2114,

    [SectionCombo("Area of Effect")]
    [IconsCombo([WAR.MythrilTempest, UTL.ArrowLeft, WAR.Overpower])]
    [CustomComboInfo("Mythril Tempest Combo", "Replace Mythril Tempest with its combo chain.", WAR.JobID)]
    WarriorMythrilTempestCombo = 2103,

    [SectionCombo("Area of Effect")]
    [IconsCombo([WAR.MythrilTempest, UTL.ArrowLeft, WAR.SteelCyclone, UTL.Blank, WAR.Buffs.InnerRelease, UTL.Checkmark])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Mythril Tempest Inner Release Feature", "Replace Mythril Tempest with Steel Cyclone/Decimate when Inner Release is active.", WAR.JobID)]
    WarriorMythrilTempestInnerReleaseFeature = 2111,

    [SectionCombo("Area of Effect")]
    [IconsCombo([WAR.MythrilTempest, UTL.ArrowLeft, WAR.SteelCyclone, UTL.Blank, UTL.Blank, UTL.Danger])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Beast Gauge Overcap Protection (AoE)", "Replace Mythril Tempest with Steel Cyclone/Decimate the next combo action would cause the Beast Gauge to overcap.", WAR.JobID)]
    WarriorAoEGaugeOvercapProtection = 2105,

    [SectionCombo("Inner Warrior")]
    [IconsCombo([WAR.InnerBeast, WAR.SteelCyclone, UTL.ArrowLeft, WAR.Infuriate, UTL.Blank, UTL.Blank, UTL.Danger])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Angry Beast Feature", "Replace Inner Beast/Fell Cleave and Steel Cyclone/Decimate with Infuriate when less then 50 Beast Gauge is available.", WAR.JobID)]
    WarriorInfuriateBeastFeature = 2109,

    [SectionCombo("Inner Warrior")]
    [IconsCombo([WAR.FellCleave, WAR.Decimate, UTL.ArrowLeft, WAR.PrimalRend])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Primal Beast Feature", "Replace Fell Cleave and Decimate with Primal Rend when available", WAR.JobID)]
    WarriorPrimalBeastFeature = 2107,

    [SectionCombo("Inner Warrior")]
    [IconsCombo([WAR.InnerRelease, UTL.ArrowLeft, WAR.PrimalRend])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Primal Release Feature", "Replace Inner Release with Primal Rend when available", WAR.JobID)]
    WarriorPrimalReleaseFeature = 2108,

    [SectionCombo("Buffs")]
    [IconsCombo([WAR.Bloodwhetting, UTL.ArrowLeft, WAR.ThrillOfBattle, UTL.ArrowLeft, WAR.Equilibrium])]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Healthy Balanced Diet Feature", "Replace Bloodwhetting with Thrill of Battle, and then Equilibrium when the preceding is on cooldown.", WAR.JobID)]
    WarriorHealthyBalancedDietFeature = 2112,

    [SectionCombo("Level Synchronization")]
    [IconsCombo([WAR.NascentFlash, UTL.ArrowLeft, WAR.RawIntuition])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Nascent Flash Level Sync", "Replace Nascent Flash with Raw Intuition when Level Synced.", WAR.JobID)]
    WarriorNascentFlashSyncFeature = 2106,

    #endregion
    // ====================================================================================
    #region WHITE MAGE

    [IconsCombo([WHM.Stone, UTL.ArrowLeft, WHM.Aero, UTL.Blank, WHM.Debuffs.Aero, UTL.Clock])]
    [SectionCombo("Single Target")]
    [AccessibilityCustomCombo]
    [CustomComboInfo("Auto Aero", "Replace Stone and its upgrades with Aero and its upgrades when it is about to run out.", WHM.JobID)]
    WhiteMageDoTFeature = 2409,

    [SectionCombo("Single Target")]
    [IconsCombo([WHM.Glare3, UTL.ArrowLeft, WHM.Glare4, UTL.Blank, WHM.Buffs.Glare4Ready, UTL.Checkmark])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Glare 4 Feature", "Replace Glare 3 with Glare 4 when a stack is available.", WHM.JobID)]
    WhiteMageGlare4Feature = 2407,

    [SectionCombo("Area of Effect")]
    [IconsCombo([WHM.Holy3, UTL.ArrowLeft, WHM.Glare4, UTL.Blank, WHM.Buffs.Glare4Ready, UTL.Checkmark])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Glare 4 AoE Feature", "Replace Holy 3 with Glare 4 when a stack is available.", WHM.JobID)]
    WhiteMageGlare4AoEFeature = 2410,

    [SectionCombo("Afflatus Misery")]
    [IconsCombo([WHM.AfflatusSolace, UTL.ArrowLeft, WHM.AfflatusMisery, UTL.Blank, UTL.Blank, UTL.Enemy])]
    [CustomComboInfo("Solace into Misery", "Replace Afflatus Solace with Afflatus Misery when ready and you have an enemy target and 3 Blood Lilies.", WHM.JobID)]
    WhiteMageSolaceMiseryFeature = 2401,

    [SectionCombo("Afflatus Misery")]
    [IconsCombo([WHM.AfflatusRapture, UTL.ArrowLeft, WHM.AfflatusMisery, UTL.Blank, UTL.Blank, UTL.Enemy])]
    [CustomComboInfo("Rapture into Misery", "Replace Afflatus Rapture with Afflatus Misery when ready and you have an enemy target and 3 Blood Lilies.", WHM.JobID)]
    WhiteMageRaptureMiseryFeature = 2402,

    [SectionCombo("Afflatus Misery")]
    [IconsCombo([WHM.Holy, UTL.ArrowLeft, WHM.AfflatusMisery, UTL.Blank, UTL.Blank, UTL.Enemy])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Holy into Misery", "Replace Holy/Holy 3 with Afflatus Misery when ready and you have an enemy target and 3 Blood Lilies.", WHM.JobID)]
    WhiteMageHolyMiseryFeature = 2405,

    [SectionCombo("Afflatus Solace")]
    [IconsCombo([WHM.AfflatusSolace, UTL.ArrowLeft, WHM.Cure2, UTL.Plus, WHM.AfflatusRapture, UTL.ArrowLeft, WHM.Medica])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Afflatus Feature", "Replace Cure 2 with Afflatus Solace and Medica with Afflatus Rapture when a Lily is available.", WHM.JobID)]
    WhiteMageAfflatusFeature = 2404,

    [SectionCombo("Afflatus Solace")]
    [IconsCombo([WHM.AfflatusSolace, UTL.ArrowLeft, WHM.Medica2, WHM.Medica3])]
    [ParentCombo(WhiteMageAfflatusFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Medicafflatus Feature", "Also replaces Medica 2 & Medica 3 with Afflatus Rapture when a Lily is available.", WHM.JobID)]
    WhiteMageAfflatusMedicaPlusFeature = 2408,

    [SectionCombo("Level Synchronization")]
    [IconsCombo([WHM.Cure, UTL.ArrowLeft, WHM.Cure2])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Cure 2 Level Sync", "Replace Cure 2 with Cure when below level 30 in synced content.", WHM.JobID)]
    WhiteMageCureFeature = 2403,

    #endregion
    // ====================================================================================
    #region DOH

    // [CustomComboInfo("Placeholder", "Placeholder.", DOH.JobID)]
    // DohPlaceholder = 50001,

    #endregion
    // ====================================================================================
    #region DOL

    [SectionCombo("Disciple of the Ocean")]
    [IconsCombo([DOL.Cast, UTL.ArrowLeft, DOL.Hook])]
    [ConflictingCombos(DolCastRestFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Cast / Hook Feature", "Replace Cast with Hook when fishing.", DOL.JobID)]
    DolCastHookFeature = 51002,

    [SectionCombo("Disciple of the Ocean")]
    [IconsCombo([DOL.Cast, UTL.ArrowLeft, DOL.Rest])]
    [ConflictingCombos(DolCastHookFeature)]
    [ExpandedCustomCombo]
    [CustomComboInfo("Cast / Rest Feature", "Replace Cast with Rest when fishing.", DOL.JobID)]
    DolCastRestFeature = 51008,

    [SectionCombo("Disciple of the Ocean")]
    [IconsCombo([DOL.Cast, UTL.ArrowLeft, DOL.Gig])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Cast / Gig Feature", "Replace Cast with Gig when underwater.", DOL.JobID)]
    DolCastGigFeature = 51003,

    [SectionCombo("Disciple of the Ocean")]
    [IconsCombo([DOL.SurfaceSlap, UTL.ArrowLeft, DOL.VeteranTrade])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Surface Slap / Veteran Trade Feature", "Replace Surface Slap with Veteran Trade when underwater.", DOL.JobID)]
    DolSurfaceTradeFeature = 51004,

    [SectionCombo("Disciple of the Ocean")]
    [IconsCombo([DOL.PrizeCatch, UTL.ArrowLeft, DOL.NaturesBounty])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Prize Catch / Nature's Bounty Feature", "Replace Prize Catch with Nature's Bounty when underwater.", DOL.JobID)]
    DolPrizeBountyFeature = 51005,

    [SectionCombo("Disciple of the Ocean")]
    [IconsCombo([DOL.Snagging, UTL.ArrowLeft, DOL.Salvage])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Snagging / Salvage Feature", "Replace Snagging with Salvage when underwater.", DOL.JobID)]
    DolSnaggingSalvageFeature = 51006,

    [SectionCombo("Disciple of the Ocean")]
    [IconsCombo([DOL.CastLight, UTL.ArrowLeft, DOL.ElectricCurrent])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Cast Light / Electric Current Feature", "Replace Cast Light with Electric Current when underwater.", DOL.JobID)]
    DolCastLightElectricCurrentFeature = 51007,

    [SectionCombo("Disciple of the Land")]
    [IconsCombo([DOL.AgelessWords, DOL.SolidReason, UTL.ArrowLeft, DOL.BtnWiseToTheWorld, DOL.MinWiseToTheWorld, UTL.Blank, DOL.Buffs.EurekaMoment, UTL.Checkmark])]
    [ExpandedCustomCombo]
    [CustomComboInfo("Eureka Feature", "Replace Ageless Words and Solid Reason with Wise to the World when available.", DOL.JobID)]
    DolEurekaFeature = 51001,

    #endregion
    // ====================================================================================
}
