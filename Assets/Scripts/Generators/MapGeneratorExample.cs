using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generator for dummy player
/// </summary>
public class MapGeneratorExample : AbstractGenerator
{
    private readonly List<CreatureCard> cards = new List<CreatureCard>()
        {
            new CreatureCard("Fighter", "Raaaaargh, stupid varvar", 20, 30, 0),
            new CreatureCard("Archer", "Fire to eyes", 10, 10, 10),
            new CreatureCard("Cleric", "Hill all varvars", 10, 15, 10)
        };

    public override List<AbstractCard> GenerateMapCards()
    {
        var deck = new List<AbstractCard>(); 
        int cardCount = Random.Range(4, 7);

        for(int i = 0; i < cardCount; i++)
        {
            var card = cards[Random.Range(0, cards.Count)];
            deck.Add(new CreatureCard(card.Title, card.Description, card.Attack, card.HitPoint, card.ManaPoint));
        }

        return deck;
    }

    public override List<AbstractCard> GenerateDeck()
    {
        return new List<AbstractCard>();
    }
}
