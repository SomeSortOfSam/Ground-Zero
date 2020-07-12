using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Door : MonoBehaviour
{
    public InputButton button;
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
            animator.SetBool("Open", true);
        }
        else
        {
            animator.SetBool("Open", false);
        }
    }
}
