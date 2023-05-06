using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Enemy Prefabs
    public GameObject lowHealthEnemyPrefab;
    public GameObject mediumHealthEnemyPrefab;
    public GameObject highHealthEnemyPrefab;

    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    
    
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay); // enemies spawn at set intervals
    }

    public void SpawnObject()
    {
        int random = Random.Range(1, 5);
        switch (random)
        {
            case >=3: // 50% chance to spawn a low health enemy
                Instantiate(lowHealthEnemyPrefab, transform.position, transform.rotation);
                break;
            case 2: // 25% chance to spawn a medium health enemy
                Instantiate(mediumHealthEnemyPrefab, transform.position, transform.rotation);
                break;
            case 1: // 25% chance to spawn a high health enemy
                Instantiate(highHealthEnemyPrefab, transform.position, transform.rotation);
                break;
        }

        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }

}
