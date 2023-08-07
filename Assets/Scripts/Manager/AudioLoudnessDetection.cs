using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessDetection : MonoBehaviour, IDataPersistence
{
    // Start is called before the first frame update
    //Amount of data collect before the clip
    public int sampleWaveTotal = 64;
    private string microphoneName;
    private AudioClip microphoneClip;
    private int currentMic;


    public void LoadData(GameData data)
    {
        currentMic = data.SelectedMicDevice;
    }

    public void SaveData(GameData data)
    {

    }

    private void Start()
    {
        microphoneName = Microphone.devices[currentMic];
        Debug.Log("Recebeu do save o valor: " + currentMic);
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
        Debug.Log(microphoneName);
    }

    public float GetLoudnessMicrophone()
    {   
        return GetLoudness(Microphone.GetPosition(microphoneName), microphoneClip);
    }

    //clip position represents the point in a audio wave we need to verify the loudness
    public float GetLoudness(int clipPosition, AudioClip clip)
    {
        //The start position for the part we need detect loudness
        int startPosition = clipPosition - sampleWaveTotal;

        //sometimes, there's a bug in the audio that the beginning starts with -1, we fix this 
        //always starting with 0
        if (startPosition < 0)
        {
            startPosition = 0;
        }

        //Basically, we get the data of the wave in array
        float[] waveData = new float[sampleWaveTotal];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0;

        for (int i = 0; i < sampleWaveTotal; i++)
        {
            //Goes all wave analising between 0 -1 and 1 the sound, in this case, 0 is no sound
            totalLoudness += Mathf.Abs(waveData[i]);
        }

        return totalLoudness / sampleWaveTotal;
    }
}