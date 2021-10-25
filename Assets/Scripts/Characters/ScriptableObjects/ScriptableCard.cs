using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;

public enum TargetType
{
    HFriendly, HEnemy, HAny, HSelf
}
[CreateAssetMenu(fileName = "new Card", menuName = "TurnActions/Card", order = 0)]
public class ScriptableCard : ScriptableObject
{
    public ScriptableAction action;
    public ScriptableRange range;
    public ScriptableArea area;
    public ScriptableTargetRequest targetRequest;
    //public NodeAnimationFactory animationFactory;

    public string title;
    public string description;
    public int cost;
    //Scriptable Target Picker
    public void AITurn(HNode origin, AgentBase agent)
    {

        List<HNode> rangeList = range.Area(origin);
        // List<HNode> areaList = area.Area(origin, rangeList);
        List<HNode> targets = RequestTarget(rangeList, area, HObjectFactions.HPlayerFaction);
        if (targets != null && targets.Count > 0)
        {
            PerformAction(origin, targets, agent);
        }
        // Debug.Log("AITURN");
    }
    public List<HNode> RequestTarget(List<HNode> range, ScriptableArea scriptableArea, HObjectFactions targetFaction)
    {
        return targetRequest.Request(range, scriptableArea, targetFaction);
    }
    public void PerformAction(HNode from, List<HNode> targets, AgentBase agent)
    {
        action.PerformAction(from, targets, agent);
    }
    public List<HNode> Range(HNode origin)
    {
        return range.Area(origin);
    }
    public List<HNode> Area(HNode origin, HNode target)
    {
        return area.Area(origin, target);
    }
}
