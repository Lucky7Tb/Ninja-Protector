using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private GameObject player;

    public GameObject goblin;
    private float enemyNextSpawnTime = 0f;
    private float enemySpawnTime = 10f;
    // Left position, right position
    Vector3[] enemySpawnPosition = {new Vector3(-7f, -2.5f, -2), new Vector3(7f, -2.5f, -2)};
    
    public GameObject food;
    private float foodNextSpawnTime = 15f;
    private float foodSpawnTime = 15f;

    public GameObject sleepingDust;

    public GameObject attackPowerUpIcon;
    private float attackPowerUpNextSpawnTime = 40f;
    private float attackPowerUpSpawnTime = 40f;

    public GameObject instantEnemyDeathIcon;
    private float instantEnemyDeathNextSpawnTime = 50f;
    private float instantEnemyDeathSpawnTime = 50f;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(Time.time > enemyNextSpawnTime)
        {
            spawEnemy();
            enemyNextSpawnTime += enemySpawnTime;
        }    
        
        if(Time.time > foodNextSpawnTime)
        {
            spawnFood();
            foodNextSpawnTime += foodSpawnTime;
        }    
        
        if(Time.time > instantEnemyDeathNextSpawnTime)
        {
            spawnInstanDeathAllEnemy();
            instantEnemyDeathNextSpawnTime += instantEnemyDeathSpawnTime;
        }    
        
        if(Time.time > attackPowerUpNextSpawnTime)
        {
            spawnAttackPowerUp();
            attackPowerUpNextSpawnTime += attackPowerUpSpawnTime;
        }    
    }

    void spawEnemy()
    {
        int randomSpawnIndex = Random.Range(0, 2);
        Vector3 spawnPosition = enemySpawnPosition[randomSpawnIndex];
        GameObject cloneGoblin = Instantiate(goblin);
        cloneGoblin.transform.position = spawnPosition;
    }

    void spawnFood()
    {
        GameObject cloneFood = Instantiate(food);
        cloneFood.transform.position = getRandomItemSpawnPosition();
    }

    void spawnInstanDeathAllEnemy()
    {
        GameObject cloneEnemyDeathIcon = Instantiate(instantEnemyDeathIcon);
        cloneEnemyDeathIcon.transform.position = getRandomItemSpawnPosition();
    }

    void spawnAttackPowerUp()
    {
        GameObject attackPowerUp = Instantiate(attackPowerUpIcon);
        attackPowerUp.transform.position = getRandomItemSpawnPosition();
    }


    void spawnSleepingDust()
    {

    }

    Vector3 getRandomItemSpawnPosition()
    {
        int randomXPosition = Random.Range(-9, 8);
        return new Vector3(randomXPosition, 3, 3);
    }
}
