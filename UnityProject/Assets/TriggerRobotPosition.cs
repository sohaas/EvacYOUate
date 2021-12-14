using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRobotPosition : MonoBehaviour
{

    public int triggerPointId;
    private void OnTriggerEnter(Collider other)
    {
        EventManager.instance.RobotMovedTo(triggerPointId);
    }
}
