// Importing necessary namespaces
using JS.CharacterStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JS.HealtBar;
using JetBrains.Annotations;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    // Player health-related variables
    public int maxHealth;
    public float currentHealth;
    public float healthRegen;
    public int previousMaxHealth;
    public float armour;
    public float realDamage;
    public float lifeLeech;

    // Screens that will be enabled/disabled when the player dies
    public Canvas deathScreen;
    public Canvas hudScreen;
    public Canvas statScreen;
    public Canvas pauseMenuScreen;

    // Health bar UI element
    public Health_Bar healthBar;

    // Character stats
    [SerializeField]
    private Character characterStats;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize character stats
        characterStats = GetComponent<Character>();

        // Set initial health and stats values
        maxHealth = (int)characterStats.Life.Value;
        healthRegen = characterStats.LifeRegen.Value + 0.5f;
        armour = characterStats.Armour.Value;
        lifeLeech = characterStats.LifeSteal.Value;

        currentHealth = maxHealth;

        // Initialize health bar
        healthBar.SetMaxHealth(maxHealth);
        healthBar.UpdateHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Update max health and health regeneration values
        maxHealth = (int)characterStats.Life.Value;
        healthRegen = characterStats.LifeRegen.Value;

        // Adjust current health if max health has increased
        if (previousMaxHealth < maxHealth)
        {
            int healthDifference = maxHealth - previousMaxHealth;
            currentHealth += healthDifference;
            previousMaxHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        // Ensure current health does not exceed max health
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        // Regenerate health
        Regen();

        // Update health bar
        healthBar.UpdateHealth(currentHealth);
    }

    // Regenerate health over time
    public void Regen()
    {
        // Cap health regeneration rate
        if (healthRegen >= 200)
        {
            healthRegen = 200;
        }

        // Increase current health based on regeneration rate
        currentHealth += healthRegen * Time.deltaTime;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    // Handle taking damage
    public void TakeDamage(float damage)
    {
        // Cap armor value
        if (armour > 9)
        {
            armour = 9;
        }

        // Calculate real damage after considering armor
        if (armour > 0)
        {
            realDamage = damage - (damage * (armour / 10));
        }
        else
        {
            realDamage = damage;
        }

        Debug.Log("Real Damage: " + realDamage);
        currentHealth -= realDamage;

        // Check if player health has dropped to zero or below
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Add life to the current health
    public void AddLife(float life)
    {
        currentHealth += life;
    }

    // Handle player death
    public void Die()
    {
        // Disable HUD, stats, and pause menu screens
        hudScreen.enabled = false;
        statScreen.enabled = false;
        pauseMenuScreen.enabled = false;
        // Enable death screen
        deathScreen.enabled = true;
        // Pause the game
        Time.timeScale = 0;
    }
}
