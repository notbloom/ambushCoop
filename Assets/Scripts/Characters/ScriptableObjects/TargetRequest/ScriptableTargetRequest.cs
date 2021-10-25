using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
public abstract class ScriptableTargetRequest : ScriptableObject
{
    public abstract List<HNode> Request(List<HNode> range, ScriptableArea scriptableArea, HObjectFactions targetFaction);
}
