using UnityEngine;
using UnityEditor;
using System.IO;

namespace Game
{
    /// <summary>
    /// Credit: http://wiki.unity3d.com/index.php?title=CreateScriptableObjectAsset
    /// </summary>
    public static class SOCreator
    {
        /// <summary>
        //	This makes it easy to create, name and place unique new ScriptableObject asset files.
        /// </summary>
        public static void CreateAsset<T>(int i) where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();

            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (path == "") {
                path = "Assets";
            }
            else if (Path.GetExtension(path) != "") {
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            }

            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(T).Name + i + ".asset");

            AssetDatabase.CreateAsset(asset, assetPathAndName);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }

        /// <summary>
        /// Shortcut to make multiple
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count"></param>
        public static void CreateAssets<T>(int count) where T : ScriptableObject
        {
            for (int i = 0; i < count; ++i) {
                CreateAsset<T>(i + 1);
            }
        }
    }
}