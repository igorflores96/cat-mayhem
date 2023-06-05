using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WinConditions : MonoBehaviour, IDataPersistence
{
    [Header("Objects")]
    public GameObject[] brokenObjectsInScene;

    [Header("Canvas Settings")]
    public Image caosBar;

    private float caosCount;
    private float lerpSpeedBar;
    private int _sceneIndex;
    private bool _levelComplete;

    public UnityEvent OnWinLevel;

    public void LoadData(GameData data)
    {

    }

    public void SaveData(GameData data)
    {
        if(_levelComplete)
        {
            if (data.LevelsUnlocked.ContainsKey("Level" + _sceneIndex))
            {
                data.LevelsUnlocked.Remove("Level" + _sceneIndex);
            }

            data.LevelsUnlocked.Add("Level" + _sceneIndex, true);
        }

    }



    private void Start()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if(_sceneIndex == 11)//Temos no total 10 indexes, com mais um vai dar erro.
        {
            _sceneIndex = 10;
        }
        
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
            _levelComplete = true;
            OnWinLevel?.Invoke();
            ChangeScene();
        }
    }

    void CaosBarFiller()
    {
        caosBar.fillAmount = Mathf.Lerp(caosBar.fillAmount, caosCount / brokenObjectsInScene.Length, lerpSpeedBar);
    }

    private void ChangeScene()
    {
        SceneManager.LoadSceneAsync("WinScreen");
    }

    public void OnLoseGame()
    {
        _levelComplete = false;
        SceneManager.LoadSceneAsync("loseScreen");
    }
}
