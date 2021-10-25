using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;

[CreateAssetMenu(fileName = "PlayerStartLocationAction", menuName = "TurnActions/PlayerStartLocationAction", order = 0)]
public class PlayerStartLocationAction : ScriptableAction
{
    public override void PerformAction(HNode from, List<HNode> targets, AgentBase agent)
    {
        if (targets.Count == 0)
            return;

        HNode target = targets[0];

        if (HexagonalMapView.MainMap.startingNodes.Contains(target) && target.occupant == null) {
            if (agent.agent == null)
            {
                agent.Create();
                target.occupant = agent.agent;
                agent.node = target;
                agent.transform.position = target.ToVector3();
            } else {
                agent.node.occupant = null;
                target.occupant = agent.agent;
                agent.node = target;
                agent.transform.position = target.ToVector3();
            }
        }
        
    }
}
