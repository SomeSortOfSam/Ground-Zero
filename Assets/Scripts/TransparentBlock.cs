using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentBlock : MonoBehaviour
{
    public Collider2D collider2;

    // Update is called once per frame
    void Update()
    {
        collider2.enabled = !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.S));
    }
}
