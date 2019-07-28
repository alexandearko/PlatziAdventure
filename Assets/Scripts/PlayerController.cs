﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 4.0f;
    private bool walking = false;
    public Vector2 lastMovement = Vector2.zero;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";
    private const string attackingState = "Attacking";
    private Animator animator;
    private Rigidbody2D playerRigidbody;

    public static bool playerCreated;
    public string nextPlaceName;

    private bool attacking = false;
    public float attackTime;
    private float attackTimeCounter;
    public bool playerTalking;

	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();

        if (!playerCreated)
        {
            playerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        playerTalking = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (playerTalking)
        {
            playerRigidbody.velocity = Vector2.zero;
            return;
        }

        //d = v * t

        walking = false;

        if (Input.GetMouseButtonDown(0))
        {
            attacking = true;
            attackTimeCounter = attackTime;
            playerRigidbody.velocity = Vector2.zero;
            animator.SetBool(attackingState, true);
        }

        if (attacking)
        {
            attackTimeCounter -= Time.deltaTime;
            if(attackTimeCounter < 0)
            {
                attacking = false;
                animator.SetBool(attackingState, false);
            }
        }
        else
        {
            if ((Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f) || (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f))
            {
                walking = true;
                lastMovement = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical));

                playerRigidbody.velocity = lastMovement.normalized * speed * Time.deltaTime;
            }               
        }

        if (!walking)
        {
            playerRigidbody.velocity = Vector2.zero;
        }

        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical, Input.GetAxisRaw(vertical));

        animator.SetBool(walkingState, walking);
        animator.SetFloat(lastHorizontal, lastMovement.x);
        animator.SetFloat(lastVertical, lastMovement.y);

    }
}
