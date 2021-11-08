using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Ambush
{
    [Serializable]
    public class Node
    {      
        public const float innerRadius = 3f;
        public const float outerRadius = 0.866025404f;
     
        public ushort x;// => position.x;
        public ushort y;// => position.y;

        [NonSerialized]
        public List<Node> neighbours;

        [NonSerialized]
        public BoardObject occupant;

        [NonSerialized]
        public List<HTrigger> triggers;

        public bool passable => true;

        public Node(ushort x, ushort y)
        {
            this.x = x;
            this.y = y;            
            neighbours = new List<Node>();
        }

        //public new string ToString() => position.ToString();

        public string ToStringWithNeighbours()
        {
            string output = ToString() + "\n";
            output += "Neighbours(" + neighbours.Count.ToString() + "):\n";
            foreach (Node node in neighbours)
            {
                output += node.ToString() + "\n";
            }
            return output;
        }
        public Vector3 ToVector3()
        {
            if (y % 2 == 0)
            {
                return new Vector3(x * innerRadius, 0, y * outerRadius);
            }
            else
            {
                return new Vector3(x * innerRadius + innerRadius / 2f, 0, y * outerRadius);
            }

        }

        public static float SquaredDistance(Node r, Node c)
        {
            Vector3 a = r.ToVector3();
            Vector3 b = c.ToVector3();
            return (b.x - a.x) * (b.x - a.x) + (b.z - a.z) * (b.z - a.z);
        }

    }
}