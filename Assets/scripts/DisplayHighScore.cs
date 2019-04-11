using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{

    public Text HighScore;
    // Start is called before the first frame update
    void Start()
    {
        HighScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
