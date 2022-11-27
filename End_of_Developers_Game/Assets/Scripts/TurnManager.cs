using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Inst { get; private set; }
    void Awake() => Inst = this;

    [Header("Develop")]
    [SerializeField] [Tooltip("시작 턴 모드를 정합니다")] ETurnMode eTurnMode;
    [SerializeField] [Tooltip("카드 배분이 매우 빨라집니다")] bool fastMode;
    [SerializeField] [Tooltip("시작 카드 갯수를 정합니다")] int startCardCount;


    [Header("Properties")]
    public bool isLoading;
    public bool myTurn;



    enum ETurnMode { My }
    WaitForSeconds delay05 = new WaitForSeconds(0.1f);

    public static Action<bool> OnAddCard;

    void GameSetup()
    {
        switch(eTurnMode)
        {
            case ETurnMode.My:
                myTurn = true;
                break;
        }
    }

    public IEnumerator StartGameCo()
    {
        GameSetup();
        isLoading = true;

        for (int i = 0; i < startCardCount; i++)
        {
            //yield return delay05;
            //OnAddCard?.Invoke(false);
            yield return delay05;
            OnAddCard?.Invoke(true);
        }
        StartCoroutine(StartTurnCo());
    }

    IEnumerator StartTurnCo()
    {
        isLoading = true;

        yield return delay05;
        OnAddCard?.Invoke(myTurn);
        yield return delay05;
        isLoading = false;
    }
}
