using XIVComboExpandedPlugin.Attributes;
using XIVComboExpandedPlugin.Combos;

namespace XIVComboExpandedPlugin
{
    /// <summary>
    /// Combo presets.
    /// </summary>
    public enum CustomComboPreset
    {
        // Last enum used: 111
        // Available: 28,38,45,46
        // ====================================================================================
        #region ASTROLOGIAN

        [OrderedEnum]
        [CustomComboInfo("Draw on Play", "Play turns into Draw when no card is drawn, as well as the usual Play behavior.", AST.JobID, AST.Play)]
        AstrologianCardsOnDrawFeature = 27,

        [OrderedEnum]
        [CustomComboInfo("Minor Arcana Play Feature", "Changes Minor Arcana to Crown Play when a card drawn.", AST.JobID, AST.MinorArcana)]
        AstrologianMinorArcanaPlayFeature = 75,

        [OrderedEnum]
        [CustomComboInfo("Benefic 2 to Benefic Level Sync", "Changes Benefic 2 to Benefic when below level 26 in synced content.", AST.JobID, AST.Benefic2)]
        AstrologianBeneficFeature = 73,

        #endregion
        // ====================================================================================
        #region BLACK MAGE

        [OrderedEnum]
        [CustomComboInfo("Enochian Feature", "Change Fire 4 or Blizzard 4 to the other depending on stance.", BLM.JobID, BLM.Fire4, BLM.Blizzard4)]
        BlackEnochianFeature = 25,

        [OrderedEnum]
        [CustomComboInfo("Umbral Soul/Transpose Switcher", "Change Transpose into Umbral Soul when Umbral Soul is usable.", BLM.JobID, BLM.Transpose)]
        BlackManaFeature = 26,

        [OrderedEnum]
        [CustomComboInfo("(Between the) Ley Lines", "Change Ley Lines into BTL when Ley Lines is active.", BLM.JobID, BLM.LeyLines)]
        BlackLeyLinesFeature = 56,

        [OrderedEnum]
        [CustomComboInfo("Fire 1/3 Feature", "Fire 1 becomes Fire 3 outside of Astral Fire, and when Firestarter proc is up.", BLM.JobID, BLM.Fire)]
        BlackFireFeature = 70,

        [OrderedEnum]
        [CustomComboInfo("Blizzard 1/3 Feature", "Blizzard 1 becomes Blizzard 3 when out of Umbral Ice.", BLM.JobID, BLM.Blizzard)]
        BlackBlizzardFeature = 71,

        [OrderedEnum]
        [CustomComboInfo("Freeze Feature", "Freeze becomes Blizzard 2 when synced.", BLM.JobID, BLM.Freeze)]
        BlackFreezeFeature = 110,

        [OrderedEnum]
        [CustomComboInfo("Scathe/Xenoglossy Feature", "Scathe becomes Xenoglossy when available.", BLM.JobID, BLM.Scathe)]
        BlackScatheFeature = 95,

        #endregion
        // ====================================================================================
        #region BARD

        [OrderedEnum]
        [CustomComboInfo("Wanderer's into Pitch Perfect", "Replaces Wanderer's Minuet with Pitch Perfect while in WM.", BRD.JobID, BRD.WanderersMinuet)]
        BardWanderersPitchPerfectFeature = 41,

        [OrderedEnum]
        [CustomComboInfo("Heavy Shot into Straight Shot", "Replaces Heavy Shot/Burst Shot with Straight Shot/Refulgent Arrow when procced.", BRD.JobID, BRD.HeavyShot, BRD.BurstShot)]
        BardStraightShotUpgradeFeature = 42,

        [OrderedEnum]
        [CustomComboInfo("Iron Jaws Feature", "Iron Jaws is replaced with Caustic Bite/Stormbite if one or both are not up.\nAlternates between the two if Iron Jaws isn't available.", BRD.JobID, BRD.IronJaws)]
        BardIronJawsFeature = 63,

        // [CustomComboInfo("Burst Shot/Quick Nock into Apex Arrow", "Replaces Burst Shot and Quick Nock with Apex Arrow when gauge is full.", BRD.JobID, BRD.BurstShot, BRD.QuickNock)]
        // BardApexFeature = 74,

