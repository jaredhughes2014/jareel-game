using Jareel.Unity;
using UnityEngine;

namespace Game
{
	public class GameMasterMonoController : MonoMasterController<GameMasterController>
	{
		/// <summary>
		/// The state that will be loaded on start
		/// </summary>
		[SerializeField] private string m_stateToLoad;

		protected void Start()
		{
			if (!string.IsNullOrEmpty(m_stateToLoad)) {
				Master.ImportState(m_stateToLoad);
			}
		}

		protected virtual void OnDestroy()
		{
			Debug.Log(Master.ExportStates());
		}
	}
}
