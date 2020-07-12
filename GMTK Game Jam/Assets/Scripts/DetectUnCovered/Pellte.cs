using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellte : DetectUnCovered
{
    public Rigidbody2D rigidbody2;
    public float speed;

    public void Update()
    {
        if (Uncovered)
        {
            rigidbody2.velocity = (FindObjectOfType<PlayerMovment>().transform.position - transform.position).normalized * speed; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent(out BouncyPelltes bounce))
        {
            rigidbody2.velocity = bounce.SetPelleteVelocity() * speed;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
