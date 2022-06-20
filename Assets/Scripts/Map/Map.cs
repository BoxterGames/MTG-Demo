using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Map : MonoBehaviour
{
    public Action OnAnimationEnd;

    [SerializeField] private MapVisual visual;

    public List<AbstractCard>[] Cards { get; private set; }

    private List<AbstractCard> cardsForEffect = new List<AbstractCard>();
    private AbstractEffect.ApplyEffect effect;

    private bool isVisualizing;

    public void Init(List<AbstractCard>[] map)
    {
        Cards = map;

        for(int i = 0; i < Cards.Length; i++)
        {
            Cards[i].ForEach(card => visual.AddCard(i , card));
        }
    }

    public void PlayCard(int playerId, AbstractCard card)
    {
        if (card == null)
        {
            OnAnimationEnd?.Invoke();
            return;
        }

        SpawnCard(playerId, card);
    }

    public void RemoveCard(int playerId, int id)
    {
        Cards[playerId].RemoveAt(id);
        visual.RemoveCard(playerId, id);
    }


    private void SpawnCard(int playerId, AbstractCard card)
    {
        isVisualizing = true;

        if (card is CreatureCard)
        {
            Cards[playerId].Add(card);
            visual.AddCard(playerId, card);
        }

        if (card is EffectCard)
        {
            ((EffectCard)card).Effect.Init();
            effect = ((EffectCard)card).Effect.GetEffect();
            cardsForEffect = ((EffectCard)card).Chooser.GetCards(playerId, Cards);
        }
    }

    private void LateUpdate()
    {
        if (!isVisualizing || !visual.IsAnimationEnd)
        {
            return;
        }

        if (cardsForEffect.Count == 0)
        {
            isVisualizing = false;
            OnAnimationEnd?.Invoke();
        }
        else
        {
            effect(cardsForEffect[0]);
            cardsForEffect.RemoveAt(0);
        }
    }
}
