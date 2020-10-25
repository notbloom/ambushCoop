using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using notbloom.HexagonalMap;
public class RoundsEngine : MonoBehaviour
{
    static RoundsEngine instance;
    public int roundNumber { get; }
    public static List<AgentBase> AllAgents
    {
        get { return instance.agents; }
    }
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
        //instance.initiativeViews[agentIndex].OnTurnStart();
        AnimationInvoker.Enqueue(new InitiativeTurnAnimationCommand(instance.initiativeViews[agentIndex], true, 0.2f));
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
        AnimationInvoker.Enqueue(new InitiativeTurnAnimationCommand(instance.initiativeViews[agentIndex], true, 0.2f));
        instance.agents[agentIndex].PlayTurn();
    }
    public static void EndTurn(AgentBase agent)
    {
        //        instance.initiativeViews[agentIndex].OnTurnEnd();
        AnimationInvoker.Enqueue(new InitiativeTurnAnimationCommand(instance.initiativeViews[agentIndex], false, 0.2f));

        Debug.Log("END TURN");
        NextTurn();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void SaveScenario()
    {
        ScenarioData data = new ScenarioData();
        //REGISTER NODES
        data.string_id = "test_scenario";
        data.s_nodes = new List<NodeData>();
        foreach (HNode hnode in HexagonalMapView.MainMap.nodes)
        {
            data.s_nodes.Add(new NodeData(hnode));
        }
        //REGISTER OBJECTS
        data.s_objects = new List<ObjectInstaceData>();
        //OBJECTS -> ENEMY AGENTS
        List<EnemyAgent> agentBases = GameObject.FindObjectsOfType<EnemyAgent>().ToList();
        foreach (EnemyAgent agent in agentBases)
        {
            data.s_objects.Add(new ObjectInstaceData(agent));
        }
        ScenarioData.Save(data);
    }
    public void LoadScenario()
    {
        //HexagonalMapView.GenericMap();
        LoadScenario(ScenarioData.Load("test_scenario"));
        
    }
    public void LoadScenario(ScenarioData data)
    {
        //Create Map
        HexagonalMapView.CreateMapFromNodeData(data.s_nodes);
        //Spawn Enemies
        foreach (ObjectInstaceData objData in data.s_objects)
        {
            Debug.Log("Enemies/" + objData.string_id);
            GameObject instance = Instantiate(Resources.Load("Enemies/" + objData.string_id, typeof(GameObject))) as GameObject;

            ISpawn ispawn = instance.GetComponent<ISpawn>();
            if (ispawn != null)
                ispawn.Spawn(objData);
        }
        //SpawnPlayers();
    }
    public void SpawnPlayers() {        
        PlayerAgent[] players = GameObject.FindObjectsOfType<PlayerAgent>();
        //TODO SPAWN POINTS
        foreach (PlayerAgent player in players)
        {
            player.Spawn(new ObjectInstaceData(new NodeData(7, 23)));
        }

    }
}
