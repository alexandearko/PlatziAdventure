using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public GameObject dialogBox;
    public Text dialogText;
    public bool dialogActive;

    public string[] dialogLines;
    public int currentDialogLine;
    private PlayerController playerController;

	// Use this for initialization
	void Start () {
        playerController = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentDialogLine++;
        }
        if(currentDialogLine >= dialogLines.Length)
        {
            dialogActive = false;
            dialogBox.SetActive(false);
            currentDialogLine = 0;
            playerController.playerTalking = false;
        }
        else
        {
            dialogText.text = dialogLines[currentDialogLine];
        }
	}

    public void ShowDialog(string[] lines)
    {
        dialogActive = true;
        dialogBox.SetActive(true);
        currentDialogLine = 0;
        dialogLines = lines;
        playerController.playerTalking = true;
    }
}
