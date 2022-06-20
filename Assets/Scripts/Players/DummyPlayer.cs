using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayer : BattlePlayer
{
    public override void StartTurn()
    {
        OnCardChoose?.Invoke(null);
    }
}
