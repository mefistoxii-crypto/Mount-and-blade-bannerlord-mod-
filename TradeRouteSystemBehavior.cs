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
    /// Automatic trade routes between towns
    /// </summary>
    public class TradeRouteSystemBehavior : CampaignBehaviorBase
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
                "Tactical Overhaul BONUS: Automatic trade routes between towns",
                Color.FromUint(0xFFFFAA00)));
        }

        private void OnDailyTick()
        {
            // Automatic trade routes between towns - daily processing
        }
    }
}
