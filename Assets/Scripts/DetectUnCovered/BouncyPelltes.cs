using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPelltes : MonoBehaviour
{
    public Vector3 direction;
    internal Vector2 SetPelleteVelocity()
    {
        return direction.normalized;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + direction.normalized);
    }
}
