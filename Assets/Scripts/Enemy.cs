using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public float enemyHealth = 100f;
    public float enemyDamage = 5f;
    public float horizontalMove = 0f;
    
    public void TakeDamage(float damage) {
        enemyHealth -= damage;

        animator.SetTrigger("GetHit");

        if(enemyHealth <= 0) {
            Die();
        }
    }
    
    void Die() {
        animator.SetTrigger("GoDead");
        Vector3 position = transform.position;
        position.y = -2.8f;
        transform.position = position;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
