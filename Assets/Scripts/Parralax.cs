﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    public Transform player;
    Vector3 prevPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position - prevPos * .01f;
        transform.position += Vector3.forward * 10;
        prevPos = player.position;
    }
}
