﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System.Linq;

[CreateAssetMenu(fileName = "CleaveArea", menuName = "Area/CleaveArea", order = 0)]

public class CleaveAoe : ScriptableArea
{
    public float distance;
    public ScriptableArea ringArea;
    public ScriptableArea distanceArea;
    public override List<HNode> Targets(HNode origin, HNode target)
    {

        List<HNode> originRing = ringArea.Targets(origin, null);
        List<HNode> targetArea = distanceArea.Targets(target, null);
        //HexagonalMapView.MainMap.nodes.Where(p => HNode.SquaredDistance(p, origin) < originTargetDistance).ToList<HNode>();
        List<HNode> aoe = originRing.Where(p => targetArea.Contains(p)).ToList<HNode>();

        return aoe;
    }
}
