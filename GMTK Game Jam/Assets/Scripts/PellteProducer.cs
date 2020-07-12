using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PellteProducer : MonoBehaviour
{
    public InputButton button;
    public GameObject Pellate;
    int time;
    public int FramesBetweenShots = 30;

    // Update is called once per frame
    void Update()
    {
        time++;
        if(time >= FramesBetweenShots && (button == null || (button != null && button.buttonDown)))
        {
            GameObject pellate = Instantiate(Pellate,transform.position - transform.right, Quaternion.identity);
            pellate.GetComponent<Rigidbody2D>().velocity = -transform.right * pellate.GetComponent<Pellte>().speed;
            time = 0;
        }
    }
}
