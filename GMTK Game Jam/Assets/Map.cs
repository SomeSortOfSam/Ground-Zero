using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public List<Pickup> pickups = new List<Pickup>();
    public static Pickup[] staticPickups;
    // Start is called before the first frame update
    void Awake()
    {
        Degradation.totalPickups = pickups.Count;
        staticPickups = pickups.ToArray();
    }

    internal static void Reset()
    {
        foreach(Pickup pickup in staticPickups)
        {
            pickup.gameObject.SetActive(true);
        }
    }
}
