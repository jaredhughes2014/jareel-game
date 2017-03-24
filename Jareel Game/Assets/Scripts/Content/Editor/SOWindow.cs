using UnityEngine;
using UnityEditor;
using System;

namespace Game
{
    /// <summary>
    /// Used to open windows
    /// </summary>
    public class SOWindow : EditorWindow
    {
        /// <summary>
        /// The number of copies to create
        /// </summary>
        private int m_count;

        /// <summary>
        /// Used to perform the creation
        /// </summary>
        private Action<int> m_onCreate;

        /// <summary>
        /// Opens a window to create assets of S
        /// </summary>
        public static void Open<S>() where S : ScriptableObject
        {
            var window = EditorWindow.GetWindow<SOWindow>();
            window.Setup(count =>
            {
                SOCreator.CreateAssets<S>(count);
            });


            var size = new Vector2(300, 100);
            window.minSize = size;
            window.maxSize = size;

            window.Show();
        }

        /// <summary>
        /// Sets up the creation window
        /// </summary>
        public void Setup(Action<int> onCreate)
        {
            m_onCreate = onCreate;
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnGUI()
        {
            m_count = EditorGUILayout.IntField("Count", m_count);

            if (GUILayout.Button("Submit")) {
                m_onCreate(m_count);
            }
        }
    }
}
