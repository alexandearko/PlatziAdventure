﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public int value;
    private CoinsManager manager;

	// Use this for initialization
	void Start () {
        manager = FindObjectOfType<CoinsManager>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            manager.AddMoney(value);
            Destroy(gameObject);
        }
    }
}
