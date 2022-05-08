using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject goblin;
    public GameObject food;
    public float enemyNextSpawnTime = 0f;
    public float enemySpawnTime = 10f;
    // Left position, right position
    Vector3[] enemySpawnPosition = {new Vector3(-7f, -2.5f, -2), new Vector3(7f, -2.5f, -2)};
    
    void Start()
    {
        spawnFood();
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

    void spawnFood()
    {
        GameObject cloneFood = Instantiate(food);
        cloneFood.transform.position = new Vector3(-0.5f, 3, 3);
    }
}
