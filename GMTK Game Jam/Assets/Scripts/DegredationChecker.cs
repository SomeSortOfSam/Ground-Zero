using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DegredationChecker : MonoBehaviour
{
    public Slider slider;
    public static Slider staticSlider;
    // Update is called once per frame
    private void Start()
    {
        staticSlider = slider;
        Degradation.FinalDegradationEvent += ColorChangeBlack;
    }

    private void ColorChangeBlack()
    {
        slider.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = Color.black;
    }

    public static void ColorChangeRed()
    {
        staticSlider.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = Color.red;
    }

    void Update()
    {
        slider.value = Degradation.Percent;
    }
}
