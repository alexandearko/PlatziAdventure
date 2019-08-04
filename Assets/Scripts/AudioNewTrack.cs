using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioNewTrack : MonoBehaviour {

    private AudioManager manager;
    public int newTrackID;
    public bool playOnStart;
	// Use this for initialization
	void Start () {

        manager = FindObjectOfType<AudioManager>();
        if (playOnStart)
        {
            manager.PlayNewTrack(newTrackID);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            manager.PlayNewTrack(newTrackID);
            gameObject.SetActive(false);
        }
    }
}
