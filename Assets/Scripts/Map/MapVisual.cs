using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

/// <summary>
/// Manage that all cards was animated and stay at right place.
/// </summary>
public class MapVisual : MonoBehaviour
{
    /// <summary>
    /// Is all cards animationn complete
    /// </summary>
    public bool IsAnimationEnd
    {
        get
        {
            return movingEnds && !cardsMap.Any(cards => cards.Any(c => !c.IsAnimationEnd));
        }
    }

    [Header("Card prefab")]
    [SerializeField] CardVisual cardPrefab;
    [SerializeField] float CardWidth;
    [SerializeField] float cardMovingSpeed;

    [Header("Field")]   
    [SerializeField] private Transform[] playerFields;
    
    private List<CardVisual>[] cardsMap = new List<CardVisual>[] { new List<CardVisual>(), new List<CardVisual>() };
    private bool movingEnds;

    /// <summary>
    /// Add card
    /// </summary>
    /// <param name="playerID"></param>
    /// <param name="card"></param>
    public void AddCard(int playerID, AbstractCard card)
    {
        var cardVisual = Instantiate(cardPrefab, playerFields[playerID]);
        cardVisual.Init(card);
        cardsMap[playerID].Add(cardVisual);
        UpdateCardPosition(cardsMap[playerID], true);
    }

    /// <summary>
    /// Remove dead card.
    /// </summary>
    /// <param name="playerId"></param>
    /// <param name="id"></param>
    public void RemoveCard(int playerId, int id)
    {
        Destroy(cardsMap[playerId][id].gameObject);
        cardsMap[playerId].RemoveAt(id);
    }

    private void Update()
    {
        Array.ForEach(cardsMap, card => UpdateCardPosition(card, false));
    }

    private void UpdateCardPosition(List<CardVisual> card, bool forceUpdate)
    {
        for (int i = 0; i < card.Count; i++)
        {
            float x = (i - (card.Count - 1) / 2f) * CardWidth;
            movingEnds = true;

            if (!forceUpdate)
            {
                float currX = card[i].transform.localPosition.x;
                float delta = x - currX;
                float speed = Math.Sign(delta) * Math.Min(Math.Abs(delta), cardMovingSpeed * Time.deltaTime);

                movingEnds = delta < 0.01f;
                x = currX + speed;
            }

            card[i].transform.localPosition = Vector3.right * x;
        }
    }
}
