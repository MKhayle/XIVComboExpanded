using System;
using System.Runtime.CompilerServices;

using XIVComboExpandedPlugin.Combos;

namespace XIVComboExpandedPlugin.Attributes;

/// <summary>
/// Attribute documenting additional information for each combo.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
internal class CustomComboInfoAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomComboInfoAttribute"/> class.
    /// </summary>
    /// <param name="fancyName">Display name.</param>
    /// <param name="description">Combo description.</param>
    /// <param name="jobID">Associated job ID.</param>
    /// <param name="order">Display order.</param>
    internal CustomComboInfoAttribute(string fancyName, string description, byte jobID, [CallerLineNumber] int order = 0)
    {
        this.FancyName = fancyName;
        this.Description = description;
        this.JobID = jobID;
        this.Order = order;
    }

    /// <summary>
    /// Gets the display name.
    /// </summary>
    public string FancyName { get; }

    /// <summary>
    /// Gets the description.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the job ID.
    /// </summary>
    public byte JobID { get; }

    /// <summary>
    /// Gets the display order.
    /// </summary>
    public int Order { get; }

    /// <summary>
    /// Gets the job name.
    /// </summary>
    public string JobName => JobIDToName(this.JobID);

    /// <summary>
    /// Gets the role name.
    /// </summary>
    public string RoleName => JobIDToRole(this.JobID);

    /// <summary>
    /// Gets the job name from a job ID.
    /// </summary>
    /// <returns>The job name.</returns>
    public static string JobIDToName(byte key)
    {
        return key switch
        {
            0 => "Adventurer",
            1 => "Paladin",
            2 => "Monk",
            3 => "Warrior",
            4 => "Dragoon",
            5 => "Bard",
            6 => "White Mage",
            7 => "Black Mage",
            8 => "Disciples of the Hand",
            9 => "Disciples of the Hand",
            10 => "Disciples of the Hand",
            11 => "Disciples of the Hand",
            12 => "Disciples of the Hand",
            13 => "Disciples of the Hand",
            14 => "Disciples of the Hand",
            15 => "Disciples of the Hand",
            16 => "Disciples of the Land",
            17 => "Disciples of the Land",
            18 => "Disciples of the Land",
            19 => "Paladin",
            20 => "Monk",
            21 => "Warrior",
            22 => "Dragoon",
            23 => "Bard",
            24 => "White Mage",
            25 => "Black Mage",
            26 => "Summoner", // Arcanist
            27 => "Summoner",
            28 => "Scholar",
            29 => "Ninja",
            30 => "Ninja",
            31 => "Machinist",
            32 => "Dark Knight",
            33 => "Astrologian",
            34 => "Samurai",
            35 => "Red Mage",
            36 => "Blue Mage",
            37 => "Gunbreaker",
            38 => "Dancer",
            39 => "Reaper",
            40 => "Sage",
            41 => "Viper",
            42 => "Pictomancer",
            43 => "Beastmaster",
            DOH.JobID => "Disciples of the Hand",
            DOL.JobID => "Disciples of the Land",
            _ => "Adventurer",
        };
    }

    public static byte NameToJobID(string key)
    {
        return key switch
        {
            "Adventurer" => 0,
            "Gladiator" => 1,
            "Pugilist" => 2,
            "Marauder" => 3,
            "Lancer" => 4,
            "Archer" => 5,
            "Conjurer" => 6,
            "Thaumaturge" => 7,
            "Carpenter" => 8,
            "Blacksmith" => 9,
            "Armorer" => 10,
            "Goldsmith" => 11,
            "Leatherworker" => 12,
            "Weaver" => 13,
            "Alchemist" => 14,
            "Culinarian" => 15,
            "Miner" => 16,
            "Botanist" => 17,
            "Fisher" => 18,
            "Paladin" => 19,
            "Monk" => 20,
            "Warrior" => 21,
            "Dragoon" => 22,
            "Bard" => 23,
            "White Mage" => 24,
            "Black Mage" => 25,
            "Arcanist" => 26,
            "Summoner" => 27,
            "Scholar" => 28,
            "Rogue" => 29,
            "Ninja" => 30,
            "Machinist" => 31,
            "Dark Knight" => 32,
            "Astrologian" => 33,
            "Samurai" => 34,
            "Red Mage" => 35,
            "Blue Mage" => 36,
            "Gunbreaker" => 37,
            "Dancer" => 38,
            "Reaper" => 39,
            "Sage" => 40,
            "Viper" => 41,
            "Pictomancer" => 42,
            "Beastmaster" => 43,
            "Disciples of the Hand" => DOH.JobID,
            "Disciples of the Land" => DOL.JobID,
            _ => 0,
        };
    }

    public static string JobIDToRole(byte key)
    {
        return key switch
        {
            0 => "Adventurer",
            1 => "Tank",
            2 => "Melee",
            3 => "Tank",
            4 => "Melee",
            5 => "Ranged",
            6 => "Healer",
            7 => "Caster",
            8 => "Carpenter",
            9 => "DOH",
            10 => "DOH",
            11 => "DOH",
            12 => "DOH",
            13 => "DOH",
            14 => "DOH",
            15 => "DOH",
            16 => "DOL",
            17 => "DOL",
            18 => "DOL",
            19 => "Tank",
            20 => "Melee",
            21 => "Tank",
            22 => "Melee",
            23 => "Ranged",
            24 => "Healer",
            25 => "Caster",
            26 => "Caster",
            27 => "Caster",
            28 => "Healer",
            29 => "Melee",
            30 => "Melee",
            31 => "Ranged",
            32 => "Tank",
            33 => "Healer",
            34 => "Melee",
            35 => "Caster",
            36 => "Caster",
            37 => "Tank",
            38 => "Ranged",
            39 => "Melee",
            40 => "Healer",
            41 => "Melee",
            42 => "Caster",
            43 => "Melee",
            DOH.JobID => "Others",
            DOL.JobID => "Others",
            _ => "Others",
        };
    }

    public static byte RoleIDToOrder(string key)
    {
        return key switch
        {
            "Adventurer" => 0,
            "Tank" => 1,
            "Healer" => 2,
            "Melee" => 3,
            "Ranged" => 4,
            "Caster" => 5,
            "Others" => 6,
            _ => 0,
        };
    }
}
