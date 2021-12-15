using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRobotPosition : MonoBehaviour
{

    public int triggerPointId;

    /**
     * TRIGGERS:
     * 1: In front of the participant (starting point)     -> play intro
     * 2: In front of the rubble                           -> play instruction 1, move to point 3
     * 3: Behind the rubble                                -> wait for the participant, maybe turn towards him
     * 4: In front of toppled shelf                        -> play instruction 2, move to point 5
     */

    // TODO: Add ids/tags to player and robot and check whether id/tag == robot

    private void OnTriggerEnter(Collider other)
    {
        EventManager.instance.RobotAt(triggerPointId);
    }
}
