using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System.Linq;

[CreateAssetMenu(fileName = "new RingArea", menuName = "Range/RingRange", order = 0)]
public class RingRange : ScriptableRange
{
    // Start is called before the first frame update public float minDistance;
    public float maxDistance;
    public float minDistance;
    public override List<HNode> Area(HNode origin)
    {
        float squaredMinDistance = minDistance * minDistance;
        float squaredMaxDistance = maxDistance * maxDistance;
        List<HNode> aoe = HexagonalMapView.MainMap.nodes.Where(p => HNode.SquaredDistance(p, origin) > squaredMinDistance && HNode.SquaredDistance(p, origin) < squaredMaxDistance).ToList<HNode>();// && p != node).ToList<HNode>();
        return aoe;
    }
}
