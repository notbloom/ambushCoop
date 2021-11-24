using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;

public class PlayerAgent : AgentBase, ISpawn
{
    public List<ScriptableCard> actions;
    //public ScriptableCard currentCard => actions[actionCount];
    public bool playingACard;
    public void Create()
    {
        base.Create();
    }
    public void Spawn(ObjectInstaceData objectInstaceData)
    {
        Debug.Log(objectInstaceData.node.x);
        Debug.Log(objectInstaceData.node.y);
        node = HexagonalMapView.FindNodeByData(objectInstaceData.node);
        base.Init(objectInstaceData);
        transform.position = node.ToVector3();
        //  Debug.Log("algo");
    }
    public void Spawn(HNode node)
    {

        base.Init(node);
        transform.position = node.ToVector3();
        //  Debug.Log("algo");
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(agentID.unique_id);
        //transform.position = new Vector3(agent.node.x, 0, agent.node.y);
    }
    public override void PlayTurn()
    {

    }
    public override string Intent()
    {
        return "Player Turn";
    }
    public void ClickOnNode(HNode clickedNode, ScriptableCard currentCard)
    {

        List<HNode> areaOfEffect = new List<HNode>();
        List<HNode> r = currentCard.Range(agent.node);//, clickedNode);

        if (r.Contains(clickedNode))
        {
            areaOfEffect = currentCard.Area(node, clickedNode);
        }
        PerformAction(currentCard, areaOfEffect);
        AreaView.ResetView();
        //RoundsEngine.EndTurn(this);
    }
    public void PerformAction(ScriptableCard action, List<HNode> targets)
    {
        action.PerformAction(agent.node, targets, this);
    }
}
