using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public event Action<bool> buttonChangedEvent;
    public bool buttonDown;
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        buttonDown = true;
        buttonChangedEvent?.Invoke(buttonDown);
    }
    public virtual void OnTriggerExit2D(Collider2D collider)
    {
        buttonDown = false;
        buttonChangedEvent?.Invoke(buttonDown);
    }
}
