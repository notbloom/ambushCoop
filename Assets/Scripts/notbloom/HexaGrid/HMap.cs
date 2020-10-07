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