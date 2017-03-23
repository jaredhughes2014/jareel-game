
using UnityEngine;
using System.Linq;

namespace Game
{
    /// <summary>
    /// Contains all inventory items defined for this game
    /// </summary>
    public class InventoryRepository : GameContent
    {
        /// <summary>
        /// All basic items available
        /// </summary>
        [SerializeField] private InventoryItem[] m_items;
        public InventoryItem[] Items { get { return m_items; } }

		/// <summary>
		/// All potion items available
		/// </summary>
		[SerializeField] private InventoryItem[] m_potions;
		public InventoryItem[] Potions { get { return m_potions; } }

		/// <summary>
		/// Combines all items into a single array
		/// </summary>
		public InventoryItem[] AllItems { get { return Items.Union(Potions).ToArray(); } }
	}
}
