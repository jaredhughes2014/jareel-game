using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
	/// <summary>
	/// Cache which manages copies of a prefab stored as children of this object
	/// </summary>
	public class ComponentCache : MonoBehaviour
	{
		#region Fields

		/// <summary>
		/// The component to generate copies of
		/// </summary>
		[SerializeField] private GameObject m_prefab;

		/// <summary>
		/// The components stored in this cache
		/// </summary>
		private List<GameObject> m_components = new List<GameObject>();

		#endregion

		/// <summary>
		/// Activates the given number of copies of the prefab and returns them. If there are more
		/// than the given count of copies available, the extra copies will have their game objects
		/// deactivated.
		/// 
		/// If fewer than the given count of copies exist, new copies will be created
		/// </summary>
		/// <param name="count">The number of copies to return</param>
		/// <param name="onCreated">Optional action to execute on newly created game objects</param>
		/// <returns>All components that were activated</returns>
		public GameObject[] Activate(int count, Action<GameObject> onCreated = null)
		{
			while (m_components.Count < count) {
				var obj = Instantiate(m_prefab, transform);
				m_components.Add(obj);

				if (onCreated != null) onCreated(obj);
			}

			int i;
			var components = new GameObject[count];

			for (i = 0; i < count; ++i) {
				var component = m_components[i];
				component.gameObject.SetActive(true);
				components[i] = component;
			}

			for (; i < m_components.Count; ++i) {
				m_components[i].gameObject.SetActive(false);
			}

			return components;
		}

		/// <summary>
		/// Activates the same way as the GameObject activate and then gets the components off of each
		/// returned object
		/// </summary>
		/// <typeparam name="T">The type of component to activate</typeparam>
		/// <param name="count">The number of components to activate</param>
		/// <param name="onCreated">Optional action executed every time an item is created</param>
		/// <returns>All of the selected components</returns>
		public T[] Activate<T>(int count, Action<T> onCreated = null) where T : Component
		{
			if (onCreated == null) {
				return Activate(count).Select(p => p.GetComponent<T>()).ToArray();
			}
			else {
				return Activate(count, obj => { onCreated(obj.GetComponent<T>()); }).Select(p => p.GetComponent<T>()).ToArray();
			}
		}
	}
}
