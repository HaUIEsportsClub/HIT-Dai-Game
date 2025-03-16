using UnityEngine;

public class Loading : MonoBehaviour
{
    private void Start()
    {
        LoadSceneManager.Instance.LoadScene("Levels");
        
        Screen.SetResolution(600, 1334, false);
        Screen.fullScreen = false;
    }
}
