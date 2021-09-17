using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace Siege_Loadout
{
    public class HeroSiegeEquipmentCampaignBehaviour : CampaignBehaviorBase
    {
        private Dictionary<Hero, Equipment> _heroSiegeEquipment = new Dictionary<Hero, Equipment>();

        public Equipment GetSiegeEquipment(Hero hero)
        {
            if(_heroSiegeEquipment.TryGetValue(hero, out Equipment equipment))
            {
                return equipment;
            }
            Utilities.PrintLine("hero does not have a siege loadout - returning the battle loadout");
            return hero.BattleEquipment; // default is to use battle equips
        }

        public void SetSiegeEquipment(Hero hero, Equipment equipment)
        {
            _heroSiegeEquipment[hero] = equipment;
        }

        public override void RegisterEvents() { }
        public override void SyncData(IDataStore dataStore)
        {
            dataStore.SyncData("_heroSiegeEquipment", ref _heroSiegeEquipment);
        }
    }

    public static class HeroSiegeEquipmentExtension
    {
        public static Equipment GetSiegeEquipment(this Hero hero)
        {
            var behavior = Campaign.Current.GetCampaignBehavior<HeroSiegeEquipmentCampaignBehaviour>();
            return behavior.GetSiegeEquipment(hero);
        }

        public static void SetSiegeEquipment(this Hero hero, Equipment equipment)
        {
            var behavior = Campaign.Current.GetCampaignBehavior<HeroSiegeEquipmentCampaignBehaviour>();

            behavior.SetSiegeEquipment(hero, equipment);
        }
    }
}
