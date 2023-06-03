using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public SerializableDictionary<string, bool> LevelsTimerReached;

    public SerializableDictionary<string, bool> LevelsUnlocked;

    public SerializableDictionary<string, bool> CoinCollect;



    public GameData()
    {
        LevelsTimerReached = new SerializableDictionary<string, bool>();
        CoinCollect = new SerializableDictionary<string, bool>();
        LevelsUnlocked = new SerializableDictionary<string, bool>();
        LevelsUnlocked.Add("Level1", true); //O level 1 deve sempre estar disponível.
    }
}
