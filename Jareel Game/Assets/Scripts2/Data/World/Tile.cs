using Jareel;

namespace JareelUnity.World
{
    /// <summary>
    /// A tile is an individual unit of space on a map. Tiles contain data
    /// about their visual and physical state
    /// </summary>
    public class Tile : StateObject, ICopyable<Tile>
    {
        #region Constants

        /// <summary>
        /// A standard tile status
        /// </summary>
        public int NormalStatus = 0;

        #endregion

        #region State Data

        /// <summary>
        /// If true, the user will not be able to walk through this tile
        /// </summary>
        [StateData("clip")] public bool Clip { get; set; }

        /// <summary>
        /// The ID of the tileset this tile will use for rendering
        /// </summary>
        [StateData("tileSet")] public string TileSetID { get; set; }

        /// <summary>
        /// The current status of this tile
        /// </summary>
        [StateData("status")] public int TileStatus { get; set; }

        #endregion

        #region Cloning

        /// <summary>
        /// Creates a deep copy of this tile
        /// </summary>
        /// <returns>Deep copy of this tile</returns>
        public Tile Copy()
        {
            return new Tile() {
                Clip = Clip,
                TileSetID = TileSetID,
                TileStatus = TileStatus
            };
        }

        #endregion
    }
}
