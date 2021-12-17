using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRobotPosition : MonoBehaviour
{
    public int triggerPointId;

    // TODO: Add ids/tags to player and robot and check whether id/tag == robot

    private void OnTriggerEnter(Collider other)
    {
        EventManager.instance.EnteredInteraction();
        Invoke("AfterDelay", 5);
    }

    private void AfterDelay()
    {
        EventManager.instance.LeftInteraction();
    }
}
