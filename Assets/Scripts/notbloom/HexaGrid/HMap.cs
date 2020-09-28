using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace notbloom.HexagonalMap
{
    public class HMap
    {
        public const float innerRadius = 3f;
        public const float outerRadius = 0.866025404f;

        public List<HNode> nodes;

        public void CreateSimpleGrid(int rows, int cols)
        {
            //Create the nodes;
            nodes = new List<HNode>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // if (UnityEngine.Random.Range(0f, 1f) < 0.1f)
                    //     continue;
                    HNode node;
                    if (j % 2 == 0)
                    {
                        node = new HNode(i * innerRadius, j * outerRadius);
                    }
                    else
                    {
                        node = new HNode(i * innerRadius + innerRadius / 2f, j * outerRadius);
                    }

                    nodes.Add(node);
                }
            }
            //Register Neighbours
            foreach (HNode node in nodes)
            {
                node.neighbours = nodes.Where(p => HNode.SquaredDistance(p, node) < 3.8f && p != node).ToList<HNode>();
                Debug.Log(node.neighbours.Count);
            }
        }
    }

}