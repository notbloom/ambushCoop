using System.Collections.Generic;
using System.Linq;

namespace Ambush
{
    public static class Area
    {
        public static List<Node> Ring(Node center, int radius)
        {
            return Map.nodeCollection.Get(HexOperations.Ring(center.hex, radius));
        }

        public static List<Node> Circle(Node center, int radius)
        {
            return Map.nodeCollection.Get(HexOperations.Circle(center.hex, radius));
        }

        public static List<Node> Empty(List<Node> list)
        {
            return list.Where(n => n.occupant == null).ToList();
        }

        public static List<Node> Straight(Node center, int radius)
        {
            var hexes = new List<Hex>();
            for (var i = 0; i < radius; i++)
                foreach (var direction in Hex.Directions)
                    hexes.Add(direction * i + center.hex);
            return Map.nodeCollection.Get(hexes);
        }

        public static List<Node> Path(Node origin, Node target, int distance)
        {
            //Path Finderrrrr
            return PathFinder.GetShortestPathDijkstra(origin, target);
            // List<Node> aoe = new List<Node>{ target }; 
            // return aoe;
        }
    }
}