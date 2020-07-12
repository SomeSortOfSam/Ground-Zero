using System;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    public Sprite empty;
    public Sprite full;
    public Image icon;
    internal void Fill()
    {
        icon.sprite = full;
    }
    internal void Empty()
    {
        icon.sprite = empty;
    }
}