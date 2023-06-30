using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] 
    private AudioMixer audioMixer;

    [SerializeField]
    private Slider musicSlider;

    [SerializeField]
    private Slider effectSlider;

    private float _musicVolume;
    private float _effectVolume;


    public void SaveData(GameData data)
    {
        data.MusicVolume = _musicVolume;
        data.EffectsVolume = _effectVolume;
    }

    public void LoadData(GameData data)
    {
        _musicVolume = data.MusicVolume;
        _effectVolume = data.EffectsVolume;
    }


    private void Start()
    {
        if(!DataPersistenceManager._instance.HasGameData()) // Primeira vez jogando.
        {
            _musicVolume = _effectVolume = 0.50f;
        }
        

        audioMixer.SetFloat("MusicVolume", Mathf.Log10(_musicVolume) * 20);
        audioMixer.SetFloat("EffectsVolume", Mathf.Log10(_effectVolume) * 20);

        musicSlider.value = _musicVolume;
        effectSlider.value = _effectVolume;

    }

    public void SetMusicVolume(float level)
    {
        _musicVolume = level;
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(_musicVolume) * 20);
        DataPersistenceManager._instance.SaveGame();

    }

    public void SetEffectsVolume(float level)
    {
        _effectVolume = level;
        audioMixer.SetFloat("EffectsVolume", Mathf.Log10(_effectVolume) * 20);
        DataPersistenceManager._instance.SaveGame();
    }
}
