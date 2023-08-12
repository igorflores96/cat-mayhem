using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    private Button[] ButtonsLeveis;

    [SerializeField]
    private bool[] HasUnlockedLevel;

    [SerializeField]
    private Button MenuButton;

    private bool _cutscenePlayed;


    public void LoadData(GameData data)
    {
        for(int i = 0 + 1; i <= ButtonsLeveis.Length; i++)
        {
            data.LevelsUnlocked.TryGetValue("Level" + i.ToString(), out HasUnlockedLevel[i-1]);
            if(HasUnlockedLevel[i-1])
            {
                ButtonsLeveis[i-1].interactable = true;
            }
            else
            {
                ButtonsLeveis[i - 1].gameObject.SetActive(false);
            }
        }

        _cutscenePlayed = data.SeeCutscene;
    }

    public void SaveData(GameData data)
    {
        data.SeeCutscene = _cutscenePlayed;
    }

    private void Awake()
    {
        MenuButton.onClick.AddListener(OnMenuButtonClick);
    }
    private void OnMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToLevel(int levelIndex)
    {
        StartCoroutine(WaitToChange(levelIndex));
    }

    public void LevelOne()
    {
        if(_cutscenePlayed)
        {
            StartCoroutine(WaitToChange(1));
        }
        else
        {
            _cutscenePlayed = true;
            SceneManager.LoadScene(14); //Index da cena que vai a cutscene.
        }
    }

    IEnumerator WaitToChange(int levelIndex)
    {
        
        yield return new WaitForSeconds(.6f);
        SceneManager.LoadScene("Level" + levelIndex);
    }
}
