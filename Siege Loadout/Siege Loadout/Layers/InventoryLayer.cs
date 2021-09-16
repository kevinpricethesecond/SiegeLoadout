using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;

namespace Siege_Loadout.Layers
{
    class InventoryLayer : GauntletLayer
    {
        CustomInventoryVM _viewModel;

        public InventoryLayer(int localOrder, string categoryId = "GauntletLayer") : base(localOrder, categoryId)
        {
            
            _viewModel = new CustomInventoryVM();
            this.LoadMovie("SiegeInventory", this._viewModel);
        }
    }
}
