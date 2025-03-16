using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public CardDataManager cardDataManager;
    public LevelDataManager levelDataManager;
    public GameData gameData;
    public BGData bgData;

    public LevelManager levelManager;

    public Card cardPrefab;
    public Sprite cardBack;

    private void Awake()
    {
        if (Instance) return;

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 60;
    }

    public void LoadLevel()
    {
        var curLevel = gameData.curLevel;
        LoadLevel(curLevel);
        UIManager.Instance.SetLevel(curLevel);
        UIManager.Instance.coinText.text = gameData.coin.ToString();
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

    public void RemoveCard(Card card)
    {
        levelManager.RemoveCard(card);
    }
}