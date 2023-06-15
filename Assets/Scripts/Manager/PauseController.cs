using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{

    [SerializeField]
    private GameObject _pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            if (!(Time.timeScale == 0))
            {
                Time.timeScale = 0;
                _pauseMenu.SetActive(true);

            }
            else
            {
                Time.timeScale = 1;
                _pauseMenu.SetActive(false);
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
