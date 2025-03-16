using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/Game Data")]
public class GameData : ScriptableObject
{
    public bool isSound;
    public bool isMusic;
    public int coin = 0;
    public int curLevel;
    public int maxLevel;

    public void CheckMaxLevel()
    {
        curLevel++;
        if (curLevel > maxLevel)
        {
            maxLevel = curLevel;
        }
    }
}
