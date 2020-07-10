using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DegredationChecker : MonoBehaviour
{
    public Slider slider;
    // Update is called once per frame
    private void Start()
    {
        Degradation.FinalDegradationEvent += ColorChange;
    }

    private void ColorChange()
    {
        slider.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = Color.black;
    }

    void Update()
    {
        slider.value = Degradation.Percent;
    }
}
