using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that generates deck and default cards on map 
/// </summary>
public abstract class AbstractGenerator
{
    /// <summary>
    /// Generate cards in hand
    /// </summary>
    public abstract List<AbstractCard> GenerateDeck();

    /// <summary>
    /// Generate cards on map
    /// </summary>
    public abstract List<AbstractCard> GenerateMapCards();
}
