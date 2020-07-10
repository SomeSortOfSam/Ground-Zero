using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskControler : MonoBehaviour
{
    public Sprite sprite;
    public int maxSize = 10;
    public static List<SpriteMask> spriteMasks = new List<SpriteMask>();

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            GameObject mask = new GameObject("Mask");
            mask.tag = "Mask";
            mask.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
            mask.AddComponent<MaskBehaviour>().maxSize = maxSize;
            SpriteMask spriteMask = mask.AddComponent<SpriteMask>();
            spriteMask.sprite = sprite;
            spriteMasks.Add(spriteMask);
        }
    }
}
