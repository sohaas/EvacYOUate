using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] bool endInteraction;
    [SerializeField] bool startInteraction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (endInteraction) 
            {
                EventManager.instance.CompletedInteraction();
            }
            else if (startInteraction)
            {
                EventManager.instance.StartedInteraction();
            }
            else if (this.gameObject.tag == "StandUp")
            {
                EventManager.instance.EnteredStopPoint(true);
            }

            // disable current trigger
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
