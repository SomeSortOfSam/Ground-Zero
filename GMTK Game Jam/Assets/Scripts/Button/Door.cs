using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Door : MonoBehaviour
{
    public InputButton button;
    public Collider2D collider2;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (button != null)
        {
            button.buttonChangedEvent += ChangeDoorState;
        }
    }

    private void ChangeDoorState(bool obj)
    {
        if (obj)
        {
            collider2.enabled = false;
            animator.SetBool("Open", true);
        }
        else
        {
            collider2.enabled = true;
            animator.SetBool("Open", false);
        }
    }
}
