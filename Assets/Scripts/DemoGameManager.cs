using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class DemoGameManager : MonoBehaviour
{
    private AbstractGenerator[] generator = new AbstractGenerator[]
    {
        new MapGeneratorExample(),
        new DeckGeneratorExample()
    };

    [SerializeField] private BattlePlayer[] players = new BattlePlayer[2];
    [SerializeField] private BattleManager battle;
    [SerializeField] private TextureLoader loader;

    private List<AbstractCard>[] decks;
    private List<AbstractCard>[] cards;
    private bool waitingTexture = true;

    private void Start()
    {
        decks = new List<AbstractCard>[] { generator[0].GenerateDeck(), generator[1].GenerateDeck() };
        cards = new List<AbstractCard>[] { generator[0].GenerateMapCards(), generator[1].GenerateMapCards() };

        List<string> titles = new List<string>();

        Array.ForEach(decks, i => titles.AddRange(i.Select(c => c.Title)));
        Array.ForEach(cards, i => titles.AddRange(i.Select(c => c.Title)));

        loader.LoadTexture(titles);
    }

    private void Update()
    {
        if (loader.IsLoadingEnded && waitingTexture)
        {
            waitingTexture = false;
            Array.ForEach(decks, cards => cards.ForEach(card => card.Texture = loader.Textures[card.Title]));
            Array.ForEach(cards, cards => cards.ForEach(card => card.Texture = loader.Textures[card.Title]));

            StartBattle();
        }
    }

    private void StartBattle()
    {
        players[0].Init(decks[0]);
        players[1].Init(decks[1]);
        battle.StartBattle(players, cards);
    }
}
