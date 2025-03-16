using UnityEngine;

public class WinPopup : MonoBehaviour
{
    public void NextLevel()
    {   
        GameManager.Instance.gameData.CheckMaxLevel();
        LoadSceneManager.Instance.LoadScene("Game");
    }
    public void GoToMenu()
    {
        GameManager.Instance.gameData.CheckMaxLevel();
        LoadSceneManager.Instance.LoadScene("Levels");
    }
}
