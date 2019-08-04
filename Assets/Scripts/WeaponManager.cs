using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public Weapon[] weapon;
    public int currentWeapon;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(1);
        }
	}
    public void ChangeWeapon(int newWeapon)
    {
        weapon[currentWeapon].gameObject.SetActive(false);
        currentWeapon = newWeapon;
        weapon[currentWeapon].gameObject.SetActive(true);
        Debug.Log(weapon[currentWeapon]);
    }

}   
