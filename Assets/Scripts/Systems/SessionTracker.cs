using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionTracker : MonoBehaviour
{
    public static SessionTracker instance;
    public const string PlayScene = "PlayScene";
    public string[] scenarioIDs;
    public int currentScenarioIndex = 0;
    public string scenarioID => scenarioIDs[currentScenarioIndex];

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == PlayScene)
        {
       //     Board.LoadScenario(scenarioID);
        }
    }
    public static void NewSession()
    {
        instance.currentScenarioIndex = 0;
        SceneManager.LoadScene(PlayScene);
    }
    public void LoadNext()
    {
        currentScenarioIndex++;

        if (currentScenarioIndex >= scenarioIDs.Length)
        {
            LoadSessionEnd();
        }
        else
        {
            SceneManager.LoadScene(PlayScene);
        }
    }
    public void LoadSessionEnd()
    {

    }
}
