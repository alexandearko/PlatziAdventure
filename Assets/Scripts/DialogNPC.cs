using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : MonoBehaviour {

    public string[] dialog;
    private DialogManager manager;
    private bool playerInTheZone;
    public PlayerController player;

	// Use this for initialization
	void Start () {
        manager = FindObjectOfType<DialogManager>();
	}

    // Update is called once per frame
    void Update () {
		
        if(playerInTheZone && Input.GetKeyDown(KeyCode.Return))
        {
            manager.ShowDialog(dialog);
            if(gameObject.GetComponentInParent<NPCMovement>() != null)
            {
                gameObject.GetComponentInParent<NPCMovement>().isTalking = true;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerInTheZone = true;
        }
    }
}
