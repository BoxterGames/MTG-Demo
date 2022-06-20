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

[System.Serializable]
public class CardChooser
{
    public bool ChooseOpponentCard;
    public ChooseType Type;

    public CardChooser(ChooseType type, bool chooseOpponentCard)
    {
        Type = type;
        ChooseOpponentCard = chooseOpponentCard;
    }

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