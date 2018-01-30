using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class LoadSceneButton : MonoBehaviour
{

    // GameObject in charge of scene-level admin.
    private GameObject sceneController;

    // Whether the Google Cardboard user is gazing at this button.
    private bool isLookedAt = false;

    // How long the user can gaze at this before the button is clicked.
    public float timerDuration = 3f;

    // Count time the player has been gazing at the button.
    private float lookTimer = 0f;

    // Graphical progress indicator.
    private GameObject gazeTimer;

    // Use this for initialization
    void Start()
    {
        sceneController = GameObject.Find("SceneController");
        gazeTimer = GameObject.Find("GazeTimer");
    }

    // Update is called once per frame
    void Update()
    {

        // While player is looking at this button.
        if (isLookedAt)
        {

            // Increment the gaze timer.
            lookTimer += Time.deltaTime;

            // Modify graphic progress indicator to show remaining time. E.g. set the alpha layer value
            // cutoff on a PNG so the part showing is proportional to remaining time.
            gazeTimer.GetComponent<Renderer>().material.SetFloat("_Cutoff", lookTimer / timerDuration);

            // Gaze time exceeded limit - button is considered clicked.
            if (lookTimer > timerDuration)
            {
                lookTimer = 0f;

                Debug.Log("Button selected!");
                GetComponent<Button>().onClick.Invoke();
            }
        }

        // Not gazing at this anymore, reset everything.
        else
        {
            lookTimer = 0f;
            // Reset progress indicator.
            gazeTimer.GetComponent<Renderer>().material.SetFloat("_Cutoff", 0f);
        }
    }

    // Record whether Google Cardboard user is gazing at the button.
    // gazedAt: Set it to the value passed from event trigger.
    public void SetGazedAt(bool gazedAt)
    {
        isLookedAt = gazedAt;
    }
    
    // Call the SceneController to load the next scene in build settings.
    public void LoadNextScene()
    {
        sceneController.GetComponent<SceneController>().LoadNextScene();
    }

    // Call the SceneController to load the previous scene in build settings.
    public void LoadPrevScene()
    {
        sceneController.GetComponent<SceneController>().LoadPrevScene();
    }

    internal class SceneController
    {
        internal void LoadNextScene()
        {
            throw new NotImplementedException();
        }

        internal void LoadPrevScene()
        {
            throw new NotImplementedException();
        }
    }
}

