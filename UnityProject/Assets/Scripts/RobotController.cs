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

    private void OnTriggerPoint(int id, GameObject next)
    {
        if (next != null)
        {
            MoveTo(next.transform.position);
        }
    }

    private void OnDestroy()
    {
        EventManager.instance.robotAt -= OnTriggerPoint;
    }

}
