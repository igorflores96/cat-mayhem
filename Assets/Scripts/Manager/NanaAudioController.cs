using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NanaAudioController : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoudnessDetection detector;
    public float loudnessSensibility = 100;
    public float limit = 0.1f;
    private bool canStunNana = false;

    private NanaMovement nanaScript;

    private void Awake()
    {
        nanaScript = GetComponent<NanaMovement>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            float loudness = detector.GetLoudnessMicrophone() * loudnessSensibility;

            if (loudness < limit)
            {
                Debug.Log(loudness);
                loudness = 0;
            }
            else if(canStunNana)
            {
                nanaScript.NanaCantMove();
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
