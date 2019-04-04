using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerHealth : MonoBehaviour
{
    public Slider healthSlider;
    static public float currentHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthControl();
    }


    public void healthControl()
    {
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            playerHealthScript.health -= 1;
            currentHealth = 100;
        }
    }
}





