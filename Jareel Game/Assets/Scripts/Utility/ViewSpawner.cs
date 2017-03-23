using UnityEngine;

namespace Game
{
    /// <summary>
    /// Helpful fun class for spawning views into the scene. Once the view has spawned, this behaviour
    /// will destroy itself if there are other spawners attached to the object, or the entire object
    /// if this is the last spawner
    /// </summary>
    public class ViewSpawner : MonoBehaviour
    {
        /// <summary>
        /// The view to spawn
        /// </summary>
        [SerializeField] private GameObject[] m_prefabs;

        /// <summary>
        /// Instantiate then self-destruct
        /// </summary>
        private void Start()
        {
            for (int i = 0; i < m_prefabs.Length; ++i) {
                var view = Instantiate(m_prefabs[i], transform.parent);

                view.transform.localPosition = Vector3.zero;
                view.transform.localScale = Vector3.one;
                view.name = i.ToString() + '_' + view.name;
            }

            var spawners = gameObject.GetComponents<ViewSpawner>();

            if (spawners.Length == 0) {
                Destroy(gameObject);
            }
            else {
                Destroy(this);
            }
        }
    }
}