using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WinConditions : MonoBehaviour
{
    [Header("Objects")]
    public GameObject[] brokenObjectsInScene;

    [Header("Canvas Settings")]
    public Image caosBar;

    private float caosCount;
    private float lerpSpeedBar;

    public UnityEvent OnWinLevel;

    private void Start()
    {
        caosCount = 0;
    }

    private void Update()
    {
        lerpSpeedBar = 3f * Time.deltaTime;
        CaosBarFiller();
    }

    public void CountCaos()
    {
        caosCount++;

        if (caosCount == brokenObjectsInScene.Length)
        {
            OnWinLevel?.Invoke();
        }
    }

    void CaosBarFiller()
    {
        caosBar.fillAmount = Mathf.Lerp(caosBar.fillAmount, caosCount / brokenObjectsInScene.Length, lerpSpeedBar);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("WinScreen");
    }
}
