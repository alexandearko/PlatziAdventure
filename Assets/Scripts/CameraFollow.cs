using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private GameObject followTarget;
    [SerializeField]
    private Vector3 targetPosition;
    [SerializeField]
    private float cameraSpeed = 4.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, this.transform.position.z);

        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, cameraSpeed * Time.deltaTime);
	}
}
