using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NanaTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float maxOfStunTime = 0f;
    public FloatReference CooldownStunTime;

    [Header("Objects Settings")]
    public NanaMovement nanaAgent;
    public NanaAudioController nanaSound;

    private float freeNanaTimer;
    private float currentTimeOfStun = 0f;

    void Update()
    {
        if (nanaAgent.NanaIsStopped())
        {
            freeNanaTimer += Time.deltaTime;
            nanaSound.setNanaStunFalse();

            if (freeNanaTimer > maxOfStunTime)
            {
                freeNanaTimer = 0f;         
                nanaAgent.NanaCanMove();
            }
        }

        if(currentTimeOfStun < CooldownStunTime.Value && !nanaSound.getNanaStunStatus())
        {
            currentTimeOfStun += Time.deltaTime;
        }
        else
        {
            currentTimeOfStun = 0;
            nanaSound.setNanaStunTrue();
        }
    }

}
