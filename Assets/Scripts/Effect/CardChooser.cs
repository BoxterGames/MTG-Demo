using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum ChooseType
{
    None,
    All,
    Random
}

/// <summary>
/// Class that  choose card for apply effect
/// </summary>
[System.Serializable]
public class CardChooser
{
    /// <summary>
    /// Whose card select
    /// </summary>
    public bool ChooseOpponentCard;

    /// <summary>
    /// How much card select.
    /// </summary>
    public ChooseType Type;

    public CardChooser(ChooseType type, bool chooseOpponentCard)
    {
        Type = type;
        ChooseOpponentCard = chooseOpponentCard;
    }

    /// <summary>
    /// Calculate List<card> for apply effect
    /// </summary>
    /// <param name="playerId"></param>
    /// <param name="cards"></param>
    /// <returns></returns>
    public List<AbstractCard> GetCards(int playerId, List<AbstractCard>[] cards)
    {
        int id = ChooseOpponentCard ? (playerId + 1) % cards.Length : playerId;

        switch (Type)
        {
            case ChooseType.All:
                return cards[id].ToList();

            case ChooseType.Random:

                int cardID = Random.Range(0, cards[id].Count);
                return new List<AbstractCard>() { cards[id][cardID] };

            default:
                return new List<AbstractCard>();
        }
    }
}