        #endregion
        // ====================================================================================
        #region DANCER

        [OrderedEnum]
        [CustomComboInfo("Fan Dance Combos", "Change Fan Dance and Fan Dance 2 into Fan Dance 3 while flourishing.", DNC.JobID, DNC.FanDance1, DNC.FanDance2)]
        DancerFanDanceCombo = 33,

        [OrderedEnum]
        [SecretCustomCombo]
        [ConflictingCombos(DancerDanceComboCompatibility)]
        [CustomComboInfo("Dance Step Combo", "Change Standard Step and Technical Step into each dance step while dancing.", DNC.JobID, DNC.StandardStep, DNC.TechnicalStep)]
        DancerDanceStepCombo = 31,

        [OrderedEnum]
        [CustomComboInfo("Flourish Proc Saver", "Change Flourish into any available procs before using.", DNC.JobID, DNC.Flourish)]
        DancerFlourishFeature = 34,

        [OrderedEnum]
        [CustomComboInfo("Single Target Multibutton", "Change Cascade into procs and combos as available.", DNC.JobID, DNC.Cascade)]
        DancerSingleTargetMultibutton = 43,

        [OrderedEnum]
        [CustomComboInfo("AoE Multibutton", "Change Windmill into procs and combos as available.", DNC.JobID, DNC.Windmill)]
        DancerAoeMultibutton = 50,

        [OrderedEnum]
        [ConflictingCombos(DancerDanceStepCombo)]
        [CustomComboInfo(
            "Dance Step Feature",
            "Change actions into dance steps while dancing." +
            "\nThis helps ensure you can still dance with combos on, without using auto dance." +
            "\nYou can change the respective actions by inputting action IDs below for each dance step." +
            "\nThe defaults are Cascade, Flourish, Fan Dance and Fan Dance II. If set to 0, they will reset to these actions." +
            "\nYou can get Action IDs with Garland Tools by searching for the action and clicking the cog.",
            DNC.JobID)]
        DancerDanceComboCompatibility = 72,

        [OrderedEnum]
        [CustomComboInfo("Devilment Feature", "Change Devilment into Starfall Dance after use.", DNC.JobID, DNC.Devilment)]
        DancerDevilmentFeature = 103,

        #endregion
        // ====================================================================================
        #region DRAGOON

        [OrderedEnum]
        [CustomComboInfo("Jump + Mirage Dive", "Replace (High) Jump with Mirage Dive when Dive Ready.", DRG.JobID, DRG.Jump, DRG.HighJump)]
        DragoonJumpFeature = 44,

        [OrderedEnum]
        [CustomComboInfo("Coerthan Torment Combo", "Replace Coerthan Torment with its combo chain.", DRG.JobID, DRG.CoerthanTorment)]
        DragoonCoerthanTormentCombo = 0,

        [OrderedEnum]
        [CustomComboInfo("Chaos Thrust Combo", "Replace Chaos Thrust with its combo chain.", DRG.JobID, DRG.ChaosThrust)]
        DragoonChaosThrustCombo = 1,

        [OrderedEnum]
        [CustomComboInfo("Full Thrust Combo", "Replace Full Thrust with its combo chain.", DRG.JobID, DRG.FullThrust)]
        DragoonFullThrustCombo = 2,

        #endregion
        // ====================================================================================
        #region DARK KNIGHT

        [OrderedEnum]
        [CustomComboInfo("Souleater Combo", "Replace Souleater with its combo chain.", DRK.JobID, DRK.Souleater)]
        DarkSouleaterCombo = 3,

        [OrderedEnum]
        [CustomComboInfo("Stalwart Soul Combo", "Replace Stalwart Soul with its combo chain.", DRK.JobID, DRK.StalwartSoul)]
        DarkStalwartSoulCombo = 4,

        [OrderedEnum]
        [CustomComboInfo("Delirium Feature", "Replace Souleater and Stalwart Soul with Bloodspiller and Quietus when Delirium is active.", DRK.JobID, DRK.Souleater, DRK.StalwartSoul)]
        DeliriumFeature = 57,

        // [CustomComboInfo("Dark Knight Gauge Overcap Feature", "Replace AoE combo with gauge spender if you are about to overcap.", DRK.JobID, DRK.StalwartSoul)]
        // DRKOvercapFeature = 85,

