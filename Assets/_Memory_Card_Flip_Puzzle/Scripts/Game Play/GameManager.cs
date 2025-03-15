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
        //DontDestroyOnLoad(gameObject);
    }
}
