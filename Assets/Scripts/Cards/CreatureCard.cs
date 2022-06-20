using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureCard : AbstractCard
{
    public int Attack;
    public int HitPoint;
    public int ManaPoint;

    public CreatureCard(string title, string description, int attack, int hitPoint, int manapoint) : base(title, description)
    {
        Attack = attack;
        HitPoint = hitPoint;
        ManaPoint = manapoint;
    }
}
