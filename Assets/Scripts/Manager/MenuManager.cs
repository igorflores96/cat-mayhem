using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayIsClicked()
    {
        SceneManager.LoadScene("Level1");
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
