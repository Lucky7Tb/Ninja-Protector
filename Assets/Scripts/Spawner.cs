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
    private float foodSpawnTime = 15f;

    public GameObject attackPowerUpIcon;
    private float attackPowerUpSpawnTime = 40f;

    public GameObject instantEnemyDeathIcon;
    private float instantEnemyDeathSpawnTime = 50f;

    public bool isGameOver;

    void Start()
    {
        isGameOver = false;
        player = GameObject.Find("Player");
        StartCoroutine(spawnFood());
        StartCoroutine(spawnAttackPowerUp());
        StartCoroutine(spawnInstanDeathAllEnemy());
    }

    void Update()
    {
        if(Time.time > enemyNextSpawnTime)
        {
            spawEnemy();
            enemyNextSpawnTime += enemySpawnTime;
        }
    }

    void spawEnemy()
    {
        int randomSpawnIndex = Random.Range(0, 2);
        Vector3 spawnPosition = enemySpawnPosition[randomSpawnIndex];
        GameObject cloneGoblin = Instantiate(goblin);
        cloneGoblin.transform.position = spawnPosition;
    }

    IEnumerator spawnFood()
    {
        while(!isGameOver)
        {
            yield return new WaitForSeconds(foodSpawnTime);
            GameObject cloneFood = Instantiate(food);
            cloneFood.transform.position = getRandomItemSpawnPosition();
        }
    }

    IEnumerator spawnInstanDeathAllEnemy()
    {
        while(!isGameOver)
        {
            yield return new WaitForSeconds(instantEnemyDeathSpawnTime);
            GameObject cloneEnemyInstanstDeathIcon = Instantiate(instantEnemyDeathIcon);
            cloneEnemyInstanstDeathIcon.transform.position = getRandomItemSpawnPosition();
        }
    }

    IEnumerator spawnAttackPowerUp()
    {
        while(!isGameOver)
        {
            yield return new WaitForSeconds(attackPowerUpSpawnTime);
            GameObject cloneAttackPowerUp = Instantiate(attackPowerUpIcon);
            cloneAttackPowerUp.transform.position = getRandomItemSpawnPosition();
        }
    }

    private Vector3 getRandomItemSpawnPosition()
    {
        int randomXPosition = Random.Range(-9, 8);
        return new Vector3(randomXPosition, 3, 3);
    }
}
