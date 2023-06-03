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
                ButtonsLeveis[i-1].interactable = false;
            }
        }

    }

    public void SaveData(GameData data)
    {

    }

    private void Awake()
    {
        ButtonsLeveis[0].onClick.AddListener(OnButtonLevelOneClick);
        ButtonsLeveis[1].onClick.AddListener(OnButtonLevelTwoClick);
        ButtonsLeveis[2].onClick.AddListener(OnButtonLevelThreeClick);
        ButtonsLeveis[3].onClick.AddListener(OnButtonLevelFourClick);
        ButtonsLeveis[4].onClick.AddListener(OnButtonLevelFiveClick);
        ButtonsLeveis[5].onClick.AddListener(OnButtonLevelSixClick);
        ButtonsLeveis[6].onClick.AddListener(OnButtonLevelSevenClick);
        ButtonsLeveis[7].onClick.AddListener(OnButtonLevelEightClick);
        ButtonsLeveis[8].onClick.AddListener(OnButtonLevelNineClick);
        ButtonsLeveis[9].onClick.AddListener(OnButtonLevelTenClick);
        MenuButton.onClick.AddListener(OnButtonMenuClick);
    }

    private void OnButtonLevelOneClick()
    {
        SceneManager.LoadScene("Level1");
    }
    private void OnButtonLevelTwoClick()
    {
        SceneManager.LoadScene("Level2");
    }
    private void OnButtonLevelThreeClick()
    {
        SceneManager.LoadScene("Level3");
    }
    private void OnButtonLevelFourClick()
    {
        SceneManager.LoadScene("Level4");
    }
    private void OnButtonLevelFiveClick()
    {
        SceneManager.LoadScene("Level5");
    }
    private void OnButtonLevelSixClick()
    {
        SceneManager.LoadScene("Level6");
    }
    private void OnButtonLevelSevenClick()
    {
        SceneManager.LoadScene("Level 7");
    }
    private void OnButtonLevelEightClick()
    {
        SceneManager.LoadScene("Level8");
    }
    private void OnButtonLevelNineClick()
    {
        SceneManager.LoadScene("Level9");
    }
    private void OnButtonLevelTenClick()
    {
        SceneManager.LoadScene("Level10");
    }
    private void OnButtonMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
