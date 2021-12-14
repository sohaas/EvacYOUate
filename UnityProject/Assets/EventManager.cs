using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{

    public static EventManager instance;
    private bool started = false;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (!started)
        {
            started = true;
            StartGame();
        }
    }

    public event Action expStarted;
    public void StartGame()
    {
        expStarted?.Invoke();
    }

    public event Action<int> robotMovedTo;
    public void RobotMovedTo(int id)
    {
        robotMovedTo?.Invoke(id);
    }
}
