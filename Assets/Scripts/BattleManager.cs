using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System;

/// <summary>
/// Manage game turn. 
/// </summary>
public class BattleManager : MonoBehaviour
{
    public Map Field;

    public GameObject[] TurnActive = new GameObject[2];

    private BattlePlayer[] players;
    private int playerId;

    public void StartBattle(BattlePlayer[] newPlayers, List<AbstractCard>[] cards)
    {
        Field.Init(cards);

        players = newPlayers;
        playerId = 0;

        Array.ForEach(TurnActive, i => i.SetActive(i == TurnActive[0]));
        Array.ForEach(players, player => player.OnCardChoose += OnCardChoose);
        Field.OnAnimationEnd += OnAnimationEnd;
        players[0].StartTurn();
    }

    private void OnCardChoose(AbstractCard newCard)
    {
        Array.ForEach(TurnActive, i => i.SetActive(false));
        Field.PlayCard(playerId, newCard);
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
        for (int i = Field.Cards.Length - 1; i >= 0; i--)
        {
            for (int j = Field.Cards[i].Count - 1; j >= 0; j--)
            {
                if(((CreatureCard)Field.Cards[i][j]).HitPoint < 0)
                {
                    Field.RemoveCard(i, j);
                }
            }
        }
    }
}