        #endregion
        // ====================================================================================
        #region GUNBREAKER

        [OrderedEnum]
        [CustomComboInfo("Solid Barrel Combo", "Replace Solid Barrel with its combo chain.", GNB.JobID, GNB.SolidBarrel)]
        GunbreakerSolidBarrelCombo = 20,

        [OrderedEnum]
        [CustomComboInfo("Gnashing Fang Continuation", "Replace Gnashing Fang with Continuation moves when appropriate.", GNB.JobID, GNB.GnashingFang)]
        GunbreakerGnashingFangCont = 52,

        [OrderedEnum]
        [CustomComboInfo("Burst Strike Continuation", "Replace Burst Strike with Continuation moves when appropriate.", GNB.JobID, GNB.BurstStrike)]
        GunbreakerBurstStrikeCont = 96,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Bow Shock / Sonic Break Feature", "Replace Bow Shock and Sonic Break with one or the other depending on which is on cooldown.", GNB.JobID, GNB.BowShock, GNB.SonicBreak)]
        GunbreakerBowShockSonicBreakFeature = 97,

        [OrderedEnum]
        [CustomComboInfo("Demon Slaughter Combo", "Replace Demon Slaughter with its combo chain.", GNB.JobID, GNB.DemonSlaughter)]
        GunbreakerDemonSlaughterCombo = 22,

        [OrderedEnum]
        [CustomComboInfo("Fated Circle Feature", "In addition to the Demon Slaughter combo, add Fated Circle when charges are full.", GNB.JobID, GNB.DemonSlaughter)]
        GunbreakerFatedCircleFeature = 30,

        // [OrderedEnum]
        // [CustomComboInfo("Burst Strike to Bloodfest Feature", "Replace Burst Strike with Bloodfest if you have no powder gauge.", GNB.JobID, GNB.BurstStrike)]
        // GunbreakerBloodfestOvercapFeature = 83,

        // [OrderedEnum]
        // [CustomComboInfo("No Mercy Feature", "Replace No Mercy with Bow Shock, and then Sonic Break, while No Mercy is active.", GNB.JobID, GNB.NoMercy)]
        // GunbreakerNoMercyFeature = 84,

        #endregion
        // ====================================================================================
        #region MACHINIST

        [OrderedEnum]
        [CustomComboInfo("(Heated) Shot Combo", "Replace either form of Clean Shot with its combo chain.", MCH.JobID, MCH.CleanShot, MCH.HeatedCleanShot)]
        MachinistMainCombo = 23,

        [OrderedEnum]
        [CustomComboInfo("Spread Shot Heat", "Replace Spread Shot with Auto Crossbow when overheated.", MCH.JobID, MCH.SpreadShot)]
        MachinistSpreadShotFeature = 24,

        [OrderedEnum]
        [CustomComboInfo("Hypercharge Feature", "Replace Heat Blast and Auto Crossbow with Hypercharge when not overheated.", MCH.JobID, MCH.HeatBlast, MCH.AutoCrossbow)]
        MachinistOverheatFeature = 47,

        [OrderedEnum]
        [CustomComboInfo("Overdrive Feature", "Replace Rook Autoturret and Automaton Queen with Overdrive while active.", MCH.JobID, MCH.RookAutoturret, MCH.AutomatonQueen)]
        MachinistOverdriveFeature = 58,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Gauss Round / Ricochet Feature", "Replace Gauss Round and Ricochet with one or the other depending on which has more charges.", MCH.JobID, MCH.GaussRound, MCH.Ricochet)]
        MachinistGaussRoundRicochetFeature = 66,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Hot Shot (Air Anchor) / Drill / Chainsaw Feature", "Replace Hot Shot (Air Anchor), Drill, and Chainsaw with whichever is available.", MCH.JobID, MCH.HotShot, MCH.AirAnchor, MCH.Drill, MCH.Chainsaw)]
        MachinistHotShotDrillChainsawFeature = 102,

        #endregion
        // ====================================================================================
        #region MONK

        [OrderedEnum]
        [CustomComboInfo("Monk AoE Combo", "Replaces Rockbreaker with the AoE combo chain, or Rockbreaker when Perfect Balance is active.", MNK.JobID, MNK.Rockbreaker)]
        MonkAoECombo = 54,

