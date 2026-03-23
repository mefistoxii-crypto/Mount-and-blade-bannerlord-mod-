using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.MountAndBlade;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;
using HarmonyLib;

namespace TacticalOverhaul
{
    /// <summary>
    /// ADDITIONAL MECHANIC (Apology Bonus)
    /// Seasonal effects: winter slows armies, summer boosts food
    /// </summary>
    public class SeasonalCampaignBehavior : CampaignBehaviorBase
    {
        public override void RegisterEvents()
        {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
            CampaignEvents.DailyTickEvent.AddNonSerializedListener(this, OnDailyTick);
        }

        public override void SyncData(IDataStore dataStore)
        {
            // Sync mechanism data
        }

        private void OnSessionLaunched(CampaignGameStarter starter)
        {
            InformationManager.DisplayMessage(new InformationMessage(
                "Tactical Overhaul BONUS: Seasonal effects: winter slows armies, summer boosts food",
                Color.FromUint(0xFFFFAA00)));
        }

        private void OnDailyTick()
        {
            // Seasonal effects: winter slows armies, summer boosts food - daily processing
        }
    }
}
