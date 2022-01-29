using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    [SerializeField] private int exitNr;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("EXIT");
        
        if (other.gameObject.tag == "Player")
        {
            EventManager.instance.Exited(exitNr);
            // CapturePosition.SaveJson();
        }
        
    }
}
