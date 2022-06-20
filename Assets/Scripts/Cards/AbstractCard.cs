using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCard
{
    public readonly string Title;
    public readonly string Description;
    public Texture2D Texture;

    protected AbstractCard(string title, string description)
    {
        Title = title;
        Description = description;
    }
}
