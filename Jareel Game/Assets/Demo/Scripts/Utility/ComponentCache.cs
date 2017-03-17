using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	/// <summary>
	/// Caches instances of components
	/// </summary>
	public class ComponentCache<T> where T : Component
	{
		#region Properties

		/// <summary>
		/// The components currently managed by this cache
		/// </summary>
		private List<T> m_components;

		/// <summary>
		/// The parent of the components
		/// </summary>
		private GameObject m_parent;

		/// <summary>
		/// The prefab to use for instantiation
		/// </summary>
		private T m_prefab;

		/// <summary>
		/// Used for naming the new components
		/// </summary>
		private string m_typeName;

		#endregion

		/// <summary>
		/// Creates a new component cache
		/// </summary>
		public ComponentCache(GameObject parent, T prefab)
		{
			m_parent = parent;
			m_prefab = prefab;

			m_components = new List<T>();
			m_typeName = typeof(T).Name;
		}

		/// <summary>
		/// Insures that at least the given count of components exists
		/// in this cache
		/// </summary>
		public void CacheAtLeast(int count)
		{
			int required = count - m_components.Count;

			for (int i = 0; i < required; ++i) {
				var child = Object.Instantiate(m_prefab, m_parent.transform);
				child.name = m_typeName + (m_components.Count + 1);
				child.gameObject.SetActive(false);

				m_components.Add(child);
			}
		}

		/// <summary>
		/// Activates and returns the given number of copies. Deactivates all other copies
		/// </summary>
		/// <param name="count">The number to activate</param>
		/// <returns>Array containing all of the activated copies</returns>
		public T[] ActivateCopies(int count)
		{
			CacheAtLeast(count);
			var copies = new T[count];
			int i;

			for (i = 0; i < count; ++i) {
				m_components[i].gameObject.SetActive(true);
				copies[i] = m_components[i];
			}

			for (; i < m_components.Count; ++i) {
				m_components[i].gameObject.SetActive(false);
			}

			return copies;
		}
	}
}