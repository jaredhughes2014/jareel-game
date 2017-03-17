using Jareel.Unity;
using UnityEngine;
using System.Linq;

namespace Game
{
	/// <summary>
	/// Renders the world background
	/// </summary>
	public class WorldView : MonoStateSubscriber<WorldState>
	{
		#region Fields

		/// <summary>
		/// The maps this renderer works with
		/// </summary>
		[SerializeField] private MapRepository m_maps;

		/// <summary>
		/// The object under which the room tiles will be rendered
		/// </summary>
		[SerializeField] private GameObject m_mapRoot;

		/// <summary>
		/// The prefab that is used to generate map tiles
		/// </summary>
		[SerializeField] private WorldTile m_tileTemplate;

		/// <summary>
		/// The name of the map that is currently active
		/// </summary>
		private string m_activeMap = "";

		/// <summary>
		/// Contains the image components used for rendering
		/// </summary>
		private ComponentCache<WorldTile> m_mapTiles;

		#endregion

		/// <summary>
		/// Check to see if the map in the world state is different than the one
		/// currently rendered
		/// </summary>
		/// <param name="state">Contains data about the current state of the world</param>
		protected override void OnStateChanged(WorldState state)
		{
			if (state.MapName != m_activeMap) {
				var map = m_maps.Maps.FirstOrDefault(p => p.Name == state.MapName);

				if (map == null) {
					Debug.LogWarning("Unable to load map: " + state.MapName);
				}
				else {
					LayoutMap(map);
				}

				m_activeMap = state.MapName;
			}
		}

		protected override void Start()
		{
			base.Start();
			m_mapTiles = new ComponentCache<WorldTile>(m_mapRoot, m_tileTemplate);
		}

		#region Layout

		/// <summary>
		/// Lays out all map tiles using the specifications in the given map data
		/// and world state
		/// </summary>
		/// <param name="map">Contains the sprites used for rendering</param>
		private void LayoutMap(MapData map)
		{
			var sprites = m_mapTiles.ActivateCopies(map.MapSprites.Length);

			for (int i = 0; i < sprites.Length; ++i) {
				var tile = sprites[i];
				tile.Sprite = map.MapSprites[i];

				tile.SetCoordinates(i % map.Columns, i / map.Columns);

				var position = new Vector2(tile.Image.preferredWidth * tile.X, -tile.Image.preferredHeight * tile.Y);
				tile.transform.localPosition = position;
				tile.transform.localScale = Vector3.one;

				tile.OnClick += RegisterTileClick;
			}
		}

		/// <summary>
		/// Registers when the user clicks on a tile
		/// </summary>
		/// <param name="x">The x location of the click</param>
		/// <param name="y">The y location of the click</param>
		private void RegisterTileClick(int x, int y)
		{
			var ev = (true) ? LocationEvent.WarpLocation : LocationEvent.SetLocation;
			Events.Execute(ev, x, y);
		}

		#endregion
	}
}
