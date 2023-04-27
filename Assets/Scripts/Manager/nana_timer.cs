using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class nana_timer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float currentTime;
    public float maxStunTime = 0f;
    public float stunTimeGap = 0f;
    public float stunCurrentTime = 0f;

    [Header("Objects Settings")]
    public nana_movement nanaAgent;
    public nana_audioController nanaSound;

    [Header("Canvas Settings")]
    public TextMeshProUGUI textStun;
    public TextMeshProUGUI textTimerStun;


    // Update is called once per frame
    void Update()
    {

        textStun.text = "Pode Stunar: " + nanaSound.getNanaStunStatus().ToString();
        textTimerStun.text = "Contagem Tempo Stun: " + stunCurrentTime.ToString("0.0");

        if (nanaAgent.NanaIsStopped())
        {
            currentTime += Time.deltaTime;
            
            if (currentTime > maxStunTime)
            {
                currentTime = 0f;
                nanaSound.setNanaStunFalse();
                nanaAgent.NanaCanMove();
            }
        }

        if(stunCurrentTime < stunTimeGap && !nanaSound.getNanaStunStatus())
        {
            stunCurrentTime += Time.deltaTime;
        }
        else
        {
            stunCurrentTime = 0;
            nanaSound.setNanaStunTrue();
        }
    }

}
