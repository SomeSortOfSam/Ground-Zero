﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotorialScript : MonoBehaviour
{ 
    public string text;
    private bool hasSpoke;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasSpoke)
        {
            print(text);
            FindObjectOfType<Image>().GetComponent<Animator>().SetTrigger("Text");
            FindObjectOfType<Text>().text = text;
            hasSpoke = true;
        }
    }
}
