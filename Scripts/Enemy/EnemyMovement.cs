using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;

    public float moveSpeed = 1.5f;

    public float attackRange = 1f;
    public bool canAttackPlayer = false;


    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = GetDistanceToPlayer();

        if (distanceToPlayer >= attackRange)
        {
            //Debug.Log("Chasing the Player");
            ChasePlayer();
        }
        else
        {
            //Debug.Log("Can Attack Player");
            canAttackPlayer = true;
        }

        if (canAttackPlayer == true)
        {
            AttackPlayer();
        }
    }

    private float GetDistanceToPlayer()
    {
        return Vector3.Distance(player.transform.position, transform.position);
    }

    private void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    private void AttackPlayer()
    {
        // Debug.Log("Attacking Player");
    }
}
