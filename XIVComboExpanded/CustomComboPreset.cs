using XIVComboExpandedPlugin.Attributes;
using XIVComboExpandedPlugin.Combos;

namespace XIVComboExpandedPlugin
{
    /// <summary>
    /// Combo presets.
    /// </summary>
    public enum CustomComboPreset
    {
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

        // ====================================================================================
        #region ADV
        #endregion
        // ====================================================================================
        #region ASTROLOGIAN

        [CustomComboInfo("Draw on Play", "Play turns into Draw when no card is drawn, as well as the usual Play behavior.", AST.JobID)]
        AstrologianDrawPlayFeature = 3301,

        [CustomComboInfo("Astrodyne on Play", "Play turns into Astrodyne when seals are full.", AST.JobID)]
        AstrologianAstrodynePlayFeature = 3304,

        [CustomComboInfo("Minor Arcana Play Feature", "Changes Minor Arcana to Crown Play when a card drawn.", AST.JobID)]
        AstrologianMinorArcanaPlayFeature = 3302,

        [CustomComboInfo("Benefic 2 to Benefic Level Sync", "Changes Benefic 2 to Benefic when below level 26 in synced content.", AST.JobID)]
        AstrologianBeneficFeature = 3303,

        #endregion
        // ====================================================================================
        #region BLACK MAGE

        [CustomComboInfo("Enochian Feature", "Change Fire 4 or Blizzard 4 to whichever action you can currently use.", BLM.JobID)]
        BlackEnochianFeature = 2501,

        [CustomComboInfo("Umbral Soul/Transpose Switcher", "Change Transpose into Umbral Soul when Umbral Soul is usable.", BLM.JobID)]
        BlackManaFeature = 2502,

        [CustomComboInfo("(Between the) Ley Lines", "Change Ley Lines into BTL when Ley Lines is active.", BLM.JobID)]
        BlackLeyLinesFeature = 2503,

        [CustomComboInfo("Fire 1/3 Feature", "Fire 1 becomes Fire 3 outside of Astral Fire, and when Firestarter proc is up.", BLM.JobID)]
        BlackFireFeature = 2504,

        [CustomComboInfo("Blizzard 1/3 Feature", "Blizzard 1 becomes Blizzard 3 when out of Umbral Ice.", BLM.JobID)]
        BlackBlizzardFeature = 2505,

        [CustomComboInfo("Freeze/Flare Feature", "Freeze and Flare become whichever action you can currently use.", BLM.JobID)]
        BlackFreezeFlareFeature = 2506,

        [CustomComboInfo("Fire 2 Feature", "(High) Fire 2 becomes Flare in Astral Fire with 1 or fewer Umbral Hearts.", BLM.JobID)]
        BlackFire2Feature = 2508,

        [CustomComboInfo("Ice 2 Feature", "(High) Blizzard 2 becomes Freeze in Umbral Ice.", BLM.JobID)]
        BlackBlizzard2Feature = 2509,

        [CustomComboInfo("Scathe/Xenoglossy Feature", "Scathe becomes Xenoglossy when available.", BLM.JobID)]
        BlackScatheFeature = 2507,

        #endregion
        // ====================================================================================
        #region BARD

        [CustomComboInfo("Wanderer's into Pitch Perfect", "Replaces Wanderer's Minuet with Pitch Perfect while in WM.", BRD.JobID)]
        BardWanderersPitchPerfectFeature = 2301,

        [CustomComboInfo("Heavy Shot into Straight Shot", "Replaces Heavy Shot with Straight Shot/Refulgent Arrow when available.", BRD.JobID)]
        BardStraightShotUpgradeFeature = 2302,

        [CustomComboInfo("Iron Jaws Feature", "Iron Jaws is replaced with Caustic Bite/Stormbite if one or both are not up.\nAlternates between the two if Iron Jaws isn't available.", BRD.JobID)]
        BardIronJawsFeature = 2303,

        [CustomComboInfo("Burst Shot/Quick Nock into Apex Arrow", "Replaces Burst Shot and Quick Nock with Apex Arrow when gauge is full.", BRD.JobID)]
        BardApexFeature = 2304,

        [CustomComboInfo("Quick Nock into Shadowbite", "Replaces Quick Nock with Shadowbite when available.", BRD.JobID)]
        BardShadowbiteFeature = 2305,

