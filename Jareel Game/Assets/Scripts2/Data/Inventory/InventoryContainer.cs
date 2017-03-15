using Jareel;
using System.Collections.Generic;
using System.Linq;

namespace JareelUnity.Inventory
{
    /// <summary>
    /// Holder for items in the inventory
    /// </summary>
    public class InventoryContainer : StateObject, ICopyable<InventoryContainer>
    {
        /// <summary>
        /// The slots of this container
        /// </summary>
        [StateData("slots")] public List<InventorySlot> Slots { get; set; }

        /// <summary>
        /// The number of items that can be held in this container
        /// </summary>
        [StateData("capacity")] public int Capacity { get; set; }

        /// <summary>
        /// Creates a new inventory container
        /// </summary>
        public InventoryContainer()
        {
            Slots = new List<InventorySlot>();
        }

        /// <summary>
        /// Creates a deep copy of this inventory container
        /// </summary>
        /// <returns>Deep copy of this container</returns>
        public InventoryContainer Copy()
        {
            return new InventoryContainer() {
                Slots = Slots.Select(p => p.Copy()).ToList(),
                Capacity = Capacity
            };
        }
    }
}
