using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMenu : MonoBehaviour
{

    public static DontDestroyMenu instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("LevelSelect") && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MainMenu"))
        {
            Destroy(gameObject);
        }
    }

}
