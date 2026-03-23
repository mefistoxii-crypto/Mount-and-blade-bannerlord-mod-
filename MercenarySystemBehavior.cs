using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace TacticalOverhaul
{
    /// <summary>
    /// Mercenary System - FIXED VERSION
    /// Using MBObjectManager instead of CharacterObject.Find
    /// </summary>
    public class MercenarySystemBehavior : CampaignBehaviorBase
    {
        private Dictionary<Settlement, List<CharacterObject>> _availableMercenaries;
        private const int MAX_MERCENARIES_PER_SETTLEMENT = 5;

        public MercenarySystemBehavior()
        {
            _availableMercenaries = new Dictionary<Settlement, List<CharacterObject>>();
        }

        public override void RegisterEvents()
        {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
            CampaignEvents.DailyTickEvent.AddNonSerializedListener(this, OnDailyTick);
            CampaignEvents.OnSettlementOwnerChangedEvent.AddNonSerializedListener(this, OnSettlementOwnerChanged);
        }

        public override void SyncData(IDataStore dataStore)
        {
            dataStore.SyncData("_tacticalOverhaul_availableMercenaries", ref _availableMercenaries);
        }

        private void OnSessionLaunched(CampaignGameStarter starter)
        {
            try
            {
                InitializeMercenarySystem();
                InformationManager.DisplayMessage(new InformationMessage(
                    "Mercenary System Active!",
                    Color.FromUint(0xFF00FF00)));
            }
            catch (Exception ex)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    $"Mercenary System Error: {ex.Message}",
                    Color.FromUint(0xFFFF0000)));
            }
        }

        private void InitializeMercenarySystem()
        {
            foreach (var settlement in Settlement.All.Where(s => s.IsTown))
            {
                if (MBRandom.RandomFloat < 0.40f)
                {
                    SpawnMercenariesAtSettlement(settlement);
                }
            }
        }

        private void OnDailyTick()
        {
            try
            {
                foreach (var settlement in Settlement.All.Where(s => s.IsTown))
                {
                    if (!_availableMercenaries.ContainsKey(settlement) || _availableMercenaries[settlement].Count == 0)
                    {
                        if (MBRandom.RandomFloat < 0.10f)
                        {
                            SpawnMercenariesAtSettlement(settlement);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void OnSettlementOwnerChanged(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturerHero, ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail detail)
        {
            if (settlement.IsTown)
            {
                SpawnMercenariesAtSettlement(settlement);
            }
        }

        private void SpawnMercenariesAtSettlement(Settlement settlement)
        {
            try
            {
                var cultureId = settlement.Culture?.StringId;
                if (string.IsNullOrEmpty(cultureId)) return;

                var cultureMercs = MercenaryDatabase.GetMercenariesByCulture(cultureId).ToList();
                
                if (cultureMercs.Count == 0)
                {
                    cultureMercs = MercenaryDatabase.GetAllMercenaries().ToList();
                }

                var spawnCount = MBRandom.RandomInt(3, MAX_MERCENARIES_PER_SETTLEMENT + 1);
                var spawnedMercs = new List<CharacterObject>();

                for (int i = 0; i < spawnCount && cultureMercs.Count > 0; i++)
                {
                    var randomMerc = cultureMercs[MBRandom.RandomInt(0, cultureMercs.Count)];
                    
                    // FIXED: Using MBObjectManager instead of CharacterObject.Find
                    var character = MBObjectManager.Instance.GetObject<CharacterObject>(randomMerc.UnitId);
                    
                    if (character != null)
                    {
                        spawnedMercs.Add(character);
                        cultureMercs.Remove(randomMerc);
                    }
                }

                _availableMercenaries[settlement] = spawnedMercs;
            }
            catch (Exception) { }
        }

        public List<CharacterObject> GetAvailableMercenaries(Settlement settlement)
        {
            if (_availableMercenaries.TryGetValue(settlement, out var mercs))
                return mercs;
            return new List<CharacterObject>();
        }

        public void RecruitMercenary(CharacterObject mercenary, Settlement settlement, int count = 1)
        {
            try
            {
                if (!_availableMercenaries.ContainsKey(settlement)) return;
                if (!_availableMercenaries[settlement].Contains(mercenary)) return;

                var playerParty = MobileParty.MainParty;
                if (playerParty == null) return;

                var mercData = MercenaryDatabase.GetMercenaryData(mercenary.StringId);
                if (mercData == null) return;

                int cost = mercData.Wages * 5 * count;

                if (Hero.MainHero.Gold < cost)
                {
                    InformationManager.DisplayMessage(new InformationMessage(
                        $"Not enough gold! Need {cost} denars.",
                        Color.FromUint(0xFFFF0000)));
                    return;
                }

                playerParty.MemberRoster.AddToCounts(mercenary, count);
                Hero.MainHero.ChangeHeroGold(-cost);
                _availableMercenaries[settlement].Remove(mercenary);

                InformationManager.DisplayMessage(new InformationMessage(
                    $"Recruited {count}x {mercenary.Name} for {cost} denars!",
                    Color.FromUint(0xFF00FF00)));
            }
            catch (Exception ex)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    $"Recruitment error: {ex.Message}",
                    Color.FromUint(0xFFFF0000)));
            }
        }

        public string GetMercenaryInfo(CharacterObject mercenary)
        {
            var data = MercenaryDatabase.GetMercenaryData(mercenary.StringId);
            if (data == null) return $"{mercenary.Name} - No data";

            return $"{data.Name} (Tier {data.Tier})\n" +
                   $"Wages: {data.Wages} denars/day\n" +
                   $"Upkeep: {data.Upkeep} denars/day\n" +
                   $"Health: {data.BaseHealth}\n" +
                   $"Morale: {data.BaseMorale}\n" +
                   $"Type: {data.Type}\n" +
                   $"Recruitment Cost: {data.Wages * 5} denars";
        }
    }
}