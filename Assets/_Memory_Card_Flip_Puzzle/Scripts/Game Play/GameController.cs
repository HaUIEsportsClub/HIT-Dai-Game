using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public Card curCard1;
    public Card curCard2;
    
    private void Awake()
    {
        if (Instance) return;

        Instance = this;
        //DontDestroyOnLoad(gameObject);
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
            Debug.LogError("Không ăn được card");
            FlipDownCard();
        }
    }

    public void CoupleCardComplete()
    {
        curCard1.CompleteCard(-CardConfig.xComplete);
        curCard2.CompleteCard(CardConfig.xComplete);
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
