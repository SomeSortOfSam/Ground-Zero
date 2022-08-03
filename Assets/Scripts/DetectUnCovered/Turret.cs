using UnityEngine;

public class Turret : DetectUncovered
{
    public Transform head;
    public SpriteRenderer headOver;
    public SpriteRenderer headUnder;
    private int fireTimer;
    public int framesBetweenFire;

    private void Update()
    {
        if (Uncovered)
        {
            fireTimer++;
            RaycastHit2D hit = Physics2D.Raycast(head.position, head.up);

            if (hit.collider != null && !hit.collider.CompareTag("Tile") && !hit.collider.CompareTag("Kill") && !hit.collider.CompareTag("Pickup"))
            {
                Debug.DrawLine(head.position, hit.point, Color.red);
                if (fireTimer == framesBetweenFire)
                {
                    if (hit.collider.TryGetComponent(out PlayerMovement Pm))
                    {
                        Player.InvokeDeadEvent();
                    }
                    else
                    {
                        Destroy(hit.collider.gameObject);
                    }
                    fireTimer = 0;
                }
            }
            else
            {
                Debug.DrawLine(head.position, head.position + head.up, Color.green);
                float rot = head.rotation.eulerAngles.z + 1;
                head.rotation = Quaternion.Euler(0, 0, rot);

                headOver.flipY = rot > 180;
                headUnder.flipY = rot > 180;

            }
        }
        else
        {
            fireTimer = 0;
        }
    }
}