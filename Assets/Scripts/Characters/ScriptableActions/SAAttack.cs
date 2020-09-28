using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using notbloom.HexagonalMap;

[CreateAssetMenu(fileName = "new Attack", menuName = "TurnActions/Attack", order = 0)]
public class SAAttack : ScriptableAction
{
    public int targets;
    public int damage;
    public int range;
    public List<Status> statuses;
    public override void PerformAction(HNode from, List<HNode> targets)
    {
        //
    }
}
