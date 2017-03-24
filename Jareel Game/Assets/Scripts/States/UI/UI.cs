using Jareel;

namespace Game
{
    /// <summary>
    /// Events which can be executed to modify the UI state
    /// </summary>
    public enum UIEvent
    {
        SetInventoryOpen
    }

    /// <summary>
    /// The state containing data about the UI
    /// </summary>
    [StateContainer("ui")]
    public class UIState : State
    {
		#region StateData

		/// <summary>
		/// If true, the action UI should open instead of the basic HUD
		/// </summary>
		[StateData] public bool InCombat { get; set; }

        /// <summary>
        /// If true, the inventory view should be displayed
        /// </summary>
        [StateData] public bool InventoryOpen { get; set; }

		#endregion
    }

	/// <summary>
	/// Controls modification and cloning of the UI state
	/// </summary>
    public class UIController : StateController<UIState>
    {
        #region Event Listeners

        /// <summary>
        /// If the user is not in combat, sets the inventory view open or closed.
        /// </summary>
        /// <param name="open">If true, the inventory is open. Otherwise false</param>
        [EventListener(UIEvent.SetInventoryOpen)]
        private void SetInventoryOpen(bool open)
        {
            if (!State.InCombat) {
                State.InventoryOpen = open;
            }
        }

        /// <summary>
        /// Sets the state of the combat UI. This will always set the inventory to closed
        /// as well, even if leaving combat
        /// </summary>
        /// <param name="inCombat">Sets the user to be in or out of combat</param>
        [EventListener(GeneralEvent.SetInCombat)]
        private void SetInCombat(bool inCombat)
        {
            State.InventoryOpen = false;
            State.InCombat = inCombat;
        }

        #endregion

        /// <summary>
        /// Creates a deep copy of the UI state
        /// </summary>
        /// <returns>Deep copy of the UI state</returns>
        public override UIState CloneState()
        {
            return new UIState() {
                InCombat = State.InCombat,
                InventoryOpen = State.InventoryOpen,
            };
        }
    }
}