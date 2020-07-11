using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectUnCovered : MonoBehaviour
{
    public SpriteRenderer over;
    public SpriteRenderer under;
    public event Action<bool> UncoveredChangedEvent;
    public bool Uncovered { get => GetIsUncovered(); }

    private bool GetIsUncovered()
    {
        foreach(Transform mask in MaskControler.masks)
        {
            if (Vector2.Distance(transform.position,mask.position) < 1)
            {
                return true;
            }
        }
        return false;
    }

    bool prevFrame;
    internal virtual void Update()
    {
        if(prevFrame != Uncovered)
        {
            UncoveredChangedEvent?.Invoke(Uncovered);
            prevFrame = Uncovered;
        }
    }
    private void OnDrawGizmos()
    {
        if (Uncovered)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawSphere(transform.position, .1f);
    }
}
