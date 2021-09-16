using TaleWorlds.MountAndBlade;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using UIExtenderLib;
using System;
using System.Collections.Generic;

namespace Siege_Loadout
{
    public class SubModule : MBSubModuleBase
    {
        public override void OnBeforeMissionBehaviourInitialize(Mission mission)
        {
            base.OnBeforeMissionBehaviourInitialize(mission);

            if (!mission.HasMissionBehaviour<CustomSiegeMissionController>() && mission.HasMissionBehaviour<SiegeMissionController>())
            {
                mission.AddMissionBehaviour(new CustomSiegeMissionController());
            }
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarter)
        {
            if (game.GameType is Campaign)
            {
                //The current game is a campaign
                CampaignGameStarter campaignStarter = (CampaignGameStarter)gameStarter;
                campaignStarter.AddBehavior(new HeroSiegeEquipmentCampaignBehaviour());
                campaignStarter.AddBehavior(new MissionSiegeEquipmentCampaignBehaviour());
                campaignStarter.AddBehavior(new CustomInventoryBehaviour());
            }
        }

    }
}
