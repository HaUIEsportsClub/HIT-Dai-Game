using UnityEngine;

public class Loading : MonoBehaviour
{
    private void Start()
    {
        LoadSceneManager.Instance.LoadScene("Home");
    }
}
