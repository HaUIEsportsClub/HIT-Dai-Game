using DG.Tweening;
using UnityEngine;

public class PopupScaler : MonoBehaviour
{
    private void OnEnable()
    {
        transform.localScale = Vector3.one * 1.3f;
        transform.DOScale(Vector3.one, 0.5f);
    }
}
