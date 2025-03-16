using UnityEngine;

public class WinPopup : MonoBehaviour
{
    public void ReplayLevel()
    {
        LoadSceneManager.Instance.LoadScene("Game");
    }

    public void GoToMenu()
    {
        LoadSceneManager.Instance.LoadScene("Normal Levels");
    }
}
