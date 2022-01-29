using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class ConditionManager : MonoBehaviour
{
    public int[] conditionCounter = new int[4];
    public int participant = 0;
    private int _condition;

    // TODO: Outsource to utils file 
    public const int N_INSTRUCTIONS = 4;
    public const int N_PARTICIPANTS = 8;
    private const string PATH = "./Assets/Serialized/conditions.bin";

    [SerializeField] private AudioData testAudios;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        LoadConditions();
        participant++;
        GetCondition();
        SceneManagement.condition = _condition;

         _audioSource = GameObject.Find("Canvas4").GetComponent<AudioSource>();      
         EventManager.instance.testAudio += PlayTestAudio;
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
    }

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

    private void SaveConditions()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(PATH, FileMode.Create);

        ConditionData data = new ConditionData(this);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    void PlayTestAudio()
    {
        var clip = testAudios.Clip(_condition / 2);

        if (clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }

    void OnDestroy()
    {
        SaveConditions();
    }
}
