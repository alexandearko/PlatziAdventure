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
            CharacterStats stats = collision.gameObject.GetComponent<CharacterStats>();
            int totalDamage = damage - stats.defenseLevels[stats.currentLevel];
            if (totalDamage <= 0)
            {
                totalDamage = 1;
            }

            collision.gameObject.GetComponent<HealthManager>().Damagecharacter(totalDamage);

            Instantiate(hurtAnimation, this.transform.position, this.transform.rotation);
            var clone = (GameObject)Instantiate(damageNumber, this.transform.position, this.transform.rotation);

            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;

        }
    }
}
