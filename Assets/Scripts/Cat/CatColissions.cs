using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CatColissions : MonoBehaviour
{
    public UnityEvent OnCatIsCatch;
    public UnityEvent OnCoinCollect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Nana")
        {
            OnCatIsCatch?.Invoke();
        }
        
        if (other.gameObject.tag == "Coin")
        {
            OnCoinCollect?.Invoke();
        }

    }
}
