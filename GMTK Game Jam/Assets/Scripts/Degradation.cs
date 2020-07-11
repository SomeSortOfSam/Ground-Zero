using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public static class Degradation
{
    public static event Action FinalDegradationEvent;
    public static float Percent { get => percent; set => Increment(value); }
    static float percent;

    private static void Increment(float value)
    {
        if (value >= 1)
        {
            FinalDegradationEvent?.Invoke();
            percent = 1;
        }
        else
        {
            percent = value;
        }
    }
    public static void Reset()
    {
        Percent = 0;
    }
}
