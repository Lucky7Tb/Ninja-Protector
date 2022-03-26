using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float damage = 20f;
    public float health = 100f;
    public float moveSpeed = 8f;
    float attackRate = 2f;
    float nextAttackTime = 0f;

    public Animator animator;
    public GameObject blood; 
    PlayerAttack playerAttack;
    PlayerController playerController;

    void Start() {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        playerAttack = GameObject.FindObjectOfType<PlayerAttack>();    
    }

    void Update()
    {
        if(health > 0)
        {
            playerController.move(Input.GetAxisRaw("Horizontal"), moveSpeed);
        
            if(Time.time > nextAttackTime) 
            {
                if(Input.GetMouseButtonDown(0)) 
                {
                    playerAttack.attack(damage);
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        } else {
            playerController.move(Input.GetAxisRaw("Horizontal"), 0);
        }
    }

    public void takeDamage(float takenDamage)
    {
        health -= takenDamage;
        GameObject cloneBlood = Instantiate(blood);
        cloneBlood.transform.position = transform.position;
        Destroy(cloneBlood, 0.5f);
        if(health <= 0)
        {
            animator.SetTrigger("PlayerDead");
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
