using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataManager", menuName = "Data/Level Data")]
public class LevelDataManager : ScriptableObject
{
    public List<LevelManager> listLevel;
}
