using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDataManager", menuName = "Data/Card Data")]
public class CardDataManager : ScriptableObject
{
    public List<CardData> cardData;
}

[Serializable]
public class CardData
{
    public int id;
    public Sprite sprite;
}