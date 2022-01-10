using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    public float rotationSpeed = 200F;
    
    void Update()
    {
        // Rotate the object around itself at a given rotation speed
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime), Space.Self);
    }
}
