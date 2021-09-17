using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Engine.GauntletUI;

namespace Siege_Loadout.Layers
{
    class InventoryLayer : GauntletLayer
    {
        CustomInventoryVM _viewModel;

        public InventoryLayer(int localOrder, string categoryId = "GauntletLayer", bool shouldClear = false) : base(localOrder, categoryId, shouldClear)
        {
            LoadMovie("SiegeInventory", _viewModel);
        }

        public InventoryLayer(int localOrder, string categoryId, SPInventoryVM inventory, bool shouldClear = false) : base(localOrder, categoryId, shouldClear)
        {
            _viewModel = new CustomInventoryVM(inventory);
            Utilities.PrintLine($"inside inventory layer, have view model::{_viewModel}");
            LoadMovie("SiegeInventory", _viewModel);
        }
    }
}
