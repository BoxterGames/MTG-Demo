using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Visualize cards in hand
/// </summary>
[System.Serializable]
public class DeckVisualizer
{
    /// <summary>
    /// To check which card was choosed player.
    /// TODO: may be cards to private and add Action<Card> cardChoose
    /// </summary>
    public List<CardVisual> Cards;

    [SerializeField] private CardVisual prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private float cardWith;

    /// <summary>
    /// Create visual card gameobject
    /// </summary>
    /// <param name="cards"></param>
    public void SetupDeck(List<AbstractCard> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            CardVisual card = Object.Instantiate(prefab, parent);
            card.Init(cards[i]);

            float x = (i - cards.Count / 2f) * cardWith;
            card.transform.localPosition = Vector3.right * x;

            Cards.Add(card);
        }
    }
}
