using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    GameObject player;
    Enemy enemy;
    EnemyAttack enemyAttack;
    float attackRate = 0.5f;
    float nextAttackTime = 0f;

    void Start()
    {
        player =  GameObject.Find("Player");
        enemy = GameObject.FindObjectOfType<Enemy>();
        enemyAttack = GameObject.FindObjectOfType<EnemyAttack>();
    }

    public void findPlayer(float movementSpeed)
    {
        float playerPosition = Mathf.Abs(player.transform.position.x);
        float enemyPosition = Mathf.Abs(transform.position.x);
        if(Mathf.Ceil(Mathf.Abs(playerPosition - enemyPosition)) < 2)
        {
            animator.SetFloat("EnemySpeed", 0f);
            if(Time.time > nextAttackTime) 
            {
                enemyAttack.attack(enemy.damage);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        } else {
            animator.SetFloat("EnemySpeed", movementSpeed);
            if(player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
            }
            
            if(player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
            }
        }
    }
}
