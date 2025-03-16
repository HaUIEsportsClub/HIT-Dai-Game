using UnityEngine;

public class GameHistoryManager : MonoBehaviour
{
    public static GameHistoryManager Instance;
    public LevelManager levelManager;
    
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
        if (levelManager)
        {
            Destroy(levelManager.gameObject);
        }

        levelManager.Initialize(24);
        UIManager.Instance.AllowClick();
    }
}
