using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using Object = UnityEngine.Object;

namespace Ambush
{
    [Serializable]
    [DebuggerDisplay("({x},{y})")]
    public class Node
    {
        public static float size = 1.5f;
        public Hex hex;
        public int x => hex.r; //r
        public int y => hex.q; //q in qubic
        public int z => (- y - x); 
        
        [NonSerialized]
        public List<Node> neighbours;

        [NonSerialized] 
        public BoardObject occupant;
        public Node(int q, int r)
        {
            hex = new Hex(q, r);
                        
            neighbours = new List<Node>();
        }

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

        public Vector3 ToVector3() => hex.FlatToVector3(size);
        // {
        //     if (y % 2 == 0)
        //     {
        //         return new Vector3(x * Constants.hexInnerRadius, 0, y * Constants.hexOuterRadius);
        //     }
        //     else
        //     {
        //         return new Vector3(x * Constants.hexInnerRadius + Constants.hexInnerRadius / 2f, 0, y * Constants.hexOuterRadius);
        //     }
        //
        // }

        public static float SquaredDistance(Node r, Node c)
        {
            Vector3 a = r.ToVector3();
            Vector3 b = c.ToVector3();
            return (b.x - a.x) * (b.x - a.x) + (b.z - a.z) * (b.z - a.z);
        }

    }
}