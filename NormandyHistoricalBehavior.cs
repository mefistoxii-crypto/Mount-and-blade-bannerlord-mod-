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

namespace TacticalOverhaul
{
    /// <summary>
    /// NORMANDY HISTORICAL SYSTEMS - FIXED VERSION
    /// Removed IsSeaUnit, using string.Contains instead
    /// </summary>
    public class NormandyHistoricalBehavior : CampaignBehaviorBase
    {
        private Dictionary<Hero, FeudalOathData> _feudalOaths;
        private Dictionary<Settlement, NavalPowerData> _navalPowers;
        private Dictionary<Settlement, KnightlyOrderData> _knightlyOrders;
        private Dictionary<Settlement, CastleData> _castleBuildings;
        private const float FEUDAL_OATH_BONUS = 0.30f;
        private const float NAVAL_POWER_BONUS = 0.25f;

        public NormandyHistoricalBehavior()
        {
            _feudalOaths = new Dictionary<Hero, FeudalOathData>();
            _navalPowers = new Dictionary<Settlement, NavalPowerData>();
            _knightlyOrders = new Dictionary<Settlement, KnightlyOrderData>();
            _castleBuildings = new Dictionary<Settlement, CastleData>();
        }

        public override void RegisterEvents()
        {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
            CampaignEvents.DailyTickEvent.AddNonSerializedListener(this, DailyTick);
            CampaignEvents.HourlyTickPartyEvent.AddNonSerializedListener(this, HourlyTickParty);
            CampaignEvents.OnSettlementOwnerChangedEvent.AddNonSerializedListener(this, OnSettlementOwnerChanged);
        }

        public override void SyncData(IDataStore dataStore)
        {
            dataStore.SyncData("_tacticalOverhaul_feudalOaths", ref _feudalOaths);
            dataStore.SyncData("_tacticalOverhaul_navalPowers", ref _navalPowers);
            dataStore.SyncData("_tacticalOverhaul_knightlyOrders", ref _knightlyOrders);
            dataStore.SyncData("_tacticalOverhaul_castleBuildings", ref _castleBuildings);
        }

        private void OnSessionLaunched(CampaignGameStarter starter)
        {
            InitializeNormandySystems();
        }

