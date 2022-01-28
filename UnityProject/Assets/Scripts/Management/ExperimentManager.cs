using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExperimentManager : MonoBehaviour
{
    public static int _condition;

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
        AudioManager.instance.instructions = instructionAudios[_condition];

        timer.SetDuration(300).Begin();

        EventManager.instance.exited += LoadScene;
        EventManager.instance.timeIsUp += ShowCanvas;
        EventManager.instance.afterShock += HideCanvas;
    }

    void ShowCanvas()
    {
        GameObject.Find("VRCamera").transform.Find("TimerUI").gameObject.SetActive(true);
    }

    void HideCanvas(MovementType move)
    {
        GameObject.Find("TimerUI").gameObject.SetActive(false);
    }

    void LoadScene(int sceneNr)
    {
        SceneManager.LoadScene(sceneNr, LoadSceneMode.Single);
    }

    void OnDestroy()
    {
        EventManager.instance.exited -= LoadScene;
        EventManager.instance.timeIsUp -= ShowCanvas;
        EventManager.instance.afterShock -= HideCanvas;
    }




}
