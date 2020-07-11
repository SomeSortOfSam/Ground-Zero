using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public event Action<bool> buttonChangedEvent;
    public Animator animator;
    public bool buttonDown;
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        buttonDown = true;
        animator.SetBool("Down", true);
        buttonChangedEvent(buttonDown);
    }
    public virtual void OnTriggerExit2D(Collider2D collider)
    {
        buttonDown = false;
        animator.SetBool("Down", false);
        buttonChangedEvent(buttonDown);
    }
}
