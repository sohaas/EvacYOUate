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

    /*TODO: trigger in Experiment Manager*/
    public event Action startedExperiment;
    public void StartedExperiment()
    {
        startedExperiment?.Invoke();
    }

    public event Action <bool> enteredStopPoint;
    public void EnteredStopPoint(bool audio)
    {
        enteredStopPoint?.Invoke(audio);
    }

    public event Action<MovementType> playedInteraction;
    public void PlayedInteraction(MovementType move)
    {
        playedInteraction?.Invoke(move);
    }

    public event Action completedInteraction;
    public void CompletedInteraction()
    {
        completedInteraction?.Invoke();
    }

    public event Action startedInteraction;
    public void StartedInteraction()
    {
        startedInteraction?.Invoke();
    }

    public event Action requestedRepeat;
    public void RequestedRepeat()
    {
        requestedRepeat?.Invoke();
    }

    public event Action<int> exited;
    public void Exited(int exitNr)
    {
        exited?.Invoke(exitNr);
    }

    public event Action timeIsUp;
    public void TimeIsUp()
    {
        timeIsUp?.Invoke();
    }

    public event Action<MovementType> afterShock; 
    public void AfterShock(MovementType move)
    {
        afterShock?.Invoke(move);
    }

    public event Action testAudio;
    public void TestAudio()
    {
        testAudio?.Invoke();
    }
}
