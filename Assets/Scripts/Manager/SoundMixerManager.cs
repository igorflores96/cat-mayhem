using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] 
    private AudioMixer audioMixer;

    [SerializeField]
    private Slider musicSlider;

    [SerializeField]
    private Slider effectSlider;


    private void Start()
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 1) * 20));
        audioMixer.SetFloat("EffectsVolume", Mathf.Log10(PlayerPrefs.GetFloat("EffectsVolume", 1) * 20));

        if(PlayerPrefs.HasKey("MusicVolume") || PlayerPrefs.HasKey("EffectsVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            effectSlider.value = PlayerPrefs.GetFloat("EffectsVolume");
        }
        else
        {
            musicSlider.value = 0.75f;
            effectSlider.value = 0.75f;
        }


    }

    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(level) * 20);
        PlayerPrefs.Save();
    }

    public void SetEffectsVolume(float level)
    {
        audioMixer.SetFloat("EffectsVolume", Mathf.Log10(level) * 20);
        PlayerPrefs.Save();
    }
}
