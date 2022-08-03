using System;
using UnityEngine;

public class DegradationBehaviour : MonoBehaviour
{
    public Transform holder;
    public GameObject icon;
    public ButtonScript button;
    private void Start()
    {
        Degradation.holder = holder;
        Degradation.icon = icon;
        Degradation.button = button;
    }
}
public static class Degradation
{
    public static event Action FinalDegradationEvent;
    public static float Percent { get
        {
            float pickups = Degradation.pickups;
            float totalPickups = Degradation.totalPickups;
            float output = pickups / totalPickups;
            if (output == 1)
            {
                FinalDegradationEvent?.Invoke();
            }
            return output;
        }
    }
    public static int pickups;
    public static int totalPickups;
    public static Transform holder;
    public static GameObject icon;
    public static ButtonScript button;

    public static void Reset()
    {
        pickups = 0;
    }
}
