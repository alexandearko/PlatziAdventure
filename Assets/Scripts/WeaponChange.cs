using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour {

    private WeaponManager manager;
    public int weaponID;
    public bool equipOnStart;
	// Use this for initialization
	void Start () {
        manager = FindObjectOfType<WeaponManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
