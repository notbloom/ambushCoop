using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ambush
{
    [Serializable]
    public class Map
    {
        public static NodeCollection nodeCollection;
        public List<Node> nodes;
        public List<Node> startingNodes;

        public static List<Node> Ring(Node center, int radius)
        {
            return nodeCollection.Get(HexOperations.Ring(center.hex, radius));
        }

        public static List<Node> Circle(Node center, int radius)
        {
            return nodeCollection.Get(HexOperations.Circle(center.hex, radius));
        }


        public void Save()
        {
            var json = JsonUtility.ToJson(this);
            Debug.Log(json);
        }

        private List<Node> NodeLine(int xStart, int xEnd, int atY)
        {
            var list = new List<Node>();
            for (var i = xStart; i <= xEnd; i++) list.Add(new Node(i, atY));

            return list;
        }

        public void CreateGeneric()
        {
            //Create the nodes;
            nodes = new List<Node>();
            nodes.AddRange(NodeLine(12, 16, 0));
            nodes.AddRange(NodeLine(10, 16, 1));
            nodes.AddRange(NodeLine(8, 16, 2));
            nodes.AddRange(NodeLine(6, 16, 3));
            nodes.AddRange(NodeLine(4, 15, 4));
            nodes.AddRange(NodeLine(3, 14, 5));
            nodes.AddRange(NodeLine(2, 13, 6));
            nodes.AddRange(NodeLine(1, 12, 7));
            nodes.AddRange(NodeLine(0, 10, 8));
            nodes.AddRange(NodeLine(0, 8, 9));
            nodes.AddRange(NodeLine(0, 6, 10));
            nodes.AddRange(NodeLine(0, 4, 11));
            // for (int i = 0; i < 10; i++)
            // {
            //     for (int j = 0; j < 8; j++)
            //     {
            //         nodes.Add(new Node(i, j));
            //     }
            // }
            //
            //Set starting nodes
            nodeCollection = new NodeCollection();
            nodeCollection.Add(nodes);
            var startingHexes = new List<Hex>
            {
                new Hex(6, 3),
                new Hex(6, 4),
                new Hex(7, 3),
                new Hex(8, 2),
                new Hex(8, 3),
                new Hex(9, 2),
                new Hex(10, 1),
                new Hex(10, 2)
            };

            startingNodes = new List<Node>();

            foreach (var t in startingHexes) startingNodes.Add(nodeCollection.Get(t));
            //Register Neighbours
            ConnectCloseAsNeighbours();
        }
        // public void CreateGenericOld()
        // {
        //     //Create the nodes;
        //     nodes = new List<Node>();
        //
        //     var boardPointsY = new IEnumerable<ushort>[]
        //     {
        //         Utilities.FromTo(3,11),
        //         Utilities.FromTo(1,13),
        //         Utilities.FromTo(0,14),
        //         Utilities.FromTo(0,14),
        //         Utilities.FromTo(0,14),
        //         Utilities.FromTo(0,14),
        //         Utilities.FromTo(0,14),
        //         Utilities.FromTo(2,12),
        //         Utilities.LeftColumn(4,10)
        //     };
        //
        //     var boardPointsX = Enumerable.Range(0, boardPointsY.Length)
        //         .Select(x => (ushort)x);
        //
        //     var j = 0;
        //     foreach (var x in boardPointsX)
        //     {
        //         foreach (var y in boardPointsY[j++])
        //         {
        //             nodes.Add(new Node(x, y));
        //         }
        //     }
        //
        //     //Set starting nodes
        //     startingNodes = new List<Node>();
        //     for (int i = 0; i < 4; i++)
        //     {
        //         startingNodes.Add(nodes[i]);
        //     }
        //     //Register Neighbours
        //     ConnectCloseAsNeighbours();
        // }

        //public void CreateSimpleGrid(int rows, int cols)
        //{
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
        // public void SetStartingNodes(List<NodeData> nodeData)
        // {
        //     startingNodes = new List<Node>();
        //     foreach (NodeData node in nodeData)
        //     {
        //         startingNodes.Add(FindNodeByData(node));
        //     }
        // }

        // public Node FindNodeByData(NodeData nodeData)
        // {
        //     return nodes.FirstOrDefault(n => n.x == nodeData.x && n.y == nodeData.y);
        // }
        public Node FindNodeByVector2Int(Vector2Int nodeVector)
        {
            return nodes.FirstOrDefault(n => n.x == nodeVector.x && n.y == nodeVector.y);
        }

        public void ConnectCloseAsNeighbours(float distance = 3.8f) //8.550f
        {
            foreach (var node in nodes)
            {
                node.neighbours = nodes
                    .Where(p => Node.SquaredDistance(p, node) < Constants.hexSquaredDistanceToNeighbours && p != node)
                    .ToList();

                Debug.Log(node.neighbours.Count);
            }
        }
    }
}