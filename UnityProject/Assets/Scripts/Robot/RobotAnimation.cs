using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor;
using UnityEngine;

public class RobotAnimation : MonoBehaviour
{
    // Animations for movement
    public RuntimeAnimatorController anim_forward;
    public RuntimeAnimatorController anim_backward;
    public RuntimeAnimatorController anim_right;
    public RuntimeAnimatorController anim_left;
    
    // Take care that we only move if currently no instructions are given
    private bool _instructionRunning;
    
    // Target loactions for path
    public Transform[] targets;
    private int _current; // To count the current location
    private int _frameCounter;
    
    // Rotation direction information
    private float _clockwise = 0F;
    private float _counterClockwise = 0f;
    
    // Speeds for movement // TODO: Could make this public, adjust them to really match the wheel rotation speed
    public float _turningSpeed = 0.3F;
    public float _movementSpeed = 0.4F;
    
    // Start is called before the first frame update
    void Start()
    {
        _current = 0;
        _frameCounter = 0;
        _instructionRunning = false;

        EventManager.instance.enteredStopPoint += Pause;
        EventManager.instance.timeIsUp += Pause;
        EventManager.instance.playedInteraction += Move;
        EventManager.instance.completedInteraction += Move;
        EventManager.instance.afterShock += Move;
    }

    // Update is called once per frame
    void Update()
    {
        // Do not update if we are currently in an instruction phase
        if (!_instructionRunning)
        {
            // Enable animations
            GetComponent<Animator>().enabled = true;
            
            // Check for the next position
            if (transform.position != targets[_current].position)
            {
                // Determine which direction to rotate towards
                Vector3 targetDirection = targets[_current].position - transform.position;
                var rotation = Quaternion.LookRotation(targetDirection); // the target rotation

                // The step size is equal to speed times frame time.
                float singleStep = _turningSpeed * Time.deltaTime;

                // Rotate the forward vector towards the target direction by one step
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
                
                float fromY = transform.rotation.eulerAngles.y;
                float toY = rotation.eulerAngles.y;

                // Check whether we have roughly met the desired rotation
                if (Mathf.Abs(fromY - toY) < 0.5F)
                {
                    // Adjust the rotation to the specifically desired rotation
                    transform.rotation = rotation;
                    
                    // Move forward
                    GetComponent<Animator>().runtimeAnimatorController = anim_forward;
                    transform.position = Vector3.MoveTowards(transform.position, targets[_current].position,
                        _movementSpeed * Time.deltaTime);

                    // Check if the position of robot and target are approximately equal
                    if (Vector3.Distance(transform.position, targets[_current].position) < 0.002F) // TODO: 0.001F start value
                    {
                        // set the robot to this position
                        transform.position = targets[_current].position;
                    }
                }
                else // we are not yet at the desired rotation and have to adjust the animation direction
                {
                    // First get the rotation in a clockwise and counterclockwise direction
                    if (fromY <= toY)
                    {
                        _clockwise = toY - fromY;
                        _counterClockwise = fromY + (360 - toY);
                    }
                    else
                    {
                        _clockwise = (360 - fromY) + toY;
                        _counterClockwise = fromY - toY;
                    }
                    
                    // Set the correct animation dependent on the rotation direction
                    if (_clockwise <= _counterClockwise)
                    {
                        GetComponent<Animator>().runtimeAnimatorController = anim_right;
                    }
                    else
                    {
                        GetComponent<Animator>().runtimeAnimatorController = anim_left;
                    }
                }
            }
            else
            {
                _current += 1;
            }
        }
        else
        {
            // no animation during an instruction phase
            GetComponent<Animator>().enabled = false;
        }

        _frameCounter += 1;
    }

    // to be called by event with MovementType
    void Move(MovementType type)
    {
        _instructionRunning = false;
    } 

    // to be called by event without MovementType
    void Move()
    {
        _instructionRunning = false;
    }

    // to be called by event with bool
    void Pause(bool audio)
    {
        _instructionRunning = true;
    }

    // to be called by event without bool
    void Pause()
    {
        _instructionRunning = true;
    }
}
