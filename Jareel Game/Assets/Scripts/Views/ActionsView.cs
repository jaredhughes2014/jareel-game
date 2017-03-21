using UnityEngine;
using UnityEngine.UI;
using Jareel.Unity;
using System.Linq;

namespace Game
{
	/// <summary>
	/// Renders the view of the user's available actions
	/// </summary>
	public class ActionsView : MonoStateSubscriber<ActionState>
	{
		#region Fields

		/// <summary>
		/// The image which changes color based on the previous action
		/// </summary>
		[SerializeField] private Image m_actionImage;

		/// <summary>
		/// The image representing the first action button
		/// </summary>
		[SerializeField] private Image m_action1Button;

		/// <summary>
		/// The image representing the second action button
		/// </summary>
		[SerializeField] private Image m_action2Button;

		/// <summary>
		/// The image representing the third action button
		/// </summary>
		[SerializeField] private Image m_action3Button;

		/// <summary>
		/// The image representing the fourth action button
		/// </summary>
		[SerializeField] private Image m_action4Button;

		#endregion

		#region Updates

		/// <summary>
		/// Every update, render the actions
		/// </summary>
		/// <param name="state">The state to render this view from</param>
		protected override void OnStateChanged(ActionState state)
		{
			var last = state.ActionHistory.LastOrDefault();

			if (string.IsNullOrEmpty(last)) {
				m_actionImage.color = Color.black;
			}


		}

		private Color GetActionIndicatorColor(string last)
		{
			if (last == null) return Color.black;

			switch (last) {
				case (ActionState.Action1String):
					return m_action1Button.color;
				case (ActionState.Action2String):
					return m_action2Button.color;
				case (ActionState.Action3String):
					return m_action3Button.color;
				case (ActionState.Action4String):
					return m_action4Button.color;
				default: return Color.white;
			}
		}

		#endregion
	}
}
