using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustRobotPosition : MonoBehaviour
{
    private float _yPosition = 0.2932F;
    
    void Update()
    {
        transform.position = new Vector3(transform.position.x, _yPosition, transform.position.z);
    }
}
