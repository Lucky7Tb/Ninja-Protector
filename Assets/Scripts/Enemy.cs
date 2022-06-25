using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float health = 100f;
    public float damage = 5f;
    float speed = 3.5f;
    public Animator animator;
    public GameObject blood;
    EnemyController enemyController;
    public AudioClip swordSound;   
    public AudioSource enemyAudio; 

    void Start() 
    {
        enemyController = GameObject.FindObjectOfType<EnemyController>();
        enemyAudio = GetComponent<AudioSource>();
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
    
    public void die() 
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Player>().score += 5;
        animator.SetTrigger("GoDead");
        Vector3 position = transform.position;
        position.y = -2.8f;
        transform.position = position;
        GetComponent<Collider2D>().enabled = false;
        Destroy(this);
        Destroy(gameObject, 2);
    }
}
