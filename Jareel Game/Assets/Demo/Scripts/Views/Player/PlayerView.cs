using System;
using Jareel.Unity;
using UnityEngine;

namespace Game
{
	public class PlayerView : MonoStateSubscriber<LocationState>
	{
		protected override void OnStateChanged(LocationState state)
		{
			Debug.Log(string.Format("Coordinates: ({0}, {1})", state.X, state.Y));
		}
	}
}
