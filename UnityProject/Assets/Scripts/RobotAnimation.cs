using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class RobotAnimation : MonoBehaviour
{
    // Animations for movement
    public RuntimeAnimatorController anim_forward;
    public RuntimeAnimatorController anim_backward;
    public RuntimeAnimatorController anim_right;
    public RuntimeAnimatorController anim_left;
    
    // Target loactions for path
    public Transform[] targets;
    private int _current; // To count the current location
    private float _neededRotation;
    private int _frameCounter;
    
    // Speeds for movement // TODO: Could make this public
    private float _turningSpeed = 0.8F;
    private float _movementSpeed = 1F;
    
    // Start is called before the first frame update
    void Start()
    {
        _current = 0;
        _neededRotation = 0;
        _frameCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
                if (Vector3.Distance(transform.position, targets[_current].position) < 0.001F)
                {
                    // set the robot to this position
                    transform.position = targets[_current].position;
                }
            }
            else // we are not yet at the desired rotation and have to adjust the animation direction
            {
                // Debug.Log(fromY);
                // Debug.Log(toY);

                float clockwise = 0F;
                float counterClockwise = 0f;
                
                if (fromY <= toY)
                {
                    clockwise = toY - fromY;
                    counterClockwise = fromY + (360 - toY);
                }
                else
                {
                    clockwise = (360 - fromY) + toY;
                    counterClockwise = fromY - toY;
                }

                if (clockwise <= counterClockwise)
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

        if (_current >= targets.Length)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        
        _frameCounter += 1;
    }
}
