using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {

    public int questID;
    private QuestManager manager;

    public string startText, completedText;
	// Use this for initialization
	void Start () {

        manager = FindObjectOfType<QuestManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartQuest()
    {
        manager.ShowQuestText(startText);
    }

    public void CompletedQuest()
    {
        manager.ShowQuestText(completedText);
        manager.questCompleted[questID] = true;
        gameObject.SetActive(false);
    }
}
