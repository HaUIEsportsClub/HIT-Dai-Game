using DG.Tweening;
using UnityEngine.UI;

public class TransitionFx : Singleton<TransitionFx>
{
    public Image fade;

    public void StartLoadScene()
    {
        fade.DOFade(1f, 0.5f).SetUpdate(true);
    }

    public void EndLoadScene()
    {
        fade.DOFade(0f, 0.5f).SetUpdate(true);
    }
}