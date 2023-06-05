using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CatColissions : MonoBehaviour
{
    public UnityEvent OnCatIsCatch;
    public UnityEvent OnCoinCollect;
    public UnityEvent OnCollisionOnBox;

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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PaperBox")
        {
            OnCollisionOnBox?.Invoke();
        }

    }
}
