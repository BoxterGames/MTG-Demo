using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeckVisualizer
{
    public List<CardVisual> Cards;

    [SerializeField] private CardVisual prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private float cardWith;

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
