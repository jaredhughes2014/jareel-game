using Jareel;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    /// <summary>
    /// The set of events that can be exeucted to change the inventory state
    /// </summary>
    public enum InventoryEvent
    {
        SetItem,
        RemoveItem
    }

    /// <summary>
    /// Collection of bags available in the state
    /// </summary>
    public enum InventoryBag
    {
        Main,
        Potions
    }

    /// <summary>
    /// Contains the state of the player's inventory
    /// </summary>
    [StateContainer("inventory")]
    public class InventoryState : State
    {
        #region Constants

        /// <summary>
        /// The default capacity of the main bag
        /// </summary>
        public const int DefaultCapacityMain = 16;

        /// <summary>
        /// The default capacity of the potions bag
        /// </summary>
        public const int DefaultCapacityPotions = 10;

        #endregion

        #region StateData

        /// <summary>
        /// Contains the item IDs of the items in the main bag
        /// </summary>
        [StateData("mainBag")] public List<string> MainBag { get; set; }

        /// <summary>
        /// Contains the item IDs of the items in the potion bag
        /// </summary>
        [StateData("potions")] public List<string> Potions { get; set; }

        #endregion

        /// <summary>
        /// Creates a new blank inventory state
        /// </summary>
        public InventoryState()
        {
            MainBag = new List<string>();
            for (int i = 0; i < DefaultCapacityMain; ++i) {
                MainBag.Add(null);
            }
            
            Potions = new List<string>();
            for (int i = 0; i < DefaultCapacityPotions; ++i) {
                Potions.Add(null);
            }
        }
    }

    /// <summary>
    /// Controls cloning and modification of the inventory state
    /// </summary>
    public class InventoryController : StateController<InventoryState>
    {
        #region Event Listeners

        /// <summary>
        /// Sets the item in the given bag at the given slot to be the item with the given ID
        /// </summary>
        /// <param name="id">ID of the item to use</param>
        /// <param name="bag">The bag to place the item in</param>
        /// <param name="slot">The slot to place the item in</param>
        [EventListener(InventoryEvent.SetItem)]
        private void SetItem(string id, InventoryBag bag, int slot)
        {
            GetBag(bag)[slot] = id;
        }

        /// <summary>
        /// Removes the item in the given bag at the given slot.
        /// </summary>
        /// <param name="bag">The bag to remove the item from</param>
        /// <param name="slot">The slot to remove an item from</param>
        [EventListener(InventoryEvent.RemoveItem)]
        private void UseItem(InventoryBag bag, int slot)
        {
            GetBag(bag)[slot] = null;
        }

        /// <summary>
        /// Gets the bag list corresponding to the given bag vlaue
        /// </summary>
        /// <param name="bag">Bag value</param>
        /// <returns>List corresponding to the given bag</returns>
        private List<string> GetBag(InventoryBag bag)
        {
            switch (bag) {
                case (InventoryBag.Main): return State.MainBag;
                case (InventoryBag.Potions): return State.Potions;
                default: return null;
            }
        }

        #endregion

        /// <summary>
        /// Creates and returns a deep copy of the inventory state
        /// </summary>
        /// <returns>Deep copy of the inventory state</returns>
        public override InventoryState CloneState()
        {
            return new InventoryState() {
                MainBag = State.MainBag.ToList(),
                Potions = State.Potions.ToList()
            };
        }
    }
}