        // [CustomComboInfo("Bloodletter Feature", "Replaces Bloodletter with Empyreal Arrow and Sidewinder depending on which is available.", BRD.JobID)]
        // BardBloodletterFeature = 2306,

        // [CustomComboInfo("Rain of Death Feature", "Replaces Rain of Death with Empyreal Arrow and Sidewinder depending on which is available.", BRD.JobID)]
        // BardRainOfDeathFeature = 2307,

        #endregion
        // ====================================================================================
        #region DANCER

        [CustomComboInfo("Fan Dance Combos", "Change Fan Dance and Fan Dance 2 into Fan Dance 3 while flourishing.", DNC.JobID)]
        DancerFanDanceCombo = 3801,

        [SecretCustomCombo]
        [ConflictingCombos(DancerDanceComboCompatibility)]
        [CustomComboInfo("Dance Step Combo", "Change Standard Step and Technical Step into each dance step while dancing.", DNC.JobID)]
        DancerDanceStepCombo = 3802,

        [CustomComboInfo("Flourish Proc Saver", "Change Flourish into any available procs before using.", DNC.JobID)]
        DancerFlourishFeature = 3803,

        [CustomComboInfo("Single Target Multibutton", "Change Cascade into procs and combos as available.", DNC.JobID)]
        DancerSingleTargetMultibutton = 3804,

        [CustomComboInfo("AoE Multibutton", "Change Windmill into procs and combos as available.", DNC.JobID)]
        DancerAoeMultibutton = 3805,

        [ConflictingCombos(DancerDanceStepCombo)]
        [CustomComboInfo(
            "Dance Step Feature",
            "Change actions into dance steps while dancing." +
            "\nThis helps ensure you can still dance with combos on, without using auto dance." +
            "\nYou can change the respective actions by inputting action IDs below for each dance step." +
            "\nThe defaults are Cascade, Flourish, Fan Dance and Fan Dance II. If set to 0, they will reset to these actions." +
            "\nYou can get Action IDs with Garland Tools by searching for the action and clicking the cog.",
            DNC.JobID)]
        DancerDanceComboCompatibility = 3806,

        [CustomComboInfo("Devilment Feature", "Change Devilment into Starfall Dance after use.", DNC.JobID)]
        DancerDevilmentFeature = 3807,

        #endregion
        // ====================================================================================
        #region DARK KNIGHT

        [CustomComboInfo("Souleater Combo", "Replace Souleater with its combo chain.", DRK.JobID)]
        DarkSouleaterCombo = 3201,

        [CustomComboInfo("Stalwart Soul Combo", "Replace Stalwart Soul with its combo chain.", DRK.JobID)]
        DarkStalwartSoulCombo = 3202,

        [CustomComboInfo("Delirium Feature", "Replace Souleater and Stalwart Soul with Bloodspiller and Quietus when Delirium is active.", DRK.JobID)]
        DarkDeliriumFeature = 3203,

        // [SecretCustomCombo]
        // [CustomComboInfo("Salted Shadowbringer Stuff", "Replace Cave and Spit and Abyssal Drain with Salted Earth and Shadowbringer depending on cooldown.", DRK.JobID)]
        // DarkShadowbringerFeature = 3204,

        #endregion
        // ====================================================================================
        #region DRAGOON

        [CustomComboInfo("Jump + Mirage Dive", "Replace (High) Jump with Mirage Dive when Dive Ready.", DRG.JobID)]
        DragoonJumpFeature = 2201,

        [CustomComboInfo("Coerthan Torment Combo", "Replace Coerthan Torment with its combo chain.", DRG.JobID)]
        DragoonCoerthanTormentCombo = 2202,

        [CustomComboInfo("Chaos Thrust Combo", "Replace Chaos Thrust with its combo chain.", DRG.JobID)]
        DragoonChaosThrustCombo = 2203,

        [CustomComboInfo("Full Thrust Combo", "Replace Full Thrust with its combo chain.", DRG.JobID)]
        DragoonFullThrustCombo = 2204,

        [CustomComboInfo("Wheeling Thrust / Fang and Claw Option", "When you have either Enhanced Fang and Claw or Wheeling Thrust, Chaos Thrust becomes Wheeling Thrust and Full Thrust becomes Fang and Claw.", DRG.JobID)]
        DragoonFangThrustFeature = 2205,

