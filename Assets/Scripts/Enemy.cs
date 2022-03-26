using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public GameObject originalBlood;
    GameObject cloneBlood;
    float health = 100f;
    // float damage = 5f;
    public float speed = 3.5f;

    public void TakeDamage(float damage) {
        health -= damage;
        speed = 0f;

        animator.SetTrigger("GetHit");
        cloneBlood = Instantiate(originalBlood);
        cloneBlood.transform.position = transform.position;
        Destroy(cloneBlood, 0.5f);
        if(health <= 0) {
            speed = 0f;
            Die();
        } else {
            speed = 3.5f;
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
