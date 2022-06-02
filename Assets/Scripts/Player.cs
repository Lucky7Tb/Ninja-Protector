using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int score = 0;

    float healthUpPoint = 10f;
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
    public AudioClip appleBiteSound; 
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

    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(10);
        damage -= 10f;
        attackRate += 0.5f;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Food"))
        {
            health += healthUpPoint;
            playerAudio.PlayOneShot(appleBiteSound, 0.3f);
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("AttackPowerUp"))
        {
            Destroy(other.gameObject);
            damage += 10f;
            attackRate -= 0.5f;
            StartCoroutine(PowerupCooldown());
        }

        if(other.gameObject.CompareTag("InstantEnemyDeath"))
        {
            Destroy(other.gameObject);
            GameObject[] goblins = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject goblin in goblins)
            {
                goblin.GetComponent<Enemy>().takeDamage(10000f);
            }
        }
    }
}
