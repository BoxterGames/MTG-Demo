using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEffect : AbstractEffect
{
    public override void Init() { }

    public override ApplyEffect GetEffect()
    {
        return (card) => Debug.Log(card.Title + " nothing do");
    }
}
