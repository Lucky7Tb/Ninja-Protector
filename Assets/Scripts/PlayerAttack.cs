using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator animator;
    public Transform areaHitPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public Player player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();    
    }

    public void Attack() {
        animator.SetTrigger("player_attack");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(areaHitPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in enemies) {
            enemy.GetComponent<Enemy>().TakeDamage(player.playerAttackDamage);
        }
    }

    void OnDrawGizmosSelected() {
        if(areaHitPoint == null) {
            return;
        }
        Gizmos.DrawWireSphere(areaHitPoint.position, attackRange);    
    }
}
