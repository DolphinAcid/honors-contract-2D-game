using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    
    //collectible spawn positions
    Vector3 spawnPosition;
    private Vector3 spawn1 = new Vector3(-15.5f, 11.5f, 0f);
    private Vector3 spawn2 = new Vector3(6f, 7.5f, 0f);
    private Vector3 spawn3 = new Vector3(-4.5f, -6f, 0f);
    private Vector3 spawn4 = new Vector3(14.5f, -2f, 0f);
    private Vector3 spawn5 = new Vector3(-13f, -4.5f, 0f);


    void Start()
    {
        // on game start --> collectibles spawn at set intervals
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }
    public void SpawnObject()
    {
        // Generate a random int from 1-5 and spawn collectible at the corresponding spawn position
        int random = Random.Range(1, 6);
        switch (random)
        {
            case 1:
                spawnPosition = spawn1;
                break;
            case 2:
                spawnPosition = spawn2;
                break;
            case 3:
                spawnPosition = spawn3;
                break;
            case 4:
                spawnPosition = spawn4;
                break;
            case 5:
                spawnPosition = spawn5;
                break;
            default:
                spawnPosition = Vector3.zero;
                break;
        }
        
        Instantiate(collectiblePrefab, spawnPosition, transform.rotation);
        
        if (stopSpawning)
        {
            // This function isn't currently used
            CancelInvoke("SpawnObject");
        }

    }
}
