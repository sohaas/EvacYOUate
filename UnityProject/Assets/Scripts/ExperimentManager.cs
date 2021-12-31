using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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

    // TODO: Outsource to utils file 
    public const int N_INSTRUCTIONS = 4;
    public const int N_PARTICIPANTS = 5;
    private const string PATH = "./Assets/Serialized/conditions.bin";

    public int[] conditionCounter = new int[4];
    public AudioData[] instructionAudios;
    public int participant = 0;
    public static ExperimentManager instance;

    private int[] _compliance = new int[N_INSTRUCTIONS];
    private int _condition;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        EventManager.instance.complied += UpdateCompliance;

        LoadConditions();
        participant++;
        GetCondition();
    }


    // Updates the compliance score when Player collides with trigger.
    private void UpdateCompliance(int pos, int degree)
    {
        _compliance[pos] = degree;
    }


    // Assigns a random experiment condition.
    private void GetCondition()
    {
        if (participant > N_PARTICIPANTS)
        {
            Debug.Log("Maximal number of participants has been reached!");
            // TODO: invoke an event that stops the experiment
            return;
        }
        else if ((N_PARTICIPANTS - participant) < (N_PARTICIPANTS % 4))
        {
            do
            {
                _condition = Random.Range(0, 4);
            } while (conditionCounter[_condition] >= (N_PARTICIPANTS / 4) + 1);
        }
        else
        {
            do
            {
                _condition = Random.Range(0, 4);
            } while (conditionCounter[_condition] >= (N_PARTICIPANTS / 4));
        }

        conditionCounter[_condition]++;
        AudioManager.instance.instructions = instructionAudios[_condition];
    }


    // TODO: outsource to fileManager
    private void SaveConditions()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(PATH, FileMode.Create);

        ConditionData data = new ConditionData(instance);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    // TODO: Outsource to fileManager
    private void LoadConditions()
    {
        if (File.Exists(PATH))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(PATH, FileMode.Open);

            ConditionData data = formatter.Deserialize(stream) as ConditionData;
            stream.Close();

            participant = data.participant;
            conditionCounter = new int[4];
            for (int i = 0; i < conditionCounter.Length; i++)
            {
                conditionCounter[i] = data.conditions[i];
            }
        } 
        else
        {
            conditionCounter = new int[4];
        }
    }

    void OnDestroy()
    {
        EventManager.instance.complied -= UpdateCompliance;
        SaveConditions();
    }




}