        // [SecretCustomCombo]
        // [CustomComboInfo("Dive Dive Dive!", "Replace Spineshatter Dive, Dragonfire Dive, and Stardiver with whichever is available.", DRG.JobID)]
        // DragoonDiveFeature = 2205,

        #endregion
        // ====================================================================================
        #region GUNBREAKER

        [CustomComboInfo("Solid Barrel Combo", "Replace Solid Barrel with its combo chain.", GNB.JobID)]
        GunbreakerSolidBarrelCombo = 3701,

        [CustomComboInfo("Gnashing Fang Continuation", "Replace Gnashing Fang with Continuation moves when appropriate.", GNB.JobID)]
        GunbreakerGnashingFangCont = 3702,

        [CustomComboInfo("Burst Strike Continuation", "Replace Burst Strike with Continuation moves when appropriate.", GNB.JobID)]
        GunbreakerBurstStrikeCont = 3703,

        [SecretCustomCombo]
        [CustomComboInfo("Bow Shock / Sonic Break Feature", "Replace Bow Shock and Sonic Break with one or the other depending on which is on cooldown.", GNB.JobID)]
        GunbreakerBowShockSonicBreakFeature = 3704,

        [CustomComboInfo("Demon Slaughter Combo", "Replace Demon Slaughter with its combo chain.", GNB.JobID)]
        GunbreakerDemonSlaughterCombo = 3705,

        [CustomComboInfo("Fated Circle Feature", "In addition to the Demon Slaughter combo, add Fated Circle when charges are full.", GNB.JobID)]
        GunbreakerFatedCircleFeature = 3706,

        [CustomComboInfo("Empty Bloodfest Feature", "Replace Burst Strike and Fated Circle with Bloodfest if the powder gauge is empty.", GNB.JobID)]
        GunbreakerEmptyBloodfestFeature = 3707,

        [SecretCustomCombo]
        [CustomComboInfo("No Mercy Feature", "Replace No Mercy with Bow Shock, and then Sonic Break, while No Mercy is active.", GNB.JobID)]
        GunbreakerNoMercyFeature = 3708,

        [SecretCustomCombo]
        [CustomComboInfo("Double Down Feature", "Replace Burst Strike and Fated Circle with Double Down when available.", GNB.JobID)]
        GunbreakerDoubleDownFeature = 3709,

        #endregion
        // ====================================================================================
        #region MACHINIST

        [CustomComboInfo("(Heated) Shot Combo", "Replace Clean Shot with its combo chain.", MCH.JobID)]
        MachinistMainCombo = 3101,

        [CustomComboInfo("Spread Shot Heat", "Replace Spread Shot with Auto Crossbow when overheated.", MCH.JobID)]
        MachinistSpreadShotFeature = 3102,

        [CustomComboInfo("Hypercharge Feature", "Replace Heat Blast and Auto Crossbow with Hypercharge when not overheated.", MCH.JobID)]
        MachinistOverheatFeature = 3103,

        [CustomComboInfo("Overdrive Feature", "Replace Rook Autoturret with Overdrive while active.", MCH.JobID)]
        MachinistOverdriveFeature = 3104,

        [SecretCustomCombo]
        [CustomComboInfo("Gauss Round / Ricochet Feature", "Replace Gauss Round and Ricochet with one or the other depending on which has more charges.", MCH.JobID)]
        MachinistGaussRoundRicochetFeature = 3105,

        [SecretCustomCombo]
        [CustomComboInfo("Hot Shot (Air Anchor) / Drill / Chainsaw Feature", "Replace Hot Shot (Air Anchor), Drill, and Chainsaw with whichever is available.", MCH.JobID)]
        MachinistHotShotDrillChainsawFeature = 3106,

        #endregion
        // ====================================================================================
        #region MONK

        [CustomComboInfo("Monk AoE Combo", "Replaces Rockbreaker with the AoE combo chain.", MNK.JobID)]
        MonkAoECombo = 2001,

        [CustomComboInfo("Monk Disciplined AoE Feature", "Replace Rockbreaker with Four Point Fury while Formless Fist is active.", MNK.JobID)]
        MonkAoEDisciplinedFeature = 2007,

