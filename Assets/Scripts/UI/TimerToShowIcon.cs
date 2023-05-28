using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerToShowIcon : MonoBehaviour
{
    private bool canCount = false;

    private float Timer;

    public UnityEvent OnDesativeIcon;
    void Update()
    {
        if (canCount)
        {
            Timer += Time.deltaTime;

            if (Timer > 1f)
            {
                Timer = 0f;
                canCount = false;
                OnDesativeIcon?.Invoke();
            }
        }
    }

    public void CanStartCount()
    {
        canCount = true;
    }
}
