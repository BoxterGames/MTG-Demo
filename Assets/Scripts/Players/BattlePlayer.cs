using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BattlePlayer : MonoBehaviour
{
    public int PlayerId;
    public Action<AbstractCard> OnCardChoose;

    protected List<AbstractCard> playerDeck;

    public virtual void Init(List<AbstractCard> deck)
    {
        playerDeck = deck;
    }

    public abstract void StartTurn();
}
