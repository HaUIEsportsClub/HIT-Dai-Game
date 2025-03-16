using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public ButtonSpell spell1;
    public ButtonSpell spell2;

    private void Start()
    {
        GameController.OnAddCoin -= UpdateButton;
        GameController.OnAddCoin += UpdateButton;
    }

    private void OnEnable()
    {
        UpdateButton();
    }

    public void UpdateButton()
    {
        // if (GameManager.Instance.gameData.coin >= 50)
        // {
        //     Debug.Log("True");
        //     spell1.SetInteractable(true);
        //     spell1.myButton.interactable = true;
        //     spell2.SetInteractable(true);
        //     spell2.myButton.interactable = true;
        // }
        // else
        // {
        //     Debug.Log("False");
        //     spell1.SetInteractable(false);
        //     spell1.myButton.interactable = false;
        //     spell2.SetInteractable(false);
        //     spell2.myButton.interactable = false;
        // }
    }

    public void Spell_1()
    {
        if (GameManager.Instance.gameData.coin >= 50)
        {
            GameController.Instance.AddCoin(-50);
            UIManager.Instance.remainingTime += 30;
        }
    }

    public void Spell_2()
    {
        if (GameManager.Instance.gameData.coin >= 50)
        {
            GameController.Instance.AddCoin(-50);
            StartCoroutine(GameManager.Instance.levelManager.FlipAllCards(CardConfig.rotateTime + 0.25f));
        }
    }
}