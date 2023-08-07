using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public SerializableDictionary<string, bool> LevelsTimerReached;

    public SerializableDictionary<string, bool> LevelsUnlocked;

    public SerializableDictionary<string, bool> CoinCollect;

    public SerializableDictionary<string, bool> LevelsBeaten;

    public float MusicVolume;
    public float EffectsVolume;
    public int SelectedMicDevice;


    public GameData()
    {
        MusicVolume = EffectsVolume = 0.50f;
        SelectedMicDevice = 0;
        LevelsTimerReached = new SerializableDictionary<string, bool>();
        CoinCollect = new SerializableDictionary<string, bool>();
        LevelsBeaten = new SerializableDictionary<string, bool>();
        LevelsUnlocked = new SerializableDictionary<string, bool>();
        LevelsUnlocked.Add("Level1", true); //O level 1 deve sempre estar disponível.
        
    }
}
