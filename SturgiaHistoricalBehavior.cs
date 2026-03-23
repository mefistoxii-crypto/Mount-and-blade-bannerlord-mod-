using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;
using HarmonyLib;

namespace TacticalOverhaul
{
    /// <summary>
    /// STURGIA HISTORICAL SYSTEMS
    ///
    /// Features:
    /// 1. Boyar Assembly - noble council system
    /// 2. Ice Fishing - winter economy boost
    /// 3. River Trade - special trade routes
    /// 4. Winter Warfare - cold weather bonuses
    /// </summary>
    public class SturgiaHistoricalBehavior : CampaignBehaviorBase
    {
        private Dictionary<Settlement, IceFishingData> _iceFishingLocations;
        private Dictionary<Hero, BoyarLoyalty> _boyarLoyalty;
        private Dictionary<Kingdom, RiverTradeData> _riverTradeRoutes;
        private Dictionary<Settlement, WinterFortification> _winterFortifications;
        private const float WINTER_WARFARE_BONUS = 0.20f; // +20% effectiveness in cold

        public SturgiaHistoricalBehavior()
        {
            _iceFishingLocations = new Dictionary<Settlement, IceFishingData>();
            _boyarLoyalty = new Dictionary<Hero, BoyarLoyalty>();
            _riverTradeRoutes = new Dictionary<Kingdom, RiverTradeData>();
            _winterFortifications = new Dictionary<Settlement, WinterFortification>();
        }

        public override void RegisterEvents()
        {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
            CampaignEvents.DailyTickEvent.AddNonSerializedListener(this, DailyTick);
            CampaignEvents.HourlyTickPartyEvent.AddNonSerializedListener(this, HourlyTickParty);
            CampaignEvents.OnSettlementGarrisonChangedEvent.AddNonSerializedListener(this, OnSettlementGarrisonChanged);
            CampaignEvents.OnClanRelationChangedEvent.AddNonSerializedListener(this, OnClanRelationChanged);
        }

        public override void SyncData(IDataStore dataStore)
        {
            dataStore.SyncData("_tacticalOverhaul_iceFishingLocations", ref _iceFishingLocations);
            dataStore.SyncData("_tacticalOverhaul_boyarLoyalty", ref _boyarLoyalty);
            dataStore.SyncData("_tacticalOverhaul_riverTradeRoutes", ref _riverTradeRoutes);
            dataStore.SyncData("_tacticalOverhaul_winterFortifications", ref _winterFortifications);
        }

        private void OnSessionLaunched(CampaignGameStarter starter)
        {
            InitializeSturgiaSystems();
        }

        private void InitializeSturgiaSystems()
        {
            // Initialize ice fishing locations in Sturgian settlements
            foreach (var settlement in Settlement.All.Where(s => s.Culture?.StringId == "sturgia" && s.IsTown))
            {
                if (MBRandom.RandomFloat < 0.30f) // 30% chance
                {
                    CreateIceFishingLocation(settlement);
                }
            }

            // Initialize river trade routes for Sturgia
            var sturgiaKingdom = Kingdom.All.FirstOrDefault(k => k.Culture?.StringId == "sturgia");
            if (sturgiaKingdom != null)
            {
                CreateRiverTradeRoute(sturgiaKingdom);
            }

            InformationManager.DisplayMessage(new InformationMessage(
                "Sturgia Historical Systems Active: Boyar Assembly & River Trade!",
                Color.FromUint(0xFF0000FF)));
        }

        private void DailyTick()
        {
            // Process ice fishing
            ProcessIceFishingLocations();

            // Process boyar loyalty
            ProcessBoyarLoyalty();

            // Process river trade
            ProcessRiverTradeRoutes();

            // Process winter fortifications
            ProcessWinterFortifications();
        }

        private void HourlyTickParty(MobileParty party)
        {
            if (party == null || !party.IsActive) return;

            // Check for winter effects
            CheckWinterEffects(party);

            // Apply river trade effects
            ApplyRiverTradeEffects(party);
        }

        #region ICE FISHING SYSTEM

