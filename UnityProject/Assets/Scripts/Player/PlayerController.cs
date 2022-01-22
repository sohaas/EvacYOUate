using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{
    public bool showController = false;

    private ContinuousMove continuousMovement;
    private GameObject teleParent;

    private bool started = true;
    private bool active;


    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to events
        EventManager.instance.startedInteraction += DisableMovement;
        EventManager.instance.playedInteraction += EnableMovement;
        EventManager.instance.completedInteraction += ToggleToTele;

        // Get components and objects needed for en- and disabling
        continuousMovement = GetComponent<ContinuousMove>();
        teleParent = GameObject.Find("TeleportingParent");

        // movement disabled until introduction is finished
        Invoke("DisableMovement", 0.7f);
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
        // toggle to Teleportation
        continuousMovement.enabled = false;
        teleParent.transform.Find("Teleporting").gameObject.SetActive(true);
        teleParent.transform.Find("TelePoints").gameObject.SetActive(true);

        Debug.Log("Toggled to Teleporting");
    }

    void ToggleToContinuous()
    {
        // Toggle to Continuous Movement
        continuousMovement.enabled = true;
        GameObject.Find("Teleporting").SetActive(false);
        GameObject.Find("TelePoints").SetActive(false);

        Debug.Log("Toggled to Continuous Movement");
    }

    void DisableMovement()
    {
        if (AudioManager.instance.playing || started)
        {
            continuousMovement.enabled = false;
            GameObject.Find("Teleporting").SetActive(false);
            GameObject.Find("TelePoints").SetActive(false);

            started = false;
            active = false;

            Debug.Log("Disabled Movement");
        }
        else
        {
            ToggleToContinuous();
        }
        
    }

    void EnableMovement(MovementType move)
    {
        if (!active)
        {
            if (move == MovementType.CONTINUOUS)
            {
                continuousMovement.enabled = true;

                Debug.Log("Enabled Continuous Movement");
            }
            else if (move == MovementType.TELE)
            {
                teleParent.transform.Find("Teleporting").gameObject.SetActive(true);
                teleParent.transform.Find("TelePoints").gameObject.SetActive(true);

                Debug.Log("Enabled Teleportation");
            }

            active = true;
        }  
    }

    void onDestroy()
    {
        EventManager.instance.startedInteraction -= DisableMovement;
        EventManager.instance.playedInteraction -= EnableMovement;
        EventManager.instance.completedInteraction -= ToggleToTele;
    }
}
