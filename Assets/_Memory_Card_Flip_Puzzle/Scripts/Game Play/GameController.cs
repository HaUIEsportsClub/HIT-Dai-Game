using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public Card curCard1;
    public Card curCard2;

    public static event Action OnAddCoin;

    private void Awake()
    {
        if (Instance) return;

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GameManager.Instance.LoadLevel();
        AudioManager.Instance.PlayMusic("Game", 0.3f);
    }

    public void SetCurrentCard(Card card)
    {
        if (curCard1 == null)
        {
            curCard1 = card;
        }
        else
        {
            curCard2 = card;
        }

        CheckIfBlockClick();
    }

    public void CheckIfBlockClick()
    {
        if (curCard1 != null && curCard2 != null)
        {
            BlockClick();
        }
    }

    public void BlockClick()
    {
        UIManager.Instance.BlockClick();
    }

    public void AllowClick()
    {
        curCard1 = null;
        curCard2 = null;
        UIManager.Instance.AllowClick();
    }

    private void FlipDownCard()
    {
        if (curCard1 != null)
        {
            curCard1.FlipDown();
            curCard1 = null;
        }

        if (curCard2 != null)
        {
            curCard2.FlipDown();
            curCard2 = null;
        }
    }

    public void CheckLegitCard()
    {
        if (!CanCheckLegit())
        {
            return;
        }

        if (curCard1.ID == curCard2.ID)
        {
            CoupleCardComplete();
        }
        else
        {
            AudioManager.Instance.PlaySFX("Incorrect");
            FlipDownCard();
        }
    }

    public void CoupleCardComplete()
    {
        AudioManager.Instance.PlaySFX("Correct");
        var completePos1 = new Vector2(-CardConfig.xComplete, 0f);
        var completePos2 = new Vector2(CardConfig.xComplete, 0f);
        var time1 = Vector2.Distance(curCard1.transform.position, completePos1) / CardConfig.completeAnimSpeed;
        var time2 = Vector2.Distance(curCard2.transform.position, completePos2) / CardConfig.completeAnimSpeed;
        var time12 = time1 - time2;
        curCard1.CompleteCard(completePos1, time1, time12 >= 0 ? 0 : -time12);
        curCard2.CompleteCard(completePos2, time2, -time12 >= 0 ? 0 : time12);

        AddCoin(10);
    }

    public void AddCoin(int coinValue)
    {
        GameManager.Instance.gameData.coin += coinValue;
        UIManager.Instance.coinText.text = GameManager.Instance.gameData.coin.ToString();
        OnAddCoin?.Invoke();
    }

    private bool CanCheckLegit()
    {
        if (!curCard1 || !curCard2 || !curCard1.IsFlipped || !curCard2.IsFlipped)
        {
            return false;
        }

        return true;
    }
}