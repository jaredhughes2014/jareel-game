
using Jareel;

namespace Game
{
    /// <summary>
    /// Events that can be executed to change the player's state
    /// </summary>
    public enum PlayerStatsEvent
    {
        IncreaseStat,
        DecreaseStat,
    }

    /// <summary>
    /// Contains the state of the player's stats
    /// </summary>
    [StateContainer("stats")]
    public class PlayerStatsState : State
    {
        #region Constants

        // Primary stats
        public const string StrengthName = "Strength";
        public const string DexterityName = "Dexterity";
        public const string IntellectName = "Intellect";
        public const string SpiritName = "Spirit";

        //Defensive stats
        public const string HealthName = "Health";
        public const string ArmorName = "Armor";
        public const string ResistanceName = "Resistance";


        #endregion

        #region State Data

        /// <summary>
        /// The player's maximum health
        /// </summary>
        [StateData("health")] public int MaxHealth { get; set; }

        /// <summary>
        /// The player's armor value
        /// </summary>
        [StateData("armor")] public int Armor { get; set; }

        /// <summary>
        /// The player's spell resistance
        /// </summary>
        [StateData("resistance")] public int Resistance { get; set; }

        /// <summary>
        /// The player's spell resistance
        /// </summary>
        [StateData("strength")] public int Strength { get; set; }

        /// <summary>
        /// The player's spell resistance
        /// </summary>
        [StateData("dexterity")] public int Dexterity { get; set; }

        /// <summary>
        /// The player's spell resistance
        /// </summary>
        [StateData("intellect")] public int Intellect { get; set; }

        /// <summary>
        /// The player's spell resistance
        /// </summary>
        [StateData("spirit")] public int Spirit { get; set; }

        #endregion
    }

    /// <summary>
    /// Controls changes and copying of the player's stat state
    /// </summary>
    public class PlayerStatsController : StateController<PlayerStatsState>
    {
        #region Event Listeners

        /// <summary>
        /// Increases the value of the given stat by the given value
        /// </summary>
        /// <param name="stat">Stat to increase</param>
        /// <param name="value">Amount to increase the stat</param>
        [EventListener(PlayerStatsEvent.IncreaseStat)]
        private void IncreaseStat(string stat, int value)
        {
            DistributeStatChange(stat, value);
        }

        /// <summary>
        /// Decreases the value of the given stat by the given value
        /// </summary>
        /// <param name="stat">Stat to increase</param>
        /// <param name="value">Amount to decrease the stat</param>
        [EventListener(PlayerStatsEvent.IncreaseStat)]
        private void DecreaseStat(string stat, int value)
        {
            DistributeStatChange(stat, -value);
        }

        /// <summary>
        /// Distributes a change to the given stat. Provide a negative value to decrease a stat
        /// </summary>
        /// <param name="stat">The stat to increase</param>
        /// <param name="value">The amount to change the stat by</param>
        private void DistributeStatChange(string stat, int value)
        {
            switch (stat) {
                case (PlayerStatsState.HealthName):
                    State.MaxHealth += value;
                    break;

                case (PlayerStatsState.ArmorName):
                    State.Armor += value;
                    break;

                case (PlayerStatsState.ResistanceName):
                    State.Resistance += value;
                    break;

                case (PlayerStatsState.StrengthName):
                    State.Strength += value;
                    break;

                case (PlayerStatsState.DexterityName):
                    State.MaxHealth += value;
                    break;

                case (PlayerStatsState.IntellectName):
                    State.MaxHealth += value;
                    break;

                case (PlayerStatsState.SpiritName):
                    State.MaxHealth += value;
                    break;
            }
        }

        #endregion

        /// <summary>
        /// Creates a deep copy of the player's stats state
        /// </summary>
        /// <returns>Deep copy of the player's stats</returns>
        public override PlayerStatsState CloneState()
        {
            return new PlayerStatsState() {
                MaxHealth = State.MaxHealth,
                Armor = State.Armor,
                Resistance = State.Resistance,
                Strength = State.Strength,
                Dexterity = State.Dexterity,
                Intellect = State.Intellect,
                Spirit = State.Spirit
            };
        }
    }
}