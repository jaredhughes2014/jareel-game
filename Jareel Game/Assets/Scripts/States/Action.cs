using System.Collections.Generic;
using Jareel;
using System.Linq;

namespace Game
{
	/// <summary>
	/// All events that can be used to change the action state
	/// </summary>
	public enum ActionEvent
	{
		UseAction1,
		UseAction2,
		UseAction3,
		UseAction4
	}

	/// <summary>
	/// The state of the actions performed by the user
	/// </summary>
	[StateContainer("actions")]
	public class ActionState : State
	{
		#region Constants

		// Action string constants
		public const string Action1String = "action1";
		public const string Action2String = "action2";
		public const string Action3String = "action3";
		public const string Action4String = "action4";

		#endregion

		#region State Data

		/// <summary>
		/// The history of actions performed by the user
		/// </summary>
		[StateData("history")] public List<string> ActionHistory { get; set; }

		#endregion

		/// <summary>
		/// Creates a new Action state
		/// </summary>
		public ActionState()
		{
            ActionHistory = new List<string>();
		}
	}

	/// <summary>
	/// Controls modification and cloning of the action state
	/// </summary>
	public class ActionController : StateController<ActionState>
	{
		/// <summary>
		/// Registers that a user performed their first action
		/// </summary>
		[EventListener(ActionEvent.UseAction1)]
		private void RegisterAction1()
		{
			State.ActionHistory.Add(ActionState.Action1String);
		}

		/// <summary>
		/// Registers that a user performed their second action
		/// </summary>
		[EventListener(ActionEvent.UseAction2)]
		private void RegisterAction2()
		{
			State.ActionHistory.Add(ActionState.Action2String);
		}

		/// <summary>
		/// Registers that a user performed their third action
		/// </summary>
		[EventListener(ActionEvent.UseAction3)]
		private void RegisterAction3()
		{
			State.ActionHistory.Add(ActionState.Action3String);
		}

		/// <summary>
		/// Registers that a user performed their fourth action
		/// </summary>
		[EventListener(ActionEvent.UseAction4)]
		private void RegisterAction4()
		{
			State.ActionHistory.Add(ActionState.Action4String);
		}

		/// <summary>
		/// Creates a deep copy of the action state
		/// </summary>
		/// <returns>Deep copy of the action state</returns>
		public override ActionState CloneState()
		{
            return new ActionState() {
                ActionHistory = State.ActionHistory.Select(p => p).ToList()
			};
		}
	}
}