        [CustomComboInfo("Monk Lunar AoE Feature", "Replace Rockbreaker with Shadow of the Destroyer (or Rockbreaker depending on level) when Perfect Balance is active and the Lunar Nadi is missing.", MNK.JobID)]
        MonkAoELunarFeature = 2006,

        [CustomComboInfo("Monk Solar AoE Feature", "Replace Rockbreaker with whatever is necessary to acquire missing Beast Chakra when Perfect Balance is active and the Solar Nadi is missing.", MNK.JobID)]
        MonkAoESolarFeature = 2005,

        [CustomComboInfo("Monk AoE Balance Feature", "Replaces Rockbreaker with Masterful Blitz if you have 3 Beast Chakra.", MNK.JobID)]
        MonkAoEBalanceFeature = 2002,

        [CustomComboInfo("Monk Four Point Fury AoE Feature", "Replace Four Point Fury with Shadow of the Destroyer (or Rockbreaker depending on level) when Perfect Balance is active.", MNK.JobID)]
        MonkAoEFpfFeature = 2008,

        [CustomComboInfo("Howling Fist / Meditation Feature", "Replace Howling Fist with Meditation when the Fifth Chakra is not open.", MNK.JobID)]
        MonkHowlingFistMeditationFeature = 2003,

        [CustomComboInfo("Perfect Balance Feature", "Replace Perfect Balance with Masterful Blitz when you have 3 Beast Chakra.", MNK.JobID)]
        MonkPerfectBalanceFeature = 2004,

        #endregion
        // ====================================================================================
        #region NINJA

        [CustomComboInfo("Armor Crush Combo", "Replace Armor Crush with its combo chain.", NIN.JobID)]
        NinjaArmorCrushCombo = 3001,

        [CustomComboInfo("Aeolian Edge Combo", "Replace Aeolian Edge with its combo chain.", NIN.JobID)]
        NinjaAeolianEdgeCombo = 3002,

        [CustomComboInfo("Hakke Mujinsatsu Combo", "Replace Hakke Mujinsatsu with its combo chain.", NIN.JobID)]
        NinjaHakkeMujinsatsuCombo = 3003,

        [CustomComboInfo("Kassatsu to Trick", "Replaces Kassatsu with Trick Attack while Suiton or Hidden is up.\nCooldown tracking plugin recommended.", NIN.JobID)]
        NinjaKassatsuTrickFeature = 3004,

        [CustomComboInfo("Ten Chi Jin to Meisui", "Replaces Ten Chi Jin (the move) with Meisui while Suiton is up.\nCooldown tracking plugin recommended.", NIN.JobID)]
        NinjaTCJMeisuiFeature = 3005,

        [CustomComboInfo("Kassatsu Chi/Jin Feature", "Replaces Chi with Jin while Kassatsu is up if you have Enhanced Kassatsu.", NIN.JobID)]
        NinjaKassatsuChiJinFeature = 3006,

        [CustomComboInfo("Hide to Mug", "Replaces Hide with Mug while in combat.", NIN.JobID)]
        NinjaHideMugFeature = 3007,

        [ConflictingCombos(NinjaGCDNinjutsuFeature)]
        [CustomComboInfo("Aeolian to Ninjutsu Feature", "Replaces Aeolian Edge (combo) with Ninjutsu if any Mudra are used.", NIN.JobID)]
        NinjaNinjutsuFeature = 3008,

        [ConflictingCombos(NinjaNinjutsuFeature)]
        [CustomComboInfo("GCDs to Ninjutsu Feature", "Every GCD combo becomes Ninjutsu while Mudras are being used.", NIN.JobID)]
        NinjaGCDNinjutsuFeature = 3009,

        [CustomComboInfo("Bunshin / Kamaitachi Feature", "Replaces Bunshin with Phantom Kamaitachi after usage.", NIN.JobID)]
        NinjaBunshinKamaitachiFeature = 3010,

        [CustomComboInfo("Armor Crush / Raiju Feature", "Replaces the Armor Crush combo with Forked and Fleeting Raiju when available.", NIN.JobID)]
        NinjaArmorCrushRaijuFeature = 3012,

        [CustomComboInfo("Aeolian Edge / Raiju Feature", "Replaces the Aeolian Edge combo with Forked and Fleeting Raiju when available.", NIN.JobID)]
        NinjaAeolianEdgeRaijuFeature = 3013,

