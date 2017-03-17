using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	/// <summary>
	/// Individual tile in the world
	/// </summary>
	public class WorldTile : MonoBehaviour
	{
		#region Events

		/// <summary>
		/// Event fired when the user clicks this tile
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public delegate void OnClickHandler(int x, int y);
		public event OnClickHandler OnClick;

		#endregion

		#region Properties

		/// <summary>
		/// The image used to render this tile
		/// </summary>
		[SerializeField] private Image m_image;
		public Image Image { get { return m_image; } }
		
		/// <summary>
		/// The sprite of this tile
		/// </summary>
		public Sprite Sprite { get { return m_image.sprite; } set { m_image.sprite = value; } }

		/// <summary>
		/// The x coordinate of this tile within the tile grid
		/// </summary>
		public int X { get; set; }

		/// <summary>
		/// The y coordinate of this tile within the tile grid
		/// </summary>
		public int Y { get; set; }

		#endregion

		#region Setup

		/// <summary>
		/// Sets the grid coordinates of this tile
		/// </summary>
		/// <param name="x">The x grid coordinate</param>
		/// <param name="y">The y grid coordinate</param>
		public void SetCoordinates(int x, int y)
		{
			X = x;
			Y = y;
		}

		/// <summary>
		/// Registers a click
		/// </summary>
		public void RegisterClick()
		{
			OnClick(X, Y);
		}

		#endregion
	}
}
