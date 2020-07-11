using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectUnCovered : MonoBehaviour
{
    public event Action<bool> UncoveredChangedEvent;
    public bool Uncovered { get => GetIsUncovered() && !Player.dead; }
    bool prevFrame = false;

    private bool GetIsUncovered()
    {
        bool output = false;
        foreach(SpriteMask mask in MaskControler.masks)
        {
            if (mask.bounds.Contains(transform.position))
            {
                output = true;
            }
        }
        if (prevFrame != output)
        {
            UncoveredChangedEvent?.Invoke(output);
            prevFrame = output;
        }
        return output;
    }
}
