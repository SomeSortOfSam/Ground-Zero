using Unity.Mathematics;
using UnityEngine;

public class MaskBehaviour : MonoBehaviour
{
    private int life = 100;
    int size = 0;
    public int maxSize = 10;
    private void Update()
    {
        if(life <= 0)
        {
            MaskControler.spriteMasks.Remove(GetComponent<SpriteMask>());
            Destroy(gameObject);
        }
        float lifeSquared = Mathf.Clamp(life * life,0,size);

        transform.localScale = Vector3.one * lifeSquared;
        Degradation.Percent += .001f;
        life--;
        size++;
        size = Mathf.Clamp(size,0,maxSize);
    }
}