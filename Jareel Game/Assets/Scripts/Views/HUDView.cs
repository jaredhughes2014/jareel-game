using Jareel.Unity;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Renders the basic HUD. This is the UI the user sees when they are not in combat
    /// </summary>
    public class HUDView : MonoStateSubscriber<UIState>
    {
        /// <summary>
        /// The root of the view
        /// </summary>
        [SerializeField] private GameObject m_viewRoot;

        /// <summary>
        /// Determine if this view should be hidden or visible
        /// </summary>
        /// <param name="ui"></param>
        protected override void OnStateChanged(UIState ui)
        {
            bool combat = !ui.InCombat;

            m_viewRoot.SetActive(combat);
        }

        #region Events

        /// <summary>
        /// TODO TEMPORARY Executes an event to start combat
        /// </summary>
        public void StartCombat()
        {
            Events.ExecuteStrict(GeneralEvent.SetInCombat, true);
        }

        /// <summary>
        /// Opens the inventory view
        /// </summary>
        public void OpenInventory()
        {
            Events.ExecuteStrict(UIEvent.SetInventoryOpen, true);
        }

        #endregion
    }
}
