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
            var last = state.ActionHistory;

			if (string.IsNullOrEmpty(last)) {
				m_actionImage.color = Color.black;
			}
            else {
                m_actionImage.color = GetActionIndicatorColor(last);
            }

		}

        /// <summary>
        /// Gets the color to set the action image based on the last action performed
        /// </summary>
        /// <param name="last">The last action performed by the user</param>
        /// <returns>The color to set the action image</returns>
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

        #region Events

        /// <summary>
        /// Executes the first action event
        /// </summary>
        public void UseAction1()
        {
            Events.Execute(ActionEvent.UseAction1);
        }

        /// <summary>
        /// Executes the second action event
        /// </summary>
        public void UseAction2()
        {
            Events.Execute(ActionEvent.UseAction2);
        }

        /// <summary>
        /// Executes the third action event
        /// </summary>
        public void UseAction3()
        {
            Events.Execute(ActionEvent.UseAction3);
        }

        /// <summary>
        /// Executes the fourth action event
        /// </summary>
        public void UseAction4()
        {
            Events.Execute(ActionEvent.UseAction4);
        }

        #endregion
    }
}
