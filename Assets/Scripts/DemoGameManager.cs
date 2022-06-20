using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

/// <summary>
/// Main class that start battle. Use to prepare cards, decks and textures.
/// </summary>
public class DemoGameManager : MonoBehaviour
{
    /// <summary>
    /// You can use any generators for each player, later they can use some data like players full-deck, npc difficulty, emivroment.
    /// </summary>
    private AbstractGenerator[] generator = new AbstractGenerator[]
    {
        new MapGeneratorExample(),
        new DeckGeneratorExample()
    };

    /// <summary>
    /// Players action manager. I can be like npc/pc, may be players with special skills.
    /// </summary>
    [SerializeField] private BattlePlayer[] players = new BattlePlayer[2];
    
    /// <summary>
    /// Battle manager class.
    /// </summary>
    [SerializeField] private BattleManager battle;

    /// <summary>
    /// Texture loader.
    /// </summary>
    [SerializeField] private TextureLoader loader;

    /// <summary>
    /// Decks that appear to user in hand [] depends on players count. List<> depends on cards count.
    /// </summary>
    private List<AbstractCard>[] decks;

    /// <summary>
    /// Cards on table.
    /// </summary>
    private List<AbstractCard>[] cards;


    private bool waitingTexture = true;

    private void Start()
    {
        decks = new List<AbstractCard>[] { generator[0].GenerateDeck(), generator[1].GenerateDeck() };
        cards = new List<AbstractCard>[] { generator[0].GenerateMapCards(), generator[1].GenerateMapCards() };

        List<string> titles = new List<string>();

        //Make list of titles, repeated card will check in loader. 
        //TODO: use inr id instead.
        Array.ForEach(decks, i => titles.AddRange(i.Select(c => c.Title)));
        Array.ForEach(cards, i => titles.AddRange(i.Select(c => c.Title)));

        loader.LoadTexture(titles);
    }

    private void Update()
    {
        //All textures loaded.
        if (loader.IsLoadingEnded && waitingTexture)
        {
            waitingTexture = false;
            //Set texture to CardData
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
