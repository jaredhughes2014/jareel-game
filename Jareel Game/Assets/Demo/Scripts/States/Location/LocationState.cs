using Jareel;

namespace Game
{
	/// <summary>
	/// Events which can be executed to change the location state
	/// </summary>
	public enum LocationEvent
	{
		SetLocation,
		WarpLocation
	}

	/// <summary>
	/// The state of the player's location
	/// </summary>
	[StateContainer("location")]
	public class LocationState : State
	{
		#region State Data
		
		/// <summary>
		/// The player's X coordinate
		/// </summary>
		[StateData("x")] public int X { get; set; }

		/// <summary>
		/// The player's Y coordinate
		/// </summary>
		[StateData("y")] public int Y { get; set; }

		/// <summary>
		/// If true, the last move the player made was a warp
		/// </summary>
		[StateData] public bool Warped { get; set; }

		#endregion
	}

	/// <summary>
	/// Controls changes to the player's location
	/// </summary>
	public class LocationController : StateController<LocationState>
	{
		#region Event Listeners

		/// <summary>
		/// Sets the player's location in the current map. The Warped property
		/// in the state will be set to false
		/// </summary>
		/// <param name="x">The player's new X coordinate</param>
		/// <param name="y">The player's new Y coordinate</param>
		[EventListener(LocationEvent.SetLocation)]
		private void SetLocation(int x, int y)
		{
			State.X = x;
			State.Y = y;
			State.Warped = false;
		}

		/// <summary>
		/// Sets the player's location in the current map. The Warped property
		/// in the state will be set to true
		/// </summary>
		/// <param name="x">The player's new X coordinate</param>
		/// <param name="y">The player's new Y coordinate</param>
		[EventListener(LocationEvent.WarpLocation)]
		private void WarpLocation(int x, int y)
		{
			State.X = x;
			State.Y = y;
			State.Warped = true;
		}

		#endregion

		/// <summary>
		/// Creates and returns a deep copy of the location state
		/// </summary>
		/// <returns>Deep copy of the location state</returns>
		public override LocationState CloneState()
		{
			return new LocationState() {
				X = State.X,
				Y = State.Y,
				Warped = State.Warped
			};
		}
	}
}
