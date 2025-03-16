#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace _Memory_Card_Flip_Puzzle.Scripts.Editor
{
    [CustomEditor(typeof(LevelManager))]
    public class LevelManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            LevelManager levelManager = (LevelManager)target;
            GUILayout.BeginVertical();
            if (GUILayout.Button("Clear"))
            {
                levelManager.DestroyChildAndClearList();
            }

            if (GUILayout.Button("Generate"))
            {
                levelManager.GenerateGrid();
            }

            if (GUILayout.Button("Generate Demo"))
            {
                levelManager.GenerateGridDemo();
            }

            GUILayout.EndVertical();
            base.OnInspectorGUI();
        }
    }
}
#endif