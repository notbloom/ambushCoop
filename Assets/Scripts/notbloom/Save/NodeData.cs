using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
[Serializable]
public class NodeData
{
    public int x;
    public int y;

    public NodeData(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public NodeData(HNode node)
    {
        this.x = node.x;
        this.y = node.y;
    }
}