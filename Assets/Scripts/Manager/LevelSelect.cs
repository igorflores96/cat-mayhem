using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    private Button[] ButtonsLeveis;

    [SerializeField]
    private bool[] HasUnlockedLevel;

    [SerializeField]
    private Button MenuButton;



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

        for (int i = 0; i < ButtonsLeveis.Length; i++)
        {
            if(HasUnlockedLevel[i])
            {
                ButtonsLeveis[i].interactable = true;
            }
            else
            {
                ButtonsLeveis[i].interactable = false;
            }
        }
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
