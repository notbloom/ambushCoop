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
        // foreach (AgentBase agent in agents)
        // {
        //     //Debug.Log(agent.name);
        // }
    }
    public static void StartRound()
    {
        instance.agents[agentIndex].PlayTurn();
    }
    public static void RegisterAgent() { }
    public static void RemoveAgent(AgentBase agentBase)
    {
        instance.agents.Remove(agentBase);
        agentBase.node.occupant = null;
    }

    public static void NextTurn()
    {
        agentIndex++;
        if (agentIndex >= instance.agents.Count)
        {
            agentIndex = 0;
        }
        instance.agents[agentIndex].PlayTurn();
    }
    public static void EndTurn(AgentBase agent)
    {
        Debug.Log("END TURN");
        NextTurn();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
