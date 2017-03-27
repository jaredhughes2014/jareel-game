using Jareel;

namespace Game
{
    /// <summary>
    /// Events which can be executed to modify the UI state
    /// </summary>
    public enum UIEvent
    {
        OpenPanel,
        CloseActivePanel,

        SetHUDSliderOpen,
    }

    /// <summary>
    /// The state containing data about the UI
    /// </summary>
    [StateContainer("ui")]
    public class UIState : State
    {
        #region Constants

        // Panel names
        public const string InventoryName = "Inventory";
        public const string CharacterSheetName = "CharacterSheet";
        public const string CombatPanelName = "Combat";
        public const string HUDName = "HUD";

        #endregion

        #region StateData

        /// <summary>
        /// The name of the panel that is open. If no 
        /// </summary>
        [StateData] public string OpenPanel { get; set; }

        /// <summary>
        /// If true, the HUD slider is open
        /// </summary>
        [StateData] public bool HUDSliderOpen { get; set; }

        #endregion

        /// <summary>
        /// Create a new UI state
        /// </summary>
        public UIState()
        {
            OpenPanel = HUDName;
        }
    }

	/// <summary>
	/// Controls modification and cloning of the UI state
	/// </summary>
    public class UIController : StateController<UIState>
    {
        #region Event Listeners

        /// <summary>
        /// Sets the open panel
        /// </summary>
        /// <param name="panel">The name of the panel to open</param>
        [EventListener(UIEvent.OpenPanel)]
        private void OpenPanel(string panel)
        {
            State.OpenPanel = panel;
        }

        /// <summary>
        /// Sets the 
        /// </summary>
        /// <param name="open">If true, the inventory is open. Otherwise false</param>
        [EventListener(UIEvent.CloseActivePanel)]
        private void CloseOpenPanel()
        {
            State.OpenPanel = UIState.HUDName;
        }

        /// <summary>
        /// Sets the state of the combat UI. This will automatically open the combat panel
        /// if it is true, or the HUD panel otherwise
        /// </summary>
        /// <param name="inCombat">Sets the user to be in or out of combat</param>
        [EventListener(GeneralEvent.SetInCombat)]
        private void SetInCombat(bool inCombat)
        {
            State.OpenPanel = (inCombat) ? UIState.CombatPanelName : UIState.HUDName;
        }

        #endregion

        /// <summary>
        /// Creates a deep copy of the UI state
        /// </summary>
        /// <returns>Deep copy of the UI state</returns>
        public override UIState CloneState()
        {
            return new UIState() {
                OpenPanel = State.OpenPanel,
                HUDSliderOpen = State.HUDSliderOpen
            };
        }
    }
}