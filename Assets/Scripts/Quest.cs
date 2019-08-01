using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {

    public int questID;
    private QuestManager manager;

    public string startText, completedText;

    public void StartQuest()
    {
        manager = FindObjectOfType<QuestManager>();
        manager.ShowQuestText(startText);
    }

    public void CompletedQuest()
    {
        manager.ShowQuestText(completedText);
        manager.questCompleted[questID] = true;
        gameObject.SetActive(false);
    }
}
