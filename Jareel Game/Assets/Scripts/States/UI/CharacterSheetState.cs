using Jareel;

namespace Game
{
    /// <summary>
    /// Events that
    /// </summary>
    public enum CharacterSheetEvent
    {
    }

    /// <summary>
    /// Contains the state of the character sheet
    /// </summary>
    [StateContainer("characterSheet")]
    public class CharacterSheetState : State
    {
        #region Fields

        /// <summary>
        /// If true, the hud should be displayed
        /// </summary>
        [StateData] public bool Open { get; set; }

        #endregion
    }

    /// <summary>
    /// Controls cloning and modification of the HUD state
    /// </summary>
    public class CharacterSheetController : StateController<CharacterSheetState>
    {
        #region State Adapters

        /// <summary>
        /// Adapts data from the UI state into this state
        /// </summary>
        /// <param name="ui">The state of the UI</param>
        [StateAdapter]
        private void AdaptUI(UIState ui)
        {
            State.Open = ui.OpenPanel == UIState.CharacterSheetName;
        }

        #endregion

        /// <summary>
        /// Creates and returns a deep copy of the HUD state
        /// </summary>
        /// <returns>Deep copy of the HUD state</returns>
        public override CharacterSheetState CloneState()
        {
            return new CharacterSheetState() {
                Open = State.Open,
            };
        }
    }
}