        private void InitializeNormandySystems()
        {
            try
            {
                // Initialize feudal oaths for Normandy rulers
                foreach (var kingdom in Kingdom.All.Where(k => k.Culture?.StringId == "normandy"))
                {
                    if (kingdom.Leader != null)
                    {
                        CreateFeudalOath(kingdom.Leader, kingdom);
                    }
                }

                // Initialize naval powers in Normandy settlements
                foreach (var settlement in Settlement.All.Where(s => s.Culture?.StringId == "normandy" && s.IsTown))
                {
                    if (MBRandom.RandomFloat < 0.35f)
                    {
                        EstablishNavalPower(settlement);
                    }
                }

                // Initialize knightly orders
                foreach (var settlement in Settlement.All.Where(s => s.Culture?.StringId == "normandy" && s.IsTown))
                {
                    if (MBRandom.RandomFloat < 0.25f)
                    {
                        EstablishKnightlyOrder(settlement);
                    }
                }

                InformationManager.DisplayMessage(new InformationMessage(
                    "Normandy Historical Systems Active!",
                    Color.FromUint(0xFF0000FF)));
            }
            catch (Exception ex)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    $"Normandy initialization error: {ex.Message}",
                    Color.FromUint(0xFFFF0000)));
            }
        }

        private void DailyTick()
        {
            ProcessFeudalOaths();
            ProcessNavalPowers();
            ProcessKnightlyOrders();
            ProcessCastleBuildings();
        }

        private void HourlyTickParty(MobileParty party)
        {
            if (party == null || !party.IsActive) return;

            CheckKnightlyPresence(party);
            ApplyNavalPowerEffects(party);
        }

        #region FEUDAL OATH SYSTEM

        private void CreateFeudalOath(Hero ruler, Kingdom kingdom)
        {
            var oath = new FeudalOathData
            {
                Ruler = ruler,
                Kingdom = kingdom,
                OathStrength = MBRandom.RandomInt(70, 100),
                DaysUntilRenewal = MBRandom.RandomInt(14, 28)
            };

            foreach (var clan in kingdom.Clans)
            {
                if (clan.Leader != null && clan.Leader != ruler)
                {
                    _feudalOaths[clan.Leader] = oath;
                }
            }
        }

        private void ProcessFeudalOaths()
        {
            foreach (var kvp in _feudalOaths.ToList())
            {
                var vassal = kvp.Key;
                var oath = kvp.Value;

                oath.DaysUntilRenewal--;

                if (oath.DaysUntilRenewal <= 0)
                {
                    oath.DaysUntilRenewal = MBRandom.RandomInt(14, 28);
                }

                if (vassal.Clan?.Kingdom == oath.Kingdom)
                {
                    if (vassal == Hero.MainHero && vassal.PartyBelongedTo != null)
                    {
                        vassal.PartyBelongedTo.Morale += 0.2f;
                    }
                }
            }
        }

        #endregion

        #region NAVAL POWER SYSTEM

        private void EstablishNavalPower(Settlement settlement)
        {
            if (_navalPowers.ContainsKey(settlement)) return;

            var navalPower = new NavalPowerData
            {
                Settlement = settlement,
                PortLevel = (PortLevel)MBRandom.RandomInt(1, 4),
                TradeBonus = MBRandom.RandomInt(10, 30),
                CombatBonus = NAVAL_POWER_BONUS,
                DaysUntilMaintenance = MBRandom.RandomInt(7, 14)
            };

            _navalPowers[settlement] = navalPower;
        }

        private void ProcessNavalPowers()
        {
            foreach (var kvp in _navalPowers.ToList())
            {
                var settlement = kvp.Key;
                var navalPower = kvp.Value;

                navalPower.DaysUntilMaintenance--;

                if (navalPower.DaysUntilMaintenance <= 0)
                {
                    navalPower.DaysUntilMaintenance = MBRandom.RandomInt(7, 14);
                }

                if (settlement.Town != null)
                {
                    settlement.Town.Prosperity += navalPower.TradeBonus * 0.05f;
                }
            }
        }

        private void ApplyNavalPowerEffects(MobileParty party)
        {
            if (party?.LeaderHero?.MapFaction == null) return;

            var nearbyNavalPower = _navalPowers.Values.FirstOrDefault(np => 
                np.Settlement.Position.DistanceSquared(party.Position) < 40000);

            if (nearbyNavalPower != null)
            {
                // Check for naval units by string ID instead of IsSeaUnit
                foreach (var element in party.MemberRoster.GetTroopRoster())
                {
                    if (element.Character != null && 
                        (element.Character.StringId.Contains("naval") || 
                         element.Character.StringId.Contains("ship") ||
                         element.Character.StringId.Contains("viking") ||
                         element.Character.StringId.Contains("nord")))
                    {
                        party.Morale += nearbyNavalPower.CombatBonus * 0.01f * element.Number;
                    }
                }
            }
        }

        #endregion

        #region KNIGHTLY ORDER SYSTEM

        private void EstablishKnightlyOrder(Settlement settlement)
        {
            if (_knightlyOrders.ContainsKey(settlement)) return;

            var order = new KnightlyOrderData
            {
                Settlement = settlement,
                OrderType = (OrderType)MBRandom.RandomInt(0, 4),
                PietyBonus = MBRandom.RandomInt(10, 25),
                CombatBonus = MBRandom.RandomInt(5, 15),
                DaysUntilChapter = MBRandom.RandomInt(10, 20)
            };

            _knightlyOrders[settlement] = order;
        }

        private void CheckKnightlyPresence(MobileParty party)
        {
            int knightCount = 0;

            foreach (var element in party.MemberRoster.GetTroopRoster())
            {
                if (IsKnight(element.Character))
                {
                    knightCount += element.Number;
                }
            }

            if (knightCount > 0 && party.LeaderHero != null)
            {
                party.Morale += knightCount * 0.015f;

                if (MBRandom.RandomFloat < 0.05f && knightCount >= 3)
                {
                    JoinKnightlyOrder(party);
                }
            }
        }

        private bool IsKnight(CharacterObject character)
        {
            if (character == null) return false;

            string id = character.StringId.ToLower();
            return id.Contains("knight") || id.Contains("cavalry") || id.Contains("man at arms");
        }

        private void JoinKnightlyOrder(MobileParty party)
        {
            if (party.LeaderHero == null) return;

            var nearbyOrder = _knightlyOrders.Values.FirstOrDefault(o => 
                o.Settlement.Position.DistanceSquared(party.Position) < 40000);

            if (nearbyOrder != null)
            {
                foreach (var element in party.MemberRoster.GetTroopRoster())
                {
                    if (IsKnight(element.Character))
                    {
                        party.Morale += nearbyOrder.CombatBonus * 0.01f * element.Number;
                    }
                }
            }
        }

        private void ProcessKnightlyOrders()
        {
            foreach (var kvp in _knightlyOrders.ToList())
            {
                var settlement = kvp.Key;
                var order = kvp.Value;

                order.DaysUntilChapter--;

                if (order.DaysUntilChapter <= 0)
                {
                    order.DaysUntilChapter = MBRandom.RandomInt(10, 20);
                }

                if (settlement.Town != null)
                {
                    settlement.Town.Loyalty += order.PietyBonus * 0.02f;
                }
            }
        }

        #endregion

        #region CASTLE BUILDING SYSTEM

        private void OnSettlementOwnerChanged(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturerHero, ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail detail)
        {
            if (newOwner?.Clan?.Culture?.StringId == "normandy")
            {
                if (MBRandom.RandomFloat < 0.30f && !_castleBuildings.ContainsKey(settlement))
                {
                    BuildCastle(settlement);
                }
            }
        }

        private void BuildCastle(Settlement settlement)
        {
            var castle = new CastleData
            {
                Settlement = settlement,
                CastleLevel = (CastleLevel)MBRandom.RandomInt(1, 4),
                DefenseBonus = MBRandom.RandomInt(10, 30),
                GarrisonBonus = MBRandom.RandomInt(5, 15),
                DaysUntilUpgrade = MBRandom.RandomInt(14, 28)
            };

            _castleBuildings[settlement] = castle;
        }

        private void ProcessCastleBuildings()
        {
            foreach (var kvp in _castleBuildings.ToList())
            {
                var settlement = kvp.Key;
                var castle = kvp.Value;

                castle.DaysUntilUpgrade--;

                if (castle.DaysUntilUpgrade <= 0)
                {
                    UpgradeCastle(castle);
                    castle.DaysUntilUpgrade = MBRandom.RandomInt(14, 28);
                }

                if (settlement.Town != null)
                {
                    settlement.Town.MilitiaPartySize += castle.GarrisonBonus;

                    if (settlement.OwnerClan == Hero.MainHero?.Clan)
                    {
                        settlement.Town.Loyalty += 0.3f;
                    }
                }
            }
        }

        private void UpgradeCastle(CastleData castle)
        {
            castle.CastleLevel = (CastleLevel)Math.Min((int)CastleLevel.Strategic, (int)castle.CastleLevel + 1);
            castle.DefenseBonus += 10;
            castle.GarrisonBonus += 5;
        }

        #endregion
    }

    #region Data Classes

    public class FeudalOathData
    {
        public Hero Ruler { get; set; }
        public Kingdom Kingdom { get; set; }
        public int OathStrength { get; set; }
        public int DaysUntilRenewal { get; set; }
    }

    public class NavalPowerData
    {
        public Settlement Settlement { get; set; }
        public PortLevel PortLevel { get; set; }
        public int TradeBonus { get; set; }
        public float CombatBonus { get; set; }
        public int DaysUntilMaintenance { get; set; }
    }

    public class KnightlyOrderData
    {
        public Settlement Settlement { get; set; }
        public OrderType OrderType { get; set; }
        public int PietyBonus { get; set; }
        public int CombatBonus { get; set; }
        public int DaysUntilChapter { get; set; }
    }

    public class CastleData
    {
        public Settlement Settlement { get; set; }
        public CastleLevel CastleLevel { get; set; }
        public int DefenseBonus { get; set; }
        public int GarrisonBonus { get; set; }
        public int DaysUntilUpgrade { get; set; }
    }

    #endregion

    #region Enums

    public enum PortLevel
    {
        Small,
        Medium,
        Large,
        Strategic
    }

    public enum OrderType
    {
        Templar,
        Hospitaller,
        Teutonic,
        Knights
    }

    public enum CastleLevel
    {
        Motte,
        Stone,
        Concentric,
        Strategic
    }

    #endregion
}