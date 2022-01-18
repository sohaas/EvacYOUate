using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    [SerializeField] private int exitNr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CapturePosition.SaveJson();
            EventManager.instance.Exited(exitNr);
        }
    }
}
