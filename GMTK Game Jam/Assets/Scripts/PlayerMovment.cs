﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Player.player = this;
        Player.DieEvent += Degradation.Reset;
        Player.DieEvent += delegate { MaskControler.SummonMask(transform.position, 150); };
        Player.DieEvent += Die;
        Degradation.FinalDegradationEvent += Player.InvkoeDieEvent;
    }
    // Update is called once per frame
    void Update()
    {
        if (Player.dead)
        {
            return;
        }
        Movement();
        Jump();
        transform.rotation = Quaternion.identity;
    }

    private void Movement()
    {
        Vector2 velocity = rigidbody2.velocity;
        velocity.x = Input.GetAxisRaw("Horizontal") * speed;
        rigidbody2.velocity = velocity;
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
    }

    private void Jump()
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
            Player.groundedNum = 40;
            Player.fidget++;
            if (Player.fidget == 550 || Player.fidget == 551)
            {
                animator.SetBool("figdet", true);
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
        if (Player.Grounded && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)))
        {
            Vector2 velocity = rigidbody2.velocity;
            velocity.y = speed;
            rigidbody2.velocity = velocity;
        } else
        {
            Vector2 velocity = rigidbody2.velocity;
            velocity.y = -9.18f;
            rigidbody2.velocity = velocity;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Player.dead)
        {
            if (collision.CompareTag("Mask"))
            {
                Player.InvkoeDieEvent();
            }
            else if (collision.CompareTag("Pickup"))
            {
                collision.gameObject.SetActive(false);
                Degradation.pickups++;
            }
        }
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
        SceneManager.UnloadSceneAsync(FindObjectOfType<Map>().index + 1);
        if (Degradation.Percent >= 1)
        {
            SceneManager.LoadSceneAsync(FindObjectOfType<Map>().index + 2, LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadSceneAsync(FindObjectOfType<Map>().index + 1, LoadSceneMode.Additive);
        }
        yield return new WaitForSeconds(2);
        transform.position = startPos.position;
        rigidbody2.gravityScale = 1;
        Player.dead = false;
    }
}

public static class Player
{
    public static PlayerMovment player;
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