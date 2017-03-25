using Jareel;

namespace Game
{
    /// <summary>
    /// Events that can be executed to change the character state
    /// </summary>
    public enum CharacterEvent
    {
        SetName
    }

    /// <summary>
    /// Contains the state of the player's character
    /// </summary>
    [StateContainer("character")]
    public class CharacterState : State
    {
        #region State Data

        /// <summary>
        /// The name of the character
        /// </summary>
        [StateData] public string CharacterName { get; set; }

        #endregion

        public CharacterState()
        {
            CharacterName = "DefaultName";
        }
    }

    /// <summary>
    /// Controls cloning and modifying the character state
    /// </summary>
    public class CharacterController : StateController<CharacterState>
    {
        #region Event Listeners

        /// <summary>
        /// Sets the name of the player's character
        /// </summary>
        /// <param name="name">The name to set</param>
        [EventListener(CharacterEvent.SetName)]
        private void SetName(string name)
        {
            State.CharacterName = name;
        }

        #endregion

        /// <summary>
        /// Creates a deep copy of the character state
        /// </summary>
        /// <returns>Deep copy of the character state</returns>
        public override CharacterState CloneState()
        {
            return new CharacterState() {
                CharacterName = State.CharacterName
            };
        }
    }
}
