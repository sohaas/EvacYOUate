using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{
    // single instance of manager
    public static SceneManagement instance;

    // data that needs to be accessible across scenes
    public static int condition;

    void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // for testing
        // Debug.Log("Staring");
        // Invoke("LoadScene", 15);
    }

    void LoadScene()
    {
        // for testing
        Debug.Log("Loading Scene");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    void LoadScene(int sceneNr)
    {
        SceneManager.LoadScene(sceneNr, LoadSceneMode.Single);
    }
}
