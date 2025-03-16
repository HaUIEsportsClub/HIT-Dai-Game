using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Image blockClick;
    public Image bg;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI coinText;
    public WinPopup winPopup;
    public LosePopup losePopup;
    public GameObject setting;

    public TextMeshProUGUI timerText;
    public float totalTimeInSeconds;
    public float remainingTime;

    private bool canCountdown = true;
    //private bool isPaused = false;
    private Coroutine countdownRountine;

    private void Awake()
    {
        if (Instance) return;

        Instance = this;
        blockClick.enabled = false;
    }

    private void Start()
    {
        InitTime();
        bg.sprite = GameManager.Instance.bgData.RandomSprite();
    }

    public void SetLevel(int level)
    {
        levelText.text = "Level " + level;
    }

    public void ShowWinPopup()
    {
        winPopup.gameObject.SetActive(true);
        AudioManager.Instance.PlaySFX("Win");
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

    public void InitTime()
    {
        totalTimeInSeconds = GameManager.Instance.levelManager.levelData.time;
        remainingTime = totalTimeInSeconds + 2;
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        countdownRountine = StartCoroutine(TimerCountdown());
    }
    
    private void StartCountdown(object param)
    {
        if (!canCountdown)
        {
            canCountdown = true;
            countdownRountine = StartCoroutine(TimerCountdown());
        }
    }

    private IEnumerator TimerCountdown()
    {
        while (remainingTime > 0)
        {
            if (canCountdown)
            {
                remainingTime -= Time.deltaTime;

                int minutes = Mathf.FloorToInt(remainingTime / 60f);
                int seconds = Mathf.FloorToInt(remainingTime % 60f);

                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

                if (remainingTime <= 0f)
                {
                    remainingTime = 0f; 
                    timerText.text = "00:00";
                }
            }

            yield return null;
        }

        GameOver();
    }

    public void GameOver()
    {
        if (!winPopup.gameObject.activeSelf)
            losePopup.gameObject.SetActive(true);
    }

    public void OpenSetting()
    {
        setting.SetActive(true);
    }

    public void CloseSetting()
    {
        setting.SetActive(false);
    }
    
    public void LoadHome()
    {
        SceneManager.LoadScene("Levels");
    }
    
    
}
