using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatColissions : MonoBehaviour
{
    public bool isCatch = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Nana")
        {
            Debug.Log("Avó pegou o gato!");
            isCatch = true;
        }
    }
}