        [CustomComboInfo("Huraijin / Raiju Feature", "Replaces Huraijin with Forked and Fleeting Raiju when available.", NIN.JobID)]
        NinjaHuraijinRaijuFeature = 3011,

        #endregion
        // ====================================================================================
        #region PALADIN

        [CustomComboInfo("Goring Blade Combo", "Replace Goring Blade with its combo chain.", PLD.JobID)]
        PaladinGoringBladeCombo = 1901,

        [CustomComboInfo("Goring Blade Atonement Feature", "Replace Goring Blade with Atonement when under the effect of Sword Oath.", PLD.JobID)]
        PaladinGoringBladeAtonementFeature = 1909,

        [CustomComboInfo("Royal Authority Combo", "Replace Royal Authority with its combo chain.", PLD.JobID)]
        PaladinRoyalAuthorityCombo = 1902,

        [CustomComboInfo("Royal Authority Atonement Feature", "Replace Royal Authority with Atonement when under the effect of Sword Oath.", PLD.JobID)]
        PaladinRoyalAuthorityAtonementFeature = 1903,

        [CustomComboInfo("Prominence Combo", "Replace Prominence with its combo chain.", PLD.JobID)]
        PaladinProminenceCombo = 1904,

        [CustomComboInfo("Requiescat Confiteor", "Replace Requiescat with Confiter while under the effect of Requiescat.", PLD.JobID)]
        PaladinRequiescatCombo = 1905,

        [SecretCustomCombo]
        [CustomComboInfo("Confiteor Feature", "Replace Holy Spirit/Circle with Confiteor when Requiescat is up and MP is under 2000 or only one stack remains.", PLD.JobID)]
        PaladinConfiteorFeature = 1907,

        [SecretCustomCombo]
        [CustomComboInfo("Scornful Spirits Feature", "Replace Spirits Within and Circle of Scorn with whichever is available soonest.", PLD.JobID)]
        PaladinScornfulSpiritsFeature = 1908,

        #endregion
        // ====================================================================================
        #region REAPER

        [CustomComboInfo("Slice Combo", "Replace Infernal Slice with its combo chain.", RPR.JobID)]
        ReaperSliceCombo = 3901,

        [CustomComboInfo("Scythe Combo", "Replace Nightmare Scythe with its combo chain.", RPR.JobID)]
        ReaperScytheCombo = 3902,

        [CustomComboInfo("Soul Reaver Gibbet Feature", "Replace Infernal Slice with Gibbet while Reaving or Enshrouded.", RPR.JobID)]
        ReaperSoulReaverGibbetFeature = 3903,

        [ParentCombo(ReaperSoulReaverGibbetFeature)]
        [CustomComboInfo("Soul Reaver Gibbet Option", "Replace Infernal Slice with Gallows instead while Reaving or Enshrouded.", RPR.JobID)]
        ReaperSoulReaverGibbetOption = 3904,

        [CustomComboInfo("Soul Reaver Gallows Feature", "Replace Shadow of Death with Gallows while Reaving or Enshrouded.", RPR.JobID)]
        ReaperSoulReaverGallowsFeature = 3905,

        [ParentCombo(ReaperSoulReaverGallowsFeature)]
        [CustomComboInfo("Soul Reaver Gallows Option", "Replace Shadow of Death with Gibbet instead while Reaving or Enshrouded.", RPR.JobID)]
        ReaperSoulReaverGallowsOption = 3906,

        [CustomComboInfo("Soul Reaver Guillotine Option", "Replace Nightmare Scythe with Guillotine while Reaving or Enshrouded.", RPR.JobID)]
        ReaperSoulReaverGuillotineFeature = 3907,

        [CustomComboInfo("Lemure's Soul Reaver Feature", "Replace Gibbet, Gallows, and Guillotine (and in other combos) with Lemure's Slice or Scythe when two or more stacks of Void Shroud are active.", RPR.JobID)]
        ReaperLemuresSoulReaverFeature = 3911,

        [SecretCustomCombo]
        [CustomComboInfo("Communio Soul Reaver Feature", "Replace Gibbet, Gallows, and Guillotine (and in other combos) with Communio when one stack is left of Shroud.", RPR.JobID)]
        ReaperCommunioSoulReaverFeature = 3912,

