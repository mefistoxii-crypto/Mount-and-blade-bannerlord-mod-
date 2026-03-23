using System;
using System.Collections.Generic;
using TaleWorlds.Core;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.MountAndBlade;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using HarmonyLib;

namespace TacticalOverhaul
{
    /// <summary>
    /// Custom data dla mercenary units (wages, upkeep, morale, tier)
    /// Bannerlord XML nie wspiera tych atrybutów, więc zarządzamy w C#
    /// </summary>
    public class MercenaryData
    {
        public string UnitId { get; set; }
        public string Name { get; set; }
        public int Tier { get; set; }
        public int Wages { get; set; }
        public int Upkeep { get; set; }
        public int BaseHealth { get; set; }
        public int BaseMorale { get; set; }
        public string Culture { get; set; }
        public MercenaryType Type { get; set; }
    }

    public enum MercenaryType
    {
        LightInfantry,
        HeavyInfantry,
        Archer,
        Crossbowman,
        LightCavalry,
        HeavyCavalry,
        HorseArcher,
        Special
    }

    /// <summary>
    /// Database wszystkich mercenary units z custom data
    /// </summary>
    public static class MercenaryDatabase
    {
        private static Dictionary<string, MercenaryData> _mercenaries;

        static MercenaryDatabase()
        {
            InitializeMercenaries();
        }

