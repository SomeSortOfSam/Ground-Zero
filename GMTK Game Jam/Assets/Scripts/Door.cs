using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.buttonChangedEvent += ChangeDoorState;
    }

    private void ChangeDoorState(bool obj)
    {
        if (obj)
        {

        }
    }
}
