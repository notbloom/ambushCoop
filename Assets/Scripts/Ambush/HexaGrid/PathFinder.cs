using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ambush
{
    public class PathFinder
    {
        public static List<Node> FindTarget(Node from)
        {
            List<Node> path = new List<Node>();
            return path;
        }
        public static List<Node> Closest(Node from, Node target, int movement)
        {
            List<Node> path = new List<Node>();

            return path;
        }
        public static List<Node> AI_Meele(Node Start, Node Target, int movement, BoardFaction goThrough)
        {
            Node End = Target.neighbours.Where(x => x.occupant == null).OrderBy(y => y.SquaredDistance(Target)).First();
            if (End == null)
                return null;
            Dictionary<Node, Node> NearestToStartDictinoary = AIDijkstraMoveSearch(Start, End, goThrough);
            var shortestPath = new List<Node>();
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
        public static List<Node> AIClosestToObjective(Node Start, Node End, int movement, BoardFaction goThrough)
        {
            Dictionary<Node, Node> NearestToStartDictinoary = AIDijkstraMoveSearch(Start, End, goThrough);
            var shortestPath = new List<Node>();
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
        public static List<Node> GetShortestPathDijkstra(Node Start, Node End)
        {
            Dictionary<Node, Node> NearestToStartDictinoary = DijkstraSearch(Start, End);
            var shortestPath = new List<Node>();
            shortestPath.Add(End);
            BuildShortestPath(shortestPath, End, NearestToStartDictinoary);
            shortestPath.Reverse();
            return shortestPath;
        }

        private static void BuildShortestPath(List<Node> list, Node node, Dictionary<Node, Node> nearestToStart)
        {
            if (!nearestToStart.ContainsKey(node))
                return;
            list.Add(nearestToStart[node]);
            BuildShortestPath(list, nearestToStart[node], nearestToStart);
        }

        private static Dictionary<Node, Node> AIDijkstraMoveSearch(Node Start, Node End, BoardFaction goThrough)
        {
            Dictionary<Node, int> MinCostToStart = new Dictionary<Node, int>();
            Dictionary<Node, Node> NearestToStart = new Dictionary<Node, Node>();
            List<Node> visited = new List<Node>();
            MinCostToStart.Add(Start, 0);
            var prioQueue = new List<Node>();
            prioQueue.Add(Start);
            do
            {
                prioQueue = prioQueue.OrderBy(x => MinCostToStart[x]).ToList();
                var node = prioQueue.First();
                prioQueue.Remove(node);

                foreach (Node cnn in node.neighbours)
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

        private static Dictionary<Node, Node> DijkstraSearch(Node Start, Node End)
        {
            Dictionary<Node, int> MinCostToStart = new Dictionary<Node, int>();
            Dictionary<Node, Node> NearestToStart = new Dictionary<Node, Node>();
            List<Node> visited = new List<Node>();
            MinCostToStart.Add(Start, 0);
            var prioQueue = new List<Node>();
            prioQueue.Add(Start);
            do
            {
                prioQueue = prioQueue.OrderBy(x => MinCostToStart[x]).ToList();
                var node = prioQueue.First();
                prioQueue.Remove(node);

                foreach (Node cnn in node.neighbours)
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