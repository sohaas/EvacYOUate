using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotController : MonoBehaviour
{

    void Start()
    {
        EventManager.instance.robotAt += OnTriggerPoint;
    }

    public void MoveTo(Vector3 position)
    {
        transform.position = position;
    }

    public void OnTriggerPoint(int id)
    {
        // trigger pause and continue of robot path
    }

    private void OnDestroy()
    {
        EventManager.instance.robotAt -= OnTriggerPoint;
    }

}
