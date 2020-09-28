using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using notbloom.HexagonalMap;
public class RoundsEngine : MonoBehaviour
{
    public int roundNumber { get; }

    public List<ScriptableAgent> agents;


    void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        FindAgents();
    }
    public void FindAgents()
    {
        agents = HexagonalMapView.MainMap.nodes.Where(x => x.occupant != null).
        Select(q => q.occupant).
        Where(o => o.agent != null).Select(y => y.agent).ToList();
        foreach (ScriptableAgent agent in agents)
        {
            Debug.Log(agent.name);
        }
    }
    public void Step()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
