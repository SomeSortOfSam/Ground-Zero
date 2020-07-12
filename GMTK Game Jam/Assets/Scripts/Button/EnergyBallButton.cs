using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallButton : Button
{
    public Animator animator;
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pellte"))
        {
            animator.SetBool("Down", true);
            base.OnTriggerEnter2D(collision);
        }
    }
}
