using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector3 oriScale;

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(oriScale - oriScale / 10f, 0.15f).SetUpdate(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(oriScale, 0.15f).SetUpdate(true);
        //AudioManager.Instance.PlaySFX("Button_Click");
    }
}