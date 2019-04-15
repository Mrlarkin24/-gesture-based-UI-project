using System.Collections;
 using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement;
   using LockingPolicy = Thalmic.Myo.LockingPolicy; 
using Pose = Thalmic.Myo.Pose; using UnlockType = Thalmic.Myo.UnlockType; 
using VibrationType = Thalmic.Myo.VibrationType;  public class MyoControls : MonoBehaviour {      public Rigidbody2D rb;     public float moveSpeed = 1.0f;     public Vector2 moveV;      public Transform projectileSpawn;
    public GameObject bulletTest;

    public float nextFire = 1.0f;
    public float currentTime = 0.0f;      // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;

    

    // A rotation that compensates for the Myo armband's orientation parallel to the ground, i.e. yaw.
    // Once set, the direction the Myo armband is facing becomes "forward" within the program.
    // Set by making the fingers spread pose or pressing "r".
    private Quaternion _antiYaw = Quaternion.identity;

    // A reference angle representing how the armband is rotated about the wearer's arm, i.e. roll.
    // Set by making the fingers spread pose or pressing "r".
    private float _referenceRoll = 0.0f;

    // The pose from the last update. This is used to determine if the pose has changed
    // so that actions are only performed upon making them rather than every frame during
    // which they are active.
    private Pose _lastPose = Pose.Unknown;

    void Start()
    {
        //bulletTest = GameObject.FindGameObjectWithTag("Bullet");
        projectileSpawn = this.gameObject.transform;
    }

    void Update()     {         currentTime += Time.deltaTime;          Scene currentScene = SceneManager.GetActiveScene();         string sceneName = currentScene.name;         // Access the ThalmicMyo component attached to the Myo game object.         ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();          bool updateReference = true;          Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));           if (updateReference)
        {
            // _antiYaw represents a rotation of the Myo armband about the Y axis (up) which aligns the forward
            // vector of the rotation with Z = 1 when the wearer's arm is pointing in the reference direction.
            _antiYaw = Quaternion.FromToRotation(
                new Vector3(myo.transform.forward.x, 0, myo.transform.forward.z),
                new Vector3(0, 0, 1)
            );

            // _referenceRoll represents how many degrees the Myo armband is rotated clockwise
            // about its forward axis (when looking down the wearer's arm towards their hand) from the reference zero
            // roll direction. This direction is calculated and explained below. When this reference is
            // taken, the joint will be rotated about its forward axis such that it faces upwards when
            // the roll value matches the reference.
            Vector3 referenceZeroRoll = computeZeroRollVector(myo.transform.forward);
            _referenceRoll = rollFromZero(referenceZeroRoll, myo.transform.forward, myo.transform.up);
            //Debug.Log(_referenceRoll);

        }

        if (_referenceRoll > 75.0)
        {
            //Debug.Log("test");
            moveInput = new Vector2(-1, 0);
        }
        else if (_referenceRoll < 50.0)
        {
            moveInput = new Vector2(1, 0);
        }
        else
        {
            moveInput = new Vector2(0, 0);
        }

        moveV = moveInput * moveSpeed;

        // Check if the pose has changed since last update.
        // The ThalmicMyo component of a Myo game object has a pose property that is set to the
        // currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
        // detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
        // is not on a user's arm, pose will be set to Pose.Unknown.
        if (thalmicMyo.pose != _lastPose)         {             _lastPose = thalmicMyo.pose;              if (sceneName == "Menu")             {                  // Vibrate the Myo armband when a fist is made.                 if (thalmicMyo.pose == Pose.FingersSpread)                 {                     Debug.Log("Menu fist Working");                     thalmicMyo.Vibrate(VibrationType.Medium);                                          Debug.Log(updateReference);                     LoadScene("SampleScene");                                          ExtendUnlockAndNotifyUserAction(thalmicMyo);                  }                 else if (thalmicMyo.pose == Pose.WaveIn)                 {                     Debug.Log("Menu wave in Working");                     LoadScene("Options");                       ExtendUnlockAndNotifyUserAction(thalmicMyo);                 }                 else if (thalmicMyo.pose == Pose.DoubleTap)                 {                     Debug.Log("Menu FrigerSpread works");                     QuitGame();                     ExtendUnlockAndNotifyUserAction(thalmicMyo);                 }             }             else if(sceneName == "SampleScene")             {

                if (thalmicMyo.pose == Pose.Fist)                 {  
                                       Debug.Log("level1 Shooting");   
                                        
                                                       Shoot();      
                                              
                                                              ExtendUnlockAndNotifyUserAction(thalmicMyo);  
                                                                             }
                             }             else if (sceneName == "Options")             {                 if (thalmicMyo.pose == Pose.FingersSpread)                 {                     Debug.Log("Options Working");                     QuitGame();                     ExtendUnlockAndNotifyUserAction(thalmicMyo);                 }                 else if (thalmicMyo.pose == Pose.Fist)                 {                     Debug.Log("level1 Moving Right");                     LoadScene("Menu");                     ExtendUnlockAndNotifyUserAction(thalmicMyo);                 }             }         }         
        }      void ExtendUnlockAndNotifyUserAction(ThalmicMyo myo)     {         ThalmicHub hub = ThalmicHub.instance;          if (hub.lockingPolicy == LockingPolicy.Standard)         {             myo.Unlock(UnlockType.Timed);         }          myo.NotifyUserAction();     }      void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveV * Time.fixedDeltaTime);        
    }      void LoadScene(string SceneName)     {         SceneManager.LoadSceneAsync(SceneName);         rb = GetComponent<Rigidbody2D>();     }

    float rollFromZero(Vector3 zeroRoll, Vector3 forward, Vector3 up)
    {
        // The cosine of the angle between the up vector and the zero roll vector. Since both are
        // orthogonal to the forward vector, this tells us how far the Myo has been turned around the
        // forward axis relative to the zero roll vector, but we need to determine separately whether the
        // Myo has been rolled clockwise or counterclockwise.
        float cosine = Vector3.Dot(up, zeroRoll);

        // To determine the sign of the roll, we take the cross product of the up vector and the zero
        // roll vector. This cross product will either be the same or opposite direction as the forward
        // vector depending on whether up is clockwise or counter-clockwise from zero roll.
        // Thus the sign of the dot product of forward and it yields the sign of our roll value.
        Vector3 cp = Vector3.Cross(up, zeroRoll);
        float directionCosine = Vector3.Dot(forward, cp);
        float sign = directionCosine < 0.0f ? 1.0f : -1.0f;

        //Debug.Log(sign * Mathf.Rad2Deg * Mathf.Acos(cosine));
        // Return the angle of roll (in degrees) from the cosine and the sign.
        return sign * Mathf.Rad2Deg * Mathf.Acos(cosine);
    }

    // Compute a vector that points perpendicular to the forward direction,
    // minimizing angular distance from world up (positive Y axis).
    // This represents the direction of no rotation about its forward axis.
    Vector3 computeZeroRollVector(Vector3 forward)
    {
        Vector3 antigravity = Vector3.up;
        Vector3 m = Vector3.Cross(myo.transform.forward, antigravity);
        Vector3 roll = Vector3.Cross(m, myo.transform.forward);

        return roll.normalized;
    }      public void Shoot()
    {

        if (currentTime > nextFire)
        {
            Debug.Log("TEST 2");
            nextFire += currentTime;
            Instantiate(bulletTest, projectileSpawn.position, Quaternion.identity);

            nextFire -= currentTime;
            currentTime = 0.0f;
        }
    }      void QuitGame()      {         Debug.Log("Quitting Game");         Application.Quit();     } } 