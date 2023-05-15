using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{

    public GameObject fractured;
    public MeshRenderer objectDestroyed;
    public float breakforce = 2.2f;

    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            BreakTheThing();
        }
    }
    public void BreakTheThing()
    {
        GameObject frac = Instantiate(fractured,transform.position,transform.rotation);
        foreach(Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (rb.transform.position - transform.position).normalized * breakforce;
            rb.AddForce(force);
        }
        objectDestroyed.enabled = false;
    }
}