        // [CustomComboInfo("Monk Bootshine Feature", "Replaces Dragon Kick with Bootshine if both a form and Leaden Fist are up.", MNK.JobID, MNK.DragonKick)]
        // MnkBootshineFeature = 82,

        [OrderedEnum]
        [CustomComboInfo("Howling Fist / Meditation Feature", "Howling Fist with Meditation when the Fifth Chakra is not open.", MNK.JobID, MNK.HowlingFist)]
        MonkHowlingFistMeditationFeature = 106,

        #endregion
        // ====================================================================================
        #region NINJA

        [OrderedEnum]
        [CustomComboInfo("Armor Crush Combo", "Replace Armor Crush with its combo chain.", NIN.JobID, NIN.ArmorCrush)]
        NinjaArmorCrushCombo = 17,

        [OrderedEnum]
        [CustomComboInfo("Aeolian Edge Combo", "Replace Aeolian Edge with its combo chain.", NIN.JobID, NIN.AeolianEdge)]
        NinjaAeolianEdgeCombo = 18,

        [OrderedEnum]
        [CustomComboInfo("Hakke Mujinsatsu Combo", "Replace Hakke Mujinsatsu with its combo chain.", NIN.JobID, NIN.HakkeMujinsatsu)]
        NinjaHakkeMujinsatsuCombo = 19,

        // [OrderedEnum]
        // [CustomComboInfo("Kassatsu to Trick", "Replaces Kassatsu with Trick Attack while Suiton or Hidden is up.\nCooldown tracking plugin recommended.", NIN.JobID, NIN.Kassatsu)]
        // NinjaKassatsuTrickFeature = 87,

        // [OrderedEnum]
        // [CustomComboInfo("Ten Chi Jin to Meisui", "Replaces Ten Chi Jin (the move) with Meisui while Suiton is up.\nCooldown tracking plugin recommended.", NIN.JobID, NIN.TenChiJin)]
        // NinjaTCJMeisuiFeature = 88,

        [OrderedEnum]
        [CustomComboInfo("Kassatsu Chi/Jin Feature", "Replaces Chi with Jin while Kassatsu is up if you have Enhanced Kassatsu.", NIN.JobID, NIN.Chi)]
        NinjaKassatsuChiJinFeature = 89,

        // [OrderedEnum]
        // [CustomComboInfo("Hide to Mug", "Replaces Hide with Mug while in combat.", NIN.JobID, NIN.Hide)]
        // NinjaHideMugFeature = 90,

        // [OrderedEnum]
        // [CustomComboInfo("Aeolian to Ninjutsu Feature", "Replaces Aeolian Edge (combo) with Ninjutsu if any Mudra are used.", NIN.JobID, NIN.AeolianEdge)]
        // NinjaNinjutsuFeature = 91,

        [OrderedEnum]
        [CustomComboInfo("GCDs to Ninjutsu Feature", "Every GCD combo becomes Ninjutsu while Mudras are being used.", NIN.JobID, NIN.AeolianEdge, NIN.ArmorCrush, NIN.HakkeMujinsatsu)]
        NinjaGCDNinjutsuFeature = 92,

        [OrderedEnum]
        [CustomComboInfo("Bunshin / Kamaitachi Feature", "Replaces Bunshin with Phantom Kamaitachi after usage.", NIN.JobID, NIN.Bunshin)]
        NinjaBunshinKamaitachiFeature = 107,

        [OrderedEnum]
        [CustomComboInfo("Huraijin / Raiju Feature", "Replaces Huraijin with Forked and Fleeting Raiju when available.", NIN.JobID, NIN.Huraijin)]
        NinjaHuraijinRaijuFeature = 108,

        #endregion
        // ====================================================================================
        #region PALADIN

        [OrderedEnum]
        [CustomComboInfo("Goring Blade Combo", "Replace Goring Blade with its combo chain.", PLD.JobID, PLD.GoringBlade)]
        PaladinGoringBladeCombo = 5,

        [OrderedEnum]
        [CustomComboInfo("Royal Authority Combo", "Replace Royal Authority/Rage of Halone with its combo chain.", PLD.JobID, PLD.RoyalAuthority, PLD.RageOfHalone)]
        PaladinRoyalAuthorityCombo = 6,

