using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    Vector2 target;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        target = player.position;
        float distance = Vector2.Distance(transform.position, target);
        if (distance > .5f)
        {
            Vector2 pos = Vector2.Lerp(target, transform.position, .9f);
            transform.position = new Vector3(pos.x, pos.y, -10);
        }
        else
        {
            transform.position = new Vector3(target.x, target.y, -10);
        }
    }
}
