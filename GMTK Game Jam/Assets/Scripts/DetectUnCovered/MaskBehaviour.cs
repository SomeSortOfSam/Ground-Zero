using Unity.Mathematics;
using UnityEngine;

public class MaskBehaviour : MonoBehaviour
{
    private int life = 200;
    private int InverseLife { get => 200 - life; }
    public float maxSize = 1;

    private void Update()
    {
        if(life <= 0)
        {
            MaskControler.masks.Remove(transform.GetComponent<SpriteMask>());
            Destroy(gameObject);
        }
        float lifeSquared = life < 50 ? Mathf.Clamp(life * life, 0, maxSize) : Mathf.Clamp(InverseLife * InverseLife, 0, maxSize);
        Vector3 size = Vector3.one * lifeSquared;
        transform.localScale = size;
        life--;
    }
}