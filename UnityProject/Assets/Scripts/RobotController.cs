using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotController : MonoBehaviour
{

    public Transform target;
    public float t;

    void Start()
    {
        EventManager.instance.expStarted += MoveTo;
        EventManager.instance.robotMovedTo += OnTriggerPoint;
    }

    public void MoveTo()
    {
        transform.position = target.position;
    }

    public void OnTriggerPoint(int id)
    {
        if (id == 1)
        {
            Debug.Log("Works");
        }
    }

    private void OnDestroy()
    {
        EventManager.instance.expStarted -= MoveTo;
        EventManager.instance.robotMovedTo -= OnTriggerPoint;
    }

}
