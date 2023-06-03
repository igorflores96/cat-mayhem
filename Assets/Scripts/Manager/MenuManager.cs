using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Button _continueButton;

    private void Start()
    {
        if(!DataPersistenceManager._instance.HasGameData())
        {
            _continueButton.interactable = false;
        }
    }

    public void OnConfirmeNewGame()
    {
        SceneManager.LoadSceneAsync("LevelSelect");
        DataPersistenceManager._instance.NewGame();
    }

    public void OnContinueButtonIsClicked()
    {
        SceneManager.LoadSceneAsync("LevelSelect");
    }

    public void OnWinLevelIsClicked()
    {
        SceneManager.LoadSceneAsync("LevelSelect");
    }

    public void ChooseLevel(int LevelSelected)
    {
        SceneManager.LoadScene(LevelSelected);
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
