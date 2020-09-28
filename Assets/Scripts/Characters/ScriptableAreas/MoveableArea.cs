using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
using System.Linq;

[CreateAssetMenu(fileName = "MoveableArea", menuName = "Area/MoveableArea", order = 0)]

public class MoveableArea : ScriptableArea
{
    public int distance;
    public override List<HNode> Targets(HNode origin, HNode target)
    {

        List<HNode> area = new List<HNode>();
        List<HNode> lastNeighbours = new List<HNode>() { origin };
        for (int i = 0; i < distance; i++)
        {
            List<HNode> currentNeighbours = new List<HNode>();
            foreach (HNode neighbour in lastNeighbours)
            {
                currentNeighbours.AddRange(neighbour.neighbours.Where(n => n.occupant == null && !area.Contains(n)).Distinct().ToList());
            }
            lastNeighbours = currentNeighbours;
            area.AddRange(currentNeighbours);
        }
        // = HexagonalMapView.MainMap.nodes.Where(p => HNode.SquaredDistance(p, target) < distance).ToList<HNode>();// && p != node).ToList<HNode>();
        return area;
    }
}
