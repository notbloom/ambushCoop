using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System.Linq;

[CreateAssetMenu(fileName = "RingArea", menuName = "Area/RingArea", order = 0)]

public class RingArea : ScriptableArea
{
    public float minDistance;
    public float maxDistance;
    public override List<HNode> Targets(HNode origin, HNode target)
    {
        List<HNode> aoe = HexagonalMapView.MainMap.nodes.Where(p => HNode.SquaredDistance(p, origin) > minDistance && HNode.SquaredDistance(p, origin) < maxDistance).ToList<HNode>();// && p != node).ToList<HNode>();
        return aoe;
    }
}
