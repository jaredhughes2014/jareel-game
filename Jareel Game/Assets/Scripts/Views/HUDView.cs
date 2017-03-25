using Jareel.Unity;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Renders the basic HUD. This is the UI the user sees when they are not in combat
    /// </summary>
    public class HUDView : MonoStateSubscriber<HUDState>
    {
        #region Fields

        /// <summary>
        /// The root of the view
        /// </summary>
        [SerializeField] private GameObject m_viewRoot;

        /// <summary>
        /// The root of the button slider
        /// </summary>
        [SerializeField] private GameObject m_sliderRoot;

        /// <summary>
        /// The root of the button which opens the button slider
        /// </summary>
        [SerializeField] private GameObject m_sliderButton;

        #endregion

        /// <summary>
        /// Determine if this view should be hidden or visible
        /// </summary>
        /// <param name="ui"></param>
        protected override void OnStateChanged(HUDState ui)
        {
            m_viewRoot.SetActive(ui.Open);
            m_sliderRoot.SetActive(ui.SliderOpen);
            m_sliderButton.SetActive(!ui.SliderOpen);
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
            Events.ExecuteStrict(UIEvent.OpenPanel, UIState.InventoryName);
        }

        /// <summary>
        /// Sets the slider to be either open or closed
        /// </summary>
        /// <param name="open">If true, the slider will open</param>
        public void SetSliderOpen(bool open)
        {
            Events.ExecuteStrict(HUDEvent.SetSliderOpen, open);
        }

        /// <summary>
        /// Opens the character sheet view
        /// </summary>
        public void OpenCharacterSheet()
        {
            Debug.Log("NYI");
        }

        #endregion
    }
}
