using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float enemySpeed = 1;
    private Rigidbody2D enemyRb;
    private bool isMoving;
    public float rndMin = 0.5f;
    public float rndMax = 1.5f;

    public float timeBetweenSteps;
    private float timeBetweenStepsCounter;

    public float timeToMakeStep;
    private float timeToMakeStepCounter;

    public Vector2 directionToMakeStep;

    private Animator enemyAnimator;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";


	// Use this for initialization
	void Start () {

        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();

        timeBetweenStepsCounter = timeBetweenSteps * Random.Range(rndMin, rndMax);
        timeToMakeStepCounter = timeToMakeStep * Random.Range(rndMin, rndMax);
	}
	
	// Update is called once per frame
	void Update () {

        if (isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime;
            enemyRb.velocity = directionToMakeStep;

            if(timeToMakeStepCounter < 0)
            {
                isMoving = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                enemyRb.velocity = Vector2.zero;
            }
        }
        else
        {
            timeBetweenStepsCounter -= Time.deltaTime;
            if(timeBetweenStepsCounter < 0)
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;

                directionToMakeStep = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) * enemySpeed;

            }
        }

        enemyAnimator.SetFloat(horizontal, directionToMakeStep.x);
        enemyAnimator.SetFloat(vertical, directionToMakeStep.y);
	}
}
