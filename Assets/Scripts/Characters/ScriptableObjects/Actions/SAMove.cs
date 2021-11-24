using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;

[CreateAssetMenu(fileName = "Move", menuName = "TurnActions/Move", order = 0)]
public class SAMove : ScriptableAction
{
    public int moveAmount;
    public NodeAnimationFactory animationFactory;
    public override void PerformAction(HNode from, List<HNode> targets, AgentBase agent)
    {
        //TODO REMOVE THIS MAP
        HMapController map = new HMapController();
        //List<HNode> path = HPathFinder.GetShortestPathDijkstra(from, targets[0]);
        if (targets.Count == 0)
            return;

        HNode target = targets[targets.Count - 1];

        if (target.neighbours.Contains(from))
            return;
        List<HNode> path = HPathFinder.AI_Meele(from, targets[targets.Count - 1], moveAmount, agent.faction);
        if (path.Count > 0)
            path.RemoveAt(0);
        foreach (HNode node in path)
        {
//            AnimationInvoker.Enqueue(animationFactory.Generate(agent.gameObject, new List<HNode>() { from }, new List<HNode>() { node }, 0.2f));
            //map.StepObjectTo(from.occupant, node);
            map.StepObjectTo(agent.agent, node);
        }
        //  AnimationInvoker.Enqueue(new DamageAnimation(agent.agent, new HDamageInstance(20f), 0.2f));
        //agent.ReceiveDamage(new HDamageInstance(30f));
    }
}