        [CustomComboInfo("Arcane Harvest Feature", "Replace Arcane Circle with Plentiful Harvest when you have stacks of Immortal Sacrifice.", RPR.JobID)]
        ReaperHarvestFeature = 3908,

        [CustomComboInfo("Enshroud Communio Feature", "Replace Enshroud with Communio when Enshrouded.", RPR.JobID)]
        ReaperEnshroudCommunioFeature = 3909,

        [CustomComboInfo("Regress Feature", "Both Hell's Ingress and Egress turn into Regress when Threshold is active, instead of just the opposite of the one used.", RPR.JobID)]
        ReaperRegressFeature = 3910,

        #endregion
        // ====================================================================================
        #region RED MAGE

        [CustomComboInfo("Red Mage AoE Combo", "Replaces Veraero/Verthunder 2 with Impact when Dualcast or Swiftcast are active.", RDM.JobID)]
        RedMageAoECombo = 3501,

        [CustomComboInfo("Redoublement combo", "Replaces Redoublement with its combo chain, following enchantment rules.", RDM.JobID)]
        RedMageMeleeCombo = 3502,

        [SecretCustomCombo]
        [ParentCombo(RedMageMeleeCombo)]
        [CustomComboInfo("Redoublement Combo Plus", "Replaces Redoublement (and Moulinet) with Verflare/Verholy (and then Scorch and Resolution) after 3 mana stacks, whichever is more appropriate.", RDM.JobID)]
        RedMageMeleeComboPlus = 3503,

        [CustomComboInfo("Verproc into Jolt", "Replaces Verstone/Verfire with Jolt/Scorch when no proc is available.", RDM.JobID)]
        RedMageVerprocCombo = 3504,

        [ParentCombo(RedMageVerprocCombo)]
        [CustomComboInfo("Verproc into Jolt Plus", "Additionally replaces Verstone/Verfire with Veraero/Verthunder if Dualcast, Swiftcast, or Lost Chainspell are up.", RDM.JobID)]
        RedMageVerprocComboPlus = 3505,

        [ParentCombo(RedMageVerprocComboPlus)]
        [CustomComboInfo("Verproc into Jolt Plus Opener Feature (Stone)", "Turns Verstone into Veraero when out of combat.", RDM.JobID)]
        RedMageVerprocOpenerFeatureStone = 3506,

        [ParentCombo(RedMageVerprocComboPlus)]
        [CustomComboInfo("Verproc into Jolt Plus Opener Feature (Fire)", "Turns Verfire into Verthunder when out of combat.", RDM.JobID)]
        RedMageVerprocOpenerFeatureFire = 3507,

        // [SecretCustomCombo]
        // [CustomComboInfo("Contre Sixte / Fleche Feature", "Turns Contre Sixte and Fleche into whichever is available.", RDM.JobID)]
        // RedMageContreFlecheFeature = 3508,

        #endregion
        // ====================================================================================
        #region SAGE

        // [CustomComboInfo("Kardia Into Soteria", "Kardia turns into Soteria when active and Soteria is off-cooldown.", SGE.JobID)]
        // SageKardiaFeature = 4001,

        [CustomComboInfo("Taurochole Into Druochole Feature", "Taurochole changes into Druochole while Taurochole is on cooldown")]
        SageTaurocholeDruocholeFeature = 4002,

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

        [CustomComboInfo("Shinten to Senei", "Replace Hissatsu: Shinten with Senei when available.", SAM.JobID)]
        SamuraiShintenSeneiFeature = 3414,

        [CustomComboInfo("Shinten to Shoha", "Replace Hissatsu: Shinten with Shoha when Meditation is full.", SAM.JobID)]
        SamuraiShintenShohaFeature = 3413,

        [CustomComboInfo("Kyuten to Guren", "Replace Hissatsu: Kyuten with Guren when available.", SAM.JobID)]
        SamuraiKyutenGurenFeature = 3415,

        [CustomComboInfo("Kyuten to Shoha II", "Replace Hissatsu: Kyuten with Shoha II when Meditation is full.", SAM.JobID)]
        SamuraiKyutenShoha2Feature = 3412,

        [CustomComboInfo("Ikishoten Namikiri Feature", "Replace Ikishoten with Ogi Namikiri, Shoha, and then Kaeshi Namikiri when available.", SAM.JobID)]
        SamuraiIkishotenNamikiriFeature = 3411,

