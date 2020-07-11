using System;

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
    internal static int pickups;
    internal static int totalPickups;

    public static void Reset()
    {
        pickups = 0;
    }
}
