using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnControl : MonoBehaviour

{

    public Transform[] spawnPoints;
    public GameObject[] enemys;
    int randomSpawnPoint, randomEnemy;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    Vector2 whereToSpawn;
    void Start()
    {
        //spawnAllowed = true;
        //InvokeRepeating("SpawnAEnemy", 0f, 0f);
    }


    private void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomEnemy = Random.Range(0, enemys.Length);
            Instantiate(enemys[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }
   }

