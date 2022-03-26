using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject goblin;
    public float nextSpawnTime = 0f;
    public float spawnTime = 5f;
    
    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            spaw();
            nextSpawnTime += spawnTime;
        }    
    }

    void spaw()
    {
        Vector3 spawnPosition = new Vector3(7f, -2.5f, -2f);
        GameObject cloneGoblin = Instantiate(goblin);
        cloneGoblin.transform.position = spawnPosition;
    }
}
