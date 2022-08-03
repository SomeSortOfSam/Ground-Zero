using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : DetectUncovered
{
    public Rigidbody2D rigidbody2;
    public Animator animator;
    internal void Update()
    {
        if (Uncovered)
        {
            Vector2 velocity = rigidbody2.velocity;
            Vector3 direction = Player.player.transform.position - transform.position;
            velocity.x += (direction.x / direction.magnitude) *.1f;
            rigidbody2.velocity = velocity;
            transform.rotation = Quaternion.identity;
            if((direction.x / direction.magnitude) <= 0)
            {
                animator.SetBool("Right", false);
            }
            else
            {
                animator.SetBool("Right", true);
            }
            animator.SetBool("Dead",Player.dead);
        }
        else
        {
            rigidbody2.velocity = new Vector2(0,-9.18f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Uncovered)
        {
            Vector2 velocity = rigidbody2.velocity;
            Vector3 direction = Player.player.transform.position - transform.position;
            velocity.y += (direction.y / direction.magnitude) * .1f;
            rigidbody2.velocity = velocity;
        }
    }
}
