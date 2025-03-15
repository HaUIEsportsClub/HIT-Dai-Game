using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/Game Data")]
public class GameData : ScriptableObject
{
    public bool isSound;
    public bool isMusic;
    public int curLevel;
}
