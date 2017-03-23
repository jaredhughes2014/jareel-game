using UnityEngine;
using Jareel.Unity;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
	/// <summary>
	/// Renders the visuals of the player's inventory
	/// </summary>
	public class InventoryView : MonoStateSubscriber<InventoryState, InventoryUIState>
	{
		#region Fields

		/// <summary>
		/// The root of the inventory view
		/// </summary>
		[SerializeField] private GameObject m_viewRoot;

		/// <summary>
		/// Set of all inventory items
		/// </summary>
		[SerializeField] private InventoryRepository m_items;

		/// <summary>
		/// The root of the open bag
		/// </summary>
		[SerializeField] private ComponentCache m_activeBagRoot;

		/// <summary>
		/// The root of  inventory buttons
		/// </summary>
		[SerializeField] private GameObject m_buttonRoot;

		#endregion

		#region Updates

		/// <summary>
		/// Every time the state changes, check to see if the view should still be open and update the items
		/// displayed in the view
		/// </summary>
		/// <param name="inventory">The state of the player's inventory</param>
		/// <param name="ui">The state of the UI</param>
		protected override void OnStateChanged(InventoryState inventory, InventoryUIState ui)
		{
			bool open = ui.Open;
			m_viewRoot.SetActive(open);

			if (open) {
				if (string.IsNullOrEmpty(ui.OpenBag)) {
					ActivateSelectionButtons();
				}
				else {
					OpenBag(ui.OpenBag);
				}
			}
		}

		/// <summary>
		/// Determine which bag to open based on the given bags
		/// </summary>
		/// <param name="bag">The name of the bag to open</param>
		private void OpenBag(string bag)
		{
			switch (bag) {
				case (InventoryUIState.MainBagName):
					RenderBag(m_activeBagRoot, State1.MainBag);
					break;

				case (InventoryUIState.PotionsBagName):
					RenderBag(m_activeBagRoot, State1.Potions);
					break;

				default: break;
			}
		}

		/// <summary>
		/// Renders the selection buttons and disables the bag root
		/// </summary>
		private void ActivateSelectionButtons()
		{
			m_buttonRoot.gameObject.SetActive(true);
			m_activeBagRoot.gameObject.SetActive(false);
		}

		/// <summary>
		/// Renders a bag using a component cache and the list of item IDs that are expected
		/// to be rendered
		/// </summary>
		/// <param name="bag">Parent of the bag slots</param>
		/// <param name="itemIDs">IDs of the items to render</param>
		private void RenderBag(ComponentCache bag, List<string> itemIDs)
		{
			m_activeBagRoot.gameObject.SetActive(true);
			m_buttonRoot.gameObject.SetActive(false);

			var slots = bag.Activate<BagSlotView>(itemIDs.Count, slot => {
				slot.OnSlotClicked += SelectItem;
			});

			var items = itemIDs.Select(p => string.IsNullOrEmpty(p) ? null : m_items.AllItems.First(q => q.ID == p)).ToArray();

			for (int i = 0; i < itemIDs.Count; ++i) {
				slots[i].Render(items[i], i);
			}
		}

        #endregion

        #region Events

        /// <summary>
        /// Closes the player's inventory
        /// </summary>
        public void CloseInventory()
        {
			if (State2.SelectedSlot >= 0) {
				Events.ExecuteStrict(InventoryUIEvent.CloseItem);
			}
			if (!string.IsNullOrEmpty(State2.OpenBag)) {
				Events.ExecuteStrict(InventoryUIEvent.CloseBag);
			}
			else {
				Events.ExecuteStrict(UIEvent.SetInventoryOpen, false);
			}
        }

		/// <summary>
		/// Event fired to open the main bag
		/// </summary>
		public void OpenMainBag()
		{
			Events.ExecuteStrict(InventoryUIEvent.OpenBag, InventoryUIState.MainBagName);
		}

		/// <summary>
		/// Event fired to open the potion bag
		/// </summary>
		public void OpenPotionBag()
		{
			Events.ExecuteStrict(InventoryUIEvent.OpenBag, InventoryUIState.PotionsBagName);
		}

		/// <summary>
		/// Selects the item slot given unless the item corresponding to that slot is null
		/// </summary>
		/// <param name="item">The item contained at the given slot. Null for no items</param>
		/// <param name="slot">The slot clicked</param>
		private void SelectItem(InventoryItem item, int slot)
		{
			if (item != null) {
				Events.ExecuteStrict(InventoryUIEvent.SelectItem, slot);
			}
			else {
				Debug.Log("No item equipped");
			}
		}

		#endregion
	}
}
