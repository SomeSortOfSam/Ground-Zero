using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoverChecker : MonoBehaviour
{
    public DetectUnCovered covered;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        covered.UncoveredChangedEvent += ChangeText;
    }

    private void ChangeText(bool covered)
    {
        if (covered)
        {
            text.text = "Its uncovered";
        }
        else
        {
            text.text = "nah, covered";
        }
    }
}
