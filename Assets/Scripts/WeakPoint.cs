using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour {

    public GameObject hurtAnimation;
    public GameObject damageNumber;
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DamagePlayer(int damage)
    {
        Instantiate(hurtAnimation, this.transform.position, this.transform.rotation);
        var clone = (GameObject)Instantiate(damageNumber, this.transform.position, this.transform.rotation);

        clone.GetComponent<DamageNumber>().damagePoints = damage;
    }
}
