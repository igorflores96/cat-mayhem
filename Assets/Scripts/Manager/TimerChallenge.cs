using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerChallenge : MonoBehaviour
{
    private float timeLevel;
    void Start()
    {
        timeLevel = 0;   
    }

    void Update()
    {
        timeLevel += Time.deltaTime;
    }
    public void CalculateTimer(float TimeToBeat)
    {
        if(timeLevel <= TimeToBeat)
        {
            Debug.Log("Ganhou a ins�gnia.");
        }
        else
        {
            Debug.Log("N�o ganhou a ins�gnia.");

        }
    }
}
