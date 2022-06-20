using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

/// <summary>
/// A little bit messy class, that manages cards effect query.
/// TODO: delete this class is garbage between BattlePlayer and MapVisual.
/// Battle playyer will directly say to Map visual (or may be even to card, that something change)
/// </summary>
public class Map : MonoBehaviour
{
    /// <summary>
    /// When all effects has been applied.
    /// </summary>
    public Action OnAnimationEnd;

    /// <summary>
    /// TODO delete this var, we shhouldnt managed it.
    /// </summary>
    public List<AbstractCard>[] Cards { get; private set; }

    /// <summary>
    /// Map visualizer.
    /// </summary>
    [SerializeField] private MapVisual visual;

    /// <summary>
    /// Cards effect, Todo: may be Bbattle manager  
    /// </summary>
    private List<AbstractCard> cardsForEffect = new List<AbstractCard>();
    private AbstractEffect.ApplyEffect effect;

    private bool isVisualizing;

    /// <summary>
    /// Initialize map/
    /// </summary>
    /// <param name="map"></param>
    public void Init(List<AbstractCard>[] map)
    {
        Cards = map;

        for(int i = 0; i < Cards.Length; i++)
        {
            Cards[i].ForEach(card => visual.AddCard(i , card));
        }
    }

    /// <summary>
    /// Some card has been player
    /// </summary>
    /// <param name="playerId"></param>
    /// <param name="card"></param>
    public void PlayCard(int playerId, AbstractCard card)
    {
        if (card == null)
        {
            OnAnimationEnd?.Invoke();
            return;
        }

        SpawnCard(playerId, card);
    }

    /// <summary>
    /// Some card has been deleted.
    /// </summary>
    /// <param name="playerId"></param>
    /// <param name="id"></param>
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
