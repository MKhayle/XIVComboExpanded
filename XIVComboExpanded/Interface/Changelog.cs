using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVComboExpanded.Interface
{
    public class Changelog
    {
        public static Dictionary<string, string[]> GetChangelog()
        {
            return new Dictionary<string, string[]>()
                {
                    {
                        "v2.0.3.0",
                        [
                            "API 12 update.",
                        ]
                    },
                    {
                        "v2.0.2.3",
                        [
                            "Fixed the theme failing imgui assertion when clicked repeatedly and crashing the game.",
                            "There's never been a 2.0.2.1 nor a 2.0.2.2",
                            "Do not believe Ondore's lies!"
                        ]
                    },
                    {
                        "v2.0.2.0",
                        [
                            "Added a custom opt-out theme setting for better visibility.",
                        ]
                    },
                    {
                        "v2.0.1.4",
                        [
                            "Fixed SGE's Eukrasian Prognosis feature.",
                            "Added PLD's Shield Lob to Holy Spirit feature.",
                            "Sorry New Year!"
                        ]
                    },
                    {
                        "v2.0.1.3",
                        [
                            "Added AST's Gravity-only to Arcana feature.",
                            "Added DNC's Combined Steps secret feature.",
                            "Fixed MNK's Steeled Meditation when below level 54.",
                            "Added SAM's Hissatsu: Guren features by @propagandist1.",
                            "Added SGE's Eukrasian Dosis/Diagnosis/Prognosis/Dyskria features.",
                            "Added SMN's Primal Favor Feature by @kaedys.",
                            "Re-added SAM's Oka Combo as a separate option.",
                            "Revised DRG's Stardiver to Nastrond and Dragonfire Dive by @kaedys.",
                            "Happy New Year!"
                        ]
                    },
                    {
                        "v2.0.1.2",
                        [
                            "Added NIN's Bhavacakra to Hellfrog Level Sync feature.",
                            "Added PCT's  Holy Hammer combo feature by @Propagandist1.",
                            "Added PCT's Starry Muse/Star Prism Combo by @kaedys.",
                            "Added SAM's AoE Features by @kaedys",
                            "Fixed level checks for BLM, MNK, SAM and RPR by @kaedys.",
                            "Fixed NIN's Forked Raiju features.",
                            "Removed PCT's deprecated (and now useless) Landscape Muse/Star Prism Combo.",
                            "Reworked VPR's Vice combo oGCD by @kaedys.",
                            "Updated BLM things and stuff for Enochian Timer Feature by @lhn1703."
                        ]
                    },
                    {
                        "v2.0.1.1",
                        [
                            "Added BLM's Enochian Umbral Ice Feature by @lhn1703.",
                            "Added BRD's Automatic Iron Jaws Apex Feature by @kaedys",
                            "Added BRD's Battle Finale Feature by @kaedys.",
                            "Added BRD's Radiant Strikes feature by @kaedys.",
                            "Added DNC's Tillana Overcap Prevention Feature by @kaedys.",
                            "Added DRK's Souleater Overcap Optimized Feature by @lhn1703.",
                            "Added DRK's Stalwart Soul Overcap Optimized Feature by @lhn1703.",
                            "Added DRK's Disesteem Feature & Disesteem Souleater Feature by @lhn1703.",
                            "Added GNB's Brutal Shell Combo for sustaining purposes.",
                            "Added NIN's various Aeolian Edge|Armor Crush / Fleeting Raiju|Forked Raiju Features by @kaedys.",
                            "Added RPR's Soul Scythe Guillotine Feature by @kaedys.",
                            "Added VPR's Serpent's Fang Feature & Include all oGCDs Option by @kaedys.",
                            "Fixed BLM's Enochian Timer feature where it could try to cast Despair even if you lack the MP by @kaedys.",
                            "Fixed DNC's Automatic Saber Dance features for AoE that were using the single target feature instead by @kaedys.",
                            "Fixed NIN's Kazematoi feature conflicting with (or requiring) the Aeolian Edge combo feature by @kaedys.",
                            "Fixed VPR's combos when the player has neither Honed buff so that the combo buttons are left alone, rather than \nboth being replaced with Steel Fangs/Maw by @kaedys.",
                            "Removed BLM's Enochian active conditional for replacing Transpose and Umbral Soul by @kaedys.",
                            "Removed DNC's Devilment into Starfall Combo as 7.1 made this native.",
                            "Removed MNK's conflicts for Coeurl Feature and Raptor Feature with Monke Mode by @kaedys.",
                            "Reworked SAM's Shoha features to prioritize it over Zanshin if both are available when replacing Shinten by @kaedys.",
                            "Reworked SGE's Sectioning by @kaedys.",
                            "Reworked DRG's Geirskogul to Wyrmwind Thrust feature to prioritize it over Nastrond, since the latter has effectively no cooldown during LotD.\n The priority for usage is now Geirskogal > Wyrmwind > Nastrond.",
                            "Added PCT checks to determine whether oGCDs can be used or not to prevent No Abilities in Deep Dungeons to lock you in unusable skills.",
                            "Added level check for NIN's Trick Attack in the Kassatsu Trick feature by @kaedys.",
                            "Added level check for RPR's Automatic Soul Slice/Scythe features by @kaedys.",
                            "Added level checks for VPR's PvP Main & AoE Style Combos.",
                        ]
                    },
                    {
                        "v2.0.1.0",
                        [
                            "API 11 update. Things are still partially broken, please do not post issues on GitHub for now."
                        ]
                    },
                    {
                        "v2.0.0.12",
                        [
                            "Fixed ADV's Swift Raise Feature. Sorry about that!",
                            "Added GNB's Empty Blood Reign Feature by @aldros-ffxi."
                        ]
                    },
                    {
                        "v2.0.0.11",
                        [
                            "Reworked the drawing engine to use ImRaii instead of ImGUI for better performances and prevent font/colors leaking issues.",
                            "Changed the Combo tabs order so that they go from the most available options to the least ones.",
                            "Added the English name of skills when icons are hovered if you're not using an English client.",
                            "Added the level at which a skill is learnt after the skill's name.",
                            "Added additional checks for the auto-selection settings to prevent background issues.",
                            "Fixed ADV's Silent Peloton checking if you were in combat instead of out of combat.",
                            "Fixed VPR's Serpent's Ire on Reawaken replacing every button.",
                            "Added VPR level check for Auto Steel Reaving's Reaving Maw.",
                            "Added VPR checks to determine whether oGCDs can be used or not to prevent No Abilities in Deep Dungeons to lock you in unusable skills."
                        ]
                    },
                    {
                        "v2.0.0.10",
                        [
                            "Fixed an issue with classes not being properly recognized as jobs and being auto-selected by the auto-selection setting.\nGrab your job stones!",
                            "Updated the order in which actions are used outside Fight or Flight when using the Paladin FoF Optimize feature. \nSee issue #418 for reasoning by @kaedys.",
                            "Fixed PLD's One-Stop Stun Button locking Shield Bash into an unusable Low Blow when abilities are disabled (like in Deep Dungeons)\nFurther checks will be added for Deep Dungeons compatibility.",
                            "Rewrote RPR features and logic, combining many prior ones and updating interactions by @kaedys.",
                            "Implemented RPR automatic Soul Slice feature by @kaedys.",
                            "Removed Sacrificium Priority and Soulsow on Shadow of Death features by @kaedys.",
                            "Added VPR's Auto Fang/Bite feature by @kaedys.",
                            "Added VPR's Serpent's Ire on Reawaken by @aldros-ffxi.",
                            "Added VPR's Uncoiled Fury to Writhing Snap by @aldros-ffxi.",
                            "Restored VPR's PvP Style Main Combo by @aldros-ffxi.",
                            "Restored VPR's PvP Combo Start Flanksbane Fang by @aldros-ffxi.",
                            "Restored VPR's PvP Combo Start Flanksting Strike by @aldros-ffxi.",
                            "Restored VPR's PvP Combo Start Hindsbane Fang by @aldros-ffxi.",
                            "Restored VPR's PvP AoE Combo Start Bloodied Maw by @aldros-ffxi.",
                            "Added GNB's Burst Strike into Gnashing Fang feature by @aldros-ffxi.",
                            "Added GNB's Burst Strike into Danger Zone feature by @aldros-ffxi.",
                        ]
                    },
                    {
                        "v2.0.0.9",
                        [
                            "Fixed SGE's Dosis Psyche Feature being a child combo of the Auto Eukrasian Dosis feature.",
                            "Fixed SGE's Toxikon into Psyche being a child combo of the Toxikon into Phlegma.",
                            "Split GNB's Double Down Feature into Double Down Burst Feature & Double Down Fated Feature.",
                            "Added NIN's Kazematoi Overcap Feature.",
                        ]
                    },
                    {
                        "v2.0.0.8",
                        [
                            "Added DNC's Single Target Feather Overcap Feature.",
                            "Added DNC's Auto-Fan Dance 3.",
                            "Added DNC's AoE Feather Overcap Feature.",
                            "Added DNC's AoE Auto-Fan Dance 3.",
                            "Added SGE's Phlegma into Psyche.",
                            "Added GNB's Expanded Continuation Disable X Features.",
                            "Added the currently installed version in the titlebar.",
                        ]
                    },
                    {
                        "v2.0.0.7",
                        [
                            "MCH's Gauss Round / Double Check & Ricochet / Checkmate Feature fix if Checkmate/Double Check\nwere assigned in the hotbar instead of Ricochet/Gauss Round.",
                        ]
                    },
                    {
                        "v2.0.0.6",
                        [
                            "RPR's Perfect Harvest Feature fix by @kaedys.",
                            "VPR's Generation Legacy Feature fix by @kaedys.",
                            "Added SAM's Iaijutsu to Tsubame-gaeshi Single Sen by @mikel-gh."
                        ]
                    },
                    {
                        "v2.0.0.5",
                        [
                            "Fixed a white background which was leaking when an invalid job was automatically picked with the auto-pick setting.",
                            "BRD's Bloodletter Features fix when Heartbreak Shot was unlocked by @aldros-ffxi."
                        ]
                    },
                    {
                        "v2.0.0.4",
                        [
                            "Reworded the Accessiiblity Combos description.",
                            "Fixed SGE's Dyskrasia Psyche Feature's logic.",
                        ]
                    },
                    {
                        "v2.0.0.3",
                        [
                            "WAR's Storm's Path Combo logic fix (electric boogaloo) by @kaedys.",
                            "PLD's Divine Might Feature logic fix (also electric boogaloo) by @kaedys.",
                            "Added WHM's Glare 4 AoE Feature.",
                            "Added SGE's Dyskrasia Psyche Feature.",
                        ]
                    },
                    {
                        "v2.0.0.2",
                        [
                            "NIN's Auto-Refill Kazematoi additional logic fix.",
                            "WAR's Storm's Path Combo logic fix.",
                            "PLD's Divine Might Feature fix."
                        ]
                    },
                    {
                        "v2.0.0.1", ["NIN's Auto-Refill Kazematoi fix."]
                    },
                    {
                        "v2.0.0.0",
                        ["Initial re-release!",
                        "Every job is Dawntrail updated at least up to the level 90.",
                        "Please request reasonable new Features on GitHub (link in the About tab) if you'd like to see new combos.",
                        "A one-time pop-up allows for an easier first installation. It can be re-enabled in the Settings tab.",
                        "Please note that some jobs do not have any combos available at all if you don't enable Expanded combos.",]
                    },
                };
        }
    }
}
