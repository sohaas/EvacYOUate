using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class NextButton : MonoBehaviour
{
    public static bool buttonListener;
    public SteamVR_Action_Boolean input;
    private GameObject teleParent;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        teleParent = GameObject.Find("TeleportingParent");
        buttonListener = true;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (input.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Debug.Log("Button pressed");
            // Display correct text on canvas
            if (SceneManager.GetActiveScene().buildIndex == 0)
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

            buttonListener = false;
            Invoke("ActivateButton", 5);
        }
    }

    void ActivateButton()
    {
        buttonListener = true;
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
                EventManager.instance.CompletedInteraction();
                buttonListener = false;
                break;
            case 2:
                GameObject.Find("Duck").SetActive(false);
                GameObject.Find("Canvas3").transform.Find("Crawl").gameObject.SetActive(true);
                break;
            case 3:
                EventManager.instance.TestAudio();
                GameObject.Find("Audio").SetActive(false);
                GameObject.Find("Canvas4").transform.Find("Repeat").gameObject.SetActive(true);
                break;
            case 4:
                EventManager.instance.TestAudio();
                GameObject.Find("Repeat").SetActive(false);
                GameObject.Find("Canvas4").transform.Find("Explore").gameObject.SetActive(true);
                // Deactivate other canvases
                GameObject.Find("Canvas1").SetActive(false);
                GameObject.Find("Canvas2").SetActive(false);
                GameObject.Find("Canvas3").SetActive(false);
                // Activate telepoints for free movement
                GameObject.Find("GuidedTelepoints").SetActive(false);
                GameObject.Find("TeleportingParent").transform.Find("FreeTelepoints").gameObject.SetActive(true);
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
