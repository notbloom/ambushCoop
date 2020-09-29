using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System.Linq;
public class RequestAnyTargetOfTypeInArea : ScriptableTargetRequest
{
    public override List<HNode> Request(List<HNode> area, HObjectFactions targetFaction)
    {
        return area.Where(x => x.occupant.faction == targetFaction).ToList();
    }

}
