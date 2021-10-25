using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System.Linq;

[CreateAssetMenu(fileName = "DistanceFromTarget", menuName = "Area/DistanceFromTarget", order = 0)]

public class AreaAoe : ScriptableArea
{
    public float distance;
    public override List<HNode> Area(HNode origin, HNode target)
    {
        List<HNode> aoe = HexagonalMapView.MainMap.nodes.Where(p => HNode.SquaredDistance(p, target) < distance).ToList<HNode>();// && p != node).ToList<HNode>();
        return aoe;
    }
}
