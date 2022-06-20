using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Example for demo player
/// </summary>
public class DeckGeneratorExample : AbstractGenerator
{
    public override List<AbstractCard> GenerateDeck()
    {
        return new List<AbstractCard>()
        {
            new EffectCard("FireBall", "All will be damaged", new CardChooser(ChooseType.All, true), new RandomDamage())
        };
    }

    public override List<AbstractCard> GenerateMapCards()
    {
        return new List<AbstractCard>();
    }
}
