using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace Siege_Loadout
{
    class CustomInventoryVM : ViewModel
    {
        private InventoryLogic _inventoryLogic;
        private Hero _hero;
        private SPInventoryVM _inventory;
    }
}
