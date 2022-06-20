using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCard : AbstractCard
{
    public CardChooser Chooser;
    public AbstractEffect Effect;

    public EffectCard(string title, string description, CardChooser choose, AbstractEffect effect) : base(title, description)
    {
        Chooser = choose;
        Effect = effect;
    }
}