        private static void InitializeMercenaries()
        {
            _mercenaries = new Dictionary<string, MercenaryData>
            {
                // LIGHT INFANTRY (Tier 1)
                ["merc_light_infantry_01"] = new MercenaryData { UnitId = "merc_light_infantry_01", Name = "Forest Footman", Tier = 1, Wages = 10, Upkeep = 5, BaseHealth = 40, BaseMorale = 80, Culture = "battania", Type = MercenaryType.LightInfantry },
                ["merc_light_infantry_02"] = new MercenaryData { UnitId = "merc_light_infantry_02", Name = "Desert Raider", Tier = 1, Wages = 12, Upkeep = 6, BaseHealth = 38, BaseMorale = 75, Culture = "aserai", Type = MercenaryType.LightInfantry },
                ["merc_light_infantry_03"] = new MercenaryData { UnitId = "merc_light_infantry_03", Name = "Northern Skirmisher", Tier = 1, Wages = 11, Upkeep = 5, BaseHealth = 42, BaseMorale = 78, Culture = "sturgia", Type = MercenaryType.LightInfantry },
                ["merc_light_infantry_04"] = new MercenaryData { UnitId = "merc_light_infantry_04", Name = "Southern Levy", Tier = 1, Wages = 10, Upkeep = 5, BaseHealth = 45, BaseMorale = 70, Culture = "empire", Type = MercenaryType.LightInfantry },
                ["merc_light_infantry_05"] = new MercenaryData { UnitId = "merc_light_infantry_05", Name = "Steppe Rider", Tier = 1, Wages = 15, Upkeep = 7, BaseHealth = 40, BaseMorale = 85, Culture = "khuzait", Type = MercenaryType.LightInfantry },
                ["merc_light_infantry_06"] = new MercenaryData { UnitId = "merc_light_infantry_06", Name = "Highland Scout", Tier = 1, Wages = 14, Upkeep = 6, BaseHealth = 38, BaseMorale = 80, Culture = "battania", Type = MercenaryType.LightInfantry },
                ["merc_light_infantry_07"] = new MercenaryData { UnitId = "merc_light_infantry_07", Name = "Feudal Serf", Tier = 1, Wages = 9, Upkeep = 4, BaseHealth = 35, BaseMorale = 65, Culture = "vlandia", Type = MercenaryType.LightInfantry },
                ["merc_light_infantry_08"] = new MercenaryData { UnitId = "merc_light_infantry_08", Name = "Tribal Warrior", Tier = 1, Wages = 11, Upkeep = 5, BaseHealth = 40, BaseMorale = 75, Culture = "battania", Type = MercenaryType.LightInfantry },
                ["merc_light_infantry_09"] = new MercenaryData { UnitId = "merc_light_infantry_09", Name = "Nomadic Scout", Tier = 1, Wages = 13, Upkeep = 6, BaseHealth = 37, BaseMorale = 80, Culture = "khuzait", Type = MercenaryType.LightInfantry },
                ["merc_light_infantry_10"] = new MercenaryData { UnitId = "merc_light_infantry_10", Name = "Tundra Raider", Tier = 1, Wages = 12, Upkeep = 6, BaseHealth = 43, BaseMorale = 77, Culture = "sturgia", Type = MercenaryType.LightInfantry },

                // HEAVY INFANTRY (Tier 2)
                ["merc_heavy_infantry_01"] = new MercenaryData { UnitId = "merc_heavy_infantry_01", Name = "Legion Veteran", Tier = 2, Wages = 20, Upkeep = 10, BaseHealth = 55, BaseMorale = 85, Culture = "empire", Type = MercenaryType.HeavyInfantry },
                ["merc_heavy_infantry_02"] = new MercenaryData { UnitId = "merc_heavy_infantry_02", Name = "Feudal Knight", Tier = 2, Wages = 22, Upkeep = 11, BaseHealth = 58, BaseMorale = 88, Culture = "vlandia", Type = MercenaryType.HeavyInfantry },
                ["merc_heavy_infantry_03"] = new MercenaryData { UnitId = "merc_heavy_infantry_03", Name = "Forest Defender", Tier = 2, Wages = 19, Upkeep = 9, BaseHealth = 52, BaseMorale = 83, Culture = "battania", Type = MercenaryType.HeavyInfantry },
                ["merc_heavy_infantry_04"] = new MercenaryData { UnitId = "merc_heavy_infantry_04", Name = "Druzhina Guard", Tier = 2, Wages = 21, Upkeep = 10, BaseHealth = 60, BaseMorale = 86, Culture = "sturgia", Type = MercenaryType.HeavyInfantry },
                ["merc_heavy_infantry_05"] = new MercenaryData { UnitId = "merc_heavy_infantry_05", Name = "Desert Warden", Tier = 2, Wages = 20, Upkeep = 10, BaseHealth = 50, BaseMorale = 82, Culture = "aserai", Type = MercenaryType.HeavyInfantry },
                ["merc_heavy_infantry_06"] = new MercenaryData { UnitId = "merc_heavy_infantry_06", Name = "Steppe Champion", Tier = 2, Wages = 23, Upkeep = 11, BaseHealth = 48, BaseMorale = 87, Culture = "khuzait", Type = MercenaryType.HeavyInfantry },
                ["merc_heavy_infantry_07"] = new MercenaryData { UnitId = "merc_heavy_infantry_07", Name = "Iron Guard", Tier = 2, Wages = 24, Upkeep = 12, BaseHealth = 62, BaseMorale = 90, Culture = "vlandia", Type = MercenaryType.HeavyInfantry },
                ["merc_heavy_infantry_08"] = new MercenaryData { UnitId = "merc_heavy_infantry_08", Name = "Tribal Defender", Tier = 2, Wages = 18, Upkeep = 9, BaseHealth = 54, BaseMorale = 81, Culture = "battania", Type = MercenaryType.HeavyInfantry },
                ["merc_heavy_infantry_09"] = new MercenaryData { UnitId = "merc_heavy_infantry_09", Name = "Imperial Elite", Tier = 2, Wages = 21, Upkeep = 10, BaseHealth = 56, BaseMorale = 85, Culture = "empire", Type = MercenaryType.HeavyInfantry },
                ["merc_heavy_infantry_10"] = new MercenaryData { UnitId = "merc_heavy_infantry_10", Name = "Northern Huscarl", Tier = 2, Wages = 22, Upkeep = 11, BaseHealth = 61, BaseMorale = 87, Culture = "sturgia", Type = MercenaryType.HeavyInfantry },

                // ARCHERS (Tier 2)
                ["merc_archer_01"] = new MercenaryData { UnitId = "merc_archer_01", Name = "Forest Marksman", Tier = 2, Wages = 18, Upkeep = 9, BaseHealth = 42, BaseMorale = 78, Culture = "battania", Type = MercenaryType.Archer },
                ["merc_archer_02"] = new MercenaryData { UnitId = "merc_archer_02", Name = "Desert Bowman", Tier = 2, Wages = 17, Upkeep = 8, BaseHealth = 40, BaseMorale = 75, Culture = "aserai", Type = MercenaryType.Archer },
                ["merc_archer_03"] = new MercenaryData { UnitId = "merc_archer_03", Name = "Steppe Archer", Tier = 2, Wages = 19, Upkeep = 9, BaseHealth = 38, BaseMorale = 80, Culture = "khuzait", Type = MercenaryType.Archer },
                ["merc_archer_04"] = new MercenaryData { UnitId = "merc_archer_04", Name = "Imperial Bowman", Tier = 2, Wages = 16, Upkeep = 8, BaseHealth = 43, BaseMorale = 74, Culture = "empire", Type = MercenaryType.Archer },
                ["merc_archer_05"] = new MercenaryData { UnitId = "merc_archer_05", Name = "Northern Huntsman", Tier = 2, Wages = 17, Upkeep = 8, BaseHealth = 44, BaseMorale = 76, Culture = "sturgia", Type = MercenaryType.Archer },
                ["merc_archer_06"] = new MercenaryData { UnitId = "merc_archer_06", Name = "Feudal Longbow", Tier = 2, Wages = 18, Upkeep = 9, BaseHealth = 41, BaseMorale = 77, Culture = "vlandia", Type = MercenaryType.Archer },
                ["merc_archer_07"] = new MercenaryData { UnitId = "merc_archer_07", Name = "Highland Bowman", Tier = 2, Wages = 19, Upkeep = 9, BaseHealth = 39, BaseMorale = 79, Culture = "battania", Type = MercenaryType.Archer },
                ["merc_archer_08"] = new MercenaryData { UnitId = "merc_archer_08", Name = "Nomadic Marksman", Tier = 2, Wages = 20, Upkeep = 10, BaseHealth = 37, BaseMorale = 81, Culture = "khuzait", Type = MercenaryType.Archer },
                ["merc_archer_09"] = new MercenaryData { UnitId = "merc_archer_09", Name = "Legion Archer", Tier = 2, Wages = 17, Upkeep = 8, BaseHealth = 42, BaseMorale = 75, Culture = "empire", Type = MercenaryType.Archer },
                ["merc_archer_10"] = new MercenaryData { UnitId = "merc_archer_10", Name = "Tundra Hunter", Tier = 2, Wages = 18, Upkeep = 9, BaseHealth = 45, BaseMorale = 77, Culture = "sturgia", Type = MercenaryType.Archer },

                // CROSSBOWMEN (Tier 2)
                ["merc_crossbow_01"] = new MercenaryData { UnitId = "merc_crossbow_01", Name = "Imperial Crossbow", Tier = 2, Wages = 19, Upkeep = 9, BaseHealth = 44, BaseMorale = 76, Culture = "empire", Type = MercenaryType.Crossbowman },
                ["merc_crossbow_02"] = new MercenaryData { UnitId = "merc_crossbow_02", Name = "Feudal Crossbow", Tier = 2, Wages = 20, Upkeep = 10, BaseHealth = 45, BaseMorale = 78, Culture = "vlandia", Type = MercenaryType.Crossbowman },
                ["merc_crossbow_03"] = new MercenaryData { UnitId = "merc_crossbow_03", Name = "Northern Crossbow", Tier = 2, Wages = 19, Upkeep = 9, BaseHealth = 46, BaseMorale = 77, Culture = "sturgia", Type = MercenaryType.Crossbowman },
                ["merc_crossbow_04"] = new MercenaryData { UnitId = "merc_crossbow_04", Name = "Desert Sniper", Tier = 2, Wages = 18, Upkeep = 9, BaseHealth = 42, BaseMorale = 75, Culture = "aserai", Type = MercenaryType.Crossbowman },
                ["merc_crossbow_05"] = new MercenaryData { UnitId = "merc_crossbow_05", Name = "Legion Sniper", Tier = 2, Wages = 20, Upkeep = 10, BaseHealth = 43, BaseMorale = 77, Culture = "empire", Type = MercenaryType.Crossbowman },

                // LIGHT CAVALRY (Tier 3)
                ["merc_light_cavalry_01"] = new MercenaryData { UnitId = "merc_light_cavalry_01", Name = "Desert Raider", Tier = 3, Wages = 30, Upkeep = 15, BaseHealth = 50, BaseMorale = 85, Culture = "aserai", Type = MercenaryType.LightCavalry },
                ["merc_light_cavalry_02"] = new MercenaryData { UnitId = "merc_light_cavalry_02", Name = "Steppe Lancer", Tier = 3, Wages = 32, Upkeep = 16, BaseHealth = 48, BaseMorale = 87, Culture = "khuzait", Type = MercenaryType.LightCavalry },
                ["merc_light_cavalry_03"] = new MercenaryData { UnitId = "merc_light_cavalry_03", Name = "Forest Rider", Tier = 3, Wages = 29, Upkeep = 14, BaseHealth = 52, BaseMorale = 83, Culture = "battania", Type = MercenaryType.LightCavalry },
                ["merc_light_cavalry_04"] = new MercenaryData { UnitId = "merc_light_cavalry_04", Name = "Northern Scout", Tier = 3, Wages = 31, Upkeep = 15, BaseHealth = 54, BaseMorale = 84, Culture = "sturgia", Type = MercenaryType.LightCavalry },
                ["merc_light_cavalry_05"] = new MercenaryData { UnitId = "merc_light_cavalry_05", Name = "Imperial Cavalry", Tier = 3, Wages = 30, Upkeep = 15, BaseHealth = 51, BaseMorale = 85, Culture = "empire", Type = MercenaryType.LightCavalry },

                // HEAVY CAVALRY (Tier 3)
                ["merc_heavy_cavalry_01"] = new MercenaryData { UnitId = "merc_heavy_cavalry_01", Name = "Legion Cataphract", Tier = 3, Wages = 38, Upkeep = 19, BaseHealth = 60, BaseMorale = 90, Culture = "empire", Type = MercenaryType.HeavyCavalry },
                ["merc_heavy_cavalry_02"] = new MercenaryData { UnitId = "merc_heavy_cavalry_02", Name = "Feudal Knight", Tier = 3, Wages = 40, Upkeep = 20, BaseHealth = 62, BaseMorale = 92, Culture = "vlandia", Type = MercenaryType.HeavyCavalry },
                ["merc_heavy_cavalry_03"] = new MercenaryData { UnitId = "merc_heavy_cavalry_03", Name = "Steppe Lancer", Tier = 3, Wages = 36, Upkeep = 18, BaseHealth = 55, BaseMorale = 88, Culture = "khuzait", Type = MercenaryType.HeavyCavalry },
                ["merc_heavy_cavalry_04"] = new MercenaryData { UnitId = "merc_heavy_cavalry_04", Name = "Northern Cavalry", Tier = 3, Wages = 37, Upkeep = 18, BaseHealth = 58, BaseMorale = 89, Culture = "sturgia", Type = MercenaryType.HeavyCavalry },
                ["merc_heavy_cavalry_05"] = new MercenaryData { UnitId = "merc_heavy_cavalry_05", Name = "Desert Lancer", Tier = 3, Wages = 35, Upkeep = 17, BaseHealth = 54, BaseMorale = 86, Culture = "aserai", Type = MercenaryType.HeavyCavalry },

                // HORSE ARCHERS (Tier 3)
                ["merc_horse_archer_01"] = new MercenaryData { UnitId = "merc_horse_archer_01", Name = "Steppe Archer", Tier = 3, Wages = 34, Upkeep = 17, BaseHealth = 46, BaseMorale = 84, Culture = "khuzait", Type = MercenaryType.HorseArcher },
                ["merc_horse_archer_02"] = new MercenaryData { UnitId = "merc_horse_archer_02", Name = "Desert Skirmisher", Tier = 3, Wages = 32, Upkeep = 16, BaseHealth = 44, BaseMorale = 82, Culture = "aserai", Type = MercenaryType.HorseArcher },
                ["merc_horse_archer_03"] = new MercenaryData { UnitId = "merc_horse_archer_03", Name = "Northern Rider", Tier = 3, Wages = 33, Upkeep = 16, BaseHealth = 47, BaseMorale = 83, Culture = "sturgia", Type = MercenaryType.HorseArcher },
                ["merc_horse_archer_04"] = new MercenaryData { UnitId = "merc_horse_archer_04", Name = "Imperial Scout", Tier = 3, Wages = 31, Upkeep = 15, BaseHealth = 45, BaseMorale = 81, Culture = "empire", Type = MercenaryType.HorseArcher },
                ["merc_horse_archer_05"] = new MercenaryData { UnitId = "merc_horse_archer_05", Name = "Forest Hunter", Tier = 3, Wages = 32, Upkeep = 16, BaseHealth = 43, BaseMorale = 82, Culture = "battania", Type = MercenaryType.HorseArcher },

                // SPECIAL ELITE UNITS (Tier 4)
                ["merc_special_01"] = new MercenaryData { UnitId = "merc_special_01", Name = "Imperial Praetorian", Tier = 4, Wages = 70, Upkeep = 35, BaseHealth = 80, BaseMorale = 99, Culture = "empire", Type = MercenaryType.Special },
                ["merc_special_02"] = new MercenaryData { UnitId = "merc_special_02", Name = "Feudal Champion", Tier = 4, Wages = 68, Upkeep = 34, BaseHealth = 77, BaseMorale = 98, Culture = "vlandia", Type = MercenaryType.Special },
                ["merc_special_03"] = new MercenaryData { UnitId = "merc_special_03", Name = "Steppe Khan", Tier = 4, Wages = 72, Upkeep = 36, BaseHealth = 73, BaseMorale = 99, Culture = "khuzait", Type = MercenaryType.Special },
                ["merc_special_04"] = new MercenaryData { UnitId = "merc_special_04", Name = "Forest Warlord", Tier = 4, Wages = 66, Upkeep = 33, BaseHealth = 75, BaseMorale = 97, Culture = "battania", Type = MercenaryType.Special },
                ["merc_special_05"] = new MercenaryData { UnitId = "merc_special_05", Name = "Iron Knight", Tier = 4, Wages = 65, Upkeep = 32, BaseHealth = 75, BaseMorale = 98, Culture = "vlandia", Type = MercenaryType.Special },
                ["merc_special_06"] = new MercenaryData { UnitId = "merc_special_06", Name = "Northern Reaver", Tier = 4, Wages = 62, Upkeep = 31, BaseHealth = 72, BaseMorale = 97, Culture = "battania", Type = MercenaryType.Special },
                ["merc_special_07"] = new MercenaryData { UnitId = "merc_special_07", Name = "Desert Nomad", Tier = 4, Wages = 60, Upkeep = 30, BaseHealth = 70, BaseMorale = 96, Culture = "aserai", Type = MercenaryType.Special },
                ["merc_special_08"] = new MercenaryData { UnitId = "merc_special_08", Name = "Southern Conqueror", Tier = 4, Wages = 64, Upkeep = 32, BaseHealth = 74, BaseMorale = 97, Culture = "empire", Type = MercenaryType.Special },
                ["merc_special_09"] = new MercenaryData { UnitId = "merc_special_09", Name = "Eastern Warlord", Tier = 4, Wages = 66, Upkeep = 33, BaseHealth = 76, BaseMorale = 99, Culture = "khuzait", Type = MercenaryType.Special },
                ["merc_special_10"] = new MercenaryData { UnitId = "merc_special_10", Name = "Northern Champion", Tier = 4, Wages = 68, Upkeep = 34, BaseHealth = 78, BaseMorale = 99, Culture = "sturgia", Type = MercenaryType.Special },
                // NORD/VIKING MERCENARIES (5)
                ["merc_nord_berserker"] = new MercenaryData { UnitId = "merc_nord_berserker", Name = "Nord Berserker", Tier = 3, Wages = 45, Upkeep = 22, BaseHealth = 65, BaseMorale = 95, Culture = "nord", Type = MercenaryType.Special },
                ["merc_nord_huscarl"] = new MercenaryData { UnitId = "merc_nord_huscarl", Name = "Nord Huscarl", Tier = 3, Wages = 42, Upkeep = 21, BaseHealth = 70, BaseMorale = 93, Culture = "nord", Type = MercenaryType.HeavyInfantry },
                ["merc_nord_archer"] = new MercenaryData { UnitId = "merc_nord_archer", Name = "Nord Archer", Tier = 2, Wages = 24, Upkeep = 12, BaseHealth = 50, BaseMorale = 85, Culture = "nord", Type = MercenaryType.Archer },
                ["merc_nord_raider"] = new MercenaryData { UnitId = "merc_nord_raider", Name = "Nord Raider", Tier = 2, Wages = 22, Upkeep = 11, BaseHealth = 48, BaseMorale = 88, Culture = "nord", Type = MercenaryType.LightInfantry },
                ["merc_nord_ulfhednar"] = new MercenaryData { UnitId = "merc_nord_ulfhednar", Name = "Ulfhednar Elite", Tier = 4, Wages = 70, Upkeep = 35, BaseHealth = 80, BaseMorale = 99, Culture = "nord", Type = MercenaryType.Special },
            };
        }

        public static MercenaryData GetMercenaryData(string unitId)
        {
            return _mercenaries.TryGetValue(unitId, out var data) ? data : null;
        }

        public static IEnumerable<MercenaryData> GetAllMercenaries()
        {
            return _mercenaries.Values;
        }

        public static IEnumerable<MercenaryData> GetMercenariesByType(MercenaryType type)
        {
            foreach (var merc in _mercenaries.Values)
            {
                if (merc.Type == type)
                    yield return merc;
            }
        }

        public static IEnumerable<MercenaryData> GetMercenariesByCulture(string culture)
        {
            foreach (var merc in _mercenaries.Values)
            {
                if (merc.Culture == culture)
                    yield return merc;
            }
        }

        public static int GetWages(string unitId)
        {
            var data = GetMercenaryData(unitId);
            return data?.Wages ?? 10;
        }

        public static int GetUpkeep(string unitId)
        {
            var data = GetMercenaryData(unitId);
            return data?.Upkeep ?? 5;
        }
    }
}
