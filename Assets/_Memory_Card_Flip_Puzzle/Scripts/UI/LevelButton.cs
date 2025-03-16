using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int id;
    public TextMeshProUGUI levelText;
    public Button button;
    public Image lockImage;

    public void LoadLevel()
    {
        GameManager.Instance.gameData.curLevel = id + 1;
        LoadSceneManager.Instance.LoadScene("Game");
    }

    public void Init(int i)
    {
        id = i;
        var maxLevel = GameManager.Instance.gameData.maxLevel;
        var isLocked = id >= maxLevel;
        button.interactable = !isLocked;
        lockImage.enabled = isLocked;
        levelText.text = $"Level {i+1}";

        if (isLocked)
        {
            levelText.rectTransform.anchoredPosition = new Vector2(0, 20);
        }
        else
        {
            levelText.rectTransform.anchoredPosition = new Vector2(0, 0);
        }
    }
}