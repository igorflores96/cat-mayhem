using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameplayStart : MonoBehaviour
{
    public UnityEvent OnGameplayStart;
    void Awake()
    {
        OnGameplayStart?.Invoke();
    }
}
