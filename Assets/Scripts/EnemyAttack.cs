using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator animator;
    public Transform areaHitPoint;
    public LayerMask playerLayers;
    public float attackRange = 0.4f;
    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    public void attack(float damage)
    {
        Collider2D player = Physics2D.OverlapCircle(areaHitPoint.position, attackRange, playerLayers);
        if(player != null)
        {
            animator.SetTrigger("EnemyAttack");
            enemy.enemyAudio.PlayOneShot(enemy.swordSound, 0.5f);
            player.GetComponent<Player>().takeDamage(damage);
        }
    }

    void OnDrawGizmosSelected() 
    {
        if(areaHitPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(areaHitPoint.position, attackRange);    
    }
}
