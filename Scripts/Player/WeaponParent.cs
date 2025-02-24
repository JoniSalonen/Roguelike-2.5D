using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JS.CharacterStats;
using ShopItems;


public class WeaponParent : MonoBehaviour
{
    public Animator animator;
    public Character c;
    float attackCooldown;

    public Transform circleOrigin;
    public float circleRadius;

    private PlayerHealth playerHealth;

    protected float damage;
    private bool attackBlocked;
    protected float hit;

    protected float lifeStealValue;


    private void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();

        attackBlocked = false;

    }

    private void Update()
    {
        attackCooldown = (1 / c.AttackSpeed.Value);
    }


    public void Attack()
    {

        if (attackBlocked)
            return;

        animator.SetBool("Attack", true);
        hit = Damage();
        Leech(hit);
        
        attackBlocked = true;
        StartCoroutine(DelayAttack());

    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(attackCooldown);
        attackBlocked = false;
    }

    public void StopAttack()
    {
        animator.SetBool("Attack", false);
    }

    public float Damage()
    {
        if (!attackBlocked)
        {
            damage = Random.Range((c.Damage.Value / 2), c.Damage.Value);

            if (Random.Range(0, 100) <= c.CritChance.Value || c.CritChance.Value >= 100)
            {
                damage = c.Damage.Value * (1 + c.CritMult.Value);

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

    public void Leech(float damage)
    {
        lifeStealValue = c.LifeSteal.Value;

        float lifeSteal = damage * (0.01f * lifeStealValue);
        playerHealth.AddLife(lifeSteal);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, circleRadius);
    }

    public void DetectColliders()
    {
        foreach (Collider col in Physics.OverlapSphere(circleOrigin.position, circleRadius))
        {
            Debug.Log(col.name);

            EnemyHealth health;

            if (health = col.GetComponent<EnemyHealth>())
            {
                health.TakeDamage(hit, transform.parent.gameObject);
            }

        }
    }
}
