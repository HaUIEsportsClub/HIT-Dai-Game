using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataManager", menuName = "Data/Level Data")]
public class LevelDataManager : ScriptableObject
{
    public List<LevelData> levelDataList;
}

[Serializable]
public class LevelData
{
    public int id;
    public int cardCoupleCount;
    public float time;
    public float cameraSize;
}