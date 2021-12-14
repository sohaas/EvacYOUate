using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRobotPosition : MonoBehaviour
{

    public int triggerPointId;
    public GameObject next;

    /**
     * TRIGGERS:
     * 1: Intermediate point on the way to the participant -> change direction, go to point 2
     * 2: In front of the participant (starting point)     -> play intro
     * 3: In front of the rubble                           -> play instruction 1, move to point 4
     * 4: Behind the rubble                                -> wait for the participant, maybe turn towards him
     * 5: Intermediate point on the way to instruction 2   -> change direction, go to point 6
     * 6: Intermediate point on the way to instruction 2   -> change direction, go to point 7
     * 7: Intermediate point on the way to instruction 2   -> change direction, go to point 8
     * 8: Intermediate point on the way to instruction 2   -> change direction, go to point 9
     * 9: In front of toppled shelf                        -> play instruction 2, move to point 10
     */

    // TODO: Add ids/tags to player and robot and check whether id/tag == robot

    private void OnTriggerEnter(Collider other)
    {
        EventManager.instance.RobotAt(triggerPointId, next);
    }
}
