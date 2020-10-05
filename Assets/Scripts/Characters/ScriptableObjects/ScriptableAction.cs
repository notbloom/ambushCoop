using UnityEngine;
using notbloom.HexagonalMap;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "TurnAction", menuName = "Char/TurnAction", order = 0)]
public abstract class ScriptableAction : ScriptableObject
{
    //   public int targets;
    // public abstract bool ValidateTargets(List<HNode> targets);

    public abstract void PerformAction(HNode from, List<HNode> targets, AgentBase agent);
}
