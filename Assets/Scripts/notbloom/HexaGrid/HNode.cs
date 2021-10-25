using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace notbloom.HexagonalMap
{
    [Serializable]
    public class HNode
    {
        public const float innerRadius = 3f;
        public const float outerRadius = 0.866025404f;
        // public HPosition position;
        public int x;// => position.x;
        public int y;// => position.y;
        [NonSerialized]
        public List<HNode> neighbours;
        [NonSerialized]
        public HObject occupant;
        [NonSerialized]
        public List<HTrigger> triggers;
        public bool passable => true;

        public HNode(int x, int y)
        {
            this.x = x;
            this.y = y;
            //position = new HPosition(x, y);
            neighbours = new List<HNode>();
        }

        //public new string ToString() => position.ToString();

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
            if (y % 2 == 0)
            {
                return new Vector3(x * innerRadius, 0, y * outerRadius);
            }
            else
            {
                return new Vector3(x * innerRadius + innerRadius / 2f, 0, y * outerRadius);
            }

        }

        public static float SquaredDistance(HNode r, HNode c)
        {
            Vector3 a = r.ToVector3();
            Vector3 b = c.ToVector3();
            return (b.x - a.x) * (b.x - a.x) + (b.z - a.z) * (b.z - a.z);
        }



        //    HPosition.SquaredDistance( Vector3.squa );// a.position, b.position);

    }
}