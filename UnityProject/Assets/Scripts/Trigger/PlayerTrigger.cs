using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] bool endInteraction;
    [SerializeField] bool startInteraction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && endInteraction) 
        {
            EventManager.instance.CompletedInteraction();
        }
        else if (other.gameObject.tag == "Player" && startInteraction)
        {
            EventManager.instance.StartedInteraction();
        }
    }
}
