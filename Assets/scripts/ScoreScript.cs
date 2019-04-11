using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreVal = 0;
    public Text score;
    public Text HighScore;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
        HighScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "score: " + scoreVal;
        

        if(scoreVal > PlayerPrefs.GetInt("HighScore")){
            Debug.Log(scoreVal);
            PlayerPrefs.SetInt("HighScore", scoreVal);
        }
    }
}










