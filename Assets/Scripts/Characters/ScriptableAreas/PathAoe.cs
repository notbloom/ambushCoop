using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System.Linq;

[CreateAssetMenu(fileName = "Path", menuName = "Area/Path", order = 0)]

public class PathAoe : ScriptableArea
{
    public int maxSteps;
    public override List<HNode> Targets(HNode origin, HNode target)
    {
        //List<HNode> aoe = HPathFinder.GetShortestPathDijkstra(origin, target);
        List<HNode> aoe = HPathFinder.AIClosestToObjective(origin, target, maxSteps, origin.occupant.faction);
        if (aoe.Count > maxSteps)
            aoe.RemoveRange(maxSteps, aoe.Count - maxSteps);
        return aoe;
    }
}
