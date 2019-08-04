using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumenController : MonoBehaviour {

    private AudioSource audioSource;
    private float currentAudioLevel;
    public float defaultAudioLevel;
    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetAudioLevel(float newVolumen)
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        currentAudioLevel = defaultAudioLevel * newVolumen;
        audioSource.volume = currentAudioLevel;
    }
}
