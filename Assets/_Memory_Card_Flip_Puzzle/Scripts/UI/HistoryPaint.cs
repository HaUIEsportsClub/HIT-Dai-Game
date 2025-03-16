using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryPaint : MonoBehaviour
{
    public Image historyImage;
    public Image maskImage;
    public List<Image> cardImage;
    public Color activeColor = Color.green;
    public int curID;

    private void Awake()
    {
        EventDispatcher.Instance.RegisterListener(EventID.On_Complete_Card, OnCompleteCard);
        curID = 0;
    }

    private void OnDestroy()
    {
        EventDispatcher.Instance.RemoveListener(EventID.On_Complete_Card, OnCompleteCard);
    }

    private void OnCompleteCard(object param)
    {
        cardImage[curID].color = activeColor;
        curID++;
    }
}
