using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System.Linq;

//TODO CHANGE SPELLING TO INRANGE
public class RequestAnyTargetOfTypeInArea : ScriptableTargetRequest
{
    public override List<HNode> Request(List<HNode> range, ScriptableArea area, HObjectFactions targetFaction)
    {
        return range.Where(x => x.occupant.faction == targetFaction).ToList();
    }

}
