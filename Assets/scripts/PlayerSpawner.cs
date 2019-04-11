using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject playerShip;
    public float timer = 0.0f;
    public Vector2 spawnPoint = new Vector2(0,-4);

 
    // Start is called before the first frame update
    void Update()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    public void SpawnPlayer(){
        timer += Time.deltaTime;
        if(!GameObject.FindGameObjectWithTag("Player") && timer > 2){
        Instantiate (playerShip, spawnPoint, Quaternion.identity);
        timer = 0;
        }
    }
}
