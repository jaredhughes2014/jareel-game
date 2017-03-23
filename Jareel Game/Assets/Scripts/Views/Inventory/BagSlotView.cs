using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	/// <summary>
	/// The view which renders a particular slot in a bag. This view
	/// </summary>
	public class BagSlotView : MonoBehaviour
	{
		#region Events

		/// <summary>
		/// Event executed when this bag slot is clicked
		/// </summary>
		/// <param name="item">The inventory item represented by this slot</param>
		/// <param name="slot">The slot in the bag this represents</param>
		public delegate void OnSlotClickedHandler(InventoryItem item, int slot);
		public event OnSlotClickedHandler OnSlotClicked;

		#endregion

		#region Fields

		/// <summary>
		/// Image used to render the icon for this item
		/// </summary>
		[SerializeField] private Image m_icon;

		/// <summary>
		/// Icon to display an empty item slot
		/// </summary>
		[SerializeField] private Sprite m_emptyIcon;

		#endregion

		#region State

		/// <summary>
		/// The slot in the bag this represents
		/// </summary>
		public int Slot { get; private set; }

		/// <summary>
		/// The inventory item held in this slot
		/// </summary>
		public InventoryItem Item { get; private set; }

		#endregion

		#region Rendering

		/// <summary>
		/// Renders the visuals for this bag slot
		/// </summary>
		/// <param name="item">The item held in this slot, or none if no item is selected</param>
		/// <param name="slot">The bag slot this item represents</param>
		public void Render(InventoryItem item, int slot)
		{
			Item = item;
			Slot = slot;

			m_icon.sprite = item == null ? m_emptyIcon : item.Icon;
		}

		#endregion

		#region Interactions

		/// <summary>
		/// Fires an event that this item was used
		/// </summary>
		public void UseItem()
		{
			if (OnSlotClicked != null) OnSlotClicked(Item, Slot);
		}

		#endregion
	}
}