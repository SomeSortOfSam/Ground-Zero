using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : DetectUnCovered
{
    public Rigidbody2D rigidbody2;
    internal void Update()
    {
        if (Uncovered)
        {
            Vector2 velocity = rigidbody2.velocity;
            Vector3 direction = Player.player.transform.position - transform.position;
            velocity.x += (direction.x / direction.magnitude) *.1f;
            rigidbody2.velocity = velocity;
            transform.rotation = Quaternion.identity;
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
