using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class QuestTrigger : MonoBehaviour {

    private QuestManager manager;
    public int questID;
    public bool startPoint, endPoint;

	// Use this for initialization
	void Start () {

        manager = FindObjectOfType<QuestManager>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (!manager.questCompleted[questID])
            {
                if(startPoint && !manager.quest[questID].gameObject.activeInHierarchy)
                {
                    manager.quest[questID].gameObject.SetActive(true);
                    manager.quest[questID].StartQuest();
                }

                if(endPoint && manager.quest[questID].gameObject.activeInHierarchy)
                {
                    manager.quest[questID].CompletedQuest();
                }
            }
        }
    }
}
