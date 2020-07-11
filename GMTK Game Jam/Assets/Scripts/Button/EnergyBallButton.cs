using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallButton : Button
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pellte"))
        {
            base.OnTriggerEnter2D(collision);
        }
    }
    public override void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Pellte"))
        {
            base.OnTriggerExit2D(collider);
        }
    }
}
