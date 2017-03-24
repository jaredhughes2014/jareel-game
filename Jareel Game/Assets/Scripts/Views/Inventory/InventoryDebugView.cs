
using UnityEngine;
using Jareel.Unity;
using System;

namespace Game
{
	/// <summary>
	/// Special view used 
	/// </summary>
	public class InventoryDebugView : MonoStateSubscriber<InventoryState, InventoryUIState, SessionState>
	{
		#region Fields

		/// <summary>
		/// The root of this view
		/// </summary>
		[SerializeField] private GameObject m_viewRoot;

		/// <summary>
		/// Repository of all available items
		/// </summary>
		[SerializeField] private InventoryRepository m_items;

		/// <summary>
		/// Contains the buttons for standard items
		/// </summary>
		[SerializeField] private ComponentCache m_itemButtons;

		/// <summary>
		/// Contains the buttons for potion items
		/// </summary>
		[SerializeField] private ComponentCache m_potionButtons;

		#endregion

		/// <summary>
		/// Every time the state updates, see if this view should be visible
		/// </summary>
		/// <param name="state1">The state of the player's inventory</param>
		/// <param name="state2">The state of the inventory UI</param>
        /// <param name="state3">The state of the player's session</param>
		protected override void OnStateChanged(InventoryState state1, InventoryUIState state2, SessionState state3)
		{
			bool open = state2.Open && state3.DebugEnabled;

			m_viewRoot.gameObject.SetActive(open);

			if (open) {
				RenderDebugButtons(m_itemButtons, m_items.Items, slot => { slot.OnSlotClicked += AddStandardItem; });
				RenderDebugButtons(m_potionButtons, m_items.Potions, slot => { slot.OnSlotClicked += AddPotion; });
			}
		}

		/// <summary>
		/// Renders a set of debug buttons. Any newly created buttons will be used
		/// to executed the given onNewSlot function
		/// </summary>
		/// <param name="root">The cache to generate buttons with</param>
		/// <param name="items">The items to generate buttons for</param>
		/// <param name="onNewSlot">Executed every time a new slot is created</param>
		private void RenderDebugButtons(ComponentCache root, InventoryItem[] items, Action<BagSlotView> onNewSlot)
		{
			var views = root.Activate(items.Length, onNewSlot);

			for (int i = 0; i < views.Length; ++i) {
				views[i].Render(items[i], -1);
			}
		}

		#region Events

		/// <summary>
		/// Fires an event to add the given standard item to the first available slot in the player's inventory
		/// </summary>
		/// <param name="item">The item that will be added</param>
		/// <param name="slot">Not used</param>
		private void AddStandardItem(InventoryItem item, int slot)
		{
			slot = State1.MainBag.IndexOf(null);

			if (slot >= 0) {
				Events.Execute(InventoryEvent.SetItem, item.ID, InventoryBag.Main, slot);
			}
		}

		/// <summary>
		/// Fires an event to add the given potion to the first available slot in the player's inventory
		/// </summary>
		/// <param name="item">The potion that will be added</param>
		/// <param name="slot">Not used</param>
		private void AddPotion(InventoryItem potion, int slot)
		{
			slot = State1.Potions.IndexOf(null);

			if (slot >= 0) {
				Events.Execute(InventoryEvent.SetItem, potion.ID, InventoryBag.Potions, slot);
			}
		}

		#endregion
	}
}
