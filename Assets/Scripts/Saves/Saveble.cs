using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saveble : MonoBehaviour
{
    [SerializeField]
    private IntReference SceneNumber;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
