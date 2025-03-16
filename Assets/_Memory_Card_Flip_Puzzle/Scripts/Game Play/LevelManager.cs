using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [Header("LEVEL DATA")] public LevelData levelData;

    [Header("CARD MANAGER")] [SerializeField]
    private List<int> indexList = new List<int>();

    [SerializeField] private List<int> cardIndexList = new List<int>();
    public List<Card> cardList;

    [SerializeField] private List<Transform> cardsParent;

    private void Awake()
    {
        cardsParent = new List<Transform>();
        cardsParent = GetComponentsInChildren<Transform>().ToList();
        cardsParent.RemoveAt(0);
    }

#if UNITY_EDITOR
    private const float sizeObject = 1;
    private float spacing => sizeObject + levelData.padding;

    [ContextMenu("Clear Child")]
    public void DestroyChildAndClearList()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        cardsParent.Clear();
    }

    [ContextMenu("Generate Map")]
    public void GenerateGrid()
    {
        DestroyChildAndClearList();

        float startX = -(levelData.cols - 1) * spacing / 2f;
        float startY = (levelData.rows - 1) * spacing / 2f;

        int index = 0;
        for (int i = 0; i < levelData.rows; i++)
        {
            for (int j = 0; j < levelData.cols; j++)
            {
                index++;
                Vector3 position = new Vector3(startX + j * spacing, startY - i * spacing, 0);
                var obj = new GameObject($"Element {index}");
                obj.transform.SetParent(transform);
                obj.transform.position = position;
                cardsParent.Add(obj.transform);
            }
        }
    }


    [ContextMenu("Generate Demo")]
    public void GenerateGridDemo()
    {
        var pathObj = $"Assets/_Memory_Card_Flip_Puzzle/Prefabs/Demo.prefab";
        DestroyChildAndClearList();

        var objDemo = AssetDatabase.LoadAssetAtPath<GameObject>(pathObj);
        if (!objDemo)
        {
            Debug.LogError($"Không có prefab tại đường dẫn: ---- {pathObj}");
            return;
        }

        float startX = -(levelData.cols - 1) * spacing / 2f;
        float startY = (levelData.rows - 1) * spacing / 2f;

        int index = 0;
        for (int i = 0; i < levelData.rows; i++)
        {
            for (int j = 0; j < levelData.cols; j++)
            {
                index++;
                Vector3 position = new Vector3(startX + j * spacing, startY - i * spacing, 0);
                var obj = Instantiate(objDemo, transform, true);
                obj.name = $"Demo {index}";
                obj.transform.position = position;
                cardsParent.Add(obj.transform);
            }
        }
    }

#endif


    public void Initialize()
    {
        Camera.main.orthographicSize = levelData.cameraSize;
        indexList.Clear();
        cardIndexList.Clear();
        
        int totalCard = GameManager.Instance.cardDataManager.cardData.Count;

        for (int i = 0; i < totalCard; i++)
        {
            indexList.Add(i);
        }

        CreateCardData();
        SpawnCards();
    }
    
    public void Initialize(int total)
    {
        Camera.main.orthographicSize = levelData.cameraSize;
        indexList.Clear();
        cardIndexList.Clear();
        int totalCard = total;

        for (int i = 0; i < totalCard; i++)
        {
            indexList.Add(i);
        }

        CreateCardData();
        SpawnCards();
    }

    private void SpawnCards()
    {
        for (int i = 0; i < levelData.cardCoupleCount * 2;)
        {
            int index = cardIndexList[i];
            SpawnCard(index, i++);
        }
    }

    private void SpawnCard(int idCard, int childIndex)
    {
        var card = PoolingManager.Spawn(GameManager.Instance.cardPrefab, cardsParent[childIndex].position,
            Quaternion.identity);
        card.transform.SetParent(cardsParent[childIndex]);
        card.Init(GameManager.Instance.cardDataManager.cardData[idCard]);
        cardList.Add(card);
    }

    public void RemoveCard(Card card)
    {
        cardList.Remove(card);
        
        if (cardList.Count <= 0)
        {
            UIManager.Instance.ShowWinPopup();
        }
    }

    private void CreateCardData()
    {
        List<int> check = new List<int>();
        for (int i = 0; i < levelData.cardCoupleCount; i++)
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

    public IEnumerator FlipAllCards(float time)
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            if (!cardList[i].IsFlipped)
            {
                cardList[i].Flip();
            }
        }
        
        UIManager.Instance.BlockClick();
        yield return new WaitForSeconds(time);
        for (int i = 0; i < cardList.Count; i++)
        {
            cardList[i].FlipDown();
        }
    }
}

[Serializable]
public class LevelData
{
    [Range(2, 15)] public int rows = 2;
    [Range(2, 10)] public int cols = 2;
    [Range(2.5f, 4f)] public float padding = 2.5f;
    public int cardCoupleCount;
    public float time;
    public float cameraSize;
}