using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private IntReference CurrentLevel;

    public void PlayIsClicked()
    {
        CurrentLevel.Value = 1;
        SceneManager.LoadScene((int)CurrentLevel.Value);
        CurrentLevel.Value++;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene((int)CurrentLevel.Value);
        CurrentLevel.Value++;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene((int)CurrentLevel.Value);
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
