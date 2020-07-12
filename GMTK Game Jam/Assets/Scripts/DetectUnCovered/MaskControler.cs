using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MaskControler : MonoBehaviour
{
    public Sprite sprite;
    public SpriteRenderer gun;
    public SpriteRenderer gunOutline;
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
        Vector3 nitey = gun.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, nitey); 
        gun.transform.rotation = rotation;
        gun.flipX = Mathf.Sign(nitey.x) == -1;
        gunOutline.flipX = Mathf.Sign(nitey.x) == -1;
        if (Input.GetMouseButtonDown(0))
        {
            gunAnimator.SetTrigger("Fire");
            Player.fidget = 0;
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
            SummonMask(mousePos, .5f * (Degradation.pickups + 1));
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
