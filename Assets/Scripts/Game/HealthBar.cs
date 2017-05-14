using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//! Manages the health bar, updating it appropriately 
public class HealthBar : MonoBehaviour {

    public Image currentHealthImage;

    private float maxHealth;
    private float damageTaken;
    private float currentHealth;

	void Start () {
        maxHealth = damageTaken = carController.life;
        UpdateHealthBar();
    }
	
    private void UpdateHealthBar()
    {
        currentHealth = damageTaken / maxHealth;
        currentHealthImage.rectTransform.localScale = new Vector2(currentHealth, 1);
    }

    public void CauseDamage (int damage)
    {
        damageTaken -= damage;
        UpdateHealthBar();
    }
}
