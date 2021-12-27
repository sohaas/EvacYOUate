using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTrigger : MonoBehaviour
{
    public bool audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Robot")
        {
            EventManager.instance.EnteredStopPoint(audio);
        }
    }
}
