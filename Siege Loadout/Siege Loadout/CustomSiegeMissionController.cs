using System.Collections.Generic;
using System;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;


namespace Siege_Loadout
{
    public class CustomSiegeMissionController : MissionLogic
    {
        private MissionEquipment currentBattleEquipment { get; set; }

        public override void OnBehaviourInitialize()
        {
            base.OnBehaviourInitialize();
            Hero mainHero = Hero.MainHero;
            if (mainHero != null)
            {
                Utilities.PrintLine($"have siege equips for mainHero:: {mainHero.BattleEquipment}");
                // assign an empty set of equipment
                try
                {
                    Equipment siegeLoadout = mainHero.BattleEquipment;
                    siegeLoadout.AddEquipmentToSlotWithoutAgent((EquipmentIndex)5, mainHero.CivilianEquipment.GetEquipmentFromSlot((EquipmentIndex)5)); // change head armor to civilian head armor
                    Utilities.PrintLine($"assigned {siegeLoadout.GetEquipmentFromSlot((EquipmentIndex)5)} to head armor slot");

                    MissionEquipment newMissionEquipment = new MissionEquipment();
                    newMissionEquipment.FillFrom(siegeLoadout, mainHero.ClanBanner);
                    this.currentBattleEquipment = newMissionEquipment;
                    mainHero.SetSiegeEquipment(siegeLoadout);
                    Utilities.PrintLine($"have siege equips for mainHero:: {mainHero.GetSiegeEquipment()}");
                }
                catch (Exception e)
                {
                    Utilities.PrintLine($"cant get siege equips in custom siege controller due to {e}");
                }
            }
            else
            {
                Utilities.PrintLine("main hero is null");
            }
        }

        public override void AfterStart()
        {
            base.AfterStart();
            Agent mainAgent = Mission.Current.MainAgent;
            Hero mainHero = Hero.MainHero;
            MissionEquipment newMissionEquipment = new MissionEquipment();
            newMissionEquipment.FillFrom(mainHero.GetSiegeEquipment(), mainHero.ClanBanner);
            if(mainAgent != null)
            {
                mainAgent.InitializeMissionEquipment(newMissionEquipment, mainHero.ClanBanner);
            }
            else
            {
                Utilities.PrintLine("main agent is null in AfterStart");
            }
        }

        public override void OnMissionDeactivate()
        {
            base.OnMissionDeactivate();
            Agent mainAgent = Mission.Current.MainAgent;
            Hero mainHero = Hero.MainHero;
            mainAgent.InitializeMissionEquipment(this.currentBattleEquipment, mainHero.ClanBanner);
        }

    }
}
