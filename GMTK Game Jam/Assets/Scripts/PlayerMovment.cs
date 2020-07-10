using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = .1f;
    public SpriteRenderer spriteRenderer;
    int grounded;
    public float rayLeght = .25f;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            spriteRenderer.flipX = false;
        }
        pos.y += Jump();
        transform.position = pos;
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
            grounded = 100;
        }
        else if (grounded >= 0)
        {
            grounded--;
        }
        if (grounded >= 0 && Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            return speed;
        }
        return 0;
    }
}
