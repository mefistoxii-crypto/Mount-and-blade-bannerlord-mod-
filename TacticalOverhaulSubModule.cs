using System;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using System.IO;

namespace TacticalOverhaul
{
    /// <summary>
    /// TACTICAL OVERHAUL v2.4.0 - WORKING VERSION
    /// </summary>
    public class TacticalOverhaulSubModule : MBSubModuleBase
    {
        private static readonly string LogPath = "TacticalOverhaul_log.txt";

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            LogMessage("Tactical Overhaul loading...");
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            
            try
            {
                // Initialize Harmony for extended formations
                ExtendedFormationsBehavior.InitializeHarmony();
                LogMessage("Harmony initialized successfully");
            }
            catch (Exception ex)
            {
                LogMessage($"Harmony initialization error: {ex.Message}");
            }
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
            
            try
            {
                if (game.GameType is Campaign)
                {
                    CampaignGameStarter campaignStarter = (CampaignGameStarter)gameStarterObject;
                    
                    // Add all campaign behaviors
                    campaignStarter.AddBehavior(new TacticalOverhaulBehavior());
                    campaignStarter.AddBehavior(new ArtillerySystemBehavior());
                    campaignStarter.AddBehavior(new CastleRecruitmentBehavior());
                    campaignStarter.AddBehavior(new ExtendedFormationsBehavior());
                    campaignStarter.AddBehavior(new MercenarySystemBehavior());
                    
                    // Historical behaviors
                    campaignStarter.AddBehavior(new VlandiaHistoricalBehavior());
                    campaignStarter.AddBehavior(new KhuzaitHistoricalBehavior());
                    campaignStarter.AddBehavior(new NormandyHistoricalBehavior());
                    campaignStarter.AddBehavior(new RutheniaHistoricalBehavior());
                    campaignStarter.AddBehavior(new SturgiaHistoricalBehavior());
                    campaignStarter.AddBehavior(new AseraiHistoricalBehavior());
                    campaignStarter.AddBehavior(new BattaniaHistoricalBehavior());
                    campaignStarter.AddBehavior(new EmpireHistoricalBehavior());
                    campaignStarter.AddBehavior(new NordHistoricalBehavior());
                    
                    LogMessage("All campaign behaviors added successfully");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error in OnGameStart: {ex.Message}");
            }
        }

        private void LogMessage(string message)
        {
            try
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}\n";
                File.AppendAllText(LogPath, logEntry);
                
                // Also show in game if possible
                InformationManager.DisplayMessage(new InformationMessage(
                    $"Tactical Overhaul: {message}",
                    Color.FromUint(0xFF00FF00)));
            }
            catch
            {
                // Silent fail - can't log
            }
        }
    }

    /// <summary>
    /// Simple behavior that shows the mod is working
    /// </summary>
    public class TacticalOverhaulBehavior : CampaignBehaviorBase
    {
        private bool _hasShownWelcome = false;

        public override void RegisterEvents()
        {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
        }

        public override void SyncData(IDataStore dataStore) { }

        private void OnSessionLaunched(CampaignGameStarter starter)
        {
            if (!_hasShownWelcome)
            {
                try
                {
                    InformationManager.DisplayMessage(new InformationMessage(
                        "===========================================",
                        Color.FromUint(0xFFFFAA00)));

                    InformationManager.DisplayMessage(new InformationMessage(
                        "TACTICAL OVERHAUL v2.4.0 ACTIVE",
                        Color.FromUint(0xFFFFAA00)));

                    InformationManager.DisplayMessage(new InformationMessage(
                        "All systems loaded successfully!",
                        Color.FromUint(0xFF00FF00)));

                    InformationManager.DisplayMessage(new InformationMessage(
                        "===========================================",
                        Color.FromUint(0xFFFFAA00)));

                    _hasShownWelcome = true;
                }
                catch (Exception ex)
                {
                    InformationManager.DisplayMessage(new InformationMessage(
                        $"Tactical Overhaul Error: {ex.Message}",
                        Color.FromUint(0xFFFF0000)));
                }
            }
        }
    }
}