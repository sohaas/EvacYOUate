using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRobotPosition : MonoBehaviour
{
    public int triggerPointId;

    // TODO: Add ids/tags to player and robot and check whether id/tag == robot

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Robot")
        {
            EventManager.instance.EnteredInteraction();
        }
    }
}
