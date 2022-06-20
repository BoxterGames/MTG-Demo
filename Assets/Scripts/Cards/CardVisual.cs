using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
public class CardVisual : MonoBehaviour
{
    public virtual bool IsAnimationEnd { get { return true; } }
    public AbstractCard CardData { get; private set; }

    public Action<AbstractCard> OnPress;

    [SerializeField] private Text Title;
    [SerializeField] private Text Description;

    private RawImage image;
    private Button button;

    public virtual void Init(AbstractCard card)
    {
        button = GetComponent<Button>();
        image = GetComponent<RawImage>();
        button.onClick.AddListener(OnButtonPress);

        CardData = card;

        Description.text = card.Description;
        Title.text = card.Title;
        image.texture = card.Texture;

    }

    private void OnButtonPress()
    {
        OnPress?.Invoke(CardData);
    }
}
