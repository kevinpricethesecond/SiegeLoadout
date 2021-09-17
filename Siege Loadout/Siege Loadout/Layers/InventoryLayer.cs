using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Engine.GauntletUI;

namespace Siege_Loadout.Layers
{
    class InventoryLayer : GauntletLayer
    {
        CustomInventoryVM _viewModel;
        private bool _firstRefresh = false;
        private bool _leftMouseButtonWasReleased = false;

        public InventoryLayer(int localOrder, string categoryId = "GauntletLayer", bool shouldClear = false) : base(localOrder, categoryId, shouldClear)
        {
            _viewModel = new CustomInventoryVM();
            LoadMovie("SiegeInventory", _viewModel);
        }

        public InventoryLayer(int localOrder, string categoryId, SPInventoryVM inventory, bool shouldClear = false) : base(localOrder, categoryId, shouldClear)
        {
            _viewModel = new CustomInventoryVM(inventory);
            Utilities.PrintLine($"inside inventory layer, have view model::{_viewModel}");
            /*LoadMovie("SiegeInventory", _viewModel);*/
            string movieName = "SiegeInventory";
            LoadMovie(movieName, _viewModel);
        }

        protected override void OnLateUpdate(float dt)
        {
            base.OnLateUpdate(dt);

            // Since we are refreshing for the first time, we need to check for first refresh
            // so we are not refreshing every single late update
            if (!_firstRefresh)
            {
                _firstRefresh = true;
                _viewModel.RefreshValues();
                return;
            }

            if (TaleWorlds.InputSystem.Input.IsKeyReleased(TaleWorlds.InputSystem.InputKey.LeftMouseButton) && !_leftMouseButtonWasReleased)
            {
                _viewModel.RefreshValues();
                _leftMouseButtonWasReleased = true;
            }

            if (TaleWorlds.InputSystem.Input.IsKeyPressed(TaleWorlds.InputSystem.InputKey.LeftMouseButton) && _leftMouseButtonWasReleased)
            {
                _leftMouseButtonWasReleased = false;
            }

        }
    }
}
