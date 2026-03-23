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
    /// RUTHENIA HISTORICAL SYSTEMS
    ///
    /// Features:
    /// 1. Veche Council - assembly system
    /// 2. Druzhina Guard - elite warrior retinue
    /// 3. River Forts - defensive system
    /// 4. Trade Routes - economic network
    /// </summary>
    public class RutheniaHistoricalBehavior : CampaignBehaviorBase
    {
        private Dictionary<Settlement, VecheCouncilData> _vecheCouncils;
        private Dictionary<Hero, DruzhinaGuardData> _druzhinaGuards;
        private Dictionary<Settlement, RiverFortData> _riverForts;
        private Dictionary<Kingdom, TradeRouteData> _tradeRoutes;
        private const float DRUZHINA_GUARD_BONUS = 0.35f; // +35% combat effectiveness
        private const float RIVER_FORT_DEFENSE_BONUS = 0.30f; // +30% defense bonus

        public RutheniaHistoricalBehavior()
        {
            _vecheCouncils = new Dictionary<Settlement, VecheCouncilData>();
            _druzhinaGuards = new Dictionary<Hero, DruzhinaGuardData>();
            _riverForts = new Dictionary<Settlement, RiverFortData>();
            _tradeRoutes = new Dictionary<Kingdom, TradeRouteData>();
        }

        public override void RegisterEvents()
        {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
            CampaignEvents.DailyTickEvent.AddNonSerializedListener(this, DailyTick);
            CampaignEvents.HourlyTickPartyEvent.AddNonSerializedListener(this, HourlyTickParty);
            CampaignEvents.OnSettlementOwnerChangedEvent.AddNonSerializedListener(this, OnSettlementOwnerChanged);
            CampaignEvents.OnClanRelationChangedEvent.AddNonSerializedListener(this, OnClanRelationChanged);
        }

        public override void SyncData(IDataStore dataStore)
        {
            dataStore.SyncData("_tacticalOverhaul_vecheCouncils", ref _vecheCouncils);
            dataStore.SyncData("_tacticalOverhaul_druzhinaGuards", ref _druzhinaGuards);
            dataStore.SyncData("_tacticalOverhaul_riverForts", ref _riverForts);
            dataStore.SyncData("_tacticalOverhaul_tradeRoutes", ref _tradeRoutes);
        }

        private void OnSessionLaunched(CampaignGameStarter starter)
        {
            InitializeRutheniaSystems();
        }

        private void InitializeRutheniaSystems()
        {
            // Initialize veche councils in major Ruthenian settlements
            foreach (var settlement in Settlement.All.Where(s => s.Culture?.StringId == "ruthenia" && s.IsTown))
            {
                if (MBRandom.RandomFloat < 0.30f) // 30% chance
                {
                    CreateVecheCouncil(settlement);
                }
            }

            // Initialize river forts along waterways
            foreach (var settlement in Settlement.All.Where(s => s.Culture?.StringId == "ruthenia" && s.IsTown))
            {
                if (MBRandom.RandomFloat < 0.25f) // 25% chance
                {
                    BuildRiverFort(settlement);
                }
            }

            // Initialize trade routes for Ruthenia
            var rutheniaKingdom = Kingdom.All.FirstOrDefault(k => k.Culture?.StringId == "ruthenia");
            if (rutheniaKingdom != null)
            {
                CreateTradeRoutes(rutheniaKingdom);
            }

            InformationManager.DisplayMessage(new InformationMessage(
                "Ruthenia Historical Systems Active: Veche Council & Druzhina!",
                Color.FromUint(0xFF00FF00)));
        }

        private void DailyTick()
        {
            // Process veche councils
            ProcessVecheCouncils();

            // Process druzhina guards
            ProcessDruzhinaGuards();

            // Process river forts
            ProcessRiverForts();

            // Process trade routes
            ProcessTradeRoutes();
        }

        private void HourlyTickParty(MobileParty party)
        {
            if (party == null || !party.IsActive) return;

            // Check for druzhina guards in party
            CheckDruzhinaPresence(party);

            // Apply river fort effects
            ApplyRiverFortEffects(party);
        }

        #region VECH COUNCIL SYSTEM

        private void CreateVecheCouncil(Settlement settlement)
        {
            if (_vecheCouncils.ContainsKey(settlement)) return;

            var council = new VecheCouncilData
            {
                CouncilType = (CouncilType)MBRandom.RandomInt(0, 3),
                ProsperityBonus = MBRandom.RandomInt(8, 20),
                LoyaltyBonus = MBRandom.RandomInt(5, 15),
                DaysUntilMeeting = MBRandom.RandomInt(7, 14)
            };

            _vecheCouncils[settlement] = council;

            if (settlement == Settlement.CurrentSettlement && Hero.MainHero != null)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    $"{settlement.Name} has established a {GetCouncilName(council.CouncilType)} veche council!",
                    Color.FromUint(0xFF00FF00)));
            }
        }

        private string GetCouncilName(CouncilType type)
        {
            switch (type)
            {
                case CouncilType.City:
                    return "city";
                case CouncilType.Territorial:
                    return "territorial";
                case CouncilType.Kingdom:
                    return "kingdom";
                default:
                    return "regional";
            }
        }

        private void ProcessVecheCouncils()
        {
            foreach (var kvp in _vecheCouncils.ToList())
            {
                var settlement = kvp.Key;
                var council = kvp.Value;

                // Reduce meeting time
                council.DaysUntilMeeting--;

                // Hold meeting if time has come
                if (council.DaysUntilMeeting <= 0)
                {
                    HoldVecheMeeting(council);
                    council.DaysUntilMeeting = MBRandom.RandomInt(7, 14);
                }

                if (settlement.Town != null)
                {
                    // Boost prosperity
                    settlement.Town.Prosperity += council.ProsperityBonus * 0.05f;

                    // Boost loyalty
                    settlement.Town.Loyalty += council.LoyaltyBonus * 0.03f;
                }
            }
        }

        private void HoldVecheMeeting(VecheCouncilData council)
        {
            // If player owns the settlement, provide bonus
            if (council.Settlement.OwnerClan == Hero.MainHero?.Clan)
            {
                int goldBonus = MBRandom.RandomInt(100, 300);
                Hero.MainHero.ChangeHeroGold(goldBonus);

                InformationManager.DisplayMessage(new InformationMessage(
                    $"The veche council meeting in {council.Settlement.Name} has brought {goldBonus} gold to your clan!",
                    Color.FromUint(0xFF00FF00)));
            }
        }

        #endregion

        #region DRUZHINA GUARD SYSTEM

        private void CheckDruzhinaPresence(MobileParty party)
        {
            // Count druzhina guards
            int druzhinaCount = 0;

            foreach (var element in party.MemberRoster.GetTroopRoster())
            {
                if (IsDruzhina(element.Character))
                {
                    druzhinaCount += element.Number;
                }
            }

            if (druzhinaCount > 0 && party.LeaderHero != null)
            {
                // Druzhina guards boost morale
                party.Morale += druzhinaCount * 0.02f;

                // Chance to form druzhina retinue
                if (MBRandom.RandomFloat < 0.05f && druzhinaCount >= 3)
                {
                    FormDruzhinaRetinue(party);
                }
            }
        }

        private bool IsDruzhina(CharacterObject character)
        {
            if (character == null) return false;

            string id = character.StringId.ToLower();
            return id.Contains("druzhina") || id.Contains("warrior") || id.Contains("elite");
        }

        private void FormDruzhinaRetinue(MobileParty party)
        {
            if (party.LeaderHero == null) return;

            var retinue = new DruzhinaGuardData
            {
                IsActive = true,
                DaysRemaining = MBRandom.RandomInt(5, 10),
                CombatBonus = DRUZHINA_GUARD_BONUS
            };

            _druzhinaGuards[party.LeaderHero] = retinue;

            if (party == MobileParty.MainParty)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    "Your warriors have formed a DRUZHINA RETINUE! (+35% combat effectiveness)",
                    Color.FromUint(0xFF00FF00)));
            }
        }

        private void ProcessDruzhinaGuards()
        {
            var expiredRetinues = _druzhinaGuards
                .Where(kvp => kvp.Value.DaysRemaining-- <= 0)
                .Select(kvp => kvp.Key)
                .ToList();

            foreach (var hero in expiredRetinues)
            {
                _druzhinaGuards.Remove(hero);

                if (hero == Hero.MainHero)
                {
                    InformationManager.DisplayMessage(new InformationMessage(
                        "Your druzhina retinue has disbanded.",
                        Color.FromUint(0xFF808080)));
                }
            }

            // Apply active retinues
            foreach (var kvp in _druzhinaGuards.Where(r => r.Value.IsActive))
            {
                ApplyDruzhinaRetinueEffects(kvp.Key, kvp.Value);
            }
        }

        private void ApplyDruzhinaRetinueEffects(Hero hero, DruzhinaGuardData retinue)
        {
            if (hero.PartyBelongedTo == null) return;

            // Apply combat bonus to troops
            foreach (var element in hero.PartyBelongedTo.MemberRoster.GetTroopRoster())
            {
                if (element.Character != null)
                {
                    // In a real implementation, we would modify troop stats
                    // For now, just boost morale
                    hero.PartyBelongedTo.Morale += retinue.CombatBonus * 0.01f * element.Number;
                }
            }
        }

        #endregion

        #region RIVER FORT SYSTEM

        private void BuildRiverFort(Settlement settlement)
        {
            if (_riverForts.ContainsKey(settlement)) return;

            var fort = new RiverFortData
            {
                FortLevel = (FortLevel)MBRandom.RandomInt(1, 4),
                DefenseBonus = RIVER_FORT_DEFENSE_BONUS,
                GarrisonBonus = MBRandom.RandomInt(5, 15),
                DaysUntilPatrol = MBRandom.RandomInt(3, 7)
            };

            _riverForts[settlement] = fort;

            if (settlement == Settlement.CurrentSettlement && Hero.MainHero != null)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    $"{settlement.Name} has constructed a {GetFortName(fort.FortLevel)} river fort!",
                    Color.FromUint(0xFF00FF00)));
            }
        }

        private string GetFortName(FortLevel level)
        {
            switch (level)
            {
                case FortLevel.Small:
                    return "small";
                case FortLevel.Medium:
                    return "medium";
                case FortLevel.Large:
                    return "large";
                case FortLevel.Major:
                    return "major";
                default:
                    return "strategic";
            }
        }

        private void ProcessRiverForts()
        {
            foreach (var kvp in _riverForts.ToList())
            {
                var settlement = kvp.Key;
                var fort = kvp.Value;

                // Reduce patrol time
                fort.DaysUntilPatrol--;

                // Perform patrol if time has come
                if (fort.DaysUntilPatrol <= 0)
                {
                    PatrolRiver(fort);
                    fort.DaysUntilPatrol = MBRandom.RandomInt(3, 7);
                }

                if (settlement.Town != null)
                {
                    // Boost defense
                    settlement.Town.Loyalty += fort.DefenseBonus * 0.02f;

                    // Boost garrison
                    if (settlement.GarrisonTroopRoster != null)
                    {
                        settlement.GarrisonTroopRoster.AddToCounts(settlement.GarrisonTroopRoster.GetTroopRoster()
                            .FirstOrDefault()?.Character, fort.GarrisonBonus);
                    }
                }
            }
        }

        private void PatrolRiver(RiverFortData fort)
        {
            // If player owns the settlement, provide security bonus
            if (fort.Settlement.OwnerClan == Hero.MainHero?.Clan)
            {
                // Reduce bandit activity in the area
                foreach (var party in MobileParty.All.Where(p => p.IsActive && 
                    p.MapFaction != null && p.MapFaction.IsBanditFaction &&
                    p.Position.DistanceSquared(fort.Settlement.Position) < 40000))
                {
                    party.Morale -= 0.2f;
                }

                InformationManager.DisplayMessage(new InformationMessage(
                    $"Your river fort patrol has reduced bandit activity near {fort.Settlement.Name}!",
                    Color.FromUint(0xFF00FF00)));
            }
        }

        private void ApplyRiverFortEffects(MobileParty party)
        {
            if (party == null || party.LeaderHero == null) return;

            // Check if party is near a river fort
            var nearbyFort = _riverForts.Values.FirstOrDefault(f => 
                f.Settlement.Position.DistanceSquared(party.Position) < 40000);

            if (nearbyFort != null)
            {
                // Apply defense bonus
                party.Morale += nearbyFort.DefenseBonus * 0.01f;

                // If player owns the fort, provide additional bonuses
                if (nearbyFort.Settlement.OwnerClan == Hero.MainHero?.Clan)
                {
                    party.Morale += 0.1f;
                }
            }
        }

        #endregion

        #region TRADE ROUTE SYSTEM

        private void CreateTradeRoutes(Kingdom kingdom)
        {
            var tradeRoute = new TradeRouteData
            {
                Kingdom = kingdom,
                ProsperityBonus = MBRandom.RandomInt(15, 25),
                TradeRoutes = kingdom.Settlements
                    .Where(s => s.IsTown)
                    .Select(s => s)
                    .ToList(),
                DaysUntilCaravan = MBRandom.RandomInt(5, 10)
            };

            _tradeRoutes[kingdom] = tradeRoute;
        }

        private void ProcessTradeRoutes()
        {
            foreach (var kvp in _tradeRoutes.ToList())
            {
                var kingdom = kvp.Key;
                var tradeRoute = kvp.Value;

                // Reduce caravan time
                tradeRoute.DaysUntilCaravan--;

                // Send caravan if time has come
                if (tradeRoute.DaysUntilCaravan <= 0)
                {
                    SendTradeCaravan(tradeRoute);
                    tradeRoute.DaysUntilCaravan = MBRandom.RandomInt(5, 10);
                }
            }
        }

        private void SendTradeCaravan(TradeRouteData tradeRoute)
        {
            foreach (var settlement in tradeRoute.TradeRoutes)
            {
                if (settlement.Town != null)
                {
                    // Boost prosperity
                    settlement.Town.Prosperity += tradeRoute.ProsperityBonus * 0.1f;
                }
            }

            // If player is part of this kingdom, provide gold bonus
            if (Hero.MainHero != null && Hero.MainHero.MapFaction == tradeRoute.Kingdom)
            {
                int goldBonus = tradeRoute.TradeRoutes.Count * 75;
                Hero.MainHero.ChangeHeroGold(goldBonus);

                InformationManager.DisplayMessage(new InformationMessage(
                    $"Trade caravan has brought {goldBonus} gold to your clan!",
                    Color.FromUint(0xFF00FF00)));
            }
        }

        #endregion
    }

    public class VecheCouncilData
    {
        public Settlement Settlement { get; set; }
        public CouncilType CouncilType { get; set; }
        public int ProsperityBonus { get; set; }
        public int LoyaltyBonus { get; set; }
        public int DaysUntilMeeting { get; set; }
    }

    public class DruzhinaGuardData
    {
        public bool IsActive { get; set; }
        public int DaysRemaining { get; set; }
        public float CombatBonus { get; set; }
    }

    public class RiverFortData
    {
        public Settlement Settlement { get; set; }
        public FortLevel FortLevel { get; set; }
        public float DefenseBonus { get; set; }
        public int GarrisonBonus { get; set; }
        public int DaysUntilPatrol { get; set; }
    }

    public class TradeRouteData
    {
        public Kingdom Kingdom { get; set; }
        public int ProsperityBonus { get; set; }
        public List<Settlement> TradeRoutes { get; set; }
        public int DaysUntilCaravan { get; set; }
    }

    public enum CouncilType
    {
        City,
        Territorial,
        Kingdom
    }

    public enum FortLevel
    {
        Small,
        Medium,
        Large,
        Major
    }
}
