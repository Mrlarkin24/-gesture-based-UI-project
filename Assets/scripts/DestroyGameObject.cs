using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public string[] type;


    void OnCollisionEnter2D(Collision2D col)
    {
        foreach(var item in type)
        {
            if (col.gameObject.tag == item)
            {
                //destroy the player
                //Object.Destroy(this.gameObject);
                //destroy the bullet
                Object.Destroy(col.gameObject);
                //col.gameObject.SetActive(false);
                //playerHealth.currentHealth -= 20;
                if(item == "Bullet")
                {
                    Object.Destroy(this.gameObject);
                    ScoreScript.scoreVal += 1;
                }

            }
        }
    }
}
