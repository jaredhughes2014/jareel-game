
using JareelUnity.Inventory;
using Jareel;

namespace JareelUnity
{
    /// <summary>
    /// The state of the user's UI
    /// </summary>
    [StateContainer("inventory")]
    public class InventoryState : State
    {
        #region Constants

        /// <summary>
        /// The default capacity of the main inventory container
        /// </summary>
        public const int DefaultMainCapcity = 10;

        /// <summary>
        /// The default capacity of the potion inventory container
        /// </summary>
        public const int DefaultPotionCapacity = 16;

        #endregion

        #region State Data

        /// <summary>
        /// The primary inventory. This holds items that don't have a specific slot
        /// </summary>
        [StateData("main")] public InventoryContainer MainInventory { get; set; }

        /// <summary>
        /// The inventory container used to store potions
        /// </summary>
        [StateData("potions")] public InventoryContainer PotionInventory { get; set; }

        #endregion

        #region Setup

        /// <summary>
        /// Initializes the inventory state
        /// </summary>
        public InventoryState()
        {
            MainInventory = new InventoryContainer() {
                Capacity = DefaultMainCapcity
            };

            PotionInventory = new InventoryContainer() {
                Capacity = DefaultPotionCapacity
            };
        }

        #endregion
    }

    public class InventoryController : StateController<InventoryState>
    {
        /// <summary>
        /// Creates a clone of the inventory state. This copy is a deep copy
        /// </summary>
        /// <returns>Deep copy of the inventory state</returns>
        public override InventoryState CloneState()
        {
            return new InventoryState() {
                MainInventory = State.MainInventory.Copy(),
                PotionInventory = State.PotionInventory.Copy()
            };
        }
    }
}
