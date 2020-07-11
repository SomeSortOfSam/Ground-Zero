using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = .1f;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public float rayLeght = .25f;
    public Transform startPos;
    public Rigidbody2D rigidbody2;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
        Player.DieEvent += Degradation.Reset;
    }
    // Update is called once per frame
    void Update()
    {
        if (Player.dead)
        {
            return;
        }
        Vector3 pos = transform.position;
        pos = Movement(pos);
        pos.y += Jump();
        transform.position = pos;
        transform.rotation = Quaternion.identity;
    }

    private Vector3 Movement(Vector3 pos)
    {
        pos.x += Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            animator.SetBool("walking", true);
            spriteRenderer.flipX = true;
            Player.fidget = 0;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            animator.SetBool("walking", true);
            spriteRenderer.flipX = false;
            Player.fidget = 0;
        }
        else
        {
            animator.SetBool("walking", false);
        }

        return pos;
    }

    private float Jump()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down);
        if (hitInfo.collider != null && hitInfo.distance < rayLeght)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + (Vector3.down * rayLeght), Color.green);
        }
        if (hitInfo.distance < rayLeght)
        {
            Player.groundedNum = 100;
            Player.fidget++;
            if (Player.fidget == 550 || Player.fidget == 551)
            {
                animator.SetBool("figdet",true);
            }
            else if (Player.fidget > 1000)
            {
                animator.SetBool("figdet", false);
                Player.fidget -= 1000;
            }
        }
        else if (Player.Grounded)
        {
            Player.groundedNum--;
            Player.fidget = 0;
        }
        if (Player.Grounded && Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            return speed;
        }
        return 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.InvkoeDieEvent();
        Die();
    }

    private void Die()
    {
        StartCoroutine(DieEnumeoraor());
    }

    private IEnumerator DieEnumeoraor()
    {
        animator.SetTrigger("Death");
        rigidbody2.gravityScale = 0;
        rigidbody2.velocity *= .1f;
        yield return new WaitForSeconds(2);
        transform.position = startPos.position;
        rigidbody2.gravityScale = 1;
        Player.dead = false;
    }
}

public static class Player
{
    public static int groundedNum;
    public static bool Grounded { get => groundedNum >= 0; }
    public static int fidget;
    public static bool dead;
    public static event Action DieEvent;
    public static void InvkoeDieEvent()
    {
        dead = true;
        DieEvent?.Invoke();
    }
}