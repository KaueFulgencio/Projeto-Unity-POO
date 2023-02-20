using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay = 1.0f; 
    public int waveSize = 5; 
    public float spawnRadius = 10.0f; 
    public int totalWaves = 10; 

    private int currentWave = 0; 
    private int enemiesSpawned = 0; 
    private float nextSpawnTime = 0.0f; 

    void Start()
    {
        SpawnWave();
    }
    void Update()
    {
        if (enemiesSpawned >= waveSize)
        {
            if (currentWave >= totalWaves)
            {
                enabled = false;
                return;
            }
            nextSpawnTime = Time.time + spawnDelay;
            currentWave++;
            enemiesSpawned = 0;
        }

        if (Time.time >= nextSpawnTime)
        {
            enemiesSpawned++;

            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
    void SpawnWave()
    {
        nextSpawnTime = Time.time + spawnDelay;
        currentWave = 0;
        enemiesSpawned = 0;
    }
}
