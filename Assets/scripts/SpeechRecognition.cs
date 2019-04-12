
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class SpeechRecognition : MonoBehaviour
{

    Scene currentScene;
    string sceneName;

    public string[] keywords = new string[] { };
    
    public ConfidenceLevel confidence = ConfidenceLevel.Low;

    public Text results;

    public bool gamePaused = false;
    public GameObject pauseMenu;

    protected PhraseRecognizer recognizer;
    // variable that changes when word is inputted
    protected string word = "val";
    // Start is called before the first frame update
    void Start()
    {
        sceneName = currentScene.name;
        currentScene = SceneManager.GetActiveScene();
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "You said: <b>" + word + "</b>";
    }

    private void Update()
    {

        switch (word)
        {
            case "start":
                SceneManager.LoadSceneAsync("SampleScene");
                Time.timeScale = 1.0f;
                break;
            case "help":
                Debug.Log("WE will help you");
                SceneManager.LoadSceneAsync("tutorialScene");
                break;
            case "main":
                if(sceneName != "SampleScene"){
                    HealthScript.health = 3;
                    SceneManager.LoadSceneAsync("Menu");   
                }
                Debug.Log("going to the main menu");
                //SceneManager.LoadSceneAsync("Menu");
                ScoreScript.scoreVal = 0;
                break;
            case "quit":
                Debug.Log("Quitting Game");
                Application.Quit();
                break;
            case "pause":
                if(gamePaused == false){
                    Time.timeScale = 0;
                    gamePaused = true;
                    Cursor.visible = true;
                    pauseMenu.SetActive(true);
                }
                break;
            case  "play":
                if(gamePaused == true){
                    Time.timeScale = 1.0f;
                    gamePaused = false;
                    Cursor.visible = false;
                    pauseMenu.SetActive(false);
                }
                break;
            case "leave":
            if(gamePaused == true){
                if(gamePaused == true){
                        ScoreScript.scoreVal = 0;
                        HealthScript.health = 3;
                        Time.timeScale = 1.0f;
                        gamePaused = false;
                        Cursor.visible = false;
                        pauseMenu.SetActive(false);
                        SceneManager.LoadSceneAsync("Menu");
                    }
            }
                break;
        }

        
    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}

