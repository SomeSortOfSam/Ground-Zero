using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : DetectUnCovered
{
    public Rigidbody2D rigidbody2;
    public Transform target;
    internal override void Update()
    {
        base.Update();

        if (Uncovered)
        {
            Vector2 velocity = rigidbody2.velocity;
            Vector3 direction = target.position - transform.position;
            velocity.x = direction.x / direction.magnitude;
            rigidbody2.velocity = velocity;
        }
    }
}
