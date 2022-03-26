using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public GameObject blood;
    EnemyAttack enemyAttack;
    EnemyController enemyController;
    float health = 100f;
    public float damage = 5f;
    float speed = 3.5f;

    void Start() 
    {
        enemyController = GameObject.FindObjectOfType<EnemyController>();
    }

    void Update() 
    {
        if(health > 0)
        {
            enemyController.findPlayer(speed);
        }
    }

    public void takeDamage(float takenDamage) 
    {
        health -= takenDamage;
        speed = 0f;

        animator.SetTrigger("GetHit");
        GameObject cloneBlood = Instantiate(blood);
        cloneBlood.transform.position = transform.position;
        Destroy(cloneBlood, 0.5f);
        if(health <= 0) 
        {
            speed = 0f;
            die();
        } else {
            speed = 3.5f;
        }
    }
    
    void die() 
    {
        animator.SetTrigger("GoDead");
        Vector3 position = transform.position;
        position.y = -2.8f;
        transform.position = position;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 2);
    }
}
