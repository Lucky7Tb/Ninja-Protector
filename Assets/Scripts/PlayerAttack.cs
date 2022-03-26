using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator animator;
    public Transform areaHitPoint;
    public LayerMask enemyLayers;
    float attackRange = 0.5f;

    public void attack(float damage) 
    {
        animator.SetTrigger("PlayerAttack");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(areaHitPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in enemies) 
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected() {
        if(areaHitPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(areaHitPoint.position, attackRange);    
    }
}
