using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public CardDataManager cardDataManager;
    public LevelDataManager levelDataManager;
    public GameData gameData;

    public LevelManager levelManager;

    public Card cardPrefab;
    public Sprite cardBack;

    private void Awake()
    {
        if (Instance) return;

        Instance = this;
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        LoadLevel();
    }

    public void LoadLevel()
    {
        var curLevel = gameData.curLevel;

        LoadLevel(curLevel);
    }

    public void LoadLevel(int level)
    {
        if (levelManager)
        {
            Destroy(levelManager.gameObject);
        }

        levelManager = Instantiate(levelDataManager.LoadLevel(level), Vector3.zero, Quaternion.identity);
        levelManager.Initialize();

        UIManager.Instance.AllowClick();
    }
}