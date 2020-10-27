using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public GameLoader gameLoader;
    public TurnSystem turnSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScenario(string scenario_id) {
        gameLoader.LoadScenario(scenario_id);
        turnSystem.OnScenarioLoaded();
    }
    public void SaveGameState() { 

    }
    public void LoadGameState() { 

    }
}
