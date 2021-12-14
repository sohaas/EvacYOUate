using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRobotPosition : MonoBehaviour
{

    public int triggerPointId;
    public GameObject next;

    private void OnTriggerEnter(Collider other)
    {
        EventManager.instance.RobotAt(triggerPointId, next);
    }
}
