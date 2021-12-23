using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{

    public static EventManager instance;
    // TODO: move to experiment manager; hide in inspector
    public bool interacting = false;

    void Awake()
    {
        instance = this;
    }

    /*TODO: trigger in Experiment Manager*/
    public event Action startedExperiment;
    public void StartedExperiment()
    {
        startedExperiment?.Invoke();
    }

    public event Action enteredInteraction;
    public void EnteredInteraction()
    {
        enteredInteraction?.Invoke();
    }

    public event Action playedInteraction;
    public void PlayedInteraction()
    {
        playedInteraction?.Invoke();
    }

    public event Action leftInteraction;
    public void LeftInteraction()
    {
        leftInteraction?.Invoke();
    }
}
