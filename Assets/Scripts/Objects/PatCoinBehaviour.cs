using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatCoinBehaviour : MonoBehaviour, IDataPersistence
{

    private int _sceneIndex;

    private bool _hasCollect;
    private bool _saveCoin;
    public void LoadData(GameData data)
    {
        data.CoinCollect.TryGetValue("Level" + _sceneIndex, out _hasCollect);
        if(_hasCollect)
        {
            gameObject.SetActive(false);
        }

    }

    public void SaveData(GameData data)
    {
        if(_saveCoin && _hasCollect)
        {
            if (data.CoinCollect.ContainsKey("Level" + _sceneIndex))
            {
                data.CoinCollect.Remove("Level" + _sceneIndex);
            }

            data.CoinCollect.Add("Level" + _sceneIndex, true);
        }
    }


    private void Awake()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        _hasCollect = false;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 0.4f));
    }

    public void CoinCollect()
    {
        _hasCollect = true;
        gameObject.SetActive(false);
    }

    public void OnCompleteLevel()
    {
        _saveCoin = true;
    }
}
