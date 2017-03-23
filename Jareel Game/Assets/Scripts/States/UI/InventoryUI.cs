using Jareel;

namespace Game
{
	/// <summary>
	/// Contains events which can change the inventory UI
	/// </summary>
	public enum InventoryUIEvent
	{
		SelectItem,
		CloseItem,

		OpenBag,
		CloseBag,
	}

	/// <summary>
	/// Contains the current state of the inventory UI
	/// </summary>
	[StateContainer("inventoryUI")]
	public class InventoryUIState : State
	{
		#region Constants

		/// <summary>
		/// The name of the user's primary bag
		/// </summary>
		public const string MainBagName = "MainBag";

		/// <summary>
		/// The name of the bag which holds all potions
		/// </summary>
		public const string PotionsBagName = "Potions";

		#endregion

		#region State Data

		/// <summary>
		/// The name of the bag that is currently open
		/// </summary>
		[StateData] public string OpenBag { get; set; }

		/// <summary>
		/// The slot of the inventory item that is currently selected
		/// </summary>
		[StateData] public int SelectedSlot { get; set; }

		/// <summary>
		/// If false, the inventory will close
		/// </summary>
		[StateData] public bool Open { get; set; }

		#endregion

		/// <summary>
		/// Creates a new inventory UI state
		/// </summary>
		public InventoryUIState()
		{
			OpenBag = "";
			SelectedSlot = -1;
		}
	}

	/// <summary>
	/// Controls modification and cloning of the inventory UI state 
	/// </summary>
	public class InventoryUIController : StateController<InventoryUIState>
	{
		#region Event Listeners

		/// <summary>
		/// Opens the provided bag
		/// </summary>
		/// <param name="bag">The name of the bag to open</param>
		[EventListener(InventoryUIEvent.OpenBag)]
		private void OpenBag(string bag)
		{
			State.OpenBag = bag;
		}

		/// <summary>
		/// Closes the currently opened bag
		/// </summary>
		[EventListener(InventoryUIEvent.CloseBag)]
		private void CloseBag()
		{
			State.OpenBag = "";
			State.SelectedSlot = -1;
		}

		/// <summary>
		/// Selects the given inventory slot.
		/// </summary>
		/// <param name="slot">The slot to select</param>
		[EventListener(InventoryUIEvent.SelectItem)]
		private void SelectSlot(int slot)
		{
			State.SelectedSlot = slot;
		}

		/// <summary>
		/// Deselcts the currently selected inventory slot
		/// </summary>
		[EventListener(InventoryUIEvent.CloseItem)]
		private void DeselectSlot()
		{
			State.SelectedSlot = -1;
		}

		#endregion

		#region State Adapters

		/// <summary>
		/// Adapts the UI state to this state.
		/// </summary>
		/// <param name="ui">Copy of the UI state</param>
		[StateAdapter]
		private void AdaptUIState(UIState ui)
		{
			State.Open = ui.InventoryOpen;
			if (!State.Open) {
				ResetState();
			}
		}

		/// <summary>
		/// Sets all state values to their defaults
		/// </summary>
		private void ResetState()
		{
			State.OpenBag = "";
			State.SelectedSlot = -1;
		}

		#endregion

		/// <summary>
		/// Creates a deep copy of the inventory UI state
		/// </summary>
		/// <returns>Deep copy of the inventory UI state</returns>
		public override InventoryUIState CloneState()
		{
			return new InventoryUIState() {
				OpenBag = State.OpenBag,
				SelectedSlot = State.SelectedSlot,
				Open = State.Open
			};
		}
	}
}