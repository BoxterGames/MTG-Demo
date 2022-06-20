using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dummy player that skip turn
/// </summary>
public class DummyPlayer : BattlePlayer
{
    public override void StartTurn()
    {
        OnCardChoose?.Invoke(null);
    }
}
