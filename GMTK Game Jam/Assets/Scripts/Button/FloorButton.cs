using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : InputButton
{
    public Sprite upperUp;
    public Sprite upperDown;
    public SpriteRenderer upper;
    public Sprite underUp;
    public Sprite underDown;
    public SpriteRenderer under;
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Box _) || collision.TryGetComponent(out PlayerMovment _))
        {
            upper.sprite = upperDown;
            under.sprite = underDown;
            base.OnTriggerEnter2D(collision);
        }
    }
    public override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Box _) || collision.TryGetComponent(out PlayerMovment _))
        {
            upper.sprite = upperUp;
            under.sprite = underUp;
            base.OnTriggerExit2D(collision);
        }
    }
}
