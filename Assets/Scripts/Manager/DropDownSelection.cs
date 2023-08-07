using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownSelection : MonoBehaviour, IDataPersistence
{
   

    [SerializeField] private TMP_Dropdown dropDownMenu;

    private int micSelected;


    public void SaveData(GameData data)
    {
        data.SelectedMicDevice = micSelected;
    }

    public void LoadData(GameData data)
    {
        micSelected = data.SelectedMicDevice;
    }



    void OnEnable()
    {
        dropDownMenu.ClearOptions();

        for (int i = 0; i < Microphone.devices.Length; i++)
        {
            var option = new TMP_Dropdown.OptionData(Microphone.devices[i]);
            dropDownMenu.options.Add(option);
        }
    }


    public void HandleSelection(int MicSelected)
    {
        micSelected = MicSelected;
        DataPersistenceManager._instance.SaveGame();
    }
}
