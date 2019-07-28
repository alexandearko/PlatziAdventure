using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UIManager : MonoBehaviour {

    public Slider playerHealthBar;
    public Text playerHealthText;
    public Text playerLevel;

    public HealthManager playerHealthManager;
    public CharacterStats playerStats;

	// Update is called once per frame
	void Update () {

        //por si subimos de nivel

        playerHealthBar.maxValue = playerHealthManager.maxHealth;
        playerHealthBar.value = playerHealthManager.currentHealth;

        StringBuilder sb = new StringBuilder("HP:");
        sb.Append(playerHealthManager.currentHealth);
        sb.Append("/");
        sb.Append(playerHealthManager.maxHealth);
        playerHealthText.text = sb.ToString();

        StringBuilder plvl = new StringBuilder("Level: ");
        plvl.Append(playerStats.currentLevel);
        playerLevel.text = plvl.ToString();
	}
}