        [OrderedEnum]
        [CustomComboInfo("Atonement Feature", "Replace Royal Authority with Atonement when under the effect of Sword Oath.", PLD.JobID, PLD.RoyalAuthority)]
        PaladinAtonementFeature = 59,

        [OrderedEnum]
        [CustomComboInfo("Prominence Combo", "Replace Prominence with its combo chain.", PLD.JobID, PLD.Prominence)]
        PaladinProminenceCombo = 7,

        [OrderedEnum]
        [CustomComboInfo("Requiescat Confiteor", "Replace Requiescat with Confiter while under the effect of Requiescat.", PLD.JobID, PLD.Requiescat)]
        PaladinRequiescatCombo = 55,

        // [OrderedEnum]
        // [CustomComboInfo("Requiescat Feature", "Replace Royal Authority/Goring Blade combo with Holy Spirit and Prominence combo with Holy Circle while Requiescat is active.\nRequires said combos to be activated to work.", PLD.JobID, PLD.RoyalAuthority, PLD.GoringBlade, PLD.Prominence)]
        // PaladinRequiescatFeature = 86,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Confiteor Feature", "Replace Holy Spirit/Circle with Confiteor while MP is under 4000 and Requiescat is up.", PLD.JobID, PLD.HolySpirit, PLD.HolyCircle)]
        PaladinConfiteorFeature = 69,

        #endregion
        // ====================================================================================
        #region REAPER

        [OrderedEnum]
        [CustomComboInfo("Slice Combo", "Replace Slice with its combo chain.", RPR.JobID, RPR.Slice)]
        ReaperSliceCombo = 98,

        [OrderedEnum]
        [CustomComboInfo("Scythe Combo", "Replace Spinning Scythe with its combo chain.", RPR.JobID, RPR.SpinningScythe)]
        ReaperScytheCombo = 99,

        [OrderedEnum]
        [CustomComboInfo("Enshroud Communio Feature", "Replace Enshroud with Communio when Enshrouded.", RPR.JobID, RPR.Enshroud)]
        ReaperEnshroudCommunioFeature = 105,

        [OrderedEnum]
        [CustomComboInfo("Arcane Circle Harvest Feature", "Replace Arcane Circle with Plentiful Harvest when you have stacks of Immortal Sacrifice.", RPR.JobID, RPR.ArcaneCircle)]
        ReaperHarvestFeature = 111,

        #endregion
        // ====================================================================================
        #region RED MAGE

        [OrderedEnum]
        [CustomComboInfo("Red Mage AoE Combo", "Replaces Veraero/Verthunder 2 with Impact when Dualcast or Swiftcast are active.", RDM.JobID, RDM.Veraero2, RDM.Verthunder2)]
        RedMageAoECombo = 48,

        [OrderedEnum]
        [CustomComboInfo("Redoublement combo", "Replaces Redoublement with its combo chain, following enchantment rules.", RDM.JobID, RDM.Redoublement)]
        RedMageMeleeCombo = 49,

        [OrderedEnum]
        [SecretCustomCombo]
        [CustomComboInfo("Redoublement Combo Plus", "Replaces Redoublement with Verflare/Verholy after Enchanted Redoublement, whichever is more appropriate.\nRequires Redoublement Combo.", RDM.JobID, RDM.Redoublement)]
        RedMageMeleeComboPlus = 68,

        [OrderedEnum]
        [CustomComboInfo("Verproc into Jolt", "Replaces Verstone/Verfire with Jolt/Scorch when no proc is available.", RDM.JobID, RDM.Verstone, RDM.Verfire)]
        RedMageVerprocCombo = 53,

        [OrderedEnum]
        [CustomComboInfo("Verproc into Jolt Plus", "Additionally replaces Verstone/Verfire with Veraero/Verthunder if Dualcast, Swiftcast, or Lost Chainspell are up.\nRequires Verproc into Jolt.", RDM.JobID, RDM.Verstone, RDM.Verfire)]
        RedMageVerprocComboPlus = 93,

