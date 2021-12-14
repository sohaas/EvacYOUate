using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{

    public static EventManager instance;
    private bool started = false;
    private GameObject _next; 

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _next = GameObject.Find("Trigger 1");
    }

    private void Update()
    {
        // move first event to start function 
        if (!started)
        {
            started = true;
            RobotAt(0, _next);
        }
    }

    public event Action<int, GameObject> robotAt;
    public void RobotAt(int id, GameObject next)
    {
        robotAt?.Invoke(id, next);
    }
}
