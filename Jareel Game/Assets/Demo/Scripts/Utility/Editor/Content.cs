using UnityEngine;
using UnityEditor;

namespace Game
{
	/// <summary>
	/// Defines all the creator items
	/// </summary>
	public static class Content
	{
		private const string ContentPath = "Assets/Create/Content/";


		[MenuItem(ContentPath + "MapData")]
		public static void CreateMapData()
		{
			SOCreator.CreateAsset<MapData>();
		}

		[MenuItem(ContentPath + "MapRepository")]
		public static void CreateMapRepository()
		{
			SOCreator.CreateAsset<MapRepository>();
		}
	}
}