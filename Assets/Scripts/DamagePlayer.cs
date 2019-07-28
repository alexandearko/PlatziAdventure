using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    public int damage;
    public GameObject damageNumber;
    public GameObject hurtAnimation;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<HealthManager>().Damagecharacter(damage);

            Instantiate(hurtAnimation, this.transform.position, this.transform.rotation);
            var clone = (GameObject)Instantiate(damageNumber, this.transform.position, this.transform.rotation);

            clone.GetComponent<DamageNumber>().damagePoints = damage;

        }
    }
}
