﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

    public float speed = 1.5f;
    private Rigidbody2D npcRigidbody;

    public bool isWalking, isTalking;

    public float walkTime = 1.5f;
    private float walkCounter;

    public float waitTime = 3.0f;
    private float waitCounter;
    public Vector2[] walkingDirection =
    {
        new Vector2(1,0),
        new Vector2(0,1),
        new Vector2(-1,0),
        new Vector2(0,-1)
    };

    private int currentDirection;

    public BoxCollider2D villagerZone;

    private DialogManager manager;

    // Use this for initialization
    void Start () {
        manager = FindObjectOfType<DialogManager>();
        npcRigidbody = GetComponent<Rigidbody2D>();

        walkCounter = walkTime;
        waitCounter = waitTime;
	}
	
	// Update is called once per frame
	void Update () {

        if (!manager.dialogActive)
        {
            isTalking = false;
        }
        if (isTalking)
        {
            StopWalking();
            return;
        }
        if (isWalking)
        {
            if(villagerZone != null)
            {
                if(this.transform.position.x < villagerZone.bounds.min.x ||
                   this.transform.position.x > villagerZone.bounds.max.x ||
                   this.transform.position.y < villagerZone.bounds.min.y ||
                   this.transform.position.y > villagerZone.bounds.max.y)
                {
                    StopWalking();
                }
            }
            npcRigidbody.velocity = walkingDirection[currentDirection] * speed;
            walkCounter -= Time.deltaTime;
            if (walkCounter < 0)
            {
                StopWalking();
            }
        }
        else
        {
            npcRigidbody.velocity = Vector2.zero;
            waitCounter -= Time.deltaTime;
            if (waitCounter < 0)
            {
                StarWalking();
            }
        }
    }

    private void StarWalking()
    {
        isWalking = true;
        currentDirection = Random.Range(0, 4);
        walkCounter = walkTime;
    }
    private void StopWalking()
    {
        isWalking = false;
        waitCounter = waitTime;
        npcRigidbody.velocity = Vector2.zero;
    }
}
