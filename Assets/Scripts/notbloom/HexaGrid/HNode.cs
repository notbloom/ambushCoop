using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace notbloom.HexagonalMap
{
    public class HNode
    {
        public HPosition position;
        public float x => position.x;
        public float y => position.y;
        public List<HNode> neighbours;
        public HObject occupant;
        public List<HTrigger> triggers;
        public bool passable => true;

        public HNode(float x, float y)
        {
            position = new HPosition(x, y);
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
        public Vector3 ToVector3()
        {
            return new Vector3(x, 0, y);
        }

        public static float SquaredDistance(HNode a, HNode b) => HPosition.SquaredDistance(a.position, b.position);

    }
}