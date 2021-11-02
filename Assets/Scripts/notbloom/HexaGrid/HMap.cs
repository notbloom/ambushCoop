using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
namespace notbloom.HexagonalMap
{
    [Serializable]
    public class HMap
    {
        public const float innerRadius = 3f;
        public const float outerRadius = 0.866025404f;

        public List<HNode> nodes;
        public List<HNode> startingNodes;

        public void Save()
        {
            string json = JsonUtility.ToJson(this);
            Debug.Log(json);
        }
        public void CreateSimpleGrid(int rows, int cols)
        {
            //Create the nodes;
            nodes = new List<HNode>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    nodes.Add(new HNode(i, j)); //node);
                }
            }
            //Set starting nodes
            startingNodes = new List<HNode>();
            for (int i = 0; i < rows; i++)
            {
                startingNodes.Add(nodes[i]);
            }
            //Register Neighbours
            ConnectCloseAsNeighbours();
        }
        public void CreateFromNodeData(List<NodeData> nodeData)
        {
            nodes = new List<HNode>();
            foreach (NodeData node in nodeData)
            {
                nodes.Add(new HNode(node.x, node.y));
            }
            ConnectCloseAsNeighbours();
        }
        public void SetStartingNodes(List<NodeData> nodeData) {
            startingNodes = new List<HNode>();
            foreach (NodeData node in nodeData)
            {
                startingNodes.Add(FindNodeByData(node));
            }
        }
        
        public HNode FindNodeByData(NodeData nodeData)
        {
            return nodes.Where(n => n.x == nodeData.x && n.y == nodeData.y).First();
        }
        public HNode FindNodeByVector2Int(Vector2Int nodeVector)
        {
            return nodes.Where(n => n.x == nodeVector.x && n.y == nodeVector.y).First();
        }
        public void ConnectCloseAsNeighbours(float distance = 3.8f)
        {
            foreach (HNode node in nodes)
            {
                node.neighbours = nodes.Where(p => HNode.SquaredDistance(p, node) < distance && p != node).ToList<HNode>();
                Debug.Log(node.neighbours.Count);
            }
        }
    }

}