﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallButton : InputButton
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pellet"))
        {
            base.OnTriggerEnter2D(collision);
        }
    }

    public override void OnTriggerExit2D(Collider2D collider)
    {

    }
}
