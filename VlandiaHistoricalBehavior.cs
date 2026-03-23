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
    /// VLANDIA HISTORICAL SYSTEMS
    ///
    /// Features:
    /// 1. Knightly Code - honor and chivalry system
    /// 2. Feudal Levy - troop recruitment mechanics
    /// 3. Tournament Circuit - events and rewards
    /// 4. Castle Hierarchy - noble rank system
    /// </summary>
    public class VlandiaHistoricalBehavior : CampaignBehaviorBase
    {
        private Dictionary<Hero, KnightlyCodeData> _knightlyCodes;
        private Dictionary<Settlement, TournamentData> _activeTournaments;
        private Dictionary<Clan, FeudalLevyData> _feudalLevies;
        private Dictionary<Hero, NobleRank> _nobleRanks;
        private const float KNIGHTLY_HONOR_BONUS = 0.25f; // +25% honor bonus
        private const float KNIGHTLY_LEADERSHIP_BONUS = 0.20f; // +20% leadership bonus

        public VlandiaHistoricalBehavior()
        {
            _knightlyCodes = new Dictionary<Hero, KnightlyCodeData>();
            _activeTournaments = new Dictionary<Settlement, TournamentData>();
            _feudalLevies = new Dictionary<Clan, FeudalLevyData>();
            _nobleRanks = new Dictionary<Hero, NobleRank>();
        }

        public override void RegisterEvents()
        {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
            CampaignEvents.DailyTickEvent.AddNonSerializedListener(this, DailyTick);
            CampaignEvents.HourlyTickPartyEvent.AddNonSerializedListener(this, HourlyTickParty);
            CampaignEvents.OnSettlementOwnerChangedEvent.AddNonSerializedListener(this, OnSettlementOwnerChanged);
            CampaignEvents.OnHeroCreatedEvent.AddNonSerializedListener(this, OnHeroCreated);
        }

        public override void SyncData(IDataStore dataStore)
        {
            dataStore.SyncData("_tacticalOverhaul_knightlyCodes", ref _knightlyCodes);
            dataStore.SyncData("_tacticalOverhaul_activeTournaments", ref _activeTournaments);
            dataStore.SyncData("_tacticalOverhaul_feudalLevies", ref _feudalLevies);
            dataStore.SyncData("_tacticalOverhaul_nobleRanks", ref _nobleRanks);
        }

        private void OnSessionLaunched(CampaignGameStarter starter)
        {
            InitializeVlandiaSystems();
        }

        private void InitializeVlandiaSystems()
        {
            // Initialize tournaments in Vlandian settlements
            foreach (var settlement in Settlement.All.Where(s => s.Culture?.StringId == "vlandia" && s.IsTown))
            {
                if (MBRandom.RandomFloat < 0.20f) // 20% chance
                {
                    ScheduleTournament(settlement);
                }
            }

            // Initialize noble ranks for Vlandian heroes
            foreach (var hero in Hero.AllHeroes.Where(h => h.Clan?.Culture?.StringId == "vlandia"))
            {
                AssignNobleRank(hero);
            }

            InformationManager.DisplayMessage(new InformationMessage(
                "Vlandia Historical Systems Active: Knightly Code & Tournaments!",
                Color.FromUint(0xFFFF0000)));
        }

        private void DailyTick()
        {
            // Process knightly codes
            ProcessKnightlyCodes();

            // Process tournaments
            ProcessTournaments();

            // Process feudal levies
            ProcessFeudalLevies();

            // Process noble ranks
            ProcessNobleRanks();
        }

        private void HourlyTickParty(MobileParty party)
        {
            if (party == null || !party.IsActive) return;

            // Check for knights in party
            CheckKnightlyPresence(party);

            // Apply feudal levy effects
            ApplyFeudalLevyEffects(party);
        }

        #region KNIGHTLY CODE SYSTEM

        private void OnHeroCreated(Hero hero)
        {
            if (hero != null && hero.Clan?.Culture?.StringId == "vlandia")
            {
                AssignNobleRank(hero);
            }
        }

        private void AssignNobleRank(Hero hero)
        {
            if (_nobleRanks.ContainsKey(hero)) return;

            var rank = new NobleRank
            {
                Title = GetNobleTitle(hero),
                HonorBonus = MBRandom.RandomInt(5, 15),
                LeadershipBonus = MBRandom.RandomInt(3, 10)
            };

            _nobleRanks[hero] = rank;

            if (hero == Hero.MainHero)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    $"You have been granted the title of {rank.Title}!",
                    Color.FromUint(0xFFFF0000)));
            }
        }

        private string GetNobleTitle(Hero hero)
        {
            if (hero.Clan?.Leader == hero)
            {
                return "Count";
            }
            else if (hero.IsNoble && hero.Age > 25)
            {
                return "Knight";
            }
            else
            {
                return "Squire";
            }
        }

        private void CheckKnightlyPresence(MobileParty party)
        {
            // Count knights
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
                // Knights boost morale
                party.Morale += knightCount * 0.015f;

                // Chance to adopt knightly code
                if (MBRandom.RandomFloat < 0.04f && knightCount >= 3)
                {
                    AdoptKnightlyCode(party);
                }
            }
        }

        private bool IsKnight(CharacterObject character)
        {
            if (character == null) return false;

            string id = character.StringId.ToLower();
            return id.Contains("knight") || id.Contains("man at arms") || id.Contains("cavalry");
        }

        private void AdoptKnightlyCode(MobileParty party)
        {
            if (party.LeaderHero == null) return;

            var code = new KnightlyCodeData
            {
                IsActive = true,
                DaysRemaining = MBRandom.RandomInt(5, 10),
                HonorBonus = KNIGHTLY_HONOR_BONUS,
                LeadershipBonus = KNIGHTLY_LEADERSHIP_BONUS
            };

            _knightlyCodes[party.LeaderHero] = code;

            if (party == MobileParty.MainParty)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    "You have embraced the KNIGHTLY CODE! (+25% honor, +20% leadership)",
                    Color.FromUint(0xFFFF0000)));
            }
        }

        private void ProcessKnightlyCodes()
        {
            var expiredCodes = _knightlyCodes
                .Where(kvp => kvp.Value.DaysRemaining-- <= 0)
                .Select(kvp => kvp.Key)
                .ToList();

            foreach (var hero in expiredCodes)
            {
                _knightlyCodes.Remove(hero);

                if (hero == Hero.MainHero)
                {
                    InformationManager.DisplayMessage(new InformationMessage(
                        "Your knightly code commitment has ended.",
                        Color.FromUint(0xFF808080)));
                }
            }

            // Apply active codes
            foreach (var kvp in _knightlyCodes.Where(c => c.Value.IsActive))
            {
                ApplyKnightlyCodeEffects(kvp.Key, kvp.Value);
            }
        }

        private void ApplyKnightlyCodeEffects(Hero hero, KnightlyCodeData code)
        {
            if (hero.PartyBelongedTo == null) return;

            // Boost honor
            hero.SetPersonalValue(HeroTrait.Honor, hero.GetPersonalValue(HeroTrait.Honor) + code.HonorBonus * 0.01f);

            // Boost leadership
            foreach (var companion in hero.PartyBelongedTo.MemberRoster.GetTroopRoster())
            {
                if (companion.Character.IsHero && companion.Character.HeroObject != null)
                {
                    companion.Character.HeroObject.SetPersonalValue(HeroTrait.Leadership, 
                        companion.Character.HeroObject.GetPersonalValue(HeroTrait.Leadership) + code.LeadershipBonus * 0.01f);
                }
            }
        }

        #endregion

        #region TOURNAMENT SYSTEM

        private void ScheduleTournament(Settlement settlement)
        {
            if (_activeTournaments.ContainsKey(settlement)) return;

            var tournament = new TournamentData
            {
                Settlement = settlement,
                PrizePool = MBRandom.RandomInt(500, 2000),
                DaysUntilTournament = MBRandom.RandomInt(7, 14),
                Participants = new List<Hero>()
            };

            _activeTournaments[settlement] = tournament;

            if (settlement == Settlement.CurrentSettlement && Hero.MainHero != null)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    $"{settlement.Name} will host a tournament in {tournament.DaysUntilTournament} days!",
                    Color.FromUint(0xFFFF0000)));
            }
        }

        private void ProcessTournaments()
        {
            foreach (var kvp in _activeTournaments.ToList())
            {
                var settlement = kvp.Key;
                var tournament = kvp.Value;

                // Reduce time until tournament
                tournament.DaysUntilTournament--;

                // If time has come, hold the tournament
                if (tournament.DaysUntilTournament <= 0)
                {
                    HoldTournament(tournament);
                    tournament.DaysUntilTournament = MBRandom.RandomInt(14, 28); // Schedule next tournament
                }
            }
        }

        private void HoldTournament(TournamentData tournament)
        {
            // If player is at the settlement, allow participation
            if (Settlement.CurrentSettlement == tournament.Settlement && Hero.MainHero != null)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    "A tournament is being held in " + tournament.Settlement.Name + "!",
                    Color.FromUint(0xFFFF0000)));

                // In a real implementation, this would trigger a tournament mini-game
                // For now, just provide a gold reward for participation
                Hero.MainHero.ChangeHeroGold(tournament.PrizePool / 4);

                InformationManager.DisplayMessage(new InformationMessage(
                    "You participated in the tournament and won " + (tournament.PrizePool / 4) + " gold!",
                    Color.FromUint(0xFF00FF00)));
            }

            // Boost settlement prosperity
            if (tournament.Settlement.Town != null)
            {
                tournament.Settlement.Town.Prosperity += 10;
            }
        }

        #endregion

        #region FEUDAL LEVY SYSTEM

        private void OnSettlementOwnerChanged(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturerHero, ChangeOwnerOfSettlementAction.ChangeOwnerOfSettlementDetail detail)
        {
            // When a Vlandian settlement changes hands, establish feudal levy
            if (newOwner != null && newOwner.Clan?.Culture?.StringId == "vlandia")
            {
                CreateFeudalLevy(newOwner.Clan, settlement);
            }
        }

        private void CreateFeudalLevy(Clan clan, Settlement settlement)
        {
            if (_feudalLevies.ContainsKey(clan)) return;

            var levy = new FeudalLevyData
            {
                Clan = clan,
                Settlement = settlement,
                TroopCount = MBRandom.RandomInt(20, 50),
                DaysUntilExpiration = MBRandom.RandomInt(10, 20)
            };

            _feudalLevies[clan] = levy;

            InformationManager.DisplayMessage(new InformationMessage(
                $"{clan.Name} has raised a feudal levy of {levy.TroopCount} troops at {settlement.Name}!",
                Color.FromUint(0xFFFF0000)));
        }

        private void ProcessFeudalLevies()
        {
            foreach (var kvp in _feudalLevies.ToList())
            {
                var clan = kvp.Key;
                var levy = kvp.Value;

                // Reduce expiration time
                levy.DaysUntilExpiration--;

                // If time has come, expire levy
                if (levy.DaysUntilExpiration <= 0)
                {
                    _feudalLevies.Remove(clan);

                    InformationManager.DisplayMessage(new InformationMessage(
                        $"The feudal levy of {clan.Name} has expired.",
                        Color.FromUint(0xFF808080)));
                }
            }
        }

        private void ApplyFeudalLevyEffects(MobileParty party)
        {
            if (party == null || party.LeaderHero == null) return;

            var levy = _feudalLevies.Values.FirstOrDefault(l => l.Clan == party.LeaderHero.Clan);
            if (levy != null && levy.Settlement == party.CurrentSettlement)
            {
                // Boost troop quality
                foreach (var troop in party.MemberRoster.GetTroopRoster())
                {
                    if (troop.Character != null)
                    {
                        // In a real implementation, we would modify troop stats
                        // For now, just boost morale
                        party.Morale += 0.1f;
                    }
                }
            }
        }

        #endregion

        #region NOBLE RANK SYSTEM

        private void ProcessNobleRanks()
        {
            foreach (var kvp in _nobleRanks)
            {
                var hero = kvp.Key;
                var rank = kvp.Value;

                // Apply rank bonuses
                if (hero.PartyBelongedTo != null)
                {
                    // Boost morale
                    hero.PartyBelongedTo.Morale += rank.HonorBonus * 0.01f;

                    // Boost leadership
                    if (hero.GetSkillValue(DefaultSkills.Leadership) > 0)
                    {
                        float newLeadership = hero.GetSkillValue(DefaultSkills.Leadership) + rank.LeadershipBonus * 0.01f;
                        hero.SetSkillValue(DefaultSkills.Leadership, newLeadership);
                    }
                }
            }
        }

        #endregion
    }

    public class KnightlyCodeData
    {
        public bool IsActive { get; set; }
        public int DaysRemaining { get; set; }
        public float HonorBonus { get; set; }
        public float LeadershipBonus { get; set; }
    }

    public class TournamentData
    {
        public Settlement Settlement { get; set; }
        public int PrizePool { get; set; }
        public int DaysUntilTournament { get; set; }
        public List<Hero> Participants { get; set; }
    }

    public class FeudalLevyData
    {
        public Clan Clan { get; set; }
        public Settlement Settlement { get; set; }
        public int TroopCount { get; set; }
        public int DaysUntilExpiration { get; set; }
    }

    public class NobleRank
    {
        public string Title { get; set; }
        public int HonorBonus { get; set; }
        public int LeadershipBonus { get; set; }
    }
}
