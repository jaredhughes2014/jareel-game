using UnityEditor;

namespace Game
{
    /// <summary>
    /// Defines all of the content creation functions for this game
    /// </summary>
    public static class Content
    {
        /// <summary>
        /// The base path for creating content
        /// </summary>
        public const string ContentPath = "/Assets/Create/Content/";

        //Inventory

        [MenuItem(ContentPath + "Inventory Item")]
        public static void CreateInventoryItem()
        {
            SOCreator.CreateAsset<InventoryItem>();
        }

        [MenuItem(ContentPath + "Inventory Item")]
        public static void CreateInventoryRepository()
        {
            SOCreator.CreateAsset<InventoryRepository>();
        }
    }
}
