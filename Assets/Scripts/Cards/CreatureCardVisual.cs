using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureCardVisual : CardVisual
{
    [Header("Creature visual")]
    [SerializeField] private Text mana;
    [SerializeField] private Text hit;
    [SerializeField] private Text attack;

    public override bool IsAnimationEnd => Time.time > animationEnd && newHitPoint == creature.HitPoint;

    private CreatureCard creature;

    private int lastHit;
    private int newHitPoint;
    private float animationTime = 0.5f;

    private float animationEnd;

    public override void Init(AbstractCard card)
    {
        base.Init(card);

        creature = (CreatureCard)card;

        newHitPoint = lastHit = creature.HitPoint;
    }

    private void Update()
    {
        UpdateData();

        if (newHitPoint != creature.HitPoint)
        {
            lastHit = newHitPoint;
            newHitPoint = creature.HitPoint;
            animationEnd = Time.time + animationTime;
        }
    }

    private void UpdateData()
    {
        float path = Mathf.Clamp01((animationEnd - Time.time) / animationTime);
        float val = Mathf.Lerp(newHitPoint, lastHit, path);

        hit.text = val.ToString("f0");
        mana.text = creature.ManaPoint.ToString();
        attack.text = creature.Attack.ToString();
    }
}
