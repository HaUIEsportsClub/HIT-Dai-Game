using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Image blockClick;

    private void Awake()
    {
        if (Instance) return;

        Instance = this;
        blockClick.enabled = false;
    }

    public void BlockClick()
    {
        blockClick.enabled = true;
    }

    public void AllowClick()
    {
        blockClick.enabled = false;
    }
}
