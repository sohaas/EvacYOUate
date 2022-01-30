using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExperimentManager : MonoBehaviour
{
    public static int _condition;

    public AudioData[] instructionAudios;
    // public AudioData testAudio;

    private GameObject timerUI;

    [SerializeField] Timer timerFront;
    [SerializeField] Timer timerBack;

    // Single instance of manager
    public static ExperimentManager instance;

    void Awake()
    {
        // Singleton pattern
        instance = this;
    }

    void Start()
    {
        _condition = SceneManagement.condition;
        AudioManager.instance.instructions = instructionAudios[_condition];

        timerFront.SetDuration(360).Begin();
        timerBack.SetDuration(360).Begin();

        EventManager.instance.exited += LoadScene;
        EventManager.instance.timeIsUp += ShowCanvas;
        EventManager.instance.afterShock += HideCanvas;
    }

    void ShowCanvas()
    {
        // GameObject.Find("VRCamera").transform.Find("TimerUI").gameObject.SetActive(true);
        Debug.Log("Show Canvas");
    }

    void HideCanvas(MovementType move)
    {
        // GameObject.Find("TimerUI").gameObject.SetActive(false);
        Debug.Log("Hide Canvas");
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
