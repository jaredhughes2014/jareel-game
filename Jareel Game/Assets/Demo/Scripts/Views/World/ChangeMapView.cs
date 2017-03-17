using Jareel.Unity;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

namespace Game
{
	/// <summary>
	/// Renders the controls to change the map
	/// </summary>
	public class ChangeMapView : MonoStateSubscriber<WorldState>
	{
		#region Fields

		/// <summary>
		/// The maps this renderer works with
		/// </summary>
		[SerializeField] private MapRepository m_maps;

		/// <summary>
		/// The object under which the room tiles will be rendered
		/// </summary>
		[SerializeField] private Dropdown m_optionDropDown;

		#endregion

		/// <summary>
		/// Check to see if the map in the world state is different than the one
		/// currently rendered
		/// </summary>
		/// <param name="state">Contains data about the current state of the world</param>
		protected override void OnStateChanged(WorldState state)
		{
		}

		protected override void Start()
		{
			base.Start();

			m_optionDropDown.AddOptions(m_maps.Maps.Select(p => p.Name).ToList());
			m_optionDropDown.onValueChanged.AddListener(SelectOption);
			SelectOption(0);
		}

		#region Layout

		/// <summary>
		/// Lays out all map tiles using the specifications in the given map data
		/// and world state
		/// </summary>
		/// <param name="map">Contains the sprites used for rendering</param>
		private void SelectOption(int x)
		{
			Events.Execute(WorldEvents.SetMap, m_optionDropDown.options[x].text);
		}

		#endregion
	}
}
