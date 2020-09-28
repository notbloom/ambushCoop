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
    public ScriptableAOE aoe;
    public ScriptableTargetRequest targetRequest;

    //Scriptable Target Picker
    public void AITurn(HNode origin)
    {
        List<HNode> rangeList = Range(origin, origin);
        List<HNode> targets = RequestTarget(rangeList, HObjectFactions.HPlayerFaction);
        PerformAction(origin, targets);
    }
    public List<HNode> RequestTarget(List<HNode> area, HObjectFactions targetFaction)
    {
        return targetRequest.Request(area, targetFaction);
    }
    public void PerformAction(HNode from, List<HNode> targets)
    {
        action.PerformAction(from, targets);
    }
    public List<HNode> Range(HNode origin, HNode target)
    {
        return aoe.Range.Targets(origin, target);
    }
    public List<HNode> Area(HNode origin, HNode target)
    {
        return aoe.Area.Targets(origin, target);
    }
}
