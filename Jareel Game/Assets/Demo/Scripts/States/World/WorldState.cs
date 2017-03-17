using Jareel;

namespace Game
{
	/// <summary>
	/// Set of events that can be executed on the world controller
	/// </summary>
	public enum WorldEvents
	{
		SetMap
	}

	/// <summary>
	/// Contains data about the world the player is in
	/// </summary>
	[StateContainer("world")]
	public class WorldState : State
	{
		#region State Data

		/// <summary>
		/// The name of the map the user has loaded
		/// </summary>
		[StateData("map")] public string MapName { get; set; }

		#endregion

		public WorldState()
		{
			MapName = "";
		}
	}

	/// <summary>
	/// Controls modifications to the world state
	/// </summary>
	public class WorldController : StateController<WorldState>
	{
		#region Event Listeners

		/// <summary>
		/// Changes the name of the map to the provided map name. This listener should be strict
		/// </summary>
		/// <param name="mapName">The name of the map to set</param>
		[EventListener(WorldEvents.SetMap)]
		private void SetMap(string mapName)
		{
			State.MapName = mapName;
		}

		#endregion

		/// <summary>
		/// Creates a deep copy of the world state
		/// </summary>
		/// <returns>Deep copy of the world state</returns>
		public override WorldState CloneState()
		{
			return new WorldState() {
				MapName = State.MapName
			};
		}
	}
}
