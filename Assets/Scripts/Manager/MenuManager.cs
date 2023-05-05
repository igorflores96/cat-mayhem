using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayIsClicked()
    {
        SceneManager.LoadScene((int)ScenesNames.gameScene);
    }

    public void InstructionsIsCliked()
    {
        SceneManager.LoadScene((int)ScenesNames.creditsScene);
    }

    public void MenuIsClicked()
    {
        SceneManager.LoadScene((int)ScenesNames.mainMenuScene);

    }

    public void QuitIsClicked()
    {
        Debug.Log("Saiu do jogo.");
        Application.Quit();
    }
}