        [OrderedEnum]
        [CustomComboInfo("Verproc into Jolt Plus Opener Feature (Stone)", "Turns Verstone into Veraero when out of combat.\nRequires Verproc into Jolt Plus.", RDM.JobID, RDM.Verstone)]
        RedMageVerprocOpenerFeatureStone = 101,

        [OrderedEnum]
        [CustomComboInfo("Verproc into Jolt Plus Opener Feature (Fire)", "Turns Verfire into Verthunder when out of combat.\nRequires Verproc into Jolt Plus.", RDM.JobID, RDM.Verfire)]
        RedMageVerprocOpenerFeatureFire = 94,

        #endregion
        // ====================================================================================
        #region SAGE

        #endregion
        // ====================================================================================
        #region SAMURAI

        [OrderedEnum]
        [CustomComboInfo("Yukikaze Combo", "Replace Yukikaze with its combo chain.", SAM.JobID, SAM.Yukikaze)]
        SamuraiYukikazeCombo = 11,

        [OrderedEnum]
        [CustomComboInfo("Gekko Combo", "Replace Gekko with its combo chain.", SAM.JobID, SAM.Gekko)]
        SamuraiGekkoCombo = 12,

        [OrderedEnum]
        [CustomComboInfo("Kasha Combo", "Replace Kasha with its combo chain.", SAM.JobID, SAM.Kasha)]
        SamuraiKashaCombo = 13,

        [OrderedEnum]
        [CustomComboInfo("Mangetsu Combo", "Replace Mangetsu with its combo chain.", SAM.JobID, SAM.Mangetsu)]
        SamuraiMangetsuCombo = 14,

        [OrderedEnum]
        [CustomComboInfo("Oka Combo", "Replace Oka with its combo chain.", SAM.JobID, SAM.Oka)]
        SamuraiOkaCombo = 15,

        [OrderedEnum]
        [CustomComboInfo("Hyosetsu Combo", "Replace Hyosetsu with its combo chain.", SAM.JobID, SAM.Hyosetsu)]
        SamuraiHyosetsuCombo = 100,

        // [OrderedEnum]
        // [CustomComboInfo("Jinpu/Shifu Feature", "Replace Meikyo Shisui with Jinpu or Shifu depending on what is needed.", SAM.JobID, SAM.MeikyoShisui)]
        // SamuraiJinpuShifuFeature = 81,

        [OrderedEnum]
        [ConflictingCombos(SamuraiIaijutsuTsubameGaeshiFeature)]
        [CustomComboInfo("Tsubame-gaeshi to Iaijutsu", "Replace Tsubame-gaeshi with Iaijutsu when Sen is empty.", SAM.JobID, SAM.TsubameGaeshi)]
        SamuraiTsubameGaeshiIaijutsuFeature = 60,

        [OrderedEnum]
        [ConflictingCombos(SamuraiIaijutsuShohaFeature)]
        [CustomComboInfo("Tsubame-gaeshi to Shoha", "Replace Tsubame-gaeshi with Shoha when meditation is 3.", SAM.JobID, SAM.TsubameGaeshi)]
        SamuraiTsubameGaeshiShohaFeature = 61,

        [OrderedEnum]
        [ConflictingCombos(SamuraiTsubameGaeshiIaijutsuFeature)]
        [CustomComboInfo("Iaijutsu to Tsubame-gaeshi", "Replace Iaijutsu with Tsubame-gaeshi when Sen is not empty.", SAM.JobID, SAM.Iaijutsu)]
        SamuraiIaijutsuTsubameGaeshiFeature = 64,

        [OrderedEnum]
        [ConflictingCombos(SamuraiTsubameGaeshiShohaFeature)]
        [CustomComboInfo("Iaijutsu to Shoha", "Replace Iaijutsu with Shoha when meditation is 3.", SAM.JobID, SAM.Iaijutsu)]
        SamuraiIaijutsuShohaFeature = 65,

        [OrderedEnum]
        [CustomComboInfo("Ikishoten Namikiri Feature", "Replace Ikishoten with Ogi Namikiri and then Kaeshi Namikiri when available.", SAM.JobID, SAM.Ikishoten)]
        SamuraiIkishotenNamikiriFeature = 109,

        #endregion
        // ====================================================================================
        #region SCHOLAR

