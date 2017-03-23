using UnityEngine;
using Jareel.Unity;

namespace Game
{
    /// <summary>
    /// Renders the visuals of the player's inventory
    /// </summary>
    public class InventoryView : MonoStateSubscriber<InventoryState, UIState>
    {
        #region Fields

        /// <summary>
        /// The root of the inventory view
        /// </summary>
        [SerializeField] private GameObject m_viewRoot;

        #endregion

        #region Updates

        /// <summary>
        /// Every time the state changes, check to see if the view should still be open and update the items
        /// displayed in the view
        /// </summary>
        /// <param name="inventory">The state of the player's inventory</param>
        /// <param name="ui">The state of the UI</param>
        protected override void OnStateChanged(InventoryState inventory, UIState ui)
        {
            m_viewRoot.SetActive(ui.InventoryOpen);
        }

        #endregion

        #region Events

        /// <summary>
        /// Closes the player's inventory
        /// </summary>
        public void CloseInventory()
        {
            Events.Execute(UIEvent.SetInventoryOpen, false);
        }

        #endregion
    }
}
