using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "EnemyBullet" || col.gameObject.tag == "Enemy")
        {
            //destroy the player
            //Object.Destroy(this.gameObject);
            //destroy the bullet
            Object.Destroy(col.gameObject);
            //col.gameObject.SetActive(false);
            DisplayPlayerHealth.currentHealth -= 20;



        }
    }
}
