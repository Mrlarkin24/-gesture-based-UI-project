
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class SpeechRecognition : MonoBehaviour
{
    public string[] keywords = new string[] { "play", "quit", "help", "main"};
    
    public ConfidenceLevel confidence = ConfidenceLevel.Low;

    public Text results;

    protected PhraseRecognizer recognizer;
    // variable that changes when word is inputted
    protected string word = "val";
    // Start is called before the first frame update
    void Start()
    {
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
            case "play":
                SceneManager.LoadSceneAsync("SampleScene");
                break;
            case "help":
                Debug.Log("WE will help you");
                SceneManager.LoadSceneAsync("tutorialScene");
                break;
            case "main":
                Debug.Log("going to the main menu");
                SceneManager.LoadSceneAsync("Menu");
                break;
            case "quit":
                Debug.Log("Quitting Game");
                Application.Quit();
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

