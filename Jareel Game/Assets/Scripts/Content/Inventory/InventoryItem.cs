using UnityEngine;

namespace Game
{
    /// <summary>
    /// A potential item in the inventory
    /// </summary>
    public class InventoryItem : GameContent
    {
        /// <summary>
        /// The name of the item
        /// </summary>
        [SerializeField] private string m_name;
        public string Name { get { return m_name; } }

        /// <summary>
        /// The description of the item
        /// </summary>
        [SerializeField, TextArea] private string m_description;
        public string Description { get { return m_description; } }

		/// <summary>
		/// The sprite representing the icon of this inventory item
		/// </summary>
		[SerializeField] private Sprite m_icon;
		public Sprite Icon { get { return m_icon; } }
    }
}
