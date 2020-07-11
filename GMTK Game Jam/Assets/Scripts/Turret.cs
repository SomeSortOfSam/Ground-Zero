using UnityEngine;

public class Turret: DetectUnCovered
{
    public Transform head;
    public GameObject muzzleFlare;
    public GameObject bulletHit;
    private void Update()
    {
        if (Uncovered)
        {
            RaycastHit2D hit = Physics2D.Raycast(head.position, head.up);
            if (hit.collider != null && !hit.collider.CompareTag("Tile"))
            {
                Instantiate(muzzleFlare, hit.point, Quaternion.Euler(-head.up));
            }
        }
    }
}