using UnityEngine;
using Jareel;

namespace JareelUnity
{
    /// <summary>
    /// Control boards have two primary functions: Create your master controller
    /// and connect all subscribers to that master controller
    /// </summary>
    public abstract class ControlBoard<T> : MonoBehaviour where T : MasterController, new()
    {
        #region Fields

        /// <summary>
        /// The subscribers this will manage
        /// </summary>
        [SerializeField] private MonoStateSubscriber[] m_subscribers;

        /// <summary>
        /// The master controller this accesses
        /// </summary>
        protected T m_master;

        /// <summary>
        /// Used to perform state updates on the master controller
        /// </summary>
        private SequentialExecutor m_executor;

        #endregion

        #region Setup

        /// <summary>
        /// Initializes all subscribers and creates your master controller
        /// </summary>
        protected virtual void Start()
        {
            m_master = new T();
            m_executor = new SequentialExecutor(m_master);

            foreach (var subscriber in m_subscribers) {
                subscriber.ExtendFromMaster(m_master);
            }
        }

        /// <summary>
        /// Disconnects all subscribers from the master controller
        /// </summary>
        protected virtual void OnDestroy()
        {
            foreach (var subscriber in m_subscribers) {
                m_master.DisconnectSubscriber(subscriber.AbstractSubscriber);
            }
        }

        /// <summary>
        /// Updates the master controller
        /// </summary>
        protected virtual void Update()
        {
            m_executor.Execute();
        }

        #endregion
    }
}
