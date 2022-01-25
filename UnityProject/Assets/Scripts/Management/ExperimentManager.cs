using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExperimentManager : MonoBehaviour
{
    // TODO: Outsource to utils file 
    public const int N_INSTRUCTIONS = 4;
    public const int N_PARTICIPANTS = 50;
    private const string PATH = "./Assets/Serialized/conditions.bin";

    public int[] conditionCounter = new int[4];
    public AudioData[] instructionAudios;
    public int participant = 0;
    public static ExperimentManager instance;

    private int _condition;

    [SerializeField] Timer timer;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        EventManager.instance.exited += LoadEndScene;

        // prepare condition dependent data
        LoadConditions();
        participant++;
        GetCondition();

        // set timer
        timer.SetDuration(300).Begin();
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

    void LoadEndScene(int sceneNr)
    {
        SceneManager.LoadScene(sceneNr, LoadSceneMode.Single);
    }

    void OnDestroy()
    {
        EventManager.instance.exited -= LoadEndScene;

        SaveConditions();
    }




}
