using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;
    public LevelManager levelManager;
    private List<Transform> cardsParent;
    [SerializeField] private List<int> indexList = new List<int>();
    [SerializeField] private List<int> cardIndexList = new List<int>();
    public List<Card> cardList;

    private void Awake()
    {
        if (Instance) return;

        Instance = this;
        cardsParent = GetComponentsInChildren<Transform>().ToList();
        cardsParent.RemoveAt(0);
    }

    public void Start()
    {
        indexList.Clear();
        cardIndexList.Clear();
        levelManager = GameManager.Instance.levelManager;
        int totalCard = GameManager.Instance.cardDataManager.cardData.Count;

        for (int i = 0; i < totalCard; i++)
        {
            indexList.Add(i);
        }


        for (int i = 0; i < cardIndexList.Count; i++)
        {
            Debug.Log(cardIndexList[i]);
        }

        CreateCardData();
        SpawnCards();
    }

    private void SpawnCards()
    {
        for (int i = 0; i < levelManager.cardCoupleCount * 2;)
        {
            int index = cardIndexList[i];
            SpawnCard(index, i++);
        }
    }

    private void SpawnCard(int idCard, int childIndex)
    {
        var card = PoolingManager.Spawn(GameManager.Instance.cardPrefab, cardsParent[childIndex].position, Quaternion.identity);
        card.transform.SetParent(cardsParent[childIndex]);
        card.Init(GameManager.Instance.cardDataManager.cardData[idCard]);
    }

    private void CreateCardData()
    {
        List<int> check = new List<int>();
        for (int i = 0; i < levelManager.cardCoupleCount; i++)
        {
            int random = GetRandomCardIndex();
            check.Add(random);
            check.Add(random);
        }

        cardIndexList = Shuffle(check);
    }

    public List<int> Shuffle(List<int> list)
    {
        var count = list.Count;
        var last = count - 1;
        for (var i = 0; i < last - 1; ++i)
        {
            var r = Random.Range(i, count);
            (list[i], list[r]) = (list[r], list[i]);
        }

        return list;
    }

    private int GetRandomCardIndex()
    {
        if (indexList.Count <= 0)
        {
            Debug.LogError("Cannot Random index");
            return -1;
        }

        var index = Random.Range(0, indexList.Count);
        indexList.RemoveAt(index);
        return index;
    }
}