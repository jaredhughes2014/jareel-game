using UnityEngine;

namespace Game
{
    /// <summary>
    /// Represents a serialized asset usable by the game
    /// </summary>
    public class GameContent : ScriptableObject
    {
        /// <summary>
        /// The ID of this content item
        /// </summary>
        [SerializeField] private string m_id;
        public string ID { get { return m_id; } }

        /// <summary>
        /// Instantiates a new content item and automatically generates an ID number for that content item
        /// </summary>
        protected virtual void OnEnable()
        {
            if (string.IsNullOrEmpty(m_id)) {
                m_id = GetType().Name + '_' + System.Guid.NewGuid().ToString();
            }
        }
    }
}
