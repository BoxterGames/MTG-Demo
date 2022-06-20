using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple player that can choose card.
/// </summary>
public class DemoPlayer : BattlePlayer
{
    [SerializeField] private DeckVisualizer deckVisual;

    private bool state;

    public override void Init(List<AbstractCard> deck)
    {
        base.Init(deck);
        deckVisual.SetupDeck(deck);
        deckVisual.Cards.ForEach(card =>  card.OnPress += OnCardPress);
    }

    public override void StartTurn()
    {
        state = true;
    }

    private void OnCardPress(AbstractCard card)
    {
        if (!state)
        {
            return;
        }

        state = false;
        OnCardChoose?.Invoke(card);
    }
}
