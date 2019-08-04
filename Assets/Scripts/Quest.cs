using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {

    public int questID;
    public int questExp;
    private QuestManager manager;

    public string startText, completedText;
    public bool needsItem;
    public string itemNeeded;

    public bool needsEnemy;
    public string enemyName;
    public int numberOfEnemies;
    private int enemiesKilled;

    public void StartQuest()
    {
        manager = FindObjectOfType<QuestManager>();
        manager.ShowQuestText(startText);
    }
    void Update()
    {
        if(needsItem && manager.itemCollected.Equals(itemNeeded))
        {
            manager.itemCollected = null;
            CompletedQuest();
        }

        if(needsEnemy && manager.enemyKilled.Equals(enemyName))
        {
            manager.enemyKilled = null;
            enemiesKilled++;
            if(enemiesKilled >= numberOfEnemies)
            {
                CompletedQuest();
            }
        }
    }

    public void CompletedQuest()
    {
        manager.ShowQuestText(completedText + "\n Exp: " + questExp.ToString());
        manager.questCompleted[questID] = true;
        gameObject.SetActive(false);
        GameObject.Find("Player").GetComponent<CharacterStats>().AddExperience(questExp);
    }
}
