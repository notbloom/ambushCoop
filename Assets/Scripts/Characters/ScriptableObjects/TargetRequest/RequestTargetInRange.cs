using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System.Linq;

[CreateAssetMenu(fileName = "RequestTargetInRange", menuName = "TurnActions/RequestTarget/RequestTargetInRange", order = 0)]

//TODO IMPLEMENT THIS, IT'S ONLY GRABBING ANY TARGET
public class RequestTargetInRange : ScriptableTargetRequest
{
    public override List<HNode> Request(List<HNode> range, ScriptableArea area, HObjectFactions targetFaction)
    {
        List<HNode> targets = range
        .Where(o => o.occupant != null)
        .Where(p => p.occupant.faction == targetFaction)
        .ToList();
        return targets;
    }

}
