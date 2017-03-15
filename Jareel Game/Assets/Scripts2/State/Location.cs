
using Jareel;

namespace JareelUnity
{
    /// <summary>
    /// Stores data about the player's current location
    /// </summary>
    [StateContainer("location")]
    public class LocationState : State
    {
        #region StateData

        /// <summary>
        /// The zone the player is currently residing in
        /// </summary>
        [StateData("zone")] public string Zone { get; set; }

        /// <summary>
        /// The player's x coordinate
        /// </summary>
        [StateData("x")] public int X { get; set; }
        
        /// <summary>
        /// The player's y coordinate
        /// </summary>
        [StateData("y")] public int Y { get; set; }

        #endregion

        #region Construction

        /// <summary>
        /// Creates a new location state
        /// </summary>
        public LocationState()
        {
            Zone = "";
        }

        #endregion
    }

    public class LocationController : StateController<LocationState>
    {
        /// <summary>
        /// Creates and returns a deep copy of the location state
        /// </summary>
        /// <returns>Deep copy of the location state</returns>
        public override LocationState CloneState()
        {
            return new LocationState() {
                Zone = State.Zone,
                X = State.X,
                Y = State.Y
            };
        }
    }
}
