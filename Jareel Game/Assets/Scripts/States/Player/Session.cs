using Jareel;

namespace Game
{
    /// <summary>
    /// Events that can be executed to change the session state
    /// </summary>
    public enum SessionEvent
    {
        ToggleDebug
    }

    /// <summary>
    /// State container for the player's session
    /// </summary>
    [StateContainer("session")]
    public class SessionState : State
    {
        #region State Data

        /// <summary>
        /// If true, this is a debug session
        /// </summary>
        [StateData(false)] public bool DebugEnabled { get; set; }

        /// <summary>
        /// If true, the debug menu has been triggered at least once
        /// </summary>
        [StateData] public bool DebugTriggered { get; set; }

        #endregion
    }

    /// <summary>
    /// Controls the changes and duplication of the session state
    /// </summary>
    public class SessionController : StateController<SessionState>
    {
        #region Event Listeners

        /// <summary>
        /// Toggles the debug enabled state.
        /// </summary>
        [EventListener(SessionEvent.ToggleDebug)]
        private void ToggleDebug()
        {
            State.DebugEnabled = !State.DebugEnabled;
            State.DebugTriggered = true;
        }

        #endregion

        /// <summary>
        /// Creates a deep copy of the session state
        /// </summary>
        /// <returns>Deep copy of the session state</returns>
        public override SessionState CloneState()
        {
            return new SessionState() {
                DebugEnabled = State.DebugEnabled,
                DebugTriggered = State.DebugTriggered
            };
        }
    }
}
