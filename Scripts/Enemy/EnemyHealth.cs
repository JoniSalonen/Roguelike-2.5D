// Importing necessary namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using JS.Inventory;
using JS.enemyStats;
using JS.EnemyMult;
using Unity.VisualScripting;

public class EnemyHealth : MonoBehaviour
{
    // Indicates if the enemy is dead
    [SerializeField]
    private bool isDead = false;

    // Health-related variables
    [Header("Health")]
    public int maxHealth;
    public float currentHealth;

    // Coins the enemy drops upon death
    [Header("Coins")]
    public int coins;

    // Damage reduction percentage
    [Header("Damage Reduction")]
    public float dr;

    // Event triggered when the enemy is hit
    [Header("Events")]
    public UnityEvent<GameObject> OnHitWithReference;

    [Header("Enemy Multiplier")]
    public float enemyMult;

    public Animator animator;

    // Reference to the player's inventory
    private Inventory inventory;

    private EnemyAI enemyAI;

    // Reference to the enemy stats object
    private GameObject enemyStats;

    public GameObject enemyMulti;

    protected string colliderName;

    // Start is called before the first frame update
    public void Start()
    {
        // Find the enemy stats object in the scene
        enemyStats = GameObject.Find("EnemyScaler");
        inventory = GameObject.Find("Player_Controller").GetComponent<Inventory>();
        enemyMulti = GameObject.Find("EnemyMultiplier");
        enemyAI = GetComponent<EnemyAI>();

        CheckCollider();

        // Initialize enemy stats
        coins = enemyStats.GetComponent<EnemyStats>().coins;
        maxHealth = (int)(enemyStats.GetComponent<EnemyStats>().health * enemyMult);

        dr = enemyStats.GetComponent<EnemyStats>().damageReduction;
        currentHealth = maxHealth;
    }

    // Check if the enemy has a collider and get its name
    public void CheckCollider()
    {
        Collider col = GetComponent<Collider>();

        if (col != null)
        {
            // Split the collider name to get the enemy type
            // enemeies are named as "EnemyName(Clone)" so we split the name at "("
            string[] splitArray = col.name.Split('(');
            colliderName = splitArray[0].Trim();

            // check if the enemy has a multiplier
            if (enemyMulti != null)
            {
                enemyMult = enemyMulti.GetComponent<EnemyMultiplier>().GetMultiplier(colliderName);
                // Debug.Log("enemy mult: " + enemyMult);
            }
        }
        else
        {
            Debug.LogWarning("Collider not found on the enemy!");
            enemyMult = 1f;
        }
    }

    // Method to handle taking damage
    public void TakeDamage(float damage, GameObject sender)
    {
        // If the enemy is already dead, destroy the game object
        if (isDead)
        {
            StartCoroutine(DeathAnimation());
            return;
        }

        // Ignore damage from the same layer (e.g., friendly fire)
        if (sender.layer == gameObject.layer)
        {
            return;
        }

        // Calculate the actual damage after applying damage reduction
        currentHealth -= damage - (damage * (0.01f * dr));

        // If the enemy is still alive, invoke the hit event
        if (currentHealth > 0)
        {
            OnHitWithReference?.Invoke(sender);
        }
        else
        {
            // If the enemy is dead, invoke the hit event, update inventory, and destroy the game object
            OnHitWithReference?.Invoke(sender);
            isDead = true;
            StartCoroutine(DeathAnimation()); 
        }
    }

    IEnumerator DeathAnimation()
    {
        Destroy(enemyAI);
        animator.SetBool("Death", true);
        yield return new WaitForSeconds(3);
        inventory.coins += coins;
        Destroy(gameObject);
    }
}
