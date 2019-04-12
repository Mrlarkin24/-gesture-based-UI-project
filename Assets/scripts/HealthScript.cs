using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{

    public static int health = 3;
    public GameObject Explosion;
    public GameObject live1, live2, live3;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "EnemyBullet" ||col.gameObject.tag == "Enemy")
        {
            
            Object.Destroy(col.gameObject);
            //Object.Destroy(this.gameObject);
            health -= 1;



        }
    }
    // Start is called before the first frame update
    void Start()
    {
        live1.gameObject.SetActive(true);
        live2.gameObject.SetActive(true);
        live3.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        healthController();
    }


    void healthController(){

        if(health > 3){
            health = 3;
        }

        switch(health){
            case 3:
                live1.gameObject.SetActive(true);
                live2.gameObject.SetActive(true);
                live3.gameObject.SetActive(true);
                break;
            case 2:
                live1.gameObject.SetActive(true);
                live2.gameObject.SetActive(true);
                live3.gameObject.SetActive(false);
                break;
            case 1:
                live1.gameObject.SetActive(true);
                live2.gameObject.SetActive(false);
                live3.gameObject.SetActive(false);
                break;
            case 0:
                live1.gameObject.SetActive(false);
                live2.gameObject.SetActive(false);
                live3.gameObject.SetActive(false);
                
                EndGame();
                break;
            }
    }

    void EndGame(){
        SceneManager.LoadSceneAsync("EndMenu");
    }

  
}
