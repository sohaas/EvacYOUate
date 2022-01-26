using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class NextButton : MonoBehaviour
{
    public SteamVR_Action_Boolean input;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (input.GetStateDown(SteamVR_Input_Sources.Any))
        {
            // Display correct text on canvas
            if (SceneManager.GetActiveScene().buildIndex == 1) 
            {
                HandleUI(counter);
                counter++;
            }
            // Switch from transition scene to main scene
            else if (SceneManager.GetActiveScene().buildIndex == 1) 
            {
                SceneManager.LoadScene(2, LoadSceneMode.Single);
            }
            // Repeat audio in main scene
            else if (SceneManager.GetActiveScene().buildIndex == 2) 
            {
                EventManager.instance.RequestedRepeat();
            }
        }
    }

    private void HandleUI(int counter)
    {
        switch (counter)
        {
            case 0:
                GameObject.Find("Intro").SetActive(false);
                GameObject.Find("Canvas1").transform.Find("Turn").gameObject.SetActive(true);
                break;
            case 1:
                GameObject.Find("Turn").SetActive(false);
                GameObject.Find("Canvas1").transform.Find("Teleport").gameObject.SetActive(true);
                break;
            case 2:
                GameObject.Find("Duck").SetActive(false);
                GameObject.Find("Canvas3").transform.Find("Crawl").gameObject.SetActive(true);
                break;
            case 3:
                GameObject.Find("Audio").SetActive(false);
                GameObject.Find("Canvas4").transform.Find("Repeat").gameObject.SetActive(true);
                break;
            case 4:
                //TODO repeat audio
                GameObject.Find("Repeat").SetActive(false);
                GameObject.Find("Canvas4").transform.Find("Explore").gameObject.SetActive(true);
                // Activate telepoints for free movement
                GameObject.Find("GuidedTelepoints").SetActive(false);
                GameObject.Find("TeleportingParent").transform.Find("FreeTelepoints").gameObject.SetActive(true);
                // Disable trigger areas for movement toggle
                GameObject.Find("Triggers").SetActive(false);
                break;
            case 5:
                // Switch from familiarization scene to transition scene
                SceneManager.LoadScene(1, LoadSceneMode.Single);
                break;
            default:
                    break;
        }
    }
}
