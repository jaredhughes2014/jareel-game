
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Contains all inventory items defined for this game
    /// </summary>
    public class InventoryRepository : GameContent
    {
        /// <summary>
        /// All inventory items available
        /// </summary>
        [SerializeField] private InventoryItem[] m_inventory;
        public InventoryItem[] Inventory { get { return m_inventory; } }
    }
}
