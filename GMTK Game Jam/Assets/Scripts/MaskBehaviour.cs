using Unity.Mathematics;
using UnityEngine;

public class MaskBehaviour : MonoBehaviour
{
    private int life = 100;
    public int maxSize = 10;
    private void Update()
    {
        if(life <= 0)
        {
            MaskControler.masks.Remove(transform);
            Destroy(gameObject);
        }
        float lifeSquared = Mathf.Clamp(life * life, 0, maxSize);
        transform.localScale = Vector3.one * lifeSquared;
        life--;
    }
}