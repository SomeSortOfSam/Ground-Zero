﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskControler : MonoBehaviour
{
    public Sprite sprite;
    public Transform gun;
    public Animator gunAnimator;
    public GameObject mask;
    public int maxSize = 10;
    public static List<Transform> masks = new List<Transform>();

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 nitey = gun.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, nitey); 
        gun.rotation = rotation;
        if (Input.GetMouseButtonDown(0))
        {
            gunAnimator.SetTrigger("Fire");
            Player.fidget = 0;
            GameObject obj = Instantiate(mask, Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10)), Quaternion.identity);
            obj.GetComponent<MaskBehaviour>().maxSize = maxSize;
            masks.Add(obj.transform);
        }
    }
}
