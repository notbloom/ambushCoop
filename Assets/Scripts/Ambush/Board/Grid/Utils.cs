using System.Collections.Generic;

namespace Ambush
{
    public static class Utils
    {
        public static float SquaredDistance(this Node a, Node b)
        {
            return Node.SquaredDistance(a, b);
        }

        public static string ToString(this List<Node> hNodes)
        {
            var output = "";
            foreach (var node in hNodes) output += node + "\n";
            return output;
        }
        // public static string ToString(this HNode hNode)
        // {
        //     return "HNode[" + hNode.ToString() + "," + hNode.y.

        // }
    }
}