        private void CreateIceFishingLocation(Settlement settlement)
        {
            if (_iceFishingLocations.ContainsKey(settlement)) return;

            var fishing = new IceFishingData
            {
                FishType = (FishType)MBRandom.RandomInt(0, 4),
                ProsperityBonus = MBRandom.RandomInt(5, 15),
                FoodBonus = MBRandom.RandomInt(10, 25),
                DaysUntilThaw = MBRandom.RandomInt(20, 40)
            };

            _iceFishingLocations[settlement] = fishing;

            if (settlement == Settlement.CurrentSettlement && Hero.MainHero != null)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    $"{settlement.Name} has excellent ice fishing for {GetFishName(fishing.FishType)}!",
                    Color.FromUint(0xFF0000FF)));
            }
        }

        private string GetFishName(FishType type)
        {
            switch (type)
            {
                case FishType.Pike:
                    return "pike";
                case FishType.Perch:
                    return "perch";
                case FishType.Salmon:
                    return "salmon";
                case FishType.Trout:
                    return "trout";
                default:
                    return "fish";
            }
        }

        private void ProcessIceFishingLocations()
        {
            foreach (var kvp in _iceFishingLocations.ToList())
            {
                var settlement = kvp.Key;
                var fishing = kvp.Value;

                // Reduce thaw time
                fishing.DaysUntilThaw--;

                // Renew if thawed
                if (fishing.DaysUntilThaw <= 0)
                {
                    fishing.DaysUntilThaw = MBRandom.RandomInt(20, 40);
                    InformationManager.DisplayMessage(new InformationMessage(
                        $"The ice fishing season in {settlement.Name} has begun anew!",
                        Color.FromUint(0xFF0000FF)));
                }

                if (settlement.Town != null)
                {
                    // Boost prosperity
                    settlement.Town.Prosperity += fishing.ProsperityBonus * 0.05f;

                    // Boost food supply
                    settlement.Town.FoodStocks += fishing.FoodBonus * 0.1f;
                }
            }
        }

        #endregion

        #region BOYAR LOYALTY SYSTEM

        private void OnClanRelationChanged(Clan firstClan, Clan secondClan, float relationChange, bool isPersonalRelation)
        {
            // If Sturgian clans become friendly, boost boyar loyalty
            if (!isPersonalRelation && firstClan != null && secondClan != null && 
                firstClan.Culture?.StringId == "sturgia" && secondClan.Culture?.StringId == "sturgia" &&
                relationChange > 20 && relation + relationChange > 30)
            {
                BoostBoyarLoyalty(firstClan.Leader, secondClan.Leader);
            }
        }

        private void BoostBoyarLoyalty(Hero firstHero, Hero secondHero)
        {
            if (firstHero == null || secondHero == null) return;

            // Boost loyalty for both heroes
            if (!_boyarLoyalty.ContainsKey(firstHero))
            {
                _boyarLoyalty[firstHero] = new BoyarLoyalty { LoyaltyLevel = 50 };
            }
            _boyarLoyalty[firstHero].LoyaltyLevel = Math.Min(100, _boyarLoyalty[firstHero].LoyaltyLevel + 10);

            if (!_boyarLoyalty.ContainsKey(secondHero))
            {
                _boyarLoyalty[secondHero] = new BoyarLoyalty { LoyaltyLevel = 50 };
            }
            _boyarLoyalty[secondHero].LoyaltyLevel = Math.Min(100, _boyarLoyalty[secondHero].LoyaltyLevel + 10);

            InformationManager.DisplayMessage(new InformationMessage(
                $"Boyar loyalty increased between {firstHero.Name} and {secondHero.Name}!",
                Color.FromUint(0xFF0000FF)));
        }

        private void ProcessBoyarLoyalty()
        {
            foreach (var kvp in _boyarLoyalty.ToList())
            {
                var hero = kvp.Key;
                var loyalty = kvp.Value;

                if (hero.Clan != null && hero.Clan.Kingdom != null)
                {
                    // High loyalty provides troop quality bonus
                    if (loyalty.LoyaltyLevel >= 80)
                    {
                        foreach (var troop in hero.Clan.Tier)
                        {
                            if (troop.Character != null)
                            {
                                // In a real implementation, we would modify troop stats
                                // For now, just boost morale
                                if (hero.PartyBelongedTo != null)
                                {
                                    hero.PartyBelongedTo.Morale += 0.1f;
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region RIVER TRADE SYSTEM

        private void CreateRiverTradeRoute(Kingdom kingdom)
        {
            var tradeRoute = new RiverTradeData
            {
                Kingdom = kingdom,
                ProsperityBonus = MBRandom.RandomInt(10, 20),
                TradeRoutes = kingdom.Settlements
                    .Where(s => s.IsTown)
                    .Select(s => s)
                    .ToList(),
                DaysUntilNextTrade = MBRandom.RandomInt(5, 10)
            };

            _riverTradeRoutes[kingdom] = tradeRoute;
        }

        private void ProcessRiverTradeRoutes()
        {
            foreach (var kvp in _riverTradeRoutes.ToList())
            {
                var kingdom = kvp.Key;
                var tradeRoute = kvp.Value;

                // Reduce trade time
                tradeRoute.DaysUntilNextTrade--;

                // Perform trade if time has come
                if (tradeRoute.DaysUntilNextTrade <= 0)
                {
                    PerformRiverTrade(tradeRoute);
                    tradeRoute.DaysUntilNextTrade = MBRandom.RandomInt(5, 10);
                }
            }
        }

        private void PerformRiverTrade(RiverTradeData tradeRoute)
        {
            foreach (var settlement in tradeRoute.TradeRoutes)
            {
                if (settlement.Town != null)
                {
                    // Boost prosperity
                    settlement.Town.Prosperity += tradeRoute.ProsperityBonus * 0.1f;

                    // Boost loyalty
                    settlement.Town.Loyalty += 0.2f;
                }
            }

            // If player is part of this kingdom, provide gold bonus
            if (Hero.MainHero != null && Hero.MainHero.MapFaction == tradeRoute.Kingdom)
            {
                int goldBonus = tradeRoute.TradeRoutes.Count * 50;
                Hero.MainHero.ChangeHeroGold(goldBonus);

                InformationManager.DisplayMessage(new InformationMessage(
                    $"River trade has brought {goldBonus} gold to your clan!",
                    Color.FromUint(0xFF00FF00)));
            }
        }

        private void ApplyRiverTradeEffects(MobileParty party)
        {
            if (party == null || party.LeaderHero == null || party.LeaderHero.MapFaction == null) return;

            var tradeRoute = _riverTradeRoutes.Values.FirstOrDefault(r => r.Kingdom == party.LeaderHero.MapFaction);
            if (tradeRoute != null)
            {
                // Boost morale for parties traveling on rivers
                if (party.CurrentSettlement != null && 
                    party.CurrentSettlement.Town != null && 
                    party.CurrentSettlement.Town.IsCoastalOrRiver)
                {
                    party.Morale += 0.15f;
                }
            }
        }

        #endregion

        #region WINTER WARFARE SYSTEM

        private void OnSettlementGarrisonChanged(Settlement settlement)
        {
            // When Sturgian settlement gets garrison, check for winter fortification
            if (settlement.OwnerClan != null && 
                settlement.OwnerClan.Culture?.StringId == "sturgia" && 
                settlement.IsTown &&
                !_winterFortifications.ContainsKey(settlement))
            {
                if (MBRandom.RandomFloat < 0.4f) // 40% chance
                {
                    CreateWinterFortification(settlement);
                }
            }
        }

        private void CreateWinterFortification(Settlement settlement)
        {
            var fortification = new WinterFortification
            {
                DefenseBonus = MBRandom.RandomInt(10, 25),
                DaysUntilMelt = MBRandom.RandomInt(15, 30)
            };

            _winterFortifications[settlement] = fortification;

            if (settlement == Settlement.CurrentSettlement && Hero.MainHero != null)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    $"{settlement.Name} has winter fortifications! (+{fortification.DefenseBonus} defense bonus)",
                    Color.FromUint(0xFF0000FF)));
            }
        }

        private void ProcessWinterFortifications()
        {
            foreach (var kvp in _winterFortifications.ToList())
            {
                var settlement = kvp.Key;
                var fortification = kvp.Value;

                // Reduce melt time
                fortification.DaysUntilMelt--;

                // Remove if melted
                if (fortification.DaysUntilMelt <= 0)
                {
                    _winterFortifications.Remove(settlement);

                    if (settlement == Settlement.CurrentSettlement && Hero.MainHero != null)
                    {
                        InformationManager.DisplayMessage(new InformationMessage(
                            $"The winter fortifications in {settlement.Name} have melted.",
                            Color.FromUint(0xFF808080)));
                    }
                }
            }
        }

        private void CheckWinterEffects(MobileParty party)
        {
            if (party == null || !party.IsActive) return;

            // Check if party is in a cold region
            bool isColdRegion = party.CurrentSettlement != null && 
                               party.CurrentSettlement.Town != null && 
                               party.CurrentSettlement.Town.IsCold;

            if (isColdRegion)
            {
                // Check for winter fortifications at current settlement
                if (_winterFortifications.ContainsKey(party.CurrentSettlement))
                {
                    var fortification = _winterFortifications[party.CurrentSettlement];

                    // Boost defense if defending
                    if (party.CurrentSettlement?.SiegeEvent != null && 
                        party.CurrentSettlement.SiegeEvent.BesiegerParty == party)
                    {
                        party.Morale += fortification.DefenseBonus * 0.01f;
                    }
                }

                // Check for Sturgian troops
                int sturgianCount = 0;
                foreach (var element in party.MemberRoster.GetTroopRoster())
                {
                    if (element.Character?.Culture?.StringId == "sturgia")
                    {
                        sturgianCount += element.Number;
                    }
                }

                if (sturgianCount > 0)
                {
                    // Sturgian troops get winter warfare bonus
                    party.Morale += sturgianCount * 0.01f;
                }
            }
        }

        #endregion
    }

    public class IceFishingData
    {
        public FishType FishType { get; set; }
        public int ProsperityBonus { get; set; }
        public int FoodBonus { get; set; }
        public int DaysUntilThaw { get; set; }
    }

    public enum FishType
    {
        Pike,
        Perch,
        Salmon,
        Trout
    }

    public class BoyarLoyalty
    {
        public int LoyaltyLevel { get; set; }
    }

    public class RiverTradeData
    {
        public Kingdom Kingdom { get; set; }
        public int ProsperityBonus { get; set; }
        public List<Settlement> TradeRoutes { get; set; }
        public int DaysUntilNextTrade { get; set; }
    }

    public class WinterFortification
    {
        public int DefenseBonus { get; set; }
        public int DaysUntilMelt { get; set; }
    }
}
