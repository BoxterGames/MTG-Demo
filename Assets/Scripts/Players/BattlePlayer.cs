using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Base player who will be make turns.
/// </summary>
public abstract class BattlePlayer : MonoBehaviour
{
    /// <summary>
    /// Player IDs
    /// </summary>
    public int PlayerId;

    /// <summary>
    /// Call when player choosed the card/
    /// </summary>
    public Action<AbstractCard> OnCardChoose;

    /// <summary>
    /// Card in players hand
    /// TODO: May be set public? In this case visualizers can get info about deck, also some achievments can be create. Like: get 3 archers
    /// </summary>
    protected List<AbstractCard> playerDeck;

    public virtual void Init(List<AbstractCard> deck)
    {
        playerDeck = deck;
    }

    public abstract void StartTurn();
}
