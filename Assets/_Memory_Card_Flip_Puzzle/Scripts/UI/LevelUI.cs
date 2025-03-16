using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public GameObject settingPopup;
    public GameObject infoPopup;
    public List<LevelButton> levels;
    public LevelButton levelButtonPrefab;
    public Transform content;

    private void Start()
    {
        AudioManager.Instance.PlayMusic("Choose_Level", 0.3f);

        levels = new List<LevelButton>();
        for (int i = 0; i < GameManager.Instance.levelDataManager.TotalLevels; i++)
        {
            var levelButton = Instantiate(levelButtonPrefab, content);
            levels.Add(levelButton);
        }

        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].Init(i);
        }
    }

    public void ActiveSettingPopup()
    {
        settingPopup.SetActive(true);
    }

    public void ActiveInfoPopup()
    {
        infoPopup.SetActive(true);
    }

    public void DeactiveInfoPopup()
    {
        infoPopup.SetActive(false);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}