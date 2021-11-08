using System.Linq;
using System.Collections.Generic;

namespace Ambush
{
    public static class Utils
    {

        public static float SquaredDistance(this Node a, Node b) => Node.SquaredDistance(a, b);

        public static string ToString(this List<Node> hNodes)
        {
            string output = "";
            foreach (Node node in hNodes)
            {
                output += node.ToString() + "\n";
            }
            return output;
        }
        // public static string ToString(this HNode hNode)
        // {
        //     return "HNode[" + hNode.ToString() + "," + hNode.y.

        // }
    }
}