using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class MenuControls : MonoBehaviour
{

    public GameObject myo = null;

    private Pose _lastPose = Pose.Unknown;

    private void Start()
    {
     
    }
    void Update()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;
        // Access the ThalmicMyo component attached to the Myo game object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        // Check if the pose has changed since last update.
        // The ThalmicMyo component of a Myo game object has a pose property that is set to the
        // currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
        // detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
        // is not on a user's arm, pose will be set to Pose.Unknown.
        if (thalmicMyo.pose != _lastPose)
        {
            _lastPose = thalmicMyo.pose;

            if (sceneName == "Menu")
            {

                // Vibrate the Myo armband when a fist is made.
                if (thalmicMyo.pose == Pose.DoubleTap)
                {
                    Debug.Log("MEnu fist Working");
                    thalmicMyo.Vibrate(VibrationType.Medium);
                    playGame();
                    ExtendUnlockAndNotifyUserAction(thalmicMyo);

                    // Change material when wave in, wave out or double tap poses are made.
                }
                else if (thalmicMyo.pose == Pose.WaveIn)
                {
                    Debug.Log("Menu wave in Working");
                    LoadOptions();
                    ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }
                else if (thalmicMyo.pose == Pose.FingersSpread)
                {
                    Debug.Log("Menu oubletap works");
                    QuitGame();
                    ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }
            }
            else if(sceneName == "SampleScene")
            {
                if (thalmicMyo.pose == Pose.WaveIn)
                {
                    Debug.Log("level1 Moving Left");
                    thalmicMyo.Vibrate(VibrationType.Medium);

                    ExtendUnlockAndNotifyUserAction(thalmicMyo);

                    // Change material when wave in, wave out or double tap poses are made.
                }
                else if (thalmicMyo.pose == Pose.WaveOut)
                {
                    Debug.Log("level1 Moving Right");

                    ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }
                else if (thalmicMyo.pose == Pose.Fist)
                {
                    Debug.Log("level1 Shooting");
                    
                    ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }
            }
        }
    }

    void ExtendUnlockAndNotifyUserAction(ThalmicMyo myo)
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (hub.lockingPolicy == LockingPolicy.Standard)
        {
            myo.Unlock(UnlockType.Timed);
        }

        myo.NotifyUserAction();
    }


    void playGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    void LoadOptions()
    {
        SceneManager.LoadSceneAsync("Options");
    }

    void QuitGame()

    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
