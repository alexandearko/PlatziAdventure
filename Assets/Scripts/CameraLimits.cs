﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CameraLimits : MonoBehaviour {

	// Use this for initialization
	void Start () {

        FindObjectOfType<CameraFollow>().ChangeLimits(GetComponent<BoxCollider2D>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
