using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject goblin;
    public float enemyNextSpawnTime = 0f;
    public float enemySpawnTime = 10f;
    // Left position, right position
    Vector3[] enemySpawnPosition = {new Vector3(-7f, -2.5f, -2), new Vector3(7f, -2.5f, -2)};
    
    public GameObject food;
    public float foodNextSpawnTime = 0f;
    public float foodSpawnTime = 15f;

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
        int randomXPosition = Random.Range(-9, 8);
        GameObject cloneFood = Instantiate(food);
        cloneFood.transform.position = new Vector3(randomXPosition, 3, 3);
    }
}
