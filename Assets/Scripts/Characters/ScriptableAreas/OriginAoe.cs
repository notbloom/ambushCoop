using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System.Linq;

[CreateAssetMenu(fileName = "DistanceFromOrigin", menuName = "Area/DistanceFromOrigin", order = 0)]

public class OriginAoe : ScriptableArea
{
    public float distance;
    public override List<HNode> Targets(HNode origin, HNode target)
    {
        List<HNode> aoe = HexagonalMapView.MainMap.nodes.Where(p => HNode.SquaredDistance(p, origin) < distance).ToList<HNode>();// && p != node).ToList<HNode>();
        return aoe;
    }
}
