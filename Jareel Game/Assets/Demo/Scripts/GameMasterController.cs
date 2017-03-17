using Jareel;

namespace Game
{
	/// <summary>
	/// Connects all state controllers for the game into a single 
	/// </summary>
	public class GameMasterController : MasterController
	{
		protected override void UseControllers()
		{
			Use<WorldState, WorldController>();
			Use<LocationState, LocationController>();
		}
	}
}
