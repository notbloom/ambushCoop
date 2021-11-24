using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Ambush
{
    public static class Area
    {
        
        public static List<Node> Circle(Node origin, Node target, int distance)
        {
            List<Node> aoe = origin.neighbours; //HexagonalMapView.MainMap.nodes.Where(p => Node.SquaredDistance(p, target) < distance).ToList<Node>();// && p != node).ToList<HNode>();
            return aoe;
        }
         public static List<Node> Path(Node origin, Node target, int distance)
        {
            //Path Finderrrrr
            List<Node> aoe = new List<Node>{ target }; 
            return aoe;
        }
    }

}
