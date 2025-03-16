using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Image blockClick;
    public TextMeshProUGUI levelText;
    public WinPopup winPopup;
    public LosePopup losePopup;

    private void Awake()
    {
        if (Instance) return;

        Instance = this;
        blockClick.enabled = false;
    }

    private void Start()
    {
    }

    public void SetLevel(int level)
    {
        levelText.text = "Level " + level;
    }

    public void ShowWinPopup()
    {
        winPopup.gameObject.SetActive(true);
    }

    public void ShowLosePopup()
    {
        losePopup.gameObject.SetActive(true);
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
