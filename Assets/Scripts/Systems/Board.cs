using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameLoader gameLoader;
    public TurnSystem turnSystem;
    public AreaView areaView;
    private static Board instance;
    // Start is called before the first frame update
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
    }

    public PlayerClient PlayerByID(string id)
    {
        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void LoadScenario(string scenario_id)
    {
        instance.gameLoader.LoadScenario(scenario_id);
        instance.turnSystem.OnScenarioLoaded();
        instance.areaView.Init();

    }
    //public void LoadScenario(string scenario_id) {
    //     gameLoader.LoadScenario(scenario_id);
    //     turnSystem.OnScenarioLoaded();
    //     areaView.Init();
    // }
    public void SaveGameState()
    {

    }
    public void LoadGameState()
    {

    }
}
