using UnityEngine;

public class LosePopup : MonoBehaviour
{
    public void ReplayLevel()
    {
        LoadSceneManager.Instance.LoadScene("GamePlay");
    }

    public void GoToMenu()
    {
        LoadSceneManager.Instance.LoadScene("Normal Levels");
    }
}
