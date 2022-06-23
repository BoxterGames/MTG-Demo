using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System;

/// <summary>
/// Manage battle turn. And cards living. Later will be call cards attack action.
/// </summary>
public class BattleManager : MonoBehaviour
{
    /// <summary>
    /// Ovject that shows turns order.
    /// TODO: Move outside.
    /// </summary>
    public GameObject[] TurnActive = new GameObject[2];


    /// <summary>
    /// Map that containes all cards.
    /// </summary>
    [SerializeField] private Map map;

    private BattlePlayer[] players;
    private int playerId;

    /// <summary>
    /// Start battles
    /// </summary>
    /// <param name="newPlayers">Players who will be play</param>
    /// <param name="cards">Cards on deck</param>
    public void StartBattle(BattlePlayer[] newPlayers, List<AbstractCard>[] cards)
    {
        map.Init(cards);

        players = newPlayers;
        playerId = 0;

        Array.ForEach(TurnActive, i => i.SetActive(i == TurnActive[0]));
        
        //Subscribe to player turn ends
        Array.ForEach(players, player => player.OnCardChoose += OnCardChoose);
        
        map.OnAnimationEnd += OnAnimationEnd;
        players[0].StartTurn();
    }

    private void OnCardChoose(AbstractCard newCard)
    {
        Array.ForEach(TurnActive, i => i.SetActive(false));
        map.PlayCard(playerId, newCard);
    }

    private void OnAnimationEnd()
    {
        DeleteDeadCard();
        playerId = (playerId + 1) % players.Length;

        Array.ForEach(TurnActive, i => i.SetActive(i == TurnActive[playerId]));
        players[playerId].StartTurn();
    }

    private void DeleteDeadCard()
    {
        for (int i = map.Cards.Length - 1; i >= 0; i--)
        {
            for (int j = map.Cards[i].Count - 1; j >= 0; j--)
            {   
                if(((CreatureCard)map.Cards[i][j]).HitPoint <= 0)
                {
                    map.RemoveCard(i, j);
                }
            }
        }
    }
}
