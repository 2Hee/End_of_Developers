using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

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
    public PRS originPRS;

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

    private void OnMouseOver()
    {
        if (isFront)
            CardManager.Inst.CardMouseOver(this);
    }

    private void OnMouseExit()
    {
        if (isFront)
            CardManager.Inst.CardMouseExit(this);
    }

    private void OnMouseDown()
    {
        if (isFront)
            CardManager.Inst.CardMouseDown();
    }

    private void OnMouseUp()
    {
        if (isFront)
            CardManager.Inst.CardMouseUp();
    }

    public void MoveTransform(PRS prs, bool useDotween, float dotweenTime = 0)
    {
        if(useDotween)
        {
            transform.DOMove(prs.pos, dotweenTime);
            transform.DORotateQuaternion(prs.rot, dotweenTime);
            transform.DOScale(prs.scale, dotweenTime);
        }
        else
        {
            transform.position = prs.pos;
            transform.rotation = prs.rot;
            transform.localScale = prs.scale;
        }
    }
}
