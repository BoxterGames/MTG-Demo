using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Effect that apply to card
/// </summary>
public abstract class AbstractEffect
{
    public delegate void ApplyEffect(AbstractCard card);

    public abstract void Init();

    public abstract ApplyEffect GetEffect();
}