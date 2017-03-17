using UnityEngine;

namespace Game
{
	/// <summary>
	/// Contains all of the maps used in the game
	/// </summary>
	public class MapRepository : ScriptableObject
	{
		/// <summary>
		/// The maps held in this repository
		/// </summary>
		[SerializeField] private MapData[] m_maps;
		public MapData[] Maps { get { return m_maps; } }
	}
}
