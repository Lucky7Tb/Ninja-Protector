using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    Enemy enemy;

    void Start() 
    {
        enemy = GameObject.FindObjectOfType<Enemy>();    
    }

    void Update() 
    {
        findPlayer();    
    }

    public void findPlayer()
    {
        float playerPosition = Mathf.Abs(player.transform.position.x);
        float enemyPosition = Mathf.Abs(transform.position.x);
        // Debug.Log(Mathf.Ceil(Mathf.Abs(playerPosition - enemyPosition)));

        if(Mathf.Ceil(Mathf.Abs(playerPosition - enemyPosition)) < 2)
        {
            enemy.animator.SetFloat("EnemySpeed", 0f);
            // transform.Translate(Vector3.left * Time.deltaTime * 0);
        } else {
            enemy.animator.SetFloat("EnemySpeed", enemy.speed);
            if(player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.Translate(Vector3.left * Time.deltaTime * enemy.speed);
            }
            
            if(player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.Translate(Vector3.right * Time.deltaTime * enemy.speed);
            }
        }
    }

}
