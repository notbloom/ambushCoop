using System.Collections.Generic;
using System.Linq;

namespace Ambush
{
    public class PathFinder
    {
        public static List<Node> GetShortestPathDijkstra(Node Start, Node End)
        {
            var NearestToStartDictinoary = DijkstraSearch(Start, End);
            var shortestPath = new List<Node>();
            shortestPath.Add(End);
            BuildShortestPath(shortestPath, End, NearestToStartDictinoary);
            shortestPath.Reverse();
            return shortestPath;
        }

        private static Dictionary<Node, Node> DijkstraSearch(Node Start, Node End)
        {
            var MinCostToStart = new Dictionary<Node, int>();
            var NearestToStart = new Dictionary<Node, Node>();
            var visited = new List<Node>();
            MinCostToStart.Add(Start, 0);
            var prioQueue = new List<Node>();
            prioQueue.Add(Start);
            do
            {
                prioQueue = prioQueue.OrderBy(x => MinCostToStart[x]).ToList();
                var node = prioQueue.First();
                prioQueue.Remove(node);

                foreach (var cnn in node.neighbours)
                {
                    if (cnn.occupant != null)
                        continue;
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

        public static List<Node> MoveArea(Node origin, int steps, BoardFaction faction) //, List<Node> visited = null)
        {
            var visited = new List<Node>();
            visited.Add(origin);

            var fringes = new List<List<Node>>();
            fringes.Add(new List<Node> {origin});

            for (var i = 1; i <= steps; i++)
            {
                fringes.Add(new List<Node>());
                foreach (var node in fringes[fringes.Count - 1])
                foreach (var neighbour in node.neighbours.Except(visited))
                {
                    visited.Add(neighbour);
                    fringes[i].Add(neighbour);
                }
            }

            return visited;
            // visited ??= new List<Node>();
            // List<Node> vacant = new List<Node>();
            //
            // if (steps == 1)
            // {
            //     foreach (var neighbour in origin.neighbours.Except(visited))
            //     {
            //         visited.Add(neighbour);    
            //         if (origin.occupant == null)
            //             vacant.Add(neighbour);
            //     }
            //     
            // }
        }

        public static List<Node> FindTarget(Node from)
        {
            var path = new List<Node>();
            return path;
        }

        public static List<Node> Closest(Node from, Node target, int movement)
        {
            var path = new List<Node>();

            return path;
        }

        public static List<Node> AI_Meele(Node Start, Node Target, int movement, BoardFaction goThrough)
        {
            var End = Target.neighbours.Where(x => x.occupant == null).OrderBy(y => y.SquaredDistance(Target)).First();
            if (End == null)
                return null;
            var NearestToStartDictinoary = AIDijkstraMoveSearch(Start, End, goThrough);
            var shortestPath = new List<Node>();
            shortestPath.Add(End);
            BuildShortestPath(shortestPath, End, NearestToStartDictinoary);
            shortestPath.Reverse();


            if (shortestPath.Count > movement)
                shortestPath.RemoveRange(movement, shortestPath.Count - movement);
            while (shortestPath[shortestPath.Count - 1].occupant != null) shortestPath.RemoveAt(shortestPath.Count - 1);
            return shortestPath;
        }

        public static List<Node> AIClosestToObjective(Node Start, Node End, int movement, BoardFaction goThrough)
        {
            var NearestToStartDictinoary = AIDijkstraMoveSearch(Start, End, goThrough);
            var shortestPath = new List<Node>();
            shortestPath.Add(End);
            BuildShortestPath(shortestPath, End, NearestToStartDictinoary);
            shortestPath.Reverse();


            if (shortestPath.Count > movement)
                shortestPath.RemoveRange(movement, shortestPath.Count - movement);
            while (shortestPath[shortestPath.Count - 1].occupant != null) shortestPath.RemoveAt(shortestPath.Count - 1);
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
            var MinCostToStart = new Dictionary<Node, int>();
            var NearestToStart = new Dictionary<Node, Node>();
            var visited = new List<Node>();
            MinCostToStart.Add(Start, 0);
            var prioQueue = new List<Node>();
            prioQueue.Add(Start);
            do
            {
                prioQueue = prioQueue.OrderBy(x => MinCostToStart[x]).ToList();
                var node = prioQueue.First();
                prioQueue.Remove(node);

                foreach (var cnn in node.neighbours)
                {
                    //SKIP UNAVOIDABLE OBSTACLES
                    if (node.occupant != null)
                        if (node.occupant.faction != goThrough)
                            continue;
                    //SKIP VISITED NODES
                    if (visited.Contains(cnn))
                        continue;


                    //CALCULATE THE COST OF THE NODE
                    //DEFAULT IS 1
                    var cost = 1;
                    //IF THE NODE IS ADJACENT BUT HAS ANY OBJECT
                    if (node.neighbours.Contains(End))
                        if (cnn.occupant != null)
                            // visited.Add(cnn);
                            // continue;
                            cost = 100;
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
    }
}