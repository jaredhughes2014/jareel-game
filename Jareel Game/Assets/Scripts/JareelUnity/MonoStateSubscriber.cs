using UnityEngine;
using System;

namespace Jareel.Unity
{
	/// <summary>
	/// Mono state subscribers connect to a master controller to provide access to state
	/// data and access to the master controller's event manager.
	/// 
	/// While mono state subscribers can fire events, they CANNOT listen for events.
	/// </summary>
	public abstract class MonoStateSubscriber<S> : MonoBehaviour where S : State, new()
	{
		#region Properties

		/// <summary>
		/// Allows firing of events
		/// </summary>
		public EventManager Events { get; private set; }

		/// <summary>
		/// Provides access to the state
		/// </summary>
		private StateSubscriber<S> m_subscriber;

		/// <summary>
		/// The state this is subscribed to. This will not be set until the first state change
		/// has been registered
		/// </summary>
		protected S State { get; private set; }

		/// <summary>
		/// If true, this will not receive any state updates
		/// </summary>
		protected bool Blocked { get; private set; }

		#endregion

		#region Mono Fields

		/// <summary>
		/// The master controller this subscribes to. If this field is not set, the subscriber will
		/// ascend up the heirarchy to try to set this field
		/// </summary>
		[SerializeField] private MonoMasterController m_master;

		#endregion

		#region Setup

		/// <summary>
		/// Connects this subscriber to the master controller. If the master is not set, this is
		/// where the subscriber will attempt to connect by moving up the heirarchy
		/// 
		/// If overriding, the base function must be called, or else this will break horribly
		/// </summary>
		protected virtual void Start()
		{
			var transform = this.transform;

			while (m_master == null && transform != null) {
				transform = transform.parent;
				m_master = transform.gameObject.GetComponent<MonoMasterController>();
			}

			if (m_master == null) {
				Debug.LogError("Unable to connect to a master controller. Aborting...", this);
				Destroy(this);
			}
			else {
				ConnectToMaster();
			}
		}

		/// <summary>
		/// Executes to spawn the subscriber
		/// </summary>
		internal void ConnectToMaster()
		{
			try {
				m_subscriber = m_master.AbstractMaster.SpawnSubscriber<S>();
				Events = m_master.AbstractMaster.Events;
			}
			catch (ArgumentException e) {
				Debug.LogError(e);
				Debug.LogError("Unable to connect subscriber. Aborting...", this);
				Destroy(this);
			}
		}

		/// <summary>
		/// Disconnects this subscriber from the master
		/// 
		/// If overriding, the base function must be called, or this will break your master controller
		/// </summary>
		protected virtual void OnDestroy()
		{
			m_master.AbstractMaster.DisconnectSubscriber(m_subscriber);
		}

		#endregion

		#region Updates

		/// <summary>
		/// Checks for updates to the state. If an update exists, OnStateChanged will execute.
		/// 
		/// If overriding, the base function must be called or your subscriber will never have
		/// access to the state
		/// </summary>
		protected virtual void Update()
		{
			CheckForStateChange();
		}

		/// <summary>
		/// If not blocked, checks if the subscribed state has updated. If it has, calls
		/// OnStateChanged
		/// </summary>
		private void CheckForStateChange()
		{
			if (!Blocked && m_subscriber.Updated) {
				State = m_subscriber.State;
				OnStateChanged(State);
			}
		}

		/// <summary>
		/// Executed every time the state changes. This is the most recent copy
		/// of your state. Note that this is a copy and changing it will not change
		/// the state in the master controller
		/// </summary>
		/// <param name="state">Deep copy of the state this subscriber is subscribed to</param>
		protected abstract void OnStateChanged(S state);

		#endregion

		#region Blocking

		/// <summary>
		/// Prevents this subscriber from receiving state updates
		/// </summary>
		protected void Block()
		{
			Blocked = true;
		}

		/// <summary>
		/// Allows this subscriber to receive state updates again. If updateNow is true
		/// and an update occurred while this was blocked, a state change will be registered immediately.
		/// 
		/// Note that this change will only be registered if a state change has occurred. This
		/// cannot be used to force a state change notification to occur again
		/// </summary>
		/// <param name="updateNow">If true, executes a state change if one has occurred</param>
		protected void Unblock(bool updateNow = true)
		{
			Blocked = false;
			if (updateNow) {
				CheckForStateChange();
			}
		}

		#endregion
	}
}
