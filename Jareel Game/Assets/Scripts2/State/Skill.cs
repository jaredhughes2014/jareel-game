using Jareel;

namespace JareelUnity
{
    /// <summary>
    /// The skill state contains data about the user's currently set
    /// skills.
    /// </summary>
    [StateContainer("skills")]
    public class SkillState : State
    {
        #region State Data

        /// <summary>
        /// The ID of the user's primary skill.
        /// </summary>
        [StateData("primary")] public string PrimaryID { get; set; }

        /// <summary>
        /// The ID of the user's combo skill
        /// </summary>
        [StateData("combo")] public string ComboID { get; set; }

        /// <summary>
        /// The ID of the user's secondary skill
        /// </summary>
        [StateData("secondary")] public string SecondaryID { get; set; }

        /// <summary>
        /// The ID of the user's special skill
        /// </summary>
        [StateData("special")] public string SpecialID { get; set; }

        #endregion

        #region Setup

        /// <summary>
        /// Creates a new skill state
        /// </summary>
        public SkillState()
        {
            PrimaryID = "";
            ComboID = "";
            SecondaryID = "";
            SpecialID = "";
        }

        #endregion
    }

    /// <summary>
    /// Controls changes made to the skill state
    /// </summary>
    public class SkillController : StateController<SkillState>
    {
        /// <summary>
        /// Creates and returns a deep copy of the skill state
        /// </summary>
        /// <returns>Deep copy of the skill state</returns>
        public override SkillState CloneState()
        {
            return new SkillState() {
                PrimaryID = State.PrimaryID,
                ComboID = State.ComboID,
                SecondaryID = State.SecondaryID,
                SpecialID = State.SpecialID
            };
        }
    }
}
