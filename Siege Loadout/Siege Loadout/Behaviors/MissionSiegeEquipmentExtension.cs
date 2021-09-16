using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.MountAndBlade;

namespace Siege_Loadout
{

    public class MissionSiegeEquipmentCampaignBehaviour : CampaignBehaviorBase
    {
        private Dictionary<Mission, bool> _requiresSiegeLoadout = new Dictionary<Mission, bool>();

        public bool GetDoesMissionRequireSiegeEquipment(Mission mission)
        {
            if (_requiresSiegeLoadout.TryGetValue(mission, out bool result))
            {
                return result;
            }

            return false; //default value
        }

        public void SetDoesMissionRequireSiegeEquipment(Mission mission, bool newValue)
        {
            _requiresSiegeLoadout[mission] = newValue;
        }

        public override void RegisterEvents() { }
        public override void SyncData(IDataStore dataStore)
        {
            dataStore.SyncData("_requiresSiegeLoadout", ref _requiresSiegeLoadout);
        }
    }
    public static class MissionSiegeEquipmentExtension
    {
        public static bool GetDoesMissionRequireSiegeEquipment(this Mission mission)
        {
            var behavior = Campaign.Current.GetCampaignBehavior<MissionSiegeEquipmentCampaignBehaviour>();
            return behavior.GetDoesMissionRequireSiegeEquipment(mission);
        }

        public static void SetDoesMissionRequireSiegeEquipment(this Mission mission, bool newValue)
        {
            var behavior = Campaign.Current.GetCampaignBehavior<MissionSiegeEquipmentCampaignBehaviour>();

            behavior.SetDoesMissionRequireSiegeEquipment(mission, newValue);
        }
    }
}
