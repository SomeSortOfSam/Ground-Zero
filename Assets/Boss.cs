using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 3;
    public Animator animator;
    public GameObject pickUp;
    public event Action<bool> Stage2Event;
    public event Action<bool> Stage3Event;
    public List<Door> doors2 = new List<Door>();
    public List<Door> doors3 = new List<Door>();
    private void Start()
    {
        foreach (Door door in doors2)
        {
            door.ChangeDoorState(true);
            Stage2Event += door.ChangeDoorState;
        }
        foreach (Door door in doors3)
        {
            door.ChangeDoorState(true);
            Stage3Event += door.ChangeDoorState;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pellet"))
        {
            animator.SetTrigger("harm");
            health--;
            if (health == 2)
            {
                Stage2Event?.Invoke(false);
            }
            else if (health == 1)
            {
                Stage3Event?.Invoke(false);
            }
            else if (health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        animator.SetBool("Dead", true);
        Instantiate(pickUp, transform.position, Quaternion.identity);
    }
}
