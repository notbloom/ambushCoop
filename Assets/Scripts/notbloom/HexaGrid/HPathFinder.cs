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
        public static List<HNode> AI_Meele(HNode Start, HNode Target, int movement, HObjectFactions goThrough)
        {
            HNode End = Target.neighbours.Where(x => x.occupant == null).OrderBy(y => y.SquaredDistance(Target)).First();
            if (End == null)
                return null;
            Dictionary<HNode, HNode> NearestToStartDictinoary = AIDijkstraMoveSearch(Start, End, goThrough);
            var shortestPath = new List<HNode>();
            shortestPath.Add(End);
            BuildShortestPath(shortestPath, End, NearestToStartDictinoary);
            shortestPath.Reverse();


            if (shortestPath.Count > movement)
                shortestPath.RemoveRange(movement, shortestPath.Count - movement);
            while (shortestPath[shortestPath.Count - 1].occupant != null)
            {
                shortestPath.RemoveAt(shortestPath.Count - 1);
            }
            return shortestPath;
        }
        public static List<HNode> AIClosestToObjective(HNode Start, HNode End, int movement, HObjectFactions goThrough)
        {
            Dictionary<HNode, HNode> NearestToStartDictinoary = AIDijkstraMoveSearch(Start, End, goThrough);
            var shortestPath = new List<HNode>();
            shortestPath.Add(End);
            BuildShortestPath(shortestPath, End, NearestToStartDictinoary);
            shortestPath.Reverse();


            if (shortestPath.Count > movement)
                shortestPath.RemoveRange(movement, shortestPath.Count - movement);
            while (shortestPath[shortestPath.Count - 1].occupant != null)
            {
                shortestPath.RemoveAt(shortestPath.Count - 1);
            }
            return shortestPath;
        }
        public static List<HNode> GetShortestPathDijkstra(HNode Start, HNode End)
        {
            Dictionary<HNode, HNode> NearestToStartDictinoary = DijkstraSearch(Start, End);
            var shortestPath = new List<HNode>();
            shortestPath.Add(End);
            BuildShortestPath(shortestPath, End, NearestToStartDictinoary);
            shortestPath.Reverse();
            return shortestPath;
        }

        private static void BuildShortestPath(List<HNode> list, HNode node, Dictionary<HNode, HNode> nearestToStart)
        {
            if (!nearestToStart.ContainsKey(node))
                return;
            list.Add(nearestToStart[node]);
            BuildShortestPath(list, nearestToStart[node], nearestToStart);
        }

        private static Dictionary<HNode, HNode> AIDijkstraMoveSearch(HNode Start, HNode End, HObjectFactions goThrough)
        {
            Dictionary<HNode, int> MinCostToStart = new Dictionary<HNode, int>();
            Dictionary<HNode, HNode> NearestToStart = new Dictionary<HNode, HNode>();
            List<HNode> visited = new List<HNode>();
            MinCostToStart.Add(Start, 0);
            var prioQueue = new List<HNode>();
            prioQueue.Add(Start);
            do
            {
                prioQueue = prioQueue.OrderBy(x => MinCostToStart[x]).ToList();
                var node = prioQueue.First();
                prioQueue.Remove(node);

                foreach (HNode cnn in node.neighbours)
                {
                    //SKIP UNAVOIDABLE OBSTACLES
                    if (node.occupant != null)
                    {
                        if (node.occupant.faction != goThrough)
                            continue;

                    }
                    //SKIP VISITED NODES
                    if (visited.Contains(cnn))
                        continue;


                    //CALCULATE THE COST OF THE NODE
                    //DEFAULT IS 1
                    int cost = 1;
                    //IF THE NODE IS ADJACENT BUT HAS ANY OBJECT
                    if (node.neighbours.Contains(End))
                    {
                        if (cnn.occupant != null)
                        {
                            // visited.Add(cnn);
                            // continue;
                            cost = 100;
                        }
                    }
                    //TODO change cnn.Cost to terrain cost, water, etc
                    if (!MinCostToStart.ContainsKey(cnn) ||
                        MinCostToStart[node] + cost < MinCostToStart[cnn])

                    {
                        MinCostToStart[cnn] = MinCostToStart[node] + cost;
                        NearestToStart[cnn] = node;
                        if (!prioQueue.Contains(cnn))
                            prioQueue.Add(cnn);
                    }
                }
                visited.Add(node);
                //CHECK END CONDITIONS
                //IF THIS NODE IS ADJACENT TO OUR TARGET
                // if (node.neighbours.Contains(End))
                // {
                //     //IF THIS NODE IS EMPTY
                //     if (node.occupant == null)
                //     {
                //         return NearestToStart;
                //     }
                // }
                if (node == End)
                    return NearestToStart;
            } while (prioQueue.Any());

            //I added this
            return NearestToStart;
        }

        private static Dictionary<HNode, HNode> DijkstraSearch(HNode Start, HNode End)
        {
            Dictionary<HNode, int> MinCostToStart = new Dictionary<HNode, int>();
            Dictionary<HNode, HNode> NearestToStart = new Dictionary<HNode, HNode>();
            List<HNode> visited = new List<HNode>();
            MinCostToStart.Add(Start, 0);
            var prioQueue = new List<HNode>();
            prioQueue.Add(Start);
            do
            {
                prioQueue = prioQueue.OrderBy(x => MinCostToStart[x]).ToList();
                var node = prioQueue.First();
                prioQueue.Remove(node);

                foreach (HNode cnn in node.neighbours)
                {
                    // if (cnn.occupant != null)
                    //     continue;
                    if (visited.Contains(cnn))
                        continue;
                    //TODO change cnn.Cost to terrain cost, water, etc
                    if (!MinCostToStart.ContainsKey(cnn) ||
                        MinCostToStart[node] + 1 < MinCostToStart[cnn])

                    {
                        MinCostToStart[cnn] = MinCostToStart[node] + 1;
                        NearestToStart[cnn] = node;
                        if (!prioQueue.Contains(cnn))
                            prioQueue.Add(cnn);
                    }
                }
                visited.Add(node);
                // if (End.occupant != null && node.neighbours.Contains(End))
                //     return NearestToStart;
                if (node == End)
                    return NearestToStart;
            } while (prioQueue.Any());

            //I added this
            return NearestToStart;
        }
    }
}