using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDamage : AbstractEffect
{
    private int damage;

    public override void Init()
    {
        damage = Random.Range(-2, 9);
    }

    public override ApplyEffect GetEffect()
    {
        return CardDamage;

    }

    private void CardDamage(AbstractCard card)
    {
        if(card is CreatureCard)
        {
            ((CreatureCard)card).HitPoint -= damage;
        }
    }
}
