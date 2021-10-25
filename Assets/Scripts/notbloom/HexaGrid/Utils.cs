using System.Linq;
using System.Collections.Generic;

namespace notbloom.HexagonalMap
{
    public static class Utils
    {

        public static float SquaredDistance(this HNode a, HNode b) => HNode.SquaredDistance(a, b);

        public static string ToString(this List<HNode> hNodes)
        {
            string output = "";
            foreach (HNode node in hNodes)
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