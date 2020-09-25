using System.Linq;
using System.Collections.Generic;

namespace notbloom.HexagonalMap
{
    public class HNode
    {
        public HPosition position;
        public float x => position.x;
        public float y => position.y;
        public List<HNode> neighbours;

        public List<HOcupant> occupant;
        public bool passable => true;

        public HNode(float x, float y)
        {
            position = new HPosition(x, y);
            occupant = new List<HOcupant>();
            neighbours = new List<HNode>();
        }

        public new string ToString() => position.ToString();

        public string ToStringWithNeighbours()
        {
            string output = ToString() + "\n";
            output += "Neighbours(" + neighbours.Count.ToString() + "):\n";
            foreach (HNode node in neighbours)
            {
                output += node.ToString() + "\n";
            }
            return output;
        }

        public static float SquaredDistance(HNode a, HNode b) => HPosition.SquaredDistance(a.position, b.position);

    }
}