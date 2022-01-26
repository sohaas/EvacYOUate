using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExperimentManager : MonoBehaviour
{
    private int _condition;

    // TODO: do they need to be public
    public AudioData[] instructionAudios;
    public AudioData testAudio;

    [SerializeField] Timer timer;

    // Single instance of manager
    public static ExperimentManager instance;

    void Awake()
    {
        // Singleton pattern
        instance = this;
    }

    void Start()
    {
        // TODO: check if that works without Event Manager in the scene
        _condition = SceneManagement.condition;
        Debug.Log(_condition);
        AudioManager.instance.instructions = instructionAudios[_condition];

        timer.SetDuration(300).Begin();

        EventManager.instance.exited += LoadScene;
    }


    void LoadScene(int sceneNr)
    {
        SceneManager.LoadScene(sceneNr, LoadSceneMode.Single);
    }

    void OnDestroy()
    {
        EventManager.instance.exited -= LoadScene;
    }




}
