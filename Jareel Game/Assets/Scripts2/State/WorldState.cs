using Jareel;
using JareelUnity.World;
using System.Linq;

namespace JareelUnity
{
    /// <summary>
    /// Contains the state of the world. This includes the state of every tile
    /// </summary>
    [StateContainer("world")]
    public class WorldState : State
    {
        #region State Data

        /// <summary>
        /// The current state of every tile in the state
        /// </summary>
        [StateData("tiles")] public Tile[][] Tiles { get; set; }

        /// <summary>
        /// The name of the current map
        /// </summary>
        [StateData("map")] public string MapName { get; set; }

        #endregion

        #region Construction

        /// <summary>
        /// Creates an empty world state
        /// </summary>
        public WorldState()
        {
            MapName = "";
        }

        /// <summary>
        /// Creates a world state with a set of tiles given
        /// </summary>
        /// <param name="map">The name of the map</param>
        /// <param name="tiles">The set of tiles derived from the map</param>
        public WorldState(string map, Tile[][] tiles)
        {
            MapName = map;
            Tiles = tiles;
        }

        #endregion
    }

    /// <summary>
    /// Controls changes to the world state
    /// </summary>
    public class WorldController : StateController<WorldState>
    {
        /// <summary>
        /// Creates a deep copy of the world state
        /// </summary>
        /// <returns>The state of the world</returns>
        public override WorldState CloneState()
        {
            return new WorldState() {
                Tiles = State.Tiles.Select(p => p.Select(q => q.Copy()).ToArray()).ToArray(),
                MapName = State.MapName
            };
        }
    }
}
