using UnityEngine;
using System.Linq;

namespace Game
{
    /// <summary>
    /// Utility functions for input
    /// </summary>
    public static class InputUtility
    {
        /// <summary>
        /// Returns true if all of the given keys are being held. This is useful for hotkeys.
        /// 
        /// This will only return true once as it checks for at least one key to be pressed down
        /// </summary>
        /// <param name="keys">The keys to check for holding</param>
        /// <returns>True if all of the given keys are held</returns>
        public static bool ButtonsHeld(params KeyCode[] keys)
        {
            return keys.Any(p => Input.GetKeyDown(p)) && keys.All(p => Input.GetKey(p));
        }
    }
}
