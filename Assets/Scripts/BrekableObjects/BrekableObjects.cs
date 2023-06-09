using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrekableObjects : MonoBehaviour
{
    private bool isBroken = false;


    [Header("Colocar se for roupas")]
    [SerializeField] private ClothesLine clothes = null;


    [Header("S� se for Destrut�vel")]
    [SerializeField] private bool isDestructable = false;
    [SerializeField] private Breakable scriptDestruction;

    public UnityEvent OnBrokenObject;
    public UnityEvent OnParticlesActive;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !isBroken)
        {
            isBroken = true;

            OnBrokenObject?.Invoke();
            OnParticlesActive?.Invoke();

            if (isDestructable == true)
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
