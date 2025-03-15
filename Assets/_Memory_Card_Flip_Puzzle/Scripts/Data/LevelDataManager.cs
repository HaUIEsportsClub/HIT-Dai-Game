using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "LevelDataManager", menuName = "Data/Level Data")]
public class LevelDataManager : ScriptableObject
{
    public List<LevelManager> listLevel;
    
    public int TotalLevels => listLevel.Count;

    public LevelManager LoadLevel(int level)
    {
        var lv = Mathf.Clamp(level - 1, 0, listLevel.Count - 1);
        return listLevel[lv];
    }

#if UNITY_EDITOR
    private const string pathLevel = "Assets/_Memory_Card_Flip_Puzzle/Prefabs/Levels";

     public int TotalLevelLoad = 1;

    [ContextMenu("Load All Levels")]
    public void GetLevelFormDatabase()
    {
        listLevel = new List<LevelManager>();

        for (int i = 0; i < TotalLevelLoad; i++)
        {
            var assetPath = $"{pathLevel}/Level {i + 1}.prefab";
            // Debug.LogError(assetPath);
            var lv = AssetDatabase.LoadAssetAtPath<LevelManager>(assetPath);
            if (lv)
            {
                listLevel.Add(lv);
            }
        }

        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }
#endif
}