using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesLine : MonoBehaviour
{
    public Rigidbody clothesRb;
    public bool isclothesLine;
    public ClothesLine otherClothesLine;

    private bool isPhysicsSet = false;

    void Start()
    {
        isclothesLine = true;
    }

    public void SetUsePhysics()
    {
        if (!isPhysicsSet && clothesRb != null)
        {
            clothesRb.isKinematic = false;
            isPhysicsSet = true;

            if (otherClothesLine != null)
            {
                otherClothesLine.SetUsePhysics();
            }
        }
    }
}
