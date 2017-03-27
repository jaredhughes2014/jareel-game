using Jareel;

namespace Game
{
    /// <summary>
    /// Contains the events that can be executed for the combat UI
    /// </summary>
    public enum CombatUIEvent
    {

    }

    /// <summary>
    /// Contains the state of the combat UI
    /// </summary>
    [StateContainer("combatUI")]
    public class CombatUIState : State
    {
        #region State Data

        /// <summary>
        /// If true, the combat UI should be open
        /// </summary>
        [StateData] public bool Open { get; set; }

        #endregion
    }

    /// <summary>
    /// Controls cloning and modification of the combat UI state
    /// </summary>
    public class CombatUIController : StateController<CombatUIState>
    {
        #region State Adapters

        /// <summary>
        /// Adapts the UI state to the state in this controller
        /// </summary>
        /// <param name="ui">The UI state</param>
        [StateAdapter]
        private void AdaptUI(UIState ui)
        {
            State.Open = ui.OpenPanel == UIState.CombatPanelName;
        }

        #endregion

        /// <summary>
        /// Creates and return a deep copy of the CombatUIState
        /// </summary>
        /// <returns>Deep copy of the combat UI State</returns>
        public override CombatUIState CloneState()
        {
            return new CombatUIState() {
                Open = State.Open
            };
        }
    }
}
