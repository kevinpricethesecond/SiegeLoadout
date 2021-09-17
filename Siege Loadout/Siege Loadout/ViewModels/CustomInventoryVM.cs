
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace Siege_Loadout
{
    class CustomInventoryVM : ViewModel
    {
        private InventoryLogic _inventoryLogic = null;
        private Hero _hero = null;
        private SPInventoryVM _inventory = null;
        private HintViewModel _battleOutfitHint;


        public CustomInventoryVM() : base()
        {
            _inventoryLogic = InventoryManager.InventoryLogic;
            _hero = Hero.MainHero;
            Utilities.PrintLine($"inside customVM with Inventory Logic {_inventoryLogic}");
        }

        public CustomInventoryVM(SPInventoryVM inventory) : base()
        {
            _inventoryLogic = InventoryManager.InventoryLogic;
            _inventory = inventory;
            _hero = Hero.MainHero;
            Utilities.PrintLine($"inside customVM with Inventory Logic {_inventoryLogic}");
        }

        [DataSourceProperty]
        public HintViewModel BattleOutfitHint
        {
            get => _battleOutfitHint;
            set
            {
                if (_battleOutfitHint != value)
                {
                    _battleOutfitHint = value;
                    OnPropertyChanged();
                }
                else if (_battleOutfitHint == null)
                {
                    _battleOutfitHint = new HintViewModel(GameTexts.FindText("str_inventory_battle_outfit", null), null);
                }
            }
        }

    }
}
