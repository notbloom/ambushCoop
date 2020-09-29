using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;
public class PlayerAgent : AgentBase

{
    public List<ScriptableCard> actions;
    public ScriptableCard currentCard => actions[actionCount];

    void Start()
    {
        base.Init();
        transform.position = node.ToVector3();
        //  Debug.Log("algo");
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(agent.node.x, 0, agent.node.y);
    }
    public override void PlayTurn()
    {

    }
    public void ClickOnNode(HNode clickedNode)
    {

        List<HNode> areaOfEffect = new List<HNode>();
        List<HNode> r = currentCard.Range(agent.node, clickedNode);

        if (r.Contains(clickedNode))
        {
            areaOfEffect = currentCard.Area(node, clickedNode);
        }
        foreach (HNode _node in areaOfEffect)
        {
            Debug.Log(_node.ToString());
        }
        PerformAction(actions[actionCount], areaOfEffect);
        actionCount++;
        if (actionCount == actions.Count)
            actionCount = 0;
        RoundsEngine.EndTurn(this);
    }
    public void PerformAction(ScriptableCard action, List<HNode> targets)
    {
        action.PerformAction(agent.node, targets, this);
    }
}
