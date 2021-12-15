using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{

    public static EventManager instance;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        /**
         * Trigger start of experiment here
         * -> subscribe start robot path
         * -> subscribe start timer
         */
    }

    /**
     * TRIGGER ROBOT AT:
     * 
     * id == 1:
     * play introduction
     * maybe let the robot ask, whether the participant is ready to follow;
     * can confirm with a button press -> triggers robot to move to trigger point 2
     * 
     * id == 2:
     * play instruction 1: step over
     * end of instructions triggers robot to go to trigger point 3
     * 
     * id == 3:
     * wait for participant to step over the rubble and trigger the next step, maybe 
     * turn towards the participant while waiting; the participant successfully stepping
     * over the the rubble triggers the robot to move to trigger point 4; also triggers
     * the robot to say something encouraging/approving?
     * 
     * id == 4: 
     * play instruction 2: ducking below shelf
     * 
     */

    public event Action<int> robotAt;
    public void RobotAt(int id)
    {
        robotAt?.Invoke(id);
    }
}
