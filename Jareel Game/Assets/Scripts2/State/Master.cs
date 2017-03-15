using Jareel;

namespace JareelUnity
{
    /// <summary>
    /// Connecting point for all of the states in the game
    /// </summary>
    public class JareelGameMasterController : MasterController
    {
        /// <summary>
        /// Defines which states and controllers should be used by using the Use() function
        /// </summary>
        protected override void UseControllers()
        {
            Use<UIState, UIController>();
            Use<InventoryState, InventoryController>();
            Use<SkillState, SkillController>();
            Use<LocationState, LocationController>();
            Use<WorldState, WorldController>();
        }
    }
}
