using UnityEditor;
using UnityEngine;

namespace EditorTools
{
    public class EditorToolSet : EditorWindow
    {
        [MenuItem("Tools/Clear Player Prefs")]
        public static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
