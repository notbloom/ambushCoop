using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
[Serializable]
public class ObjectInstaceData
{
    public string string_id;
    public NodeData node;
    public ObjectDataTypes type;

    public ObjectInstaceData(AgentBase agentBase)
    {
        node = new NodeData(agentBase.node);
        string_id = agentBase.string_id;
    }
    public ObjectInstaceData(NodeData nodeData)
    {
        node = nodeData;
        //string_id = agentBase.string_id;
    }
}

public class EnemyInstanceData
{
    public string visible_id;
    public string baseStats_id;
    public List<string> cards_id;

}