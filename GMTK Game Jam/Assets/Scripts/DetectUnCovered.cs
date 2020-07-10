using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectUnCovered : MonoBehaviour
{
    public SpriteRenderer over;
    public SpriteRenderer under;
    public event Action<bool> UncoveredChangedEvent;
    public bool Uncovered { get => GetIsUncovered(under); }

    private bool GetIsUncovered(SpriteRenderer under)
    {
        foreach(SpriteMask mask in MaskControler.spriteMasks)
        {
            if (mask.bounds.Contains(under.transform.position))
            {
                return true;
            }
        }
        return false;
    }

    bool prevFrame;
    private void Update()
    {
        if(prevFrame != Uncovered)
        {
            UncoveredChangedEvent?.Invoke(Uncovered);
            prevFrame = Uncovered;
        }
    }
}
