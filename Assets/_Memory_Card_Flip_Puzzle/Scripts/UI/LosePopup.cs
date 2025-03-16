using UnityEngine;

public class LosePopup : MonoBehaviour
{
    public void ReplayLevel()
    {
        LoadSceneManager.Instance.LoadScene("Game");
    }

    public void GoToMenu()
    {
        LoadSceneManager.Instance.LoadScene("Levels");
    }
}
