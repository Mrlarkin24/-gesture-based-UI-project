using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform projectileSpawn;
    public GameObject bulletTest;

    public float nextFire = 1.0f;
    public float currentTime = 0.0f;

    // Use this for initialization
    // Start is called before the first frame update
    void Start()
    {
        //bulletTest = GameObject.FindGameObjectWithTag("Bullet");
        projectileSpawn = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }


    public void Shoot()
    {
        currentTime += Time.deltaTime;
        if (Input.GetButton("Fire1") && currentTime > nextFire)
        {
            nextFire += currentTime;
            Instantiate(bulletTest, projectileSpawn.position, Quaternion.identity);

            nextFire -= currentTime;
            currentTime = 0.0f;
        }
    }


}