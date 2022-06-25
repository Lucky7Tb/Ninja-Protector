using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int score = 0;
    
    private float healthUpPoint = 10f;
    public float damage = 25f;
    public float health = 100f;
    public float moveSpeed = 8f;
    private float attackRate = 2f;
    private float nextAttackTime = 0f;
    private HealthBar healthBarScript;
    
    public TextMeshProUGUI powerUpText;
    private GameObject gameOverContainer;

    public Animator animator;
    public GameObject blood; 
    private PlayerAttack playerAttack;
    private PlayerController playerController;
    private Spawner spawner;
    
    public AudioClip swordSound; 
    public AudioClip appleBiteSound;
    public AudioClip pickupItemSound;
    private AudioSource playerAudio;
    
    void Start() {
        playerController = GetComponent<PlayerController>();
        playerAttack = GetComponent<PlayerAttack>();   
        playerAudio = GetComponent<AudioSource>();
        healthBarScript = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        gameOverContainer = GameObject.Find("GameOverContainer");
        gameOverContainer.gameObject.SetActive(false);
    }

    void Update()
    {
        if(!spawner.isGameOver)
        {
            if(health > 0)
            {
                float move = Input.GetAxisRaw("Horizontal");
                
                if(move == -1 && transform.position.x <= -11) {
                    move = 0;
                }
                
                if(move == 1 && transform.position.x >= 11) {
                    move = 0;
                }

                playerController.move(move, moveSpeed);
            
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
                playerController.move(-1, 0);
                spawner.isGameOver = true;
            }
        } 
    }

    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(10);
        damage -= 10f;
        powerUpText.gameObject.SetActive(false);
    }

    public void takeDamage(float takenDamage)
    {
        GameObject cloneBlood = Instantiate(blood);
        cloneBlood.transform.position = transform.position;
        Destroy(cloneBlood, 0.5f);
        health -= takenDamage;
        healthBarScript.SetSliderHealth(health);
        if(health <= 0)
        {
            animator.SetTrigger("PlayerDead");
            GetComponent<Collider2D>().enabled = false;
            gameOverContainer.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Food"))
        {
            health += healthUpPoint;
            healthBarScript.SetSliderHealth(health);
            playerAudio.PlayOneShot(appleBiteSound, 0.3f);
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("AttackPowerUp"))
        {
            Destroy(other.gameObject);
            damage += 10f;
            StartCoroutine(PowerupCooldown());
            playerAudio.PlayOneShot(pickupItemSound, 0.3f);
            powerUpText.gameObject.SetActive(true);
        }

        if(other.gameObject.CompareTag("InstantEnemyDeath"))
        {
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(pickupItemSound, 0.3f);
            GameObject[] goblins = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject goblin in goblins)
            {
                goblin.GetComponent<Enemy>().takeDamage(10000f);
            }
        }
    }
}
