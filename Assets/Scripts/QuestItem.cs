using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class QuestItem : MonoBehaviour {

    public int questID;
    private QuestManager manager;
    public string itemName;

	// Use this for initialization
	void Start () {

        manager = FindObjectOfType<QuestManager>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (manager.quest[questID].gameObject.activeInHierarchy && !manager.questCompleted[questID])
            {
                manager.itemCollected = itemName;
                gameObject.SetActive(false);
            }
        }
    }

}
