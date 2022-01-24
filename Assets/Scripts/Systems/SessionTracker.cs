using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionTracker : MonoBehaviour
{
    public const string PlayScene = "PlayScene";
    public static SessionTracker instance;
    public int currentScenarioIndex;
    public string[] scenarioIDs;
    public string scenarioID => scenarioIDs[currentScenarioIndex];

    private void Awake()
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
            LoadSessionEnd();
        else
            SceneManager.LoadScene(PlayScene);
    }

    public void LoadSessionEnd()
    {
    }
}