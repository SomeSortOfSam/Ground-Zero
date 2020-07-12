using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskControler : MonoBehaviour
{
    public Sprite sprite;
    public Transform gun;
    public Animator gunAnimator;
    public GameObject spriteMask;
    public static GameObject staticSpriteMask;
    public static List<SpriteMask> masks = new List<SpriteMask>();

    public void Start()
    {
        masks.Clear();
        staticSpriteMask = spriteMask;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 nitey = gun.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, nitey); 
        gun.rotation = rotation;
        if (Input.GetMouseButtonDown(0))
        {
            gunAnimator.SetTrigger("Fire");
            Player.fidget = 0;
            StartCoroutine(DegradationCorutine(mousePos));
        }
    }

    private IEnumerator DegradationCorutine(Vector2 mousePos)
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        System.Random random = new System.Random();
        float size = Mathf.Lerp(.5f,2, Degradation.Percent);
        SpriteMask mask = SummonMask(mousePos, size);
        yield return new WaitForSeconds(.1f);
        for(float i = 0; i < Degradation.Percent && mask != null; i += .1f)
        {
            size /= 2;
            SummonMask(mousePos + (new Vector2(random.Next(-1,1),random.Next(-1,1)).normalized * mask.bounds.extents), size);
            yield return new WaitForSeconds(.1f);
        }
    }

    public static SpriteMask SummonMask(Vector2 mousePos, float maxSize)
    {
        GameObject obj = Instantiate(staticSpriteMask, mousePos, Quaternion.identity);
        obj.GetComponent<MaskBehaviour>().maxSize = maxSize;
        SpriteMask mask = obj.GetComponent<SpriteMask>();
        masks.Add(mask);
        return mask;
    }
}
