using UnityEngine;
using Jareel.Unity;
using UnityEngine.UI;

namespace Game
{
    /// <summary>
    /// Controls rendering the character sheet
    /// </summary>
    public class CharacterSheetView : MonoStateSubscriber<CharacterSheetState, CharacterState, PlayerStatsState>
    {
        #region Fields

        /// <summary>
        /// The root of the visual components
        /// </summary>
        [SerializeField] private GameObject m_viewRoot;

        /// <summary>
        /// Root of the player's stat view
        /// </summary>
        [SerializeField] private ComponentCache m_statsRoot;

        /// <summary>
        /// Renders the name of the character
        /// </summary>
        [SerializeField] private Text m_nameLabel;

        #endregion

        /// <summary>
        /// Any time a state updates, update this view to reflect the new state
        /// </summary>
        /// <param name="ui">The state of the character sheet UI</param>
        /// <param name="character">The state of the player's character</param>
        /// <param name="stats">The state of the player's stats</param>
        protected override void OnStateChanged(CharacterSheetState ui, CharacterState character, PlayerStatsState stats)
        {
            m_viewRoot.gameObject.SetActive(ui.Open);

            if (ui.Open) {
                m_nameLabel.text = character.CharacterName;
            }
        }

        #region Events

        /// <summary>
        /// Closes this panel
        /// </summary>
        public void Close()
        {
            Events.Execute(UIEvent.CloseActivePanel);
        }

        #endregion
    }
}
