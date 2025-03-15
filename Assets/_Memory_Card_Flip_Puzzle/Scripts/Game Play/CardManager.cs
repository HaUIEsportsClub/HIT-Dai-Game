using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;
    public LevelData levelData;
    public List<Card> cardList;
    [SerializeField] private List<Transform> cardsParent;
    
    private void Awake()
    {
        if (Instance) return;

        Instance = this;
        cardsParent = GetComponentsInChildren<Transform>().ToList();
        cardsParent.RemoveAt(0);
    }

    public void Start()
    {
        var gameData = GameManager.Instance.gameData;
        var curLevel = gameData.curLevel;
        levelData = GameManager.Instance.levelDataManager.levelDataList[curLevel];
        SpawnCards();
    }

    private void SpawnCards()
    {
        for (int i = 0; i < levelData.cardCoupleCount * 2;)
        {
            SpawnCard(0, i++);
            SpawnCard(0, i++);
        }
    }

    private void SpawnCard(int idCard, int childIndex)
    {
        var card = PoolingManager.Spawn(GameManager.Instance.cardPrefab, cardsParent[childIndex].position, Quaternion.identity);
        card.transform.SetParent(cardsParent[childIndex]);
    }
}
