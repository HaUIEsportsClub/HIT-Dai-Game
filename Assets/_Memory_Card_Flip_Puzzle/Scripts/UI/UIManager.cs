using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Image blockClick;
    public Button replayButton;

    private void Awake()
    {
        if (Instance) return;

        Instance = this;
        blockClick.enabled = false;
    }

    private void Start()
    {
        replayButton.onClick.AddListener(OnReplayClicked);
    }

    private void OnReplayClicked()
    {
        GameManager.Instance.LoadLevel();
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
