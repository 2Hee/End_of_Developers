using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] SpriteRenderer card;
    [SerializeField] SpriteRenderer character;
    [SerializeField] TMP_Text nameTMP;
    [SerializeField] TMP_Text numberTMP;
    [SerializeField] Sprite cardFront;
    [SerializeField] Sprite cardBack;

    public Item item;
    bool isFront;

    public void Setup(Item item, bool isFront)
    {
        this.item = item;
        this.isFront = isFront;

        if(this.isFront)
        {
            character.sprite = this.item.sprite;
            nameTMP.text = this.item.name;
            numberTMP.text = this.item.value.ToString();
        }
        else
        {
            card.sprite = cardBack;
            nameTMP.text = "";
            numberTMP.text = "";
        }
    }
}
