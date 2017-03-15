using System;
using Jareel;

namespace JareelUnity
{
    /// <summary>
    /// Complex state object for an inventory item.
    /// </summary>
    public class InventorySlot : StateObject, ICopyable<InventorySlot>
    {
        #region State Data

        /// <summary>
        /// The ID of the item
        /// </summary>
        [StateData("id")] public string ID { get; set; }

        #endregion

        #region Setup

        /// <summary>
        /// Primary constructor. Sets the ID of the item in this slot
        /// </summary>
        /// <param name="id">The ID of the item</param>
        public InventorySlot(string id)
        {
            ID = id;
        }

        /// <summary>
        /// Default constructor used for serialization
        /// </summary>
        public InventorySlot() : this("") { }

        /// <summary>
        /// Creates a deep copy of this inventory slot
        /// </summary>
        /// <returns>Deep copy of this slot</returns>
        public InventorySlot Copy()
        {
            return new InventorySlot(ID);
        }

        #endregion
    }
}
