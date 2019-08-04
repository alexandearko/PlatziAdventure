using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeManager : MonoBehaviour {

    private AudioVolumenController[] audios;
    public float maxVolumeLevel;
    public float currentVolumLevel;
	// Use this for initialization
	void Start () {

        audios = FindObjectsOfType<AudioVolumenController>();
        ChangeGlobalAudioVolume();
	}
    void Update()
    {
        ChangeGlobalAudioVolume();
    }

    public void ChangeGlobalAudioVolume()
    {
        if(currentVolumLevel >= maxVolumeLevel)
        {
            currentVolumLevel = maxVolumeLevel;
        }

        foreach(AudioVolumenController avc in audios)
        {
            avc.SetAudioLevel(currentVolumLevel);
        }
    }
}
