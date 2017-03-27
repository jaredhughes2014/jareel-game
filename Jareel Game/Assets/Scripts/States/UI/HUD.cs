using Jareel;

namespace Game
{ 
    /// <summary>
    /// Events that
    /// </summary>
    public enum HUDEvent
    {
        SetSliderOpen
    }

    /// <summary>
    /// Contains the state of the HUD
    /// </summary>
    [StateContainer("hud")]
    public class HUDState : State
    {
        #region Fields

        /// <summary>
        /// If true, the HUD slider should be open
        /// </summary>
        [StateData] public bool SliderOpen { get; set; }

        /// <summary>
        /// If true, the hud should be displayed
        /// </summary>
        [StateData] public bool Open { get; set; }

        #endregion
    }

    /// <summary>
    /// Controls cloning and modification of the HUD state
    /// </summary>
    public class HUDController : StateController<HUDState>
    {
        #region State Adapters

        /// <summary>
        /// Adapts data from the UI state into this state
        /// </summary>
        /// <param name="ui">The state of the UI</param>
        [StateAdapter]
        private void AdaptUI(UIState ui)
        {
            State.Open = ui.OpenPanel == UIState.HUDName;

            if (!State.Open) {
                SetSliderOpen(false);
            }
        }

        #endregion

        #region Event Listeners

        /// <summary>
        /// Sets the HUD slider open or closed
        /// </summary>
        /// <param name="open">If true, the HUD slider will be open</param>
        [EventListener(HUDEvent.SetSliderOpen)]
        private void SetSliderOpen(bool open)
        {
            State.SliderOpen = open;
        }

        #endregion

        /// <summary>
        /// Creates and returns a deep copy of the HUD state
        /// </summary>
        /// <returns>Deep copy of the HUD state</returns>
        public override HUDState CloneState()
        {
            return new HUDState() {
                Open = State.Open,
                SliderOpen = State.SliderOpen
            };
        }
    }
}