        #endregion
        // ====================================================================================
        #region SCHOLAR

        [CustomComboInfo("Seraph Fey Blessing/Consolation", "Change Fey Blessing into Consolation when Seraph is out.", SCH.JobID)]
        ScholarSeraphConsolationFeature = 2801,

        [CustomComboInfo("ED Aetherflow", "Change Energy Drain into Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
        ScholarEnergyDrainFeature = 2802,

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

        [CustomComboInfo("Radiant Carbuncle Feature", "Change Radiant Aegis into Summon Carbuncle when no pet has been summoned.", SMN.JobID)]
        SummonerRadiantCarbuncleFeature = 2711,

        [CustomComboInfo("Searing Carbuncle Feature", "Change Searing Light into Summon Carbuncle when no pet has been summoned.", SMN.JobID)]
        SummonerSearingCarbuncleFeature = 2712,

        #endregion
        // ====================================================================================
        #region WARRIOR

        [CustomComboInfo("Storms Path Combo", "Replace Storms Path with its combo chain.", WAR.JobID)]
        WarriorStormsPathCombo = 2101,

        [CustomComboInfo("Storms Eye Combo", "Replace Storms Eye with its combo chain.", WAR.JobID)]
        WarriorStormsEyeCombo = 2102,

        [CustomComboInfo("Mythril Tempest Combo", "Replace Mythril Tempest with its combo chain.", WAR.JobID)]
        WarriorMythrilTempestCombo = 2103,

        // [CustomComboInfo("Overpower Combo", "Replace Overpower with its combo chain (so that you can still use Mythril Tempest by itself in pulls)", WAR.JobID, WAR.Overpower)]
        // WarriorOverpowerCombo = 2104,

        // [CustomComboInfo("Warrior Gauge Overcap Feature", "Replace Single-target or AoE combo with gauge spender if you are about to overcap and are before a step of a combo that would generate beast gauge.", WAR.JobID)]
        // WarriorGaugeOvercapFeature = 2104,

        // [CustomComboInfo("Inner Release Feature", "Replace Single-target and AoE combo with Fell Cleave/Decimate during Inner Release.", WAR.JobID)]
        // WarriorInnerReleaseFeature = 2105,

        [CustomComboInfo("Nascent Flash Feature", "Replace Nascent Flash with Raw intuition when level synced below 76.", WAR.JobID)]
        WarriorNascentFlashFeature = 2106,

        [CustomComboInfo("Primal Beast Feature", "Replace Inner Beast and Steel Cyclone with Primal Rend when available", WAR.JobID)]
        WarriorPrimalBeastFeature = 2107,

        [CustomComboInfo("Primal Release Feature", "Replace Inner Release with Primal Rend when available", WAR.JobID)]
        WarriorPrimalReleaseFeature = 2108,

        #endregion
        // ====================================================================================
        #region WHITE MAGE

        [CustomComboInfo("Solace into Misery", "Replaces Afflatus Solace with Afflatus Misery when Misery is ready to be used.", WHM.JobID)]
        WhiteMageSolaceMiseryFeature = 2401,

        [CustomComboInfo("Rapture into Misery", "Replaces Afflatus Rapture with Afflatus Misery when Misery is ready to be used.", WHM.JobID)]
        WhiteMageRaptureMiseryFeature = 2402,

        [CustomComboInfo("Cure 2 to Cure Level Sync", "Changes Cure 2 to Cure when below level 30 in synced content.", WHM.JobID)]
        WhiteMageCureFeature = 2403,

        [CustomComboInfo("Afflatus Feature", "Changes Cure 2 into Afflatus Solace, and Medica into Afflatus Rapture, when lilies are up.", WHM.JobID)]
        WhiteMageAfflatusFeature = 2404,

        #endregion
        // ====================================================================================
        #region DOH

        // [CustomComboInfo("Touch Combo", "Replaces Basic Touch with its combo chain.", DOH.JobID)]
        // DohTouchCombo = 50001,

        #endregion
        // ====================================================================================
        #region DOL

        // [CustomComboInfo("Eureka Feature", "Replaces Ageless Words and Solid Reason with Wise to the World when available.", DOL.JobID)]
        // DolEurekaFeature = 51001,

        #endregion
        // ====================================================================================
    }
}
