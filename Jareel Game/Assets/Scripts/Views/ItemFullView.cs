using UnityEngine;
using UnityEngine.UI;
using Jareel.Unity;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    /// <summary>
    /// View which displays the complete content of an item
    /// </summary>
    public class ItemFullView : MonoStateSubscriber<InventoryState, InventoryUIState>
    {
        #region Fields

        /// <summary>
        /// Used to display the name of the item
        /// </summary>
        [SerializeField] private Text m_name;
        
        /// <summary>
        /// Used to display the content of the item
        /// </summary>
        [SerializeField] private Text m_description;

        /// <summary>
        /// Used to display the item's icon
        /// </summary>
        [SerializeField] private Image m_icon;

        /// <summary>
        /// The root of all visual components in tihs view
        /// </summary>
        [SerializeField] private GameObject m_viewRoot;

        /// <summary>
        /// Contains data on all of the items available to the user
        /// </summary>
        [SerializeField] private InventoryRepository m_items;

        #endregion

        #region Updates

        /// <summary>
        /// Updates this view based on the current data in the inventory and inventory UI states
        /// </summary>
        /// <param name="inventory">The state of the player's inventory</param>
        /// <param name="ui">The state of the inventory UI</param>
        protected override void OnStateChanged(InventoryState inventory, InventoryUIState ui)
        {
            bool open = ui.Open && ui.SelectedSlot >= 0;
            m_viewRoot.gameObject.SetActive(open);

            if (open) {
                var item = m_items.AllItems.First(p => p.ID == GetItemID(ui.OpenBag, ui.SelectedSlot));

                m_name.text = item.Name;
                m_description.text = item.Description;
                m_icon.sprite = item.Icon;
            }
        }

        /// <summary>
        /// Gets the item ID of the item existing in the given bag at the given slot
        /// </summary>
        /// <param name="bag">The name of the bag to retrieve from</param>
        /// <returns>Item in the given bag at the given slot</returns>
        private string GetItemID(string bag, int slot)
        {
            switch (bag) {
                case (InventoryState.MainBagName):
                    return State1.MainBag[slot];

                case (InventoryState.PotionsBagName):
                    return State1.Potions[slot];

                default: return null;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Submits the selected item for use and deselects the currently selected item
        /// </summary>
        public void Submit()
        {
            Events.ExecuteStrict(InventoryEvent.RemoveItem, State2.OpenBag, State2.SelectedSlot);
            Events.ExecuteStrict(InventoryUIEvent.CloseItem);
        }

        /// <summary>
        /// Closes this view
        /// </summary>
        public void Close()
        {
            Events.ExecuteStrict(InventoryUIEvent.CloseItem);
        }

        #endregion
    }
}
