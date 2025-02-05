// Importing necessary namespaces
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using JS.enemyStats;
using JS.EnemyMult;

public class EnemyAI : MonoBehaviour
{
    [Header("Enemy Stats")]
    private GameObject enemyStats;

    // Move Speed
    public float moveSpeed;

    // Attack Range and can the enemy hit the player
    public float attackRange = 0.25f;
    public bool canAttackPlayer = false;

    // Animator
    public Animator animator;
    float attackCooldown;

    // Attack Area circle
    public Transform circleOrigin;
    public float circleRadius;

    // Player Health script
    private PlayerHealth playerHealth;

    // Player Controller GameObject
    private GameObject playerController;

    // Damage values
    [Header("Damage values")]
    public float damage;
    private bool attackBlocked;
    protected float hit;

    protected float enemyCurrentDamage;

    // Crit values
    [Header("Crit values")]
    protected float enemyCritChange;
    protected float enemyCritMult;

    public float enemyMult;
    public GameObject enemyMulti;
    protected string colliderName;

    public void Awake()
    {
        // Getting player's health so we can deal damage to them
        playerHealth = GetComponentInParent<PlayerHealth>();

        enemyStats = GameObject.Find("EnemyScaler");

        // Getting the enemy stats so we can use them in the AI
        moveSpeed = enemyStats.GetComponent<EnemyStats>().speed;
        enemyCurrentDamage = enemyStats.GetComponent<EnemyStats>().damage;
        enemyCritChange = enemyStats.GetComponent<EnemyStats>().critChance;
        enemyCritMult = enemyStats.GetComponent<EnemyStats>().critDamage;

        // Getting the player controller so we can chase the player
        playerController = GameObject.Find("Player_Controller");

        enemyMulti = GameObject.Find("EnemyMultiplier");

        CheckCollider();

        attackRange = 1f * enemyMult;
        // Setting the attack cooldown
        attackBlocked = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerController.transform);
        // Getting the distance to the player
        float distanceToPlayer = GetDistanceToPlayer();

        // If the distance to the player is greater than the attack range then chase the player
        if (distanceToPlayer >= attackRange)
        {
            ChasePlayer();
        }
        else
        {
            AttackPlayer();
        }
    }

    // Getting the distance to the player
    private float GetDistanceToPlayer()
    {
        return Vector3.Distance(playerController.transform.position, transform.position);
    }

    // Chasing the player
    private void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerController.transform.position, moveSpeed * Time.deltaTime);
    }

    // Attacking the player
    public void AttackPlayer()
    {
        Debug.Log("Attacking Player");
        // If the attack is blocked then return
        if (attackBlocked)
            return;

        attackCooldown = 1;

        // animator.SetTrigger("Attack");

        // Getting the damage value
        hit = Damage();
        Debug.Log("Enemy Hit: " + hit);

        // Checking if the player is in the attack area
        foreach (Collider col in Physics.OverlapSphere(circleOrigin.position, circleRadius))
        {
            Debug.Log(col.name);

            PlayerHealth health;

            // If the player is in the attack area then deal damage to them
            if (health = col.GetComponent<PlayerHealth>())
            {
                health.TakeDamage(hit);
            }
        }

        attackBlocked = true;

        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        // Wait for the attack cooldown
        yield return new WaitForSeconds(attackCooldown);
        Debug.Log("Attack Cooldown: " + attackCooldown);
        attackBlocked = false;
    }

    // Getting the damage value
    public float Damage()
    {
        enemyCurrentDamage = enemyStats.GetComponent<EnemyStats>().damage;
        // If the attack is blocked then return 0
        if (!attackBlocked)
        {
            // Getting the damage value
            damage = Random.Range((enemyCurrentDamage / 4), enemyCurrentDamage);

            // Checking if the enemy crits
            if (Random.Range(0, 100) <= enemyCritChange)
            {
                damage = enemyCurrentDamage * (1 + enemyCritMult);
                return damage;
            }
            else
            {
                return damage;
            }
        }
        else
        {
            return 0;
        }
    }

    // Drawing the attack area circle
    // This is for debugging purposes
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, circleRadius);
    }

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
                Debug.Log("enemy mult: " + enemyMult);
            }
        }
        else
        {
            Debug.LogWarning("Collider not found on the enemy!");
            enemyMult = 1f;
        }
    }
}
