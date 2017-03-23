using Jareel;
using Jareel.Unity;
using UnityEngine;

namespace Game
{
	/// <summary>
	/// This game's master controller
	/// </summary>
	public class GameMaster : MasterController
	{
		/// <summary>
		/// This is where each controller use should be declared
		/// </summary>
		protected override void UseControllers()
		{
            //Combat controllers
            Use<ActionState, ActionController>();

            //Item controllers
            Use<InventoryState, InventoryController>();

            //UI controllers
            Use<UIState, UIController>();
		}
	}

	/// <summary>
	/// Used to provide access to the master controller from a monobehaviour
	/// </summary>
	public class Master : MonoMasterController<GameMaster>
	{
		/// <summary>
		/// In the editor, copy a save file here to load from that save file
		/// </summary>
		[SerializeField] private string m_saveFile;

		/// <summary>
		/// Check for a debug save file to load from
		/// </summary>
		private void Start()
		{
			if (!string.IsNullOrEmpty(m_saveFile)) {
				Master.ImportState(m_saveFile);
			}
		}

		/// <summary>
		/// Prints the current save state to debug so it can be copied and pasted into the
		/// debug save file field on this behavior
		/// </summary>
		private void OnDestroy()
		{
			Debug.Log(Master.ExportStates());
		}
	}
}