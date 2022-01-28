using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlayerFamiliarize : MonoBehaviour
{
    public bool showController = false;

    private ContinuousMove continuousMovement;
    private GameObject teleParent;
    

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to events
        EventManager.instance.startedInteraction += ToggleToContinuous;
        EventManager.instance.completedInteraction += ToggleToTele;

        // Get components and objects needed for en- and disabling
        continuousMovement = GetComponent<ContinuousMove>();
        teleParent = GameObject.Find("TeleportingParent");
        
        //Invoke("ToggleToTele", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var hand in Player.instance.hands)
        {
            if (showController)
            {
                hand.ShowController();
                hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithController);
            }
            else
            {
                hand.HideController();
                hand.SetSkeletonRangeOfMotion(Valve.VR.EVRSkeletalMotionRange.WithoutController);
            }
        }
    }

    void ToggleToTele()
    {
        // Toggle to Teleportation
        continuousMovement.enabled = false;
        teleParent.transform.Find("Teleporting").gameObject.SetActive(true);
        teleParent.transform.Find("GuidedTelepoints").gameObject.SetActive(true);

        Debug.Log("Toggled to Teleporting");
    }

    void ToggleToContinuous()
    {
        // Toggle to Continuous Movement
        continuousMovement.enabled = true;
        GameObject.Find("Teleporting").SetActive(false);
        GameObject.Find("GuidedTelepoints").SetActive(false);

        Debug.Log("Toggled to Continuous Movement");
    }

    void onDestroy()
    {
        EventManager.instance.startedInteraction -= ToggleToContinuous;
        EventManager.instance.completedInteraction -= ToggleToTele;
    }
}
