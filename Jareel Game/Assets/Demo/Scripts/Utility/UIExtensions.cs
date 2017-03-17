using UnityEngine.UI;

namespace Game
{
	/// <summary>
	/// Library of extension functions for unity UI elements
	/// </summary>
	public static class UIExtensions
	{
		/// <summary>
		/// Easy extension to set the alpha on an image
		/// </summary>
		public static void SetAlpha(this Image img, float alpha)
		{
			var color = img.color;
			color.a = alpha;
			img.color = color;
		}
	}
}
