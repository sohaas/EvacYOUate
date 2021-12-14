using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{

    public static EventManager instance;
    private GameObject _next; 

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // TODO: maybe nicer to call RobotAt from somewhere else (to keep independence)
        _next = GameObject.Find("Trigger 1");
        RobotAt(0, _next);
    }

    /**
     * TRIGGER ROBOT AT:
     * 
     * id == 2:
     * play introduction
     * maybe let the robot ask, whether the participant is ready to follow;
     * can confirm with a button press -> triggers robot to move to trigger point 3
     * 
     * id == 3:
     * play instruction 1: step over
     * end of instructions triggers robot to go to trigger point 4
     * 
     * id == 4:
     * wait for participant to step over the rubble and trigger the next step, maybe 
     * turn towards the participant while waiting; the participant successfully stepping
     * over the the rubble triggers the robot to move to trigger point 5; also triggers
     * the robot to say something encouraging/approving?
     * 
     * id == 5-8: 
     * moving to the next instruction point via next
     * 
     * id == 9:
     * 
     */

    public event Action<int, GameObject> robotAt;
    public void RobotAt(int id, GameObject next)
    {
        robotAt?.Invoke(id, next);
    }
}
