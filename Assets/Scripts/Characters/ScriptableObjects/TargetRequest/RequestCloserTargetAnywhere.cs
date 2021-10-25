using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System.Linq;

[CreateAssetMenu(fileName = "new RequestCloserTargetAnywhere", menuName = "TurnActions/RequestTarget/ClosestOfFaction", order = 0)]

//TODO IMPLEMENT THIS, IT'S ONLY GRABBING ANY TARGET
public class RequestCloserTargetAnywhere : ScriptableTargetRequest
{
    public override List<HNode> Request(List<HNode> range, ScriptableArea area, HObjectFactions targetFaction)
    {
        // List<HObject> objects = HexagonalMapView.MainMap.nodes.Where(x => x.occupant != null).
        // Select(q => q.occupant).
        // Where(o => o.agent != null).Where(y => y.agent.faction == targetFaction).ToList();
        List<HNode> objects = TurnSystem.AllAgents.Where(x => x.faction == targetFaction).Select(y => y.node).ToList();
        return objects; //new List<HNode>() { objects[0].node };//area.Where(x => x.occupant.faction == targetFaction).ToList();
    }

}
