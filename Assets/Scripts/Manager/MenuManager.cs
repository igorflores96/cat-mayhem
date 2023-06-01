using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private int currentLevel;
    public void PlayIsClicked()
    {   
       SceneManager.LoadScene("LevelSelect");
    }

    public void ChooseLevel(int LevelSelected)
    {
        currentLevel = LevelSelected;
        SceneManager.LoadScene(LevelSelected);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(currentLevel);
    }
    public void MenuIsClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitIsClicked()
    {
        Application.Quit();
    }
}
