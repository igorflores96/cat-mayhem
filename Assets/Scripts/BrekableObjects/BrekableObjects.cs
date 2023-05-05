using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrekableObjects : MonoBehaviour
{
    private bool isBroken = false;
    [SerializeField] private ClothesLine clothes = null;
    [SerializeField] private bool isDestructable = false;
    [SerializeField] private Breakable scriptDestruction;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !isBroken)
        {
            isBroken = true;

            if(isDestructable == true)
            {
                scriptDestruction.BreakTheThing();
            }

            if (clothes?.isclothesLine == true)
            {
                clothes.SetUsePhysics();
            }
        }
    }

    public bool IsBrokenStatus()
    {
        return isBroken;
    }

    public Vector3 GetPositionObject()
    {
        return gameObject.transform.position;
    }
}
