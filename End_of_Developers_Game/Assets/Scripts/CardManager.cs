using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Inst { get; private set; }
    void Awake() => Inst = this;

    [SerializeField] ItemSO itemSO;
    [SerializeField] GameObject cardPrefab;
    [SerializeField] List<Card> myCards;

    List<Item> itemBuffer;

    public Item PopItem()
    {
        if(itemBuffer.Count == 0)
            SetItemBuffer();

        Item item = itemBuffer[0];
        itemBuffer.RemoveAt(0);
        return item;
    }

    void SetItemBuffer()
    {
        itemBuffer = new List<Item>();
        for(int i=0; i < itemSO.items.Length; i++) //items 배열 안에 있는 것들 다 가져옴
        {
            Item item = itemSO.items[i];
            for (int j =0; j < item.percent; j++) //percent에 맞춰서 순서대로 가져옴
                itemBuffer.Add(item);
        }

        for(int i =0; i < itemBuffer.Count; i++) // 순서대로 가져온거 섞어줌
        {
            int rand = Random.Range(i, itemBuffer.Count);
            Item temp = itemBuffer[i];
            itemBuffer[i] = itemBuffer[rand];
            itemBuffer[rand] = temp;
        }
    }

    private void Start()
    {
        SetItemBuffer();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            AddCard(true);
    }

    void AddCard(bool isMine)
    {
        var cardObject = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);
        var card = cardObject.GetComponent<Card>();
        card.Setup(PopItem(), isMine);
        if (isMine)
            myCards.Add(card);

        SetOriginOrder(isMine);
    }

    void SetOriginOrder(bool isMine)
    {
        int count = myCards.Count;
        for(int i =0; i < count; i++)
        {
            var targetCard = myCards[i];
            targetCard?.GetComponent<Order>().SetOriginOrder(i);
        }
    }
}
