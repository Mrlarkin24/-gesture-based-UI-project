using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    public Transform[] spawnPoints;
    public GameObject[] enemys;
    int randomSpawnPoint, randomEnemy;
    public static bool spawnAllowed;
    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("spawnAEnemy", 0f, 0f);
    }

    void spawnAEnemy()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomEnemy = Random.Range(0, enemys.Length);
            Instantiate(enemys[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }
}
