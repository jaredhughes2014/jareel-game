using UnityEngine;

namespace Game
{
	/// <summary>
	/// Stores data about the current map
	/// </summary>
	public class MapData : ScriptableObject
	{
		/// <summary>
		/// The sprites used to draw the map
		/// </summary>
		[SerializeField] private Sprite[] m_mapSprites;
		public Sprite[] MapSprites { get { return m_mapSprites; } }

		/// <summary>
		/// The number of columns per row on the map
		/// </summary>
		[SerializeField] private int m_columns;
		public int Columns { get { return m_columns; } }

		/// <summary>
		/// The name of the map
		/// </summary>
		[SerializeField] private string m_name;
		public string Name { get { return m_name; } }
	}
}
