using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using notbloom.HexagonalMap;

public class AgentTurnHandler
{
    List<AgentBase> AllAgents;
    List<AgentBase> currentQueue;
    public void Add(AgentBase newAgent)
    {

    }
}

public enum TurnPhases
{
    start, placingPlayers, play
}
public class TurnSystem : MonoBehaviour
{
    public TurnPhases CurrentPhase;
    static TurnSystem instance;
    public int roundNumber { get; }
    public static List<AgentBase> AllAgents
    {
        get { return instance.agents; }
    }
    public bool isPlacingPlayers;
    public List<AgentBase> agents;

    public GameObject agentInitiativeView;
    public Transform agentInitiativeViewParent;
    public List<InitiativeView> initiativeViews;
    public static int agentIndex = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        //StartGame();
    }
    public void OnScenarioLoaded()
    {
        CurrentPhase = TurnPhases.placingPlayers;
    }
    public bool isAgentPlaying(AgentBase agent)
    {
        if (isPlacingPlayers)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public AgentBase FindAgentBaseByID(string agent_id)
    {
        //TODO CHANGE TO UNIQUE ID 
        agents = GameObject.FindObjectsOfType<AgentBase>().ToList();
        //return agents.Where(a => a.agentID.unique_id == agent_id).First();
        return agents.Where(a => a.string_id == agent_id).First();
    }
    public void RequestPlacePlayers()
    {
        isPlacingPlayers = true;
    }
    public void OnPlayerPressedEndTurn()
    {
        EndTurn(null);
    }
    public void StartGame()
    {
        FindAgents();
        StartRound();
    }
    public void FindAgents()
    {
        agents = GameObject.FindObjectsOfType<AgentBase>().ToList();
        // agents = HexagonalMapView.MainMap.nodes.Where(x => x.occupant != null).
        // Select(q => q.occupant).
        // Where(o => o.agent != null).Select(y => y.agent).ToList();
        initiativeViews = new List<InitiativeView>();
        foreach (AgentBase agent in agents)
        {
            GameObject agentView = Instantiate(agentInitiativeView, Vector3.zero, Quaternion.identity);
            agentView.transform.parent = agentInitiativeViewParent;
            InitiativeView iView = agentView.GetComponent<InitiativeView>();
            iView.Populate(agent);
            initiativeViews.Add(iView);
        }
    }
    public static void StartRound()
    {
        instance.CurrentPhase = TurnPhases.play;
        //instance.initiativeViews[agentIndex].OnTurnStart();
  //      AnimationInvoker.Enqueue(new InitiativeTurnAnimationCommand(instance.initiativeViews[agentIndex], true, 0.2f));
        instance.agents[agentIndex].PlayTurn();

    }
    public static void RegisterAgent() { }
    public static void RemoveAgent(AgentBase agentBase)
    {
        instance.agents.Remove(agentBase);
        //TODO animate death and remove agent from lists
        //InitiativeView iView = instance.initiativeViews.Where(x => x.agentBase == agentBase).First();
        //instance.initiativeViews.Remove(iView);
        //Destroy(iView.gameObject);
        agentBase.node.occupant = null;
    }

    public static void NextTurn()
    {
        agentIndex++;
        if (agentIndex >= instance.agents.Count)
        {
            agentIndex = 0;
        }
        //Todo que pasa si yo me muevo y tu te queris mover a donde mismo antes q aparezca la animacion
//        AnimationInvoker.Enqueue(new InitiativeTurnAnimationCommand(instance.initiativeViews[agentIndex], true, 0.2f));
        instance.agents[agentIndex].PlayTurn();
    }
    public static void EndTurn(AgentBase agent)
    {
        //        instance.initiativeViews[agentIndex].OnTurnEnd();
 //       AnimationInvoker.Enqueue(new InitiativeTurnAnimationCommand(instance.initiativeViews[agentIndex], false, 0.2f));

        Debug.Log("END TURN");
        NextTurn();
    }
    // Update is called once per frame
    void Update()
    {

    }


    // public void LoadScenario()
    // {
    //     //HexagonalMapView.GenericMap();
    //     LoadScenario(ScenarioData.Load("test_scenario"));

    // }
    // public void LoadScenario(ScenarioData data)
    // {
    //     //Create Map
    //     //HexagonalMapView.CreateMapFromNodeData(data.s_nodes);
    //     //Spawn Enemies
    //     foreach (ObjectInstaceData objData in data.s_objects)
    //     {
    //         Debug.Log("Enemies/" + objData.string_id);
    //         GameObject instance = Instantiate(Resources.Load("Enemies/" + objData.string_id, typeof(GameObject))) as GameObject;

    //         ISpawn ispawn = instance.GetComponent<ISpawn>();
    //         if (ispawn != null)
    //             ispawn.Spawn(objData);
    //     }
    //     //SpawnPlayers();
    // }
    public void SpawnPlayers()
    {
        PlayerAgent[] players = GameObject.FindObjectsOfType<PlayerAgent>();
        //TODO SPAWN POINTS
        foreach (PlayerAgent player in players)
        {
            player.Spawn(new ObjectInstaceData(new NodeData(7, 23)));
        }

    }
}
