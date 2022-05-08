using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float damage = 25f;
    public float health = 100f;
    public float moveSpeed = 8f;
    float attackRate = 2f;
    float nextAttackTime = 0f;
    bool gameOver = false;

    public Animator animator;
    public GameObject blood; 
    PlayerAttack playerAttack;
    PlayerController playerController;
    public AudioClip swordSound;   
    AudioSource playerAudio; 

    void Start() {
        playerController = GetComponent<PlayerController>();
        playerAttack = GetComponent<PlayerAttack>();   
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(!gameOver)
        {
            if(health > 0)
            {
                playerController.move(Input.GetAxisRaw("Horizontal"), moveSpeed);
            
                if(Time.time > nextAttackTime) 
                {
                    if(Input.GetMouseButtonDown(0)) 
                    {
                        playerAttack.attack(damage);
                        playerAudio.PlayOneShot(swordSound, 0.5f);
                        nextAttackTime = Time.time + 1f / attackRate;
                    }
                }
            } else {
                gameOver = true;
            }
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
