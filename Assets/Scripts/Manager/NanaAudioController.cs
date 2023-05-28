using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NanaAudioController : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoudnessDetection detector;
    public float loudnessSensibility = 100;
    public float limit = 0.1f;
    private bool canStunNana = false;

    public UnityEvent OnNanaStun;

    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            float loudness = detector.GetLoudnessMicrophone() * loudnessSensibility;

            if (loudness < limit)
            {
                loudness = 0;
            }
            else if(canStunNana)
            {
                OnNanaStun?.Invoke();
            }
        }
    }

    public bool getNanaStunStatus()
    {
        return canStunNana;
    }

    public void setNanaStunTrue()
    {
        canStunNana = true;
    }

    public void setNanaStunFalse()
    {
        canStunNana = false;
    }
}
