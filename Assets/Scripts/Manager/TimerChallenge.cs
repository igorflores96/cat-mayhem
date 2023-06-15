using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerChallenge : MonoBehaviour, IDataPersistence
{
    private float _timeLevel;
    private bool _beatTheTime;
    private string _sceneName;

    [SerializeField]
    private TextMeshProUGUI _timerText;

    void Awake()
    {
        _timeLevel = 0;
        _beatTheTime = false;
        _sceneName = SceneManager.GetActiveScene().name;
    }

    public void LoadData(GameData data)
    {
        data.LevelsTimerReached.TryGetValue(_sceneName, out _beatTheTime);
        if(_beatTheTime)
        {
            _beatTheTime = true;
        }
    }

    public void SaveData(GameData data)
    {
        if(data.LevelsTimerReached.ContainsKey(_sceneName))
        {
            data.LevelsTimerReached.Remove(_sceneName);
        }

        data.LevelsTimerReached.Add(_sceneName, _beatTheTime);
    }

    void Update()
    {
        _timeLevel += Time.deltaTime;
        _timerText.text = _timeLevel.ToString("00");
    }
    public void CalculateTimer(float TimeToBeat)
    {
        if(_timeLevel <= TimeToBeat)
        {
            _beatTheTime = true;
        }
    }
}
