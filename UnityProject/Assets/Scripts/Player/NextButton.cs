using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class NextButton : MonoBehaviour
{
    public SteamVR_Action_Boolean input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If trigger is pressed on one of the controllers
        if (input.GetStateDown(SteamVR_Input_Sources.Any))
        {
            // TODO switch scene (should only be possible in 1st scene after intro is finished)

            // Repeat audio
            if (SceneManager.GetActiveScene().buildIndex == 1) 
            {
                EventManager.instance.RequestedRepeat();
            }
        }
    }
}
