using SandBox.GauntletUI;
using System;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.Library;
using Siege_Loadout.Layers;

namespace Siege_Loadout
{
    class CustomInventoryBehaviour : CampaignBehaviorBase
    {
        public SPInventoryVM Inventory { get; private set; }
        private InventoryGauntletScreen _inventoryScreen { get; set; }
        private GauntletLayer _mainLayer { get; set; }

        private void AddNewInventoryLayer(TutorialContextChangedEvent tutorialContextChangedEvent)
        {
            try
            {
                if (tutorialContextChangedEvent == null)
                {
                    throw new Exception("tutorialContextChangedEvent is null");
                }
                if (tutorialContextChangedEvent.NewContext == TutorialContexts.InventoryScreen)
                {
                    if (ScreenManager.TopScreen is InventoryGauntletScreen)
                    {
                        _inventoryScreen = ScreenManager.TopScreen as InventoryGauntletScreen;
                        Inventory = (SPInventoryVM)_inventoryScreen.GetType().GetField("_dataSource", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_inventoryScreen);
                        _mainLayer = new InventoryLayer(1000, "GauntletLayer", Inventory, false);
                        
                        _inventoryScreen.AddLayer(_mainLayer);
                        _mainLayer.InputRestrictions.SetInputRestrictions(true, InputUsageMask.All);
                    }
                }
                else if (tutorialContextChangedEvent.NewContext == TutorialContexts.None)
                {
                    if (_inventoryScreen != null && _mainLayer != null)
                    {
                        _inventoryScreen.RemoveLayer(this._mainLayer);
                        _mainLayer = null;
                    }
                }
            }
            catch (Exception e)
            {
                Utilities.PrintLine($"Failed to add custom inventory layer due to {e}");
            }
}

        public override void RegisterEvents()
        {
            Game.Current.EventManager.RegisterEvent(new Action<TutorialContextChangedEvent>(this.AddNewInventoryLayer));
        }

        public override void SyncData(IDataStore dataStore)
        {

        }
    }
}
