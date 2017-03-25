using Jareel;
using Jareel.Unity;
using System.Text;
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
            // Game Data
            Use<SessionState, SessionController>();

            // Player Data
            Use<PlayerStatsState, PlayerStatsController>();
            Use<InventoryState, InventoryController>();
            Use<ActionState, ActionController>();

            // UI
            Use<UIState, UIController>();
			Use<InventoryUIState, InventoryUIController>();
            Use<HUDState, HUDController>();
            Use<CombatUIState, CombatUIController>();
		}
	}

	/// <summary>
	/// Used to provide access to the master controller from a monobehaviour
	/// </summary>
	public class Master : MonoMasterController<GameMaster>
	{
        #region Fields

        /// <summary>
        /// In the editor, copy a save file here to load from that save file
        /// </summary>
        [SerializeField, TextArea] private string m_saveFile;

		/// <summary>
		/// In the editor, copy a time traveler export to have states ready to play
		/// </summary>
		[SerializeField, TextArea] private string m_timeTravelerExport;

		/// <summary>
		/// Controls the time traveler used for this game
		/// </summary>
		[SerializeField] private TimeTravelerView m_timeTraveler;

        /// <summary>
        /// If true, all events will be logged
        /// </summary>
        [SerializeField] private bool m_logEvents = true;

        #endregion

        #region Setup

        /// <summary>
        /// Check for a debug save file to load from
        /// </summary>
        private void Start()
		{
			if (!string.IsNullOrEmpty(m_saveFile)) {
				Master.ImportState(m_saveFile);
			}
            Master.OnEventExecuted += LogEvent;
		}

        /// <summary>
        /// This is where debug checking is performed
        /// </summary>
        protected override void Update()
        {
            base.Update();

            // Debug activation
            if (InputUtility.ButtonsHeld(KeyCode.LeftShift, KeyCode.LeftControl, KeyCode.D)) {
                Master.Events.Execute(SessionEvent.ToggleDebug);
            }

			else if (InputUtility.ButtonsHeld(KeyCode.LeftControl, KeyCode.LeftShift, KeyCode.T)) {

				if (m_timeTraveler.TimeTraveler == null) {
					m_timeTraveler.TimeTraveler = m_executor.SpawnTimeTraveler(false);
				}
				m_timeTraveler.gameObject.SetActive(!m_timeTraveler.gameObject.activeSelf);
			}
		}

        /// <summary>
        /// Prints the current save state to debug so it can be copied and pasted into the
        /// debug save file field on this behavior
        /// </summary>
        private void OnDestroy()
		{
			Debug.Log(Master.ExportDebugState());
        }

        #endregion

        /// <summary>
        /// Prints a debug statement every time an event is executed
        /// </summary>
        /// <param name="ev">The event that was executed</param>
        /// <param name="args">The arguments provided with it</param>
        private void LogEvent(object ev, object[] args)
        {
            if (m_logEvents) {
                var sb = new StringBuilder();

                sb.Append(string.Format("Executing {0}({1})", ev, ev.GetType().Name));

                if (args.Length > 0) {
                    sb.Append("\nArgs: ");
                    for (int i = 0; i < args.Length - 1; ++i) {
                        sb.Append(args[i]).Append(", ");
                    }
                    sb.Append(args[args.Length - 1]);
                }

                Debug.Log(sb.ToString());
            }
        }
	}
}