using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessDetection : MonoBehaviour
{
    // Start is called before the first frame update
    //Amount of data collect before the clip
    public int sampleWaveTotal = 64;
    private AudioClip microphoneClip;
    void Start()
    {
        MicrophoneToAudioClip();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        Debug.Log(microphoneName);
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }


    public float GetLoudnessMicrophone()
    {
        return GetLoudness(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
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