using DG.Tweening;
using UnityEngine;

public class Card : MonoBehaviour
{
    public BoxCollider2D coll;
    public SpriteRenderer sr;
    public CardData cardData;
    private bool isFLipped;

    public bool IsFlipped => isFLipped;
    public int ID => cardData.id;

    public void Init(CardData data)
    {
        cardData = data;
        isFLipped = false;
    }

    private void OnMouseDown()
    {
        if (!isFLipped && !ClickLimiter.IsMouseOverUIElement())
        {
            Flip();
        }
    }

    public void Flip()
    {
        coll.enabled = false;
        GameController.Instance.SetCurrentCard(this);
        var rotation = transform.rotation;
        var endRot2 = new Vector3(rotation.x, 180f, rotation.z);
        transform.DORotate(endRot2, CardConfig.rotateTime).OnComplete(() =>
        {
            isFLipped = true;
            GameController.Instance.CheckLegitCard();
        });
        transform.DOScale(Vector3.one * CardConfig.rotateScale, CardConfig.rotateTime * 0.4f).OnComplete(() =>
        {
            ChangeSprite(cardData.sprite);
            transform.DOScale(Vector3.one, CardConfig.rotateTime * 0.6f);
        });
    }

    public void FlipDown()
    {
        var rotation = transform.rotation;
        var endRot2 = new Vector3(rotation.x, 0f, rotation.z);
        transform.DORotate(endRot2, CardConfig.rotateTime).SetEase(Ease.InQuad).OnComplete(() =>
        {
            coll.enabled = true;
            isFLipped = false;
            GameController.Instance.AllowClick();
        });
        transform.DOScale(Vector3.one * CardConfig.rotateScale, CardConfig.rotateTime * 0.6f).SetEase(Ease.InQuad).OnComplete(() =>
        {
            ChangeSprite(GameManager.Instance.cardBack);
            transform.DOScale(Vector3.one, CardConfig.rotateTime * 0.4f).SetEase(Ease.InQuad);
        });
    }

    private void ChangeSprite(Sprite sprite)
    {
        sr.sprite = sprite;
    }

    public void CompleteCard(Vector2 completePos, float time, float offsetTime)
    {
        var yBot = -Camera.main.orthographicSize;
        sr.sortingLayerName = "Card Complete";
        transform.DOScale(CardConfig.scaleComplete, time);
        transform.DOMove(completePos, time).SetDelay(offsetTime).OnComplete(() =>
        {
            transform.DOMoveY(yBot - 3f, time + offsetTime).OnComplete(() =>
            {
                Destroy(gameObject);
                GameController.Instance.AllowClick();
            });
        });
    }
}