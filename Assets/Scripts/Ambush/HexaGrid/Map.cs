using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using notbloom.HexagonalMap;
namespace Ambush
{
    //public class Map
    //{
    //    public List<Node> nodes;

    //    public bool isNodeOccupied(Node node) => node.piece != null;
    //    public static Map Load(string ID)
    //    {
    //        return null;
    //    }
    //    public static Map CreateGeneric() { return null; }

    //}

    public static class Utilities
    {
        public static ushort[] FromTo(int from, int to)
        {
            var list = new List<ushort>();
            for (int i = from; i <= to; i++)
            {
                list.Add((ushort)i);
            }

            return list.ToArray();
        }

        public static ushort[] LeftColumn(int from, int to)
        {
            var list = new List<ushort>();
            for (int i = from; i <= to; i++)
            {
                if (i % 2 != 0)
                    continue;

                list.Add((ushort)i);
            }

            return list.ToArray();
        }
    }

    [Serializable]
    public class Map
    {
        //public const float innerRadius = 3f;// * 1.5f;
        //public const float outerRadius = 0.866025404f;// * 1.5f;   

        public List<Node> nodes;
        public List<Node> startingNodes;

        public void Save()
        {
            string json = JsonUtility.ToJson(this);
            Debug.Log(json);
        }

        public void CreateGeneric()
        {
            //Create the nodes;
            nodes = new List<Node>();

            var boardPointsY = new IEnumerable<ushort>[]
            {
                Utilities.FromTo(3,11),
                Utilities.FromTo(1,13),
                Utilities.FromTo(0,14),
                Utilities.FromTo(0,14),
                Utilities.FromTo(0,14),
                Utilities.FromTo(0,14),
                Utilities.FromTo(0,14),
                Utilities.FromTo(2,12),
                Utilities.LeftColumn(4,10)
            };

            var boardPointsX = Enumerable.Range(0, boardPointsY.Length)
                .Select(x => (ushort)x);

            var j = 0;
            foreach (var x in boardPointsX)
            {
                foreach (var y in boardPointsY[j++])
                {
                    nodes.Add(new Node(x, y));
                }
            }

            //Set starting nodes
            startingNodes = new List<Node>();
            //for (int i = 0; i < 10; i++)
            //{
            //    startingNodes.Add(nodes[i]);
            //}
            //Register Neighbours
            ConnectCloseAsNeighbours();
        }

        //public void CreateSimpleGrid(int rows, int cols)
        //{
        //    //Create the nodes;
        //    nodes = new List<Node>();

        //    var startingX = Enumerable.Range(1, 5)
        //        .Concat(Enumerable.Repeat(5, 3))
        //        .Concat(Enumerable.Range(3, 5).Reverse())
        //        .Select(x=>(ushort)x);

        //    var startingY = Enumerable.Range(0, 8)
        //        .Select(x => (ushort)x);

        //    foreach (var i in startingX)
        //    {
        //        foreach (var j in startingY)
        //        {
        //            nodes.Add(new Node(i, j)); //node);
        //        }
        //    }

        //    //for (ushort i = 0; i < rows; i++)
        //    //{
        //    //    for (ushort j = 0; j < cols; j++)
        //    //    {
        //    //        nodes.Add(new Node(i, j)); //node);
        //    //    }
        //    //}
        //    //Set starting nodes
        //    startingNodes = new List<Node>();
        //    for (int i = 0; i < rows; i++)
        //    {
        //        startingNodes.Add(nodes[i]);
        //    }
        //    //Register Neighbours
        //    ConnectCloseAsNeighbours();
        //}
        //implementar cuando cambie nodedata a ushort
        //public void CreateFromNodeData(List<NodeData> nodeData)
        //{
        //    nodes = new List<Node>();
        //    foreach (NodeData node in nodeData)
        //    {
        //        nodes.Add(new Node(node.x, node.y));
        //    }
        //    ConnectCloseAsNeighbours();
        //}
        public void SetStartingNodes(List<NodeData> nodeData)
        {
            startingNodes = new List<Node>();
            foreach (NodeData node in nodeData)
            {
                startingNodes.Add(FindNodeByData(node));
            }
        }

        public Node FindNodeByData(NodeData nodeData)
        {
            return nodes.FirstOrDefault(n => n.x == nodeData.x && n.y == nodeData.y);
        }
        public Node FindNodeByVector2Int(Vector2Int nodeVector)
        {
            return nodes.FirstOrDefault(n => n.x == nodeVector.x && n.y == nodeVector.y);
        }

        public void ConnectCloseAsNeighbours(float distance = 3.8f) //8.550f
        {
            foreach (Node node in nodes)
            {
                node.neighbours = nodes
                    .Where(p => Node.SquaredDistance(p, node) < Constants.hexSquaredDistanceToNeighbours && p != node)
                    .ToList<Node>();

                Debug.Log(node.neighbours.Count);
            }
        }
    }

}