using System.Collections.Generic;

namespace Ambush
{
    public static class Range
    {
        public static List<Node> Circle(Node origin, int distance)
        {
            var
                aoe = origin
                    .neighbours; //HexagonalMapView.MainMap.nodes.Where(p => Node.SquaredDistance(p, target) < distance).ToList<Node>();// && p != node).ToList<HNode>();
            return aoe;
        }

        public static List<Node> Ring(Node origin, int distance)
        {
            return origin.neighbours;
        }

        public static List<Node> Walkable(Node origin, int distance, BoardFaction faction)
        {
            return origin.neighbours;
        }
    }
}