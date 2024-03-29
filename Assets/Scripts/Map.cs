﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public List<Pickup> pickups = new List<Pickup>();
    public Transform startPos;
    public int index;

    // Start is called before the first frame update
    void Awake()
    {
        Degradation.totalPickups = pickups.Count;
        foreach (Transform child in Degradation.holder)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < pickups.Count; i++)
        {
            Instantiate(Degradation.icon, Degradation.holder);
        }
        Player.player.transform.position = startPos.position;
    }

}
