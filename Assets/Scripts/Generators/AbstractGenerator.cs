using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGenerator
{
    public abstract List<AbstractCard> GenerateDeck();
    public abstract List<AbstractCard> GenerateMapCards();
}