        [OrderedEnum]
        [CustomComboInfo("Seraph Fey Blessing/Consolation", "Change Fey Blessing into Consolation when Seraph is out.", SCH.JobID, SCH.FeyBless)]
        ScholarSeraphConsolationFeature = 29,

        [OrderedEnum]
        [CustomComboInfo("ED Aetherflow", "Change Energy Drain into Aetherflow when you have no more Aetherflow stacks.", SCH.JobID, SCH.EnergyDrain)]
        ScholarEnergyDrainFeature = 37,

        #endregion
        // ====================================================================================
        #region SUMMONER

        [OrderedEnum]
        [CustomComboInfo("ED Fester", "Change Fester into Energy Drain when out of Aetherflow stacks.", SMN.JobID, SMN.Fester)]
        SummonerEDFesterCombo = 39,

        [OrderedEnum]
        [CustomComboInfo("ES Painflare", "Change Painflare into Energy Syphon when out of Aetherflow stacks.", SMN.JobID, SMN.Painflare)]
        SummonerESPainflareCombo = 40,

        #endregion
        // ====================================================================================
        #region WARRIOR

        [OrderedEnum]
        [CustomComboInfo("Storms Path Combo", "Replace Storms Path with its combo chain.", WAR.JobID, WAR.StormsPath)]
        WarriorStormsPathCombo = 8,

        [OrderedEnum]
        [CustomComboInfo("Storms Eye Combo", "Replace Storms Eye with its combo chain.", WAR.JobID, WAR.StormsEye)]
        WarriorStormsEyeCombo = 9,

        [OrderedEnum]
        [CustomComboInfo("Mythril Tempest Combo", "Replace Mythril Tempest with its combo chain.", WAR.JobID, WAR.MythrilTempest)]
        WarriorMythrilTempestCombo = 10,

        // [OrderedEnum]
        // [CustomComboInfo("Warrior Gauge Overcap Feature", "Replace Single-target or AoE combo with gauge spender if you are about to overcap and are before a step of a combo that would generate beast gauge.", WAR.JobID, WAR.MythrilTempest, WAR.StormsEye, WAR.StormsPath)]
        // WarriorGaugeOvercapFeature = 78,

        // [OrderedEnum]
        // [CustomComboInfo("Inner Release Feature", "Replace Single-target and AoE combo with Fell Cleave/Decimate during Inner Release.", WAR.JobID, WAR.MythrilTempest, WAR.StormsPath)]
        // WarriorInnerReleaseFeature = 79,

        [OrderedEnum]
        [CustomComboInfo("Nascent Flash Feature", "Replace Nascent Flash with Raw intuition when level synced below 76.", WAR.JobID, WAR.NascentFlash)]
        WarriorNascentFlashFeature = 67,

        [OrderedEnum]
        [CustomComboInfo("Primal Rend Feature", "Replace Inner Beast and Steel Cyclone with Primal Rend when available", WAR.JobID, WAR.InnerBeast, WAR.SteelCyclone)]
        WarriorPrimalRendFeature = 104,

        #endregion
        // ====================================================================================
        #region WHITE MAGE

        [OrderedEnum]
        [CustomComboInfo("Solace into Misery", "Replaces Afflatus Solace with Afflatus Misery when Misery is ready to be used.", WHM.JobID, WHM.AfflatusSolace)]
        WhiteMageSolaceMiseryFeature = 35,

        [OrderedEnum]
        [CustomComboInfo("Rapture into Misery", "Replaces Afflatus Rapture with Afflatus Misery when Misery is ready to be used.", WHM.JobID, WHM.AfflatusRapture)]
        WhiteMageRaptureMiseryFeature = 36,

        [OrderedEnum]
        [CustomComboInfo("Cure 2 to Cure Level Sync", "Changes Cure 2 to Cure when below level 30 in synced content.", WHM.JobID, WHM.Cure2)]
        WhiteMageCureFeature = 76,

        [OrderedEnum]
        [CustomComboInfo("Afflatus Feature", "Changes Cure 2 into Afflatus Solace, and Medica into Afflatus Rapture, when lilies are up.", WHM.JobID, WHM.Cure2, WHM.Medica)]
        WhiteMageAfflatusFeature = 77,

        #endregion
        // ====================================================================================
    }
}
