using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

[RequireComponent(typeof(SpriteRenderer))]
public class DropShadow : MonoBehaviour
{
    public Vector2 ShadowOffset;
    public Material ShadowMaterial;

    GameObject shadowGameobject;

    void Start()
    {
        

        //create a new gameobject to be used as drop shadow
        shadowGameobject = new GameObject("Shadow");
        shadowGameobject.transform.parent = transform;

        shadowGameobject.transform.localPosition = ShadowOffset;
        shadowGameobject.transform.localRotation = Quaternion.identity;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer sr = shadowGameobject.AddComponent<SpriteRenderer>();
        sr.sprite = spriteRenderer.sprite;
        sr.material = ShadowMaterial;

        sr.sortingLayerName = spriteRenderer.sortingLayerName;
        sr.sortingOrder = spriteRenderer.sortingOrder - 1;

    }

    private void LateUpdate()
    {
        shadowGameobject.transform.localPosition = ShadowOffset;
    }
}
