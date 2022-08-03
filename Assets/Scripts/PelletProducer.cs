using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletProducer : MonoBehaviour
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
            GameObject pellet = Instantiate(Pellate,transform.position - transform.right, Quaternion.identity);
            pellet.GetComponent<Rigidbody2D>().velocity = -transform.right * pellet.GetComponent<Pellet>().speed;
            time = 0;
        }
    }
}
