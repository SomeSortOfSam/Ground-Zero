using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : DetectUncovered
{
    public Rigidbody2D rigidbody2;
    public float speed;

    public void Update()
    {
        if (Uncovered)
        {
            rigidbody2.velocity = (FindObjectOfType<PlayerMovement>().transform.position - transform.position).normalized * speed; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent(out BouncyPellet bounce))
        {
            rigidbody2.velocity = bounce.SetPelletVelocity() * speed;
        }
        else
        {
            Destroy(gameObject);
            if (collision.gameObject.GetComponent<Turret>())
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
