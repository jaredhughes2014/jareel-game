using Jareel;

namespace JareelUnity
{
    /// <summary>
    /// Contains data about the UI
    /// </summary>
    [StateContainer("ui")]
    public class UIState : State
    {
        #region Constants

        /// <summary>
        /// The view that is active when no other view is open. This is the
        /// view that overlays the world
        /// </summary>
        public const string HUD = "HUD";

        #endregion

        #region State Data

        /// <summary>
        /// The name of the view that is open. The UI will render based on the
        /// value of this view
        /// </summary>
        [StateData] public string ActiveView { get; set; }

        #endregion
    }

    /// <summary>
    /// Controls the UI state
    /// </summary>
    public class UIController : StateController<UIState>
    {
        #region Cloning

        /// <summary>
        /// Creates a copy of the current UI state
        /// </summary>
        /// <returns>A clone of the UI state</returns>
        public override UIState CloneState()
        {
            return new UIState() {
                ActiveView = State.ActiveView
            };
        }

        #endregion
    }
}
