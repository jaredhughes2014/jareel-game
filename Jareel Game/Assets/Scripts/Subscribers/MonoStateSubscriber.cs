using Jareel;
using UnityEngine;

namespace JareelUnity
{
    /// <summary>
    /// Base class for mono subscribers. This allows for a Jareel control
    /// board to provide subscription to an abstract state
    /// </summary>
    public abstract class MonoStateSubscriber : MonoBehaviour
    {
        /// <summary>
        /// The subscriber this uses to access state
        /// </summary>
        internal AbstractStateSubscriber AbstractSubscriber { get; set; }

        /// <summary>
        /// Extends this subscriber from the given master controller. This controller
        /// is where this subscriber will get its state from
        /// </summary>
        /// <param name="master">The master controller this will extend from</param>
        internal abstract void ExtendFromMaster(MasterController master);
    }

    /// <summary>
    /// The actual monosubscriber type. This type allows you to specify what
    /// type of state you are subscribing to
    /// </summary>
    /// <typeparam name="T">The type of state this is subscribing to</typeparam>
    public abstract class MonoStateSubscriber<T> : MonoStateSubscriber where T : State
    {
        #region Properties

        /// <summary>
        /// The type-specific type subscriber
        /// </summary>
        internal StateSubscriber<T> Subscriber { get { return (StateSubscriber<T>)AbstractSubscriber; } }

        /// <summary>
        /// The state this is subscribed to. This will always be the latest version of the state
        /// </summary>
        protected T State { get { return Subscriber.State; } }

        #endregion

        #region Setup

        /// <summary>
        /// Overriden to get access to an appropriate state subscriber
        /// </summary>
        /// <param name="master">The master controller this is subscribing to</param>
        internal override sealed void ExtendFromMaster(MasterController master)
        {
            AbstractSubscriber = master.SpawnSubscriber<T>();
        }

        #endregion

        #region Frame Checks

        protected virtual void Update()
        {
            if (AbstractSubscriber.Updated) {
                OnStateChanged(Subscriber.State);
            }
        }

        /// <summary>
        /// Optional callback executed every time the state changes
        /// </summary>
        protected virtual void OnStateChanged(T newState) { }

        #endregion
    }
}