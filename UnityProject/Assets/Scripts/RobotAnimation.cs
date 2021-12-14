using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class RobotAnimation : MonoBehaviour
{
    public RuntimeAnimatorController anim_forward;
    public RuntimeAnimatorController anim_backward;
    public RuntimeAnimatorController anim_right;
    public RuntimeAnimatorController anim_left;
    private int _frameCounter;
    private int _rotationSpeed = 5;
    private int _movementSpeed = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        _frameCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        // First rotate right
        if (_frameCounter < 10)
        {
            transform.Rotate(0,_rotationSpeed * Time.deltaTime,0);
            GetComponent<Animator>().runtimeAnimatorController = anim_right;
        }
        
        // Move forward
        else if (_frameCounter < 20)
        {
            transform.position += transform.forward * Time.deltaTime * _movementSpeed;
            GetComponent<Animator>().runtimeAnimatorController = anim_forward;
        }
        
        // Move backward
        else if (_frameCounter < 30)
        {
            transform.position -= transform.forward * Time.deltaTime * _movementSpeed;
            GetComponent<Animator>().runtimeAnimatorController = anim_backward;
        }
        
        // Rotate left
        else if (_frameCounter < 40)
        {
            transform.Rotate(0,-_rotationSpeed * Time.deltaTime,0);
            GetComponent<Animator>().runtimeAnimatorController = anim_left;
        }

        else
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }


        _frameCounter += 1;
    }
}
