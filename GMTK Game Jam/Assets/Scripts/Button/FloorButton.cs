using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : Button
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Box _))
        {
            base.OnTriggerEnter2D(collision);
        }
    }
    public override void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Box _))
        {
            base.OnTriggerExit2D(collider);
        }
    }
}
