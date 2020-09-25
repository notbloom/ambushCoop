using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace notbloom.HexagonalMap
{
    public class HPathFinder
    {
        public static List<HNode> FindTarget(HNode from)
        {
            List<HNode> path = new List<HNode>();
            return path;
        }
        public static List<HNode> Closest(HNode from, HNode target, int movement)
        {
            List<HNode> path = new List<HNode>();

            return path;
        }
        public static List<HNode> ClosestWithRange(HNode from, HNode target, int movement)
        {
            List<HNode> path = new List<HNode>();
            return path;
        }
        public static List<HNode> GetShortestPathDijkstra(HNode Start, HNode End)
        {
            Dictionary<HNode, HNode> NearestToStartDictinoary = DijkstraSearch(Start, End);

            // foreach (KeyValuePair<HNode, HNode> entry in NearestToStartDictinoary)
            // {
            //     Debug.Log(entry.Key.ToString() + " => " + entry.Key.ToString());
            //     // do something with entry.Value or entry.Key
            // }
            var shortestPath = new List<HNode>();
            shortestPath.Add(End);
            BuildShortestPath(shortestPath, End, NearestToStartDictinoary);
            shortestPath.Reverse();
            // foreach (HNode node in shortestPath)
            // {
            //     Debug.Log(node.ToString());
            // }
            return shortestPath;
        }

        private static void BuildShortestPath(List<HNode> list, HNode node, Dictionary<HNode, HNode> nearestToStart)
        {
            if (!nearestToStart.ContainsKey(node))
                return;
            list.Add(nearestToStart[node]);
            BuildShortestPath(list, nearestToStart[node], nearestToStart);
        }

        private static Dictionary<HNode, HNode> DijkstraSearch(HNode Start, HNode End)
        {
            Dictionary<HNode, int> MinCostToStart = new Dictionary<HNode, int>();
            Dictionary<HNode, HNode> NearestToStart = new Dictionary<HNode, HNode>();
            List<HNode> visited = new List<HNode>();
            //Start.MinCostToStart = 0;
            MinCostToStart.Add(Start, 0);
            var prioQueue = new List<HNode>();
            prioQueue.Add(Start);
            do
            {
                //prioQueue = prioQueue.OrderBy(x => x.MinCostToStart).ToList();
                prioQueue = prioQueue.OrderBy(x => MinCostToStart[x]).ToList();
                var node = prioQueue.First();
                prioQueue.Remove(node);
                //foreach (var cnn in node.neighbours.OrderBy(x => x.Cost))
                foreach (HNode cnn in node.neighbours)//.OrderBy(x => x.Cost))
                {
                    //      var childNode = cnn.ConnectedNode;
                    //    if (childNode.Visited)
                    if (visited.Contains(cnn))
                        continue;
                    //if (childNode.MinCostToStart == null ||
                    //node.MinCostToStart + cnn.Cost < childNode.MinCostToStart)
                    //     if (childNode.MinCostToStart == null ||
                    // node.MinCostToStart + cnn.Cost < childNode.MinCostToStart)
                    //TODO change cnn.Cost to terrain cost, water, etc
                    if (!MinCostToStart.ContainsKey(cnn) ||
                MinCostToStart[node] + 1 < MinCostToStart[cnn])

                    {

                        // childNode.MinCostToStart = node.MinCostToStart + cnn.Cost;
                        // childNode.NearestToStart = node;
                        // if (!prioQueue.Contains(childNode))
                        //     prioQueue.Add(childNode);

                        MinCostToStart[cnn] = MinCostToStart[node] + 1;
                        NearestToStart[cnn] = node;
                        if (!prioQueue.Contains(cnn))
                            prioQueue.Add(cnn);
                    }
                }
                visited.Add(node);
                if (node == End)
                    return NearestToStart;
            } while (prioQueue.Any());

            //I added this
            return NearestToStart;
        }
    }
}