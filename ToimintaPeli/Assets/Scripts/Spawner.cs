using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject spawnObject;
    public float radius = 1.0f;
    public float minSpawnTime = 1.0f;
    public float maxSpawnTime = 10.0f;
        
    public GameObject spawnPos;


    void Start()
    {
        Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
        Debug.Log("start");
    }


    void SpawnEnemy()
    {
      
        float spawnRadius = radius;
        
        //transform.position = Random.insideUnitSphere * spawnRadius;

        Instantiate(spawnObject, spawnPos.transform.position, Quaternion.identity);

    
        Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
        
    }
}