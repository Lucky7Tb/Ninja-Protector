using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public GameObject originalBlood;
    GameObject cloneBlood;
    public float enemyHealth = 100f;
    public float enemyDamage = 5f;
    public float horizontalMove = 0f;
    
    public void TakeDamage(float damage) {
        enemyHealth -= damage;

        animator.SetTrigger("GetHit");
        cloneBlood = Instantiate(originalBlood);
        cloneBlood.transform.position = transform.position;
        Destroy(cloneBlood, 0.5f);
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
        Destroy(this.gameObject, 2);
    }
}
