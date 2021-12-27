using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentManager : MonoBehaviour
{
    /**
     * COMPLIANCE:
     * 
     * instruction 1: stepping over
     * problem: You have to step over the debris in order to leave the room
     * trigger: Left/right side of the door frame
     * 
     * instruction 2: detour
     * problem: partial compliance
     * trigger: door frame vs. corridor
     * 
     * instruction 3: ducking
     * trigger: depends on how the participant has to do it (actually ducking vs. 
     * pressing  a button)
     * 
     * instruction 4: crawling 
     * trigger: depends on how the participant has to do it (actually going down
     * on all fours vs. pressing a button)
     */

    private const int N_INSTRUCTIONS = 4;
    private int[] _compliance = new int[N_INSTRUCTIONS];

    public static ExperimentManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        EventManager.instance.complied += UpdateCompliance;
    }

    private void UpdateCompliance(int pos, int degree)
    {
        _compliance[pos] = degree;
    }

    void OnDestroy()
    {
        EventManager.instance.complied -= UpdateCompliance;
    }




}
