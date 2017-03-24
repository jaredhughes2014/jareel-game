using System;
using Jareel.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game
{
	/// <summary>
	/// Special view which allows the user to
	/// </summary>
	public class TimeTravelerView : MonoBehaviour, IDragHandler
	{
		#region Fields

		/// <summary>
		/// Used to display a warning when there are no more states left
		/// </summary>
		[SerializeField] private Text m_warningLabel;

		/// <summary>
		/// The time traveler used by this view
		/// </summary>
		public TimeTraveler TimeTraveler { get; set; }

		#endregion

		#region Setup

		/// <summary>
		/// Logs the time traveler export
		/// </summary>
		private void OnDestroy()
		{
			if (TimeTraveler != null) {
				Debug.Log("Time Traveler Export:\n" + TimeTraveler.Export());
			}
		}

		#endregion

		#region Events

		/// <summary>
		/// Plays the next state in the time traveler. Displays a warning if there are no more states to play back
		/// </summary>
		public void PlayNext()
		{
			if (TimeTraveler.PlayNextState()) {
				m_warningLabel.text = string.Format("State {0}", TimeTraveler.StateIndex);
				m_warningLabel.color = Color.cyan;
			}
			else {
				m_warningLabel.text = "No more states to play";
				m_warningLabel.color = Color.yellow;
			}
		}

		/// <summary>
		/// Resets the playback in the time traveler. This will start the system over at the original state
		/// </summary>
		public void ResetTimeTraveler()
		{
			TimeTraveler.ResetPlayback();
			PlayNext();
		}

		/// <summary>
		/// Begins recording states. THis will clear all previous captures
		/// </summary>
		public void StartRecording()
		{
			TimeTraveler.ClearCaptures();
			TimeTraveler.StartRecording();

			m_warningLabel.text = "Recording...";
			m_warningLabel.color = Color.green;
		}

		/// <summary>
		/// Stops recording states.
		/// </summary>
		public void StopRecording()
		{
			TimeTraveler.StopRecording();

			m_warningLabel.text = string.Format("Recorded {0} States", TimeTraveler.CapturedStates.Length);
			m_warningLabel.color = Color.cyan;
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (eventData.dragging) {
				transform.localPosition += (Vector3)eventData.delta;
			}
		}

		#endregion
	}
}